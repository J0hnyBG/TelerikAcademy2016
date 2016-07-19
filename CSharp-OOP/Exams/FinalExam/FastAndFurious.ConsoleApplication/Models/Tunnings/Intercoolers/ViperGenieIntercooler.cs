using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Tunnings.Intercoolers.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Intercoolers
{
    public class ViperGenieIntercooler : Intercooler
    {
        private const decimal ViperGenieUnitPriceInUSADollars = 289;
        private const int ViperGenieWeightInGrams = 5300;
        private const int ViperGenieAccelerationBonus = 0;
        private const int ViperGenieTopSpeedBonus = 25;

        public ViperGenieIntercooler()
            : base(ViperGenieUnitPriceInUSADollars,
                  ViperGenieWeightInGrams,
                  ViperGenieAccelerationBonus,
                  ViperGenieTopSpeedBonus,
                  TunningGradeType.MidGrade,
                  IntercoolerType.ChargeAirIntercooler
                  )
        {
        }
    }
}
