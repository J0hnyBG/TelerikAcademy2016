namespace Dealership.Models
{
    using System.Collections.Generic;

    using Dealership.Common;
    using Dealership.Common.Enums;
    using Dealership.Contracts;

    public class Vehicle : IVehicle
    {
        private decimal _price;
        private string _make;
        private string _model;
        protected int _wheels;

        protected Vehicle(string make, string model, decimal price, VehicleType type, int wheels)
        {
            this.Comments = new List<IComment>();
            this.Price = price;
            this.Type = type;
            this.Make = make;
            this.Model = model;
            this.Wheels = wheels;
        }

        public IList<IComment> Comments { get; private set; }

        public decimal Price
        {
            get { return this._price; }
            private set
            {
                Validator.ValidateDecimalRange(value, Constants.MinPrice, Constants.MaxPrice, 
                    string.Format(Constants.NumberMustBeBetweenMinAndMax, "Price", Constants.MinPrice, Constants.MaxPrice));
                this._price = value;
            }
        }

        public int Wheels
        {
            get { return this._wheels; }
            protected set
            {
                Validator.ValidateIntRange(value, Constants.MinWheels, Constants.MaxWheels,
                    string.Format(Constants.NumberMustBeBetweenMinAndMax, "Wheels", Constants.MinWheels, Constants.MaxWheels));
                this._wheels = value;
            }
        }

        public VehicleType Type { get; private set; }

        public string Make
        {
            get { return this._make; }
            private set
            {
                Validator.ValidateIntRange(value.Length, Constants.MinMakeLength, Constants.MaxMakeLength, 
                    string.Format(Constants.StringMustBeBetweenMinAndMax, "Make", Constants.MinMakeLength, Constants.MaxMakeLength));
                this._make = value;
            }
        }

        public string Model
        {
            get { return this._model; }
            private set
            {
                Validator.ValidateIntRange(value.Length, Constants.MinModelLength, Constants.MaxModelLength,
                    string.Format(Constants.StringMustBeBetweenMinAndMax, "Model", Constants.MinModelLength, Constants.MaxModelLength));
                this._model = value;
            }
        }

        public override string ToString()
        {
            return string.Format("\n  Make: {0}\n  Model: {1}\n  Wheels: {2}\n  Price: ${3}",
                this.Make, this.Model, this.Wheels, this.Price);
        }

        protected string GetComments()
        {
            if (this.Comments.Count == 0)
            {
                return "\n    --NO COMMENTS--";
            }
            else
            {
                var output = "\n    --COMMENTS--";
                foreach (var comment in this.Comments)
                {
                    output = output + comment.ToString();
                }
                output = output + "\n    --COMMENTS--";
                return output;
            }
            
        }
    }
}
