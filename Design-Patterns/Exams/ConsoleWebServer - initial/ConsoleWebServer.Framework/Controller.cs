using System;

using ConsoleWebServer.Framework.ActionResults;
using ConsoleWebServer.Framework.Contracts;
using ConsoleWebServer.Framework.HttpMessages.Contracts;

namespace ConsoleWebServer.Framework
{
    public abstract class Controller
    {
        private readonly IActionResultFactory _actionResultFactory;
        private IHttpRequest _request;

        protected Controller(IHttpRequest request, IActionResultFactory actionResultFactory)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (actionResultFactory == null)
            {
                throw new ArgumentNullException(nameof(actionResultFactory));
            }

            this.Request = request;
            this._actionResultFactory = actionResultFactory;
        }

        protected IActionResultFactory ActionResultFactory
        {
            get { return this._actionResultFactory; }
        }

        protected IHttpRequest Request
        {
            get { return this._request; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(this.Request));
                }

                this._request = value;
            }
        }

        protected IActionResult Content(object model)
        {
            var actionResult = this._actionResultFactory.GetContentActionResult(this.Request, model);
            return actionResult;
        }

        protected IActionResult Json(object model)
        {
            var actionResult = this._actionResultFactory.GetJsonActionResult(this.Request, model);
            return actionResult;
        }

        protected IActionResult Redirect(string location)
        {
            var actionResult = this._actionResultFactory.GetRedirectActionResult(this.Request, location);
            return actionResult;
        }
    }
}
