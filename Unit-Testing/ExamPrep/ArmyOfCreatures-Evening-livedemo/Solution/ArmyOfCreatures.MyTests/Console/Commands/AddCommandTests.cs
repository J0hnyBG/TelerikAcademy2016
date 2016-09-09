using ArmyOfCreatures.Logic.Battles;
using Moq;

namespace ArmyOfCreatures.MyTests.Console.Commands
{
    using System;
    using NUnit.Framework;
    using ArmyOfCreatures.Console;
    using ArmyOfCreatures.Console.Commands;

    [TestFixture]
    public class AddCommandTests
    {
        [Test]
        public void ProcessCommand_WhenBattleManagerParamIsNull_ShouldThrowArgumentNullException()
        {
            var cmd = new AddCommand();

            Assert.Throws<ArgumentNullException>(() => cmd.ProcessCommand(null, "1", "second"));
        }

        [Test]
        public void ProcessCommand_WhenArgumentsParamAreNull_ShouldThrowArgumentNullException()
        {
            var cmd = new AddCommand();
            var mockedBattleManager = new Mock<IBattleManager>();

            Assert.Throws<ArgumentNullException>(() => cmd.ProcessCommand(mockedBattleManager.Object, null));
        }

        [Test]
        public void ProcessCommand_WhenArgumentsParamAreLessThanMinimum_ShouldThrowArgumentNullException()
        {
            var cmd = new AddCommand();
            var mockedBattleManager = new Mock<IBattleManager>();

            Assert.Throws<ArgumentException>(() => cmd.ProcessCommand(mockedBattleManager.Object, "1"));
        }

        [Test]
        public void ProcessCommand_WhenParamsAreValid_ShouldCallBattleManagerAddCreaturesMethodOnce()
        {
            var cmd = new AddCommand();
            var mockedBattleManager = new Mock<IBattleManager>();
            mockedBattleManager.Setup(x => x.AddCreatures(It.IsAny<CreatureIdentifier>(), It.IsAny<int>()));

            cmd.ProcessCommand(mockedBattleManager.Object, "2", "Angel(1)");

            mockedBattleManager.Verify(x => x.AddCreatures(It.IsAny<CreatureIdentifier>(), It.IsAny<int>()), Times.Once);
        }
    }
}
