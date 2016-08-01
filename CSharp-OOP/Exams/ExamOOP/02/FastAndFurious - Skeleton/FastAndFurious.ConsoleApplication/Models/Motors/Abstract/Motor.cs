using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Models.Tunnings.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Motors.Abstract
{
    public abstract class Motor : TunningPart, IMotor, IIdentifiable
    {
        protected Motor(
            decimal price,
            int weight,
            int acceleration,
            int topSpeed,
            int horsepower,
            TunningGradeType gradeType,
            CylinderType cylinderType,
            MotorType engineType)
            :base(price, weight, acceleration, topSpeed, gradeType)
        {
            this.Horsepower = horsepower;
            this.CylinderType = cylinderType;
            this.EngineType = engineType;
        }

        public int Horsepower { get; private set; }

        public MotorType EngineType { get; private set; }

        public CylinderType CylinderType { get; private set; }
    }
}
