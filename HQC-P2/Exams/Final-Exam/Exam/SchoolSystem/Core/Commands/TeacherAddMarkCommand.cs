namespace SchoolSystem.Core.Commands
{
    using System.Collections.Generic;

    using Contracts;

    /// <summary>
    /// Provides an implementation of the ICommand interface used for adding a mark to a student.
    /// </summary>
    internal class TeacherAddMarkCommand : ICommand
    {
        /// <summary>
        /// Executes the TeacherAddMarkCommand and returns the result.
        /// </summary>
        /// <param name="parameters">The student ID, teacher ID and the mark to be added.</param>
        /// <returns>A string describing the result of the operation.</returns>
        public string Execute(IList<string> parameters)
        {
            var teacherId = int.Parse(parameters[0]);
            var studentId = int.Parse(parameters[1]);

            var student = SchoolSystemEngine.Students[studentId];
            var teacher = SchoolSystemEngine.Teachers[teacherId];

            var mark = float.Parse(parameters[2]);
            teacher.AddMark(student, mark);

            return
                $"Teacher {teacher.FirstName} {teacher.LastName} added mark {mark} to student {student.FirstName} {student.LastName} in {teacher.Subject}.";
        }
    }
}