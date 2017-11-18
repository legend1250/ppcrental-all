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
        public ActionResult ProjectList()
        {
            var project = db.PROPERTies.ToList();

            return View(project);
        }

        [HttpGet]
        public ActionResult Searching(String projectname)
        {
            var product = db.PROPERTies.ToList().Where(x => x.PropertyName.Contains(projectname));
            return View(product);

        }
        [HttpGet]
        public ActionResult projectDetail(int id)
        {
            var project = db.PROPERTies.FirstOrDefault(x => x.ID == id);         
            return View(project);
        }
        public ActionResult addProject()
        {
            var vm = new DBModel();
            vm.streetService = db.STREETs.ToList();
            vm.projectService = db.PROPERTies.ToList();
            vm.wardService = db.WARDs.ToList();
            vm.districtService = db.DISTRICTs.ToList();
            vm.propertyTypeService = db.PROPERTY_TYPE.ToList();
            return View(vm);
        }
    }
}