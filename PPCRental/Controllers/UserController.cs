using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPCRental.Models;
namespace PPCRental.Controllers
{
    public class UserController : Controller
    {
        ppcrental3119Entities db = new ppcrental3119Entities();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(String une, String pwd)
        {
            
            try
            {
                var user = db.USERs.FirstOrDefault(x => x.Email == une);
                if (user.Password == pwd)
                {
                    Session["user"] = user;
                    Response.Redirect("~/Home/Index");
                }
                else
                {
                    int i = 1;
                    return View(i);
                }

            }
            catch (Exception)
            {
                return View();
            }
            
            return View();
        }
    }
}