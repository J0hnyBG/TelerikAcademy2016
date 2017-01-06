using System;
using System.Linq;

namespace ExchangeRates
{
    internal class Startup
    {
        private static void Main()
        {
            var maxCurrency1 = double.Parse(Console.ReadLine());
            var maxCurrency2 = 0d;
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var rates = Console.ReadLine()
                                   .Split(' ')
                                   .Select(double.Parse)
                                   .ToArray();
                var rate1To2 = rates[0];
                var rate2To1 = rates[1];

                double currCurrency1 = Math.Max(maxCurrency1, maxCurrency2 * rate2To1);
                double currCurrency2 = Math.Max(maxCurrency2, maxCurrency1 * rate1To2);

                maxCurrency1 = currCurrency1;
                maxCurrency2 = currCurrency2;
            }

            Console.WriteLine("{0:F2}", maxCurrency1);
        }
    }
}
