using System;

namespace _01_nNestedLoops
{
    internal class Startup
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Enter n: ");
            var n = int.Parse(Console.ReadLine());
            Loop(n);
        }

        private static void Loop(int n)
        {
            for (int i = 1; i < n + 1; i++)
            {
                Console.Write(i);
                Loop(n - 1);
                Console.WriteLine();
            }
        }
    }
}
