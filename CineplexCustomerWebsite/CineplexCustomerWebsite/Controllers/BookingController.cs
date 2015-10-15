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

        public ActionResult ConfirmBooking()
        {
            List<Seating> seats = (List<Seating>)Session["ChosenSeats"];
            String chosenSeatsAsString = "";
            foreach (Seating seat in seats)
            {
                chosenSeatsAsString += seat.Row + seat.SeatNumber + ", ";
            }
            chosenSeatsAsString = chosenSeatsAsString.Substring(0, chosenSeatsAsString.Length - 2);
            ViewBag.ChosenSeats = chosenSeatsAsString;
            return View();
        }

        public ActionResult Confirmation(String email)
        {
            List<Seating> seats = (List<Seating>)Session["ChosenSeats"];

            int movieSession = (int)Session["MovieSessionID"];

            SessionBooking booking = new SessionBooking
            {
                Seating = seats,
                MovieSession = db.MovieSession.First(session => session.SessionID == movieSession),
                UserEmail = email,
                SessionID = movieSession
            };

            foreach (Seating seat in seats)
            {
                seat.IsTaken = true;
                db.Entry(seat).State = EntityState.Modified;
            }
            db.SessionBooking.Add(booking);
            db.SaveChanges();

            return View("BookingConfirmation");
        }
    }
}