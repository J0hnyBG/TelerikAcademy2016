namespace _03_ExtensionMethodsAndStuff.Tests
{
    using System;
    using System.Text;
    using ExtensionMethods;
    public static class StringBuilderTests
    {
        public static void StartTest()
        {
            Console.WriteLine("Starting StringBuilder extensions test.");
            var sb = new StringBuilder("The quick brown fox jumps over the lazy dog.");
            var next = sb.Substring(0, 10);
            Console.WriteLine(next.ToString());
            next = sb.Substring(10, 10);
            Console.WriteLine(next.ToString());
            Console.WriteLine();
        }
    }
}
