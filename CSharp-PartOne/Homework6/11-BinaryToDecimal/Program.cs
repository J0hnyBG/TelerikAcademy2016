using System;
using System.Linq;

//Using loops write a program that converts a binary integer number to its decimal form.
//The input is entered as string. The output should be a variable of type long.
//Do not use the built-in .NET functionality.

namespace _11_BinaryToDecimal
{
    class Program
    {
        static void Main()
        {
            char[] inputBinary = Console.ReadLine().ToCharArray();
            Array.Reverse(inputBinary);

            int result = 0;

            for (int i = 0; i < inputBinary.Length; i++)
            {
                if (inputBinary[i] == '1')
                {
                    result += (int)Math.Pow(2, i);
                }
            }

            Console.WriteLine(result);
        }
    }
}
