using System;

namespace _02_SymbolToNumber
{
    internal class Program
    {
        private static void Main()
        {
            int secret = int.Parse(Console.ReadLine());
            string inputString = Console.ReadLine();

            for (int i = 0; i < inputString.Length; i++)
            {
                int result = 0;
                if (inputString[i] == '@')
                {
                    break;
                }

                if (Char.IsLetter(inputString[i]))
                {
                    if (result == 0)
                    {
                        result = 1;
                    }
                    result = (inputString[i]*secret) + 1000;
                }
                else if (Char.IsDigit(inputString[i]))
                {
                    result = inputString[i] + secret + 500;
                }
                else
                {
                    result = inputString[i] - secret;
                }

                if (i%2 == 0)
                {
                    decimal newResult = (decimal) result/(decimal) 100;
                    Math.Round(newResult, 2);
                    Console.WriteLine("{0:F2}", newResult);
                }
                else
                {
                    result *= 100;
                    Console.WriteLine(result);
                }
            }
        }
    }
}
