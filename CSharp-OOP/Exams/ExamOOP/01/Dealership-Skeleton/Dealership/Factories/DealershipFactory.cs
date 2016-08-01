using Dealership.Contracts;
using Dealership.Models;
using Dealership.Common.Enums;

namespace Dealership.Factories
{
    public class DealershipFactory : IDealershipFactory
    {
        public IVehicle CreateCar(string make, string model, decimal price, int seats)
        {
            return new Car(make, model, price, seats);
        }

        public IVehicle CreateMotorcycle(string make, string model, decimal price, string category)
        {
            return new Motorcycle(make, model, price, category);
        }

        public IVehicle CreateTruck(string make, string model, decimal price, int weightCapacity)
        {
            return new Truck(make, model, price, weightCapacity);
        }

        public IUser CreateUser(string username, string firstName, string lastName, string password, string role)
        {
            Role rol = TranslateUserType(role);

            return new User(username, firstName, lastName, password, rol);
        }

        public IComment CreateComment(string content)
        {
            return new Comment(content);
        }

        private static Role TranslateUserType(string type)
        {
            switch (type)
            {
                case "VIP":
                case "Vip":
                case "vip":
                    return Role.VIP;
                case "Admin":
                case "admin":
                    return Role.Admin;
                default:
                    return Role.Normal;
            }
        }
    }
}
