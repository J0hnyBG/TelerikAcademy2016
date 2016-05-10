using System;

namespace _03_EnglishDigit
{
    class EnglishDigit
    {
        static void Main()
        {
            string inputNumber = Console.ReadLine();

            char lastChar = GetLastChar(inputNumber);

            Console.WriteLine(ConvertDigitToWord(lastChar));
        }

        static char GetLastChar(string input)
        {
            return input[input.Length - 1];
        }

        static string ConvertDigitToWord(char digit)
        {
            switch (digit)
            {
                case '0':
                    return "zero";
                case '1':
                    return "one";
                case '2':
                    return "two";
                case '3':
                    return "three";
                case '4':
                    return "four";
                case '5':
                    return "five";
                case '6':
                    return "six";
                case '7':
                    return "seven";
                case '8':
                    return "eight";
                case '9':
                    return "nine";
            }
            return "not a digit";
        }
    }
}
