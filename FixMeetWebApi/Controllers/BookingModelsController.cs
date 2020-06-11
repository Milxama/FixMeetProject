using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FixMeetWebApi.Models;

namespace FixMeetWebApi.Controllers
{
    public class BookingModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BookingModels
        public ActionResult Index()
        {
            return View(db.BookingModels.ToList());
        }

        // GET: BookingModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingModels bookingModels = db.BookingModels.Find(id);
            if (bookingModels == null)
            {
                return HttpNotFound();
            }
            return View(bookingModels);
        }

        // GET: BookingModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookingModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Description,OfferID")] BookingModels bookingModels)
        {
            bookingModels.BookingDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.BookingModels.Add(bookingModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookingModels);
        }

        // GET: BookingModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingModels bookingModels = db.BookingModels.Find(id);
            if (bookingModels == null)
            {
                return HttpNotFound();
            }
            return View(bookingModels);
        }

        // POST: BookingModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookingID,BookingDate,Description,OfferID")] BookingModels bookingModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookingModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookingModels);
        }

        // GET: BookingModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingModels bookingModels = db.BookingModels.Find(id);
            if (bookingModels == null)
            {
                return HttpNotFound();
            }
            return View(bookingModels);
        }

        // POST: BookingModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookingModels bookingModels = db.BookingModels.Find(id);
            db.BookingModels.Remove(bookingModels);
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
