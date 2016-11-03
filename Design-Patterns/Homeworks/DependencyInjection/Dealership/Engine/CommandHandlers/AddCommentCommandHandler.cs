using System;
using System.Linq;

using Dealership.Engine.CommandHandlers.Abstract;
using Dealership.Engine.Contracts;

namespace Dealership.Engine.CommandHandlers
{
    public class AddCommentCommandHandler : CommandHandler
    {
        private const string NoSuchUser = "There is no user with username {0}!";
        private const string VehicleDoesNotExist = "The vehicle does not exist!";
        private const string CommentAddedSuccessfully = "{0} added comment successfully!";

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == "AddComment";
        }

        protected override string Handle(ICommand command, IDealershipEngine engine)
        {
            var content = command.Parameters[0];
            var author = command.Parameters[1];
            var vehicleIndex = int.Parse(command.Parameters[2]) - 1;

            var comment = engine.Factory.GetComment(content);
            comment.Author = engine.LoggedUser.Username;
            var user = engine.Users.FirstOrDefault(u => u.Username == author);

            if (user == null)
            {
                return string.Format(NoSuchUser, author);
            }

            this.ValidateRange(vehicleIndex, 0, user.Vehicles.Count, VehicleDoesNotExist);

            var vehicle = user.Vehicles[vehicleIndex];
            engine.LoggedUser.AddComment(comment, vehicle);

            return string.Format(CommentAddedSuccessfully, engine.LoggedUser.Username);
        }

        private void ValidateRange(int? value, int min, int max, string message)
        {
            if (value < min || value >= max)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
