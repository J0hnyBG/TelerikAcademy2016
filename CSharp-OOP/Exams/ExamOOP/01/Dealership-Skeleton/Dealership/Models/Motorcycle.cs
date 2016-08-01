namespace Dealership.Models
{
    using Dealership.Common;
    using Dealership.Common.Enums;
    using Dealership.Contracts;

    public class Motorcycle : Vehicle, IMotorcycle
    {
        private const int MotorycleWheels = (int)VehicleType.Motorcycle;
        private string _category;

        public Motorcycle(string make, string model, decimal price, string category) 
            : base(make, model, price, VehicleType.Motorcycle, Motorcycle.MotorycleWheels)
        {
            this.Category = category;
        }

        public string Category
        {
            get { return this._category; }
            private set
            {
                Validator.ValidateIntRange(value.Length, Constants.MinCategoryLength, Constants.MaxCategoryLength,
                    string.Format(Constants.StringMustBeBetweenMinAndMax, "Category", Constants.MinCategoryLength, Constants.MaxCategoryLength));
                this._category = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("\n  Category: {0}", this.Category) + this.GetCommentsString();
        }
    }
}
