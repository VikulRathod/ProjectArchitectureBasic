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
    public class OfferDetailsController : Controller
    {
        private T8GymDBEntities db = new T8GymDBEntities();

        // GET: OfferDetails
        public ActionResult Index()
        {
            return View(db.TblOfferDetails.ToList());
        }

        // GET: OfferDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblOfferDetail tblOfferDetail = db.TblOfferDetails.Find(id);
            if (tblOfferDetail == null)
            {
                return HttpNotFound();
            }
            return View(tblOfferDetail);
        }

        // GET: OfferDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OfferDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Description,Terms,Discount,CouponCode")] TblOfferDetail tblOfferDetail)
        {
            if (ModelState.IsValid)
            {
                db.TblOfferDetails.Add(tblOfferDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblOfferDetail);
        }

        // GET: OfferDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblOfferDetail tblOfferDetail = db.TblOfferDetails.Find(id);
            if (tblOfferDetail == null)
            {
                return HttpNotFound();
            }
            return View(tblOfferDetail);
        }

        // POST: OfferDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Description,Terms,Discount,CouponCode")] TblOfferDetail tblOfferDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblOfferDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblOfferDetail);
        }

        // GET: OfferDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblOfferDetail tblOfferDetail = db.TblOfferDetails.Find(id);
            if (tblOfferDetail == null)
            {
                return HttpNotFound();
            }
            return View(tblOfferDetail);
        }

        // POST: OfferDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblOfferDetail tblOfferDetail = db.TblOfferDetails.Find(id);
            db.TblOfferDetails.Remove(tblOfferDetail);
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
