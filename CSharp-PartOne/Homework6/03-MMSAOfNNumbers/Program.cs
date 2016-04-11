using System;
//Write a program that reads from the console a sequence of N integer
//numbers and returns the minimal, the maximal number, the sum and the
//average of all numbers(displayed with 2 digits after the decimal point).
namespace _03_MMSAOfNNumbers
{
    class Program
    {
        static void Main()
        {
            ushort n = ushort.Parse(Console.ReadLine());
            double[] numbers = new double[n];
            double? max = -10001;
            double min = 10001;
            double sum = 0;

            for (int i = 0; i < n; i++)
            {
                numbers[i] = double.Parse(Console.ReadLine());
                
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
                if (numbers[i] < min)
                {
                    min = numbers[i];
                }
                sum += numbers[i];
            }
            double avg = sum / numbers.Length;

            Console.WriteLine("min=" + min);
            Console.WriteLine("max=" + max);
            Console.WriteLine("sum=" + sum);
            Console.WriteLine("avg={0:F2}", avg);
        }
    }
}
