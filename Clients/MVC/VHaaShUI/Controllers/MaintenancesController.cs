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
    public class MaintenancesController : Controller
    {
        private T8GymDBEntities db = new T8GymDBEntities();

        // GET: Maintenances
        public ActionResult Index()
        {
            return View(db.TblMaintenances.ToList());
        }

        // GET: Maintenances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblMaintenance tblMaintenance = db.TblMaintenances.Find(id);
            if (tblMaintenance == null)
            {
                return HttpNotFound();
            }
            return View(tblMaintenance);
        }

        // GET: Maintenances/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Maintenances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Machine,IsRepair,IsMaintenance,IsReplace,IsApproved,Instruction,Estimate,Bill")] TblMaintenance tblMaintenance)
        {
            if (ModelState.IsValid)
            {
                db.TblMaintenances.Add(tblMaintenance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblMaintenance);
        }

        // GET: Maintenances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblMaintenance tblMaintenance = db.TblMaintenances.Find(id);
            if (tblMaintenance == null)
            {
                return HttpNotFound();
            }
            return View(tblMaintenance);
        }

        // POST: Maintenances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Machine,IsRepair,IsMaintenance,IsReplace,IsApproved,Instruction,Estimate,Bill")] TblMaintenance tblMaintenance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblMaintenance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblMaintenance);
        }

        // GET: Maintenances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblMaintenance tblMaintenance = db.TblMaintenances.Find(id);
            if (tblMaintenance == null)
            {
                return HttpNotFound();
            }
            return View(tblMaintenance);
        }

        // POST: Maintenances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblMaintenance tblMaintenance = db.TblMaintenances.Find(id);
            db.TblMaintenances.Remove(tblMaintenance);
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
