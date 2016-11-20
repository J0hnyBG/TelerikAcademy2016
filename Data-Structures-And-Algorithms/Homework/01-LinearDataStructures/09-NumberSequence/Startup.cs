using System;
using System.Collections.Generic;

namespace _09_NumberSequence
{
    internal class Startup
    {
        private static void Main()
        {
            /*
S1 = N;
S2 = S1 + 1;
S3 = 2*S1 + 1;
S4 = S1 + 2;
S5 = S2 + 1;
S6 = 2*S2 + 1;
S7 = S2 + 2;
             */
            Console.WriteLine("Please enter n: ");
            var n = int.Parse(Console.ReadLine());
            var numberQueue = new Queue<int>();
            numberQueue.Enqueue(n);

            var result = new List<int> { n };
            while (result.Count < 50)
            {
                var currentValue = numberQueue.Dequeue();

                var first = currentValue + 1;
                numberQueue.Enqueue(first);

                var second = (currentValue * 2) + 1;
                numberQueue.Enqueue(second);

                var third = currentValue + 2;
                numberQueue.Enqueue(third);

                result.AddRange(new [] {first, second, third});
            }


            foreach (var i in result)
            {
                Console.Write($"{i}, ");
            }
        }
    }
}
