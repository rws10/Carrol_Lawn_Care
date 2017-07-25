using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Carrol_Lawn_Care.Models;

namespace Carrol_Lawn_Care.Controllers
{
    public class MaintenanceRecordsController : Controller
    {
        private DBCLC db = new DBCLC();

        // GET: MaintenanceRecords
        public ActionResult Index()
        {
            var tblMaintRecs = db.TblMaintRecs.Include(m => m.TblEquip);
            return View(tblMaintRecs.ToList());
        }

        // GET: MaintenanceRecords/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaintenanceRecords maintenanceRecords = db.TblMaintRecs.Find(id);
            if (maintenanceRecords == null)
            {
                return HttpNotFound();
            }
            return View(maintenanceRecords);
        }

        // GET: MaintenanceRecords/Create
        public ActionResult Create()
        {
            ViewBag.equipId = new SelectList(db.TblEquips, "equipId", "name");
            return View();
        }

        // POST: MaintenanceRecords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maintId,equipId,maintType,cost,date")] MaintenanceRecords maintenanceRecords)
        {
            if (ModelState.IsValid)
            {
                db.TblMaintRecs.Add(maintenanceRecords);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.equipId = new SelectList(db.TblEquips, "equipId", "name", maintenanceRecords.equipId);
            return View(maintenanceRecords);
        }

        // GET: MaintenanceRecords/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaintenanceRecords maintenanceRecords = db.TblMaintRecs.Find(id);
            if (maintenanceRecords == null)
            {
                return HttpNotFound();
            }
            ViewBag.equipId = new SelectList(db.TblEquips, "equipId", "name", maintenanceRecords.equipId);
            return View(maintenanceRecords);
        }

        // POST: MaintenanceRecords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maintId,equipId,maintType,cost,date")] MaintenanceRecords maintenanceRecords)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maintenanceRecords).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.equipId = new SelectList(db.TblEquips, "equipId", "name", maintenanceRecords.equipId);
            return View(maintenanceRecords);
        }

        // GET: MaintenanceRecords/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaintenanceRecords maintenanceRecords = db.TblMaintRecs.Find(id);
            if (maintenanceRecords == null)
            {
                return HttpNotFound();
            }
            return View(maintenanceRecords);
        }

        // POST: MaintenanceRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MaintenanceRecords maintenanceRecords = db.TblMaintRecs.Find(id);
            db.TblMaintRecs.Remove(maintenanceRecords);
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
