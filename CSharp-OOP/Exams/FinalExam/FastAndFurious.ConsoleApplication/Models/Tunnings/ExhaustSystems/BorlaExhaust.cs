using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Tunnings.ExhaustSystems.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.ExhaustSystems
{
    public class BorlaExhaust : Exhaust
    {
        private const decimal BorlaExhaustUnitPriceInUSADollars = 1299;
        private const int BorlaExhaustWeightInGrams = 14600;
        private const int BorlaExhaustAccelerationBonus = 12;
        private const int BorlaExhaustTopSpeedBonus = 40;

        public BorlaExhaust()
            : base(BorlaExhaustUnitPriceInUSADollars, 
                  BorlaExhaustWeightInGrams, 
                  BorlaExhaustAccelerationBonus, 
                  BorlaExhaustTopSpeedBonus, 
                  TunningGradeType.HighGrade, 
                  ExhaustType.CeramicCoated)
        {
        }

    }
}
