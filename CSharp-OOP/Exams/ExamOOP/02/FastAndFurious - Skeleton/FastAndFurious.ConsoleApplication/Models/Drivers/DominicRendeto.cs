using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Drivers.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Drivers
{
    public class DominicRendeto : Driver
    {
        private const GenderType DominicGender = GenderType.Male;
        private const string DominicName = "Dominic Rendeto";
        public DominicRendeto() 
            : base(DominicName, DominicGender)
        {
        }
    }
}
