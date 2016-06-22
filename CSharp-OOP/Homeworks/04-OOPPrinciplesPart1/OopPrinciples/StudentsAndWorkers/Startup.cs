namespace StudentsAndWorkers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    internal class Startup
    {
        private static void Main()
        {
            var listOfStudents = new List<Student>
            {
                new Student("Petar", "Petrov", 2),
                new Student("Georgi", "Petrov", 5),
                new Student("Ivan", "Petrov", 6),
                new Student("Testio", "Testunov", 3),
                new Student("Petarka", "Petrova", 4),
                new Student("John", "Simeonov", 5),
                new Student("Ceko", "Cekov", 6),
                new Student("Petar", "Toshov", 4),
                new Student("Tosho", "Petrov", 5),
                new Student("Meto", "Metov", 2),
            };

            Console.WriteLine("List of students ordered by grade: ");
            var orederedListOfStudents = listOfStudents.OrderBy(x => x.Grade);

            foreach (var student in orederedListOfStudents)
            {
                Console.WriteLine($"Name: {student.FirstName} {student.LastName}, Grade: {student.Grade}");
            }
            var listOfWorkers = new List<Worker>
            {
                new Worker("Petar", "Petrov", 300.3m, 2),
                new Worker("Georgi", "Petrov", 500, 5),
                new Worker("Ivan", "Petrov",8000, 6),
                new Worker("Testio", "Testunov", 350,3),
                new Worker("Petarka", "Petrova",150, 4),
                new Worker("John", "Simeonov",500, 5),
                new Worker("Ceko", "Cekov", 600,8),
                new Worker("Petar", "Toshov",900, 4),
                new Worker("Tosho", "Petrov",5, 5),
                new Worker("Meto", "Metov", 50,2),
            };

            Console.WriteLine("\nList of workers ordered by hourly pay: ");
            var orderedListOfWorkers = listOfWorkers.OrderBy(x => x.MoneyPerHour());

            foreach (var worker in orderedListOfWorkers)
            {
                Console.WriteLine($"Name: {worker.FirstName} {worker.LastName}, Money Per Hour: {worker.MoneyPerHour():F2}");
            }

            var merged = new List<Human>();
            merged.AddRange(orderedListOfWorkers);
            merged.AddRange(orederedListOfStudents);

            var sortedMerged = merged.OrderBy(x => x.FirstName).ThenBy(x => x.LastName);
            Console.WriteLine("\nList of workers and students ordered by first then by last name: ");

            foreach ( var human in sortedMerged )
            {
                Console.WriteLine($"Name: {human.FirstName} {human.LastName}");
            }

        }
    }
}
