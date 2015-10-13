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
            //Session["Events"] = from e in db.Event
              //                  select e;
            return View(new Enquiry());
        }

        [HttpPost]
        public ActionResult Events(Enquiry UserEnquiry)
        {
            if (ModelState.IsValid)
            {
                db.Enquiry.Add(UserEnquiry);
                db.SaveChanges();
                return View("EnquirySubmission", UserEnquiry);
            }
            else
            {
                return View();
            }
        }

    }
}