using System;
using System.Net;

using ConsoleWebServer.Framework.Exceptions;
using ConsoleWebServer.Framework.HttpMessages.Contracts;

namespace ConsoleWebServer.Framework.Handlers
{
    public class ControllerHandler : BaseHandler
    {
        private readonly IActionInvoker _actionInvoker;
        private readonly Func<IHttpRequest, Controller> _controllerFactory;

        public ControllerHandler(IHttpResponseFactory responseFactory,
                                 IActionInvoker actionInvoker,
                                 Func<IHttpRequest, Controller> controllerFactory)
            : base(responseFactory)
        {
            if (actionInvoker == null)
            {
                throw new ArgumentNullException(nameof(actionInvoker));
            }

            if (controllerFactory == null)
            {
                throw new ArgumentNullException(nameof(controllerFactory));
            }

            this._controllerFactory = controllerFactory;
            this._actionInvoker = actionInvoker;
        }

        protected override bool CanHandle(IHttpRequest request)
        {
            return request.ProtocolVersion.Major < 3;
        }

        protected override IHttpResponse Handle(IHttpRequest request)
        {
            IHttpResponse response;
            try
            {
                var controller = this._controllerFactory(request);
                var actionResult = this._actionInvoker.InvokeAction(controller, request.Action);
                response = actionResult.GetResponse();
            }
            catch (HttpNotFoundException exception)
            {
                response = this.ResponseFactory.GetHttpResponse(request.ProtocolVersion.ToString(),
                                                                HttpStatusCode.NotFound,
                                                                exception.Message);
            }
            catch (Exception exception)
            {
                response = this.ResponseFactory.GetHttpResponse(request.ProtocolVersion.ToString(),
                                                                HttpStatusCode.InternalServerError,
                                                                exception.Message);
            }

            return response;
        }
    }
}
