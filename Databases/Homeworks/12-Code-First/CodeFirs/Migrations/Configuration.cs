namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Data;

    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentSystemModel>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(StudentSystemModel context)
        {
            var anyCourses = context.Courses.Any();
            var anyStudents = context.Students.Any();
            var anyMaterials = context.Materials.Any();
            var anyHomeworks = context.Homeworks.Any();
            var random = new Random();

            const int courseCount = 15;
            if (!anyCourses)
            {
                for (var i = 0; i < courseCount; i++)
                {
                    var course = new Course
                                 {
                                     Description = $"Description for course {i}",
                                     Name = $"Course {i}"
                                 };

                    context.Courses.AddOrUpdate(course);
                }

                context.SaveChanges();
            }


            //const int materialsCount = 30;
            //if (!anyMaterials)
            //{
            //    for (var i = 0; i < materialsCount; i++)
            //    {
            //        var courseId = random.Next(0, courseCount);
            //        var course = context.Courses.FirstOrDefault(c => c.Id == courseId);
            //        var material = new Material
            //                       {
            //                           Name = $"Material {i}",
            //                           Course = course
            //                       };

            //        context.Materials.AddOrUpdate(material);
            //    }

            //    context.SaveChanges();
            //}

            const int studentsCount = 150;
            if (!anyStudents)
            {
                for (var i = 0; i < studentsCount; i++)
                {
                    var student = new Student
                                  {
                                      Name = $"Student {i}",
                                      StudentNumber = 1000000 + i
                                  };

                    context.Students.AddOrUpdate(student);
                }

                context.SaveChanges();
            }

            //const int homeworksCount = 300;
            //if (!anyHomeworks)
            //{
            //    for (int i = 0; i < homeworksCount; i++)
            //    {
            //        var courseId = random.Next(0, coursesCount);
            //        var course = context.Courses.FirstOrDefault(c => c.Id == courseId);

            //        var studentId = random.Next(0, studentsCount);
            //        var student = context.Students.FirstOrDefault(c => c.Id == studentId);

            //        var homework = new Homework
            //                       {
            //                           Course = course,
            //                           Student = student,
            //                           Content = $"Content for {i} homework.",
            //                           TimeSent = DateTime.Today
            //                       };

            //        context.Homeworks.AddOrUpdate(homework);
            //    }

            //    context.SaveChanges();
            //}

            var courses = context.Courses;
            foreach (var course in courses)
            {
                var studentsInCourseCount = random.Next(0, studentsCount);
                var students = context.Students.OrderBy(s => Guid.NewGuid()).Take(studentsInCourseCount);

                foreach (var student in students)
                {
                    course.Students.Add(student);
                }
            }

            context.SaveChanges();
        }
    }
}
