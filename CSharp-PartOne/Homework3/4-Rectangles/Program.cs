using System;

namespace _4_Rectangles
{
    class Program
    {
        static void Main()
        {
            double w = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double area = w * h;
            double p = 2* (w + h);

            Console.WriteLine("{0} {1}", string.Format("{0:0.00}", area), string.Format("{0:0.00}", p));
        }
    }
}
