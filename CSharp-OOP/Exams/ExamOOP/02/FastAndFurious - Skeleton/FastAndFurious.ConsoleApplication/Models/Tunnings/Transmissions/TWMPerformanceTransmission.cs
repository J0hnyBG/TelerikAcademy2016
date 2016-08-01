using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Tunnings.Transmissions.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Transmissions
{
    public class TWMPerformanceTransmission : Transmission
    {
        private const decimal TWMPerformanceUnitPriceInUSADollars = 1599;
        private const int TWMPerformanceWeightInGrams = 4799;
        private const int TWMPerformanceAccelerationBonus = 15;
        private const int TWMPerformanceTopSpeedBonus = 0;

        public TWMPerformanceTransmission()
            : base(TWMPerformanceUnitPriceInUSADollars,
                  TWMPerformanceWeightInGrams,
                  TWMPerformanceAccelerationBonus,
                  TWMPerformanceTopSpeedBonus,
                  TunningGradeType.LowGrade,
                  TransmissionType.SemiManualShifter)
        {
        }
    }
}
