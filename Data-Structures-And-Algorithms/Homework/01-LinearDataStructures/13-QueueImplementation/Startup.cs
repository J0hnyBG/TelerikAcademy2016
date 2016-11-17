using System;
using System.Collections.Generic;

namespace _13_QueueImplementation
{
    internal class Startup
    {
        private static void Main(string[] args)
        {
            var q = new Queue<int>();

            var queue = new LinkedQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            var count = queue.Count;
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(queue.Dequeue());
            }
        }
    }
}
