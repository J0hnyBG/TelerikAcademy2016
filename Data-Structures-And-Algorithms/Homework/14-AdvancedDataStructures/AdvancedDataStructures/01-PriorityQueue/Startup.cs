using System;

namespace _01_PriorityQueue
{
    internal class Startup
    {
        private static void Main(string[] args)
        {
            var queue = new PriorityQueue<int>();
            queue.Enqueue(5);
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(6);
            queue.Enqueue(4);

            var count = queue.Size;
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(queue.Dequeue());
            }
        }
    }
}
