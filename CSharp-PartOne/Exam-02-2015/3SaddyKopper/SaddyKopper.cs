using System;
using System.Collections.Generic;
using System.Linq;

namespace _3SaddyKopper
{
    class SaddyKopper
    {
        static void Main()
        {
            bool IsOneDigit = false;
            bool IsOneDigitInner = false;

            string input = Console.ReadLine();

            List<ulong> sumList = new List<ulong>();

            int transformCounter = 0;
            ulong evensMultiplied = 0;

            string number = input;
            while (!IsOneDigit)
            {
                while (!IsOneDigitInner)
                {
                    number = RemoveLast(number);
                    sumList.Add(GetSumOfEvens(number));
                    IsOneDigitInner = CheckIfLast(number);
                }
                evensMultiplied = sumList.Aggregate((a, x) => a * x);
                transformCounter++;

                number = evensMultiplied.ToString();
                IsOneDigit = CheckIfLast(number);
            }

            Console.WriteLine(number);
        }

        static bool CheckIfLast(string s)
        {
            if (s.Length == 1)
            {
                return true;
            }
            else return false;
        }

        static bool CheckIfLast(ulong n)
        {
            if (0 <= n && n <= 9)
            {
                return true;
            }
            else return false;
        }

        static string RemoveLast(string s)
        {
            s = s.Remove(s.Length - 1);
            return s;
        }

        static ulong GetSumOfEvens(string s)
        {
            ulong sum = 0;
            s.ToCharArray();
            for (int i = 0; i < s.Length; i += 2)
            {
                sum += (ulong)Char.GetNumericValue(s[i]);
            }
            return sum;
        }
    }
}
