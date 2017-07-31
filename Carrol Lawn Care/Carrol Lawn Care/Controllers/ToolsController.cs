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
        private DB_CLCEntities db = new DB_CLCEntities();

        // GET: Tools
        public ActionResult Index()
        {
            var tools = db.Tools.Include(t => t.TblEquip);
            return View(tools.ToList());
        }

        // GET: Tools/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tool tool = db.Tools.Find(id);
            if (tool == null)
            {
                return HttpNotFound();
            }

            List<Vehicle> vehicles = new List<Vehicle>();

            foreach (var item in db.AssignedTools)
            {
                if (item.toolId == tool.toolId)
                {
                    List<Vehicle> vehicle = db.Vehicles.Where(c => c.vehId.Equals(item.truckId)).ToList();

                    foreach (var items in vehicle)
                    {
                        vehicles.Add(items);
                    }
                }
            }

            List<MaintenanceRecord> recs = new List<MaintenanceRecord>();

            foreach (var item in db.MaintenanceRecords)
            {
                if (item.equipId == tool.TblEquip.equipId)
                {
                    recs.Add(item);
                }
            }

            ViewBag.Records = recs;
            ViewBag.Truck = vehicles;
            return View(tool);
        }

        // GET: Tools/Create
        public ActionResult Create()
        {
            ViewBag.equipId = new SelectList(db.Equips, "equipId", "name");
            return View();
        }

        // POST: Tools/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "toolId,equipId")] Tool tool)
        {
            if (ModelState.IsValid)
            {
                db.Tools.Add(tool);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.equipId = new SelectList(db.Equips, "equipId", "name", tool.equipId);
            return View(tool);
        }

        // GET: Tools/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tool tool = db.Tools.Find(id);
            if (tool == null)
            {
                return HttpNotFound();
            }
            ViewBag.equipId = new SelectList(db.Equips, "equipId", "name", tool.equipId);
            return View(tool);
        }

        // POST: Tools/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "toolId,equipId")] Tool tool)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tool).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.equipId = new SelectList(db.Equips, "equipId", "name", tool.equipId);
            return View(tool);
        }

        // GET: Tools/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tool tool = db.Tools.Find(id);
            if (tool == null)
            {
                return HttpNotFound();
            }
            return View(tool);
        }

        // POST: Tools/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tool tool = db.Tools.Find(id);
            db.Tools.Remove(tool);
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
