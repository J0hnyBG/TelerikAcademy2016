using FastAndFurious.ConsoleApplication.Common.Enums;

namespace FastAndFurious.ConsoleApplication.Contracts
{
    public interface IIntercooler : ITunningPart
    {
        IntercoolerType IntercoolerType { get; }
    }
}
