using System;
using System.Collections.Generic;
using System.Numerics;


namespace _02_BunnyFactory
{
    internal class BunnyFactory
    {
        //TODO: 90/100
        private static List<int> bunniesInCage;

        private static void Main()
        {
            bunniesInCage = new List<int>();
            while (true)
            {
                string row = Console.ReadLine();
                if (row == "END")
                {
                    break;
                }
                bunniesInCage.Add(int.Parse(row));
            }

            int i = 0;
            while (true)
            {
                var sum = 0;
                for (var j = 0; j <= i; j++)
                {
                    sum += bunniesInCage[j];
                }
                if (bunniesInCage.Count < i || bunniesInCage.Count <= sum + i)
                {
                    break;
                }
                BigInteger sumOfNext = 0;
                BigInteger productOfNext = 1;

                for (var j = i + 1; j <= sum + i; j++)
                {
                    sumOfNext += bunniesInCage[j];
                    productOfNext *= bunniesInCage[j];
                }
                string nextCages = sumOfNext.ToString() + productOfNext.ToString();

                for (int j = sum + i + 1; j < bunniesInCage.Count; j++)
                {
                    nextCages = nextCages + bunniesInCage[j];
                }
                nextCages = nextCages.Replace("1", "");
                nextCages = nextCages.Replace("0", "");
                bunniesInCage.Clear();
                foreach (var ch in nextCages)
                {
                    bunniesInCage.Add(ch - '0');
                }

                i++;
            }


            foreach (var ch in bunniesInCage)
            {
                Console.Write(ch + " ");
            }
        }
    }
}