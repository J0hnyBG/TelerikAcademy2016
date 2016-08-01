using FastAndFurious.ConsoleApplication.Common.Enums;

namespace FastAndFurious.ConsoleApplication.Contracts
{
    public interface ITunningPart : IIdentifiable, IAccelerateable, ITopSpeed, IWeightable, IValuable
    {
        //int Id { get; }
        TunningGradeType GradeType { get; }
    }
}
