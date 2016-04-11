using System;
//Using loops write a program that converts an integer number to its binary representation.
//The input is entered as long. The output should be a variable of type string.
//Do not use the built-in .NET functionality.

namespace _12_DecimalToBinary
{
    class Program
    {
        static void Main()
        {
            int inputDecimal = int.Parse(Console.ReadLine());

            bool hasHitOne = false;
            int remainder = inputDecimal;

            string result = "";

            for (int i = 31; i >= 0; i--)
            {
                var twoToThePowerOfI = Math.Pow(2, i);
                if (twoToThePowerOfI <= remainder)
                {
                    result += "1";
                    remainder -= (int)twoToThePowerOfI;
                    hasHitOne = true;
                }
                else
                {
                    if (hasHitOne)
                    {
                        result += "0";
                    }
                }
            }

            Console.WriteLine(result);
        }
    }
}
