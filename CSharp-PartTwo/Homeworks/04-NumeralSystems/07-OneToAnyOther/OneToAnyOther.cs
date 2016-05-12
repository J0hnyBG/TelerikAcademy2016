using System;

namespace _07_OneToAnyOther
{
    internal class OneToAnyOther
    {
        //Max base = 16
        private static readonly char[] BaseDigitsArray =
        {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
            'A', 'B', 'C', 'D', 'E', 'F'
        };

        private static void Main()
        {
            var startingBase = uint.Parse(Console.ReadLine());
            var inputNumber = Console.ReadLine();
            var targetBase = uint.Parse(Console.ReadLine());

            var numberInDecimal = GetNumberInDecimal(inputNumber, startingBase);
            Console.WriteLine(ConvertToBase(numberInDecimal, targetBase));
        }

        private static string ConvertToBase(ulong value, uint targetBase)
        {
            var result = string.Empty;

            do
            {
                result = BaseDigitsArray[value%targetBase] + result;
                value = value/targetBase;
            } while (value != 0);

            return result;
        }

        private static ulong GetNumberInDecimal(string input, uint startingBase)
        {
            ulong result = 0;
            foreach (var digit in input)
            {
                result = (uint) Array.IndexOf(BaseDigitsArray, digit) + result*startingBase;
            }

            return result;
        }
    }
}