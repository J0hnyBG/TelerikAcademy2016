using FastAndFurious.ConsoleApplication.Models.MotorVehicles.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.MotorVehicles
{
    public class NissanSkylineR34 : MotorVehicle
    {
        private const decimal NissanSkylineR34PriceInUSD = 45999;
        private const int NissanSkylineR34WeightInGrams = 1850000;
        private const int NissanSkylineR34TopSpeed = 280;
        private const int NissanSkylineR34Acceleration = 50;

        public NissanSkylineR34()
            : base(NissanSkylineR34PriceInUSD, NissanSkylineR34WeightInGrams, NissanSkylineR34Acceleration, NissanSkylineR34TopSpeed)
        {
        }
    }
}
