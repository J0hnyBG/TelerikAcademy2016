using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Drivers.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Drivers
{
    public class Mia : Driver
    {
        private const GenderType MiaGender = GenderType.Female;
        private const string MiaName = "Mia";
        public Mia()
            : base(MiaName, MiaGender)
        {
        }
    }
}
