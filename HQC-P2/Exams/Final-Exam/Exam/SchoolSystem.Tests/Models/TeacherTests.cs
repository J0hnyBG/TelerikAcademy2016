namespace SchoolSystem.Tests.Models
{
    using System;

    using Moq;

    using NUnit.Framework;

    using SchoolSystem.Contracts;
    using SchoolSystem.Models;

    [TestFixture]
    public class TeacherTests
    {
        private const string InvalidNameShort = "P";
        private const string InvalidNameLong = "PpppppppppPpppppppppPppppppppppQ";
        private const string InvalidNameNonLetter = "11111111111111111112";

        private const string ValidName = "Petar";

        [Test]
        public void Ctor_ShouldReturnCorrectTeacherObject_WhenValidValuesArePassed()
        {
            var expectedSubject = Subject.Programming;

            var teacher = new Teacher(ValidName, ValidName, expectedSubject);

            Assert.AreEqual(ValidName, teacher.FirstName);
            Assert.AreEqual(ValidName, teacher.LastName);
            Assert.AreEqual(expectedSubject, teacher.Subject);
        }


        [TestCase(InvalidNameLong)]
        [TestCase(InvalidNameShort)]
        public void Ctor_WhenInvalidFirstNameIsPassed_ShouldThrowArgumentException(string invalidName)
        {
            var expectedLastName = "Petrov";
            var expectedSubject = Subject.Bulgarian;

            var ex = Assert.Throws<ArgumentException>(() => new Teacher(invalidName, expectedLastName, expectedSubject));
            StringAssert.Contains("must be between", ex.Message);
        }

        [TestCase(InvalidNameLong)]
        [TestCase(InvalidNameShort)]
        public void Ctor_WhenInvalidLastNameIsPassed_ShouldThrowArgumentException(string invalidName)
        {
            var firstName = "petar";
            var expectedSubject = Subject.Bulgarian;

            var ex = Assert.Throws<ArgumentException>(() => new Teacher(firstName, invalidName, expectedSubject));
            StringAssert.Contains("must be between", ex.Message);
        }

        [Test]
        public void Ctor_WhenInvalidNonLetterFirstNameIsPassed_ShouldThrowArgumentException()
        {
            var invalidFirstName = InvalidNameNonLetter;
            var expectedLastName = "Petrov";
            var expectedSubject = Subject.Bulgarian;

            var ex = Assert.Throws<ArgumentException>(() => new Teacher(invalidFirstName, expectedLastName, expectedSubject));
            StringAssert.Contains("contains invalid characters", ex.Message);
        }

        [Test]
        public void Ctor_WhenInvalidNonLetterLastNameIsPassed_ShouldThrowArgumentException()
        {
            var validFirstName = "Pesho";
            var invalidLastName = InvalidNameNonLetter;
            var expectedSubject = Subject.Bulgarian;

            var ex = Assert.Throws<ArgumentException>(() => new Teacher(validFirstName, invalidLastName, expectedSubject));
            StringAssert.Contains("contains invalid characters", ex.Message);
        }

        [Test]
        public void AddMark_ShouldCallAddMarkStudentMethodExactlyOnce()
        {
            var mockedStudent = new Mock<IStudent>();
            
            var teacher = new Teacher(ValidName, ValidName, Subject.English);

            teacher.AddMark(mockedStudent.Object, 2);

            mockedStudent.Verify(x => x.AddMark(It.IsAny<IMark>()), Times.Once());
        }
    }
}
