using System;
using System.IO;
using System.Linq;
using System.Reflection;

using Ninject;
using Ninject.Activation;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using Ninject.Parameters;

using WebFormsMvp;
using WebFormsMvp.Binder;

using _01_Cars.App_Start.Factories;
using _01_Cars.CustomEventArgs.Factories;
using _01_Cars.Models.Factories;
using _01_Cars.Services;
using _01_Cars.Services.Contracts;

namespace _01_Cars.App_Start.NinjectModules
{
    public class CarsNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind(x =>
                             {
                                 var assemblyLocation = Assembly.GetExecutingAssembly().Location;
                                 var directoryPath = Path.GetDirectoryName(assemblyLocation);
                                 x.FromAssembliesInPath(directoryPath)
                                  .SelectAllClasses()
                                  .BindDefaultInterface();
                             });

            this.Rebind<ICarService>().To<CarService>().InSingletonScope();

            this.Bind<ICarModelFactory>().ToFactory().InSingletonScope();

            this.Bind<IProducerFactory>().ToFactory().InSingletonScope();

            this.Bind<IPresenterFactory>().To<MvpPresenterFactory>().InSingletonScope();

            this.Bind<IMvpPresenterFactory>().ToFactory().InSingletonScope();

            this.Bind<ICustomEventArgsFactory>().ToFactory().InSingletonScope();

            this.Bind<IPresenter>()
                .ToMethod(GetPresenter)
                .NamedLikeFactoryMethod(
                                        (IMvpPresenterFactory factory) => factory.GetPresenter(null, null)
                );
        }

        private static IPresenter GetPresenter(IContext context)
        {
            var parameters = context.Parameters.ToList();

            var presenterType = (Type)parameters[0].GetValue(context, null);
            var viewInstance = (IView)parameters[1].GetValue(context, null);

            var ctorParamter = new ConstructorArgument("view", viewInstance);

            return (IPresenter)context.Kernel.Get(presenterType, ctorParamter);
        }
    }
}
