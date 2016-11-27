using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace _02_CombinationsWithDuplicates
{
    internal class Startup
    {
        private static void Main()
        {
            Console.WriteLine("Enter n and k in the format 'n k': ");
            var input = Console.ReadLine().Split(' ');
            var n = int.Parse(input[0]);
            var k = int.Parse(input[1]);

            var set = Enumerable.Range(1, n).ToList();
            var combinations = GenerateCombinations(set, k);

            foreach (var combination in combinations)
            {
                Console.WriteLine(string.Join(" ", combination));
            }
        }

        private static List<List<T>> GenerateCombinations<T>(IList<T> combinationList, int k)
        {
            var combinations = new List<List<T>>();

            if (k == 0)
            {
                var emptyCombination = new List<T>();
                combinations.Add(emptyCombination);

                return combinations;
            }

            if (combinationList.Count == 0)
            {
                return combinations;
            }

            T head = combinationList[0];
            var copiedCombinationList = new List<T>(combinationList);

            List<List<T>> subcombinations = GenerateCombinations(copiedCombinationList, k - 1);

            foreach (var subcombination in subcombinations)
            {
                subcombination.Insert(0, head);
                combinations.Add(subcombination);
            }

            combinationList.RemoveAt(0);
            combinations.AddRange(GenerateCombinations(combinationList, k));

            return combinations;
        }
    }
}
