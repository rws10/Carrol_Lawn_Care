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
    public class PropsController : Controller
    {
        private DB_CLCEntities db = new DB_CLCEntities();

        // GET: Props
        public ActionResult Index()
        {
            return View(db.Props.ToList());
        }

        // GET: Props/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prop prop = db.Props.Find(id);

            if (prop == null)
            {
                return HttpNotFound();
            }

            List<Person> people = new List<Person>();

            foreach (var item in db.Owns)
            {
                if (item.propId == prop.propId)
                {
                    List<Person> person = db.People.Where(c => c.perId.Equals(item.perId)).ToList();

                    foreach (var items in person)
                    {
                        people.Add(items);
                    }
                }
            }

            List<Vehicle> vehicles = new List<Vehicle>();

            foreach (var item in db.AssignedTrucks)
            {
                if (item.propId == prop.propId)
                {
                    List<Vehicle> vehicle = db.Vehicles.Where(c => c.vehId.Equals(item.truckId)).ToList();

                    foreach (var items in vehicle)
                    {
                        vehicles.Add(items);
                    }
                }
            }

            ViewBag.Truck = vehicles;
            ViewBag.Owners = people;
            return View(prop);
        }

        // GET: Props/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Props/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "propId,address,services,cost,recurrence,nextCut")] Prop prop)
        {
            if (ModelState.IsValid)
            {
                db.Props.Add(prop);

                if (prop.nextCut < DateTime.Today)
                {
                    TempData["FailureMessage"] = "Date must be today's date or later.";
                    return View(prop);
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prop);
        }

        // GET: Props/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prop prop = db.Props.Find(id);
            if (prop == null)
            {
                return HttpNotFound();
            }
            return View(prop);
        }

        // POST: Props/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "propId,address,services,cost,recurrence,nextCut")] Prop prop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prop).State = EntityState.Modified;

                if(prop.nextCut < DateTime.Today)
                {
                    TempData["FailureMessage"] = "Date must be today's date or later.";
                    return View(prop);
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prop);
        }

        // GET: Props/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prop prop = db.Props.Find(id);
            if (prop == null)
            {
                return HttpNotFound();
            }
            return View(prop);
        }

        // POST: Props/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prop prop = db.Props.Find(id);
            db.Props.Remove(prop);
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
