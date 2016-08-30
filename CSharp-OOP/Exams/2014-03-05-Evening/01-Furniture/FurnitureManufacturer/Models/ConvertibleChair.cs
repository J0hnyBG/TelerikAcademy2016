namespace FurnitureManufacturer.Models
{
    using FurnitureManufacturer.Models.Common;
    using FurnitureManufacturer.Interfaces;

    public class ConvertibleChair : Chair, IConvertibleChair
    {
        public ConvertibleChair(string model, MaterialType material, decimal price, decimal height, int numberOfLegs)
            : base(model, material, price, height, numberOfLegs)
        {
            this.IsConverted = false;
        }

        public bool IsConverted { get; private set; }

        public void Convert()
        {
            if (this.IsConverted)
            {
                this.Height -= Constants.ConvertibleChairHeightDelta;
                this.IsConverted = false;
            }
            else
            {
                this.Height += Constants.ConvertibleChairHeightDelta;
                this.IsConverted = true;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(", State: {0}", this.IsConverted ? "Converted" : "Normal");
        }
    }
}
