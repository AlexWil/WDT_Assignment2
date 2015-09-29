using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment_2.Models;

namespace Assignment_2.Controllers
{
    public class MovieSessionsController : Controller
    {
        private Assignment_2Entities db = new Assignment_2Entities();

        // GET: MovieSessions
        public ActionResult Index(string sessions, string searchString)
        {
            var movieSessions = db.MovieSessions.Include(m => m.Cineplex).Include(m => m.Movie);
            if (!String.IsNullOrEmpty(sessions))
                if (sessions != ("All"))
                {
                    {
                        movieSessions = movieSessions.Where(s => s.Cineplex.Location.Contains(sessions));
                    }
                }
            if (!String.IsNullOrEmpty(searchString))
            {
                movieSessions = movieSessions.Where(s => s.Movie.Title.Contains(searchString));
            }
            ViewBag.Sessions = new SelectList(db.Cineplexes.Select(c => c.Location));
            return View(movieSessions.ToList());
        }

        // GET: MovieSessions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieSession movieSession = db.MovieSessions.Find(id);
            if (movieSession == null)
            {
                return HttpNotFound();
            }
            return View(movieSession);
        }

        // GET: MovieSessions/Create
        public ActionResult Create()
        {
            ViewBag.CineplexID = new SelectList(db.Cineplexes, "CineplexID", "Location");
            ViewBag.MovieID = new SelectList(db.Movies, "MovieID", "Title");
            return View();
        }

        // POST: MovieSessions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SessionID,CineplexID,MovieID,Time")] MovieSession movieSession)
        {
            if (ModelState.IsValid)
            {
                db.MovieSessions.Add(movieSession);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CineplexID = new SelectList(db.Cineplexes, "CineplexID", "Location", movieSession.CineplexID);
            ViewBag.MovieID = new SelectList(db.Movies, "MovieID", "Title", movieSession.MovieID);
            return View(movieSession);
        }

        // GET: MovieSessions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieSession movieSession = db.MovieSessions.Find(id);
            if (movieSession == null)
            {
                return HttpNotFound();
            }
            ViewBag.CineplexID = new SelectList(db.Cineplexes, "CineplexID", "Location", movieSession.CineplexID);
            ViewBag.MovieID = new SelectList(db.Movies, "MovieID", "Title", movieSession.MovieID);
            return View(movieSession);
        }

        // POST: MovieSessions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SessionID,CineplexID,MovieID,Time")] MovieSession movieSession)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movieSession).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CineplexID = new SelectList(db.Cineplexes, "CineplexID", "Location", movieSession.CineplexID);
            ViewBag.MovieID = new SelectList(db.Movies, "MovieID", "Title", movieSession.MovieID);
            return View(movieSession);
        }

        // GET: MovieSessions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieSession movieSession = db.MovieSessions.Find(id);
            if (movieSession == null)
            {
                return HttpNotFound();
            }
            return View(movieSession);
        }

        // POST: MovieSessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MovieSession movieSession = db.MovieSessions.Find(id);
            db.MovieSessions.Remove(movieSession);
            db.SaveChanges();
            return RedirectToAction("Index");
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
