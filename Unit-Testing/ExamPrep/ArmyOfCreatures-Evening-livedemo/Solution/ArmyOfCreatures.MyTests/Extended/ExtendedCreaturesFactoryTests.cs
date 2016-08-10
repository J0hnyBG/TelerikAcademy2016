namespace ArmyOfCreatures.MyTests.Extended
{
    using System;

    using ArmyOfCreatures.Extended;
    using ArmyOfCreatures.Extended.Creatures;
    using ArmyOfCreatures.Logic.Creatures;

    using NUnit.Framework;

    [TestFixture]
    public class ExtendedCreaturesFactoryTests
    {
        private ExtendedCreaturesFactory _factory;

        [OneTimeSetUp]
        public void Init()
        {
            this._factory = new ExtendedCreaturesFactory();
        }

        [Test]
        public void CreateCreature_ShouldThrowArgumentExceptionWithCorrectMessage_WhenInvalidCreatureIsProvided()
        {

            Assert.That(
                () => _factory.CreateCreature("Invalid_creature_sdasdas238947&*(^&*&(689"), 
                Throws.ArgumentException.With.Message.Contains("Invalid creature type"));
        }

        [TestCase("AncientBehemoth", typeof(AncientBehemoth))]
        [TestCase("CyclopsKing", typeof(CyclopsKing))]
        [TestCase("Goblin", typeof(Goblin))]
        [TestCase("Griffin", typeof(Griffin))]
        [TestCase("WolfRaider", typeof(WolfRaider))]
        [TestCase("Angel", typeof(Angel))]
        public void CreateCreature_ShouldCreateCorrespondingCreature_WhenValidCreatureStringIsProvided(string creatureName, Type expectedCreatureType)
        {
            var result = this._factory.CreateCreature(creatureName);

            Assert.IsInstanceOf(expectedCreatureType, result);
        }
    }
}
