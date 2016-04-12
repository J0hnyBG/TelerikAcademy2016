using System;
using System.Collections.Generic;
using System.Linq;

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
            

            while (!IsOneDigit)
            {
                bool IsOneDigitInner = false;
                List<ulong> sumList = new List<ulong>();

                while (!IsOneDigitInner)
                {
                    number = RemoveLast(number);
                    sumList.Add(GetSumOfEvens(number));
                    IsOneDigitInner = CheckIfLast(number);
                }

                number = sumList.Aggregate((a, x) => a * x).ToString();

                if (transformCounter == 9)
                {
                    break;
                }
                IsOneDigit = CheckIfLast(number);
                transformCounter++;
            }

            if (transformCounter == 9)
            {
                Console.WriteLine(number);
            }
            else
            {
                Console.WriteLine(transformCounter);
                Console.WriteLine(number);
            } 
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
