using System;
using System.Linq;

using Dealership.Engine.CommandHandlers.Abstract;
using Dealership.Engine.Contracts;

namespace Dealership.Engine.CommandHandlers
{
    public class LoginCommandHandler : CommandHandler
    {
        private const string UserLoggedInAlready = "User {0} is logged in! Please log out first!";
        private const string WrongUsernameOrPassword = "Wrong username or password!";
        private const string UserLoggedIn = "User {0} successfully logged in!";

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == "Login";
        }

        protected override string Handle(ICommand command, IDealershipEngine engine)
        {
            var username = command.Parameters[0];
            var password = command.Parameters[1];

            if (engine.LoggedUser != null)
            {
                return string.Format(UserLoggedInAlready, engine.LoggedUser.Username);
            }

            var userFound =
                engine.Users.FirstOrDefault(
                                            u =>
                                                string.Equals(u.Username, username,
                                                              StringComparison.CurrentCultureIgnoreCase));

            if (userFound == null || userFound.Password != password)
            {
                return WrongUsernameOrPassword;
            }

            engine.LoginUser(userFound);

            return string.Format(UserLoggedIn, username);
        }
    }
}
