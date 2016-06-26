namespace OOPPartTwo.Models
{
    internal class Square : Shape
    {
        public Square(decimal width)
        {
            this.Width = width;
            this.Height = width;
        }

        public override decimal CalculateSurface()
        {
            return Width * Height;
        }
    }
}
