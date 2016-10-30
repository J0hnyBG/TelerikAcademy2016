namespace CodeFirst.Data
{
    using System.Data.Entity;

    using Migrations;

    using Models;

    public class StudentSystemModel : DbContext
    {
        public StudentSystemModel()
            : base("name=StudentSystemModel")
        {
            var migrationStrategy = new MigrateDatabaseToLatestVersion<StudentSystemModel, Configuration>();
            Database.SetInitializer(migrationStrategy);
        }

        public virtual IDbSet<Student> Students { get; set; }

        public virtual IDbSet<Course> Courses { get; set; }

        public virtual IDbSet<Material> Materials { get; set; }

        public virtual IDbSet<Homework> Homeworks { get; set; }

    }
}