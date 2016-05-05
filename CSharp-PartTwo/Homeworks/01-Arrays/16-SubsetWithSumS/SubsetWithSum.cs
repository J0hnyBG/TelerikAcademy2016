using System;

namespace _16_SubsetWithSumS
{
    internal class SubsetWithSum
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            int sumToFind = int.Parse(Console.ReadLine());

            bool doesSumExist = CheckIfSumExists(arr, 0, sumToFind);
            Console.WriteLine(doesSumExist ? "yes" : "no");
        }

        private static bool CheckIfSumExists(int[] arr, int startIndex, int sumToFind)
        {
            if (startIndex == arr.Length -1)
            {
                return arr[startIndex] == sumToFind || sumToFind == 0;
            }

            return CheckIfSumExists(arr, startIndex + 1, sumToFind) ||
                   CheckIfSumExists(arr, startIndex + 1, sumToFind - arr[startIndex]);
        }
    }
}
