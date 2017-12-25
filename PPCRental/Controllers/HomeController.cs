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
            var projects = db.View_project_from_index.OrderByDescending(x => x.Updated_at).Where(x => x.Status_ID==3).Take(6).ToList();
            ViewData["Project"] = projects;
            ViewData["District"] = db.DISTRICTs.OrderBy(x => x.DistrictName).ToList();
            ViewData["Street"] = db.STREETs.ToList();
            ViewData["Ward"] = db.WARDs.ToList();
            ViewData["property_type"] = db.PROPERTY_TYPE.ToList();

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
        [HttpPost]
        public ActionResult Contact(string name, string email, string subject, string message)
        {
            int nextID = db.ContactInfoes.Max(x => x.ID) + 1;
            ContactInfo newContact = new ContactInfo{
                ID = nextID,
                Name = name,
                Email = email,
                Subject = subject,
                Message = message
            };

            try
            {
                db.ContactInfoes.Add(newContact);
                db.SaveChanges();
                ViewBag.SuccessMessage = "Message sent successfully";
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.ToString();
                throw;
            }

            return View();
        }
    }
}