using System;

namespace _03_CompareCharArrays
{
    internal class CompareCharArrays
    {
        private static void Main()
        {
            string first = Console.ReadLine();
            string second = Console.ReadLine();

            int minLength = Math.Min(first.Length, second.Length);

            for (int i = 0; i < minLength; i++)
            {
                if (first[i] > second[i])
                {
                    Console.WriteLine(">");
                    return;
                }
                if (first[i] < second[i])
                {
                    Console.WriteLine("<");
                    return;
                }
            }
            if (first.Length > second.Length)
            {
                Console.WriteLine(">");
            }
            else if (first.Length < second.Length)
            {
                Console.WriteLine("<");
            }
            else
            {
                Console.WriteLine("=");
            }
        }
    }
}