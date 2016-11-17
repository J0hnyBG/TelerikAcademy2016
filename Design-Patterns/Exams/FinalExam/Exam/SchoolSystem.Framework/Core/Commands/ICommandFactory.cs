using SchoolSystem.Framework.Core.Commands.Contracts;

namespace SchoolSystem.Framework.Core.Commands
{
    public interface ICommandFactory
    {
        ICommand CreateCommand(string commandName);
    }
}
