using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_GoldFever
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // 4
            // 1 2 1 2
            // OUT: 2
            var n = int.Parse(Console.ReadLine());
            var prices = Console.ReadLine()
                                .Split(' ')
                                .Select(int.Parse)
                                .ToArray();


            var res = CalculateMaxProfit(prices);
            Console.WriteLine(res);
        }

        /*def calcprofit(stockvalues): 
    dobuy=[1]*len(stockvalues) # 1 for buy, 0 for sell
    prof=0
    m=0
    for i in reversed(range(len(stockvalues))):
        ai=stockvalues[i] # shorthand name
        if m<=ai:
            dobuy[i]=0
            m=ai
        prof+=m-ai
    return (prof,dobuy)  */

        private static long CalculateMaxProfit(int[] prices)
        {
            var doBuy = new long[prices.Length];
            long prof = 0;
            var m = 0;
            for (int i = prices.Length - 1; i >= 0; i--)
            {
                var ai = prices[i];
                if (m <= ai)
                {
                    doBuy[i] = 0;
                    m = ai;
                }
                prof += m - ai;

            }

            return prof;
        }
    }
}
