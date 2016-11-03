using Dealership.Common;
using Dealership.Common.Contracts;
using Dealership.Common.Enums;
using Dealership.Contracts;

namespace Dealership.Models
{
    public class Motorcycle : Vehicle, IMotorcycle
    {
        private const string CategoryProperty = "Category";

        private string _category;

        public Motorcycle(string make, string model, decimal price, string category, IValidatorProvider validator)
            : base(make, model, price, VehicleType.Motorcycle, validator)
        {
            this.Category = category;
        }

        public string Category
        {
            get
            {
                return this._category; 
            }

            private set
            {
                this.Validator.ValidateNull(value, string.Format(Constants.PropertyCannotBeNull, CategoryProperty));
                this.Validator.ValidateIntRange(value.Length, Constants.MinCategoryLength, Constants.MaxCategoryLength,
                                                string.Format(Constants.StringMustBeBetweenMinAndMax, CategoryProperty,
                                                              Constants.MinCategoryLength, Constants.MaxCategoryLength));

                this._category = value;
            }
        }

        protected override string PrintAdditionalInfo()
        {
            return string.Format("  {0}: {1}", CategoryProperty, this.Category);
        }
    }
}
