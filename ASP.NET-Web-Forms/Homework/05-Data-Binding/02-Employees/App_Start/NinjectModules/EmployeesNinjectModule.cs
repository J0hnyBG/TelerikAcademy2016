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

using _02_Employees.Data.Repositories.Factories;

namespace _01_Cars.App_Start.NinjectModules
{
    public class EmployeesNinjectModule : NinjectModule
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


            this.Bind<IPresenterFactory>().To<MvpPresenterFactory>().InSingletonScope();

            this.Bind<IMvpPresenterFactory>().ToFactory().InSingletonScope();

            this.Bind<IPresenter>()
                .ToMethod(GetPresenter)
                .NamedLikeFactoryMethod(
                                        (IMvpPresenterFactory factory) => factory.GetPresenter(null, null)
                );

            this.Bind<IRepositoryFactory>().ToFactory().InSingletonScope();
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
