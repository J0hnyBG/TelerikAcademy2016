using System;

namespace PersonClass
{
    internal class Startup
    {
        private static void Main()
        {
            var personWithAge = new Person("Petar Petrov", 25);
            var personWithoutAge = new Person("Ivan Ivanov");

            Console.WriteLine(personWithAge);
            Console.WriteLine(personWithoutAge);
        }
    }
}