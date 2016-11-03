using Dealership.Common;
using Dealership.Common.Contracts;
using Dealership.Common.Enums;
using Dealership.Contracts;

namespace Dealership.Models
{
    public class Truck : Vehicle, ITruck
    {
        private const string WeightCapacityPropery = "Weight capacity";

        private int _weightCapacity;

        public Truck(string make, string model, decimal price, int weightCapacity, IValidatorProvider validator)
            : base(make, model, price, VehicleType.Truck, validator)
        {
            this.WeightCapacity = weightCapacity;
        }

        public int WeightCapacity
        {
            get
            {
                return this._weightCapacity;
            }

            private set
            {
                this.Validator.ValidateIntRange(value, Constants.MinCapacity, Constants.MaxCapacity, string.Format(Constants.NumberMustBeBetweenMinAndMax, WeightCapacityPropery, Constants.MinCapacity, Constants.MaxCapacity));
                this._weightCapacity = value;
            }
        }

        protected override string PrintAdditionalInfo()
        {
            return string.Format("  Weight Capacity: {0}t", this.WeightCapacity);
        }
    }
}
