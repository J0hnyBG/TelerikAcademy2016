using System;
using System.Collections.Generic;

using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Repositories;
using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Framework.Core.Commands
{
    public class CreateTeacherCommand : ICommand
    {
        private readonly ITeacherFactory teacherFactory;

        public CreateTeacherCommand(ITeacherFactory teacherFactory)
        {
            if (teacherFactory == null)
            {
                throw new ArgumentNullException(nameof(teacherFactory));
            }

            this.teacherFactory = teacherFactory;
        }

        public string Execute(IList<string> parameters, ISchoolSystemData data)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var subject = (Subject)int.Parse(parameters[2]);

            var teacher = this.teacherFactory.GetTeacher(firstName, lastName, subject);
            var teacherId = data.Teachers.NextId;

            data.Teachers.Add(teacher);

            return
                $"A new teacher with name {firstName} {lastName}, subject {subject} and ID {teacherId} was created.";
        }
    }
}
