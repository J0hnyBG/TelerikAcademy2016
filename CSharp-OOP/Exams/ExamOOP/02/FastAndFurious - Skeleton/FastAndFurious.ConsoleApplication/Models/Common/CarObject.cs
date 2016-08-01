namespace FastAndFurious.ConsoleApplication.Models.Common
{
    public abstract class CarObject : Identifiable
    {
        private decimal price;

        protected CarObject(decimal price, int weight, int acceleration, int topSpeed)
        {
            this.Price = price;
            this.Weight = weight;
            this.Acceleration = acceleration;
            this.TopSpeed = topSpeed;
        }

        public virtual decimal Price
        {
            get { return this.price; }
            private set { this.price = value; }
        }

        public int Weight { get; private set; }
        public int Acceleration { get; private set; }
        public int TopSpeed { get; private set; }



    }
}
