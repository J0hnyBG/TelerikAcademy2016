namespace Dealership.Models
{
    using Dealership.Common;
    using Dealership.Common.Enums;

    using Dealership.Contracts;

    public class Car : Vehicle, ICar
    {
        private const int CarWheels = (int)VehicleType.Car;

        private int _seats;
        public Car(string make, string model, decimal price, int seats) 
            : base(make, model, price, VehicleType.Car, Car.CarWheels)
        {
            this.Seats = seats;
        }

        public int Seats
        {
            get { return this._seats; }
            private set
            {
                Validator.ValidateIntRange(value, Constants.MinSeats, Constants.MaxSeats,
                    string.Format(Constants.NumberMustBeBetweenMinAndMax, "Seats", Constants.MinSeats, Constants.MaxSeats));
                this._seats = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("\n  Seats: {0}", this.Seats) + base.GetComments();
        }
    }
}
