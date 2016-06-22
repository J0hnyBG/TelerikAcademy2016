namespace _03_ExtensionMethodsAndStuff.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Students;
    public static class StudentTest
    {
        private static readonly List<Student> StudentsList = new List<Student>
        {
            new Student(16, "Zachery", "Owen", "11114109", "02553658", "owen@abv.bg", new List<int> {2,2,2,2,2,5,6}, 1 ),
            new Student(17, "Ha", "Sinkfield", "11114103", "02553659", "ha@abv.bg", new List<int> {2,2,2,2,2,5,6}, 1),
            new Student(18, "Roy", "Campton", "11114104", "02553660", "campton@qmail.bg", new List<int> {2,2,2,2,2,5,2}, 5),
            new Student(19, "Jon", "Eatmon", "11114105", "0322553658", "eastmon@abv.bg", new List<int> {2,2,2,2,2,5,3}, 1),
            new Student(20, "Jon", "Atanasov", "11114106", "066553658", "atanasov@gmail.bg", new List<int> {2,2,5,2,2,5,5}, 2),
            new Student(24, "Jon", "Petrov", "11114106", "056553658", "petrov@abv.bg", new List<int> {2,2,2,2,2,5,6}, 2),
            new Student(26, "Jon", "Anastasov", "11114106", "0892553658", "jon@randommail.bg", new List<int> {2,2,2,2,2,5,6}, 2 ),
            new Student(26, "Two", "Markov", "11114106", "0892553658", "jon@randommail.bg", new List<int> {2,2}, 2 ),
            new Student(26, "Two", "Markov II", "11114106", "0892553658", "jon@randommail.bg", new List<int> {6,6}, 2 ),
            new Student(26, "Anton", "Petrov", "11114106", "0892553658", "jon@randommail.bg", new List<int> {2,2,2,2,2,5,6}, 2 ),

        };
        private static string[] listOfWords = new string[]
{
            "a",
            "bb",
            "ccc",
            "fffff",
            "dddd",
};
        public static void StartTest()
        {
            Console.WriteLine("List of students with first name before last name: ");
            var firstBeforeLast = StudentManager.GetFirstBeforeLast(StudentsList);

            foreach ( var student in firstBeforeLast)
            {
                Console.WriteLine($"First: {student.FirstName}; Last: {student.LastName}");
            }
            Console.WriteLine();
            Console.WriteLine("List of students between 18 and 24: ");

            var inAgeRange = StudentManager.InAgeRange(StudentsList);
            foreach ( var student in inAgeRange)
            {
                Console.WriteLine($"First: {student.FirstName}; Last: {student.LastName}; Age:{student.Age}");
            }
            Console.WriteLine();

            Console.WriteLine("List of students in descending order sorted by first then by last name with extension methods: ");

            var sortedWithExtensions = StudentManager.SortWithExtensions(StudentsList);
            foreach ( var student in sortedWithExtensions )
            {
                Console.WriteLine($"First: {student.FirstName}; Last: {student.LastName}");
            }
            Console.WriteLine();

            Console.WriteLine("List of students in descending order sorted by first then by last name with LINQ: ");

            var sortedWithLinq = StudentManager.SortWithLinq(StudentsList);
            foreach ( var student in sortedWithLinq )
            {
                Console.WriteLine($"First: {student.FirstName}; Last: {student.LastName}");
            }
            Console.WriteLine();

            Console.WriteLine("List of students in in group 2: ");

            var studentsInSecondGroup = StudentManager.GetStudentsFromGroup(StudentsList, 2);
            foreach ( var student in studentsInSecondGroup )
            {
                Console.WriteLine($"First: {student.FirstName}; Last: {student.LastName}; Group: {student.GroupNumber}");
            }
            Console.WriteLine();

            Console.WriteLine("List of students with e-mail in abv.bg: ");
            var studentsInAbv = StudentManager.GetStudentsInSpecificDomain(StudentsList, "abv.bg");
            foreach ( var student in studentsInAbv )
            {
                Console.WriteLine($"First: {student.FirstName}; Last: {student.LastName}; E-Mail: {student.Email}");
            }
            Console.WriteLine();

            Console.WriteLine("List of students with Sofia phones: ");
            var studentsInSofia = StudentManager.GetStudentsByPhone(StudentsList, "02");
            foreach ( var student in studentsInSofia )
            {
                Console.WriteLine($"First: {student.FirstName}; Last: {student.LastName}; Phone: {student.Tel}");
            }
            Console.WriteLine();

            Console.WriteLine("List of students who have at least 1 excellent mark: ");
            List<Student> excellentStudents = StudentManager.GetStudentsByMarks(StudentsList, 6).ToList();
            foreach ( var student in excellentStudents )
            {
                var anonymous = new { FullName = student.FullName, Marks = student.Marks };
                Console.WriteLine($"Full name: {anonymous.FullName};");
            }
            Console.WriteLine();

            Console.WriteLine("List of students who have exactly two marks: ");
            var studentsWithTwoMarks = StudentManager.GetStudentsWithSpecificNumberOfMarks(StudentsList, 2);
            foreach ( var student in studentsWithTwoMarks )
            {
                Console.WriteLine($"Full name: {student.FullName};");
            }
            Console.WriteLine();

            var marksFrom2006 = StudentManager.ExtractAllMarksFromYear(StudentsList, 2006);
            Console.WriteLine($"Number of marks in 2006: {marksFrom2006.Count}");
            foreach (var mark in marksFrom2006)
            {
                Console.Write(mark + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Longest word: ");
            Console.WriteLine(StudentManager.FindLongest(listOfWords));

            Console.WriteLine();
            Console.WriteLine("Students grouped by group:");

            StudentManager.GroupByGroup(StudentsList);
            Console.WriteLine("Students grouped by group with LINQ:");

            StudentManager.GroupByGroupLinq(StudentsList);
        }
    }
}
