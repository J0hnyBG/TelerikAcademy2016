using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;

namespace SchoolSystem.Framework.Core.Commands.CreationHandlers
{
    public class RemoveStudentCommandHandler
        : CommandCreationHandler
    {
        public RemoveStudentCommandHandler(ICommandFactory commandFactory)
            : base(commandFactory)
        {
        }

        protected override bool CanHandle(string commandName)
        {
            return commandName == "RemoveStudent";
        }

        protected override ICommand Handle()
        {
            return this.CommandFactory.GetRemoveStudentCommand();
        }
    }
}
