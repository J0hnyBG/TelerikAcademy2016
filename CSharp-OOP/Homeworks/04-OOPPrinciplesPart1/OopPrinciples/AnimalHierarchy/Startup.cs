namespace AnimalHierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    internal class Startup
    {
        private static void Main()
        {
            var cats = new List<Cat>
            {
                new Cat(12, "Cat1", 'F'),
                new Cat(13, "Cat2", 'F'),
                new Cat(1, "Cat3", 'F'),
                new Cat(22, "Cat4", 'F'),
                new Cat(2, "Cat5", 'F'),
                new Cat(6, "Cat6", 'F'),
                new Cat(5, "Cat7", 'F')
            };

            var averageAgeOfCats = cats.Sum(x => x.Age)/(double) cats.Count;

            var tomCats = new List<TomCat>
            {
                new TomCat(12, "Tomcat1", 'M'),
                new TomCat(13, "Tomcat2", 'm'),
                new TomCat(10, "Tomcat3", 'm'),
                new TomCat(22, "Tomcat4", 'm'),
                new TomCat(20, "Tomcat5", 'm'),
                new TomCat(16, "Tomcat6", 'm'),
                new TomCat(15, "Tomcat7", 'm')
            };

            var averageAgeOfTomCats = tomCats.Sum(x => x.Age)/(double) tomCats.Count;

            var dogs = new List<Dog>
            {
                new Dog(12, "Doggy1", 'M'),
                new Dog(13, "Doggy2", 'f'),
                new Dog(16, "Doggy3", 'm'),
                new Dog(2, "Doggy4", 'f'),
                new Dog(12, "Doggy5", 'm'),
                new Dog(14, "Doggy6", 'f'),
                new Dog(13, "Doggy7", 'm')
            };

            var averageAgeOfDogs = dogs.Sum(x => x.Age)/(double) dogs.Count;

            var frogs = new List<Frog>
            {
                new Frog(2, "Frog1", 'M'),
                new Frog(3, "Frog2", 'f'),
                new Frog(6, "Frog3", 'm'),
                new Frog(2, "Frog4", 'f'),
                new Frog(2, "Frog5", 'm'),
                new Frog(4, "Frog6", 'f'),
                new Frog(3, "Frog7", 'm')
            };

            var averageAgeOfFrogs = frogs.Sum(x => x.Age)/(double) frogs.Count;


            Console.WriteLine($"Average age of cats: {averageAgeOfCats:F2}");
            Console.WriteLine($"Average age of tomcats: {averageAgeOfTomCats:F2}");
            Console.WriteLine($"Average age of dogs: {averageAgeOfDogs:F2}");
            Console.WriteLine($"Average age of frogs: {averageAgeOfFrogs:F2}");

            Console.WriteLine("\nTesting animal sounds: ");

            cats[0].ProduceSound();
            tomCats[0].ProduceSound();
            dogs[0].ProduceSound();
            frogs[0].ProduceSound();
        }
    }
}