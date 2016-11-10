using System;

using ConsoleWebServer.Framework.HttpMessages.Contracts;

namespace ConsoleWebServer.Framework.ActionResults
{
    public class ActionResultWithoutCachingDecorator : IActionResult
    {
        private readonly IActionResult _actionResult;

        public ActionResultWithoutCachingDecorator(IActionResult actionResult)
        {
            if (actionResult == null)
            {
                throw new ArgumentNullException(nameof(actionResult));
            }

            this._actionResult = actionResult;
        }

        public IHttpResponse GetResponse()
        {
            var response = this._actionResult.GetResponse();
            response?.AddHeader("Cache-Control", "private, max-age=0, no-cache");

            return response;
        }
    }
}
