using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Tunnings.Turbochargers.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Turbochargers
{
    public class ZX8ParallelTwinTurbocharger : Turbocharger
    {
        private const decimal ZX8UnitPriceInUSADollars = 799;
        private const int ZX8WeightInGrams = 3500;
        private const int ZX8AccelerationBonus = 15;
        private const int ZX8TopSpeedBonus = 60;

        public ZX8ParallelTwinTurbocharger()
            : base(
                  ZX8UnitPriceInUSADollars,
                  ZX8WeightInGrams,
                  ZX8AccelerationBonus,
                  ZX8TopSpeedBonus,
                  TunningGradeType.HighGrade,
                  TurbochargerType.TwinTurbo)
        {
        }
    }
}
