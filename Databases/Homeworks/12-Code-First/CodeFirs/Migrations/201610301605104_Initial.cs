namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            this.CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Description = c.String(nullable: false, storeType: "ntext"),
                    })
                .PrimaryKey(t => t.Id);

            this.CreateTable(
                "dbo.Homework",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false),
                        TimeSent = c.DateTime(nullable: false),
                        StudentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId);

            this.CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        StudentNumber = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            this.CreateTable(
                "dbo.Materials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);

            this.CreateTable(
                "dbo.StudentCourses",
                c => new
                    {
                        Student_Id = c.Int(nullable: false),
                        Course_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_Id, t.Course_Id })
                .ForeignKey("dbo.Students", t => t.Student_Id, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_Id, cascadeDelete: true)
                .Index(t => t.Student_Id)
                .Index(t => t.Course_Id);
            
        }
        
        public override void Down()
        {
            this.DropForeignKey("dbo.Materials", "CourseId", "dbo.Courses");
            this.DropForeignKey("dbo.Homework", "StudentId", "dbo.Students");
            this.DropForeignKey("dbo.StudentCourses", "Course_Id", "dbo.Courses");
            this.DropForeignKey("dbo.StudentCourses", "Student_Id", "dbo.Students");
            this.DropForeignKey("dbo.Homework", "CourseId", "dbo.Courses");
            this.DropIndex("dbo.StudentCourses", new[] { "Course_Id" });
            this.DropIndex("dbo.StudentCourses", new[] { "Student_Id" });
            this.DropIndex("dbo.Materials", new[] { "CourseId" });
            this.DropIndex("dbo.Homework", new[] { "CourseId" });
            this.DropIndex("dbo.Homework", new[] { "StudentId" });
            this.DropTable("dbo.StudentCourses");
            this.DropTable("dbo.Materials");
            this.DropTable("dbo.Students");
            this.DropTable("dbo.Homework");
            this.DropTable("dbo.Courses");
        }
    }
}
