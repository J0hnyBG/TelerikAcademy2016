using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Tunnings.ExhaustSystems.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.ExhaustSystems
{
    public class RemusExhaust : Exhaust
    {
        private const decimal RemusExhaustUnitPriceInUSADollars = 679;
        private const int RemusExhaustWeightInGrams = 11500;
        private const int RemusExhaustAccelerationBonus = 8;
        private const int RemusExhaustTopSpeedBonus = 25;

        public RemusExhaust()
            : base(RemusExhaustUnitPriceInUSADollars, 
                  RemusExhaustWeightInGrams, 
                  RemusExhaustAccelerationBonus, 
                  RemusExhaustTopSpeedBonus, 
                  TunningGradeType.MidGrade, 
                  ExhaustType.StainlessSteel)
        {
        }

    }
}
