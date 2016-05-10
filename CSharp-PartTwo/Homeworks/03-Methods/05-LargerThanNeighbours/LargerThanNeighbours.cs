using System;
using System.Linq;

namespace _05_LargerThanNeighbours
{
    class LargerThanNeighbours
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            int[] arr = Console.ReadLine().Trim().Split(' ').Select(n => Convert.ToInt32(n)).ToArray();

            int largerCount = CountLargerThanNeightbours(arr);

            Console.WriteLine(largerCount);
        }

        static int CountLargerThanNeightbours(int[] arr)
        {
            int largerCount = 0;
            for (int i = 1; i < arr.Length - 1; i++)
            {
                if (CheckIfLargerThanNeightbours(arr[i], arr[i-1], arr[i+1]))
                {
                    largerCount++;
                }
            }
            return largerCount;
        }

        static bool CheckIfLargerThanNeightbours(int target, int previous, int next)
        {
            return target > previous && target > next;
        }
    }
}
