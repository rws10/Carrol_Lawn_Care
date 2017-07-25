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
    public class EmployeesController : Controller
    {
        private DBCLC db = new DBCLC();

        // GET: Employees
        public ActionResult Index()
        {
            var tblEmps = db.TblEmps.Include(e => e.TblPer).Include(e => e.TblPer1);
            return View(tblEmps.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employees employees = db.TblEmps.Find(id);
            if (employees == null)
            {
                return HttpNotFound();
            }
            return View(employees);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.managedBy = new SelectList(db.TblPers, "perId", "name");
            ViewBag.perId = new SelectList(db.TblPers, "perId", "name");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "empId,perId,payRate,ssn,managedBy")] Employees employees)
        {
            if (ModelState.IsValid)
            {
                db.TblEmps.Add(employees);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.managedBy = new SelectList(db.TblPers, "perId", "name", employees.managedBy);
            ViewBag.perId = new SelectList(db.TblPers, "perId", "name", employees.perId);
            return View(employees);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employees employees = db.TblEmps.Find(id);
            if (employees == null)
            {
                return HttpNotFound();
            }
            ViewBag.managedBy = new SelectList(db.TblPers, "perId", "name", employees.managedBy);
            ViewBag.perId = new SelectList(db.TblPers, "perId", "name", employees.perId);
            return View(employees);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "empId,perId,payRate,ssn,managedBy")] Employees employees)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employees).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.managedBy = new SelectList(db.TblPers, "perId", "name", employees.managedBy);
            ViewBag.perId = new SelectList(db.TblPers, "perId", "name", employees.perId);
            return View(employees);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employees employees = db.TblEmps.Find(id);
            if (employees == null)
            {
                return HttpNotFound();
            }
            return View(employees);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employees employees = db.TblEmps.Find(id);
            db.TblEmps.Remove(employees);
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
