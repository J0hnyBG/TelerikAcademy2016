
namespace FurnitureManufacturer.Models
{
    using FurnitureManufacturer.Models.Common;
    using FurnitureManufacturer.Interfaces;

    public abstract class Furniture : IFurniture
    {
        private string model;
        private decimal price;
        private decimal height;

        protected Furniture(string model, MaterialType material, decimal price, decimal height)
        {
            this.Model = model;
            this.Material = material;
            this.Price = price;
            this.Height = height;
        }

        public string Model
        {
            get { return this.model; }
            private set
            {
                Validator.CheckIfStringLengthIsValid(value, string.Format(ErrorMessages.InvalidStringLengthErrorMessage, "Model", Constants.MinModelNameLength), Constants.MinModelNameLength);
                Validator.CheckIfStringIsNullOrEmpty(value, string.Format(ErrorMessages.NullorEmptyErrorMessage, "Model"));
                this.model = value;
            }
        }
        public MaterialType Material { get; private set; }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                Validator.CheckIfNumberIsLessThanOrEqualToZero(value, string.Format(ErrorMessages.NumberLessThanOrEqualToErrorMessage, "Price", 0));
                this.price = value;
            }
        }

        public decimal Height
        {
            get { return this.height; }
            protected set
            {
                Validator.CheckIfNumberIsLessThanOrEqualToZero(value, string.Format(ErrorMessages.NumberLessThanOrEqualToErrorMessage, "Height", 0));
                this.height = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}", this.GetType().Name, this.Model, this.Material, this.Price, this.Height);
        }

    }
}
