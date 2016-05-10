using System;
using System.Collections.Generic;
using System.Linq;

namespace _14_IntegerCalculations
{
    class IntegerCalculations
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Trim().Split(' ').Select(n => Convert.ToInt32(n)).ToArray();

            Console.WriteLine(GetMin(numbers));
            Console.WriteLine(GetMax(numbers));
            Console.WriteLine("{0:F2}", GetAverage(numbers));
            Console.WriteLine(GetSum(numbers));
            Console.WriteLine(GetProduct(numbers));
        }

        static int GetMin(IEnumerable<int> numbers)
        {
            return numbers.Concat(new[] {int.MaxValue}).Min();
        }

        static int GetMax(IEnumerable<int> numbers)
        {
            return numbers.Concat(new[] {int.MinValue}).Max();
        }

        static double GetAverage(IReadOnlyCollection<int> numbers)
        {
            double average = numbers.Aggregate<int, double>(0, (current, number) => current + number);
            return average/numbers.Count;
        }

        static int GetSum(IEnumerable<int> numbers)
        {
            return numbers.Sum();
        }

        static long GetProduct(IEnumerable<int> numbers)
        {
            return numbers.Aggregate<int, long>(1, (current, number) => current*number);
        }


    }
}
