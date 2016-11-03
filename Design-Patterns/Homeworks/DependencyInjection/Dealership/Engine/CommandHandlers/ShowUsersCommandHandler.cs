using System.Text;

using Dealership.Common.Enums;
using Dealership.Engine.CommandHandlers.Abstract;
using Dealership.Engine.Contracts;

namespace Dealership.Engine.CommandHandlers
{
    public class ShowUsersCommandHandler : CommandHandler
    {
        private const string YouAreNotAnAdmin = "You are not an admin!";

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == "ShowUsers";
        }

        protected override string Handle(ICommand command, IDealershipEngine engine)
        {
            if (engine.LoggedUser.Role != Role.Admin)
            {
                return YouAreNotAnAdmin;
            }

            var builder = new StringBuilder();
            builder.AppendLine("--USERS--");
            var counter = 1;
            foreach (var user in engine.Users)
            {
                builder.AppendLine(string.Format("{0}. {1}", counter, user.ToString()));
                counter++;
            }

            return builder.ToString().Trim();
        }
    }
}
