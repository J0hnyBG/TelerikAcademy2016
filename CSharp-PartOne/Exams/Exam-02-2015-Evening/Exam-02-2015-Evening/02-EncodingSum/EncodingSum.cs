using System;

namespace _02_EncodingSum
{
    class EncodingSum
    {
        static void Main()
        {
            var m = int.Parse(Console.ReadLine());
            var inputString = Console.ReadLine();
            long result = 0;

            foreach (char t in inputString)
            {
                if (t == '@')
                {
                    break;
                }

                if (Char.IsNumber(t))
                {
                    result *= t - '0';
                }
                else if (Char.IsLetter(t))
                {
                    char ch = Char.ToLower(t);
                    result += ch - 'a';
                }
                else
                {
                    result %= m;
                }
            }
            Console.WriteLine(result);
        }
    }
}
