using System;

namespace _01_CalculationProbem
{
    class CalculationProblem
    {
        private static readonly char[] BaseDigitsArray = "abcdefghijklmnopqrstuvw".ToCharArray();

        static void Main()
        {
            string[] catNumbers = Console.ReadLine().Split(' ');

            uint sumInDecimal = 0;
            foreach (var catNumber in catNumbers)
            {
                sumInDecimal += GetNumberInDecimal(catNumber, (uint)BaseDigitsArray.Length);
            }

            string sumInCat = ConvertToBase(sumInDecimal, (uint)BaseDigitsArray.Length);
            Console.WriteLine("{0} = {1}", sumInCat, sumInDecimal);
        }

        private static string ConvertToBase(ulong value, uint targetBase)
        {
            var result = string.Empty;

            do
            {
                result = BaseDigitsArray[value % targetBase] + result;
                value = value / targetBase;
            } while (value != 0);

            return result;
        }

        private static uint GetNumberInDecimal(string input, uint startingBase)
        {
            uint result = 0;
            foreach (var digit in input)
            {
                result = (uint) Array.IndexOf(BaseDigitsArray, digit) + result*startingBase;
            }

            return result;
        }
    }
}
