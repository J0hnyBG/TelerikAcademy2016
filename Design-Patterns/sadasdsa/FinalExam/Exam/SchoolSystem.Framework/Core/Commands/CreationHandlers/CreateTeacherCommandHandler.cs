using System;

using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;

namespace SchoolSystem.Framework.Core.Commands.CreationHandlers
{
    public class CreateTeacherCommandHandler : CommandCreationHandler
    {
        private readonly IIdProvider idProvider;
        private readonly ITeacherFactory factory;

        public CreateTeacherCommandHandler(ICommandFactory commandFactory,
                                           IIdProvider idProvider,
                                           ITeacherFactory factory)
            : base(commandFactory)
        {
            if (idProvider == null)
            {
                throw new ArgumentNullException(nameof(idProvider));
            }
            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            this.factory = factory;
            this.idProvider = idProvider;
        }

        protected override bool CanHandle(string commandName)
        {
            return commandName == "CreateTeacher";
        }

        protected override ICommand Handle()
        {
            return this.CommandFactory.GetCreateTeacherCommand(this.idProvider, this.factory);
        }
    }
}
