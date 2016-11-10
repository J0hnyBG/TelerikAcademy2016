using System;
using System.Net;

using ConsoleWebServer.Framework.HttpMessages.Contracts;

namespace ConsoleWebServer.Framework.Handlers
{
    public abstract class BaseHandler : IHandler
    {
        private IHttpResponseFactory _responseFactory;
        private IHandler _next;

        protected BaseHandler(IHttpResponseFactory responseFactory)
        {
            this._responseFactory = responseFactory;
        }

        public IHandler Next
        {
            get { return this._next; }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(this.Next));
                }

                this._next = value;
            }
        }

        protected IHttpResponseFactory ResponseFactory
        {
            get { return this._responseFactory; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(this.ResponseFactory));
                }

                this._responseFactory = value;
            }
        }

        public IHttpResponse HandleRequest(IHttpRequest request)
        {
            if (this.CanHandle(request))
            {
                return this.Handle(request);
            }

            if (this.Next != null)
            {
                return this.Next.HandleRequest(request);
            }

            return this._responseFactory.GetHttpResponse(request.ProtocolVersion.ToString(),
                                                         HttpStatusCode.NotImplemented,
                                                         "Request cannot be handled.");
        }

        protected abstract bool CanHandle(IHttpRequest request);

        protected abstract IHttpResponse Handle(IHttpRequest request);
    }
}
