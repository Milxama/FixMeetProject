﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.HtmlControls;
using FixMeetWebApi.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;

namespace FixMeetWebApi.Controllers
{
    public class OfferModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OfferModels

        public ActionResult Index(int? requestId)
        {
            var user_id = User.Identity.GetUserId();
            var user = db.Users.Where(u => u.Id == user_id).FirstOrDefault();
           
            var userRole = db.Users.Where(u => u.Id == user_id).FirstOrDefault().UserRole;

            if (userRole == UserRole.Supplier)
            {
                var offer = db.OfferModels.Where(off => off.UserID == user_id && off.Request.IsOpen).ToList();
                return View(offer);
            }
            if (userRole == UserRole.Customer)
            {
                var offer = db.OfferModels.Where(off => off.RequestID == requestId).ToList();
                return View(offer);

            }

            return View(db.OfferModels.ToList());
        }

        public ActionResult ClosedOffers()
        {
            var user_id = User.Identity.GetUserId();
            var user = db.Users.Where(u => u.Id == user_id).FirstOrDefault();
            var userRole = user.UserRole;

            if (userRole == UserRole.Supplier)
            {
                var offer_list = db.OfferModels.Where(off => off.UserID == user_id && off.Request.IsOpen == false).ToList();
                return View(offer_list);
            }


            return View(db.RequestModels.ToList());
        }

        // GET: OfferModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfferModels offerModels = db.OfferModels.Find(id);
            if (offerModels == null)
            {
                return HttpNotFound();
            }
            return View(offerModels);
        }

        // GET: OfferModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OfferModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Description, Cost, PhoneNumber")] OfferModels offerModels, int requestId)
        {
            var user_id = User.Identity.GetUserId();
            var user = db.Users.Where(u => u.Id == user_id).FirstOrDefault();
            var user_role = user.UserRole;
            var count = db.OfferModels.Where(off => off.RequestID == requestId && off.UserID == user_id).ToList().Count();

            var req = db.RequestModels.Where(r => r.RequestID == requestId).FirstOrDefault();
            var customer_first = req.CustomerFirstName;
            var customer_last = req.CustomerLastName;

            var offer_count = db.OfferModels.Where(off => off.UserID == user_id && off.RequestID == requestId).Count();
            if (offer_count > 0)
            {
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid && user_role == UserRole.Supplier)
            {
                offerModels.OfferDate = DateTime.Now;
                offerModels.UserID = user_id;
                offerModels.SupplierFirstName = user.FirstName;
                offerModels.SupplierLastName = user.LastName;
                offerModels.CustomerFirstName = customer_first;
                offerModels.CustomerLastName = customer_last;
                offerModels.RequestID = requestId;
                offerModels.Request = req;
                db.OfferModels.Add(offerModels);
                req.Offers.Add(offerModels);
                db.SaveChanges();
                return RedirectToAction("Index", new { offerModels.RequestID }) ;
            }

            return View(offerModels);
        }

        // GET: OfferModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfferModels offerModels = db.OfferModels.Find(id);
            if (offerModels == null)
            {
                return HttpNotFound();
            }
            return View(offerModels);
        }

        // POST: OfferModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OfferID,OfferDate,Description,UserID,RequestID")] OfferModels offerModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(offerModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(offerModels);
        }

        // GET: OfferModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfferModels offerModels = db.OfferModels.Find(id);
            if (offerModels == null)
            {
                return HttpNotFound();
            }
            return View(offerModels);
        }

        // POST: OfferModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OfferModels offerModels = db.OfferModels.Find(id);
            db.OfferModels.Remove(offerModels);
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
