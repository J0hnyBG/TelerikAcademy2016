using FastAndFurious.ConsoleApplication.Models.MotorVehicles.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.MotorVehicles
{
    public class MitsubishiLancerEvolution : MotorVehicle
    {
        private const decimal MitsubishiLancerEvolutionPriceInUSD = 56999;
        private const int MitsubishiLancerEvolutionWeightInGrams = 1780000;
        private const int MitsubishiLancerEvolutionTopSpeed = 300;
        private const int MitsubishiLancerEvolutionAcceleration = 20;

        public MitsubishiLancerEvolution()
            : base(MitsubishiLancerEvolutionPriceInUSD, MitsubishiLancerEvolutionWeightInGrams, MitsubishiLancerEvolutionAcceleration, MitsubishiLancerEvolutionTopSpeed)
        {
        }
    }
}
