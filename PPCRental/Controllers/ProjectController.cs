using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPCRental.Models;
namespace PPCRental.Controllers
{
    public class ProjectController : Controller
    {
        ppcrental3119Entities db = new ppcrental3119Entities();
        // GET: Project
        public ActionResult Index()
        {
            var project = db.PROPERTies.ToList();

            return View(project);
        }
        [HttpPost]
        public ActionResult projectFilter()
        {
            return View();
        }
    }
}