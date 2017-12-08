using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPCRental.Models;
namespace PPCRental.Controllers
{
    public class HomeController : Controller
    {
        ppcrental3119Entities db = new ppcrental3119Entities();
        public ActionResult Index()
        {
            var obj = db.View_project_from_index.ToList().Take(6);

            return View(obj);
        }
        public ActionResult Contact()
        {
            return View();
        }
    }
}