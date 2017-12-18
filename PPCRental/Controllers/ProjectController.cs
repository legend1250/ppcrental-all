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
            var project = db.View_project_from_index.ToList();
            ViewData["Project_View"] = project;
            ViewData["District"] = db.DISTRICTs.OrderBy(x => x.DistrictName).ToList();
            ViewData["Street"] = db.STREETs.ToList();
            ViewData["Ward"] = db.WARDs.ToList();
            ViewData["property_type"] = db.PROPERTY_TYPE.ToList();
            //Count
            ViewData["TotalProperty"] = db.PROPERTies.Count();
            ViewData["TotalPropertyFound"] = project.Count();

            return View();
        }

        [HttpGet]
        public ActionResult Searching(String keyword, int district, int street, int ward, int ptype)
        {
            var project = db.View_project_from_index.AsEnumerable();
           
            if(keyword != null && keyword != "")
            {
                project = project.Where(x => x.PropertyName.ToLower().Contains(keyword.ToLower()));
            }
            if(district != 0)
            {
                project = project.Where(x => (int) x.District_ID == district);
            }
            if (street != 0)
            {
                project = project.Where(x => (int)x.Street_ID == street);
            }
            if (ward != 0)
            {
                project = project.Where(x => (int)x.Ward_ID == ward);
            }
            if(ptype != 0)
            {
                project = project.Where(x => x.PropertyType_ID == ptype);
            }

            

            ViewData["Project_View"] = project.ToList();
            ViewData["District"] = db.DISTRICTs.OrderBy( x => x.DistrictName).ToList();
            ViewData["Street"] = db.STREETs.ToList();
            ViewData["Ward"] = db.WARDs.ToList();
            ViewData["property_type"] = db.PROPERTY_TYPE.ToList();
            //Count
            ViewData["TotalProperty"] = db.PROPERTies.Count();
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
            //if (ModelState.IsValid)
            //{   
            // db.PROPERTies.Add(newProject);
            /// db.SaveChanges();
            /// message = "Add Success,wait for appover";
            // return Json(new { Message = message, JsonRequestBehavior.AllowGet });
            //}
            //else
            //{
            //   message = "Add Fail";

            //}
            //return Json(new { Message = message, JsonRequestBehavior.AllowGet });
            //return Json(newProject, JsonRequestBehavior.AllowGet);
            try
            {
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
                if (imaFile.ContentLength > 0)
                {
                    String avaName = Path.GetFileName(avaFile.FileName);
                    String avaPath = Path.Combine(Server.MapPath("~/img/avatar"), avaName);
                    imaFile.SaveAs(avaPath);

                }
                if (imaFile.ContentLength > 0)
                {
                    String imgName = Path.GetFileName(imaFile.FileName);
                    String imgPath = Path.Combine(Server.MapPath("~/img/avatar"), imgName);
                    imaFile.SaveAs(imgPath);
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
            return View(vm);
        }
        [HttpPost]
        public ActionResult Edit(int id)
        {
            var project = db.PROPERTies.FirstOrDefault(x => x.ID == id);
            Session["ProjectID"] = id;
            //return Json(new { projectEdit = project });
            var areaRaw = project.Area;
            var area = areaRaw.Replace("m2", "");
            return Json(new {projectId=project.ID,projectName = project.PropertyName,projectAvatar = project.Avatar,
                projectImage = project.Images, projectType = project.PropertyType_ID,
                projectContent = project.Content, projectStreet = project.District_ID,
                projectWard = project.Ward_ID, projectDistrict = project.District_ID,
                projectPrice = project.Price, projectUnit = project.UnitPrice,
                projectArea = area, projectBed = project.BedRoom,
                projectBath = project.BathRoom, projectParking = project.PackingPlace,
                projectUser = project.UserID, projectNote = project.Note, JsonRequestBehavior.AllowGet });
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
            return View();
        }
       public ActionResult projectupdate(PROPERTY projectupdate)
        {
            string message = "";
            try
            {
                var projectID = projectupdate.ID;
                //var project = db.PROPERTies.FirstOrDefault(x => x.ID == projectID);
                PROPERTY editProject = db.PROPERTies.Find(projectID);
                editProject.ID = projectupdate.ID;
                editProject.PropertyName = projectupdate.PropertyName;
                editProject.Content = projectupdate.Content;
                message = "update success";
                db.SaveChanges();
            }
            catch (Exception e)
            {
                message = e.Message;

            }
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }
      
    }
}