namespace Methods
{
    using System;

    public class Student
    {
        /// <summary>
        /// Gets or sets the First name of the student instance.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the Last name of the student instance.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets additional information about the student instance.
        /// </summary>
        public string OtherInfo { get; set; }

        /// <summary>
        /// Compares the date of birth of this Student instance with another Student instance.
        /// </summary>
        /// <param name="other">A Student to be compared against.</param>
        /// <returns>True if this instance's date of birth precedes the other ones, false otherwise.</returns>
        public bool IsOlderThan(Student other)
        {
            var firstDateAsString = this.ExtractDateOfBirthStringFromOtherInfo(this);
            var firstDate = DateTime.Parse(firstDateAsString);

            var secondDateAsString = this.ExtractDateOfBirthStringFromOtherInfo(other);
            var secondDate = DateTime.Parse(secondDateAsString);

            return firstDate < secondDate;
        }

        /// <summary>
        /// Extracts date of birth of a given student from the OtherInfo property.
        /// </summary>
        /// <param name="student">The Student object.</param>
        /// <returns>A date string.</returns>
        private string ExtractDateOfBirthStringFromOtherInfo(Student student)
        {
            var dateAsString = student.OtherInfo.Substring(student.OtherInfo.Length - 10);

            return dateAsString;
        }
    }
}
