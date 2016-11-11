using System.Collections.Generic;

using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Core.Repositories;

namespace SchoolSystem.Framework.Core.Commands
{
    public class StudentListMarksCommand : ICommand
    {
        public string Execute(IList<string> parameters, ISchoolSystemData data)
        {
            var studentId = int.Parse(parameters[0]);
            var student = data.Students.GetById(studentId);
            return student.ListMarks();
        }
    }
}
