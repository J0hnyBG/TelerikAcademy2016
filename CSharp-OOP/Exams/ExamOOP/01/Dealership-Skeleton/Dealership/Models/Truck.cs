namespace Dealership.Models
{
    using Dealership.Common;
    using Dealership.Common.Enums;
    using Dealership.Contracts;

    public class Truck : Vehicle, ITruck
    {
        private const int TruckWheels = (int)VehicleType.Truck;
        private int _weightCapacity;

        public Truck(string make, string model, decimal price, int weightCapacity)
            : base(make, model, price, VehicleType.Truck, Truck.TruckWheels)
        {
            this.WeightCapacity = weightCapacity;
        }

        public int WeightCapacity
        {
            get { return this._weightCapacity; }
            private set
            {
                Validator.ValidateIntRange(value, Constants.MinCapacity, Constants.MaxCapacity,
                    string.Format(Constants.NumberMustBeBetweenMinAndMax, "Weight capacity", Constants.MinCapacity, Constants.MaxCapacity));
                this._weightCapacity = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("\n  Weight Capacity: {0}t", this.WeightCapacity) + this.GetCommentsString();

        }
    }
}
