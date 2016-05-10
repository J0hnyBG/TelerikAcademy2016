using System;
using System.Linq;

namespace _06_FirstLargerThanNeighbours
{
    class FirstLarger
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            int[] arr = Console.ReadLine().Trim().Split(' ').Select(n => Convert.ToInt32(n)).ToArray();

            int firstIndex = FindFirstLargerThanNeightbours(arr);

            Console.WriteLine(firstIndex);
        }

        static int FindFirstLargerThanNeightbours(int[] arr)
        {
            int index = -1;
            for (int i = 1; i < arr.Length - 1; i++)
            {
                if (CheckIfLargerThanNeightbours(arr[i], arr[i - 1], arr[i + 1]))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        static bool CheckIfLargerThanNeightbours(int target, int previous, int next)
        {
            return target > previous && target > next;
        }
    }
}
