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
    public class Faculty_DetailsController : Controller
    {
        private EdubinEntities db = new EdubinEntities();

        // GET: Faculty_Details
        public ActionResult Index()
        {
            var faculty_Details = db.Faculty_Details.Include(f => f.User);
            return View(faculty_Details.ToList());
        }

        // GET: Faculty_Details/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculty_Details faculty_Details = db.Faculty_Details.Find(id);
            if (faculty_Details == null)
            {
                return HttpNotFound();
            }
            return View(faculty_Details);
        }

        // GET: Faculty_Details/Create
        public ActionResult Create()
        {
            ViewBag.F_User = new SelectList(db.Users, "ID", "UserName");
            return View();
        }

        // POST: Faculty_Details/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "F_id,F_name,Email,Contact,F_User")] Faculty_Details faculty_Details)
        {
            if (ModelState.IsValid)
            {
                db.Faculty_Details.Add(faculty_Details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.F_User = new SelectList(db.Users, "ID", "UserName", faculty_Details.F_User);
            return View(faculty_Details);
        }

        // GET: Faculty_Details/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculty_Details faculty_Details = db.Faculty_Details.Find(id);
            if (faculty_Details == null)
            {
                return HttpNotFound();
            }
            ViewBag.F_User = new SelectList(db.Users, "ID", "UserName", faculty_Details.F_User);
            return View(faculty_Details);
        }

        // POST: Faculty_Details/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "F_id,F_name,Email,Contact,F_User")] Faculty_Details faculty_Details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(faculty_Details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.F_User = new SelectList(db.Users, "ID", "UserName", faculty_Details.F_User);
            return View(faculty_Details);
        }

        // GET: Faculty_Details/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculty_Details faculty_Details = db.Faculty_Details.Find(id);
            if (faculty_Details == null)
            {
                return HttpNotFound();
            }
            return View(faculty_Details);
        }

        // POST: Faculty_Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Faculty_Details faculty_Details = db.Faculty_Details.Find(id);
            db.Faculty_Details.Remove(faculty_Details);
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
