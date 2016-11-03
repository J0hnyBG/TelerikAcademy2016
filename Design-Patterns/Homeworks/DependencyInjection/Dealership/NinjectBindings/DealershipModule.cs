using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

using Dealership.Contracts;
using Dealership.Engine;
using Dealership.Engine.CommandHandlers.Abstract;
using Dealership.Engine.CommandHandlers.Contracts;
using Dealership.Engine.Contracts;
using Dealership.Factories;
using Dealership.Models;

using Ninject.Extensions.Conventions;
using Ninject.Extensions.Factory;
using Ninject.Modules;

namespace Dealership.NinjectBindings
{
    public class DealershipModule : NinjectModule
    {
        /// <summary>Loads the module into the kernel.</summary>
        public override void Load()
        {
            this.Kernel.Bind(x =>
                             {
                                 x.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                                  .SelectAllClasses()
                                  .BindDefaultInterface();
                             });

            this.Bind<IDealershipFactory>().ToFactory();

            this.Bind<ICommandHandler>()
                .ToMethod(ctx =>
                          {
                              var assembly = this.GetType()
                                                 .GetTypeInfo()
                                                 .Assembly;
                              IList<Type> typeInfos = assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(CommandHandler))).ToList();

                              var commandHandlers = new List<ICommandHandler>();
                              for (var i = 0; i < typeInfos.Count; i++)
                              {
                                  var handler = Activator.CreateInstance(typeInfos[i]) as ICommandHandler;
                                  commandHandlers.Add(handler);
                                  if (i != 0)
                                  {
                                      commandHandlers[i-1].SetNext(handler);
                                  }
                              }

                              return commandHandlers.FirstOrDefault();
                          });

            this.Bind<IVehicle>().To<Car>().Named(typeof(Car).Name);
            this.Bind<IComment>().To<Comment>().Named(typeof(Comment).Name);
            this.Bind<ICommand>().To<Command>().Named(typeof(Command).Name);
            this.Bind<IUser>().To<User>().Named(typeof(User).Name);
            this.Bind<IVehicle>().To<Truck>().Named(typeof(Truck).Name);
            this.Bind<IVehicle>().To<Motorcycle>().Named(typeof(Motorcycle).Name);
        }
    }
}
