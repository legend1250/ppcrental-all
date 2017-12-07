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
                    if (user.Status == true)
                    {
                        Session["user"] = user.FullName;
                        Session["userID"] = user.ID;
                        string[] name_role = { "None", "Agency", "Sale" };
                        string role = name_role[(int)user.RoleID];
                        Session["userRole"] = role;
                        //  HttpResponse.RemoveOutputCacheItem("~/Home/Index");
                        return Redirect("~/Home/Index");
                    }
                    else
                    {
                        Session.RemoveAll();
                        Session["login-status"] = "NotActive";
                        return Redirect("~/User/Login");
                    }
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
        public ActionResult Security(String Password, String NewPassword)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var userid = Session["userID"];
                    USER user = db.USERs.Find(userid);
                    if (user.Password == Password)
                    {
                        user.Password = NewPassword;
                        db.SaveChanges();
                        Session["changeStatus"] = "Your password has been changed successfully";
                    }
                    else
                    {
                        Session["changeStatus"] = "Your current password not match with the password you gave";
                    }
                    
                   
                }
                catch (Exception ex)
                {
                    Session["changeStatus"] = ex.Message;
                    
                }
            }
            return View();

        }
        [HttpPost]
        public ActionResult changePassword()
        {
            return View();
        }
        public ActionResult Register()
        {
            var obj = db.security_questions.ToList();
            return View(obj); ;
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