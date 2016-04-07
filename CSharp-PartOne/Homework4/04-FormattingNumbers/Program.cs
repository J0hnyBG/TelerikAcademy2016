using System;

namespace _04_FormattingNumbers
{
    class Program
    {
        static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            float b = float.Parse(Console.ReadLine());
            float c = float.Parse(Console.ReadLine());

            string hexValue = a.ToString("X").PadRight(10, ' ');
            string bitValue = Convert.ToString(a, 2).PadLeft(10, '0');


            Console.Write(hexValue + "|");
            Console.Write(bitValue + "|");
            Console.Write(String.Format("{0:0.00}", a).PadLeft(10, ' ') + "|");
            Console.Write(String.Format("{0:0.00}", a).PadRight(10, ' '));

        }
    }
}
