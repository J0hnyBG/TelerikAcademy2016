using System.Web.Mvc;

namespace _02_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}