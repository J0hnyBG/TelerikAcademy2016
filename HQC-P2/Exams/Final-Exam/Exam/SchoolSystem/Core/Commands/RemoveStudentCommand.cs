namespace SchoolSystem.Core.Commands
{
    using System.Collections.Generic;

    using Contracts;

    /// <summary>
    /// Provides an implementation of the ICommand interface used for removing students.
    /// </summary>
    internal class RemoveStudentCommand : ICommand
    {
        /// <summary>
        /// Executes the RemoveStudentCommand and returns the result.
        /// </summary>
        /// <param name="parameters">The student ID.</param>
        /// <returns>A string describing the result of the operation.</returns>
        public string Execute(IList<string> parameters)
        {
            var studentId = int.Parse(parameters[0]);

            if (SchoolSystemEngine.RemoveStudent(studentId))
            {
                return $"Student with ID {studentId} was sucessfully removed.";
            }
            else
            {
                return $"Student with ID {studentId} was not found.";
            }
        }
    }
}