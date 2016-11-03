using Dealership.Engine.CommandHandlers.Abstract;
using Dealership.Engine.Contracts;

namespace Dealership.Engine.CommandHandlers
{
    public class LogoutCommandHandler : CommandHandler
    {
        private const string UserLoggedOut = "You logged out!";

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == "Logout";
        }

        protected override string Handle(ICommand command, IDealershipEngine engine)
        {
            engine.LoginUser(null);
            return UserLoggedOut;
        }
    }
}
