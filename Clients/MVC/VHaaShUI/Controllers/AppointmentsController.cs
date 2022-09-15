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
    public class AppointmentsController : Controller
    {
        private T8GymDBEntities db = new T8GymDBEntities();

        // GET: Appointments
        public ActionResult Index()
        {
            return View(db.TblAppointments.ToList());
        }

        // GET: Appointments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblAppointment tblAppointment = db.TblAppointments.Find(id);
            if (tblAppointment == null)
            {
                return HttpNotFound();
            }
            return View(tblAppointment);
        }

        // GET: Appointments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Contact,Email,AppointmentSubject,AppointmentMessage,SlotDate,SlotTime,AppointmentStatus,IsDeleted")] TblAppointment tblAppointment)
        {
            if (ModelState.IsValid)
            {
                db.TblAppointments.Add(tblAppointment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblAppointment);
        }

        // GET: Appointments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblAppointment tblAppointment = db.TblAppointments.Find(id);
            if (tblAppointment == null)
            {
                return HttpNotFound();
            }
            return View(tblAppointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Contact,Email,AppointmentSubject,AppointmentMessage,SlotDate,SlotTime,AppointmentStatus,IsDeleted")] TblAppointment tblAppointment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblAppointment).State = System.Data.Entity.EntityState.Modified ;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblAppointment);
        }

        // GET: Appointments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblAppointment tblAppointment = db.TblAppointments.Find(id);
            if (tblAppointment == null)
            {
                return HttpNotFound();
            }
            return View(tblAppointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblAppointment tblAppointment = db.TblAppointments.Find(id);
            db.TblAppointments.Remove(tblAppointment);
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
