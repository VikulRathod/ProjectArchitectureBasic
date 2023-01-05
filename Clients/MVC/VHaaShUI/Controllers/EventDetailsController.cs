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
    public class EventDetailsController : Controller
    {
        private T8GymDBEntities db = new T8GymDBEntities();

        // GET: EventDetails
        public ActionResult Index()
        {
            return View(db.TblEventDetails.ToList());
        }

        // GET: EventDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblEventDetail tblEventDetail = db.TblEventDetails.Find(id);
            if (tblEventDetail == null)
            {
                return HttpNotFound();
            }
            return View(tblEventDetail);
        }

        // GET: EventDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Date,Time,Guest,Description")] TblEventDetail tblEventDetail)
        {
            if (ModelState.IsValid)
            {
                db.TblEventDetails.Add(tblEventDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblEventDetail);
        }

        // GET: EventDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblEventDetail tblEventDetail = db.TblEventDetails.Find(id);
            if (tblEventDetail == null)
            {
                return HttpNotFound();
            }
            return View(tblEventDetail);
        }

        // POST: EventDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Date,Time,Guest,Description")] TblEventDetail tblEventDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblEventDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblEventDetail);
        }

        // GET: EventDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblEventDetail tblEventDetail = db.TblEventDetails.Find(id);
            if (tblEventDetail == null)
            {
                return HttpNotFound();
            }
            return View(tblEventDetail);
        }

        // POST: EventDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblEventDetail tblEventDetail = db.TblEventDetails.Find(id);
            db.TblEventDetails.Remove(tblEventDetail);
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
