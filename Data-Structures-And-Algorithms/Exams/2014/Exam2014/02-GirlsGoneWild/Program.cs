using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_GirlsGoneWild
{
    internal class Program
    {
        private static int[] shirts;
        private static int people;
        private static string skirts;
        private static List<string> results = new List<string>();

        private static readonly List<List<string>> PossibleCombinations =
            new List<List<string>>();

        private static void Main(string[] args)
        {
            // order doesnt matter
            // no duplicates
            var kShirts = int.Parse(Console.ReadLine());
            var skirtLetters = Console.ReadLine();
            var distinctLetters = skirtLetters.Distinct().ToArray();
            var people = int.Parse(Console.ReadLine());

            for (var i = 0; i < people; i++)
            {
                PossibleCombinations.Add(new List<string>());
                foreach (var ch in distinctLetters)
                {
                    for (var k = 0; k < kShirts; k++)
                    {
                        PossibleCombinations[i].Add(k + ch.ToString());
                    }
                }

                PossibleCombinations[i] = PossibleCombinations[i].OrderBy(x => x).ToList();
            }

            var a = PossibleCombinations.CartesianProduct();
            foreach (var vara in a)
            {
                //Console.WriteLine(string.Join("-", vara));
                results.Add(string.Join("-", vara));
            }

            Console.WriteLine(a.ToArray().Length);
            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
        }
    }

    public static class EnumerableExtensions
    {
        public static IEnumerable<IEnumerable<T>> CartesianProduct<T>(this IEnumerable<IEnumerable<T>> sequences)
        {
            IEnumerable<IEnumerable<T>> emptyProduct = new[] { Enumerable.Empty<T>() };
            return sequences.Aggregate(
                                       emptyProduct,
                                       (accumulator, sequence) =>
                                           from accseq in accumulator
                                           from item in sequence.Where(i => !accseq.Contains(i))
                                           select accseq.Concat(new[] { item }));
        }
    }
}
