using System;

namespace _9_Trapezoids
{
    class Program
    {
        static void Main()
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double area = h * (a + b)/2;

            Console.WriteLine(string.Format("{0:0.0000000}", area));
            
        }
    }
}
