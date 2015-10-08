using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment_2.Models;

namespace Assignment_2.Controllers
{
    public class SeatAController : Controller
    {
        private CineplexLocalEntities db = new CineplexLocalEntities();

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

        // GET: SeatA/Create
        public ActionResult Booking()
        {
            List<string> rows = db.SeatA
                .Where(seat => seat.SessionID == 1)
                .Select((seat => seat.RowID))
                .Distinct()
                .ToList();

            ViewBag.Rows = rows;
            String firstRow = rows[0];
            ViewBag.SeatsInRow = db.SeatA.Count(seat => seat.SessionID == 1 && seat.RowID == firstRow);

            if (Session["ChosenSeats"] == null)
            {
                Session["ChosenSeats"] = new List<SeatA>();
            }

            IEnumerable<int> chosenSeatIDs = (Session["ChosenSeats"] as List<SeatA>).Select(chosenSeat => chosenSeat.ID);
            ViewBag.ChosenSeatIDs = chosenSeatIDs;

            return View(db.SeatA.ToList());
        }

        public ActionResult SelectSeat(SeatA seat)
        {
            (Session["ChosenSeats"] as List<SeatA>).Add(seat);

            return RedirectToAction("Booking");
        }

        public ActionResult DeselectSeat(SeatA seatToDeselect)
        {
           foreach (SeatA seat in (Session["ChosenSeats"] as List<SeatA>))
            {
                if (seat.ID == seatToDeselect.ID)
                {
                    seatToDeselect = seat;
                }
            }
            (Session["ChosenSeats"] as List<SeatA>).Remove(seatToDeselect);          
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
