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

using PPCRental.Driver;
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
        public ActionResult Login(String usrname, String pwd,bool rememberme = false)
        {
            
            try
            {
                bool rememberMe = rememberme;

                String path = Session["SavePath"] as String;
                //Console.WriteLine(pwd);

                pwd = hashPwd(pwd);
                //// Console.WriteLine(pwd);
                var user = db.USERs.FirstOrDefault(x => x.Email == usrname);

                if (user.Password == pwd)
                {
                    if (user.Status == true)
                    {
                        int UserID = user.ID;
                        Session["user"] = user.FullName;
                        Session["userID"] = UserID;
                        string[] name_role = { "None", "Agency", "Sale","Technical"};
                        string role = name_role[(int)user.RoleID];
                        Session["userRole"] = role;
                        Session["VerifyUser"] = "NotVerify";

                        //add cookie

                        HttpCookie userName = new HttpCookie("UserName", user.FullName);
                        HttpCookie userRole = new HttpCookie("UserRole", role);
                        HttpCookie userID = new HttpCookie("UserID", UserID.ToString());
                        
                        //if checkbox rememberme is checked
                        if (rememberMe==true)
                        {
                            //set cookie's expire day in 365 day
                            userName.Expires.AddDays(365);
                            userRole.Expires.AddDays(365);
                            userID.Expires.AddDays(365);
                            
                        }
                        else
                        {
                            //remove cookie
                            userName.Expires = DateTime.Now.AddDays(-1);
                            userRole.Expires = DateTime.Now.AddDays(-1);
                            userID.Expires = DateTime.Now.AddDays(-1);
                            
                        }
                        
                        HttpContext.Response.SetCookie(userName);
                        HttpContext.Response.SetCookie(userRole);
                        HttpContext.Response.SetCookie(userID);
                       
                        //  HttpResponse.RemoveOutputCacheItem("~/Home/Index");
                        return Redirect("~"+path);
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
            
            //remove  cookie
            if (Request.Cookies["UserName"] != null)
            {
                var c = new HttpCookie("UserName");
                c.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(c);
            }

            if (Session["userID"]!=null)
            {
                bool rollbackVerify = false, rollbackID = false;
                //trước khi xóa hết kiểm tra xem user có verify chưa,nó có thì lưu lại
                int userID = (int)Session["userID"];
                HttpCookie Verify = Request.Cookies["VerifyUser" + userID.ToString()];
                HttpCookie UserID = Request.Cookies[userID.ToString()];
                if (Verify != null)
                {
                    rollbackVerify = true;
                }
                if (UserID != null)
                {
                    rollbackID = true;
                }
                //verify cookie existed
                if (rollbackVerify)
                {
                    //roll back verify cookie


                    Verify = new HttpCookie("VerifyUser" + userID.ToString(), "Verified");
                    Verify.Expires.AddDays(7);
                    HttpContext.Response.AppendCookie(Verify);
                }
                if (rollbackID)
                {
                    UserID = new HttpCookie(userID.ToString(), userID.ToString());
                    UserID.Expires.AddDays(7);
                    HttpContext.Response.AppendCookie(UserID);
                }
            }
            
            Session.RemoveAll();
            Session["User"] = null;
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
                    NewPassword = hashPwd(NewPassword);
                    if (user.Password == Password)
                    {
                        if (user.Password != NewPassword)
                        {
                            NewPassword = hashPwd(NewPassword);
                            user.Password = NewPassword;
                            db.SaveChanges();
                            Session["changeStatus"] = "Your password has been changed successfully";
                        }
                        else
                        {
                            Session["changeStatus"] = "Your new password mustn't the same with your current password";
                        }
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
            //var obj = db.security_questions.ToList();
            return View(); ;
        }
        [HttpPost]
        public ActionResult submitRegister(userData newUser)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                try
                {
                    var user = new USER();
                    user.Email = newUser.Email;
                    user.FullName = newUser.FullName;
                    user.Phone = newUser.Phone;
                    user.Password = newUser.Password;
                    user.Address = newUser.Address;
                    user.RoleID = 0;
                    user.Status = newUser.Status;
                    user.SecretQuestion_ID = newUser.SecretQuestion_ID;
                    user.Answer = newUser.Answer;

                    var checkEmail = db.USERs.FirstOrDefault(x => x.Email == newUser.Email);
                    if (checkEmail == null)
                    {

                        db.USERs.Add(user);
                        db.SaveChanges();
                        message = "Success";
                    }
                    else
                    {
                        message = "This email address already corresponds to a PPCRental member account. Please sign in or, if you forgot your password, reset it.";
                    }
                    return Json(new { Message = message, JsonRequestBehavior.AllowGet });
                }
                catch (Exception e)
                {
                    message = e.Message;
                    return Json(new { Message = message, JsonRequestBehavior.AllowGet });

                }
            }
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
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
        public ActionResult verifyUser()
        {
            ViewModels vm = new ViewModels();
            vm.zSecurity = db.security_questions.ToList();
            if (Session["userID"]==null)
            {
                Session["login-status"] = "NotLogin";
                return Redirect("~/User/Login");
            }
            else
            {
                int userID = (int)Session["userID"];
                USER user = db.USERs.Find(userID);
                ViewBag.userQuestion = user.SecretQuestion_ID;
            }
            
           
            return View(vm);

        }
        [HttpPost]
        public ActionResult verifyUser(int userQuestion,String userAnswer)
        {
            String path = Session["SavePath"] as String;
            int userID = (int)Session["userID"];
            USER user = db.USERs.Find(userID);
            String yourAnswer = userAnswer;
            int yourQuestion = userQuestion;
           
            if (user.SecretQuestion_ID == yourQuestion && user.Answer == yourAnswer.Trim())
            {
                Session["VerifyUser"] = "Verified";

                //add cookie
                HttpCookie UserID = new HttpCookie(userID.ToString(), userID.ToString());
                UserID.Expires.AddDays(7);
                HttpContext.Response.SetCookie(UserID);
                HttpCookie Verify = new HttpCookie("VerifyUser"+ userID.ToString(), "Verified");
                Verify.Expires.AddDays(7);
                HttpContext.Response.SetCookie(Verify);

                //return Redirect("~/User/Security");
                return Redirect("~" + path);     
            }
            else
            {
                ViewModels vm = new ViewModels();
                vm.zSecurity = db.security_questions.ToList();
                ViewBag.userQuestion = user.SecretQuestion_ID;
                ViewBag.VerifyMessage ="Your anwser not match with your answer in database";
                return View(vm);
            }
            
        }
        public ActionResult proFile()
        {
            return View();
        }
       

    }
}