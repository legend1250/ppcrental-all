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
                  
                    //session.Add("user", user);  
                    Session["user"] = user.Email;
                    Session["userID"] = user.ID;
                  //  HttpResponse.RemoveOutputCacheItem("~/Home/Index");
                    return Redirect("~/Home/Index");
                }
                else
                {
                    Session["error"] = 1;
                    return View();
                    
                }

            }
            catch (Exception)
            {
                Session["error"] = 1;
                return View();
            }
            
            return View();
        }
        public void Logout()
        {
            Session.RemoveAll();

            Response.Redirect("~/Home/Index");
        }
        public ActionResult Register()
        {
            return View();
        }
    }
}