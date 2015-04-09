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
            ViewBag.Title = " Jon Carlee";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.Title = " About Jon";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.Title = " Contact Jon";

            return View();
        }
        
        public ActionResult Portfolio()
        {
            ViewBag.Message = "Your portfolio page.";
            ViewBag.Title = " Jon's Portfolio";

            return View();
        }
        
        public ActionResult JSExercises()
        {
            ViewBag.Message = "Check out this portfolio item!";
            ViewBag.Title = " Jon's Portfolio - JSExercises";
            return View();
        }
        public ActionResult BugTracker()
        {
            ViewBag.Message = "Check out this portfolio item!";
            ViewBag.Title = " Jon's Portfolio - Bug Tracker";

            return View();
        }
        public ActionResult Resume()
        {
            ViewBag.Message = "Oh Wow! What a cool resume!";
            ViewBag.Title = " Jon's Resume";
            return View();
        }
        public ActionResult Other()
        {
            ViewBag.Message = "Some Other Things About Me";
            ViewBag.Title = "Other Things About Jon";

            return View();
        }
    }
}