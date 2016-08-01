using System;
using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Models.Tunnings.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Tires.Abstract
{
    public abstract class TiresSet : TunningPart, ITunningPart, ITireSet, IAccelerateable, ITopSpeed, IWeightable, IValuable 
    {
        protected TiresSet(decimal price, int weight, int acceleration, int topSpeed, TunningGradeType gradeType, TireType tyreType) 
            : base(price, weight, acceleration, topSpeed, gradeType)
        {
            this.TireType = tyreType;
        }

        public TireType TireType { get; private set; }
    }
}
