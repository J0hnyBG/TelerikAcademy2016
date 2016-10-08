namespace SchoolSystem.Contracts
{
    using System.Collections.Generic;

    using Models;

    /// <summary>
    /// Specifies an interface for a Student data model.
    /// </summary>
    internal interface IStudent : IPerson
    {
        /// <summary>
        /// Gets the student's current grade.
        /// </summary>
        Grade Grade { get; }

        /// <summary>
        /// Gets the student's marks.
        /// </summary>
        IList<IMark> Marks { get; }

        /// <summary>
        /// Lists a formatted version of a student's marks.
        /// </summary>
        string ListMarks();

        /// <summary>
        /// Adds a mark to the student's marks.
        /// </summary>
        void AddMark(IMark mark);
    }
}
