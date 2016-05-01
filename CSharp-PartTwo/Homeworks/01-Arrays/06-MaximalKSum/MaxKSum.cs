using System;
using System.Linq;

namespace _06_MaximalKSum
{
    class MaxKSum
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            int[] arr = new int[n];

            int maxSum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            
            arr = arr.OrderByDescending(c => c).ToArray();

            for (int i = 0; i < k; i++)
            {
                maxSum += arr[i];
            }
            Console.WriteLine(maxSum);
        }
    }
}
