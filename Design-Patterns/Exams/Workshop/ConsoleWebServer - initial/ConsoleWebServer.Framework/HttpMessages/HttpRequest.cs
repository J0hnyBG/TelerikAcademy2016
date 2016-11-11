using System;
using System.Text;

using ConsoleWebServer.Framework.Contracts;
using ConsoleWebServer.Framework.HttpMessages.Contracts;

namespace ConsoleWebServer.Framework.HttpMessages
{
    public class HttpRequest : HttpMessage, IHttpRequest
    {
        public HttpRequest(string method,
                           string uri,
                           string httpVersion,
                           IActionDescriptorFactory actionDescriptorFactory)
            : base(httpVersion)
        {
            if (actionDescriptorFactory == null)
            {
                throw new ArgumentNullException(nameof(actionDescriptorFactory));
            }

            this.Uri = uri;
            this.Method = method;
            this.Action = actionDescriptorFactory.GetActionDescriptor(uri);
        }

        public string Uri { get; private set; }

        public string Method { get; private set; }

        public IActionDescriptor Action { get; private set; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(
                                     string.Format(
                                                   "{0} {1} {2}{3}",
                                                   this.Method,
                                                   this.Action,
                                                   HttpVersionPrefix,
                                                   this.ProtocolVersion));
            stringBuilder.AppendLine(base.ToString().Trim());
            return stringBuilder.ToString();
        }
    }
}
