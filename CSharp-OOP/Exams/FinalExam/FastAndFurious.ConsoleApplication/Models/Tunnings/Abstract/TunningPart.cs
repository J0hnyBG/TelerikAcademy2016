using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Models.Common;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Abstract
{
    public abstract class TunningPart : CarObject, ITunningPart
    {
        protected TunningPart(decimal price, int weight, int acceleration, int topSpeed, TunningGradeType gradeType) :
            base(price, weight, acceleration, topSpeed)
        {
            this.GradeType = gradeType;
        }

        public TunningGradeType GradeType { get; private set; }
    }
}
