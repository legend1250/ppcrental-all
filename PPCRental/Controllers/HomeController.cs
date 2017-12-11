using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPCRental.Models;
using PPCRental.Driver;

namespace PPCRental.Controllers
{
    public class HomeController : Controller
    {
        ppcrental3119Entities db = new ppcrental3119Entities();
        public ActionResult Index()
        {
            //vb.View_project_from_index.ToList().Take(6);

            ViewModels vm = new ViewModels();
            vm.zProperties = db.PROPERTies.ToList();
            vm.zDistricts = db.DISTRICTs.ToList();
            vm.zWards = db.WARDs.ToList();
            vm.zStreets = db.STREETs.ToList();

            return View(vm);
        }
        public ActionResult Contact()
        {
            return View();
        }
    }
}