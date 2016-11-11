using ConsoleWebServer.Framework.ActionResults;
using ConsoleWebServer.Framework.HttpMessages.Contracts;

namespace ConsoleWebServer.Framework.Contracts
{
    public interface IActionResultFactory
    {
        IActionResult GetContentActionResult(IHttpRequest request, object model);

        IActionResult GetJsonActionResult(IHttpRequest request, object model);

        IActionResult GetRedirectActionResult(IHttpRequest request, string location);

        IActionResult GetContentActionResultWithNoCaching(IHttpRequest request, object model);

        IActionResult GetJsonActionResultWithCors(IHttpRequest request, object model, string corsSettings);

        IActionResult GetContentActionResultWithCorsWithoutCaching(IHttpRequest request,
                                                                   object model,
                                                                   string corsSettings);
    }
}
