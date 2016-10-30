namespace CodeFirst
{
    using System;
    using System.Linq;

    using Data;

    public class Startup
    {
        private static void Main()
        {
            using (var dbContext = new StudentSystemModel())
            {
                dbContext.Database.CreateIfNotExists();

                var courses = dbContext.Courses.ToList();

                foreach (var course in courses)
                {
                    Console.WriteLine($"{course.Name}: {course.Description}");
                }
            }
        }
    }
}
