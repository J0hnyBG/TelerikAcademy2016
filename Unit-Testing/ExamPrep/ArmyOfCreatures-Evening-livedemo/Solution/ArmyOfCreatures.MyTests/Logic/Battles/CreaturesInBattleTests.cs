
using System;
using ArmyOfCreatures.Extended.Creatures;
using ArmyOfCreatures.Logic.Battles;
using ArmyOfCreatures.Logic.Creatures;
using ArmyOfCreatures.MyTests.Logic.Battles.Mocks;
using Moq;
using NUnit.Framework;

namespace ArmyOfCreatures.MyTests.Logic.Battles
{
    [TestFixture]
    public class CreaturesInBattleTests
    {
        [Test]
        public void DealDamage_WhenDefenderIsNull_ShouldThrowArgumentNullException()
        {
            ICreaturesInBattle defender = null;
            var tested = new CreaturesInBattle(new AncientBehemoth(), 1);
            Assert.Throws<ArgumentNullException>(() =>tested.DealDamage(defender));
        }

        [Test]
        public void DealDamage_WhenDefenderIsValid_ShouldReturnExpectedResult()
        {
            var defender = new CreaturesInBattle(new Behemoth(), 2);
            var attacker = new CreaturesInBattle(new Behemoth(), 1);
            attacker.DealDamage(defender);

            var result = defender.TotalHitPoints;

            Assert.AreEqual(280, result);
        }

        [Test]
        public void DealDamage_WhenDefenderHasLargerDefence_ShouldReturnExpectedResult()
        {
            var defender = new CreaturesInBattle(new Behemoth(), 1);
            var attacker = new CreaturesInBattle(new AncientBehemoth(), 1);
            attacker.DealDamage(defender);

            var result = defender.TotalHitPoints;

            Assert.AreEqual(116, result);
        }

        [Test]
        public void Skip_ShouldCallApplyOnSkipForEachSpecialty()
        {
            var mockedCreature = new MockedCreature(1 , 1, 10, 1M);
            var creaturesInBattle = new CreaturesInBattle(mockedCreature, 1);

            creaturesInBattle.Skip();

            foreach (var speciality in mockedCreature.Specialties )
            {
                speciality.Verify(x => x.ApplyOnSkip(It.IsAny<ICreaturesInBattle>()), Times.Once);
            }
        }
    }
}
