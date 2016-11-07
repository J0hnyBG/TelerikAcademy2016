using Company.DataGeneration.DataGenerators;

namespace Company.DataGeneration
{
    public class Startup
    {
        private static void Main()
        {
            var db = new CompanyEntities();

            using (db)
            {
                var random = new RandomGenerator();

                var departments = new DepartmentsDataGenerator();
                var projects = new ProjectsDataGenerator();
                var employees = new EmployeesDataGenerator();
                var reports = new ReportDataGenerator();
                var employeesProjects = new EmployeesProjectsDataGenerator();

                departments.Generate(db, random, 100);
                db.SaveChanges();

                projects.Generate(db, random, 1000);
                db.SaveChanges();

                employees.Generate(db, random, 5000);
                db.SaveChanges();

                reports.Generate(db, random, 50);
                db.SaveChanges();

                employeesProjects.Generate(db, random, 10);
                db.SaveChanges();
            }
        }
    }
}
