using System;
using System.Collections.Generic;

namespace _05_ZigZagSets
{
    //TODO: 70/100 - time limit
    internal class Startup
    {
        private static bool[] used;

        private static void Main()
        {
            var input = Console.ReadLine().Split(' ');
            var n = int.Parse(input[0]);
            var k = int.Parse(input[1]);
            used = new bool[n];

            var arr = new int[k];

            var result = GetZigZagCount(k - 1, n - 1, arr);

            Console.WriteLine(result);
        }

        private static int GetZigZagCount(int k, int n, IList<int> arr)
        {
            var count = 0;
            if (k == -1)
            {
                var isZigZag = true;
                for (var i = 1; i < arr.Count; i++)
                {
                    if (i % 2 == 0 && arr[i - 1] >= arr[i]
                        || i % 2 == 1 && arr[i - 1] <= arr[i])
                    {
                        isZigZag = false;
                        break;
                    }
                }

                if (isZigZag)
                {
                    count++;
                }
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
                    arr[k] = i;
                    count += GetZigZagCount(k - 1, n, arr);
                    used[i] = false;
                }
            }

            return count;
        }
    }
}
