using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

using ConsoleWebServer.Framework;
using ConsoleWebServer.Framework.ActionResults;
using ConsoleWebServer.Framework.Contracts;
using ConsoleWebServer.Framework.Exceptions;
using ConsoleWebServer.Framework.Handlers;
using ConsoleWebServer.Framework.HttpMessages;
using ConsoleWebServer.Framework.HttpMessages.Contracts;

using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using Ninject.Parameters;

namespace ConsoleWebServer.Application.NinjectModules
{
    public class ConsoleWebServerModule : NinjectModule
    {
        private const string RequestConstructorArgument = "request";
        private const string ActionResultFactoryConstructorArgument = "actionResultFactory";
        private const string ActionResultName = "actionResult";

        public override void Load()
        {
            this.Kernel.Bind(x =>
                             {
                                 x.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                                  .SelectAllClasses()
                                  .BindDefaultInterface();
                             });

            this.Bind<IHttpResponseFactory>().ToFactory().InSingletonScope();
            this.Rebind<IHttpResponse>().To<HttpResponse>().Named(typeof(HttpResponse).Name);

            this.Bind<IHttpRequestFactory>().ToFactory().InSingletonScope();
            this.Rebind<IHttpRequest>().To<HttpRequest>().Named(typeof(HttpRequest).Name);

            this.Bind<IActionDescriptorFactory>().ToFactory().InSingletonScope();
            this.Bind<IActionDescriptor>().To<ActionDescriptor>().Named(typeof(ActionDescriptor).Name);

            this.Bind<IActionResultFactory>().ToFactory().InSingletonScope();
            this.Bind<IActionResult>().To<ContentActionResult>().Named(typeof(ContentActionResult).Name);
            this.Bind<IActionResult>().To<JsonActionResult>().Named(typeof(JsonActionResult).Name);
            this.Bind<IActionResult>().To<RedirectActionResult>().Named(typeof(RedirectActionResult).Name);

            this.Bind<IActionResult>()
                .To<ActionResultWithoutCachingDecorator>()
                .Named(typeof(ActionResultWithoutCachingDecorator).Name);

            this.Bind<IActionResult>()
                .To<ActionResultWithCorsDecorator>()
                .Named(typeof(ActionResultWithCorsDecorator).Name);

            this.Bind<IActionResult>()
                .ToMethod(ctx =>
                          {
                              IList<IParameter> contextParams = ctx.Parameters.ToList();
                              var actionResultToDecorate = ctx.Kernel.Get<IActionResult>(
                                                                                         typeof(ContentActionResult)
                                                                                             .Name,
                                                                                         contextParams[0],
                                                                                         contextParams[1]);

                              var wrappedContentActionResult = new ConstructorArgument(ActionResultName,
                                                                                       actionResultToDecorate);

                              var decoratedResult =
                                  ctx.Kernel.Get<IActionResult>(typeof(ActionResultWithoutCachingDecorator).Name,
                                                                wrappedContentActionResult);
                              return decoratedResult;
                          })
                .NamedLikeFactoryMethod(
                                        (IActionResultFactory actionResultFactory) =>
                                            actionResultFactory.GetContentActionResultWithNoCaching(null, null));

            this.Bind<IActionResult>()
                .ToMethod(ctx =>
                          {
                              IList<IParameter> contextParams = ctx.Parameters.ToList();
                              var actionResultToDecorate = ctx.Kernel.Get<IActionResult>(
                                                                                         typeof(JsonActionResult).Name,
                                                                                         contextParams[0],
                                                                                         contextParams[1]);

                              var wrappedJsonActionResult = new ConstructorArgument(ActionResultName,
                                                                                    actionResultToDecorate);

                              var decorator =
                                  ctx.Kernel.Get<IActionResult>(typeof(ActionResultWithoutCachingDecorator).Name,
                                                                wrappedJsonActionResult,
                                                                contextParams[2]);
                              return decorator;
                          })
                .NamedLikeFactoryMethod(
                                        (IActionResultFactory actionResultFactory) =>
                                            actionResultFactory.GetJsonActionResultWithCors(null, null, null));

            this.Bind<IActionResult>()
                .ToMethod(ctx =>
                          {
                              IList<IParameter> contextParams = ctx.Parameters.ToList();
                              var actionResultToDecorate = ctx.Kernel.Get<IActionResult>(
                                                                                         typeof(ContentActionResult)
                                                                                             .Name,
                                                                                         contextParams[0],
                                                                                         contextParams[1]);

                              var constructorArgument = new ConstructorArgument(ActionResultName, actionResultToDecorate);

                              var actionResultWithNoCaching =
                                  ctx.Kernel.Get<IActionResult>(typeof(ActionResultWithoutCachingDecorator).Name,
                                                                constructorArgument,
                                                                contextParams[2]);

                              var decoratedConstructorArgument = new ConstructorArgument(ActionResultName,
                                                                                         actionResultWithNoCaching);

                              var actionResultWithCorsAndNoCaching =
                                  ctx.Kernel.Get<IActionResult>(typeof(ActionResultWithCorsDecorator).Name,
                                                                decoratedConstructorArgument,
                                                                contextParams[2]);

                              return actionResultWithCorsAndNoCaching;
                          })
                .NamedLikeFactoryMethod(
                                        (IActionResultFactory actionResultFactory) =>
                                            actionResultFactory.GetContentActionResultWithCorsWithoutCaching(null, null,
                                                                                                             null));

            this.Bind<IHandler>()
                .ToMethod(ctx =>
                          {
                              var assembly = typeof(IHandler).Assembly;

                              var handlerTypes = assembly.GetTypes()
                                                         .Where(t => t.IsAbstract == false
                                                                     && typeof(IHandler).IsAssignableFrom(t)
                                                                     && t.IsSubclassOf(typeof(BaseHandler)))
                                                         .OrderByDescending(t => t.Name)
                                                         .ToList();

                              var handlers = new List<IHandler>();
                              for (var i = 0; i < handlerTypes.Count; i++)
                              {
                                  var currentHandlerType = handlerTypes[i];

                                  var currentHandler = ctx.Kernel.Get(currentHandlerType) as IHandler;
                                  handlers.Add(currentHandler);
                                  if (i > 0)
                                  {
                                      handlers[i - 1].Next = handlers[i];
                                  }
                              }

                              return handlers.FirstOrDefault();
                          });

            this.Bind<Func<IHttpRequest, Controller>>()
                .ToMethod(ctx =>
                              request =>
                              {
                                  var controllerClassName = request.Action.ControllerName + "Controller";
                                  var type =
                                      Assembly.GetEntryAssembly()
                                              .GetTypes()
                                              .FirstOrDefault(
                                                              x =>
                                                                  string.Equals(x.Name, controllerClassName,
                                                                                StringComparison
                                                                                    .CurrentCultureIgnoreCase) &&
                                                                  typeof(Controller).IsAssignableFrom(x));
                                  if (type == null)
                                  {
                                      throw new HttpNotFoundException(
                                          $"Controller with name {controllerClassName} not found!");
                                  }

                                  var requestArgument = new ConstructorArgument(RequestConstructorArgument, request);
                                  var factoryArgument = new ConstructorArgument(ActionResultFactoryConstructorArgument,
                                                                                ctx.Kernel.Get<IActionResultFactory>());

                                  var instance = (Controller)ctx.Kernel.Get(type, requestArgument, factoryArgument);

                                  return instance;
                              });
        }
    }
}
