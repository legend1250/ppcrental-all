using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPCRental.Models;
using System.IO;
using System.Data.Entity;

namespace PPCRental.Controllers
{
    public class ProjectController : Controller
    {
        ppcrental3119Entities db;
        // GET: Project
        public ProjectController()
        {
            db = new ppcrental3119Entities();   
        }
        public ActionResult ProjectList()
        {
            var project = db.View_project_from_index.OrderByDescending(x => x.Create_post).Where(x => x.Status_ID == 3).ToList();
            ViewData["Project_View"] = project;
            ViewData["District"] = db.DISTRICTs.OrderBy(x => x.DistrictName).ToList();
            ViewData["Street"] = db.STREETs.ToList();
            ViewData["Ward"] = db.WARDs.ToList();
            ViewData["property_type"] = db.PROPERTY_TYPE.ToList();
            //Count
            ViewData["TotalProperty"] = db.View_project_from_index.Count();

            return View();
        }

        [HttpGet]
        public ActionResult Searching(String keyword, int minarea, int maxarea, int district, int street, int ward, int ptype,
                                                      int bedrooms, int bathrooms, int minprice, int maxprice)
        {
            var project = db.View_project_from_index.AsEnumerable();
           
            if(keyword != null && keyword != "")
            {
                project = project.Where(x => x.PropertyName.ToLower().Contains(keyword.ToLower()) || x.Content.ToLower().Contains(keyword.ToLower()));
            }
            // Filter type Property
            if (ptype != 0)
            {
                project = project.Where(x => x.PropertyType_ID == ptype);
            }
            //Filter district
            if (district != 0)
            {
                project = project.Where(x => (int)x.District_ID == district);
            }
            //Filter ward
            if (ward != 0)
            {
                project = project.Where(x => (int)x.Ward_ID == ward);
            }
            //Filter street
            if (street != 0)
            {
                project = project.Where(x => (int)x.Street_ID == street);
            }
            //Filter min-area
            if (minarea != 0)
            {
                project = project.Where(x => x.Area >= minarea);
            }
            //Filter max-area
            if(maxarea != 0)
            {
                project = project.Where(x => x.Area <= maxarea);
            }
            //Filter bedrooms
            if(bedrooms != 0)
            {
                project = project.Where(x => x.BedRoom <= bedrooms);
            }
            //Filter bathrooms
            if(bathrooms != 0)
            {
                project = project.Where(x => x.BathRoom <= bathrooms);
            }
            //Filter min price
            if (minprice != 0)
            {
                project = project.Where(x => x.Price >= minprice);
            }
            //Filter max price
            if(maxprice != 0)
            {
                project = project.Where(x => x.Price <= maxprice);
            }
            //Filter status project
            project = project.Where(x => x.Status_ID == 3);

            ViewData["Project_View"] = project.ToList();
            ViewData["District"] = db.DISTRICTs.OrderBy( x => x.DistrictName).ToList();
            ViewData["Street"] = db.STREETs.ToList();
            ViewData["Ward"] = db.WARDs.ToList();
            ViewData["property_type"] = db.PROPERTY_TYPE.ToList();
            //Count
            ViewData["TotalProperty"] = db.PROPERTies.Where(x => x.Status_ID == 3).Count();
            ViewData["TotalPropertyFound"] = project.Count();

            return View();
        }

        
        public JsonResult filterFollowDistrict(int district_id)
        {
            var ward = db.View_District_Ward.Where(x => x.District_ID == district_id).Select( x => new { x.Ward_ID, x.WardName }).ToArray();
            var street = db.View_District_Street.Where(x => x.District_ID == district_id).Select( x => new { x.Street_ID, x.StreetName }).ToArray();

            return Json(new { Success = true, Ward = ward, Street = street }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult projectDetail(int id)
        {
            var project = db.View_project_from_index.FirstOrDefault(x => x.ID == id);
            ViewData["project"] = project;

            return View();
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
        [HttpPost]
        public ActionResult Submit([Bind(Exclude = "ID")] PROPERTY newProject)
        {
            String message;
            int status;
            DateTime time = DateTime.Now;      
            try
            {
                newProject.Updated_at = time;
                newProject.Created_at = time;
                db.PROPERTies.Add(newProject);
                db.SaveChanges();

                message = "Add Success,wait for appover.";
                status = 1;
                                
            }
            catch (Exception e)
            {
                message = e.Message;
                status = 0;
                
                


            }
            return Json(new { Status = status, Message=message, JsonRequestBehavior.AllowGet });

        }
        [HttpPost]
        public ActionResult saveImage(HttpPostedFileBase avaFile, HttpPostedFileBase imaFile)
        {
            int errorCount = 0,status;
            string message, error = "";
            try
            {
                if (avaFile!=null)
                {
                    if (avaFile.ContentLength > 0)
                    {
                        String avaName = Path.GetFileName(avaFile.FileName);
                        String avaPath = Path.Combine(Server.MapPath("~/img/avatar"), avaName);
                        avaFile.SaveAs(avaPath);

                    }
                }
                if (imaFile!=null)
                {
                    if (imaFile.ContentLength > 0)
                    {
                        String imgName = Path.GetFileName(imaFile.FileName);
                        String imgPath = Path.Combine(Server.MapPath("~/img/avatar"), imgName);
                        imaFile.SaveAs(imgPath);
                    }
                }
            }
            catch (Exception e)
            {

                errorCount++;
                error = e.Message;
            }
            if (errorCount == 0)
            {
                message = "Save ảnh thành công!!";
                status = 1;
            }
            else
            {
                status = 0;
                message = "Save ảnh thất bại:" + error;
            }
            ViewBag.imageMessage = message;
            return Json(new { Status = status, Message=message, JsonRequestBehavior.AllowGet });
            ////var path = VirtualPathUtility.Combine(Server.MapPath("~/img/avatar/"), avaFile.FileName);

            ////avaFile.SaveAs(path);
            //imaFile.SaveAs(Server.MapPath("~/img/avatar" + imaFile.FileName));
        }
        public ActionResult projectControl()
        {

            var vm = new DBModel();
            vm.streetService = db.STREETs.ToList();
            vm.projectService = db.PROPERTies.ToList();
            vm.wardService = db.WARDs.ToList();
            vm.districtService = db.DISTRICTs.ToList();
            vm.propertyTypeService = db.PROPERTY_TYPE.ToList();
            var status = db.PROJECT_STATUS.ToList();
            ViewData["project-status"] = status;
            ViewData["project-list"] = db.PROPERTies.Where(x => x.Status_ID != 2).ToList();
            return View(vm);
        }
        [HttpPost]
        public ActionResult Edit(int id)
        {
            var project = db.PROPERTies.FirstOrDefault(x => x.ID == id);
            Session["ProjectID"] = id;
            //return Json(new { projectEdit = project });
            var areaRaw = project.Area;
            
            return Json(new {projectId=project.ID,projectName = project.PropertyName,projectAvatar = project.Avatar,
                projectImage = project.Images, projectType = project.PropertyType_ID,
                projectContent = project.Content, projectStreet = project.District_ID,
                projectWard = project.Ward_ID, projectDistrict = project.District_ID,
                projectPrice = project.Price, projectUnit = project.UnitPrice,
                projectArea = project.Area, projectBed = project.BedRoom,
                projectBath = project.BathRoom, projectParking = project.PackingPlace,
                projectUser = project.UserID, projectNote = project.Note,projectStatus=project.Status_ID, JsonRequestBehavior.AllowGet });
            //return Json(new { projectEdit = id, JsonRequestBehavior.AllowGet });
        }
        [HttpPost]
        public ActionResult deleleProject(int id)
        {
            string message = "";
            try
            {
                PROPERTY project = db.PROPERTies.Find(id);
                db.PROPERTies.Remove(project);
                db.SaveChanges();
                message = "Deleted project successfully";
            }
            catch (Exception e)
            {

                message = e.Message;
            }
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }
        public ActionResult myProjects()
        {
            if (Session["user"] == null)
            {
                Session.RemoveAll();
                Session["login-status"] = "NotLogin";
                Session["SavePath"] = "/Project/MyProjects";
                return Redirect("~/User/Login");

            }
            var sessionUser = Session["userID"];
            int userID =  int.Parse(sessionUser.ToString());
            var myProject = db.View_project_from_index.Where(x => x.UserID == userID).ToList();
            int countProject = 0;
            foreach (var item in myProject)
            {
                countProject++;
            }
            Session["countMyProject"] = countProject.ToString();
            ViewData["MyProject"] = myProject;
            return View();
        }
        [HttpPost]
        public ActionResult getMyProject(int option)
        {
            int userOption = option;
            var sessionUser = Session["userID"];
            int userID = int.Parse(sessionUser.ToString());
            var myProject= db.View_project_from_index.AsEnumerable();
            if (userOption==1)
            {
                myProject = myProject.Where(x => x.UserID == userID).ToList();
               

            }
            else
            {
                myProject = myProject.Where(x => x.UserID == userID && x.Status_ID == userOption).ToList();

            }
            int countProject = 0;
            foreach (var item in myProject)
            {
                countProject++;
            }
            return Json(new { MyProject = myProject,Count=countProject,JsonRequestBehavior.AllowGet });
          
        }
       public ActionResult projectupdate(PROPERTY projectupdate,int id)
        {
            string message = "";
            DateTime date = DateTime.Now;
            try
            {
                
                //var project = db.PROPERTies.FirstOrDefault(x => x.ID == projectID);
                PROPERTY editProject = db.PROPERTies.Find(id);
                editProject.PropertyName = projectupdate.PropertyName;
                editProject.Content = projectupdate.Content;
                editProject.PropertyType_ID = projectupdate.PropertyType_ID;
                editProject.Street_ID = projectupdate.Street_ID;
                editProject.Ward_ID = projectupdate.Ward_ID;
                editProject.District_ID = projectupdate.District_ID;
                editProject.Price = projectupdate.Price;
                editProject.Area = projectupdate.Area;
                editProject.BathRoom = projectupdate.BathRoom;
                editProject.PackingPlace = projectupdate.PackingPlace;
                editProject.BedRoom = projectupdate.BedRoom;
                editProject.Status_ID = projectupdate.Status_ID;
                db.SaveChanges();
                message = "update thanh cong";
            }
            catch (Exception e)
            {
                message = e.Message;

            }
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }
        public ActionResult Approve()
        {
            var project = db.View_project_from_index.Where(x => x.Status_ID==1).ToList();
            int count = 0;
            foreach (var item in project)
            {
                count++;
            }
            ViewBag.Count = count;
            ViewData["project-not-approve"] = project;
            return View();
        }

        [HttpPost]
        public ActionResult getProject(int id)
        {
            int projectID = id;
            var projectInfor = db.View_project_from_index.FirstOrDefault(x => x.ID == projectID);

            return Json(new { Project = projectInfor, JsonRequestBehavior.AllowGet });
        }
        [HttpPost]
        public ActionResult Approve(int id)
        {
            int saleID =(int)Session["userID"];
            String message = "";
            try
            {
                var project = db.PROPERTies.Find(id);
                project.Status_ID = 3;
                project.Sale_ID = saleID;
                db.Configuration.ValidateOnSaveEnabled = false;
                db.SaveChanges();
                message = "Approve successfully";
            }
            catch (Exception ex)
            {

                message = ex.Message;

            }
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }
        [HttpPost]
        public ActionResult Reject(int id,String reason)
        {
            String message = "";
            int saleID = (int)Session["userID"];
            try
            {
                var project = db.PROPERTies.Find(id);
                project.Status_ID = 5;
                project.Sale_ID = saleID;
                if (reason!="")
                {
                    project.Note = reason;
                }
                db.Configuration.ValidateOnSaveEnabled = false;
                db.SaveChanges();
                message = "Reject successfully";
            }
            catch (Exception ex)
            {

                message = ex.Message;

            }
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }
    }
}