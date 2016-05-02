using System;

namespace _01_MutantSquirrels
{
    class MutantSquirrels
    {
        static void Main()
        {
            ulong t = ulong.Parse(Console.ReadLine());
            ulong b = ulong.Parse(Console.ReadLine());

            ulong s = ulong.Parse(Console.ReadLine());
            ulong n = ulong.Parse(Console.ReadLine());

            ulong totalTails = t * b * s * n;


            if (totalTails % 2 == 0)
            {
                double result = totalTails * 376439;
                Console.WriteLine("{0:F3}", result);
            }
            else
            {
                double result = (double)totalTails /7;
                result = Math.Round(result, 3);
                Console.WriteLine("{0:F3}", result);
            }
        }
    }
}
