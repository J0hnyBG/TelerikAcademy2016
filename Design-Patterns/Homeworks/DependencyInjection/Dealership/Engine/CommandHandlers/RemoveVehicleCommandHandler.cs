using System;

using Dealership.Engine.CommandHandlers.Abstract;
using Dealership.Engine.Contracts;

namespace Dealership.Engine.CommandHandlers
{
    internal class RemoveVehicleCommandHandler : CommandHandler
    {
        private const string VehicleRemovedSuccessfully = "{0} removed vehicle successfully!";

        private const string RemovedVehicleDoesNotExist = "Cannot remove comment! The vehicle does not exist!";

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == "RemoveVehicle";
        }

        protected override string Handle(ICommand command, IDealershipEngine engine)
        {
            var vehicleIndex = int.Parse(command.Parameters[0]) - 1;
            this.ValidateRange(vehicleIndex, 0, engine.LoggedUser.Vehicles.Count, RemovedVehicleDoesNotExist);

            var vehicle = engine.LoggedUser.Vehicles[vehicleIndex];
            engine.LoggedUser.RemoveVehicle(vehicle);

            return string.Format(VehicleRemovedSuccessfully, engine.LoggedUser.Username);
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
