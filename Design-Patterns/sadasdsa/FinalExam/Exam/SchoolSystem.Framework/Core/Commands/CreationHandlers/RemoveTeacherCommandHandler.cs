using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;

namespace SchoolSystem.Framework.Core.Commands.CreationHandlers
{
    public class RemoveTeacherCommandHandler : CommandCreationHandler
    {
        public RemoveTeacherCommandHandler(ICommandFactory commandFactory)
            : base(commandFactory)
        {
        }

        protected override bool CanHandle(string commandName)
        {
            return commandName == "RemoveTeacher";
        }

        protected override ICommand Handle()
        {
            return this.CommandFactory.GetRemoveTeacherCommand();
        }
    }
}
