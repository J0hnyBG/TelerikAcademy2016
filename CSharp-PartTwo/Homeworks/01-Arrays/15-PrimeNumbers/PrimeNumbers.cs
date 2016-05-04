using System;

namespace _15_PrimeNumbers
{
    class PrimeNumbers
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            n++;

            bool[] arr = new bool[n];

            for (int i = 2; i < n; i++)
            {
                arr[i] = true;
            }

            for (int i = 2; i < n; i++)
            {
                if (arr[i])
                {
                    for (long j = (long)i*i; j < n; j += (long)i)
                    {
                        arr[j] = false;
                    }
                }
            }

            for (int i = n - 1; i > 0; i--)
            {
                if (arr[i])
                {
                    Console.WriteLine(i);
                    break;
                }
            }
        }
    }
}
