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
            var acceleration = this.Acceleration;
            var topSpeed = this.TopSpeed;

            foreach (var tunningPart in this.TunningParts)
            {
                acceleration += tunningPart.Acceleration;
                topSpeed += tunningPart.TopSpeed;
            }
            var topSpeedInMetersPS = MetricUnitsConverter.GetMetersPerSecondFrom(topSpeed);

            var decAcceleration = (double)acceleration;
            var decTopSpeedInMPS = (double)topSpeedInMetersPS;

            var timeToMaxSpeed = decTopSpeedInMPS / decAcceleration;
            var distanceTravelledToTopSpeed = (decAcceleration * timeToMaxSpeed * timeToMaxSpeed)/2;
      
            var distanceRemaining = trackLengthInMeters - distanceTravelledToTopSpeed;

            if (distanceRemaining < 0)
            {
                //timeToMaxSpeed += distanceRemaining*acceleration;
                //todo: decrement time
                return TimeSpan.FromSeconds((double) timeToMaxSpeed);
            }

            timeToMaxSpeed += distanceRemaining/topSpeedInMetersPS;

            return TimeSpan.FromSeconds((double) timeToMaxSpeed);
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
