using System;

using ConsoleWebServer.Framework;
using ConsoleWebServer.Framework.Exceptions;
using ConsoleWebServer.Framework.HttpMessages.Contracts;

using Moq;

using NUnit.Framework;

namespace ConsoleWebServer.Tests
{
    [TestFixture]
    public class RequestParserTests
    {
        private Mock<IHttpRequestFactory> _mockedFactory;

        [OneTimeSetUp]
        public void Init()
        {
            this._mockedFactory = new Mock<IHttpRequestFactory>();
        }

        [Test]
        public void Constructor_ShouldThrow_WhenNullArgumentIsPassed()
        {
            IHttpRequestFactory nullFactory = null;

            Assert.Throws<ArgumentNullException>(() => new RequestParser(null));
        }

        [TestCase("sadasdajhik2jh312kjh23asd")]
        [TestCase("1 2")]
        [TestCase("#@$#@$#$")]
        [TestCase("#@$sa dasda jhik 2jh312kjh23 asd$#$")]
        public void Parse_ShouldThrowParserExceptionWhenInvalidArgumentIsPassed(string invalidStringToParse)
        {
            var parser = new RequestParser(this._mockedFactory.Object);

            Assert.Throws<ParserException>(() => parser.Parse(invalidStringToParse));
        }

        [Test]
        public void Parse_ShouldCallGetHttpRequestFactoryMethod_WhenCorrectParamsAreProvided()
        {
            const string input = "1 2 3";

            this._mockedFactory.Setup(f => f.GetHttpRequest("1", "2", "3"));

            var parser = new RequestParser(this._mockedFactory.Object);
            parser.Parse(input);

            this._mockedFactory.Verify(factory => factory.GetHttpRequest("1", "2", "3"),
                                       Times.Once());
        }

        [Test]
        public void Parse_ShouldAddHeadersToRequest_WhenCorrectParamsAreProvided()
        {
            const string input = @"GET /Home/LivePageForAjax HTTP/1.1
Host: telerikacademy.com
Referer: http://telerikacademy.com/";

            var mockedRequest = new Mock<IHttpRequest>();
            mockedRequest.Setup(r => r.AddHeader("Host", "telerikacademy.com"));
            mockedRequest.Setup(r => r.AddHeader("Referer", "http://telerikacademy.com/"));
            this._mockedFactory.Setup(f => f.GetHttpRequest("GET", "/Home/LivePageForAjax", "HTTP/1.1"))
                .Returns(() => mockedRequest.Object);

            var parser = new RequestParser(this._mockedFactory.Object);
            parser.Parse(input);

            this._mockedFactory.Verify(factory => factory.GetHttpRequest("GET", "/Home/LivePageForAjax", "HTTP/1.1"),
                                       Times.Once());
            mockedRequest.Verify(r => r.AddHeader("Host", "telerikacademy.com"),
                                 Times.Once());
            mockedRequest.Verify(r => r.AddHeader("Referer", "http://telerikacademy.com/"),
                                 Times.Once());
        }
    }
}
