using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CineplexCustomerWebsite.Models;


namespace CineplexCustomerWebsite.Controllers
{
    public class HomeController : Controller
    {
        private DefaultConnection db = new DefaultConnection();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Cineplexes()
        {
            
            return View(db.Cineplex.ToList());
        }

        public ActionResult Events()
        {
            ViewBag.Message = "ABC Corp. Events.";

            return View();
        }
    }
}