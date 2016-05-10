using System;
using System.Linq;

namespace _08_NumberAsArray
{
    class NumberAsArray
    {
        static void Main()
        {
            //TODO: Fails all except zero tests
            string size = Console.ReadLine();
            int[] arr1 = Console.ReadLine().Trim().Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
            int[] arr2 = Console.ReadLine().Trim().Split(' ').Select(n => Convert.ToInt32(n)).ToArray();

            int[] result = SumArrays(arr1, arr2);

            for (int i = 0; i < result.Length; i++)
            {
                Console.Write(result[i] + " ");
            }

        }

        static int[] SumArrays(int[] arr1, int[] arr2)
        {
            int largerArrayCount = Math.Max(arr1.Length, arr2.Length);
            int smallerArrayCount = Math.Min(arr1.Length, arr2.Length);

            int[] result = new int[largerArrayCount];

            bool remainder = false;
            for (int i = 0; i < smallerArrayCount; i++)
            {
                int sum = arr1[i] + arr2[i];
                if (remainder)
                {
                    result[i] = sum % 10 + 1;
                    remainder = false;
                }
                else
                {
                    result[i] = sum % 10;
                }
                if (sum > 9)
                {
                    remainder = true;
                }
            }
            if (largerArrayCount == smallerArrayCount) return result;

            if (arr1.Length > arr2.Length)
            {
                for (int i = smallerArrayCount; i < largerArrayCount; i++)
                {
                    if (remainder)
                    {
                        result[i] = arr1[i] + 1;
                        remainder = false;
                    }
                    else
                    {
                        result[i] = arr1[i];
                    }
                }
            }
            else if (arr1.Length < arr2.Length)
            {
                for (int i = smallerArrayCount; i < largerArrayCount; i++)
                {
                    if (remainder)
                    {
                        result[i] = arr2[i] + 1;
                        remainder = false;
                    }
                    else
                    {
                        result[i] = arr2[i];
                    }
                }
            }

            return result;
        }
    }
}
