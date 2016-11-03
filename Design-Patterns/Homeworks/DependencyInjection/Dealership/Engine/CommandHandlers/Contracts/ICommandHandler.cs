using Dealership.Engine.Contracts;

namespace Dealership.Engine.CommandHandlers.Contracts
{
    public interface ICommandHandler
    {
        string HandleCommand(ICommand command, IDealershipEngine engine);

        void SetNext(ICommandHandler nextHandler);
    }
}
