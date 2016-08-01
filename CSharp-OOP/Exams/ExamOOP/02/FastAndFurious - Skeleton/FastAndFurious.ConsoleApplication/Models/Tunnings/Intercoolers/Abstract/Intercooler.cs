using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Models.Tunnings.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Intercoolers.Abstract
{
    public class Intercooler : TunningPart, IIntercooler
    {

        public Intercooler
            (
            decimal price, 
            int weight, 
            int acceleration, 
            int topSpeed, 
            TunningGradeType gradeType,
            IntercoolerType intercoolerType
            ) 
            : base
            (
                  price, 
                  weight, 
                  acceleration, 
                  topSpeed, 
                  gradeType
            )
        {
            this.IntercoolerType = intercoolerType;
        }
        public IntercoolerType IntercoolerType { get; private set; }

    }
}
