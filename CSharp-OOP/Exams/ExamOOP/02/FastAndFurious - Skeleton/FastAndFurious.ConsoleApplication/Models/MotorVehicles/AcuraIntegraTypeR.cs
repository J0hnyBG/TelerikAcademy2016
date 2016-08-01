using FastAndFurious.ConsoleApplication.Models.MotorVehicles.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.MotorVehicles
{
    public class AcuraIntegraTypeR : MotorVehicle
    {
        private const decimal AcuraIntegraPriceInUSD = 24999;
        private const int AcuraIntegraWeightInGrams = 1700000;
        private const int AcuraIntegraTopSpeed = 200;
        private const int AcuraIntegraAcceleration = 15;

        public AcuraIntegraTypeR() 
            : base(AcuraIntegraPriceInUSD, AcuraIntegraWeightInGrams, AcuraIntegraAcceleration, AcuraIntegraTopSpeed)
        {
        }
    }
}
