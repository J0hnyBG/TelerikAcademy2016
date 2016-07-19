using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Tunnings.Turbochargers.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Turbochargers
{
    public class VortexR35SequentialTurbocharger : Turbocharger
    {
        private const decimal VortexR35UnitPriceInUSADollars = 699;
        private const int VortexR35WeightInGrams = 3900;
        private const int VortexR35AccelerationBonus = 10;
        private const int VortexR35TopSpeedBonus = 85;

        public VortexR35SequentialTurbocharger() 
            : base(
                  VortexR35UnitPriceInUSADollars, 
                  VortexR35WeightInGrams, 
                  VortexR35AccelerationBonus,
                  VortexR35TopSpeedBonus,
                  TunningGradeType.HighGrade, 
                  TurbochargerType.SequentialTurbo)
        {
        }
    }
}
