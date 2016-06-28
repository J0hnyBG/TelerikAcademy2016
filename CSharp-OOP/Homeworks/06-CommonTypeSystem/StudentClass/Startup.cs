using System;

namespace StudentClass
{
    internal class Startup
    {
        private static void Main()
        {

            var pesho1 = new Student("Pesho", "Petrov", "Petrov", "999999999", "Kaspichan 2", "088889788", "pesho@kaspichan.com", 3, SpecialitiesEnum.Economics, UniversitiesEnum.Unss, FacultiesEnum.StatisticsAndInformatics);
            var pesho2 = new Student("Pesho", "Petrov", "Petrov", "999999999", "Kaspichan 2", "088889788", "pesho@kaspichan.com", 3, SpecialitiesEnum.Economics, UniversitiesEnum.Unss, FacultiesEnum.StatisticsAndInformatics);
            var gosho = new Student("Gosho", "Georgiev", "Georgiev", "888888888", "Kaspichan 1", "089889788", "georgi@kaspichan.com", 3, SpecialitiesEnum.Biology, UniversitiesEnum.Su, FacultiesEnum.AppliedScience);

            Console.WriteLine("We have three students: ");
            Console.WriteLine(pesho1);
            Divide();
            Console.WriteLine(pesho2);
            Divide();
            Console.WriteLine(gosho);

            Divide();
            Console.ForegroundColor = ConsoleColor.Green;
            var areTheyEqual = pesho1.Equals(pesho2);
            Console.WriteLine("The Pesho and Pesho are equal: " + areTheyEqual + " => when we use CompareTo we get: " + pesho2.CompareTo(pesho1));

            areTheyEqual = pesho1.Equals(gosho);
            Console.WriteLine("The Pesho and Gosho are equal: " + areTheyEqual +  " => when we use CompareTo we get: " + gosho.CompareTo(pesho1));

            areTheyEqual = pesho1 == pesho2;
            Console.WriteLine("The Pesho and Pesho are equal with equality operator: " + areTheyEqual);

            areTheyEqual = pesho1 == gosho;
            Console.WriteLine("The Pesho and Gosho are equal with equality operator: " + areTheyEqual);

            Console.WriteLine("Pesho hash code:" + pesho1.GetHashCode());
            Console.WriteLine("Second Pesho hash code: " + pesho2.GetHashCode());
            Console.WriteLine("Gosho hash code: " + gosho.GetHashCode());
            Divide();

            Console.WriteLine("Lets copy Gosho and change his info.");
            var ivan = (Student)gosho.Clone();
            ivan.FirstName = "Ivan";
            ivan.LastName = "Vladimirov";
            ivan.Ssn = "777777777";
            ivan.Email = "ivan@parvomai.com";
            ivan.Address = "Parvomai";
            ivan.Speciality = SpecialitiesEnum.BusinessAdministration;
            ivan.Faculty = FacultiesEnum.StatisticsAndInformatics;
            Divide();
            Console.WriteLine(ivan);
            Divide();
            Console.WriteLine("Gosho is still the same.");
            Console.WriteLine(gosho);
            Console.ForegroundColor = ConsoleColor.Gray;

        }

        private static void Divide()
        {
            Console.WriteLine(string.Empty.PadLeft(75, '=') + "\n");

        }
    }
}