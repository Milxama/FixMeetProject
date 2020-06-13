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
    public class RequestModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RequestModels
        public ActionResult Index()
        {
            var user_id = User.Identity.GetUserId();
            var request_list = db.RequestModels.Where(req => req.UserID == user_id).ToList();
            return View(request_list);
            //return View(db.RequestModels.ToList());
        }

        // GET: RequestModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestModels requestModels = db.RequestModels.Find(id);
            if (requestModels == null)
            {
                return HttpNotFound();
            }
            return View(requestModels);
        }

        // GET: RequestModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RequestModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Category,Description")] RequestModels requestModels)
        {
            requestModels.RequestDate = DateTime.Now;
            requestModels.UserID = User.Identity.GetUserId();
            requestModels.IsOpen = true;
            requestModels.Offers = null;
            if (ModelState.IsValid)
            {
                db.RequestModels.Add(requestModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(requestModels);
        }

        // GET: RequestModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestModels requestModels = db.RequestModels.Find(id);
            if (requestModels == null)
            {
                return HttpNotFound();
            }
            return View(requestModels);
        }

        // POST: RequestModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RequestID,RequestDate,Category,Description,UserID")] RequestModels requestModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(requestModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(requestModels);
        }

        // GET: RequestModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestModels requestModels = db.RequestModels.Find(id);
            if (requestModels == null)
            {
                return HttpNotFound();
            }
            return View(requestModels);
        }

        // POST: RequestModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RequestModels requestModels = db.RequestModels.Find(id);
            db.RequestModels.Remove(requestModels);
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
