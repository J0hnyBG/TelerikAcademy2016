using System;

namespace _05_FindBits
{
    internal class Program
    {
        private static void Main()
        {
            int pattern = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            int occurences = 0;
            int mask = ~(1 << 31);
            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                number = ((number << 2) & mask) >> 2;

                for (int k = 0; k <= 24; k++)
                {
                    int temp = number;
                    temp = ((temp << 26 - k) & mask) >> 26;

                    if (temp == pattern)
                    {
                        occurences++;
                    }
                }
            }

            Console.WriteLine(occurences);
        }
    }
}