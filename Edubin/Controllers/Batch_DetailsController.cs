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
    public class Batch_DetailsController : Controller
    {
        private EdubinEntities db = new EdubinEntities();

        // GET: Batch_Details
        public ActionResult Index()
        {
            var batch_Details = db.Batch_Details.Include(b => b.Faculty_Details);
            return View(batch_Details.ToList());
        }

        // GET: Batch_Details/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Batch_Details batch_Details = db.Batch_Details.Find(id);
            if (batch_Details == null)
            {
                return HttpNotFound();
            }
            return View(batch_Details);
        }

        // GET: Batch_Details/Create
        public ActionResult Create()
        {
            ViewBag.Faculty = new SelectList(db.Faculty_Details, "F_id", "F_name");
            return View();
        }

        // POST: Batch_Details/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Batch_Code,Batch_Start,Batch_end,Timing,Faculty")] Batch_Details batch_Details)
        {
            if (ModelState.IsValid)
            {
                db.Batch_Details.Add(batch_Details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Faculty = new SelectList(db.Faculty_Details, "F_id", "F_name", batch_Details.Faculty);
            return View(batch_Details);
        }

        // GET: Batch_Details/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Batch_Details batch_Details = db.Batch_Details.Find(id);
            if (batch_Details == null)
            {
                return HttpNotFound();
            }
            ViewBag.Faculty = new SelectList(db.Faculty_Details, "F_id", "F_name", batch_Details.Faculty);
            return View(batch_Details);
        }

        // POST: Batch_Details/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Batch_Code,Batch_Start,Batch_end,Timing,Faculty")] Batch_Details batch_Details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(batch_Details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Faculty = new SelectList(db.Faculty_Details, "F_id", "F_name", batch_Details.Faculty);
            return View(batch_Details);
        }

        // GET: Batch_Details/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Batch_Details batch_Details = db.Batch_Details.Find(id);
            if (batch_Details == null)
            {
                return HttpNotFound();
            }
            return View(batch_Details);
        }

        // POST: Batch_Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Batch_Details batch_Details = db.Batch_Details.Find(id);
            db.Batch_Details.Remove(batch_Details);
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
