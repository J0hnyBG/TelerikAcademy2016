using System;
using System.Collections.Generic;

namespace _04_AllPermutations
{
    internal class Startup
    {
        private static bool[] used;

        private static void Main()
        {
            Console.WriteLine("Enter n: ");
            var input = Console.ReadLine().Split(' ');
            var n = int.Parse(input[0]);
            used = new bool[n];

            var arr = new int[n];

            GeneratePermutations(n - 1, n - 1, arr);
        }

        private static void GeneratePermutations(int k, int n, IList<int> arr)
        {
            if (k == -1)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
            else
            {
                for (var i = 0; i <= n; i++)
                {
                    if (used[i])
                    {
                        continue;
                    }

                    used[i] = true;
                    arr[k] = i + 1;
                    GeneratePermutations(k - 1, n, arr);
                    used[i] = false;
                }
            }
        }
    }
}
