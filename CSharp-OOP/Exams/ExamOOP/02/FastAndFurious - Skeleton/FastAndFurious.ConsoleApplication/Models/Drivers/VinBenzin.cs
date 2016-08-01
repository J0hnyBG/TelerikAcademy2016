using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Drivers.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Drivers
{
    public class VinBenzin : Driver
    {
        private const GenderType VinBenzinGender = GenderType.Male;
        private const string VinBenzinName = "Vin Benzin";
        public VinBenzin()
            : base(VinBenzinName, VinBenzinGender)
        {
        }
    }
}
