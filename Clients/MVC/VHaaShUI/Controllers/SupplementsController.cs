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
    public class SupplementsController : Controller
    {
        private T8GymDBEntities db = new T8GymDBEntities();

        // GET: Supplements
        public ActionResult Index()
        {
            var tblSupplements = db.TblSupplements.Include(t => t.TblLevel);
            return View(tblSupplements.ToList());
        }

        // GET: Supplements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblSupplement tblSupplement = db.TblSupplements.Find(id);
            if (tblSupplement == null)
            {
                return HttpNotFound();
            }
            return View(tblSupplement);
        }

        // GET: Supplements/Create
        public ActionResult Create()
        {
            ViewBag.LevelID = new SelectList(db.TblLevels, "ID", "Level");
            return View();
        }

        // POST: Supplements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Type,Price,LevelID")] TblSupplement tblSupplement)
        {
            if (ModelState.IsValid)
            {
                db.TblSupplements.Add(tblSupplement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LevelID = new SelectList(db.TblLevels, "ID", "Level", tblSupplement.LevelID);
            return View(tblSupplement);
        }

        // GET: Supplements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblSupplement tblSupplement = db.TblSupplements.Find(id);
            if (tblSupplement == null)
            {
                return HttpNotFound();
            }
            ViewBag.LevelID = new SelectList(db.TblLevels, "ID", "Level", tblSupplement.LevelID);
            return View(tblSupplement);
        }

        // POST: Supplements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Type,Price,LevelID")] TblSupplement tblSupplement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblSupplement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LevelID = new SelectList(db.TblLevels, "ID", "Level", tblSupplement.LevelID);
            return View(tblSupplement);
        }

        // GET: Supplements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblSupplement tblSupplement = db.TblSupplements.Find(id);
            if (tblSupplement == null)
            {
                return HttpNotFound();
            }
            return View(tblSupplement);
        }

        // POST: Supplements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblSupplement tblSupplement = db.TblSupplements.Find(id);
            db.TblSupplements.Remove(tblSupplement);
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
