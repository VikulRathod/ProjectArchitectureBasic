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
    public class NutritionistsController : Controller
    {
        private T8GymDBEntities db = new T8GymDBEntities();

        // GET: Nutritionists
        public ActionResult Index()
        {
            var tblNutritionists = db.TblNutritionists.Include(t => t.TblBloodDetail).Include(t => t.TblCity).Include(t => t.TblGender).Include(t => t.TblState).Include(t => t.TblUser);
            return View(tblNutritionists.ToList());
        }

        // GET: Nutritionists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblNutritionist tblNutritionist = db.TblNutritionists.Find(id);
            if (tblNutritionist == null)
            {
                return HttpNotFound();
            }
            return View(tblNutritionist);
        }

        // GET: Nutritionists/Create
        public ActionResult Create()
        {
            ViewBag.BloodId = new SelectList(db.TblBloodDetails, "ID", "BloodGroup");
            ViewBag.CityId = new SelectList(db.TblCities, "ID", "Name");
            ViewBag.GenderID = new SelectList(db.TblGenders, "ID", "Gender");
            ViewBag.StateID = new SelectList(db.TblStates, "ID", "Name");
            ViewBag.UserID = new SelectList(db.TblUsers, "UserId", "UserName");
            return View();
        }

        // POST: Nutritionists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Contact,Experience,Certification,Rating,Age,Achievements,GenderID,BloodId,StateID,CityId,UserID")] TblNutritionist tblNutritionist)
        {
            if (ModelState.IsValid)
            {
                db.TblNutritionists.Add(tblNutritionist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BloodId = new SelectList(db.TblBloodDetails, "ID", "BloodGroup", tblNutritionist.BloodId);
            ViewBag.CityId = new SelectList(db.TblCities, "ID", "Name", tblNutritionist.CityId);
            ViewBag.GenderID = new SelectList(db.TblGenders, "ID", "Gender", tblNutritionist.GenderID);
            ViewBag.StateID = new SelectList(db.TblStates, "ID", "Name", tblNutritionist.StateID);
            ViewBag.UserID = new SelectList(db.TblUsers, "UserId", "UserName", tblNutritionist.UserID);
            return View(tblNutritionist);
        }

        // GET: Nutritionists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblNutritionist tblNutritionist = db.TblNutritionists.Find(id);
            if (tblNutritionist == null)
            {
                return HttpNotFound();
            }
            ViewBag.BloodId = new SelectList(db.TblBloodDetails, "ID", "BloodGroup", tblNutritionist.BloodId);
            ViewBag.CityId = new SelectList(db.TblCities, "ID", "Name", tblNutritionist.CityId);
            ViewBag.GenderID = new SelectList(db.TblGenders, "ID", "Gender", tblNutritionist.GenderID);
            ViewBag.StateID = new SelectList(db.TblStates, "ID", "Name", tblNutritionist.StateID);
            ViewBag.UserID = new SelectList(db.TblUsers, "UserId", "UserName", tblNutritionist.UserID);
            return View(tblNutritionist);
        }

        // POST: Nutritionists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Contact,Experience,Certification,Rating,Age,Achievements,GenderID,BloodId,StateID,CityId,UserID")] TblNutritionist tblNutritionist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblNutritionist).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BloodId = new SelectList(db.TblBloodDetails, "ID", "BloodGroup", tblNutritionist.BloodId);
            ViewBag.CityId = new SelectList(db.TblCities, "ID", "Name", tblNutritionist.CityId);
            ViewBag.GenderID = new SelectList(db.TblGenders, "ID", "Gender", tblNutritionist.GenderID);
            ViewBag.StateID = new SelectList(db.TblStates, "ID", "Name", tblNutritionist.StateID);
            ViewBag.UserID = new SelectList(db.TblUsers, "UserId", "UserName", tblNutritionist.UserID);
            return View(tblNutritionist);
        }

        // GET: Nutritionists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblNutritionist tblNutritionist = db.TblNutritionists.Find(id);
            if (tblNutritionist == null)
            {
                return HttpNotFound();
            }
            return View(tblNutritionist);
        }

        // POST: Nutritionists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblNutritionist tblNutritionist = db.TblNutritionists.Find(id);
            db.TblNutritionists.Remove(tblNutritionist);
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
