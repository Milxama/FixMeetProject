using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FixMeetWebApi.Models;
using Microsoft.Ajax.Utilities;

namespace FixMeetWebApi.Controllers
{
    public class NegotiationChatModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        

        // GET: NegotiationChatModels
        public ActionResult Index()
        {

            return View(db.NegotiationChatModels.ToList());
        }
        public ActionResult Negotiation(int offerId)
        {
             var chat = db.NegotiationChatModels.Where(c => c.OfferID == offerId).ToList();
            return View(chat);
        }
        // GET: NegotiationChatModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NegotiationChatModels negotiationChatModels = db.NegotiationChatModels.Find(id);
            if (negotiationChatModels == null)
            {
                return HttpNotFound();
            }
            return View(negotiationChatModels);
        }

        // GET: NegotiationChatModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NegotiationChatModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ChatText")] NegotiationChatModels negotiationChatModels, int? offerId)
        {
            negotiationChatModels.ChatDate = DateTime.Now;
            negotiationChatModels.OfferID = (int)offerId;

            var offer = db.OfferModels.Where(off => off.OfferID == offerId).FirstOrDefault();
            negotiationChatModels.SuppId = offer.UserID;

            //var booking = db.BookingModels.Where(book => book.OfferID == offerId).FirstOrDefault();
            //negotiationChatModels.CustId = booking.CustId;

            var req = db.RequestModels.Where(off => off.Offers.Where(o => o.OfferID == offerId).FirstOrDefault().OfferID == offerId).FirstOrDefault();
            negotiationChatModels.CustId = req.UserID;

            if (ModelState.IsValid)
            {
                db.NegotiationChatModels.Add(negotiationChatModels);
                db.SaveChanges();
                return RedirectToAction("Negotiation", new { offerId });
            }

            return View(negotiationChatModels);
        }

        // GET: NegotiationChatModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NegotiationChatModels negotiationChatModels = db.NegotiationChatModels.Find(id);
            if (negotiationChatModels == null)
            {
                return HttpNotFound();
            }
            return View(negotiationChatModels);
        }

        // POST: NegotiationChatModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ChatId,ChatDate,ChatText,OfferID,CustId,SuppId")] NegotiationChatModels negotiationChatModels)
        {



            if (ModelState.IsValid)
            {
                db.Entry(negotiationChatModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(negotiationChatModels);
        }

        // GET: NegotiationChatModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NegotiationChatModels negotiationChatModels = db.NegotiationChatModels.Find(id);
            if (negotiationChatModels == null)
            {
                return HttpNotFound();
            }
            return View(negotiationChatModels);
        }

        // POST: NegotiationChatModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NegotiationChatModels negotiationChatModels = db.NegotiationChatModels.Find(id);
            db.NegotiationChatModels.Remove(negotiationChatModels);
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
