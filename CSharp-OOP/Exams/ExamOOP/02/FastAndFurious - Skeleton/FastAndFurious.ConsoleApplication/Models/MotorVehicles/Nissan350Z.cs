using FastAndFurious.ConsoleApplication.Models.MotorVehicles.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.MotorVehicles
{
    public class Nissan350Z : MotorVehicle
    {
        private const decimal Nissan350ZPriceInUSD = 25999;
        private const int Nissan350ZWeightInGrams = 1280000;
        private const int Nissan350ZTopSpeed = 220;
        private const int Nissan350ZAcceleration = 55;

        public Nissan350Z()
            : base(Nissan350ZPriceInUSD, Nissan350ZWeightInGrams, Nissan350ZAcceleration, Nissan350ZTopSpeed)
        {
        }
    }
}
