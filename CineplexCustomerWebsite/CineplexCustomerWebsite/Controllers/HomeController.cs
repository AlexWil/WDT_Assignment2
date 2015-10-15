using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CineplexCustomerWebsite.Models;

using System.Diagnostics;

namespace CineplexCustomerWebsite.Controllers
{
    public class HomeController : Controller
    {
        private DefaultConnection db = new DefaultConnection();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Events()
        {
            return View(db.Event.ToList());
        }

        public ActionResult EventDetails(int? EventID)
        {
            Debug.WriteLine("Current event ID: " + EventID);

            if (EventID == null)
            {
                return RedirectToAction("Events");
            }

            Event SelectedEvent = db.Event.Find(EventID);

            return View(SelectedEvent);
        }

        public ActionResult Cineplexes()
        {
            
            return View(db.Cineplex.ToList());
        }

        public ActionResult Contact()
        {
            return View(new Enquiry());
        }

        [HttpPost]
        public ActionResult Contact(Enquiry UserEnquiry)
        {

            if (ModelState.IsValid)
            {
                db.Enquiry.Add(UserEnquiry);
                db.SaveChanges();
                return View("EnquirySubmission", UserEnquiry);
            }
            else
            {
                Debug.WriteLine("Current enquiry passed: " + UserEnquiry.Email + " : " + UserEnquiry.Message);

                return View();
            }
        }

        public ActionResult SiteMap()
        {
            return View();
        }

    }
}