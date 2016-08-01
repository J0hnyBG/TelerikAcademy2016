using FastAndFurious.ConsoleApplication.Common.Enums;

namespace FastAndFurious.ConsoleApplication.Contracts
{
    public interface IEngineControlUnit : ITunningPart
    {
        EngineControlUnitType EngineControlUnitType { get; }
    }
}
