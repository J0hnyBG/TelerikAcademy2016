using IntergalacticTravel.Contracts;
using Moq;

namespace IntergalacticTravel.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class UnitTests
    {
        [Test]
        public void Pay_WhenParamIsNull_ShouldThrowNullReferenceException()
        {
            //Arrange
            var unit = new Unit(1, "Pesho");
            //Act and assert
            Assert.Throws<NullReferenceException>(() => unit.Pay(null));
        }

        [Test]
        public void Pay_WhenParamIsValid_ShouldDecreaseUnitsResourcesByCorrectAmount()
        {
            //Arrange
            var unit = new Unit(1, "Pesho");
            var mockedResource = new Mock<IResources>();
            mockedResource.SetupGet(x => x.GoldCoins).Returns(1);
            mockedResource.SetupGet(x => x.SilverCoins).Returns(1);
            mockedResource.SetupGet(x => x.BronzeCoins).Returns(1);

            var privateUnit = new Microsoft.VisualStudio.TestTools.UnitTesting.PrivateObject(unit);

            var resources = privateUnit.GetFieldOrProperty("resources") as IResources;
            resources.BronzeCoins = 10;
            resources.SilverCoins = 10;
            resources.GoldCoins = 10;

            //Act
            unit.Pay(mockedResource.Object);
            //Assert
            Assert.AreEqual(9, resources.GoldCoins);
            Assert.AreEqual(9, resources.SilverCoins);
            Assert.AreEqual(9, resources.BronzeCoins);
        }

        [Test]
        public void Pay_WhenParamIsNull_ShouldReturnCorrectResourceObject()
        {
            //Arrange
            var unit = new Unit(1, "Pesho");
            var mockedResource = new Mock<IResources>();
            mockedResource.SetupGet(x => x.GoldCoins).Returns(10);
            mockedResource.SetupGet(x => x.SilverCoins).Returns(100);
            mockedResource.SetupGet(x => x.BronzeCoins).Returns(1);
            //Act
            var result = unit.Pay(mockedResource.Object);
            //Assert
            Assert.AreEqual(mockedResource.Object.SilverCoins, result.SilverCoins);
            Assert.AreEqual(mockedResource.Object.GoldCoins, result.GoldCoins);
            Assert.AreEqual(mockedResource.Object.BronzeCoins, result.BronzeCoins);
        }
    }
}
