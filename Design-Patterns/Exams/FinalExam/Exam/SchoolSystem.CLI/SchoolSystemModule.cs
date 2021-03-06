﻿using System.IO;
using System.Reflection;

using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Factory;
using Ninject.Extensions.Interception.Infrastructure.Language;
using Ninject.Modules;

using SchoolSystem.Cli.Configuration;
using SchoolSystem.Cli.InstanceProviders;
using SchoolSystem.Cli.Interceptors;
using SchoolSystem.Framework.Core;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Core.Providers;
using SchoolSystem.Framework.Core.Repositories;
using SchoolSystem.Framework.Core.Repositories.Contracts;

namespace SchoolSystem.Cli
{
    public class SchoolSystemModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind(x =>
                             {
                                 x.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                                  .SelectAllClasses()
                                  .BindDefaultInterface();
                             });

            this.Bind<IWriter>().To<ConsoleWriterProvider>();
            this.Bind<IReader>().To<ConsoleReaderProvider>();
            this.Bind<IParser>().To<CommandParserProvider>();

            this.Bind(typeof(IRepository<>)).To(typeof(KeyedRepository<>)).WhenInjectedInto<ISchoolSystemData>();

            this.Bind<ISchoolSystemEngine>().To<Engine>();

            this.Bind<IStudentFactory>().ToFactory().InSingletonScope();
            this.Bind<ITeacherFactory>().ToFactory().InSingletonScope();
            this.Bind<IMarkFactory>().ToFactory().InSingletonScope();

            this.Bind<ICommandFactory>()
                .ToFactory(() => new UseFirstArgumentAsNameInstanceProvider())
                .InSingletonScope();

            this.Bind<ICommand>()
                .To<CreateStudentCommand>()
                .InSingletonScope()
                .Named(typeof(CreateStudentCommand).Name);

            this.Bind<ICommand>()
                .To<CreateTeacherCommand>()
                .InSingletonScope()
                .Named(typeof(CreateTeacherCommand).Name);

            this.Bind<ICommand>()
                .To<RemoveStudentCommand>()
                .InSingletonScope()
                .Named(typeof(RemoveStudentCommand).Name);

            this.Bind<ICommand>()
                .To<RemoveTeacherCommand>()
                .InSingletonScope()
                .Named(typeof(RemoveTeacherCommand).Name);

            this.Bind<ICommand>()
                .To<StudentListMarksCommand>()
                .InSingletonScope()
                .Named(typeof(StudentListMarksCommand).Name);

            this.Bind<ICommand>()
                .To<TeacherAddMarkCommand>()
                .InSingletonScope()
                .Named(typeof(TeacherAddMarkCommand).Name);

            IConfigurationProvider configurationProvider = this.Kernel.Get<IConfigurationProvider>();
            if (configurationProvider.IsTestEnvironment)
            {
                this.Rebind<IStudentFactory>()
                    .ToFactory()
                    .InSingletonScope()
                    .Intercept()
                    .With<PerformanceLoggerInterceptor>();

                this.Rebind<IMarkFactory>()
                    .ToFactory()
                    .InSingletonScope()
                    .Intercept()
                    .With<PerformanceLoggerInterceptor>();

                this.Rebind<ICommandFactory>()
                    .ToFactory(() => new UseFirstArgumentAsNameInstanceProvider())
                    .InSingletonScope()
                    .Intercept()
                    .With<PerformanceLoggerInterceptor>();
            }
        }
    }
}
