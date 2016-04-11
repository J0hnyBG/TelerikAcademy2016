using System;
//Using loops write a program that converts an integer number to its hexadecimal representation.
//The input is entered as long. The output should be a variable of type string.
//Do not use the built-in .NET functionality.

namespace _13_DecimalToHex
{
    class Program
    {
        static void Main()
        {
            ulong inputNumber = ulong.Parse(Console.ReadLine());
            ulong result = inputNumber;
            string hex = "";

            bool hasBeenConverted = false;

            while (!hasBeenConverted)
            {
                double fullResult = (double)result / 16;
                result = result / 16;
                int remainder = (int)((fullResult - result)*16);

                if (remainder <= 9 && remainder >= 0)
                {
                    hex = remainder + hex;
                }
                else
                {
                    switch (remainder)
                    {
                        case 10:
                            hex = "A" + hex;
                            break;
                        case 11:
                            hex = "B" + hex;
                            break;
                        case 12:
                            hex = "C" + hex;
                            break;
                        case 13:
                            hex = "D" + hex;
                            break;
                        case 14:
                            hex = "E" + hex;
                            break;
                        case 15:
                            hex = "F" + hex;
                            break;
                        default:
                            hex = "SomethingWentWrong";
                            break;
                    }
                }
                if (result == 0)
                {
                    hasBeenConverted = true;
                }  
            }
            Console.WriteLine(hex);
        }
    }
}
