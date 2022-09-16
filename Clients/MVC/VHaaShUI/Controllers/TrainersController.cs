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
    public class TrainersController : Controller
    {
        private T8GymDBEntities db = new T8GymDBEntities();

        // GET: Trainers
        public ActionResult Index()
        {
            var tblTrainers = db.TblTrainers.Include(t => t.TblBloodDetail).Include(t => t.TblCity).Include(t => t.TblGender).Include(t => t.TblState).Include(t => t.TblUser);
            return View(tblTrainers.ToList());
        }

        // GET: Trainers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblTrainer tblTrainer = db.TblTrainers.Find(id);
            if (tblTrainer == null)
            {
                return HttpNotFound();
            }
            return View(tblTrainer);
        }

        // GET: Trainers/Create
        public ActionResult Create()
        {
            ViewBag.BloodId = new SelectList(db.TblBloodDetails, "ID", "BloodGroup");
            ViewBag.CityId = new SelectList(db.TblCities, "ID", "Name");
            ViewBag.GenderID = new SelectList(db.TblGenders, "ID", "Gender");
            ViewBag.StateID = new SelectList(db.TblStates, "ID", "Name");
            ViewBag.UserID = new SelectList(db.TblUsers, "UserId", "UserName");
            return View();
        }

        // POST: Trainers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Contact,Experience,Certification,Rating,Age,Achievements,GenderID,BloodId,StateID,CityId,UserID")] TblTrainer tblTrainer)
        {
            if (ModelState.IsValid)
            {
                db.TblTrainers.Add(tblTrainer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BloodId = new SelectList(db.TblBloodDetails, "ID", "BloodGroup", tblTrainer.BloodId);
            ViewBag.CityId = new SelectList(db.TblCities, "ID", "Name", tblTrainer.CityId);
            ViewBag.GenderID = new SelectList(db.TblGenders, "ID", "Gender", tblTrainer.GenderID);
            ViewBag.StateID = new SelectList(db.TblStates, "ID", "Name", tblTrainer.StateID);
            ViewBag.UserID = new SelectList(db.TblUsers, "UserId", "UserName", tblTrainer.UserID);
            return View(tblTrainer);
        }

        // GET: Trainers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblTrainer tblTrainer = db.TblTrainers.Find(id);
            if (tblTrainer == null)
            {
                return HttpNotFound();
            }
            ViewBag.BloodId = new SelectList(db.TblBloodDetails, "ID", "BloodGroup", tblTrainer.BloodId);
            ViewBag.CityId = new SelectList(db.TblCities, "ID", "Name", tblTrainer.CityId);
            ViewBag.GenderID = new SelectList(db.TblGenders, "ID", "Gender", tblTrainer.GenderID);
            ViewBag.StateID = new SelectList(db.TblStates, "ID", "Name", tblTrainer.StateID);
            ViewBag.UserID = new SelectList(db.TblUsers, "UserId", "UserName", tblTrainer.UserID);
            return View(tblTrainer);
        }

        // POST: Trainers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Contact,Experience,Certification,Rating,Age,Achievements,GenderID,BloodId,StateID,CityId,UserID")] TblTrainer tblTrainer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblTrainer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BloodId = new SelectList(db.TblBloodDetails, "ID", "BloodGroup", tblTrainer.BloodId);
            ViewBag.CityId = new SelectList(db.TblCities, "ID", "Name", tblTrainer.CityId);
            ViewBag.GenderID = new SelectList(db.TblGenders, "ID", "Gender", tblTrainer.GenderID);
            ViewBag.StateID = new SelectList(db.TblStates, "ID", "Name", tblTrainer.StateID);
            ViewBag.UserID = new SelectList(db.TblUsers, "UserId", "UserName", tblTrainer.UserID);
            return View(tblTrainer);
        }

        // GET: Trainers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblTrainer tblTrainer = db.TblTrainers.Find(id);
            if (tblTrainer == null)
            {
                return HttpNotFound();
            }
            return View(tblTrainer);
        }

        // POST: Trainers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblTrainer tblTrainer = db.TblTrainers.Find(id);
            db.TblTrainers.Remove(tblTrainer);
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
