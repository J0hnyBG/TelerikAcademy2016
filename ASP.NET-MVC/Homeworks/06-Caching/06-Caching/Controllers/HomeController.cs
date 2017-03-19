using System;
using System.IO;
using System.Web.Caching;
using System.Web.Mvc;

namespace _06_Caching.Controllers
{
    public class HomeController : Controller
    {
        [OutputCache(Duration = 3600)]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [ChildActionOnly]
        [OutputCache(Duration = 600)]
        public ActionResult PartialAbout()
        {
            return this.PartialView("_About");
        }

        public ActionResult Contact()
        {
            if (this.HttpContext.Cache["files"] == null)
            {
                var files = Directory.GetFiles("C:\\");

                this.HttpContext.Cache.Add("files", files, new CacheDependency("C:\\"), DateTime.UtcNow.AddMinutes(60), Cache.NoSlidingExpiration, CacheItemPriority.Default, null);
            }

            return this.View(this.HttpContext.Cache["files"]);
        }
    }
}
