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
    public class MembershipsController : Controller
    {
        private T8GymDBEntities db = new T8GymDBEntities();

        // GET: Memberships
        public ActionResult Index()
        {
            var tblMemberships = db.TblMemberships.Include(t => t.TblLevel);
            return View(tblMemberships.ToList());
        }

        // GET: Memberships/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblMembership tblMembership = db.TblMemberships.Find(id);
            if (tblMembership == null)
            {
                return HttpNotFound();
            }
            return View(tblMembership);
        }

        // GET: Memberships/Create
        public ActionResult Create()
        {
            ViewBag.RecommendedLevel = new SelectList(db.TblLevels, "ID", "Level");
            return View();
        }

        // POST: Memberships/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Fee,Swimming,Cardio,StrengthTraining,SteamBath,CrossFit,Boxing,Zumba,BasicWorkoutPlan,CustomWorkoutPlan,BasicDietPlan,CustomDietPlan,RecommendedLevel")] TblMembership tblMembership)
        {
            if (ModelState.IsValid)
            {
                db.TblMemberships.Add(tblMembership);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RecommendedLevel = new SelectList(db.TblLevels, "ID", "Level", tblMembership.RecommendedLevel);
            return View(tblMembership);
        }

        // GET: Memberships/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblMembership tblMembership = db.TblMemberships.Find(id);
            if (tblMembership == null)
            {
                return HttpNotFound();
            }
            ViewBag.RecommendedLevel = new SelectList(db.TblLevels, "ID", "Level", tblMembership.RecommendedLevel);
            return View(tblMembership);
        }

        // POST: Memberships/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Fee,Swimming,Cardio,StrengthTraining,SteamBath,CrossFit,Boxing,Zumba,BasicWorkoutPlan,CustomWorkoutPlan,BasicDietPlan,CustomDietPlan,RecommendedLevel")] TblMembership tblMembership)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblMembership).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RecommendedLevel = new SelectList(db.TblLevels, "ID", "Level", tblMembership.RecommendedLevel);
            return View(tblMembership);
        }

        // GET: Memberships/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblMembership tblMembership = db.TblMemberships.Find(id);
            if (tblMembership == null)
            {
                return HttpNotFound();
            }
            return View(tblMembership);
        }

        // POST: Memberships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblMembership tblMembership = db.TblMemberships.Find(id);
            db.TblMemberships.Remove(tblMembership);
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
