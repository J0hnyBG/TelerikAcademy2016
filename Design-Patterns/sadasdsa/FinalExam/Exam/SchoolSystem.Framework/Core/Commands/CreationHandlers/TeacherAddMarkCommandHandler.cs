using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;

namespace SchoolSystem.Framework.Core.Commands.CreationHandlers
{
    public class TeacherAddMarkCommandHandler : CommandCreationHandler
    {
        public TeacherAddMarkCommandHandler(ICommandFactory commandFactory)
            : base(commandFactory)
        {
        }

        protected override bool CanHandle(string commandName)
        {
            return commandName == "TeacherAddMark";
        }

        protected override ICommand Handle()
        {
            return this.CommandFactory.GetTeacherAddMarkCommand();
        }
    }
}
