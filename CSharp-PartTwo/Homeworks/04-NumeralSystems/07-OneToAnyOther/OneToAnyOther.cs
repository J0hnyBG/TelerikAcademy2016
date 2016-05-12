using System;

namespace _07_OneToAnyOther
{
    internal class OneToAnyOther
    {
        //TODO: Fails some tests
        private static void Main()
        {
            uint startingBase = uint.Parse(Console.ReadLine());
            string inputNumber = Console.ReadLine();
            uint targetBase = uint.Parse(Console.ReadLine());

            ulong numberInDecimal = GetNumberInDecimal(inputNumber, startingBase);

            Console.WriteLine(ConvertToBase(numberInDecimal, targetBase));
        }

        private static string ConvertToBase(ulong value, uint targetBase)
        {
            char[] baseChars = GetBaseChars(targetBase);
            string result = string.Empty;

            do
            {
                result = baseChars[value%targetBase] + result;
                value = value/targetBase;
            } while (value > 0);

            return result;
        }

        private static char[] GetBaseChars(uint targetBase)
        {
            //Max base = 16
            char[] charArray =
            {
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
                'A', 'B', 'C', 'D', 'E', 'F'
            };
            char[] output = new char[targetBase];
            Array.Copy(charArray, output, targetBase);

            return output;
        }

        private static ulong GetNumberInDecimal(string input, uint startingBase)
        {
            char[] baseChars = GetBaseChars(startingBase);
            ulong result = 0;

            for (int i = 0; i < input.Length; i++)
            {
                ulong power = 1;
                for (int j = 1; j <= i; j++)
                {
                    power *= startingBase;
                }
                result += (uint) (Array.IndexOf(baseChars, input[input.Length - i - 1]))*power; //(ulong) Math.Pow(startingBase, i);
            }

            return result;
        }
    }
}