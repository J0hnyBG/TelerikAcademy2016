using FastAndFurious.ConsoleApplication.Common.Enums;

namespace FastAndFurious.ConsoleApplication.Contracts
{
    public interface ITurbocharger : ITunningPart
    {
        TurbochargerType TurbochargerType { get; }
    }
}
