using System;
using System.Collections.Generic;
using System.Numerics;

namespace _03_Maslan
{
    internal class Maslan
    {
        private static void Main()
        {
            var input = Console.ReadLine();
            var numberString = input;
            var transformCount = 0;

            List<int> sumList = new List<int>();

            BigInteger result = 1;

            while (transformCount < 10 )
            {
                if (numberString.Length >= 1)
                {
                    numberString = numberString.Remove(numberString.Length - 1);
                    sumList.Add(GetSumOfOdds(numberString));
                }
                else if (numberString.Length == 0)
                {
                    foreach (var sum in sumList)
                    {
                        if (sum != 0)
                        {
                            result *= sum;
                        }
                    }
                    sumList.Clear();
                    numberString = result.ToString();
                    result = 1;
                    transformCount++;

                    if (numberString.Length == 1)
                    {
                        break;
                    }
                }
            }
            if (transformCount < 10)
            {
                Console.WriteLine(transformCount);
            }
            Console.WriteLine(numberString);
        }

        private static int GetSumOfOdds(string s)
        {
            if (s.Length == 0) return 0;
            int sum = 0;
            for (int i = 1; i < s.Length; i += 2)
            {
                sum += s[i] - '0';
            }

            return sum;
        }
    }
}