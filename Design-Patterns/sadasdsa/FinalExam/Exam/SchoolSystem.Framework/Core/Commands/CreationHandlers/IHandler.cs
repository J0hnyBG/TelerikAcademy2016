using SchoolSystem.Framework.Core.Commands.Contracts;

namespace SchoolSystem.Framework.Core.Commands.CreationHandlers
{
    public interface IHandler
    {
        IHandler Next { get; set; }

        ICommand HandleCreation(string commandName);
    }
}
