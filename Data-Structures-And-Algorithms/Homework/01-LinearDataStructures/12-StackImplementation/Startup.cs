using System;
using System.Collections.Generic;

namespace _12_StackImplementation
{
    internal class Startup
    {
        private static void Main(string[] args)
        {
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            foreach (var i in stack)
            {
                Console.WriteLine(i);
            }

            var size = stack.Size;
            for (var i = 0; i < size; i++)
            {
                Console.WriteLine(stack.Pop());
            }
        }
    }
}
