using ConsoleWebServer.Framework;
using ConsoleWebServer.Framework.ActionResults;
using ConsoleWebServer.Framework.Contracts;
using ConsoleWebServer.Framework.HttpMessages.Contracts;

namespace ConsoleWebServer.Application.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IHttpRequest request, IActionResultFactory actionResultFactory)
            : base(request, actionResultFactory)
        {
        }

        public IActionResult Index(string param)
        {
            return this.Content("Home page :)");
        }

        public IActionResult LivePage(string param)
        {
            var actionResult = this.ActionResultFactory.GetContentActionResultWithNoCaching(this.Request,
                                                                                            "Live page with no caching");
            return actionResult;
        }

        public IActionResult LivePageForAjax(string param)
        {
            var actionResult = this.ActionResultFactory.GetContentActionResultWithCorsWithoutCaching(this.Request,
                                                                                                     "Live page with no caching and CORS",
                                                                                                     "*");
            return actionResult;
        }

        public IActionResult Forum(string param)
        {
            return this.Redirect("https://telerikacademy.com/Forum/Home");
        }
    }
}
