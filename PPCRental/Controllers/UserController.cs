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
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(String usrname, String pwd)
        {
            
            try
            {
                var user = db.USERs.FirstOrDefault(x => x.Email == usrname);

                if (user.Password == pwd)
                {
                    //session.Add("user", user);  
                    Session["user"] = user.FullName;
                    Session["userID"] = user.ID;
                    string[] name_role = { "None", "Agency", "Sale" };
                    Session["userRole"] = name_role[(int)user.RoleID];
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
        }
        public void Logout()
        {
            Session.RemoveAll();

            Response.Redirect("~/Home/Index");
        }
        public ActionResult Security()
        {
            return View();
        }
        [HttpPost]
        public ActionResult changePassword()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View(); ;
        }
        [HttpPost]
        public ActionResult submitRegister(USER newUser)
        {
            string message = "";
            try
            {
                db.USERs.Add(newUser);
                db.SaveChanges();
                message = "Success";
                return Json(new { Message = newUser, JsonRequestBehavior.AllowGet });
            }
            catch (Exception e)
            {
                message = e.Message;
                return Json(new { Message = message, JsonRequestBehavior.AllowGet });

            }

        }
        public ActionResult forgotPassword()
        {
            return View();
        }

    }
}