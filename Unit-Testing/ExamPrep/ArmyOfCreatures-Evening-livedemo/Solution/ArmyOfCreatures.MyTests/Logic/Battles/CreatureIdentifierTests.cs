namespace ArmyOfCreatures.MyTests.Logic.Battles
{
    using System;

    using ArmyOfCreatures.Logic.Battles;

    using NUnit.Framework;

    [TestFixture]
    public class CreatureIdentifierTests
    {
        [Test]
        public void CreatureIdentifierFromString_WithNullParameter_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => CreatureIdentifier.CreatureIdentifierFromString(null));
        }

        [Test]
        public void CreatureIdentifierFromString_WithInvalidArmyNumber_ShouldThrowFormatExcepition()
        {
            Assert.Throws<FormatException>(() => CreatureIdentifier.CreatureIdentifierFromString("Angel(dsakdaskldjas)"));
        }

        [Test]
        public void CreatureIdentifierFromString_WithNoBracketsInParameter_ShouldThrowIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() => CreatureIdentifier.CreatureIdentifierFromString("Angel 3"));
        }

        [Test]
        public void ToString_ShouldReturnCorrectString()
        {
            var identifier = CreatureIdentifier.CreatureIdentifierFromString("Angel(1)");
            var expected = "Angel(1)";
            var result = identifier.ToString();

            Assert.AreEqual(expected, result);
        }
    }
}
