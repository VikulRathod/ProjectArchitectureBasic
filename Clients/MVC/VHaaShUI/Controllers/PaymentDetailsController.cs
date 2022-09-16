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
    public class PaymentDetailsController : Controller
    {
        private T8GymDBEntities db = new T8GymDBEntities();

        // GET: PaymentDetails
        public ActionResult Index()
        {
            var tblPaymentDetails = db.TblPaymentDetails.Include(t => t.TblMember).Include(t => t.TblMembership).Include(t => t.TblPaymentMode);
            return View(tblPaymentDetails.ToList());
        }

        // GET: PaymentDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblPaymentDetail tblPaymentDetail = db.TblPaymentDetails.Find(id);
            if (tblPaymentDetail == null)
            {
                return HttpNotFound();
            }
            return View(tblPaymentDetail);
        }

        // GET: PaymentDetails/Create
        public ActionResult Create()
        {
            ViewBag.MemberID = new SelectList(db.TblMembers, "ID", "Name");
            ViewBag.MembershipID = new SelectList(db.TblMemberships, "ID", "Name");
            ViewBag.PaymentModeID = new SelectList(db.TblPaymentModes, "ID", "PaymentMode");
            return View();
        }

        // POST: PaymentDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ReceiverName,PaidAmount,MemberID,MembershipID,PaymentModeID")] TblPaymentDetail tblPaymentDetail)
        {
            if (ModelState.IsValid)
            {
                db.TblPaymentDetails.Add(tblPaymentDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MemberID = new SelectList(db.TblMembers, "ID", "Name", tblPaymentDetail.MemberID);
            ViewBag.MembershipID = new SelectList(db.TblMemberships, "ID", "Name", tblPaymentDetail.MembershipID);
            ViewBag.PaymentModeID = new SelectList(db.TblPaymentModes, "ID", "PaymentMode", tblPaymentDetail.PaymentModeID);
            return View(tblPaymentDetail);
        }

        // GET: PaymentDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblPaymentDetail tblPaymentDetail = db.TblPaymentDetails.Find(id);
            if (tblPaymentDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.MemberID = new SelectList(db.TblMembers, "ID", "Name", tblPaymentDetail.MemberID);
            ViewBag.MembershipID = new SelectList(db.TblMemberships, "ID", "Name", tblPaymentDetail.MembershipID);
            ViewBag.PaymentModeID = new SelectList(db.TblPaymentModes, "ID", "PaymentMode", tblPaymentDetail.PaymentModeID);
            return View(tblPaymentDetail);
        }

        // POST: PaymentDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ReceiverName,PaidAmount,MemberID,MembershipID,PaymentModeID")] TblPaymentDetail tblPaymentDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblPaymentDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MemberID = new SelectList(db.TblMembers, "ID", "Name", tblPaymentDetail.MemberID);
            ViewBag.MembershipID = new SelectList(db.TblMemberships, "ID", "Name", tblPaymentDetail.MembershipID);
            ViewBag.PaymentModeID = new SelectList(db.TblPaymentModes, "ID", "PaymentMode", tblPaymentDetail.PaymentModeID);
            return View(tblPaymentDetail);
        }

        // GET: PaymentDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblPaymentDetail tblPaymentDetail = db.TblPaymentDetails.Find(id);
            if (tblPaymentDetail == null)
            {
                return HttpNotFound();
            }
            return View(tblPaymentDetail);
        }

        // POST: PaymentDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblPaymentDetail tblPaymentDetail = db.TblPaymentDetails.Find(id);
            db.TblPaymentDetails.Remove(tblPaymentDetail);
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
