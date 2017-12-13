﻿ using System;
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
            var projects = db.View_project_from_index.OrderByDescending(x => x.Updated_at).Take(6).ToList();
            ViewData["Project"] = projects;
            ViewData["District"] = db.DISTRICTs.ToList();
            ViewData["Street"] = db.STREETs.ToList();
            ViewData["Ward"] = db.WARDs.ToList();




            //ViewModels vm = new ViewModels();
            //vm.zProperties = db.PROPERTies.ToList();
            //vm.zDistricts = db.DISTRICTs.ToList();
            //vm.zWards = db.WARDs.ToList();
            //vm.zStreets = db.STREETs.ToList();

            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
    }
}