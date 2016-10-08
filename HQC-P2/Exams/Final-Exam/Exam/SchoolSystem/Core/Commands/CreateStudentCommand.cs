namespace SchoolSystem.Core.Commands
{
    using System.Collections.Generic;

    using Contracts;

    using Models;

    /// <summary>
    /// Provides an implementation of the ICommand interface used for creating new students.
    /// </summary>
    internal class CreateStudentCommand : ICommand
    {
        private static int id;

        /// <summary>
        /// Executes the CreateStudentCommand and returns the result.
        /// </summary>
        /// <param name="parameters">The Student parameters.</param>
        /// <returns>A string describing the new student.</returns>
        public string Execute(IList<string> parameters)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var grade = (Grade)int.Parse(parameters[2]);

            var studentToAdd = new Student(firstName, lastName, grade);

            SchoolSystemEngine.AddStudent(id, studentToAdd);

            return $"A new student with name {studentToAdd.FirstName} {studentToAdd.LastName}, grade {studentToAdd.Grade} and ID {id++} was created.";
        }
    }
}
