using System;
using System.Linq;
using System.Web.Mvc;

using _02_MVC.Models;

namespace _02_MVC.Controllers
{
    public class SumController : Controller
    {
        // GET: Sum
        public ActionResult Index()
        {
            return this.View();
        }

        // POST: Sum/Result
        [HttpPost]
        public ActionResult Result(FormCollection collection)
        {
            try
            {
                var sum = collection.Cast<object>().Sum(key => int.Parse(collection[key as string]));

                return this.View(new Result(sum.ToString()));
            }
            catch (Exception ex)
            {
                return this.View(new Result(ex.Message));
            }
        }
    }
}
