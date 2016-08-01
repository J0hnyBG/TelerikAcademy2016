using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Tunnings.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Transmissions.Abstract
{
    public class Transmission : TunningPart
    {
        public Transmission(decimal price, int weight, int acceleration, int topSpeed, TunningGradeType gradeType, TransmissionType transmissionType) 
            : base(price, weight, acceleration, topSpeed, gradeType)
        {
            this.TransmissionType = transmissionType;
        }

        public TransmissionType TransmissionType { get; private set; }

    }
}
