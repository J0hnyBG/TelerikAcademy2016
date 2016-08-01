using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Tunnings.Transmissions.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Transmissions
{
    public class BMShortShifter : Transmission
    {
        private const decimal BMShortUnitPriceInUSADollars = 2799;
        private const int BMShortWeightInGrams = 5700;
        private const int BMShortAccelerationBonus = 28;
        private const int BMShortTopSpeedBonus = 0;

        public BMShortShifter()
            : base(BMShortUnitPriceInUSADollars,
                  BMShortWeightInGrams,
                  BMShortAccelerationBonus,
                  BMShortTopSpeedBonus, 
                  TunningGradeType.HighGrade, TransmissionType.ManualShortShifter)
        {
        }
    }
}
