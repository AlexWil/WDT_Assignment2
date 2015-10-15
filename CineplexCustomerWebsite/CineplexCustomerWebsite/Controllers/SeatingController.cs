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


        //Can be deleted later on..
        public ActionResult GenerateData()
        {
            GenerateDataHelper();
            return RedirectToAction("Index", "Home");
        }

        private void GenerateDataHelper()
        {
            Debug.WriteLine("Starting to generate..");

//            Movie thisMovie = db.Movie.First(movie => movie.MovieID == 10);
//            Cineplex thisCineplex = db.Cineplex.First(cineplex => cineplex.CineplexID == 1);
//            DateTime startShowTime = DateTime.Parse("20.10.2015 20:00:00");
//            GenerateMovieSessionsForMovie(thisMovie, thisCineplex, startShowTime);

            Movie thisMovie = db.Movie.First(movie => movie.MovieID == 3);
            Cineplex thisCineplex = db.Cineplex.First(cineplex => cineplex.CineplexID == 2);
            DateTime startShowTime = DateTime.Parse("15.10.2015 20:00:00");
             GenerateMovieSessionsForMovie(thisMovie, thisCineplex, startShowTime);

             thisMovie = db.Movie.First(movie => movie.MovieID == 5);
             thisCineplex = db.Cineplex.First(cineplex => cineplex.CineplexID == 1);
             startShowTime = DateTime.Parse("15.10.2015 16:00:00");
             GenerateMovieSessionsForMovie(thisMovie, thisCineplex, startShowTime);

             thisMovie = db.Movie.First(movie => movie.MovieID == 4);
             thisCineplex = db.Cineplex.First(cineplex => cineplex.CineplexID == 1);
             startShowTime = DateTime.Parse("15.10.2015 12:00:00");
             GenerateMovieSessionsForMovie(thisMovie, thisCineplex, startShowTime);
//
             thisMovie = db.Movie.First(movie => movie.MovieID == 2);
             thisCineplex = db.Cineplex.First(cineplex => cineplex.CineplexID == 2);
             startShowTime = DateTime.Parse("15.10.2015 16:00:00");
            GenerateMovieSessionsForMovie(thisMovie, thisCineplex, startShowTime);

            thisMovie = db.Movie.First(movie => movie.MovieID == 1);
            thisCineplex = db.Cineplex.First(cineplex => cineplex.CineplexID == 2);
            startShowTime = DateTime.Parse("15.10.2015 12:00:00");
            GenerateMovieSessionsForMovie(thisMovie, thisCineplex, startShowTime);

            thisMovie = db.Movie.First(movie => movie.MovieID == 4);
            thisCineplex = db.Cineplex.First(cineplex => cineplex.CineplexID == 3);
            startShowTime = DateTime.Parse("15.10.2015 20:00:00");
            GenerateMovieSessionsForMovie(thisMovie, thisCineplex, startShowTime);

            thisMovie = db.Movie.First(movie => movie.MovieID == 5);
            thisCineplex = db.Cineplex.First(cineplex => cineplex.CineplexID == 3);
            startShowTime = DateTime.Parse("15.10.2015 16:00:00");
            GenerateMovieSessionsForMovie(thisMovie, thisCineplex, startShowTime);  
            
            thisMovie = db.Movie.First(movie => movie.MovieID == 2);
            thisCineplex = db.Cineplex.First(cineplex => cineplex.CineplexID == 3);
            startShowTime = DateTime.Parse("15.10.2015 12:00:00");
            GenerateMovieSessionsForMovie(thisMovie, thisCineplex, startShowTime);
//
            thisMovie = db.Movie.First(movie => movie.MovieID == 8);
            thisCineplex = db.Cineplex.First(cineplex => cineplex.CineplexID == 4);
            startShowTime = DateTime.Parse("15.10.2015 20:00:00");
            GenerateMovieSessionsForMovie(thisMovie, thisCineplex, startShowTime);
//
            thisMovie = db.Movie.First(movie => movie.MovieID == 8);
            thisCineplex = db.Cineplex.First(cineplex => cineplex.CineplexID == 4);
            startShowTime = DateTime.Parse("15.10.2015 16:00:00");
            GenerateMovieSessionsForMovie(thisMovie, thisCineplex, startShowTime);

            thisMovie = db.Movie.First(movie => movie.MovieID == 10);
            thisCineplex = db.Cineplex.First(cineplex => cineplex.CineplexID == 4);
            startShowTime = DateTime.Parse("15.10.2015 12:00:00");
            GenerateMovieSessionsForMovie(thisMovie, thisCineplex, startShowTime);
//            
            thisMovie = db.Movie.First(movie => movie.MovieID == 5);
            thisCineplex = db.Cineplex.First(cineplex => cineplex.CineplexID == 5);
            startShowTime = DateTime.Parse("15.10.2015 20:00:00");
            GenerateMovieSessionsForMovie(thisMovie, thisCineplex, startShowTime);
            
            thisMovie = db.Movie.First(movie => movie.MovieID == 3);
            thisCineplex = db.Cineplex.First(cineplex => cineplex.CineplexID == 5);
            startShowTime = DateTime.Parse("15.10.2015 16:00:00");
            GenerateMovieSessionsForMovie(thisMovie, thisCineplex, startShowTime);
            
            thisMovie = db.Movie.First(movie => movie.MovieID == 1);
            thisCineplex = db.Cineplex.First(cineplex => cineplex.CineplexID == 5);
            startShowTime = DateTime.Parse("15.10.2015 12:00:00");
            GenerateMovieSessionsForMovie(thisMovie, thisCineplex, startShowTime);

            Debug.WriteLine("Finished to generate..");
        }

        private void GenerateMovieSessionsForMovie(Movie movie, Cineplex cineplex, DateTime dailyShowTime)
        {
            
            Debug.WriteLine("Starting to generate session");

            DateTime endDate = DateTime.Parse("01.11.2015 23:00:00");

            db.CineplexMovie.Add(new CineplexMovie
            {
                Cineplex = cineplex,
                Movie = movie
            });

            while (dailyShowTime.CompareTo(endDate) < 0)
            {
                Debug.WriteLine(dailyShowTime);
                MovieSession movieSession = new MovieSession
                {
                    CineplexID = cineplex.CineplexID,
                    MovieID = movie.MovieID,
                    SessionDateTime = dailyShowTime
                };
                dailyShowTime = dailyShowTime.AddDays(1);
                GenerateSeatsForSession(movieSession);
                db.MovieSession.Add(movieSession);
            }
            Debug.WriteLine("Finished to generate session and starting to save");
            db.SaveChanges();
            Debug.WriteLine("Finished to save");
            
        }


        private void GenerateSeatsForSession(MovieSession session)
        {
            List<String> rows = new List<String>()
            {
                "A",
                "B",
                "C",
                "D",
                "E",
                "F",
                "G"
            };
            foreach (String row in rows)
            {
                for (int i = 0; i <= 10; i++)
                {
                    Seating seat = new Seating
                    {
                        IsTaken = false, 
                        MovieSession = session, 
                        Row = row, 
                        SeatNumber = i,
                        SessionID = session.SessionID,
                     };
                    db.Seating.Add(seat);
                }
            }
        }
    }
}
