using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace _06_kStringSubsets
{
    internal class Startup
    {
        private static int n;
        private static int k;

        private static void Main(string[] args)
        {
            Console.Write("Enter k: ");
            k = int.Parse(Console.ReadLine()); //2;
            Console.WriteLine("Enter the list of objects in the format 'hi a b': ");
            var objects = Console.ReadLine().Split(' '); //new[] { "test", "rock", "fun" }; 
            n = objects.Length;

            var groups = new int[k];

            GenerateCombinationsNoRepetitions(0, 0, objects, groups);
        }

        private static void GenerateCombinationsNoRepetitions(int index,
                                                              int start,
                                                              IList<string> objects,
                                                              IList<int> groups)
        {
            if (index >= k)
            {
                PrintVariations(objects, groups);
            }
            else
            {
                for (var i = start; i < n; i++)
                {
                    groups[index] = i;
                    GenerateCombinationsNoRepetitions(index + 1, i + 1, objects, groups);
                }
            }
        }

        private static void PrintVariations(IList<string> objects, IEnumerable<int> groups)
        {
            foreach (var t in groups)
            {
                Console.Write(objects[t] + " ");
            }

            Console.WriteLine();
        }
    }
}
