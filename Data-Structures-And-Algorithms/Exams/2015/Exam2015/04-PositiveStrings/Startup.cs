using System;
using System.Linq;

namespace _04_PositiveStrings
{
    internal class Startup
    {
        private static void Main(string[] args)
        {
            var template = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(template))
            {
                template = Console.ReadLine();
            }

            var result = FindFirstPositiveString(template);

            Console.WriteLine(result);
        }

        private static string FindFirstPositiveString(string template)
        {
            if (!CanBeValidPositiveString(template))
            {
                return "invalid";
            }

            return "invalid";
        }

        private static bool CanBeValidPositiveString(string toComplete)
        {
            return false;
        }
    }
}
