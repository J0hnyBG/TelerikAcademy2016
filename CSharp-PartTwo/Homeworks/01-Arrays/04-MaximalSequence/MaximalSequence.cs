using System;

namespace _04_MaximalSequence
{
    class MaximalSequence
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];

            int maximalSequence = 0;
            int currentSequence = 0;
            bool updated = false;

            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
                if (i==0)
                {
                    currentSequence = 1;
                    continue;
                }
                if (array[i] == array[i-1])
                {
                    updated = false;
                    currentSequence++;
                }
                else
                {
                    updated = true;
                    maximalSequence = Math.Max(currentSequence, maximalSequence);
                    currentSequence = 1;
                }
            }

            Console.WriteLine(updated ? maximalSequence : Math.Max(maximalSequence, currentSequence));
        }
    }
}
