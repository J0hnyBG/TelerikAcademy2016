using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Tunnings.Intercoolers.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Intercoolers
{
    public class EvolutionXPerformanceIntercooler : Intercooler
    {
        private const decimal EvolutionXUnitPriceInUSADollars = 499;
        private const int EvolutionXWeightInGrams = 4500;
        private const int EvolutionXAccelerationBonus = -5;
        private const int EvolutionXTopSpeedBonus = 40;

        public EvolutionXPerformanceIntercooler() 
            : base(EvolutionXUnitPriceInUSADollars,
                  EvolutionXWeightInGrams,
                  EvolutionXAccelerationBonus,
                  EvolutionXTopSpeedBonus,
                  TunningGradeType.HighGrade, 
                  IntercoolerType.AirToLiquidIntercooler
                  )
        {
        }
    }
}
