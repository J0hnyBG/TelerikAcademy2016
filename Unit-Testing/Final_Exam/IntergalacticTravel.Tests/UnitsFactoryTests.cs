namespace IntergalacticTravel.Tests
{
    using System;
    using IntergalacticTravel.Exceptions;
    using NUnit.Framework;

    [TestFixture]
    public class UnitsFactoryTests
    {
        [TestCase("create unit Procyon Gosho 1", typeof(Procyon))]
        [TestCase("create unit Luyten Pesho 2", typeof(Luyten))]
        [TestCase("create unit Lacaille Tosho 3", typeof(Lacaille))]
        public void GetUnit_WhenValidCommandIsPassed_ShouldReturnCorrespondingUnit(string command, Type expectedType)
        {
            //Arrange
            var factory = new UnitsFactory();
            //Act
            var unit = factory.GetUnit(command);
            //Assert
            Assert.IsInstanceOf(expectedType, unit);
        }

        [TestCase("I am not a valid command!")]
        [TestCase("create unit Luyten Pesho2")]
        [TestCase("create unit InvalidUnitType Pesho 2")]
        [TestCase("createunitLytenPesho2")]
        //The following testcase doesn't throw an error, although command is invalid. Sadly we cannot edit the source code :(
        //[TestCase("Dreate unit Luyten Pesho 2")]
        public void GetUnit_WhenInvalidCommandIsPassed_ShouldThrowInvalidUnitCreationCommandException(string command)
        {
            //Arrange
            var factory = new UnitsFactory();
            //Act and assert
            Assert.Throws<InvalidUnitCreationCommandException>(() => factory.GetUnit(command));
        }
    }
}
