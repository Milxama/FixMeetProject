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
    public class StudentModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StudentModels
        public ActionResult Index()
        {
            return View(db.StudentModels.ToList());
        }

        // GET: StudentModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentModels studentModels = db.StudentModels.Find(id);
            if (studentModels == null)
            {
                return HttpNotFound();
            }
            return View(studentModels);
        }

        // GET: StudentModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudId,Name")] StudentModels studentModels)
        {
            if (ModelState.IsValid)
            {
                db.StudentModels.Add(studentModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studentModels);
        }

        // GET: StudentModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentModels studentModels = db.StudentModels.Find(id);
            if (studentModels == null)
            {
                return HttpNotFound();
            }
            return View(studentModels);
        }

        // POST: StudentModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudId,Name")] StudentModels studentModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentModels);
        }

        // GET: StudentModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentModels studentModels = db.StudentModels.Find(id);
            if (studentModels == null)
            {
                return HttpNotFound();
            }
            return View(studentModels);
        }

        // POST: StudentModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentModels studentModels = db.StudentModels.Find(id);
            db.StudentModels.Remove(studentModels);
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
