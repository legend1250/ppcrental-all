﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PPCRental.Models;
using System.IO;
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
            var project = db.PROPERTies.ToList();

            return View(project);
        }

        [HttpGet]
        public ActionResult Searching(String projectname)
        {
            var product = db.PROPERTies.ToList().Where(x => x.PropertyName.Contains(projectname));
            return View(product);

        }
        [HttpGet]
        public ActionResult projectDetail(int id)
        {
            var project = db.PROPERTies.FirstOrDefault(x => x.ID == id);         
            return View(project);
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
              
                message = "Add Success,wait for appover";
                return Json(new { Message = message, JsonRequestBehavior.AllowGet });
            }
            catch (Exception e)
            {
                message = e.Message;
                return Json(new { Message = message, JsonRequestBehavior.AllowGet });


            }
            

        }
        [HttpPost]
        public ActionResult saveImage(HttpPostedFileBase avaFile, HttpPostedFileBase imaFile)
        {
            int errorCount = 0;
            string message,error="";
            try
            {
                if (imaFile.ContentLength>0)
                {
                    String avaName = Path.GetFileName(avaFile.FileName);
                    String avaPath = Path.Combine(Server.MapPath("~/img/avatar"), avaName);
                    imaFile.SaveAs(avaPath);

                }
                if (imaFile.ContentLength>0)
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
            if (errorCount==0)
            {
                message = "Save ảnh thành công!!";
            }
            else
            {
                message = "Save ảnh thất bại:"+ error;
            }
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
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
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Session.Remove("editName");
            var product = db.PROPERTies.FirstOrDefault(x => x.ID ==id);
            //Session["editProject"] = product;
            Session["editName"] = product.PropertyName.ToString();
            Session["editAvatar"] = product.Avatar.ToString();
            Session["editImage"] = product.Images;
            Session["editDistrict"] = product.District_ID.ToString();
            Session["editStreet"] = product.Street_ID.ToString();
            Session["editWard"] = product.Ward_ID.ToString();
            Session["editPrice"] = product.Price.ToString();
            Session["editArea"] = product.Area.ToString();
            Session["editProjectType"] = product.PropertyType_ID.ToString();
            Session["editBed"] = product.BedRoom.ToString();
            Session["editBath"] = product.BathRoom.ToString();
            Session["editPacking"] = product.PackingPlace.ToString();
            Session["editContent"] = product.Content;
            return Redirect("~/Project/projectControl");
        }
    }
}