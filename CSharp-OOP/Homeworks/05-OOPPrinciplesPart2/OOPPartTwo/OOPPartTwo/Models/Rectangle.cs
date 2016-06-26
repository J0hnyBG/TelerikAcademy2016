namespace OOPPartTwo.Models
{
    internal class Rectangle : Shape
    {
        public Rectangle(decimal width, decimal height) : base(width, height)
        {
        }

        public override decimal CalculateSurface()
        {
            return Width * Height;
        }
    }
}
