using System.Collections.Generic;
using System.Linq;

namespace _03_ExtensionMethodsAndStuff
{
    using System;
    using System.Text;
    using ExtensionMethods;
    class StartUp
    {
        static void Main()
        {
            var sb = new StringBuilder("Hello");
            sb = sb.Substring(0, 5);

            Console.WriteLine(sb.ToString());


            var arr  = new[] { -900, 2, 5, 6, 7, -800, 8, 2, 3, 900, 5 };
            var list = arr.ToList();
            list.Average();

            Console.WriteLine(arr.Max());
            Console.WriteLine(list.Min());
        }
    }
}
