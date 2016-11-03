using Dealership.Common.Enums;
using Dealership.Contracts;
using Dealership.Engine.Contracts;

namespace Dealership.Factories
{
    public interface IDealershipFactory
    {
        IUser GetUser(string username, string firstName, string lastName, string password, Role role);

        IComment GetComment(string content);

        IVehicle GetCar(string make, string model, decimal price, int seats);

        IVehicle GetMotorcycle(string make, string model, decimal price, string category);

        IVehicle GetTruck(string make, string model, decimal price, int weightCapacity);

        ICommand GetCommand(string input);
    }
}
