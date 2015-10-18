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

        public ActionResult MovieSessions (string SortOrder, string CurrentFilter, string SearchString, int? page, string Cineplexes)
        {

            ViewBag.CurrentSort = SortOrder;
            ViewBag.TitleSortParm = String.IsNullOrEmpty(SortOrder) ? "title_desc" : "";
            ViewBag.DateSortParm = SortOrder == "Date" ? "date_desc" : "Date";

            ViewBag.Cineplex = Cineplexes;

            if (SearchString != null)
            {
                page = 1;
            }
            else
            {
                SearchString = CurrentFilter;
            }

            var CineplexList = new List<string>();

            var CineplexQry = from c in db.Cineplex
                              orderby c.Location
                              select c.Location;

            CineplexList.AddRange(CineplexQry.Distinct());
            ViewBag.Cineplexes = new SelectList(CineplexList);

            ViewBag.CurrentFilter = SearchString;
            ViewBag.CineplexFilter = Cineplexes;

            var MovieSessions = from ms in db.MovieSession
                                select ms;


            if (!String.IsNullOrEmpty(SearchString))
            {
                MovieSessions = MovieSessions.Where(m => m.CineplexMovie.Movie.Title.Contains(SearchString));

            }

            if (!String.IsNullOrEmpty(Cineplexes))
            {
                MovieSessions = MovieSessions.Where(m => m.CineplexMovie.Cineplex.Location == Cineplexes);

            }
            

            switch (SortOrder)
            {
                case "title_desc":
                    MovieSessions = MovieSessions.OrderByDescending(m => m.CineplexMovie.Movie.Title);
                    break;
                case "Date":
                    MovieSessions = MovieSessions.OrderBy(m => m.SessionDateTime);
                    break;
                case "date_desc":
                    MovieSessions = MovieSessions.OrderByDescending(m => m.SessionDateTime);
                    break;
                default:
                    MovieSessions = MovieSessions.OrderBy(m => m.SessionDateTime);
                    break;
            }

            int PageSize = 5;
            int PageNumber = (page ?? 1);

            return View(MovieSessions.ToPagedList(PageNumber, PageSize));
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

        public ActionResult MovieDetails(int id)
        {
            return View(db.MovieComingSoon.First(movie => movie.MovieComingSoonID == id));
        }
    }
}