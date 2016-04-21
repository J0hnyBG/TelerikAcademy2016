using System;
using System.Collections.Generic;
using System.Numerics;
namespace _3SaddyKopper
{
    class SaddyKopper
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string number = input;

            bool IsOneDigit = false;
            int transformCounter = 0;
            BigInteger result = 0;

            while (!IsOneDigit)
            {
                bool IsOneDigitInner = false;
                List<uint> sumList = new List<uint>();

                while (!IsOneDigitInner)
                {
                    number = RemoveLast(number);
                    sumList.Add(GetSumOfEvens(number));
                    IsOneDigitInner = CheckIfLast(number);
                }

                //BigInteger result = 0;
                bool first = true;
                foreach (var @ulong in sumList)
                {
                    if (first)
                    {
                        first = false;
                        result = @ulong;
                        continue;
                    }
                    result = result*@ulong;
                }
                number = result.ToString();

                if (transformCounter == 9)
                {
                    break;
                }
                IsOneDigit = CheckIfLast(number);
                transformCounter++;
            }

            if (transformCounter == 9)
            {
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine(transformCounter);
                Console.WriteLine(result);
            } 
        }

        static bool CheckIfLast(string s)
        {
            return s.Length == 1;
        }

        static string RemoveLast(string s)
        {
            s = s.Remove(s.Length - 1);
            return s;
        }

        static uint GetSumOfEvens(string s)
        {
            uint sum = 0;
            for (int i = 0; i < s.Length; i += 2)
            {
                sum += (uint)Char.GetNumericValue(s[i]);
            }
            return sum;
        }
    }
}
