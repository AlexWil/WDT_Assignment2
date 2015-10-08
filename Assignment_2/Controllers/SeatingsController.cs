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
    public class SeatingsController : Controller
    {
        private CineplexEntities db = new CineplexEntities();

        // GET: Seatings
        public ActionResult Index()
        {
            return View(db.Seating.ToList());
        }

        // GET: Seatings/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seating seating = db.Seating.Find(id);
            if (seating == null)
            {
                return HttpNotFound();
            }
            return View(seating);
        }

        // GET: Seatings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Seatings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Seating_ID,Cineplex_ID,Seat_taken")] Seating seating)
        {
            if (ModelState.IsValid)
            {
                db.Seating.Add(seating);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(seating);
        }

        // GET: Seatings/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seating seating = db.Seating.Find(id);
            if (seating == null)
            {
                return HttpNotFound();
            }
            return View(seating);
        }

        // POST: Seatings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Seating_ID,Cineplex_ID,Seat_taken")] Seating seating)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seating).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(seating);
        }

        // GET: Seatings/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seating seating = db.Seating.Find(id);
            if (seating == null)
            {
                return HttpNotFound();
            }
            return View(seating);
        }

        // POST: Seatings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Seating seating = db.Seating.Find(id);
            db.Seating.Remove(seating);
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
