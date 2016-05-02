using System;

namespace _09_FrequentNumber
{
    class FrequentNumber
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            int mostRepeatedNumber = 0;
            int maxRepeatCount = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                int currentNumber = arr[i];
                int repeatCount = 0;

                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr[j] == currentNumber)
                    {
                        repeatCount++;
                    }
                }
                if (repeatCount > maxRepeatCount)
                {
                    mostRepeatedNumber = currentNumber;
                    maxRepeatCount = repeatCount;
                }
            }
            Console.WriteLine("{0} ({1} times)", mostRepeatedNumber, maxRepeatCount);
        }
    }
}
