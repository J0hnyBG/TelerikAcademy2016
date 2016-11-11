using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;

namespace SchoolSystem.Framework.Core.Commands.CreationHandlers
{
    public class StudentListMarksHandler : CommandCreationHandler
    {
        public StudentListMarksHandler(ICommandFactory commandFactory)
            : base(commandFactory)
        {
        }

        protected override bool CanHandle(string commandName)
        {
            return commandName == "StudentListMarks";
        }

        protected override ICommand Handle()
        {
            return this.CommandFactory.GetStudentListMarksCommand();
        }
    }
}
