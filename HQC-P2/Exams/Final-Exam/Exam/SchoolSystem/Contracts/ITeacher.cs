namespace SchoolSystem.Contracts
{
    using Models;

    /// <summary>
    /// Provides an interface for the Teacher data-model.
    /// </summary>
    internal interface ITeacher : IPerson
    {
        /// <summary>
        /// Gets the teacher's teaching subject.
        /// </summary>
        Subject Subject { get; }

        /// <summary>
        /// Adds a new mark to a student.
        /// </summary>
        /// <param name="student">The student to add the mark to.</param>
        /// <param name="value">The value of the mark.</param>
        void AddMark(IStudent student, float value);
    }
}
