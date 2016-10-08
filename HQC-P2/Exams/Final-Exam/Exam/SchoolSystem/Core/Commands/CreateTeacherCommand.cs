namespace SchoolSystem.Core.Commands
{
    using System.Collections.Generic;

    using Contracts;

    using Models;

    /// <summary>
    /// Provides an implementation of the ICommand interface used for creating new teachers.
    /// </summary>
    internal class CreateTeacherCommand : ICommand
    {
        private static int id;

        /// <summary>
        /// Executes the CreateTeacherCommand and returns the result.
        /// </summary>
        /// <param name="parameters">The Teacher parameters.</param>
        /// <returns>A string describing the new teacher.</returns>
        public string Execute(IList<string> parameters)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var subject = (Subject)int.Parse(parameters[2]);

            var teacherToAdd = new Teacher(firstName, lastName, subject);

            SchoolSystemEngine.AddTeacher(id, teacherToAdd);

            return $"A new teacher with name {teacherToAdd.FirstName} {teacherToAdd.LastName}, subject {teacherToAdd.Subject} and ID {id++} was created.";
        }
    }
}