using System;

namespace _05_MaximalIncreasingSequence
{
    class MaxIncrSequence
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];

            int maximalSequence = 0;
            int currentSequence = 0;

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = int.Parse(Console.ReadLine());

                if (i == 0)
                {
                    continue;
                }
                if (array[i] > array[i - 1])
                {
                    currentSequence++;
                }
                else
                {
                    maximalSequence = Math.Max(currentSequence, maximalSequence);
                    currentSequence = 1;
                }
            }
            Console.WriteLine(maximalSequence);
        }
    }
}