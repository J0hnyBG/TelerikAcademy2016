using System;

using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;

namespace SchoolSystem.Framework.Core.Commands.CreationHandlers
{
    public class CreateStudentCommandHandler : CommandCreationHandler
    {
        private readonly IIdProvider idProvider;
        private readonly IStudentFactory factory;

        public CreateStudentCommandHandler(ICommandFactory commandFactory,
                                           IIdProvider idProvider,
                                           IStudentFactory factory)
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
            return commandName == "CreateStudent";
        }

        protected override ICommand Handle()
        {
            return this.CommandFactory.GetCreateStudentCommand(this.idProvider, this.factory);
        }
    }
}
