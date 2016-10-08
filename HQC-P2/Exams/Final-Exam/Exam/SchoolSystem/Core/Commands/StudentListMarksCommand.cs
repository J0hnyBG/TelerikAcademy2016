namespace SchoolSystem.Core.Commands
{
    using System.Collections.Generic;

    using Contracts;

    /// <summary>
    /// Provides an implementation of the ICommand interface used for listing student Marks.
    /// </summary>
    internal class StudentListMarksCommand : ICommand
    {
        /// <summary>
        /// Executes the StudentListMarksCommand and returns the result.
        /// </summary>
        /// <param name="parameters">The student ID.</param>
        /// <returns>A string describing the result of the operation.</returns>
        public string Execute(IList<string> parameters)
        {
            var studentId = int.Parse(parameters[0]);
            return SchoolSystemEngine.Students[studentId].ListMarks();
        }
    }
}