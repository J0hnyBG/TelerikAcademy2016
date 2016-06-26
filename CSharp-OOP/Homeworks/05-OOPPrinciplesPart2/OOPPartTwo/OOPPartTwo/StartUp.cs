
namespace OOPPartTwo
{
    using System;

    using Models;
    class StartUp
    {
        static void Main()
        {
            var triangles = new[]
            {
                new Triangle(5, 2), 
                new Triangle(5, 5), 
                new Triangle(5, 3), 
                new Triangle(10, 2), 
                new Triangle(7, 4),
            };

            Console.WriteLine("Triangles area: ");
            foreach (var triangle in triangles)
            {
                Console.WriteLine(triangle.CalculateSurface());
            }

            var rectangles = new[]
            {
                new Rectangle(5, 2),
                new Rectangle(5, 5),
                new Rectangle(5, 3),
                new Rectangle(10, 2),
                new Rectangle(7, 4),
            };

            Console.WriteLine("Rectangles area: ");
            foreach ( var rectangle in rectangles )
            {
                Console.WriteLine(rectangle.CalculateSurface());
            }

            var squares = new[]
{
                new Square(5),
                new Square(4),
                new Square(3),
                new Square(2),
                new Square(1),
            };

            Console.WriteLine("Squares area: ");
            foreach ( var square in squares )
            {
                Console.WriteLine(square.CalculateSurface());
            }
        }
    }
}
