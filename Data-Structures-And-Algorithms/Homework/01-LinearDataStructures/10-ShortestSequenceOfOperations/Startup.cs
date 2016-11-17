using System;
using System.Collections.Generic;

namespace _10_ShortestSequenceOfOperations
{
    internal class Startup
    {
        private static void Main(string[] args)
        {
            //TODO:
            Console.WriteLine("Please enter N: ");
            var n = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter M: ");
            var m = int.Parse(Console.ReadLine());

            var numberQueue = new Queue<int>();
            numberQueue.Enqueue(n);
            var result = new List<int>() { n };
            var current = n;

            while (current != m)
            {
                current = numberQueue.Dequeue();
                if (current == m)
                {
                    break;
                }
                var first = current + 1;
                var second = first + 2;
                var third = second * 2;

                numberQueue.Enqueue(third);
                result.AddRange(new [] {first, second, third});
            }

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
