using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_EvenDifferences
{
    class EvenDifferences
    {
        static void Main()
        {
            long[] intArray = Console.ReadLine().Split(' ').Select(n => Convert.ToInt64(n)).ToArray();

            List<long> evenDifferences = new List<long>();

            for (int i = 1; i < intArray.Length; i++)
            {
                long absDifference = 0;
                absDifference = Math.Max(intArray[i], intArray[i - 1]) - Math.Min(intArray[i], intArray[i - 1]);

                if (absDifference % 2 == 0)
                {
                    evenDifferences.Add(absDifference);
                    i++;
                }
            }

            long differencesSum = evenDifferences.Aggregate<long, long>(0, (current, number) => current + number);

            Console.WriteLine(differencesSum);
        }
    }
}
