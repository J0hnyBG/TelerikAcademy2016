using System;

namespace _18_RemoveElementsFromArray
{
    class RemoveElements
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            int[] size = new int[n];

            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
                size[i] = 1;
            }

            int max = 1;
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (arr[i] >= arr[j] && size[i] <= size[j] + 1)
                    {
                        size[i] = size[j] + 1;
                        if (max < size[i])
                        {
                            max = size[i];
                        }
                    }
                }
            }

            Console.WriteLine(n - max);
        }
    }
}
