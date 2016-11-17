using System;

namespace _11_LinkedListImplementation
{
    internal class Startup
    {
        private static void Main()
        {
            var list = new LinkedList<int>();
            list.AddFirst(2);
            list.AddLast(50);
            list.AddLast(20);
            list.AddLast(50);
            list.AddFirst(1000);
            list.AddFirst(1001);
            list.AddLastRange(new[] { 1, 2, 3, 4, 5, 6, 7, 8 });
            list.RemoveFirst();
            list.RemoveLast();
            list.RemoveFirst(1);
            list.AddLast(404);

            var a = list.Find(404);
            Console.WriteLine(a);

            foreach (var number in list)
            {
                Console.WriteLine(number);
            }
        }
    }
}
