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
    
    public class CorporateMembershipsController : Controller
    {
        private T8GymDBEntities db = new T8GymDBEntities();

        // GET: CorporateMemberships
        public ActionResult Index()
        {
            return View(db.TblCorporateMemberships.ToList());
        }

        // GET: CorporateMemberships/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblCorporateMembership tblCorporateMembership = db.TblCorporateMemberships.Find(id);
            if (tblCorporateMembership == null)
            {
                return HttpNotFound();
            }
            return View(tblCorporateMembership);
        }

        // GET: CorporateMemberships/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CorporateMemberships/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CompanyName,MemberCount,Duration__mm_,Discount")] TblCorporateMembership tblCorporateMembership)
        {
            if (ModelState.IsValid)
            {
                db.TblCorporateMemberships.Add(tblCorporateMembership);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblCorporateMembership);
        }

        // GET: CorporateMemberships/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblCorporateMembership tblCorporateMembership = db.TblCorporateMemberships.Find(id);
            if (tblCorporateMembership == null)
            {
                return HttpNotFound();
            }
            return View(tblCorporateMembership);
        }

        // POST: CorporateMemberships/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CompanyName,MemberCount,Duration__mm_,Discount")] TblCorporateMembership tblCorporateMembership)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblCorporateMembership).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblCorporateMembership);
        }

        // GET: CorporateMemberships/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblCorporateMembership tblCorporateMembership = db.TblCorporateMemberships.Find(id);
            if (tblCorporateMembership == null)
            {
                return HttpNotFound();
            }
            return View(tblCorporateMembership);
        }

        // POST: CorporateMemberships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblCorporateMembership tblCorporateMembership = db.TblCorporateMemberships.Find(id);
            db.TblCorporateMemberships.Remove(tblCorporateMembership);
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
