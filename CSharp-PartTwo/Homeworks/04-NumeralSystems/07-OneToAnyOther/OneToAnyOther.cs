using System;

namespace _07_OneToAnyOther
{
    class OneToAnyOther
    {
        static void Main()
        {
            string inputNumber = Console.ReadLine();
            int startingBase = int.Parse(Console.ReadLine());
            int targetBase = int.Parse(Console.ReadLine());
            long numberInDecimal = 0;

            if (startingBase == 10)
            {
                numberInDecimal = long.Parse(inputNumber);
            }
            else
            {
                numberInDecimal = GetNumberInDecimal(inputNumber, startingBase);
            }

            Console.WriteLine(ConvertToBase(numberInDecimal, targetBase));
        }

        static long GetNumberInDecimal(string input, int startingBase)
        {
            long result = 0;
            for (int i = 0; i < input.Length; i++)
            {
                result += (input[input.Length - i - 1] - '0') * (long)Math.Pow(startingBase, i);
            }

            return result;
        }

        static string ConvertToBase(long number, int targetBase)
        {
            long result = number;
            long remainder;
            string output = string.Empty;

            while (targetBase <= result)
            {
                remainder = result % targetBase;
                result = result / targetBase;
                
                output = remainder + output;
            }
            remainder = result % targetBase;
            output = remainder + output;
            return output;
        }
    }
}
