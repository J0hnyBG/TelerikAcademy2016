namespace SchoolSystem.Tests.Models
{
    using System;
    using System.Collections;

    using Moq;

    using NUnit.Framework;

    using SchoolSystem.Contracts;
    using SchoolSystem.Models;

    [TestFixture]
    public class StudentTests
    {
        private const string InvalidNameShort = "P";
        private const string InvalidNameLong = "PpppppppppPpppppppppPppppppppppQ";
        private const string InvalidNameNonLetter = "11111111111111111112";

        private const string ValidName = "Petar";
        public void Ctor_ShouldReturnCorrectStudentObject_WhenValidArgsArePassed()
        {
            var expectedGrade = Grade.First;

            var student = new Student(ValidName, ValidName, expectedGrade);

            Assert.AreEqual(ValidName, student.FirstName);
            Assert.AreEqual(ValidName, student.LastName);
            Assert.AreEqual(expectedGrade, student.Grade);
            Assert.AreEqual(0, student.Marks.Count);
        }

        [TestCase(InvalidNameLong)]
        [TestCase(InvalidNameShort)]
        public void Ctor_WhenInvalidFirstNameIsPassed_ShouldThrowArgumentException(string invalidName)
        {
            var expectedLastName = "Petrov";
            var expectedGrade = Grade.First;

            var ex = Assert.Throws<ArgumentException>(() => new Student(invalidName, expectedLastName, expectedGrade));
            StringAssert.Contains("must be between", ex.Message);
        }

        [TestCase(InvalidNameLong)]
        [TestCase(InvalidNameShort)]
        public void Ctor_WhenInvalidLastNameIsPassed_ShouldThrowArgumentException(string invalidName)
        {
            var firstName = "petar";
            var grade = Grade.First;

            var ex = Assert.Throws<ArgumentException>(() => new Student(firstName, invalidName, grade));
            StringAssert.Contains("must be between", ex.Message);
        }

        [Test]
        public void Ctor_WhenInvalidNonLetterFirstNameIsPassed_ShouldThrowArgumentException()
        {
            var invalidFirstName = InvalidNameNonLetter;
            var expectedLastName = "Petrov";
            var expectedGrade = Grade.First;

            var ex = Assert.Throws<ArgumentException>(() => new Student(invalidFirstName, expectedLastName, expectedGrade));
            StringAssert.Contains("contains invalid characters", ex.Message);
        }

        [Test]
        public void Ctor_WhenInvalidNonLetterLastNameIsPassed_ShouldThrowArgumentException()
        {
            var validFirstName = "Pesho";
            var invalidLastName = InvalidNameNonLetter;
            var expectedGrade = Grade.First;

            var ex = Assert.Throws<ArgumentException>(() => new Student(validFirstName, invalidLastName, expectedGrade));
            StringAssert.Contains("contains invalid characters", ex.Message);
        }

        [Test]
        public void AddMark_WhenValidMark_ShouldAddMarkCorrectly()
        {
            var student = new Student(ValidName, ValidName, Grade.Eighth);
            var markMock = new Mock<IMark>();
            markMock.Setup(x => x.Subject).Returns(() => Subject.Programming);
            markMock.Setup(x => x.Value).Returns(() => 3f);

            student.AddMark(markMock.Object);

            Assert.Contains(markMock.Object, (ICollection)student.Marks);
        }

        [Test]
        public void ListMarks_WhenNoMarks_ShouldReturnCorrectMessage()
        {
            var student = new Student(ValidName, ValidName, Grade.Eighth);

            var result = student.ListMarks();

            Assert.AreEqual("This student has no marks.", result);
        }

        [Test]
        public void ListMarks_WhenStudentHasMarks_ShouldReturnCorrectMessage()
        {
            var student = new Student(ValidName, ValidName, Grade.Eighth);
            var markMock = new Mock<IMark>();
            markMock.Setup(x => x.Subject).Returns(() => Subject.Programming);
            markMock.Setup(x => x.Value).Returns(() => 3f);
            student.AddMark(markMock.Object);
            var expected = "The student has these marks:\nProgramming => 3";

            var result = student.ListMarks();

            Assert.AreEqual(expected, result);
        }
    }
}
