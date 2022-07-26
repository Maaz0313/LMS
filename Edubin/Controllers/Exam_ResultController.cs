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
    public class Exam_ResultController : Controller
    {
        private EdubinEntities db = new EdubinEntities();

        // GET: Exam_Result
        public ActionResult Index()
        {
            var exam_Result = db.Exam_Result.Include(e => e.Exam_Details).Include(e => e.Student_Details);
            return View(exam_Result.ToList());
        }

        // GET: Exam_Result/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam_Result exam_Result = db.Exam_Result.Find(id);
            if (exam_Result == null)
            {
                return HttpNotFound();
            }
            return View(exam_Result);
        }

        // GET: Exam_Result/Create
        public ActionResult Create()
        {
            ViewBag.Exam = new SelectList(db.Exam_Details, "Exam_Id", "Course");
            ViewBag.Student = new SelectList(db.Student_Details, "Std_Id", "C_Name");
            return View();
        }

        // POST: Exam_Result/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Result_Id,Exam,Student,Total_Marks,Obtained_Marks")] Exam_Result exam_Result)
        {
            if (ModelState.IsValid)
            {
                db.Exam_Result.Add(exam_Result);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Exam = new SelectList(db.Exam_Details, "Exam_Id", "Course", exam_Result.Exam);
            ViewBag.Student = new SelectList(db.Student_Details, "Std_Id", "C_Name", exam_Result.Student);
            return View(exam_Result);
        }

        // GET: Exam_Result/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam_Result exam_Result = db.Exam_Result.Find(id);
            if (exam_Result == null)
            {
                return HttpNotFound();
            }
            ViewBag.Exam = new SelectList(db.Exam_Details, "Exam_Id", "Course", exam_Result.Exam);
            ViewBag.Student = new SelectList(db.Student_Details, "Std_Id", "C_Name", exam_Result.Student);
            return View(exam_Result);
        }

        // POST: Exam_Result/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Result_Id,Exam,Student,Total_Marks,Obtained_Marks")] Exam_Result exam_Result)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exam_Result).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Exam = new SelectList(db.Exam_Details, "Exam_Id", "Course", exam_Result.Exam);
            ViewBag.Student = new SelectList(db.Student_Details, "Std_Id", "C_Name", exam_Result.Student);
            return View(exam_Result);
        }

        // GET: Exam_Result/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam_Result exam_Result = db.Exam_Result.Find(id);
            if (exam_Result == null)
            {
                return HttpNotFound();
            }
            return View(exam_Result);
        }

        // POST: Exam_Result/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Exam_Result exam_Result = db.Exam_Result.Find(id);
            db.Exam_Result.Remove(exam_Result);
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
