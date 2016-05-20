using System;

namespace _02_ReverseAString
{
    class ReverseAString
    {
        static void Main()
        {
            var inputString = Console.ReadLine();
            Console.WriteLine(Reverse(inputString));
        }

        static string Reverse(string str)
        {
            var arr = str.ToCharArray();
            Array.Reverse(arr);
            str = string.Join("", arr);
            return str;
        }
    }
}
