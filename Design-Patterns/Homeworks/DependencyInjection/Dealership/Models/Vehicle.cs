using System.Collections.Generic;
using System.Text;

using Dealership.Common;
using Dealership.Common.Contracts;
using Dealership.Common.Enums;
using Dealership.Contracts;
using Dealership.Models.Abstract;

namespace Dealership.Models
{
    public abstract class Vehicle : Validatable, IVehicle, ICommentable
    {
        private const string MakeProperty = "Make";
        private const string ModelProperty = "Model";
        private const string PriceProperty = "Price";
        private const string WheelsProperty = "Wheels";
        private const string CommentsHeader = "    --COMMENTS--";
        private const string NoCommentsHeader = "    --NO COMMENTS--";

        private string _make;
        private string _model;
        private decimal _price;
        private int _wheels;

        protected Vehicle(string make, string model, decimal price, VehicleType type, IValidatorProvider validator)
            : base(validator)
        {
            this.Make = make;
            this.Model = model;
            this.Price = price;
            this.Type = type;
            this.Wheels = (int)type;
            this.Comments = new List<IComment>();
        }

        public VehicleType Type { get; protected set; }

        public int Wheels
        {
            get { return this._wheels; }

            private set
            {
                this.Validator.ValidateIntRange(value, Constants.MinWheels, Constants.MaxWheels,
                                                string.Format(Constants.NumberMustBeBetweenMinAndMax, WheelsProperty,
                                                              Constants.MinWheels, Constants.MaxWheels));
                this._wheels = value;
            }
        }

        public string Make
        {
            get { return this._make; }

            private set
            {
                this.Validator.ValidateNull(value, string.Format(Constants.PropertyCannotBeNull, MakeProperty));
                this.Validator.ValidateIntRange(value.Length, Constants.MinMakeLength, Constants.MaxMakeLength,
                                                string.Format(Constants.StringMustBeBetweenMinAndMax, MakeProperty,
                                                              Constants.MinMakeLength, Constants.MaxMakeLength));

                this._make = value;
            }
        }

        public string Model
        {
            get { return this._model; }

            private set
            {
                this.Validator.ValidateNull(value, string.Format(Constants.PropertyCannotBeNull, ModelProperty));
                this.Validator.ValidateIntRange(value.Length, Constants.MinModelLength, Constants.MaxModelLength,
                                                string.Format(Constants.StringMustBeBetweenMinAndMax, ModelProperty,
                                                              Constants.MinModelLength, Constants.MaxModelLength));

                this._model = value;
            }
        }

        public IList<IComment> Comments { get; }

        public decimal Price
        {
            get { return this._price; }

            private set
            {
                this.Validator.ValidateDecimalRange(value, Constants.MinPrice, Constants.MaxPrice,
                                                    string.Format(Constants.NumberMustBeBetweenMinAndMax, PriceProperty,
                                                                  Constants.MinPrice, Constants.MaxPrice));

                this._price = value;
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(string.Format("{0}:", this.GetType().Name));
            builder.AppendLine(string.Format("  {0}: {1}", MakeProperty, this.Make));
            builder.AppendLine(string.Format("  {0}: {1}", ModelProperty, this.Model));
            builder.AppendLine(string.Format("  {0}: {1}", WheelsProperty, this.Wheels));
            builder.AppendLine(string.Format("  {0}: ${1}", PriceProperty, this.Price));
            builder.AppendLine(this.PrintAdditionalInfo());
            builder.AppendLine(this.PrintComments());
            return builder.ToString().TrimEnd();
        }

        protected abstract string PrintAdditionalInfo();

        private string PrintComments()
        {
            var builder = new StringBuilder();

            if (this.Comments.Count <= 0)
            {
                builder.AppendLine(string.Format("{0}", NoCommentsHeader));
            }
            else
            {
                builder.AppendLine(string.Format("{0}", CommentsHeader));

                foreach (var comment in this.Comments)
                {
                    builder.AppendLine(comment.ToString());
                }

                builder.AppendLine(string.Format("{0}", CommentsHeader));
            }

            return builder.ToString().TrimEnd();
        }
    }
}
