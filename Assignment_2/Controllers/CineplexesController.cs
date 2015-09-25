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
    public class CineplexesController : Controller
    {
        private Assignment_2Entities db = new Assignment_2Entities();

        // GET: Cineplexes
        public ActionResult Index()
        {
            return View(db.Cineplexes.ToList());
        }

        // GET: Cineplexes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cineplex cineplex = db.Cineplexes.Find(id);
            if (cineplex == null)
            {
                return HttpNotFound();
            }
            return View(cineplex);
        }

        // GET: Cineplexes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cineplexes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CineplexID,Location,ShortDescription,LongDescription,ImageUrl")] Cineplex cineplex)
        {
            if (ModelState.IsValid)
            {
                db.Cineplexes.Add(cineplex);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cineplex);
        }

        // GET: Cineplexes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cineplex cineplex = db.Cineplexes.Find(id);
            if (cineplex == null)
            {
                return HttpNotFound();
            }
            return View(cineplex);
        }

        // POST: Cineplexes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CineplexID,Location,ShortDescription,LongDescription,ImageUrl")] Cineplex cineplex)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cineplex).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cineplex);
        }

        // GET: Cineplexes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cineplex cineplex = db.Cineplexes.Find(id);
            if (cineplex == null)
            {
                return HttpNotFound();
            }
            return View(cineplex);
        }

        // POST: Cineplexes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cineplex cineplex = db.Cineplexes.Find(id);
            db.Cineplexes.Remove(cineplex);
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
