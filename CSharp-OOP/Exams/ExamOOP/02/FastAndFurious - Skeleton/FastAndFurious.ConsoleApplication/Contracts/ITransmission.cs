using FastAndFurious.ConsoleApplication.Common.Enums;

namespace FastAndFurious.ConsoleApplication.Contracts
{
    public interface ITransmission : ITunningPart
    {
        TransmissionType TransmissionType { get; }
    }
}
