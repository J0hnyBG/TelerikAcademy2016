using Dealership.Common;
using Dealership.Common.Contracts;
using Dealership.Common.Enums;
using Dealership.Contracts;

namespace Dealership.Models
{
    public class Car : Vehicle, ICar
    {
        private const string SeatsProperty = "Seats";

        private int _seats;

        public Car(string make, string model, decimal price, int seats, IValidatorProvider validator)
            : base(make, model, price, VehicleType.Car, validator)
        {
            this.Seats = seats;
        }

        public int Seats
        {
            get
            {
                return this._seats;
            }

            private set
            {
                this.Validator.ValidateIntRange(value, Constants.MinSeats, Constants.MaxSeats,
                                                string.Format(Constants.NumberMustBeBetweenMinAndMax, SeatsProperty,
                                                              Constants.MinSeats, Constants.MaxSeats));

                this._seats = value;
            }
        }

        protected override string PrintAdditionalInfo()
        {
            return string.Format("  {0}: {1}", SeatsProperty, this.Seats);
        }
    }
}
