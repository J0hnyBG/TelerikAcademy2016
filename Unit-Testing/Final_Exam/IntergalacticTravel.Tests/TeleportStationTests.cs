using IntergalacticTravel.Exceptions;

namespace IntergalacticTravel.Tests
{
    using System.Collections.Generic;

    using IntergalacticTravel.Contracts;
    using IntergalacticTravel.Tests.MockedClasses;

    using NUnit.Framework;
    using Moq;

    [TestFixture]
    public class TeleportStationTests
    {
        [Test]
        public void Constructor_WhenValidParamsArePassed_ShouldSetUpAllFieldsCorrectly()
        {
            //Arrange
            var mockedBusinessOwner = new Mock<IBusinessOwner>();
            var mockedLocation = new Mock<ILocation>();
            var mockedGalacticMap = new List<IPath>();
            //Act
            var result = new MockedTeleportStation(mockedBusinessOwner.Object, mockedGalacticMap, mockedLocation.Object);
            //Assert
            Assert.AreSame(mockedBusinessOwner.Object, result.Owner);
            Assert.AreSame(mockedLocation.Object, result.Location);
            Assert.AreSame(mockedGalacticMap, result.GalacticMap);
            Assert.IsInstanceOf(typeof(IResources), result.Resources);
        }

        [Test]
        public void TeleportUnit_WhenUnitToTeleportIsNull_ShouldThrowArgumentNullExceptionWithCorrectMessage()
        {
            //Arrange
            var mockedBusinessOwner = new Mock<IBusinessOwner>();
            var mockedLocation = new Mock<ILocation>();
            var mockedGalacticMap = new List<IPath>();
            //Act
            var teleportStation = new TeleportStation(mockedBusinessOwner.Object, mockedGalacticMap, mockedLocation.Object);
            //Assert
            Assert.That(
                    () => teleportStation.TeleportUnit(null, mockedLocation.Object), 
                    Throws.ArgumentNullException.With.Message
                    .Contains("unitToTeleport")
                );
        }

        [Test]
        public void TeleportUnit_WhenLocationToTeleportIsNull_ShouldThrowArgumentNullExceptionWithCorrectMessage()
        {
            //Arrange
            var mockedBusinessOwner = new Mock<IBusinessOwner>();
            var mockedLocation = new Mock<ILocation>();
            var mockedUnit = new Mock<IUnit>();
            var mockedGalacticMap = new List<IPath>();
            //Act
            var teleportStation = new TeleportStation(mockedBusinessOwner.Object, mockedGalacticMap, mockedLocation.Object);
            //Assert
            Assert.That(
                    () => teleportStation.TeleportUnit(mockedUnit.Object, null),
                    Throws.ArgumentNullException.With.Message
                    .Contains("destination")
                );
        }

        [Test]
        public void TeleportUnit_WhenLocationOfUnitDoesNotMatchStationLocation_ShouldThrowTeleportOutOfRangeExceptionWithCorrectMessage()
        {
            //Arrange
            var mockedBusinessOwner = new Mock<IBusinessOwner>();

            var mockedLocation = new Mock<ILocation>();
            var mockedGalaxy = new Mock<IGalaxy>();
            mockedGalaxy.SetupGet(x => x.Name).Returns("Andromeda");
            mockedLocation.SetupGet(x => x.Planet.Galaxy).Returns(mockedGalaxy.Object);
            mockedLocation.SetupGet(x => x.Planet.Name).Returns("SG306");

            var mockedUnitGalaxy = new Mock<IGalaxy>();
            mockedUnitGalaxy.SetupGet(x => x.Name).Returns("Milky Way");
            var mockedUnitLocation = new Mock<ILocation>();
            mockedUnitLocation.SetupGet(x => x.Planet.Name).Returns("Earth");
            mockedUnitLocation.SetupGet(x => x.Planet.Galaxy).Returns(mockedUnitGalaxy.Object);
            var mockedUnit = new Mock<IUnit>();
            mockedUnit.Setup(x => x.CurrentLocation).Returns(mockedUnitLocation.Object);

            var mockedGalacticMap = new List<IPath>();
            var teleportStation = new TeleportStation(mockedBusinessOwner.Object, mockedGalacticMap, mockedLocation.Object);
            //Act and Assert
            var ex = Assert.Throws<TeleportOutOfRangeException>(() => teleportStation.TeleportUnit(mockedUnit.Object, mockedUnitLocation.Object));
            StringAssert.Contains("unitToTeleport.CurrentLocation", ex.Message);
        }

        [Test]
        public void TeleportUnit_WhenTeleportingToAlreadyTakenLocation_ShouldThrowInvalidTeleportationLocationExceptionWithCorrectMessage()
        {
            //Arrange
            var mockedBusinessOwner = new Mock<IBusinessOwner>();

            var mockedLocation = new Mock<ILocation>();
            var mockedGalaxy = new Mock<IGalaxy>();
            mockedGalaxy.SetupGet(x => x.Name).Returns("Milky Way");
            mockedLocation.SetupGet(x => x.Planet.Galaxy).Returns(mockedGalaxy.Object);
            mockedLocation.SetupGet(x => x.Planet.Name).Returns("Earth");
            mockedLocation.SetupGet(x => x.Coordinates.Latitude).Returns(1);
            mockedLocation.SetupGet(x => x.Coordinates.Longtitude).Returns(1);
            var mockedUnitTwo = new Mock<IUnit>();
            mockedUnitTwo.SetupGet(x => x.CurrentLocation).Returns(mockedLocation.Object);

            var mockedUnitGalaxy = new Mock<IGalaxy>();
            mockedUnitGalaxy.SetupGet(x => x.Name).Returns("Milky Way");
            var mockedLocationToTeleportTo = new Mock<ILocation>();
            mockedLocationToTeleportTo.SetupGet(x => x.Planet.Name).Returns("Earth");
            mockedLocationToTeleportTo.SetupGet(x => x.Coordinates.Latitude).Returns(1);
            mockedLocationToTeleportTo.SetupGet(x => x.Coordinates.Longtitude).Returns(1);

            mockedLocationToTeleportTo.SetupGet(x => x.Planet.Galaxy).Returns(mockedUnitGalaxy.Object);
            var mockedUnit = new Mock<IUnit>();
            mockedUnit.Setup(x => x.CurrentLocation).Returns(mockedLocationToTeleportTo.Object);

            var mockedGalacticMap = new List<IPath>();
            var mockedPath = new Mock<IPath>();
            mockedPath.SetupGet(x => x.TargetLocation).Returns(mockedLocationToTeleportTo.Object);
            mockedPath.SetupGet(x => x.TargetLocation.Planet.Units).Returns(new List<IUnit>() {mockedUnit.Object});
            mockedPath.SetupGet(x => x.TargetLocation.Planet.Galaxy.Name).Returns("Milky Way");
            mockedPath.SetupGet(x => x.TargetLocation.Planet.Name).Returns("Earth");
            var mockedResource = new Mock<IResources>();
            mockedPath.SetupGet(x => x.Cost).Returns(mockedResource.Object);

            mockedGalacticMap.Add(mockedPath.Object);
            var teleportStation = new TeleportStation(mockedBusinessOwner.Object, mockedGalacticMap, mockedLocation.Object);
            //Act and Assert
            var ex = Assert.Throws<InvalidTeleportationLocationException>(() => teleportStation.TeleportUnit(mockedUnitTwo.Object, mockedLocationToTeleportTo.Object));
            StringAssert.Contains("units will overlap", ex.Message);
        }

        [Test]
        public void TeleportUnit_WhenTeleportingToGalaxyThatDoesntExistInTeleportStation_ShouldThrowLocationNotFoundExceptionWithCorrectMessage()
        {
            //Arrange
            var mockedBusinessOwner = new Mock<IBusinessOwner>();

            var mockedLocation = new Mock<ILocation>();
            var mockedGalaxy = new Mock<IGalaxy>();
            mockedGalaxy.SetupGet(x => x.Name).Returns("Milky Way");
            mockedLocation.SetupGet(x => x.Planet.Galaxy).Returns(mockedGalaxy.Object);
            mockedLocation.SetupGet(x => x.Planet.Name).Returns("Earth");
            var mockedUnit = new Mock<IUnit>();
            mockedUnit.SetupGet(x => x.CurrentLocation).Returns(mockedLocation.Object);

            var mockedUnitGalaxy = new Mock<IGalaxy>();
            mockedUnitGalaxy.SetupGet(x => x.Name).Returns("Milky Way");
            var mockedLocationToTeleportTo = new Mock<ILocation>();
            mockedLocationToTeleportTo.SetupGet(x => x.Planet.Name).Returns("Earth");

            mockedLocationToTeleportTo.SetupGet(x => x.Planet.Galaxy).Returns(mockedUnitGalaxy.Object);

            var mockedGalacticMap = new List<IPath>();
            var mockedPath = new Mock<IPath>();
            mockedPath.SetupGet(x => x.TargetLocation).Returns(mockedLocationToTeleportTo.Object);
            mockedPath.SetupGet(x => x.TargetLocation.Planet.Galaxy.Name).Returns("NoSuchGalaxy");
            mockedPath.SetupGet(x => x.TargetLocation.Planet.Name).Returns("Earth");

            mockedGalacticMap.Add(mockedPath.Object);
            var teleportStation = new TeleportStation(mockedBusinessOwner.Object, mockedGalacticMap, mockedLocation.Object);
            //Act and Assert
            var ex = Assert.Throws<LocationNotFoundException>(() => teleportStation.TeleportUnit(mockedUnit.Object, mockedLocationToTeleportTo.Object));
            StringAssert.Contains("Galaxy", ex.Message);
        }

        [Test]
        public void TeleportUnit_WhenTeleportingToPlanetThatDoesntExistInTeleportStation_ShouldThrowLocationNotFoundExceptionWithCorrectMessage()
        {
            //Arrange
            var mockedBusinessOwner = new Mock<IBusinessOwner>();

            var mockedLocation = new Mock<ILocation>();
            var mockedGalaxy = new Mock<IGalaxy>();
            mockedGalaxy.SetupGet(x => x.Name).Returns("Milky Way");
            mockedLocation.SetupGet(x => x.Planet.Galaxy).Returns(mockedGalaxy.Object);
            mockedLocation.SetupGet(x => x.Planet.Name).Returns("Earth");
            var mockedUnit = new Mock<IUnit>();
            mockedUnit.SetupGet(x => x.CurrentLocation).Returns(mockedLocation.Object);

            var mockedUnitGalaxy = new Mock<IGalaxy>();
            mockedUnitGalaxy.SetupGet(x => x.Name).Returns("Milky Way");
            var mockedLocationToTeleportTo = new Mock<ILocation>();
            mockedLocationToTeleportTo.SetupGet(x => x.Planet.Name).Returns("Earth");
            mockedLocationToTeleportTo.SetupGet(x => x.Planet.Galaxy).Returns(mockedUnitGalaxy.Object);
            var mockedGalacticMap = new List<IPath>();
            var mockedPath = new Mock<IPath>();
            mockedPath.SetupGet(x => x.TargetLocation).Returns(mockedLocationToTeleportTo.Object);
            mockedPath.SetupGet(x => x.TargetLocation.Planet.Galaxy.Name).Returns("Milky Way");
            mockedPath.SetupGet(x => x.TargetLocation.Planet.Name).Returns("NoSuchPlanet");

            mockedGalacticMap.Add(mockedPath.Object);
            var teleportStation = new TeleportStation(mockedBusinessOwner.Object, mockedGalacticMap, mockedLocation.Object);
            //Act and Assert
            var ex = Assert.Throws<LocationNotFoundException>(() => teleportStation.TeleportUnit(mockedUnit.Object, mockedLocationToTeleportTo.Object));
            StringAssert.Contains("Planet", ex.Message);
        }

        [Test]
        public void TeleportUnit_WhenUnitDoesntHaveEnoughResourcesToTeleport_ShouldThrowInsufficientResourcesExceptionWithCorrectMessage()
        {
            //Arrange
            var mockedBusinessOwner = new Mock<IBusinessOwner>();

            var mockedLocation = new Mock<ILocation>();
            var mockedGalaxy = new Mock<IGalaxy>();
            mockedGalaxy.SetupGet(x => x.Name).Returns("Milky Way");
            mockedLocation.SetupGet(x => x.Planet.Galaxy).Returns(mockedGalaxy.Object);
            mockedLocation.SetupGet(x => x.Planet.Name).Returns("Earth");
            var mockedUnit = new Mock<IUnit>();
            mockedUnit.SetupGet(x => x.CurrentLocation).Returns(mockedLocation.Object);


            var mockedUnitGalaxy = new Mock<IGalaxy>();
            mockedUnitGalaxy.SetupGet(x => x.Name).Returns("Milky Way");
            var mockedLocationToTeleportTo = new Mock<ILocation>();
            mockedLocationToTeleportTo.SetupGet(x => x.Planet.Name).Returns("Earth");
            mockedLocationToTeleportTo.SetupGet(x => x.Planet.Galaxy).Returns(mockedUnitGalaxy.Object);
            var mockedGalacticMap = new List<IPath>();
            var mockedPath = new Mock<IPath>();

            var mockedMoneyForUnit = new Mock<IResources>();
            mockedMoneyForUnit.SetupGet(x => x.BronzeCoins).Returns(1);
            mockedMoneyForUnit.SetupGet(x => x.GoldCoins).Returns(0);
            mockedMoneyForUnit.SetupGet(x => x.SilverCoins).Returns(0);
            mockedUnit.SetupGet(x => x.Resources).Returns(mockedMoneyForUnit.Object);
            var mockedCostToTravel = new Mock<IResources>();
            mockedCostToTravel.SetupGet(x => x.BronzeCoins).Returns(500000);
            mockedCostToTravel.SetupGet(x => x.GoldCoins).Returns(500000);
            mockedCostToTravel.SetupGet(x => x.SilverCoins).Returns(500000);
            mockedPath.SetupGet(x => x.Cost).Returns(mockedCostToTravel.Object);

            mockedPath.SetupGet(x => x.TargetLocation).Returns(mockedLocationToTeleportTo.Object);
            mockedPath.SetupGet(x => x.TargetLocation.Planet.Galaxy.Name).Returns("Milky Way");
            mockedPath.SetupGet(x => x.TargetLocation.Planet.Name).Returns("Earth");
            mockedPath.SetupGet(x => x.TargetLocation.Planet.Units).Returns(new List<IUnit>());
            mockedGalacticMap.Add(mockedPath.Object);
            var teleportStation = new TeleportStation(mockedBusinessOwner.Object, mockedGalacticMap, mockedLocation.Object);
            //Act and Assert
            var ex = Assert.Throws<InsufficientResourcesException>(() => teleportStation.TeleportUnit(mockedUnit.Object, mockedLocationToTeleportTo.Object));
            StringAssert.Contains("FREE LUNCH", ex.Message);
        }

        [Test]
        public void TeleportUnit_WhenEverythingIsValid_ShouldCallUnitsPayMethodOnce()
        {
            //Arrange
            var mockedBusinessOwner = new Mock<IBusinessOwner>();

            var mockedLocation = new Mock<ILocation>();
            var mockedGalaxy = new Mock<IGalaxy>();
            mockedGalaxy.SetupGet(x => x.Name).Returns("Milky Way");
            mockedLocation.SetupGet(x => x.Planet.Galaxy).Returns(mockedGalaxy.Object);
            mockedLocation.SetupGet(x => x.Planet.Name).Returns("Earth");
            var mockedUnit = new Mock<IUnit>();
            mockedUnit.SetupGet(x => x.CurrentLocation).Returns(mockedLocation.Object);

            var mockedUnitGalaxy = new Mock<IGalaxy>();
            mockedUnitGalaxy.SetupGet(x => x.Name).Returns("Milky Way");
            var mockedLocationToTeleportTo = new Mock<ILocation>();
            mockedLocationToTeleportTo.SetupGet(x => x.Planet.Name).Returns("Earth");
            mockedLocationToTeleportTo.SetupGet(x => x.Planet.Galaxy).Returns(mockedUnitGalaxy.Object);
            var mockedGalacticMap = new List<IPath>();
            var mockedPath = new Mock<IPath>();

            var mockedMoneyForUnit = new Mock<IResources>();
            mockedMoneyForUnit.SetupGet(x => x.BronzeCoins).Returns(100);
            mockedMoneyForUnit.SetupGet(x => x.GoldCoins).Returns(100);
            mockedMoneyForUnit.SetupGet(x => x.SilverCoins).Returns(100);
            mockedUnit.SetupGet(x => x.Resources).Returns(mockedMoneyForUnit.Object);

            mockedUnit.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(true);

            var mockedCostToTravel = new Mock<IResources>();
            mockedCostToTravel.SetupGet(x => x.BronzeCoins).Returns(1);
            mockedCostToTravel.SetupGet(x => x.GoldCoins).Returns(1);
            mockedCostToTravel.SetupGet(x => x.SilverCoins).Returns(1);
            mockedPath.SetupGet(x => x.Cost).Returns(mockedCostToTravel.Object);
            mockedUnit.Setup(x => x.Pay(It.IsAny<IResources>())).Returns(mockedCostToTravel.Object);

            mockedPath.SetupGet(x => x.TargetLocation).Returns(mockedLocationToTeleportTo.Object);
            mockedPath.SetupGet(x => x.TargetLocation.Planet.Galaxy.Name).Returns("Milky Way");
            mockedPath.SetupGet(x => x.TargetLocation.Planet.Name).Returns("Earth");
            mockedPath.SetupGet(x => x.TargetLocation.Planet.Units).Returns(new List<IUnit>());

            mockedLocation.Setup(x => x.Planet.Units).Returns(new List<IUnit>());
            mockedLocation.Setup(x => x.Planet.Units.Remove(It.IsAny<IUnit>()));
            mockedUnit.SetupGet(x => x.CurrentLocation).Returns(mockedLocation.Object);

            mockedGalacticMap.Add(mockedPath.Object);
            var teleportStation = new TeleportStation(mockedBusinessOwner.Object, mockedGalacticMap, mockedLocation.Object);
            //Act
            teleportStation.TeleportUnit(mockedUnit.Object, mockedLocationToTeleportTo.Object);
            //Assert
            mockedUnit.Verify(x => x.Pay(It.IsAny<IResources>()), Times.Once);
        }

        [Test]
        public void TeleportUnit_WhenEverythingIsValid_ShouldIncreaseTeleportStationResourcesByCostToTravel()
        {
            //Arrange
            var mockedBusinessOwner = new Mock<IBusinessOwner>();

            var mockedLocation = new Mock<ILocation>();
            var mockedGalaxy = new Mock<IGalaxy>();
            mockedGalaxy.SetupGet(x => x.Name).Returns("Milky Way");
            mockedLocation.SetupGet(x => x.Planet.Galaxy).Returns(mockedGalaxy.Object);
            mockedLocation.SetupGet(x => x.Planet.Name).Returns("Earth");
            var mockedUnit = new Mock<IUnit>();
            mockedUnit.SetupGet(x => x.CurrentLocation).Returns(mockedLocation.Object);

            var mockedUnitGalaxy = new Mock<IGalaxy>();
            mockedUnitGalaxy.SetupGet(x => x.Name).Returns("Milky Way");
            var mockedLocationToTeleportTo = new Mock<ILocation>();
            mockedLocationToTeleportTo.SetupGet(x => x.Planet.Name).Returns("Earth");
            mockedLocationToTeleportTo.SetupGet(x => x.Planet.Galaxy).Returns(mockedUnitGalaxy.Object);
            var mockedGalacticMap = new List<IPath>();
            var mockedPath = new Mock<IPath>();

            var mockedMoneyForUnit = new Mock<IResources>();
            mockedMoneyForUnit.SetupGet(x => x.BronzeCoins).Returns(100);
            mockedMoneyForUnit.SetupGet(x => x.GoldCoins).Returns(100);
            mockedMoneyForUnit.SetupGet(x => x.SilverCoins).Returns(100);
            mockedUnit.SetupGet(x => x.Resources).Returns(mockedMoneyForUnit.Object);

            mockedUnit.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(true);

            var mockedCostToTravel = new Mock<IResources>();
            mockedCostToTravel.SetupGet(x => x.BronzeCoins).Returns(1);
            mockedCostToTravel.SetupGet(x => x.GoldCoins).Returns(1);
            mockedCostToTravel.SetupGet(x => x.SilverCoins).Returns(1);
            mockedPath.SetupGet(x => x.Cost).Returns(mockedCostToTravel.Object);
            mockedUnit.Setup(x => x.Pay(It.IsAny<IResources>())).Returns(mockedCostToTravel.Object);

            mockedPath.SetupGet(x => x.TargetLocation).Returns(mockedLocationToTeleportTo.Object);
            mockedPath.SetupGet(x => x.TargetLocation.Planet.Galaxy.Name).Returns("Milky Way");
            mockedPath.SetupGet(x => x.TargetLocation.Planet.Name).Returns("Earth");
            mockedPath.SetupGet(x => x.TargetLocation.Planet.Units).Returns(new List<IUnit>());

            mockedLocation.Setup(x => x.Planet.Units).Returns(new List<IUnit>());
            mockedLocation.Setup(x => x.Planet.Units.Remove(It.IsAny<IUnit>()));
            mockedUnit.SetupGet(x => x.CurrentLocation).Returns(mockedLocation.Object);

            mockedGalacticMap.Add(mockedPath.Object);
            var teleportStation = new MockedTeleportStation(mockedBusinessOwner.Object, mockedGalacticMap, mockedLocation.Object);
            //Act
            teleportStation.TeleportUnit(mockedUnit.Object, mockedLocationToTeleportTo.Object);
            //Assert
            Assert.AreEqual(1, teleportStation.Resources.GoldCoins);
            Assert.AreEqual(1, teleportStation.Resources.BronzeCoins);
            Assert.AreEqual(1, teleportStation.Resources.SilverCoins);
        }
        [Test]
        public void TeleportUnit_WhenEverythingIsValid_ShouldSetUnitsPreviousLocationToCurrentLocation()
        {
            //Arrange
            var mockedBusinessOwner = new Mock<IBusinessOwner>();

            var mockedLocation = new Mock<ILocation>();
            var mockedGalaxy = new Mock<IGalaxy>();
            mockedGalaxy.SetupGet(x => x.Name).Returns("Milky Way");
            mockedLocation.SetupGet(x => x.Planet.Galaxy).Returns(mockedGalaxy.Object);
            mockedLocation.SetupGet(x => x.Planet.Name).Returns("Earth");
            var mockedUnit = new Mock<IUnit>();

            var mockedUnitGalaxy = new Mock<IGalaxy>();
            mockedUnitGalaxy.SetupGet(x => x.Name).Returns("Milky Way");
            var mockedLocationToTeleportTo = new Mock<ILocation>();
            mockedLocationToTeleportTo.SetupGet(x => x.Planet.Name).Returns("Earth");
            mockedLocationToTeleportTo.SetupGet(x => x.Planet.Galaxy).Returns(mockedUnitGalaxy.Object);
            var mockedGalacticMap = new List<IPath>();
            var mockedPath = new Mock<IPath>();

            var mockedMoneyForUnit = new Mock<IResources>();
            mockedUnit.SetupGet(x => x.Resources).Returns(mockedMoneyForUnit.Object);

            mockedUnit.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(true);

            var mockedCostToTravel = new Mock<IResources>();

            mockedPath.SetupGet(x => x.Cost).Returns(mockedCostToTravel.Object);
            mockedUnit.Setup(x => x.Pay(It.IsAny<IResources>())).Returns(mockedCostToTravel.Object);

            mockedPath.SetupGet(x => x.TargetLocation).Returns(mockedLocationToTeleportTo.Object);
            mockedPath.SetupGet(x => x.TargetLocation.Planet.Galaxy.Name).Returns("Milky Way");
            mockedPath.SetupGet(x => x.TargetLocation.Planet.Name).Returns("Earth");
            mockedPath.SetupGet(x => x.TargetLocation.Planet.Units).Returns(new List<IUnit>());

            mockedLocation.Setup(x => x.Planet.Units).Returns(new List<IUnit>());
            mockedLocation.Setup(x => x.Planet.Units.Remove(It.IsAny<IUnit>()));
            mockedUnit.SetupGet(x => x.CurrentLocation).Returns(mockedLocation.Object);
            mockedUnit.SetupSet(p => p.PreviousLocation = It.IsAny<ILocation>());

            mockedGalacticMap.Add(mockedPath.Object);
            var teleportStation = new TeleportStation(mockedBusinessOwner.Object, mockedGalacticMap, mockedLocation.Object);
            //Act
            teleportStation.TeleportUnit(mockedUnit.Object, mockedLocationToTeleportTo.Object);

            //Assert
            mockedUnit.VerifySet(x => x.PreviousLocation = mockedLocation.Object, Times.Once);
        }

        [Test]
        public void TeleportUnit_WhenEverythingIsValid_ShouldSetUnitsCurrentLocationToTargetLocation()
        {
            //Arrange
            var mockedBusinessOwner = new Mock<IBusinessOwner>();

            var mockedLocation = new Mock<ILocation>();
            var mockedGalaxy = new Mock<IGalaxy>();
            mockedGalaxy.SetupGet(x => x.Name).Returns("Milky Way");
            mockedLocation.SetupGet(x => x.Planet.Galaxy).Returns(mockedGalaxy.Object);
            mockedLocation.SetupGet(x => x.Planet.Name).Returns("Earth");
            var mockedUnit = new Mock<IUnit>();

            var mockedUnitGalaxy = new Mock<IGalaxy>();
            mockedUnitGalaxy.SetupGet(x => x.Name).Returns("Milky Way");
            var mockedLocationToTeleportTo = new Mock<ILocation>();
            mockedLocationToTeleportTo.SetupGet(x => x.Planet.Name).Returns("Earth");
            mockedLocationToTeleportTo.SetupGet(x => x.Planet.Galaxy).Returns(mockedUnitGalaxy.Object);
            var mockedGalacticMap = new List<IPath>();
            var mockedPath = new Mock<IPath>();

            var mockedMoneyForUnit = new Mock<IResources>();
            mockedUnit.SetupGet(x => x.Resources).Returns(mockedMoneyForUnit.Object);

            mockedUnit.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(true);

            var mockedCostToTravel = new Mock<IResources>();

            mockedPath.SetupGet(x => x.Cost).Returns(mockedCostToTravel.Object);
            mockedUnit.Setup(x => x.Pay(It.IsAny<IResources>())).Returns(mockedCostToTravel.Object);

            mockedPath.SetupGet(x => x.TargetLocation).Returns(mockedLocationToTeleportTo.Object);
            mockedPath.SetupGet(x => x.TargetLocation.Planet.Galaxy.Name).Returns("Milky Way");
            mockedPath.SetupGet(x => x.TargetLocation.Planet.Name).Returns("Earth");
            mockedPath.SetupGet(x => x.TargetLocation.Planet.Units).Returns(new List<IUnit>());

            mockedLocation.Setup(x => x.Planet.Units).Returns(new List<IUnit>());
            mockedLocation.Setup(x => x.Planet.Units.Remove(It.IsAny<IUnit>()));
            mockedUnit.SetupGet(x => x.CurrentLocation).Returns(mockedLocation.Object);
            mockedUnit.SetupSet(p => p.CurrentLocation = It.IsAny<ILocation>());

            mockedGalacticMap.Add(mockedPath.Object);
            var teleportStation = new TeleportStation(mockedBusinessOwner.Object, mockedGalacticMap, mockedLocation.Object);
            //Act
            teleportStation.TeleportUnit(mockedUnit.Object, mockedLocationToTeleportTo.Object);

            //Assert
            mockedUnit.VerifySet(x => x.CurrentLocation = mockedLocationToTeleportTo.Object, Times.Once);
        }

        [Test]
        public void TeleportUnit_WhenEverythingIsValid_ShouldAddUnitToTargetPlanetsUnitList()
        {   //TODO:!!!
            //Arrange
            var mockedBusinessOwner = new Mock<IBusinessOwner>();

            var mockedLocation = new Mock<ILocation>();
            var mockedGalaxy = new Mock<IGalaxy>();
            mockedGalaxy.SetupGet(x => x.Name).Returns("Milky Way");
            mockedLocation.SetupGet(x => x.Planet.Galaxy).Returns(mockedGalaxy.Object);
            mockedLocation.SetupGet(x => x.Planet.Name).Returns("Earth");
            var mockedUnit = new Mock<IUnit>();

            var mockedUnitGalaxy = new Mock<IGalaxy>();
            mockedUnitGalaxy.SetupGet(x => x.Name).Returns("Milky Way");
            var mockedLocationToTeleportTo = new Mock<ILocation>();
            mockedLocationToTeleportTo.SetupGet(x => x.Planet.Name).Returns("Earth");
            mockedLocationToTeleportTo.SetupGet(x => x.Planet.Galaxy).Returns(mockedUnitGalaxy.Object);
            var mockedGalacticMap = new List<IPath>();
            var mockedPath = new Mock<IPath>();

            var mockedMoneyForUnit = new Mock<IResources>();
            mockedUnit.SetupGet(x => x.Resources).Returns(mockedMoneyForUnit.Object);

            mockedUnit.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(true);

            var mockedCostToTravel = new Mock<IResources>();

            mockedPath.SetupGet(x => x.Cost).Returns(mockedCostToTravel.Object);
            mockedUnit.Setup(x => x.Pay(It.IsAny<IResources>())).Returns(mockedCostToTravel.Object);

            mockedPath.SetupGet(x => x.TargetLocation).Returns(mockedLocationToTeleportTo.Object);
            mockedPath.SetupGet(x => x.TargetLocation.Planet.Galaxy.Name).Returns("Milky Way");
            mockedPath.SetupGet(x => x.TargetLocation.Planet.Name).Returns("Earth");
            mockedPath.SetupGet(x => x.TargetLocation.Planet.Units).Returns(new List<IUnit>());

            mockedLocation.Setup(x => x.Planet.Units).Returns(new List<IUnit>());
            mockedLocation.Setup(x => x.Planet.Units.Remove(It.IsAny<IUnit>()));

            mockedLocationToTeleportTo.Setup(x => x.Planet.Units.Add(mockedUnit.Object));

            mockedUnit.SetupGet(x => x.CurrentLocation).Returns(mockedLocation.Object);
            mockedUnit.SetupSet(p => p.CurrentLocation = It.IsAny<ILocation>());

            mockedGalacticMap.Add(mockedPath.Object);
            var teleportStation = new TeleportStation(mockedBusinessOwner.Object, mockedGalacticMap, mockedLocation.Object);
            //Act
            teleportStation.TeleportUnit(mockedUnit.Object, mockedLocationToTeleportTo.Object);

            //Assert
            mockedLocationToTeleportTo.Verify(x => x.Planet.Units.Add(mockedUnit.Object), Times.Once);
        }

        [Test]
        public void TeleportUnit_WhenEverythingIsValid_ShouldRemoveUnitFromPreviousPlanetsUnitList()
        {
            //Arrange
            var mockedBusinessOwner = new Mock<IBusinessOwner>();

            var mockedLocation = new Mock<ILocation>();
            var mockedGalaxy = new Mock<IGalaxy>();
            mockedGalaxy.SetupGet(x => x.Name).Returns("Milky Way");
            mockedLocation.SetupGet(x => x.Planet.Galaxy).Returns(mockedGalaxy.Object);
            mockedLocation.SetupGet(x => x.Planet.Name).Returns("Earth");
            var mockedUnit = new Mock<IUnit>();

            var mockedUnitGalaxy = new Mock<IGalaxy>();
            mockedUnitGalaxy.SetupGet(x => x.Name).Returns("Milky Way");
            var mockedLocationToTeleportTo = new Mock<ILocation>();
            mockedLocationToTeleportTo.SetupGet(x => x.Planet.Name).Returns("Earth");
            mockedLocationToTeleportTo.SetupGet(x => x.Planet.Galaxy).Returns(mockedUnitGalaxy.Object);
            var mockedGalacticMap = new List<IPath>();
            var mockedPath = new Mock<IPath>();

            var mockedMoneyForUnit = new Mock<IResources>();
            mockedUnit.SetupGet(x => x.Resources).Returns(mockedMoneyForUnit.Object);

            mockedUnit.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(true);

            var mockedCostToTravel = new Mock<IResources>();

            mockedPath.SetupGet(x => x.Cost).Returns(mockedCostToTravel.Object);
            mockedUnit.Setup(x => x.Pay(It.IsAny<IResources>())).Returns(mockedCostToTravel.Object);

            mockedPath.SetupGet(x => x.TargetLocation).Returns(mockedLocationToTeleportTo.Object);
            mockedPath.SetupGet(x => x.TargetLocation.Planet.Galaxy.Name).Returns("Milky Way");
            mockedPath.SetupGet(x => x.TargetLocation.Planet.Name).Returns("Earth");
            mockedPath.SetupGet(x => x.TargetLocation.Planet.Units).Returns(new List<IUnit>());

            mockedLocation.Setup(x => x.Planet.Units).Returns(new List<IUnit>());

            mockedLocation.Setup(x => x.Planet.Units.Remove(mockedUnit.Object));

            mockedUnit.SetupGet(x => x.CurrentLocation).Returns(mockedLocation.Object);
            mockedUnit.SetupSet(p => p.CurrentLocation = It.IsAny<ILocation>());

            mockedGalacticMap.Add(mockedPath.Object);
            var teleportStation = new TeleportStation(mockedBusinessOwner.Object, mockedGalacticMap, mockedLocation.Object);
            //Act
            teleportStation.TeleportUnit(mockedUnit.Object, mockedLocationToTeleportTo.Object);

            //Assert
            mockedLocation.Verify(x => x.Planet.Units.Remove(mockedUnit.Object), Times.Once);
        }

        [Test]
        public void PayProfits_WhenPassedArgumentIsActualOwner_ShouldReturnTotalAmountOfResources()
        {
            //Arrange
            var mockedBusinessOwner = new Mock<IBusinessOwner>();

            var mockedLocation = new Mock<ILocation>();
            var mockedGalaxy = new Mock<IGalaxy>();
            mockedGalaxy.SetupGet(x => x.Name).Returns("Milky Way");
            mockedLocation.SetupGet(x => x.Planet.Galaxy).Returns(mockedGalaxy.Object);
            mockedLocation.SetupGet(x => x.Planet.Name).Returns("Earth");
            var mockedUnit = new Mock<IUnit>();
            mockedUnit.SetupGet(x => x.CurrentLocation).Returns(mockedLocation.Object);

            var mockedUnitGalaxy = new Mock<IGalaxy>();
            mockedUnitGalaxy.SetupGet(x => x.Name).Returns("Milky Way");
            var mockedLocationToTeleportTo = new Mock<ILocation>();
            mockedLocationToTeleportTo.SetupGet(x => x.Planet.Name).Returns("Earth");
            mockedLocationToTeleportTo.SetupGet(x => x.Planet.Galaxy).Returns(mockedUnitGalaxy.Object);
            var mockedGalacticMap = new List<IPath>();
            var mockedPath = new Mock<IPath>();

            var mockedMoneyForUnit = new Mock<IResources>();
            mockedMoneyForUnit.SetupGet(x => x.BronzeCoins).Returns(100);
            mockedMoneyForUnit.SetupGet(x => x.GoldCoins).Returns(100);
            mockedMoneyForUnit.SetupGet(x => x.SilverCoins).Returns(100);
            mockedUnit.SetupGet(x => x.Resources).Returns(mockedMoneyForUnit.Object);

            mockedUnit.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(true);

            var mockedCostToTravel = new Mock<IResources>();
            mockedCostToTravel.SetupGet(x => x.BronzeCoins).Returns(1);
            mockedCostToTravel.SetupGet(x => x.GoldCoins).Returns(1);
            mockedCostToTravel.SetupGet(x => x.SilverCoins).Returns(1);
            mockedPath.SetupGet(x => x.Cost).Returns(mockedCostToTravel.Object);
            mockedUnit.Setup(x => x.Pay(It.IsAny<IResources>())).Returns(mockedCostToTravel.Object);

            mockedPath.SetupGet(x => x.TargetLocation).Returns(mockedLocationToTeleportTo.Object);
            mockedPath.SetupGet(x => x.TargetLocation.Planet.Galaxy.Name).Returns("Milky Way");
            mockedPath.SetupGet(x => x.TargetLocation.Planet.Name).Returns("Earth");
            mockedPath.SetupGet(x => x.TargetLocation.Planet.Units).Returns(new List<IUnit>());

            mockedLocation.Setup(x => x.Planet.Units).Returns(new List<IUnit>());
            mockedLocation.Setup(x => x.Planet.Units.Remove(It.IsAny<IUnit>()));
            mockedUnit.SetupGet(x => x.CurrentLocation).Returns(mockedLocation.Object);

            mockedGalacticMap.Add(mockedPath.Object);
            var teleportStation = new MockedTeleportStation(mockedBusinessOwner.Object, mockedGalacticMap, mockedLocation.Object);

            teleportStation.TeleportUnit(mockedUnit.Object, mockedLocationToTeleportTo.Object);

            var expectedGoldCoins = teleportStation.Resources.GoldCoins;
            var expectedSilverCoins = teleportStation.Resources.SilverCoins;
            var expectedBronzeCoins = teleportStation.Resources.BronzeCoins;
            //Act

            var result = teleportStation.PayProfits(mockedBusinessOwner.Object);

            //Assert
            Assert.AreEqual(expectedGoldCoins, result.GoldCoins);
            Assert.AreEqual(expectedSilverCoins, result.SilverCoins);
            Assert.AreEqual(expectedBronzeCoins, result.BronzeCoins);
        }
    }
}
