using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Edubin.Models;

namespace Edubin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class Course_DetailsController : Controller
    {
        private EdubinEntities db = new EdubinEntities();

        // GET: Course_Details
        public ActionResult Index()
        {
            var course_Details = db.Course_Details.Include(c => c.Batch_Details);
            return View(course_Details.ToList());
        }

        // GET: Course_Details/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course_Details course_Details = db.Course_Details.Find(id);
            if (course_Details == null)
            {
                return HttpNotFound();
            }
            return View(course_Details);
        }

        // GET: Course_Details/Create
        public ActionResult Create()
        {
            ViewBag.Batch = new SelectList(db.Batch_Details, "Batch_Code", "Batch_Code");
            return View();
        }

        // POST: Course_Details/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Course_Code,Course_Name,Course_fee,Batch")] Course_Details course_Details)
        {
            if (ModelState.IsValid)
            {
                db.Course_Details.Add(course_Details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Batch = new SelectList(db.Batch_Details, "Batch_Code", "Batch_Code", course_Details.Batch);
            return View(course_Details);
        }

        // GET: Course_Details/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course_Details course_Details = db.Course_Details.Find(id);
            if (course_Details == null)
            {
                return HttpNotFound();
            }
            ViewBag.Batch = new SelectList(db.Batch_Details, "Batch_Code", "Batch_Code", course_Details.Batch);
            return View(course_Details);
        }

        // POST: Course_Details/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Course_Code,Course_Name,Course_fee,Batch")] Course_Details course_Details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course_Details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Batch = new SelectList(db.Batch_Details, "Batch_Code", "Batch_Code", course_Details.Batch);
            return View(course_Details);
        }

        // GET: Course_Details/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course_Details course_Details = db.Course_Details.Find(id);
            if (course_Details == null)
            {
                return HttpNotFound();
            }
            return View(course_Details);
        }

        // POST: Course_Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Course_Details course_Details = db.Course_Details.Find(id);
            db.Course_Details.Remove(course_Details);
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
