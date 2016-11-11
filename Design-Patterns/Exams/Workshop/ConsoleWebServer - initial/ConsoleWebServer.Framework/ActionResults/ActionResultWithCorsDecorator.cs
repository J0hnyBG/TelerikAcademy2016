using ConsoleWebServer.Framework.HttpMessages.Contracts;

namespace ConsoleWebServer.Framework.ActionResults
{
    public class ActionResultWithCorsDecorator : IActionResult
    {
        private readonly string _corsSettings;
        private readonly IActionResult _actionResult;

        public ActionResultWithCorsDecorator(string corsSettings, IActionResult actionResult)
        {
            this._corsSettings = corsSettings;
            this._actionResult = actionResult;
        }

        public IHttpResponse GetResponse()
        {
            var response = this._actionResult.GetResponse();
            response?.AddHeader("Access-Control-Allow-Origin", this._corsSettings);

            return response;
        }
    }
}
