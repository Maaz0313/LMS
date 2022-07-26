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
    public class Exam_DetailsController : Controller
    {
        private EdubinEntities db = new EdubinEntities();

        // GET: Exam_Details
        public ActionResult Index()
        {
            var exam_Details = db.Exam_Details.Include(e => e.Course_Details).Include(e => e.Student_Details);
            return View(exam_Details.ToList());
        }

        // GET: Exam_Details/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam_Details exam_Details = db.Exam_Details.Find(id);
            if (exam_Details == null)
            {
                return HttpNotFound();
            }
            return View(exam_Details);
        }

        // GET: Exam_Details/Create
        public ActionResult Create()
        {
            ViewBag.Course = new SelectList(db.Course_Details, "Course_Code", "Course_Name");
            ViewBag.Student = new SelectList(db.Student_Details, "Std_Id", "C_Name");
            return View();
        }

        // POST: Exam_Details/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Exam_Id,Exam_Date,Exam_Time,Course,Student")] Exam_Details exam_Details)
        {
            if (ModelState.IsValid)
            {
                db.Exam_Details.Add(exam_Details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Course = new SelectList(db.Course_Details, "Course_Code", "Course_Name", exam_Details.Course);
            ViewBag.Student = new SelectList(db.Student_Details, "Std_Id", "C_Name", exam_Details.Student);
            return View(exam_Details);
        }

        // GET: Exam_Details/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam_Details exam_Details = db.Exam_Details.Find(id);
            if (exam_Details == null)
            {
                return HttpNotFound();
            }
            ViewBag.Course = new SelectList(db.Course_Details, "Course_Code", "Course_Name", exam_Details.Course);
            ViewBag.Student = new SelectList(db.Student_Details, "Std_Id", "C_Name", exam_Details.Student);
            return View(exam_Details);
        }

        // POST: Exam_Details/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Exam_Id,Exam_Date,Exam_Time,Course,Student")] Exam_Details exam_Details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exam_Details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Course = new SelectList(db.Course_Details, "Course_Code", "Course_Name", exam_Details.Course);
            ViewBag.Student = new SelectList(db.Student_Details, "Std_Id", "C_Name", exam_Details.Student);
            return View(exam_Details);
        }

        // GET: Exam_Details/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam_Details exam_Details = db.Exam_Details.Find(id);
            if (exam_Details == null)
            {
                return HttpNotFound();
            }
            return View(exam_Details);
        }

        // POST: Exam_Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Exam_Details exam_Details = db.Exam_Details.Find(id);
            db.Exam_Details.Remove(exam_Details);
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
