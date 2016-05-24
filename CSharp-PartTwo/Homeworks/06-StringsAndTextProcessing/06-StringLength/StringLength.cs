using System;

namespace _06_StringLength
{
    class StringLength
    {
        static void Main()
        {
            Console.WriteLine(Console.ReadLine()
                                .Replace("\\", string.Empty)
                                .PadRight(20, '*'));
        }
    }
}
