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
    public class OwnersController : Controller
    {
        private T8GymDBEntities db = new T8GymDBEntities();

        // GET: Owners
        public ActionResult Index()
        {
            var tblOwners = db.TblOwners.Include(t => t.TblBloodDetail).Include(t => t.TblCity).Include(t => t.TblState).Include(t => t.TblUser);
            return View(tblOwners.ToList());
        }

        // GET: Owners/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblOwner tblOwner = db.TblOwners.Find(id);
            if (tblOwner == null)
            {
                return HttpNotFound();
            }
            return View(tblOwner);
        }

        // GET: Owners/Create
        public ActionResult Create()
        {
            ViewBag.BloodId = new SelectList(db.TblBloodDetails, "ID", "BloodGroup");
            ViewBag.CityId = new SelectList(db.TblCities, "ID", "Name");
            ViewBag.StateID = new SelectList(db.TblStates, "ID", "Name");
            ViewBag.UserID = new SelectList(db.TblUsers, "UserId", "UserName");
            return View();
        }

        // POST: Owners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Contact,Email,BloodId,StateID,CityId,UserID")] TblOwner tblOwner)
        {
            if (ModelState.IsValid)
            {
                db.TblOwners.Add(tblOwner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BloodId = new SelectList(db.TblBloodDetails, "ID", "BloodGroup", tblOwner.BloodId);
            ViewBag.CityId = new SelectList(db.TblCities, "ID", "Name", tblOwner.CityId);
            ViewBag.StateID = new SelectList(db.TblStates, "ID", "Name", tblOwner.StateID);
            ViewBag.UserID = new SelectList(db.TblUsers, "UserId", "UserName", tblOwner.UserID);
            return View(tblOwner);
        }

        // GET: Owners/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblOwner tblOwner = db.TblOwners.Find(id);
            if (tblOwner == null)
            {
                return HttpNotFound();
            }
            ViewBag.BloodId = new SelectList(db.TblBloodDetails, "ID", "BloodGroup", tblOwner.BloodId);
            ViewBag.CityId = new SelectList(db.TblCities, "ID", "Name", tblOwner.CityId);
            ViewBag.StateID = new SelectList(db.TblStates, "ID", "Name", tblOwner.StateID);
            ViewBag.UserID = new SelectList(db.TblUsers, "UserId", "UserName", tblOwner.UserID);
            return View(tblOwner);
        }

        // POST: Owners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Contact,Email,BloodId,StateID,CityId,UserID")] TblOwner tblOwner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblOwner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BloodId = new SelectList(db.TblBloodDetails, "ID", "BloodGroup", tblOwner.BloodId);
            ViewBag.CityId = new SelectList(db.TblCities, "ID", "Name", tblOwner.CityId);
            ViewBag.StateID = new SelectList(db.TblStates, "ID", "Name", tblOwner.StateID);
            ViewBag.UserID = new SelectList(db.TblUsers, "UserId", "UserName", tblOwner.UserID);
            return View(tblOwner);
        }

        // GET: Owners/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblOwner tblOwner = db.TblOwners.Find(id);
            if (tblOwner == null)
            {
                return HttpNotFound();
            }
            return View(tblOwner);
        }

        // POST: Owners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblOwner tblOwner = db.TblOwners.Find(id);
            db.TblOwners.Remove(tblOwner);
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
