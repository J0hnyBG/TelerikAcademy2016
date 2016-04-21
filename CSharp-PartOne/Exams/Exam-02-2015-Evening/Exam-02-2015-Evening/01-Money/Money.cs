using System;

namespace _01_Money
{
    internal class Money
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine()); //students
            int s = int.Parse(Console.ReadLine()); //sheetsPerStudent
            double p = double.Parse(Console.ReadLine()); //priceOfOneRealm

            const int sheetsPerRealm = 400;

            double neededRealms = (n*s)/(double) sheetsPerRealm;

            double finalCost = Math.Round(neededRealms*p, 3);

            Console.WriteLine("{0:F3}", finalCost);
        }
    }
}