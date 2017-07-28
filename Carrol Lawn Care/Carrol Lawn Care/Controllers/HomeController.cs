using Carrol_Lawn_Care.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Carrol_Lawn_Care.Controllers
{
    public class HomeController : Controller
    {
        private DB_CLCEntities db = new DB_CLCEntities();
        // GET: Home
        public ActionResult Index()
        {
            var tempDate = DateTime.Today;
            IList<Prop> propsList = new List<Prop>();
            foreach(var prop in db.Props)
            {
                if(prop.nextCut == tempDate.Date)
                {
                    propsList.Add(prop);
                }
            }
            return View(propsList);
        }
    }
}