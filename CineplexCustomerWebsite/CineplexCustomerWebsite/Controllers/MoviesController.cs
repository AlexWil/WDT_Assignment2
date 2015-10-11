using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CineplexCustomerWebsite.Models;
using PagedList;

namespace CineplexCustomerWebsite.Controllers
{
    public class MoviesController : Controller
    {

        private DefaultConnection db = new DefaultConnection();

        public ActionResult MovieSessions(string SortOrder, string CurrentFilter, string SearchString, int? page)
        {

            ViewBag.CurrentSort = SortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(SortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = SortOrder == "Date" ? "date_desc" : "Date";

            if (SearchString != null)
            {
                page = 1;
            }
            else
            {
                SearchString = CurrentFilter;
            }

            ViewBag.CurrentFilter = SearchString;

            var MovieSessions = from ms in db.MovieSession
                                select ms;

            if(!String.IsNullOrEmpty(SearchString))
            {
                MovieSessions = MovieSessions.Where(m => m.CineplexMovie.Movie.Title.Contains(SearchString));
            }

            switch (SortOrder)
            {
                case "name_desc":
                    MovieSessions = MovieSessions.OrderBy(t => t.CineplexMovie.Movie.Title);
                    break;
                case "Date":
                    MovieSessions = MovieSessions.OrderBy(d => d.SessionDateTime);
                    break;
                case "date_desc":
                    MovieSessions = MovieSessions.OrderByDescending(d => d.SessionDateTime);
                    break;
                default:
                    MovieSessions = MovieSessions.OrderBy(d => d.SessionDateTime);
                    break;
            }

            int PageSize = 5;
            int PageNumber = (page ?? 1);

            return View(db.MovieSession.OrderBy(d => d.SessionDateTime).ToPagedList(PageNumber, PageSize));
        }

        public ActionResult MovieBooking(int? id)
        {

            if (id == null)
            {
                return RedirectToAction("MovieSessions", new { searchString = "" });
            }

            MovieSession MovieSession = db.MovieSession.Find(id);

            Session["SelectedSession"] = MovieSession;

            if (MovieSession == null)
            {
                return HttpNotFound();
            }

            return View(MovieSession);

        }

        public ActionResult MovieComingSoon()
        {
            return View(db.MovieComingSoon.ToList());
        }
    }
}