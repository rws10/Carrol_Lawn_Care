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
    public class PropertiesController : Controller
    {
        private DBCLC db = new DBCLC();

        // GET: Properties
        public ActionResult Index()
        {
            var tblProps = db.TblProps.Include(p => p.TblEquip).Include(p => p.TblPer);
            return View(tblProps.ToList());
        }

        // GET: Properties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = db.TblProps.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            return View(property);
        }

        // GET: Properties/Create
        public ActionResult Create()
        {
            ViewBag.equipId = new SelectList(db.TblEquips, "equipId", "name");
            ViewBag.perId = new SelectList(db.TblPers, "perId", "name");
            return View();
        }

        // POST: Properties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "propId,address,services,cost,recurrence,nextCut,perId,equipId")] Property property)
        {
            if (ModelState.IsValid)
            {
                db.TblProps.Add(property);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.equipId = new SelectList(db.TblEquips, "equipId", "name", property.equipId);
            ViewBag.perId = new SelectList(db.TblPers, "perId", "name", property.perId);
            return View(property);
        }

        // GET: Properties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = db.TblProps.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            ViewBag.equipId = new SelectList(db.TblEquips, "equipId", "name", property.equipId);
            ViewBag.perId = new SelectList(db.TblPers, "perId", "name", property.perId);
            return View(property);
        }

        // POST: Properties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "propId,address,services,cost,recurrence,nextCut,perId,equipId")] Property property)
        {
            if (ModelState.IsValid)
            {
                db.Entry(property).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.equipId = new SelectList(db.TblEquips, "equipId", "name", property.equipId);
            ViewBag.perId = new SelectList(db.TblPers, "perId", "name", property.perId);
            return View(property);
        }

        // GET: Properties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Property property = db.TblProps.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            return View(property);
        }

        // POST: Properties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Property property = db.TblProps.Find(id);
            db.TblProps.Remove(property);
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
