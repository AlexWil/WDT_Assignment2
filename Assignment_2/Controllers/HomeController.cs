using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment_2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cinemas()
        {
            ViewBag.Message = "Cinemas List";

            return View();
        }
        public ActionResult Movies()
        {
            ViewBag.Message = "Movies List";

            return View();
        }
        public ActionResult Events()
        {
            ViewBag.Message = "Events List";

            return View();
        }
        public ActionResult Movie_Sessions()
        {
            ViewBag.Message = "Movies Session Times";

            return View();
        }

    }
}