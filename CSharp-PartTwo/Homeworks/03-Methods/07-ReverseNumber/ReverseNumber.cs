using System;

namespace _07_ReverseNumber
{
    class ReverseNumber
    {
        static void Main()
        {
            string inputString = Console.ReadLine();

            string result = ReverseString(inputString);

            Console.WriteLine(result);
        }

        static string ReverseString(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);

        }
    }
}
