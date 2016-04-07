using System;

namespace _03_Circle
{
    class Program
    {
        static void Main()
        {
            double radius = double.Parse(Console.ReadLine());

            double area = Math.PI * radius * radius;
            double perimeter = Math.PI * radius * 2;

            Console.Write(string.Format("{0:0.00}", perimeter) + " ");
            Console.Write(string.Format("{0:0.00}", area));
        }
    }
}
