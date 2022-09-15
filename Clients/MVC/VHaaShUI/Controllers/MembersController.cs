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
    public class MembersController : Controller
    {
        private T8GymDBEntities db = new T8GymDBEntities();

        // GET: Members
        public ActionResult Index()
        {
            var tblMembers = db.TblMembers.Include(t => t.TblBatch).Include(t => t.TblBloodDetail).Include(t => t.TblCity).Include(t => t.TblCorporateMembership).Include(t => t.TblGender).Include(t => t.TblLevel).Include(t => t.TblMembership).Include(t => t.TblStaff).Include(t => t.TblState).Include(t => t.TblStaff1).Include(t => t.TblUser);
            return View(tblMembers.ToList());
        }

        // GET: Members/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblMember tblMember = db.TblMembers.Find(id);
            if (tblMember == null)
            {
                return HttpNotFound();
            }
            return View(tblMember);
        }

        // GET: Members/Create
        public ActionResult Create()
        {
            ViewBag.BatchID = new SelectList(db.TblBatches, "ID", "Activity");
            ViewBag.BloodId = new SelectList(db.TblBloodDetails, "ID", "BloodGroup");
            ViewBag.CityID = new SelectList(db.TblCities, "ID", "Name");
            ViewBag.CorporateMembershipID = new SelectList(db.TblCorporateMemberships, "ID", "CompanyName");
            ViewBag.GenderID = new SelectList(db.TblGenders, "ID", "Gender");
            ViewBag.TrainningLevelID = new SelectList(db.TblLevels, "ID", "Level");
            ViewBag.MembershipID = new SelectList(db.TblMemberships, "ID", "Name");
            ViewBag.NutritionistID = new SelectList(db.TblStaffs, "ID", "Name");
            ViewBag.StateID = new SelectList(db.TblStates, "ID", "Name");
            ViewBag.TrainerID = new SelectList(db.TblStaffs, "ID", "Name");
            ViewBag.UserID = new SelectList(db.TblUsers, "UserId", "UserName");
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Age,GenderID,BloodId,Weight,Height,BMI,Contact,Email,IsActive,AdmissionDate,DietPlan,InjuryDetails,ProfilePhoto,TrainningLevelID,TrainerID,NutritionistID,BatchID,MembershipID,CorporateMembershipID,StateID,CityID,UserID")] TblMember tblMember)
        {
            if (ModelState.IsValid)
            {
                db.TblMembers.Add(tblMember);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BatchID = new SelectList(db.TblBatches, "ID", "Activity", tblMember.BatchID);
            ViewBag.BloodId = new SelectList(db.TblBloodDetails, "ID", "BloodGroup", tblMember.BloodId);
            ViewBag.CityID = new SelectList(db.TblCities, "ID", "Name", tblMember.CityID);
            ViewBag.CorporateMembershipID = new SelectList(db.TblCorporateMemberships, "ID", "CompanyName", tblMember.CorporateMembershipID);
            ViewBag.GenderID = new SelectList(db.TblGenders, "ID", "Gender", tblMember.GenderID);
            ViewBag.TrainningLevelID = new SelectList(db.TblLevels, "ID", "Level", tblMember.TrainningLevelID);
            ViewBag.MembershipID = new SelectList(db.TblMemberships, "ID", "Name", tblMember.MembershipID);
            ViewBag.NutritionistID = new SelectList(db.TblStaffs, "ID", "Name", tblMember.NutritionistID);
            ViewBag.StateID = new SelectList(db.TblStates, "ID", "Name", tblMember.StateID);
            ViewBag.TrainerID = new SelectList(db.TblStaffs, "ID", "Name", tblMember.TrainerID);
            ViewBag.UserID = new SelectList(db.TblUsers, "UserId", "UserName", tblMember.UserID);
            return View(tblMember);
        }

        // GET: Members/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblMember tblMember = db.TblMembers.Find(id);
            if (tblMember == null)
            {
                return HttpNotFound();
            }
            ViewBag.BatchID = new SelectList(db.TblBatches, "ID", "Activity", tblMember.BatchID);
            ViewBag.BloodId = new SelectList(db.TblBloodDetails, "ID", "BloodGroup", tblMember.BloodId);
            ViewBag.CityID = new SelectList(db.TblCities, "ID", "Name", tblMember.CityID);
            ViewBag.CorporateMembershipID = new SelectList(db.TblCorporateMemberships, "ID", "CompanyName", tblMember.CorporateMembershipID);
            ViewBag.GenderID = new SelectList(db.TblGenders, "ID", "Gender", tblMember.GenderID);
            ViewBag.TrainningLevelID = new SelectList(db.TblLevels, "ID", "Level", tblMember.TrainningLevelID);
            ViewBag.MembershipID = new SelectList(db.TblMemberships, "ID", "Name", tblMember.MembershipID);
            ViewBag.NutritionistID = new SelectList(db.TblStaffs, "ID", "Name", tblMember.NutritionistID);
            ViewBag.StateID = new SelectList(db.TblStates, "ID", "Name", tblMember.StateID);
            ViewBag.TrainerID = new SelectList(db.TblStaffs, "ID", "Name", tblMember.TrainerID);
            ViewBag.UserID = new SelectList(db.TblUsers, "UserId", "UserName", tblMember.UserID);
            return View(tblMember);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Age,GenderID,BloodId,Weight,Height,BMI,Contact,Email,IsActive,AdmissionDate,DietPlan,InjuryDetails,ProfilePhoto,TrainningLevelID,TrainerID,NutritionistID,BatchID,MembershipID,CorporateMembershipID,StateID,CityID,UserID")] TblMember tblMember)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblMember).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BatchID = new SelectList(db.TblBatches, "ID", "Activity", tblMember.BatchID);
            ViewBag.BloodId = new SelectList(db.TblBloodDetails, "ID", "BloodGroup", tblMember.BloodId);
            ViewBag.CityID = new SelectList(db.TblCities, "ID", "Name", tblMember.CityID);
            ViewBag.CorporateMembershipID = new SelectList(db.TblCorporateMemberships, "ID", "CompanyName", tblMember.CorporateMembershipID);
            ViewBag.GenderID = new SelectList(db.TblGenders, "ID", "Gender", tblMember.GenderID);
            ViewBag.TrainningLevelID = new SelectList(db.TblLevels, "ID", "Level", tblMember.TrainningLevelID);
            ViewBag.MembershipID = new SelectList(db.TblMemberships, "ID", "Name", tblMember.MembershipID);
            ViewBag.NutritionistID = new SelectList(db.TblStaffs, "ID", "Name", tblMember.NutritionistID);
            ViewBag.StateID = new SelectList(db.TblStates, "ID", "Name", tblMember.StateID);
            ViewBag.TrainerID = new SelectList(db.TblStaffs, "ID", "Name", tblMember.TrainerID);
            ViewBag.UserID = new SelectList(db.TblUsers, "UserId", "UserName", tblMember.UserID);
            return View(tblMember);
        }

        // GET: Members/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblMember tblMember = db.TblMembers.Find(id);
            if (tblMember == null)
            {
                return HttpNotFound();
            }
            return View(tblMember);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblMember tblMember = db.TblMembers.Find(id);
            db.TblMembers.Remove(tblMember);
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
