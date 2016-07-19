using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Tunnings.Transmissions.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Transmissions
{
    public class HurstCompetitionManualShifter : Transmission
    {
        private const decimal HurstCompetitionUnitPriceInUSADollars = 1999;
        private const int HurstCompetitionWeightInGrams = 6000;
        private const int HurstCompetitionAccelerationBonus = 20;
        private const int HurstCompetitionTopSpeedBonus = 0;

        public HurstCompetitionManualShifter()
            : base(HurstCompetitionUnitPriceInUSADollars,
                  HurstCompetitionWeightInGrams,
                  HurstCompetitionAccelerationBonus,
                  HurstCompetitionTopSpeedBonus,
                  TunningGradeType.MidGrade, 
                  TransmissionType.StockShifter)
        {
        }
    }
}
