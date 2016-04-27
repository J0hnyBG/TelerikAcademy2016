using System;

namespace _01_2_4_8
{
    internal class Program
    {
        private static void Main()
        {
//TODO: fails some tests
            uint a = uint.Parse(Console.ReadLine());
            uint secretB = uint.Parse(Console.ReadLine());
            uint c = uint.Parse(Console.ReadLine());

            ulong result = 0;

            if (secretB == 2)
            {
                result = a % c;
            }
            else if (secretB == 4)
            {
                result = a + c;
            }
            else if (secretB == 8)
            {
                result = a * c;
            }

            if (result % 4 == 0)
            {
                Console.WriteLine(result/(ulong)4);
            }
            else
            {
                Console.WriteLine(result%(ulong)4);
            }
            Console.WriteLine(result);
        }
    }
}