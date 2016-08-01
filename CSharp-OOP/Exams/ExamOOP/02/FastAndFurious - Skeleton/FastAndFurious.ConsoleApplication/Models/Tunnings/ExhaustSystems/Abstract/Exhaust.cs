using System;
using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Models.Tunnings.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.ExhaustSystems.Abstract
{
    public abstract class Exhaust : TunningPart, IExhaust
    {
        protected Exhaust(
           decimal price,
           int weight,
           int acceleration,
           int topSpeed,
           TunningGradeType gradeType,
           ExhaustType exhaustType)
            :base(price, weight, acceleration, topSpeed, gradeType)
        {
            this.ExhaustType = exhaustType;
        }

        public ExhaustType ExhaustType { get; private set; }
    }
}
