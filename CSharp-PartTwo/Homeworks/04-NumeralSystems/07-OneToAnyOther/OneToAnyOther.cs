using System;

namespace _07_OneToAnyOther
{
    internal class OneToAnyOther
    {   //TODO: Fails some tests
        private static void Main()
        {
            int startingBase = int.Parse(Console.ReadLine());
            string inputNumber = Console.ReadLine();
            int targetBase = int.Parse(Console.ReadLine());

            long numberInDecimal = GetNumberInDecimal(inputNumber, startingBase);

            Console.WriteLine(ConvertToBase(numberInDecimal, targetBase));
        }

        private static string ConvertToBase(long value, int targetBase)
        {
            char[] baseChars = GetBaseChars(targetBase);
            string result = string.Empty;

            do
            {
                result = baseChars[Math.Abs(value)%targetBase] + result;
                value = value/targetBase;
            } while (value > 0);

            return result;
        }

        private static char[] GetBaseChars(int targetBase)
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

        private static long GetNumberInDecimal(string input, int startingBase)
        {
            char[] baseChars = GetBaseChars(startingBase);
            long result = 0;

            for (int i = 0; i < input.Length; i++)
            {
                result += (Array.IndexOf(baseChars, input[input.Length - i - 1]))*(long) Math.Pow(startingBase, i);
            }

            return result;
        }
    }
}