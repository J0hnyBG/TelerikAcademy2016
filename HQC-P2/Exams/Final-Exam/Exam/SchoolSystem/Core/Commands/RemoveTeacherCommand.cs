namespace SchoolSystem.Core.Commands
{
    using System.Collections.Generic;

    using Contracts;

    /// <summary>
    /// Provides an implementation of the ICommand interface used for removing teachers.
    /// </summary>
    internal class RemoveTeacherCommand : ICommand
    {
        /// <summary>
        /// Executes the RemoveTeacherCommand and returns the result.
        /// </summary>
        /// <param name="parameters">The teacher ID.</param>
        /// <returns>A string describing the result of the operation.</returns>
        public string Execute(IList<string> parameters)
        {
            var teacherId = int.Parse(parameters[0]);
            if (SchoolSystemEngine.RemoveTeacher(teacherId))
            {
                return $"Teacher with ID {teacherId} was sucessfully removed.";
            }
            else
            {
                return $"Teacher with ID {teacherId} was not found.";
            }
        }
    }
}