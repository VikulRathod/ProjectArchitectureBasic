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
    public class CustomizedPlansController : Controller
    {
        private T8GymDBEntities db = new T8GymDBEntities();

        // GET: CustomizedPlans
        public ActionResult Index()
        {
            var tblCustomizedPlans = db.TblCustomizedPlans.Include(t => t.TblMember).Include(t => t.TblStaff).Include(t => t.TblSupplement).Include(t => t.TblStaff1);
            return View(tblCustomizedPlans.ToList());
        }

        // GET: CustomizedPlans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblCustomizedPlan tblCustomizedPlan = db.TblCustomizedPlans.Find(id);
            if (tblCustomizedPlan == null)
            {
                return HttpNotFound();
            }
            return View(tblCustomizedPlan);
        }

        // GET: CustomizedPlans/Create
        public ActionResult Create()
        {
            ViewBag.MemberId = new SelectList(db.TblMembers, "ID", "Name");
            ViewBag.NutritionistID = new SelectList(db.TblStaffs, "ID", "Name");
            ViewBag.SupplimentId = new SelectList(db.TblSupplements, "ID", "Name");
            ViewBag.TrainerID = new SelectList(db.TblStaffs, "ID", "Name");
            return View();
        }

        // POST: CustomizedPlans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MemberId,NutritionPlanCharge,CustomizedNutritionPlan,TrainingPlanCharge,CustomizedTrainingPlan,NutritionistID,TrainerID,SupplimentId")] TblCustomizedPlan tblCustomizedPlan)
        {
            if (ModelState.IsValid)
            {
                db.TblCustomizedPlans.Add(tblCustomizedPlan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MemberId = new SelectList(db.TblMembers, "ID", "Name", tblCustomizedPlan.MemberId);
            ViewBag.NutritionistID = new SelectList(db.TblStaffs, "ID", "Name", tblCustomizedPlan.NutritionistID);
            ViewBag.SupplimentId = new SelectList(db.TblSupplements, "ID", "Name", tblCustomizedPlan.SupplimentId);
            ViewBag.TrainerID = new SelectList(db.TblStaffs, "ID", "Name", tblCustomizedPlan.TrainerID);
            return View(tblCustomizedPlan);
        }

        // GET: CustomizedPlans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblCustomizedPlan tblCustomizedPlan = db.TblCustomizedPlans.Find(id);
            if (tblCustomizedPlan == null)
            {
                return HttpNotFound();
            }
            ViewBag.MemberId = new SelectList(db.TblMembers, "ID", "Name", tblCustomizedPlan.MemberId);
            ViewBag.NutritionistID = new SelectList(db.TblStaffs, "ID", "Name", tblCustomizedPlan.NutritionistID);
            ViewBag.SupplimentId = new SelectList(db.TblSupplements, "ID", "Name", tblCustomizedPlan.SupplimentId);
            ViewBag.TrainerID = new SelectList(db.TblStaffs, "ID", "Name", tblCustomizedPlan.TrainerID);
            return View(tblCustomizedPlan);
        }

        // POST: CustomizedPlans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MemberId,NutritionPlanCharge,CustomizedNutritionPlan,TrainingPlanCharge,CustomizedTrainingPlan,NutritionistID,TrainerID,SupplimentId")] TblCustomizedPlan tblCustomizedPlan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblCustomizedPlan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MemberId = new SelectList(db.TblMembers, "ID", "Name", tblCustomizedPlan.MemberId);
            ViewBag.NutritionistID = new SelectList(db.TblStaffs, "ID", "Name", tblCustomizedPlan.NutritionistID);
            ViewBag.SupplimentId = new SelectList(db.TblSupplements, "ID", "Name", tblCustomizedPlan.SupplimentId);
            ViewBag.TrainerID = new SelectList(db.TblStaffs, "ID", "Name", tblCustomizedPlan.TrainerID);
            return View(tblCustomizedPlan);
        }

        // GET: CustomizedPlans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblCustomizedPlan tblCustomizedPlan = db.TblCustomizedPlans.Find(id);
            if (tblCustomizedPlan == null)
            {
                return HttpNotFound();
            }
            return View(tblCustomizedPlan);
        }

        // POST: CustomizedPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblCustomizedPlan tblCustomizedPlan = db.TblCustomizedPlans.Find(id);
            db.TblCustomizedPlans.Remove(tblCustomizedPlan);
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
