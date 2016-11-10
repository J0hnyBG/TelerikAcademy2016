using System;
using System.Net;

using ConsoleWebServer.Framework;
using ConsoleWebServer.Framework.Contracts;
using ConsoleWebServer.Framework.Exceptions;
using ConsoleWebServer.Framework.Handlers;
using ConsoleWebServer.Framework.HttpMessages.Contracts;

using Moq;

using NUnit.Framework;

namespace ConsoleWebServer.Tests
{
    [TestFixture]
    public class ResponseProviderTests
    {
        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenNullArgumentIsPassed()
        {
            var requestParser = new Mock<IRequestParser>();
            var responseFactory = new Mock<IHttpResponseFactory>();
            var headHandler = new Mock<IHandler>();

            Assert.Throws<ArgumentNullException>(() => new ResponseProvider(null, null, null));
            Assert.Throws<ArgumentNullException>(
                                                 () =>
                                                     new ResponseProvider(requestParser.Object, responseFactory.Object,
                                                                          null));
            Assert.Throws<ArgumentNullException>(
                                                 () =>
                                                     new ResponseProvider(null, responseFactory.Object,
                                                                          headHandler.Object));
            Assert.Throws<ArgumentNullException>(
                                                 () =>
                                                     new ResponseProvider(requestParser.Object, null, headHandler.Object));
        }

        [Test]
        public void GetResponse_ShouldCallRequestParserParseMethodOnceWithCorrectParameters()
        {
            const string input = "somestring";
            var responseFactory = new Mock<IHttpResponseFactory>();
            var headHandler = new Mock<IHandler>();
            var requestParser = new Mock<IRequestParser>();
            requestParser.Setup(p => p.Parse(input));

            var responseProvider = new ResponseProvider(requestParser.Object, responseFactory.Object, headHandler.Object);
            responseProvider.GetResponse(input);

            requestParser.Verify(p => p.Parse(input), Times.Once());
        }

        [Test]
        public void GetResponse_ShouldCatchParserExceptionAndCallFactoryMethodWithCorrectParams()
        {
            const string errorMessage = "Error!";
            var responseFactory = new Mock<IHttpResponseFactory>();
            responseFactory.Setup(
                                  f =>
                                      f.GetHttpResponse("1.1", HttpStatusCode.BadRequest, errorMessage,
                                                        "text/plain; charset=utf-8"));

            var headHandler = new Mock<IHandler>();
            var requestParser = new Mock<IRequestParser>();

            requestParser.Setup(p => p.Parse(It.IsAny<string>()))
                         .Throws(new ParserException(errorMessage));

            var responseProvider = new ResponseProvider(requestParser.Object, responseFactory.Object, headHandler.Object);
            responseProvider.GetResponse("message");

            responseFactory.Verify(
                                   f =>
                                       f.GetHttpResponse("1.1", HttpStatusCode.BadRequest, errorMessage,
                                                         "text/plain; charset=utf-8"), Times.Once());
        }

        [Test]
        public void GetResponse_ShouldCatchParserExceptionAndReturnFactoryMethodReturnValue()
        {
            const string errorMessage = "Error!";

            var mockedResponse = new Mock<IHttpResponse>();
            var responseFactory = new Mock<IHttpResponseFactory>();
            responseFactory.Setup(
                                  f =>
                                      f.GetHttpResponse("1.1", HttpStatusCode.BadRequest, errorMessage,
                                                        "text/plain; charset=utf-8"))
                           .Returns(mockedResponse.Object);

            var headHandler = new Mock<IHandler>();
            var requestParser = new Mock<IRequestParser>();

            requestParser.Setup(p => p.Parse(It.IsAny<string>()))
                         .Throws(new ParserException(errorMessage));

            var responseProvider = new ResponseProvider(requestParser.Object, responseFactory.Object, headHandler.Object);
            var result = responseProvider.GetResponse("message");

            Assert.AreSame(mockedResponse.Object, result);
        }

        [Test]
        public void GetResponse_ShouldCallHandlerHandleRequestMethodWithCorrectParameters()
        {
            const string input = "message";

            var responseFactory = new Mock<IHttpResponseFactory>();
            var headHandler = new Mock<IHandler>();
            var request = new Mock<IHttpRequest>();
            var requestParser = new Mock<IRequestParser>();
            requestParser.Setup(p => p.Parse(input))
                         .Returns(request.Object);
            var response = new Mock<IHttpResponse>();
            headHandler.Setup(h => h.HandleRequest(request.Object))
                       .Returns(response.Object);

            var responseProvider = new ResponseProvider(requestParser.Object, responseFactory.Object, headHandler.Object);
            var result = responseProvider.GetResponse(input);

            Assert.AreSame(response.Object, result);
            headHandler.Verify(h => h.HandleRequest(request.Object), Times.Once);
        }
    }
}
