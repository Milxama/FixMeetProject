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
    public class RequestsModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RequestsModels
        public ActionResult Index()
        {
            return View(db.RequestsModels.ToList());
        }

        // GET: RequestsModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestsModels requestsModels = db.RequestsModels.Find(id);
            if (requestsModels == null)
            {
                return HttpNotFound();
            }
            return View(requestsModels);
        }

        // GET: RequestsModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RequestsModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RequestID,RequestDate,Category,Description,UserID")] RequestsModels requestsModels)
        {
            if (ModelState.IsValid)
            {
                db.RequestsModels.Add(requestsModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(requestsModels);
        }

        // GET: RequestsModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestsModels requestsModels = db.RequestsModels.Find(id);
            if (requestsModels == null)
            {
                return HttpNotFound();
            }
            return View(requestsModels);
        }

        // POST: RequestsModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RequestID,RequestDate,Category,Description,UserID")] RequestsModels requestsModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(requestsModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(requestsModels);
        }

        // GET: RequestsModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequestsModels requestsModels = db.RequestsModels.Find(id);
            if (requestsModels == null)
            {
                return HttpNotFound();
            }
            return View(requestsModels);
        }

        // POST: RequestsModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RequestsModels requestsModels = db.RequestsModels.Find(id);
            db.RequestsModels.Remove(requestsModels);
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
