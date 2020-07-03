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
    public class RatingModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RatingModels
        public ActionResult Index()
        {
            return View(db.RatingModels.ToList());
        }

        // GET: RatingModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RatingModels ratingModels = db.RatingModels.Find(id);
            if (ratingModels == null)
            {
                return HttpNotFound();
            }
            return View(ratingModels);
        }

        // GET: RatingModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RatingModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RatingId,RatingDate,Comment,Rating,BookingId,CustId,SuppId,CustFirstName,CustLastName,SuppFirstName,SuppLastName")] RatingModels ratingModels)
        {
            if (ModelState.IsValid)
            {
                db.RatingModels.Add(ratingModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ratingModels);
        }

        // GET: RatingModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RatingModels ratingModels = db.RatingModels.Find(id);
            if (ratingModels == null)
            {
                return HttpNotFound();
            }
            return View(ratingModels);
        }

        // POST: RatingModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RatingId,RatingDate,Comment,Rating,BookingId,CustId,SuppId,CustFirstName,CustLastName,SuppFirstName,SuppLastName")] RatingModels ratingModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ratingModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ratingModels);
        }

        // GET: RatingModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RatingModels ratingModels = db.RatingModels.Find(id);
            if (ratingModels == null)
            {
                return HttpNotFound();
            }
            return View(ratingModels);
        }

        // POST: RatingModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RatingModels ratingModels = db.RatingModels.Find(id);
            db.RatingModels.Remove(ratingModels);
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
