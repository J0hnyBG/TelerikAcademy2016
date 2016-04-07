using System;

namespace _06_QuadraticEquation
{
    class Program
    {
        static void Main()
        {
            //TODO: COrrect formula
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());

            double x1 = (-b + Math.Sqrt((b * b) - (4 * a * c))) / (2 * a);
            double x2 = (-b - Math.Sqrt((b * b) - (4 * a * c))) / (2 * a);

            bool x1IsNan = double.IsNaN(x1);
            bool x2IsNan = double.IsNaN(x2);
            string format = "{0:0.00}";

            if (x1IsNan && x2IsNan)
            {
                Console.WriteLine("no real roots");
            }
            else if (x1IsNan)
            {
                Console.WriteLine(string.Format(format, x2));
            }
            else if (x2IsNan)
            {
                Console.WriteLine(string.Format(format, x1));
            }
            else
            {
                if (x1 > x2)
                {
                    Console.WriteLine(string.Format(format, x2));
                    Console.WriteLine(string.Format(format, x1));
                }
                else if (x1 < x2)
                {
                    Console.WriteLine(string.Format(format, x1));
                    Console.WriteLine(string.Format(format, x2));
                }
                else
                {
                    Console.WriteLine(string.Format(format, x2));
                }
            }
        }
    }
}
