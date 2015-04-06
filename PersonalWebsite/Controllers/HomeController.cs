using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalWebsite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        public ActionResult Portfolio()
        {
            ViewBag.Message = "Your portfolio page.";

            return View();
        }
        
        public ActionResult JSExercises()
        {
            ViewBag.Message = "Check out this portfolio item!";

            return View();
        }
        public ActionResult BugTracker()
        {
            ViewBag.Message = "Check out this portfolio item!";

            return View();
        }
        public ActionResult Resume()
        {
            ViewBag.Message = "Oh Wow! What a cool resume!";

            return View();
        }
        public ActionResult Other()
        {
            ViewBag.Message = "Some Other Things About Me";

            return View();
        }
    }
}