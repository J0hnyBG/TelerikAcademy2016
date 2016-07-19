using FastAndFurious.ConsoleApplication.Models.MotorVehicles.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.MotorVehicles
{
    public class MitsubishiEclipse : MotorVehicle
    {
        private const decimal MitsubishiEclipsePriceInUSD = 29999;
        private const int MitsubishiEclipseWeightInGrams = 1400000;
        private const int MitsubishiEclipseTopSpeed = 230;
        private const int MitsubishiEclipseAcceleration = 24;

        public MitsubishiEclipse()
            : base(MitsubishiEclipsePriceInUSD, MitsubishiEclipseWeightInGrams, MitsubishiEclipseAcceleration, MitsubishiEclipseTopSpeed)
        {
        }
    }
}
