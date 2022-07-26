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
    public class Course_FeeController : Controller
    {
        private EdubinEntities db = new EdubinEntities();

        // GET: Course_Fee
        public ActionResult Index()
        {
            var course_Fee = db.Course_Fee.Include(c => c.Course_Details);
            return View(course_Fee.ToList());
        }

        // GET: Course_Fee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course_Fee course_Fee = db.Course_Fee.Find(id);
            if (course_Fee == null)
            {
                return HttpNotFound();
            }
            return View(course_Fee);
        }

        // GET: Course_Fee/Create
        public ActionResult Create()
        {
            ViewBag.Course = new SelectList(db.Course_Details, "Course_Code", "Course_Name");
            return View();
        }

        // POST: Course_Fee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Course,Fee")] Course_Fee course_Fee)
        {
            if (ModelState.IsValid)
            {
                db.Course_Fee.Add(course_Fee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Course = new SelectList(db.Course_Details, "Course_Code", "Course_Name", course_Fee.Course);
            return View(course_Fee);
        }

        // GET: Course_Fee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course_Fee course_Fee = db.Course_Fee.Find(id);
            if (course_Fee == null)
            {
                return HttpNotFound();
            }
            ViewBag.Course = new SelectList(db.Course_Details, "Course_Code", "Course_Name", course_Fee.Course);
            return View(course_Fee);
        }

        // POST: Course_Fee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Course,Fee")] Course_Fee course_Fee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course_Fee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Course = new SelectList(db.Course_Details, "Course_Code", "Course_Name", course_Fee.Course);
            return View(course_Fee);
        }

        // GET: Course_Fee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course_Fee course_Fee = db.Course_Fee.Find(id);
            if (course_Fee == null)
            {
                return HttpNotFound();
            }
            return View(course_Fee);
        }

        // POST: Course_Fee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course_Fee course_Fee = db.Course_Fee.Find(id);
            db.Course_Fee.Remove(course_Fee);
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
