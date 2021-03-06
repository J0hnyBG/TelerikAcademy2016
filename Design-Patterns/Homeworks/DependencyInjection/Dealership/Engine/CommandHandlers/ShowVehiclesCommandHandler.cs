﻿using System.Linq;

using Dealership.Engine.CommandHandlers.Abstract;
using Dealership.Engine.Contracts;

namespace Dealership.Engine.CommandHandlers
{
    public class ShowVehiclesCommandHandler : CommandHandler
    {
        private const string NoSuchUser = "There is no user with username {0}!";

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == "ShowVehicles";
        }

        protected override string Handle(ICommand command, IDealershipEngine engine)
        {
            var username = command.Parameters[0];

            var user = engine.Users.FirstOrDefault(u => u.Username.ToLower() == username.ToLower());

            if (user == null)
            {
                return string.Format(NoSuchUser, username);
            }

            return user.PrintVehicles();
        }
    }
}
