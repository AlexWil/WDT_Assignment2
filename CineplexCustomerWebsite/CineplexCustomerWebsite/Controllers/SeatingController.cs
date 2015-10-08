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
        private CineplexEntities db = new CineplexEntities();

        public ActionResult CancelBooking()
        {
            Session["ChosenSeats"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ConfirmBooking()
        {
            Session["ChosenSeats"] = null;
            return RedirectToAction("Index", "Home");
        }

        // GET: Seating/Create
        public ActionResult Booking()
        {
            List<string> rows = db.Seating
                .Where(seat => seat.SessionID == 1)
                .Select((seat => seat.RowID))
                .Distinct()
                .ToList();

            ViewBag.Rows = rows;
            String firstRow = rows[0];
            ViewBag.SeatsInRow = db.Seating.Count(seat => seat.SessionID == 1 && seat.RowID == firstRow);

            if (Session["ChosenSeats"] == null)
            {
                Session["ChosenSeats"] = new List<Seating>();
            }

            IEnumerable<int> chosenSeatIDs = (Session["ChosenSeats"] as List<Seating>).Select(chosenSeat => chosenSeat.ID);
            ViewBag.ChosenSeatIDs = chosenSeatIDs;

            return View(db.Seating.ToList());
        }

        public ActionResult SelectSeat(Seating seat)
        {
            (Session["ChosenSeats"] as List<Seating>).Add(seat);

            return RedirectToAction("Booking");
        }

        public ActionResult DeselectSeat(Seating seatToDeselect)
        {
           foreach (Seating seat in (Session["ChosenSeats"] as List<Seating>))
            {
                if (seat.ID == seatToDeselect.ID)
                {
                    seatToDeselect = seat;
                }
            }
            (Session["ChosenSeats"] as List<Seating>).Remove(seatToDeselect);          
            return RedirectToAction("Booking");
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
