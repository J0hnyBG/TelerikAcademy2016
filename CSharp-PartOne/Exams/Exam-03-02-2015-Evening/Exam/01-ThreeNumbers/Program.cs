using System;

namespace _01_ThreeNumbers
{
    class Program
    {
        static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            int max = Math.Max(a, b);
            max = Math.Max(max, c);

            int min = Math.Min(a, b);
            min = Math.Min(min, c);

            double mean = (double)(a + b + c)/3;

            Console.WriteLine(max);
            Console.WriteLine(min);

            Console.WriteLine("{0:F3}", mean);
        }
    }
}
