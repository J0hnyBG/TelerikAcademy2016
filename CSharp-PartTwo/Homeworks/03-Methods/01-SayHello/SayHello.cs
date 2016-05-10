using System;


namespace _01_SayHello
{
    class SayHello
    {
        static void Main()
        {
            Sayhello();
        }

        static void Sayhello()
        {
           string name =  Console.ReadLine();
            Console.WriteLine("Hello, {0}!", name);
        }
    }
}
