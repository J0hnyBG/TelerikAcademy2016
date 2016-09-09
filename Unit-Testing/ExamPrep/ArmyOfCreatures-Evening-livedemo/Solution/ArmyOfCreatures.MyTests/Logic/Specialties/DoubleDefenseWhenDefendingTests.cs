namespace ArmyOfCreatures.MyTests.Logic.Specialties
{
    using System;

    using Moq;
    using NUnit.Framework;

    using ArmyOfCreatures.Logic.Battles;
    using ArmyOfCreatures.Logic.Specialties;

    [TestFixture]
    public class DoubleDefenseWhenDefendingTests
    {
        [Test]
        public void ApplyWhenDefending_WhenDefenderIsNull_ShouldThrowArgumentNullException()
        {
            var def = new DoubleDefenseWhenDefending(3);
            var mockedICreaturesInBattle = new Mock<ICreaturesInBattle>();

            Assert.Throws<ArgumentNullException>(() => def.ApplyWhenDefending(null, mockedICreaturesInBattle.Object));
        }

        [Test]
        public void ApplyWhenDefending_WhenAttackerIsNull_ShouldThrowArgumentNullException()
        {
            var def = new DoubleDefenseWhenDefending(3);
            var mockedICreaturesInBattle = new Mock<ICreaturesInBattle>();

            Assert.Throws<ArgumentNullException>(() => def.ApplyWhenDefending(mockedICreaturesInBattle.Object, null));
        }

        [Test]
        public void ApplyWhenDefending_WhenEffectHasExpired_ShouldNotChangeCurrentDefence()
        {
            var def = new DoubleDefenseWhenDefending(1);
            var defenderMock = new Mock<ICreaturesInBattle>();
            defenderMock.SetupAllProperties();
            defenderMock.Object.CurrentDefense = 1;
            var attackerMock = new Mock<ICreaturesInBattle>();

            def.ApplyWhenDefending(defenderMock.Object, attackerMock.Object);
            def.ApplyWhenDefending(defenderMock.Object, attackerMock.Object);
            def.ApplyWhenDefending(defenderMock.Object, attackerMock.Object);
            def.ApplyWhenDefending(defenderMock.Object, attackerMock.Object);

            defenderMock.VerifySet(x => x.CurrentDefense = 2);
        }

        [Test]
        public void ApplyWhenDefending_WhenEffectHasNotExpired_ShouldDoubleCurrentDefenceForEachCall()
        {
            var def = new DoubleDefenseWhenDefending(3);
            var defenderMock = new Mock<ICreaturesInBattle>();
            defenderMock.SetupAllProperties();
            defenderMock.Object.CurrentDefense = 1;
            var attackerMock = new Mock<ICreaturesInBattle>();

            def.ApplyWhenDefending(defenderMock.Object, attackerMock.Object);
            def.ApplyWhenDefending(defenderMock.Object, attackerMock.Object);
            def.ApplyWhenDefending(defenderMock.Object, attackerMock.Object);

            defenderMock.VerifySet(x => x.CurrentDefense = 8);
        }
    }
}
