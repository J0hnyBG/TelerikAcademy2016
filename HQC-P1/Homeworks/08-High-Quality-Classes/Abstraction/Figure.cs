namespace Abstraction
{
    using System;

    internal abstract class Figure
    {
        protected Figure()
        {
        }

        public abstract double CalcPerimeter();

        public abstract double CalcSurface();

        protected void ValidateValue(double value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Value cannot be less than zero!");
            }
        }
    }
}
