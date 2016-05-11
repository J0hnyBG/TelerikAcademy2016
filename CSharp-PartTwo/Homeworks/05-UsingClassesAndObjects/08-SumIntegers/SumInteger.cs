using System;
using System.Linq;

namespace _08_SumIntegers
{
    class SumInteger
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();
            int[] numbers = inputString.Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
            Console.WriteLine(SumIntegers(numbers));
        }

        static int SumIntegers(int[] numers)
        {
            return numers.Sum();
        }
    }
}
