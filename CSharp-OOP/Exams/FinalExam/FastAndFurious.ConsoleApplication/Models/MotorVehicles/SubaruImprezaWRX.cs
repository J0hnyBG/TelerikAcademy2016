using FastAndFurious.ConsoleApplication.Models.MotorVehicles.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.MotorVehicles
{
    public class SubaruImprezaWRX : MotorVehicle
    {
        private const decimal SubaruImprezaWRXPriceInUSD = 55999;
        private const int SubaruImprezaWRXWeightInGrams = 1560000;
        private const int SubaruImprezaWRXTopSpeed = 260;
        private const int SubaruImprezaWRXAcceleration = 35;

        public SubaruImprezaWRX()
            : base(SubaruImprezaWRXPriceInUSD, SubaruImprezaWRXWeightInGrams, SubaruImprezaWRXAcceleration, SubaruImprezaWRXTopSpeed)
        {
        }
    }
}
