using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CineplexCustomerWebsite.Models;

namespace CineplexCustomerWebsite.Controllers
{
    public class BookingController : Controller
    {
        private DefaultConnection db = new DefaultConnection();

        public ActionResult ConfirmBooking(FormCollection form)
        {
            List<int> seatingIds = form["submitChosenSeats"].Split(',').Select(int.Parse).ToList();
            List<Seating> seats = seatingIds.Select(seatID => db.Seating.First(seat => seat.SeatingID == seatID)).ToList();
            String chosenSeatsAsString = seats.Aggregate("", (current, seat) => current + (seat.Row + seat.SeatNumber + ", "));
            Session["ChosenSeats"] = seatingIds;
            chosenSeatsAsString = chosenSeatsAsString.Substring(0, chosenSeatsAsString.Length - 2);
            ViewBag.ChosenSeats = chosenSeatsAsString;
            return View();
        }

        public ActionResult Confirmation(String email)
        {
            List<int> seatingIds = (List<int>)Session["ChosenSeats"];
            List<Seating> seats = seatingIds.Select(seatID => db.Seating.First(seat => seat.SeatingID == seatID)).ToList();
            int movieSession = (int)Session["MovieSessionID"];
            SessionBooking booking = new SessionBooking
            {
                Seating = seats,
                MovieSession = db.MovieSession.First(session => session.SessionID == movieSession),
                UserEmail = email,
                SessionID = movieSession,
            };
            booking.CineplexID = booking.MovieSession.CineplexID;

            foreach (Seating seat in seats)
            {
                seat.IsTaken = true;
                db.Entry(seat).State = EntityState.Modified;
                seat.SessionBooking.Add(booking);
            }
            db.SessionBooking.Add(booking);
            db.SaveChanges();

            return View("BookingConfirmation");
        }

        public ActionResult CancelBooking(int? BookingID)
        {
            SessionBooking sessionBooking = db.SessionBooking.First(booking => booking.BookingID == BookingID);
            List<Seating> seatsInBooking = db.Seating.Where(s => s.SessionBooking.FirstOrDefault().BookingID.Equals(sessionBooking.BookingID)).ToList();

            foreach (Seating seat in seatsInBooking)
            {
                seat.IsTaken = false;
                seat.SessionBooking.Remove(sessionBooking);
                db.Entry(seat).State = EntityState.Modified;

            }

            db.SessionBooking.Remove(sessionBooking);
            //db.Entry(SessionBooking).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult ManageBookings(string EmailSearch)
        {

            var Bookings = from b in db.SessionBooking
                           select b;

            if (!String.IsNullOrEmpty(EmailSearch))
            {
                Bookings = Bookings.Where(b => b.UserEmail == EmailSearch);
            }
            else
            {
                Bookings = null;
            }

            return View(Bookings);
        }
    }
}