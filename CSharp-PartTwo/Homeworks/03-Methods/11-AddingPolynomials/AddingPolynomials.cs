using System;
using System.Linq;

namespace _11_AddingPolynomials
{
    class AddingPolynomials
    {
        static void Main()
        {
            string size = Console.ReadLine();
            int[] arr1 = Console.ReadLine().Trim().Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
            int[] arr2 = Console.ReadLine().Trim().Split(' ').Select(n => Convert.ToInt32(n)).ToArray();

            int[] sums = SumPolynomials(arr1, arr2);

            foreach (var sum in sums)
            {
                Console.Write(sum + " ");
            }
        }

        static int[] SumPolynomials(int[] arr1, int[] arr2)
        {
            int[] sums = new int[arr1.Length];

            for (int i = 0; i < arr1.Length; i++)
            {
                sums[i] = arr2[i] + arr1[i];
            }
            return sums;
        }
    }
}
