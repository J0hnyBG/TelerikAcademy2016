
namespace OOPPartTwo.Models
{
    internal class Triangle : Shape
    {
        public Triangle(decimal width, decimal height) : base(width, height)
        {
        }

        public override decimal CalculateSurface()
        {
            return (Width*Height)/2;
        }
    }
}
