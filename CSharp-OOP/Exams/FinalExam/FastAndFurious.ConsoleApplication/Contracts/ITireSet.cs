using FastAndFurious.ConsoleApplication.Common.Enums;

namespace FastAndFurious.ConsoleApplication.Contracts
{
    public interface ITireSet : ITunningPart
    {
        TireType TireType { get; }
    }
}
