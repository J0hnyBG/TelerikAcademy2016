using System;
using System.Linq;

namespace _01_BinaryPasswords
{
    internal class Startup
    {
        private static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var asteriskCount = input.Count(ch => ch == '*');
            var result = ((ulong)1 << asteriskCount);
            Console.WriteLine(result);
        }
    }
}
