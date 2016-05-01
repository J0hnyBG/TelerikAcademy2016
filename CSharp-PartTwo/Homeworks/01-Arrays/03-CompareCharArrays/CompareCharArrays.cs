using System;

namespace _03_CompareCharArrays
{
    class CompareCharArrays
    {
        static void Main()
        {
            string first = Console.ReadLine();
            string second = Console.ReadLine();

            if (first.Length == second.Length)
            {
                Console.WriteLine("=");
            }
            else if (first.Length > second.Length)
            {
                Console.WriteLine(">");
            }
            else
            {
                Console.WriteLine("<");
            }
        }
    }
}
