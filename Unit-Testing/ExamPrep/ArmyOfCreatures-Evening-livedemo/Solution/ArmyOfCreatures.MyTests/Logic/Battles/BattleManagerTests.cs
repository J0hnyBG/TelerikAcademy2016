using System;
using System.Linq;
using System.Runtime.InteropServices;
using ArmyOfCreatures.Console;
using ArmyOfCreatures.Logic;
using ArmyOfCreatures.Logic.Battles;
using ArmyOfCreatures.Logic.Creatures;
using ArmyOfCreatures.MyTests.Logic.Battles.Mocks;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Kernel;

namespace ArmyOfCreatures.MyTests.Logic.Battles
{
    [TestFixture]
   public class BattleManagerTests
    {
        [Test]
        public void AddCreatures_ShouldThrowArgumentNullException_WhenIdentifierIsNull()
        {
            var mockFactory = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();
            var manager = new BattleManager(mockFactory.Object, mockedLogger.Object);

            Assert.That(
                () => manager.AddCreatures(null, 5), 
                Throws.ArgumentNullException.With.Message.Contains("creatureIdentifier"));
        }

        [Test]
        public void AddCreatures_ShouldCallCreateCreatureMethodOfFactory_WhenValidIdentifierIsProvided()
        {
            var mockedLogger = new Mock<ILogger>();
            var mockFactory = new Mock<ICreaturesFactory>();
            var manager = new BattleManager(mockFactory.Object, mockedLogger.Object);
            mockFactory.Setup(x => x.CreateCreature(It.IsAny<string>())).Returns(new Angel());
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");

            manager.AddCreatures(identifier, 1);

            mockFactory.Verify(x => x.CreateCreature(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void AddCreatures_ShouldCallWriteLineMethodOfLogger_WhenValidIdentifierIsProvided()
        {
            var mockedLogger = new Mock<ILogger>();
            mockedLogger.Setup(x => x.WriteLine(It.IsAny<string>()));
            var mockFactory = new Mock<ICreaturesFactory>();
            mockFactory.Setup(x => x.CreateCreature(It.IsAny<string>())).Returns(new Angel());
            var manager = new BattleManager(mockFactory.Object, mockedLogger.Object);
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");

            manager.AddCreatures(identifier, 1);

            mockedLogger.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void AddCreatures_ShouldThrowArgumentException_WhenInvalidArmyNumberIsProvided()
        {
            var mockedLogger = new Mock<ILogger>();
            var mockFactory = new Mock<ICreaturesFactory>();
            mockFactory.Setup(x => x.CreateCreature(It.IsAny<string>())).Returns(new Angel());
            var manager = new BattleManager(mockFactory.Object, mockedLogger.Object);
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(3)");

           Assert.Throws<ArgumentException>(() =>  manager.AddCreatures(identifier, 1));
        }

        [Test]
        public void Attack_ShouldThrowArgumentNullException_WhenAttackerCreatureIdentifierIsNull()
        {
            var mockedLogger = new Mock<ILogger>();
            var mockFactory = new Mock<ICreaturesFactory>();
            var manager = new BattleManager(mockFactory.Object, mockedLogger.Object);
            var defenderIdentifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");

            Assert.Throws<ArgumentNullException>(() => manager.Attack(null, defenderIdentifier));
        }
        [Test]
        public void Attack_ShouldThrowArgumentNullException_WhenDefenderCreatureIdentifierIsNull()
        {
            var mockedFactory = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();
            var battleManager = new BattleManager(mockedFactory.Object, mockedLogger.Object);
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");

            Assert.Throws<ArgumentException>(() => battleManager.Attack(identifier, null));
        }

        [Test]
        public void Attack_ShouldCallLoggerWriteLineMethodFourTimes_WhenAttackIsSuccessfull()
        {
            var mockedFactory = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();
            var battleManager = new MockedBattleManager(mockedFactory.Object, mockedLogger.Object);
            var identifierAttacker = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");
            var identifierDefender = CreatureIdentifier.CreatureIdentifierFromString("Angel(2)");
            var creature = new Angel();

            mockedFactory.Setup(x => x.CreateCreature(It.IsAny<string>())).Returns(creature);
            battleManager.AddCreatures(identifierAttacker, 3);
            battleManager.AddCreatures(identifierDefender, 3);

            battleManager.Attack(identifierAttacker, identifierDefender);

            mockedLogger.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Exactly(6));
        }

        [Test]
        public void Attack_ShouldReturnRightResult_WhenTwoBehemothsAttackOne()
        {
            var mockedFactory = new Mock<ICreaturesFactory>();
            var mockedLogger = new Mock<ILogger>();
            var battleManager = new MockedBattleManager(mockedFactory.Object, mockedLogger.Object);
            var identifierAttacker = CreatureIdentifier.CreatureIdentifierFromString("Behemoth(1)");
            var identifierDefender = CreatureIdentifier.CreatureIdentifierFromString("Behemoth(2)");
            var creature = new Behemoth();
            mockedFactory.Setup(x => x.CreateCreature(It.IsAny<string>())).Returns(creature);
            battleManager.AddCreatures(identifierAttacker, 2);
            battleManager.AddCreatures(identifierDefender, 1);

            battleManager.Attack(identifierAttacker, identifierDefender);

            var result = battleManager.SecondArmyOfCreatures.FirstOrDefault().TotalHitPoints;

            Assert.IsTrue(result == 56);
        }
    }
}
