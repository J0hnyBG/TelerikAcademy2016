using System;
using System.Collections.Generic;

using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Repositories;
using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Framework.Core.Commands
{
    public class CreateStudentCommand : ICommand
    {
        private readonly IStudentFactory studentFactory;

        public CreateStudentCommand(IStudentFactory studentFactory)
        {
            if (studentFactory == null)
            {
                throw new ArgumentNullException(nameof(studentFactory));
            }

            this.studentFactory = studentFactory;
        }

        public string Execute(IList<string> parameters, ISchoolSystemData data)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var grade = (Grade)int.Parse(parameters[2]);

            var student = this.studentFactory.GetStudent(firstName, lastName, grade);
            var studentId = data.Students.NextId;

            data.Students.Add(student);

            return $"A new student with name {firstName} {lastName}, grade {grade} and ID {studentId} was created.";
        }
    }
}
