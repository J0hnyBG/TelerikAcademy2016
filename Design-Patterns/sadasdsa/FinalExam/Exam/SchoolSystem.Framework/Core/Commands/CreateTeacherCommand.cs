using System;
using System.Collections.Generic;

using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Core.Repositories;
using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Framework.Core.Commands
{
    public class CreateTeacherCommand : ICommand
    {
        private readonly IIdProvider idProvider;
        private readonly ITeacherFactory teacherFactory;

        public CreateTeacherCommand(IIdProvider idProvider, ITeacherFactory teacherFactory)
        {
            if (idProvider == null)
            {
                throw new ArgumentNullException(nameof(idProvider));
            }

            if (teacherFactory == null)
            {
                throw new ArgumentNullException(nameof(teacherFactory));
            }

            this.idProvider = idProvider;
            this.teacherFactory = teacherFactory;
        }

        public string Execute(IList<string> parameters, ISchoolSystemData data)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var subject = (Subject)int.Parse(parameters[2]);

            var teacher = this.teacherFactory.GetTeacher(firstName, lastName, subject);
            var teacherId = this.idProvider.GetNext();

            data.Teachers.Add(teacherId, teacher);

            return
                $"A new teacher with name {firstName} {lastName}, subject {subject} and ID {teacherId} was created.";
        }
    }
}
