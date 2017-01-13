using System;
using System.Collections.Generic;

namespace _03_RingsOfTheAcademy
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var linkChildren = new Dictionary<int, IList<int>>();

            for (var i = 1; i <= n; i++)
            {
                var hangFrom = int.Parse(Console.ReadLine());

                if (hangFrom > 0)
                {
                    if (!linkChildren.ContainsKey(hangFrom))
                    {
                        linkChildren[hangFrom] = new List<int>();
                    }


                    linkChildren[hangFrom].Add(i);
                }
            }

            ulong result = 1;

            foreach (var linkChild in linkChildren)
            {
                result *= Factorial(linkChild.Value.Count);
            }

            Console.WriteLine(result);
        }

        private static ulong Factorial(int n)
        {
            ulong result = 1;
            for (uint i = 2; i <= n; i++)
            {
                result *= i;
            }

            return result;
        }
    }
}
