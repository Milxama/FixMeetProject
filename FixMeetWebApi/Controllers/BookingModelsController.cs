using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FixMeetWebApi.Models;
using Microsoft.AspNet.Identity;

namespace FixMeetWebApi.Controllers
{
    public class BookingModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BookingModels
        public ActionResult Index()
        {
            var user_id = User.Identity.GetUserId();
            var user = db.Users.Where(u => u.Id == user_id).FirstOrDefault();
            var userRole = user.UserRole;
            var email = user.Email;

            //var offer = db.OfferModels.Where(off => off.OfferID == offerId).FirstOrDefault();
            //var sup_first_name = offer.SupplierFirstName;
            //var sup_last_name = offer.SupplierLastName;

            //var request = db.RequestModels.Where(r => r.UserID == user_id && r.IsOpen == true).FirstOrDefault();
            //var cust_first_name = request.CustomerFirstName;
            //var cust_last_name = request.CustomerLastName;

            //var booking_list = db.BookingModels.Where(booking => booking.CustFirstName == cust_first_name && booking.CustLastName == cust_last_name).ToList();

           
           
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
        public ActionResult Create([Bind(Include = "Description")] BookingModels bookingModels, int offerId)
        {

            var offer = db.OfferModels.Where(off => off.OfferID == offerId).FirstOrDefault();
            var user_id = User.Identity.GetUserId();
            var request = db.RequestModels.Where(req => req.RequestID == offer.RequestID).FirstOrDefault();
            var requestIsOpen = request.IsOpen;
            var request_id = offer.RequestID;

            

            if (ModelState.IsValid)
            {
                bookingModels.BookingDate = DateTime.Now;
                bookingModels.OfferID = offerId;
                bookingModels.RequestID = offer.RequestID;
                bookingModels.SuppFirstName = offer.SupplierFirstName;
                bookingModels.SuppLastName = offer.SupplierLastName;
                bookingModels.CustFirstName = request.CustomerFirstName;
                bookingModels.CustLastName = request.CustomerLastName;
                request.IsOpen = false;

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
        public ActionResult Edit([Bind(Include = "BookingID,BookingDate,Description")] BookingModels bookingModels)
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
