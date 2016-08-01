using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using FastAndFurious.ConsoleApplication.Common;
using FastAndFurious.ConsoleApplication.Common.Constants;
using FastAndFurious.ConsoleApplication.Common.Exceptions;
using FastAndFurious.ConsoleApplication.Common.Utils;
using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Models.Common;

namespace FastAndFurious.ConsoleApplication.Models.MotorVehicles.Abstract
{
    public abstract class MotorVehicle : CarObject, IMotorVehicle
    {
        protected MotorVehicle(decimal price, int weight, int acceleration, int topSpeed)
            : base(price, weight, acceleration, topSpeed)
        {
            this.TunningParts = new List<ITunningPart>();
        }

        public override decimal Price
        {
            get
            {
                return base.Price + this.TunningParts.Sum(x => x.Price);
            }
        }

        public IEnumerable<ITunningPart> TunningParts { get; private set; }

        public void AddTunning(ITunningPart part)
        {
            var partType = part.GetType();

            foreach (var p in TunningParts)
            {
                if (p.GetType() == partType)
                {
                    throw new TunningDuplicationException(GlobalConstants.CannotAddMultiplePartsOfTheSameTypeToVehicleExceptionMessage);
                }
            }
            this.TunningParts = this.TunningParts.Concat(new List<ITunningPart> {part});
        }
        public TimeSpan Race(int trackLengthInMeters)
        {
            // Oohh boy, you shouldn't have missed the PHYSICS class in high school.
            TimeSpan output = new TimeSpan();
            TimeSpan second = new TimeSpan(0, 0, 1);
            var acceleration = this.Acceleration;
            var topSpeed = this.TopSpeed;
            var weight = this.Weight;
            foreach (var tunningPart in TunningParts)
            {
                acceleration += tunningPart.Acceleration;
                topSpeed += tunningPart.TopSpeed;
                weight += tunningPart.Weight;
            }
            var topSpeedInMetersPS = MetricUnitsConverter.GetMetersPerSecondFrom(topSpeed);
            var currentSpeed = 0;
            var distanceTravelled = 0;
            double secondsElapsed = topSpeed/acceleration;
            TimeSpan timeToTopSpeed =  TimeSpan.FromSeconds(secondsElapsed);


            return output;
        }
        public bool RemoveTunning(ITunningPart part)
        {
            if (this.TunningParts.Contains(part))
            {
                this.TunningParts = this.TunningParts.Except(new List<ITunningPart> { part });
                return true;
            }
            return false;
        }
    }
}
