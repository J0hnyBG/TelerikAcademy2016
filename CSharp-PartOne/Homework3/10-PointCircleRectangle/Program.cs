using System;

namespace _10_PointCircleRectangle
{
    class Program
    {
        static void Main()
        {
            const int rectangleTopOffset = 1;
            const int rectangleLeftOffset = -1;
            const int rectangleWidth = 6;
            const int rectangleHeight = 2;

            const int circleX = 1;
            const int circleY = 1;
            const double circleRadius = 1.5;

            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());

            bool isInsideCircle = Math.Pow(x - circleX, 2) + Math.Pow(y - circleY, 2) <= circleRadius * circleRadius;
            bool isInsideRectangle = !(rectangleLeftOffset < x && x <= rectangleLeftOffset + rectangleWidth && rectangleTopOffset < y && y <= rectangleTopOffset + rectangleHeight);

            if (isInsideCircle)
            {
                Console.Write("inside circle ");
            }
            else
            {
                Console.Write("outside circle ");
            }
            if (isInsideRectangle)
            {
                Console.Write("inside rectangle");
            }
            else
            {
                Console.Write("outside rectangle");
            }
        }
    }
}