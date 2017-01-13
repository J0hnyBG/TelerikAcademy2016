using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/*
6
3

4 5 6 3 1 2
    */

namespace _05_Swapping
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var numbers = Console.ReadLine()
                                 .Split(' ')
                                 .Select(int.Parse)
                                 .ToArray();

            var list = new LinkedList<int>();
            for (var i = 1; i <= n; i++)
            {
                list.AddLast(i);
            }

            for (var i = 0; i < numbers.Length; i++)
            {
                var node = list.Find(numbers[i]);
                var toRemove = node;
                var removedNodes = new Queue<int>();
                while (node != null)
                {
                    list.Remove(toRemove);
                    removedNodes.Enqueue(node.Value);
                    toRemove = node.Previous;
                    node = node.Previous;
                }

                var value = removedNodes.Dequeue();
                while (removedNodes.Count > 0)
                {
                    list.AddLast(value);
                    value = removedNodes.Dequeue();
                }
            }

            Console.WriteLine(string.Join(" ", list));
        }
    }
}