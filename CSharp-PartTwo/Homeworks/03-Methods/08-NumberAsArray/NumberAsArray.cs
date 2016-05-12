using System;
using System.Numerics;

namespace _08_NumberAsArray
{
    class NumberAsArray
    {
        static void Main()
        {
            string size = Console.ReadLine();

            string num1Str = Reverse(Console.ReadLine().Replace(" ", ""));
            string num2Str = Reverse(Console.ReadLine().Replace(" ", ""));

            BigInteger number = BigInteger.Parse(num1Str);
            BigInteger number2 = BigInteger.Parse(num2Str);

            BigInteger result = number + number2;
            string output = Reverse(result.ToString());

            foreach (var digit in output)
            {
                Console.Write(digit + " ");
            }
        }
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
