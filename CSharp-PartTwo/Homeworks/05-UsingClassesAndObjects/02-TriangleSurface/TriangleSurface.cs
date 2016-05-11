using System;
using System.Threading;

namespace _02_TriangleSurface
{
    class TriangleSurface
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            double length = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double area = (length*height)/2;

            Console.WriteLine("{0:F2}", area);

        }
    }
}
