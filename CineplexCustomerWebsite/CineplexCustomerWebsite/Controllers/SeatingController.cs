using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CineplexCustomerWebsite.Models;

namespace CineplexCustomerWebsite.Controllers
{
    public class SeatingController : Controller
    {
        private DefaultConnection db = new DefaultConnection();

        public ActionResult CancelBookingProcess()
        {
            Session["ChosenSeats"] = null;
            return RedirectToAction("Index", "Home");
        }


        public ActionResult GraphicalSeatBooking(int movieSessionId)
        {
            List<string> rows = db.Seating
                .Where(seat => seat.SessionID == movieSessionId)
                .Select((seat => seat.Row))
                .Distinct()
                .ToList();

            ViewBag.Rows = rows;
            String firstRow = rows[0];
            ViewBag.SeatsInRow = db.Seating.Count(seat => seat.SessionID == movieSessionId && seat.Row == firstRow);

            //Maximum is needed to calculate optimal layout of table
            List<int> seatsPerRow = new List<int>();
            rows.ForEach(row => seatsPerRow.Add(db.Seating.Count(seat => seat.SessionID == movieSessionId && seat.Row == row)));
            ViewBag.maxSeatsPerRow=seatsPerRow.Max();

            Session["MovieSessionID"] = movieSessionId;
            ViewBag.MovieSessionID = movieSessionId;

            return View(db.Seating.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
