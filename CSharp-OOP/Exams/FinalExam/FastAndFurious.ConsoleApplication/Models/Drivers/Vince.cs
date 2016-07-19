using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Drivers.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Drivers
{
    public class Vince : Driver
    {
        private const GenderType VinceGender = GenderType.Male;
        private const string VinceName = "Vince";
        public Vince()
            : base(VinceName, VinceGender)
        {
        }
    }
}
