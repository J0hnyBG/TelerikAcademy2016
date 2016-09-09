namespace ArmyOfCreatures.MyTests.Extended
{
    using System.Collections.Generic;
    using ArmyOfCreatures.Extended;
    using ArmyOfCreatures.Logic;
    using ArmyOfCreatures.Logic.Battles;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using NUnit.Framework;
    using Assert = NUnit.Framework.Assert;

    [TestFixture]
    public class BattleManagerWithThreeArmiesTests
    {
        [Test]
        public void Constructor_ShouldInstantiateFieldsCorrectly()
        {
            var mockedCreaturesFactory = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();

            var battleManager = new BattleManagerWithThreeArmies(mockedCreaturesFactory.Object, mockedLogger.Object);
            var privateObject = new PrivateObject(battleManager);

            var resultThirdArmy = privateObject.GetField("thirdArmyCreatures") as ICollection<ICreaturesInBattle>;
           
            Assert.AreEqual(new List<ICreaturesInBattle>(), resultThirdArmy);
        }
    }
}
