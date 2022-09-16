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
    public class HolidayDetailsController : Controller
    {
        private T8GymDBEntities db = new T8GymDBEntities();

        // GET: HolidayDetails
        public ActionResult Index()
        {
            return View(db.TblHolidayDetails.ToList());
        }

        // GET: HolidayDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblHolidayDetail tblHolidayDetail = db.TblHolidayDetails.Find(id);
            if (tblHolidayDetail == null)
            {
                return HttpNotFound();
            }
            return View(tblHolidayDetail);
        }

        // GET: HolidayDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HolidayDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Date,Reason")] TblHolidayDetail tblHolidayDetail)
        {
            if (ModelState.IsValid)
            {
                db.TblHolidayDetails.Add(tblHolidayDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblHolidayDetail);
        }

        // GET: HolidayDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblHolidayDetail tblHolidayDetail = db.TblHolidayDetails.Find(id);
            if (tblHolidayDetail == null)
            {
                return HttpNotFound();
            }
            return View(tblHolidayDetail);
        }

        // POST: HolidayDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Date,Reason")] TblHolidayDetail tblHolidayDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblHolidayDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblHolidayDetail);
        }

        // GET: HolidayDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblHolidayDetail tblHolidayDetail = db.TblHolidayDetails.Find(id);
            if (tblHolidayDetail == null)
            {
                return HttpNotFound();
            }
            return View(tblHolidayDetail);
        }

        // POST: HolidayDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblHolidayDetail tblHolidayDetail = db.TblHolidayDetails.Find(id);
            db.TblHolidayDetails.Remove(tblHolidayDetail);
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
