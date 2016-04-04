using System;

namespace _7_PointInACircle
{
    class Program
    {
        static void Main()
        {
            float x = float.Parse(Console.ReadLine());
            float y = float.Parse(Console.ReadLine());
            float radius = 2;
            double calc = x * x + y * y;

            if ( x * x + y * y <= radius * radius )
            {
                Console.Write("yes " + string.Format("{0:0.00}", Math.Sqrt(calc)));
            }
            else
            {
                Console.Write("no " + string.Format("{0:0.00}", Math.Sqrt(calc)));
            }
        }
    }
}
