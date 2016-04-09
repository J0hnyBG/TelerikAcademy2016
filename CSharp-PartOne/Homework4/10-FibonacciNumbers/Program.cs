using System;
using System.Collections.Generic;

internal class Program
{
    private static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        ulong[] memory = new ulong[n];

        for (int i = 0; i < n; i++)
        {
            if (i != n - 1)
            {
                ulong result = Fibonacci(i, memory);
                Console.Write(result + ", ");
            }
            else
            {
                ulong result = Fibonacci(i, memory);
                Console.Write(result);
            }
        }
    }

    private static ulong Fibonacci(int n, IList<ulong> memory)
    {
        if (memory[n] != 0) return memory[n];
        if (n == 0)
        {
            return 0;
        }
        if (n == 1)
        {
            return 1;
        }
        memory[n] = Fibonacci((n - 1), memory) + Fibonacci((n - 2), memory);

        return memory[n];
    }
}

