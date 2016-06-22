namespace _03_ExtensionMethodsAndStuff
{
    using System;
    using Tests;
    
    class StartUp
    {
        static void Main()
        {
            StringBuilderTests.StartTest();
            Console.WriteLine();

            EnumerableTest.StartTest();
            Console.WriteLine();

            StudentTest.StartTest();
            Console.WriteLine();

            TimerAndEventTest.StartTest();
        }
    }
}
