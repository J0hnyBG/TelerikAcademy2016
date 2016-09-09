using System.Collections.Generic;
using IntergalacticTravel.Contracts;
using Moq;
using NUnit.Framework;

namespace IntergalacticTravel.Tests
{
    [TestFixture]
    public class BusinessOwnerTests
    {
        [Test]
        public void CollectProfits_ShouldReturnTheSumOfProfitsInOwnersTeleportStations()
        {
            const int expectedBronzeCoins = 2;
            const int expectedSilverCoins = 4;
            const int expectedGoldCoins = 6;
            const int halfOfExpectedBronzeCoins = expectedBronzeCoins/2;
            const int halfOfExpectedSilverCoins = expectedSilverCoins / 2;
            const int halfOfExpectedGoldCoins = expectedGoldCoins / 2;

            var mockedTeleportStation = new Mock<ITeleportStation>();
            var mockedTeleportStationTwo = new Mock<ITeleportStation>();

            var mockedResources = new Mock<IResources>();
            mockedResources.Setup(x => x.BronzeCoins).Returns(halfOfExpectedBronzeCoins);
            mockedResources.Setup(x => x.SilverCoins).Returns(halfOfExpectedSilverCoins);
            mockedResources.Setup(x => x.GoldCoins).Returns(halfOfExpectedGoldCoins);

            var listOfTeleportStations = new List<ITeleportStation>()
            {
                mockedTeleportStation.Object,
                mockedTeleportStationTwo.Object
            };
            var businessOwner = new BusinessOwner(1, "Petar", listOfTeleportStations);

            mockedTeleportStation.Setup(x => x.PayProfits(businessOwner)).Returns(mockedResources.Object);
            mockedTeleportStationTwo.Setup(x => x.PayProfits(businessOwner)).Returns(mockedResources.Object);

            businessOwner.CollectProfits();

            Assert.AreEqual(expectedBronzeCoins, businessOwner.Resources.BronzeCoins);
            Assert.AreEqual(expectedSilverCoins, businessOwner.Resources.SilverCoins);
            Assert.AreEqual(expectedGoldCoins, businessOwner.Resources.GoldCoins);
        }
    }
}
