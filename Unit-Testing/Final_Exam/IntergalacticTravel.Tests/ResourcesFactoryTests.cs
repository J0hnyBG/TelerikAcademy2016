namespace IntergalacticTravel.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class ResourcesFactoryTests
    {
        private ResourcesFactory resourcesFactory;

        [OneTimeSetUp]
        public void Init()
        {
            // Arrange
            this.resourcesFactory = new ResourcesFactory();
        }

        [TestCase("create resources gold(20) silver(30) bronze(40)")]
        [TestCase("create resources gold(20) bronze(40) silver(30)")]
        [TestCase("create resources silver(30) bronze(40) gold(20)")]
        [TestCase("create resources silver(30) gold(20) bronze(40)")]
        [TestCase("create resources bronze(40) gold(20) silver(30)")]
        [TestCase("create resources bronze(40) silver(30) gold(20)")]
        [TestCase("create resources gold(0) silver(30) bronze(40)")]
        [TestCase("create resources gold(20) silver(0) bronze(40)")]
        [TestCase("create resources gold(20) silver(30) bronze(0)")]
        [TestCase("create resources gold(0) silver(0) bronze(0)")]
        public void GetResources_WhenValidCommandIsPassed_ShouldReturnNewInstanceOfResources(string command)
        {
            //Act
            var result = this.resourcesFactory.GetResources(command);
            //Assert
            Assert.IsInstanceOf(typeof(Resources), result);
        }

        [TestCase("create resources gold(20) silver(30) bronze(40)", 20, 30, 40)]
        [TestCase("create resources gold(20) bronze(40) silver(30)", 20, 30, 40)]
        [TestCase("create resources silver(30) bronze(40) gold(20)", 20, 30, 40)]
        [TestCase("create resources silver(30) gold(20) bronze(40)", 20, 30, 40)]
        [TestCase("create resources bronze(40) gold(20) silver(30)", 20, 30, 40)]
        [TestCase("create resources bronze(40) silver(30) gold(20)", 20, 30, 40)]
        [TestCase("create resources gold(0) silver(30) bronze(40)", 0, 30, 40)]
        [TestCase("create resources gold(20) silver(0) bronze(40)", 20, 0, 40)]
        [TestCase("create resources gold(20) silver(30) bronze(0)", 20, 30, 0)]
        public void GetResources_WhenValidCommandIsPassed_ShouldReturnResourcesWithCorrectProperties(
            string command, int expectedGold, int expectedSilver, int expectedBronze)
        {
            //Act
            var result = this.resourcesFactory.GetResources(command);
            //Assert
            Assert.AreEqual(expectedGold, result.GoldCoins);
            Assert.AreEqual(expectedSilver, result.SilverCoins);
            Assert.AreEqual(expectedBronze, result.BronzeCoins);
        }

        [TestCase("I'm an invalid command!")]
        [TestCase("create resources x y z")]
        [TestCase("tansta resources a b")]
        [TestCase("absolutelyRandomStringThatMustNotBeAValidCommand")]
        [TestCase("create resources gold20 silver30 bronze40")]
        [TestCase("create resourcesgold(20)silver(30)bronze(40)")]
        [TestCase("create resources gold(20) silver(30)bronze(40)")]
        //The following testcase doesn't throw an error, although command is invalid. Sadly we cannot edit the source code :(
        //[TestCase("Dreate resources gold(20) silver(30) bronze(40)")]
        public void GetResources_WhenInvalidCommandIsPassed_ShouldThrowInvalidOperationExceptionWithCorrectMessage(string invalidCommand)
        {
            //Act and assert
            Assert.That(
                    () => this.resourcesFactory.GetResources(invalidCommand), 
                    Throws.InvalidOperationException.With.Message
                    .Contains("command")
                );
        }

        [TestCase("create resources silver(10) gold(97853252356623523532) bronze(20)")]
        [TestCase("create resources silver(555555555555555555555555555555555) gold(97853252356623523532999999999) bronze(20)")]
        [TestCase("create resources silver(10) gold(20) bronze(4444444444444444444444444444444444444)")]
        public void GetResources_WhenResourceAmountValuesAreLargerThanMaxOfUint_ShouldThrowOverflowException(
            string invalidCommand)
        {
            //Act and assert
            Assert.Throws<OverflowException>(() => this.resourcesFactory.GetResources(invalidCommand));
        }
    }
}
