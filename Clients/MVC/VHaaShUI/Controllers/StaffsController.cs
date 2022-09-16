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
    public class TblStaffsController : Controller
    {
        private T8GymDBEntities db = new T8GymDBEntities();

        // GET: TblStaffs
        public ActionResult Index() 
        {
            var tblStaffs = db.TblStaffs.Include(t => t.TblBloodDetail).Include(t => t.TblCity).Include(t => t.TblGender).Include(t => t.TblState).Include(t => t.TblUser);
            return View(tblStaffs.ToList());
        }

        // GET: TblStaffs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblStaff tblStaff = db.TblStaffs.Find(id);
            if (tblStaff == null)
            {
                return HttpNotFound();
            }
            return View(tblStaff);
        }

        // GET: TblStaffs/Create
        public ActionResult Create()
        {
            ViewBag.BloodId = new SelectList(db.TblBloodDetails, "ID", "BloodGroup");
            ViewBag.CityId = new SelectList(db.TblCities, "ID", "Name");
            ViewBag.GenderID = new SelectList(db.TblGenders, "ID", "Gender");
            ViewBag.StateID = new SelectList(db.TblStates, "ID", "Name");
            ViewBag.UserID = new SelectList(db.TblUsers, "UserId", "UserName");
            return View();
        }

        // POST: TblStaffs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Contact,Experience,Certification,Rating,Age,Achievements,GenderID,BloodId,StateID,CityId,UserID")] TblStaff tblStaff)
        {
            if (ModelState.IsValid)
            {
                db.TblStaffs.Add(tblStaff);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BloodId = new SelectList(db.TblBloodDetails, "ID", "BloodGroup", tblStaff.BloodId);
            ViewBag.CityId = new SelectList(db.TblCities, "ID", "Name", tblStaff.CityId);
            ViewBag.GenderID = new SelectList(db.TblGenders, "ID", "Gender", tblStaff.GenderID);
            ViewBag.StateID = new SelectList(db.TblStates, "ID", "Name", tblStaff.StateID);
            ViewBag.UserID = new SelectList(db.TblUsers, "UserId", "UserName", tblStaff.UserID);
            return View(tblStaff);
        }

        // GET: TblStaffs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblStaff tblStaff = db.TblStaffs.Find(id);
            if (tblStaff == null)
            {
                return HttpNotFound();
            }
            ViewBag.BloodId = new SelectList(db.TblBloodDetails, "ID", "BloodGroup", tblStaff.BloodId);
            ViewBag.CityId = new SelectList(db.TblCities, "ID", "Name", tblStaff.CityId);
            ViewBag.GenderID = new SelectList(db.TblGenders, "ID", "Gender", tblStaff.GenderID);
            ViewBag.StateID = new SelectList(db.TblStates, "ID", "Name", tblStaff.StateID);
            ViewBag.UserID = new SelectList(db.TblUsers, "UserId", "UserName", tblStaff.UserID);
            return View(tblStaff);
        }

        // POST: TblStaffs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Contact,Experience,Certification,Rating,Age,Achievements,GenderID,BloodId,StateID,CityId,UserID")] TblStaff tblStaff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblStaff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BloodId = new SelectList(db.TblBloodDetails, "ID", "BloodGroup", tblStaff.BloodId);
            ViewBag.CityId = new SelectList(db.TblCities, "ID", "Name", tblStaff.CityId);
            ViewBag.GenderID = new SelectList(db.TblGenders, "ID", "Gender", tblStaff.GenderID);
            ViewBag.StateID = new SelectList(db.TblStates, "ID", "Name", tblStaff.StateID);
            ViewBag.UserID = new SelectList(db.TblUsers, "UserId", "UserName", tblStaff.UserID);
            return View(tblStaff);
        }

        // GET: TblStaffs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblStaff tblStaff = db.TblStaffs.Find(id);
            if (tblStaff == null)
            {
                return HttpNotFound();
            }
            return View(tblStaff);
        }

        // POST: TblStaffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblStaff tblStaff = db.TblStaffs.Find(id);
            db.TblStaffs.Remove(tblStaff);
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
