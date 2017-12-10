using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPCRental.Models;
using System.Text;
using System.Security.Cryptography;
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
                //Console.WriteLine(pwd);

                pwd = hashPwd(pwd);
                //// Console.WriteLine(pwd);
                var user = db.USERs.FirstOrDefault(x => x.Email == usrname);

                if (user.Password == pwd)
                {
                    if (user.Status == true)
                    {
                        Session["user"] = user.FullName;
                        Session["userID"] = user.ID;
                        string[] name_role = { "None", "Agency", "Sale","Technical"};
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
        public ActionResult Security(string Password, string NewPassword)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var userid = Session["userID"];
                    USER user = db.USERs.Find(userid);
                    Password = hashPwd(Password);
                    if (user.Password == Password)
                    {
                        NewPassword = hashPwd(NewPassword);
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
                return Json(new { Message = message, JsonRequestBehavior.AllowGet });
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
        public ActionResult userManagement()
        {
            return userManagement(10);
        }
        [HttpPost]
        public ActionResult userManagement(int? role_id)
        {

            if (role_id == null || role_id == 10)
            {
                var users = db.UserManagements.ToList();
                return View(users);
                
            }
            else
            {
                var users = db.UserManagements.ToList().Where(x => x.RoleID == role_id);
                return View(users);
            }

        }

        public JsonResult manageUser(int role_id)
        {
            if(role_id == 10)
            {
                var users = db.UserManagements.ToArray();
                return Json(new { Success = true, Users = users }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var users = db.UserManagements.ToArray().Where(x => x.RoleID == role_id);
                return Json(new { Success = true, Users = users }, JsonRequestBehavior.AllowGet);
            }

            
        }


        private string hashPwd(string pwd)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(pwd));

            //get hash result after compute it
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits
                //for each byte
                strBuilder.Append(result[i].ToString("x2"));
            }
            return strBuilder.ToString();
        }

    }
}