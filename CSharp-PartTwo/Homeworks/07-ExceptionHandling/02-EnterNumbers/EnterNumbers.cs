using System;

namespace _02_EnterNumbers
{
    internal class EnterNumbers
    {
        private static void Main()
        {
            var arr = new int[10];

            for (int i = 0; i < arr.Length; i++)
            {
                try
                {
                    arr[i] = ReadNumber(0, 100);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Exception");
                    return;
                }
            }
            string output = string.Empty;

            for (int i = 0; i < arr.Length; i++)
            {
                if ( i == arr.Length - 1 )
                {
                    output = output + " < " + arr[i] + " < 100";
                    continue;
                }
                if (i == 0)
                {
                    output = "1 < " + output + arr[i];
                    continue;
                }
                else
                {
                    output = output + " < " + arr[i];
                }

                if (arr[i] <= arr[i-1] || arr[i] >= arr[i+1])
                {
                    Console.WriteLine("Exception");
                    return;
                }

            }
            Console.WriteLine(output);
        }

        private static int ReadNumber(int start, int end)
        {
            var n = int.Parse(Console.ReadLine());

            if (n <= start || n >= end)
            {
                throw new FormatException();
            }
            return n;
        }
    }
}