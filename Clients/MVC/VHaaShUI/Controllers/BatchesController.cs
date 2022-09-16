using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VHaaSh.API.Modals.Database_Models;

namespace VHaaSh.WEB.Controllers
{
    public class BatchesController : Controller
    {
        private T8GymDBEntities db = new T8GymDBEntities();

        // GET: Batches
        public ActionResult Index()
        {
            var tblBatches = db.TblBatches.Include(t => t.TblStaff);
            return View(tblBatches.ToList());
        }

        // GET: Batches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblBatch tblBatch = db.TblBatches.Find(id);
            if (tblBatch == null)
            {
                return HttpNotFound();
            }
            return View(tblBatch);
        }

        // GET: Batches/Create
        public ActionResult Create()
        {
            ViewBag.TrainierId = new SelectList(db.TblStaffs, "ID", "Name");
            return View();
        }

        // POST: Batches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Activity,Duration__hr_,WeekDay,TrainierId")] TblBatch tblBatch)
        {
            if (ModelState.IsValid)
            {
                db.TblBatches.Add(tblBatch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TrainierId = new SelectList(db.TblStaffs, "ID", "Name", tblBatch.TrainierId);
            return View(tblBatch);
        }

        // GET: Batches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblBatch tblBatch = db.TblBatches.Find(id);
            if (tblBatch == null)
            {
                return HttpNotFound();
            }
            ViewBag.TrainierId = new SelectList(db.TblStaffs, "ID", "Name", tblBatch.TrainierId);
            return View(tblBatch);
        }

        // POST: Batches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Activity,Duration__hr_,WeekDay,TrainierId")] TblBatch tblBatch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblBatch).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TrainierId = new SelectList(db.TblStaffs, "ID", "Name", tblBatch.TrainierId);
            return View(tblBatch);
        }

        // GET: Batches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblBatch tblBatch = db.TblBatches.Find(id);
            if (tblBatch == null)
            {
                return HttpNotFound();
            }
            return View(tblBatch);
        }

        // POST: Batches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblBatch tblBatch = db.TblBatches.Find(id);
            db.TblBatches.Remove(tblBatch);
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
