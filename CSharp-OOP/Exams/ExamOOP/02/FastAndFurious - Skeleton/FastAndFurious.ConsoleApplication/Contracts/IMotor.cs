using FastAndFurious.ConsoleApplication.Common.Enums;

namespace FastAndFurious.ConsoleApplication.Contracts
{
    public interface IMotor : ITunningPart
    {
        int Horsepower { get; }
        MotorType EngineType { get; }
        CylinderType CylinderType { get; }
    }
}
