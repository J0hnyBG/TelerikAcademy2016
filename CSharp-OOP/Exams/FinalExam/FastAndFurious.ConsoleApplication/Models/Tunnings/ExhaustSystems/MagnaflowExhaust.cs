using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Tunnings.ExhaustSystems.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.ExhaustSystems
{
    public class MagnaflowExhaust : Exhaust
    {
        private const decimal MagnaflowExhaustUnitPriceInUSADollars = 379;
        private const int MagnaflowExhaustWeightInGrams = 12800;
        private const int MagnaflowExhaustAccelerationBonus = 5;
        private const int MagnaflowExhaustTopSpeedBonus = 25;

        public MagnaflowExhaust()
            : base(MagnaflowExhaustUnitPriceInUSADollars,
                  MagnaflowExhaustWeightInGrams,
                  MagnaflowExhaustAccelerationBonus,
                  MagnaflowExhaustTopSpeedBonus,
                  TunningGradeType.LowGrade,
                  ExhaustType.NickelChromePlated)
        {
        }

    }
}
