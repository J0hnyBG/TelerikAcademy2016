using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Drivers.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Drivers
{
    public class Jessi : Driver
    {
        private const GenderType JessiGender = GenderType.Female;
        private const string JessiName = "Jessi";
        public Jessi()
            : base(JessiName, JessiGender)
        {
        }
    }
}
