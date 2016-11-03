using System;

using Dealership.Engine;
using Dealership.Engine.CommandHandlers.Contracts;
using Dealership.Engine.ConsoleProviders;
using Dealership.Factories;

using Moq;

using NUnit.Framework;

namespace Dealership.UnitTests.Engine
{
    [TestFixture]
    internal class DealershipEngineTests
    {
        [Test]
        public void Ctor_ShouldInstantiateEngineCorrectly()
        {
            var mockedFactory = new Mock<IDealershipFactory>();
            var mockedConsole = new Mock<IConsoleInputOutputProvider>();
            var mockedHandler = new Mock<ICommandHandler>();

            var engine = new DealershipEngine(mockedFactory.Object, mockedConsole.Object, mockedHandler.Object);

            Assert.IsInstanceOf<DealershipEngine>(engine);
        }

        [Test]
        public void Ctor_ShouldThrowWhenNullValueIsPassed()
        {
            var mockedConsole = new Mock<IConsoleInputOutputProvider>();
            var mockedFactory = new Mock<IDealershipFactory>();
            var mockedHandler = new Mock<ICommandHandler>();

            Assert.Throws<ArgumentNullException>(() => new DealershipEngine(null, mockedConsole.Object, mockedHandler.Object));
            Assert.Throws<ArgumentNullException>(() => new DealershipEngine(mockedFactory.Object, null, mockedHandler.Object));
            Assert.Throws<ArgumentNullException>(() => new DealershipEngine(mockedFactory.Object, mockedConsole.Object, null));
        }
    }
}
