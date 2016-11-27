using System;

namespace _03_CombinationsWithoutDuplicates
{
    internal class Startup
    {
        private static int n;
        private static int k;
        private static int[] arr;

        private static void Main()
        {
            Console.WriteLine("Enter n and k in the format 'n k': ");
            var input = Console.ReadLine().Split(' ');
            n = int.Parse(input[0]);
            k = int.Parse(input[1]);
            arr = new int[k];

            GenerateCombinationsNoRepetitions(0, 0);
        }

        private static void GenerateCombinationsNoRepetitions(int index, int start)
        {
            if (index >= k)
            {
                PrintArr();
            }
            else
            {
                for (var i = start; i < n; i++)
                {
                    arr[index] = i + 1;
                    GenerateCombinationsNoRepetitions(index + 1, i + 1);
                }
            }
        }

        private static void PrintArr()
        {
            Console.WriteLine("(" + string.Join(", ", arr) + ")");
        }
    }
}
