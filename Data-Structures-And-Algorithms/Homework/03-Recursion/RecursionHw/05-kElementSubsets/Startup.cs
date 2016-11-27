using System;
using System.Collections.Generic;

namespace _05_kElementSubsets
{
    internal class Startup
    {
        private static void Main()
        {
            Console.Write("Enter k: ");
            var k = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the list of objects in the format 'hi a b': ");
            var objects = Console.ReadLine().Split(' ');
            var groups = new int[k];

            GenerateVariationsWithRepetitions(0, k, objects, groups);
        }

        private static void GenerateVariationsWithRepetitions(int index,int k, IList<string> objects, IList<int> groups)
        {
            if (index >= k)
            {
                PrintVariations(objects, groups);
            }
            else
            {
                for (var i = 0; i < objects.Count; i++)
                {
                    groups[index] = i;
                    GenerateVariationsWithRepetitions(index + 1,k, objects, groups);
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
