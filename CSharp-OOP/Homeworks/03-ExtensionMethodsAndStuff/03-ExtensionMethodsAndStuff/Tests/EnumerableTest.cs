namespace _03_ExtensionMethodsAndStuff.Tests
{
    using System;
    using ExtensionMethods;
    public static class EnumerableTest
    {
        public static void StartTest()
        {
            Console.WriteLine("Starting IEnumerable extensions test.");

            var arr = new[] { -900, 2, 5, 6, 7, -800, 8, 2, 3, 900, 5 };

            Console.WriteLine($"MyAverage: {arr.MyAverage()}");
            Console.WriteLine($"Sum: {arr.MySum()}");
            Console.WriteLine($"Max: {arr.MyMax()}");
            Console.WriteLine($"Min: {arr.MyMin()}");
            Console.WriteLine($"Product: {arr.MyProduct()}");
        }
    }
}
