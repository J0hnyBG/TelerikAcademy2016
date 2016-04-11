using System;
//Using loops write a program that converts a hexadecimal integer number to its decimal form.
//The input is entered as string. The output should be a variable of type long.
//Do not use the built-in .NET functionality.
namespace _14_HexToDecimal
{
    class Program
    {
        static void Main()
        {
            char[] inputHex = Console.ReadLine().ToUpper().ToCharArray();
            Array.Reverse(inputHex);
            
            ulong result = 0;

            for (int i = 0; i < inputHex.Length; i++)
            {
                int multiplier;
                if (inputHex[i] - '0' >= 0 && inputHex[i] - '0' <= 9)
                {
                    multiplier = inputHex[i] - '0';
                }
                else
                {
                    switch (inputHex[i])
                    {
                        case 'A':
                            multiplier = 10;
                            break;
                        case 'B':
                            multiplier = 11;
                            break;
                        case 'C':
                            multiplier = 12;
                            break;
                        case 'D':
                            multiplier = 13;
                            break;
                        case 'E':
                            multiplier = 14;
                            break;
                        case 'F':
                            multiplier = 15;
                            break;
                        default:
                            multiplier = 0;
                            break;
                    }
                }
                result += (ulong)multiplier * (ulong)Math.Pow(16, i);
            }
            
            Console.WriteLine(result);
        }
    }
}
