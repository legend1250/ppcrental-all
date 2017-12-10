using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPCRental.Models;
using System.Text;
using System.Security.Cryptography;
using System.Web.Services;
using System.Web.Script.Services;
using Newtonsoft.Json;
using System.Data.Entity;

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
        public ActionResult UserManagement_Views()
        {
            var users = db.UserManagements.ToList();
            ViewData["users"] = users;
            ViewData["role"] = db.ROLEs.ToList();
            return View();
        }

        public JsonResult ManageUser_Views(int role_id)
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

        public ActionResult UserManagement_Edit()
        {
            var users = db.UserManagements.ToList();
            ViewData["users"] = users;
            ViewData["question"] = db.security_questions.ToList();
            return View();
        }

        [HttpPost]
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public JsonResult ManageUser_GetUser(int id)
        {
            //var user = db.USERs.FirstOrDefault( x => x.ID == id);
            //var user = db.PROPERTies.SingleOrDefault(x => x.ID == id);

            var usr = db.USERs.FirstOrDefault(x => x.ID == id);
            var user = new
            {
                id = usr.ID,
                email = usr.Email,
                pwd = usr.Password,
                fullname = usr.FullName,
                phone = usr.Phone,
                address = usr.Address,
                role_id = usr.RoleID,
                active = usr.Status,
                security_question = usr.SecretQuestion_ID,
                s_answer = usr.Answer
            };
            //Console.WriteLine(user); 
            ViewData["question"] = db.security_questions.ToList();
            
            return Json(new { Data = user }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult ManageUser_EditUser(USER editedUser)
        {
            try
            {

                //var userID = editedUser.ID;
                Console.WriteLine(editedUser);

                var user = db.USERs.Where(x => x.ID == editedUser.ID).First();
                var user2 = user;
                Console.WriteLine(user2);

                user.FullName = editedUser.FullName;
                user.Email = editedUser.Email;
                user.Password = editedUser.Password;
                user.Phone = editedUser.Phone;
                user.Address = editedUser.Address;
                user.RoleID = editedUser.RoleID;
                user.Status = editedUser.Status;
                user.SecretQuestion_ID = editedUser.SecretQuestion_ID;
                user.Answer = editedUser.Answer;

                Console.WriteLine(user);
               
                db.Configuration.ValidateOnSaveEnabled = false;
                db.Entry(user).State = EntityState.Modified;
                
                db.SaveChanges();

                return Json(true);
            }
            catch (Exception e)
            {
                return Json(e.Message);
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