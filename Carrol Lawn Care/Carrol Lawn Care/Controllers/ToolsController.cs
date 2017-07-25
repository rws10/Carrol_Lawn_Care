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
    public class ToolsController : Controller
    {
        private DBCLC db = new DBCLC();

        // GET: Tools
        public ActionResult Index()
        {
            var tblTools = db.TblTools.Include(t => t.TblEquip);
            return View(tblTools.ToList());
        }

        // GET: Tools/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tools tools = db.TblTools.Find(id);
            if (tools == null)
            {
                return HttpNotFound();
            }
            return View(tools);
        }

        // GET: Tools/Create
        public ActionResult Create()
        {
            ViewBag.equipId = new SelectList(db.TblEquips, "equipId", "name");
            return View();
        }

        // POST: Tools/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "toolId,equipId")] Tools tools)
        {
            if (ModelState.IsValid)
            {
                db.TblTools.Add(tools);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.equipId = new SelectList(db.TblEquips, "equipId", "name", tools.equipId);
            return View(tools);
        }

        // GET: Tools/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tools tools = db.TblTools.Find(id);
            if (tools == null)
            {
                return HttpNotFound();
            }
            ViewBag.equipId = new SelectList(db.TblEquips, "equipId", "name", tools.equipId);
            return View(tools);
        }

        // POST: Tools/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "toolId,equipId")] Tools tools)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tools).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.equipId = new SelectList(db.TblEquips, "equipId", "name", tools.equipId);
            return View(tools);
        }

        // GET: Tools/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tools tools = db.TblTools.Find(id);
            if (tools == null)
            {
                return HttpNotFound();
            }
            return View(tools);
        }

        // POST: Tools/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tools tools = db.TblTools.Find(id);
            db.TblTools.Remove(tools);
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
