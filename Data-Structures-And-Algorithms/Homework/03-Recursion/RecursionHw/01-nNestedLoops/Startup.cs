using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_nNestedLoops
{
    internal class Startup
    {
        private static void Main()
        {
            var count = int.Parse(Console.ReadLine());
            var numbers = Enumerable.Range(0, count).Select(x => 1).ToArray();

            Loop(numbers, count, count);
        }

        private static void Loop(IList<int> arr, int current, int count)
        {
            for (var i = 0; i < count; i++)
            {
                if (current > 1)
                {
                    Loop(arr, current - 1, count);
                }
                else
                {
                    Console.WriteLine(string.Join(" ", arr));
                }

                arr[count - current]++;
            }

            arr[count - current] = 1;
        }
    }
}
