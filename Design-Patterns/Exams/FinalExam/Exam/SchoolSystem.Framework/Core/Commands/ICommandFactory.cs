using SchoolSystem.Framework.Core.Commands.Contracts;

namespace SchoolSystem.Framework.Core.Commands
{
    public interface ICommandFactory
    {
        //ICommand GetCreateStudentCommand(IIdProvider idProvider, IStudentFactory studentFactory);

        //ICommand GetCreateTeacherCommand(IIdProvider idProvider, ITeacherFactory teacherFactory);

        //ICommand GetRemoveStudentCommand();

        //ICommand GetRemoveTeacherCommand();

        //ICommand GetStudentListMarksCommand();

        //ICommand GetTeacherAddMarkCommand();

        ICommand GetCommand(string commandName);
    }
}
