namespace Cosmetics.Products
{
    using Cosmetics.Common;
    using Cosmetics.Contracts;

    public abstract class Product : IProduct
    {
        protected string _name;
        protected string _brand;
        protected decimal _price;

        protected Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
        }

        public string Name
        {
            get { return _name; }
            private set
            {
                Validator.CheckIfStringLengthIsValid(value, 10, 3,
                    string.Format(GlobalErrorMessages.InvalidStringLength, "Product name", 3, 10));
                
                _name = value;
            }
        }

        public string Brand
        {
            get { return _brand; }
            private set
            {
                Validator.CheckIfStringLengthIsValid(value, 10, 2,
                   string.Format(GlobalErrorMessages.InvalidStringLength, "Product brand", 2, 10));
                _brand = value;
            }
        }

        public virtual decimal Price
        {
            get { return this._price; }
            protected set { this._price = value; }
        }

        public GenderType Gender { get; protected set; }

        public abstract string Print();
    }
}
