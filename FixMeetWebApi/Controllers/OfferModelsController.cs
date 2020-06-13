﻿using System;
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
    public class OfferModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OfferModels
        public ActionResult Index()
        {
            //var user_id = User.Identity.GetUserId();
            //var request_list = db.RequestModels.Where(req => req.UserID == user_id).ToList();
            //return View(request_list);
            return View(db.OfferModels.ToList());
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
        public ActionResult Create([Bind(Include = "Description")] OfferModels offerModels)
        {
           
            
            
            offerModels.OfferDate = DateTime.Now;
            offerModels.UserID = User.Identity.GetUserId();
            
            var userName = User.Identity.GetUserName();
            var requestId = db.RequestModels.Where(r => r.UserID == "04838a08-2b8f-4dce-ad89-708dc6ebe3f8").FirstOrDefault().RequestID;
            offerModels.RequestID = requestId;
            var request = db.RequestModels.Where(r => r.RequestID == requestId).FirstOrDefault();
            offerModels.Request = request;
            


            //var userName = User.Identity.GetUserName();
            //var requestId = db.Users.Where(u => u.UserName == userName).FirstOrDefault().;
            if (ModelState.IsValid)
            {
                db.OfferModels.Add(offerModels);
                request.Offers.Add(offerModels);
                db.SaveChanges();
                return RedirectToAction("Index");
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
