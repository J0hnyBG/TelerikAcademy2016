using System;
using System.Collections.Generic;

using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Core.Repositories;
using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Framework.Core.Commands
{
    public class CreateStudentCommand : ICommand
    {
        private readonly IIdProvider idProvider;
        private readonly IStudentFactory studentFactory;

        public CreateStudentCommand(IIdProvider idProvider, IStudentFactory studentFactory)
        {
            if (idProvider == null)
            {
                throw new ArgumentNullException(nameof(idProvider));
            }

            if (studentFactory == null)
            {
                throw new ArgumentNullException(nameof(studentFactory));
            }

            this.idProvider = idProvider;
            this.studentFactory = studentFactory;
        }

        public string Execute(IList<string> parameters, ISchoolSystemData data)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var grade = (Grade)int.Parse(parameters[2]);

            var student = this.studentFactory.GetStudent(firstName, lastName, grade);
            var studentId = this.idProvider.GetNext();

            data.Students.Add(studentId, student);

            return $"A new student with name {firstName} {lastName}, grade {grade} and ID {studentId} was created.";
        }
    }
}
