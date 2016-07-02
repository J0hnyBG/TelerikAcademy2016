namespace Cosmetics.Products
{
    using Cosmetics.Common;
    using Cosmetics.Contracts;

    internal class Shampoo : Product, IShampoo
    {
        private uint _milliliters;
        private UsageType _usage;

        public Shampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage) : base(name, brand, price, gender)
        {
            this.Milliliters = milliliters;
            this.Usage = usage;
        }

        public uint Milliliters
        {
            get { return _milliliters; }
            private set
            {
                //Validator.CheckIfZero(value, string.Format(GlobalErrorMessages.CannotBeZero, "Shampoo volume"));
                _milliliters = value;
            }
        }

        public UsageType Usage
        {
            get { return _usage; }
            private set { _usage = value; }
        }

        public override decimal Price
        {
            get { return this.Milliliters * this._price; }
            protected set { this._price = value; }
        }

        public override string Print()
        {
            //return $"\n- {this.Brand} - {this.Name}:\n  * Price: ${this.Price}\n  * For genger: {this.Gender}\n  * Quantity: {this.Milliliters} ml\n  * Usage: {this.Usage}";
            return string.Format("\n- {0} - {1}:\n  * Price: ${2}\n  * For gender: {3}\n  * Quantity: {4} ml\n  * Usage: {5}", this.Brand, this.Name, this.Price, this.Gender, this.Milliliters, this.Usage);
        }
    }
}
