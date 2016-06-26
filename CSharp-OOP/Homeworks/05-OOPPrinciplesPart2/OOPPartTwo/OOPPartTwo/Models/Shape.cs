namespace OOPPartTwo.Models
{
    using System;

    internal abstract class Shape
    {
        protected decimal width;
        protected decimal height;

        protected Shape() { }
        protected Shape(decimal width, decimal height)
        {
            this.Width = width;
            this.Height = height;
        }

        public decimal Width
        {
            get { return width; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Width cannot be negative!");
                }
                width = value;
            }
        }

        public decimal Height
        {
            get { return height; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Height cannot be negative!");
                }
                height = value;
            }
        }

        public abstract decimal CalculateSurface();
    }
}