using ConsoleWebServer.Framework.Contracts;
using ConsoleWebServer.Framework.HttpMessages.Contracts;

using NUnit.Framework;

namespace ConsoleWebServer.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ConsoleWebServer.Application.Controllers;

    using Moq;

    [TestFixture]
    public class ApiControllerTests
    {
        private Mock<IActionResultFactory> _actionResultFactoryMock;

        [OneTimeSetUp]
        public void Init()
        {
            this._actionResultFactoryMock = new Mock<IActionResultFactory>();
        }

        [Test]
        public void ReturnMe_ShouldCallFactoryGetJsonActionMethodWithCorrectParameters()
        {
            const string parameter = "someParam123";

            var request = new Mock<IHttpRequest>();
            request.Setup(x => x.ProtocolVersion).Returns(new Version(1, 1));
            this._actionResultFactoryMock.Setup(m => m.GetJsonActionResult(request.Object, parameter));

            var apiController = new ApiController(request.Object, this._actionResultFactoryMock.Object);
            apiController.ReturnMe(parameter);

            this._actionResultFactoryMock.Verify(m => m.GetJsonActionResult(request.Object, parameter),
                                                 Times.Exactly(1));
        }

        [Test]
        public void GetDateWithCors_ShouldThrowArgumentException_WhenNotGivenReferer()
        {
            const string parameter = "somedomain";

            var request = new Mock<IHttpRequest>();
            request.Setup(x => x.ProtocolVersion).Returns(new Version(1, 1));
            var headers = new Dictionary<string, ICollection<string>>();
            request.SetupGet(x => x.Headers).Returns(headers);

            var apiController = new ApiController(request.Object, this._actionResultFactoryMock.Object);
            Assert.Throws<ArgumentException>(() => apiController.GetDateWithCors(parameter));
        }

        [Test]
        public void GetDateWithCors_ShouldThrowArgumentException_WhenGivenEmptyReferer()
        {
            const string parameter = "somedomain";
            var request = this.GetMockedRequestWithRefererHeader(string.Empty);

            var apiController = new ApiController(request, this._actionResultFactoryMock.Object);
            Assert.Throws<ArgumentException>(() => apiController.GetDateWithCors(parameter));
        }

        [Test]
        public void GetDateWithCors_ShouldThrowArgumentException_WhenGivenWrongRefererAsParameter()
        {
            const string parameter = "somedomain";
            var request = this.GetMockedRequestWithRefererHeader("otherdomain");

            var apiController = new ApiController(request, this._actionResultFactoryMock.Object);
            Assert.Throws<ArgumentException>(() => apiController.GetDateWithCors(parameter));
        }

        [Test]
        public void GetDateWithCors_ShouldCallGetJsonActionResultWithCorsFactoryMethodWithCorrectparameters()
        {
            const string parameter = "somedomain";
            var request = this.GetMockedRequestWithRefererHeader("somedomain");

            this._actionResultFactoryMock.Setup(
                                                m =>
                                                    m.GetJsonActionResultWithCors(request, It.IsAny<object>(), parameter));

            var apiController = new ApiController(request, this._actionResultFactoryMock.Object);
            apiController.GetDateWithCors(parameter);

            this._actionResultFactoryMock.Verify(
                                                 m =>
                                                     m.GetJsonActionResultWithCors(request, It.IsAny<object>(),
                                                                                   parameter),
                                                 Times.Exactly(1));
        }

        private IHttpRequest GetMockedRequestWithRefererHeader(string refererHeader)
        {
            var request = new Mock<IHttpRequest>();
            request.Setup(x => x.ProtocolVersion).Returns(new Version(1, 1));
            var headers = new Dictionary<string, ICollection<string>>
                          {
                              {
                                  "Referer",
                                  new List<string> { refererHeader }
                              }
                          };
            request.SetupGet(x => x.Headers).Returns(headers);
            return request.Object;
        }
    }
}
