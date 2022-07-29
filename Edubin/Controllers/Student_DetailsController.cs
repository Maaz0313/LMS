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
    [AllowAnonymous]
    public class Student_DetailsController : Controller
    {
        private EdubinEntities db = new EdubinEntities();

        // GET: Student_Details
        public ActionResult Index()
        {
            var student_Details = db.Student_Details.Include(s => s.Course_Details).Include(s => s.User);
            return View(student_Details.ToList());
        }

        // GET: Student_Details/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Details student_Details = db.Student_Details.Find(id);
            if (student_Details == null)
            {
                return HttpNotFound();
            }
            return View(student_Details);
        }

        // GET: Student_Details/Create
        public ActionResult Create()
        {
            ViewBag.Course = new SelectList(db.Course_Details, "Course_Code", "Course_Name");
            ViewBag.User_ = new SelectList(db.Users, "ID", "UserName");
            return View();
        }

        // POST: Student_Details/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Std_Id,C_Name,D_O_B,Email,Contact,D_O_A,User_,Batch,Course")] Student_Details student_Details)
        {
            if (ModelState.IsValid)
            {
                db.Student_Details.Add(student_Details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Course = new SelectList(db.Course_Details, "Course_Code", "Course_Name", student_Details.Course);
            ViewBag.User_ = new SelectList(db.Users, "ID", "UserName", student_Details.User_);
            return View(student_Details);
        }

        // GET: Student_Details/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Details student_Details = db.Student_Details.Find(id);
            if (student_Details == null)
            {
                return HttpNotFound();
            }
            ViewBag.Course = new SelectList(db.Course_Details, "Course_Code", "Course_Name", student_Details.Course);
            ViewBag.User_ = new SelectList(db.Users, "ID", "UserName", student_Details.User_);
            return View(student_Details);
        }

        // POST: Student_Details/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Std_Id,C_Name,D_O_B,Email,Contact,D_O_A,User_,Batch,Course")] Student_Details student_Details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student_Details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Course = new SelectList(db.Course_Details, "Course_Code", "Course_Name", student_Details.Course);
            ViewBag.User_ = new SelectList(db.Users, "ID", "UserName", student_Details.User_);
            return View(student_Details);
        }

        // GET: Student_Details/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Details student_Details = db.Student_Details.Find(id);
            if (student_Details == null)
            {
                return HttpNotFound();
            }
            return View(student_Details);
        }

        // POST: Student_Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student_Details student_Details = db.Student_Details.Find(id);
            db.Student_Details.Remove(student_Details);
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
