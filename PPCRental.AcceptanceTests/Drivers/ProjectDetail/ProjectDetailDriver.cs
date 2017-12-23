using System;
using System.Linq;
using System.Web.Mvc;
using PPCRental.Models;
using PPCRental.AcceptanceTests.Support;
using PPCRental.Controllers;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace PPCRental.AcceptanceTests.Drivers.ProjectDetail
{
   public class ProjectDetailDriver
    {
        //private const decimal ProjectDefaultPrice = 10;
        private readonly CatalogContext _context;
        private ActionResult _result;

        public ProjectDetailDriver(CatalogContext context)
        {
            _context = context;
        }
         
        public void InsertProjectToDB(Table projects)
        {
            using (var db = new ppcrental3119Entities())
            {
                //var oStreets = db.STREETs.ToList();
                //chạy insert từng cột, các cột này dựa vào dữ liệu mình muốn kt mà khai cho khớp
                PROPERTY project = null;
                foreach (var item in projects.Rows)
                {
                    //var tPropertyName = item["PropertyName"].ToString();
                    ////var tPropertyType = item["PropertyType"].ToString();
                    //var tStreet_ID = item["Street"].ToString();
                    //var tDistrict_ID = item["District"].ToString();
                    //var tWard_ID = item["Ward"].ToString();
                    //var tUnitPrice = item["Price"].ToString();
                    //var tContent = item["Content"].ToString();
                    ////var a = db.PROPERTY_TYPE.FirstOrDefault(d1 => d1.CodeType == tPropertyType);
                    //var b = db.STREETs.FirstOrDefault(s => s.StreetName == tStreet_ID);
                    //var c = db.DISTRICTs.FirstOrDefault(d2 =  > d2.DistrictName == tDistrict_ID);
                    //var d3 = db.WARDs.FirstOrDefault(d2 => d2.WardName == tWard_ID);
                    
                    project = new PROPERTY()
                    {

                        PropertyName = item["PropertyName"].ToString(),
                        Avatar = item["Avatar"],
                        Images = item["Images"],
                        PropertyType_ID = db.PROPERTY_TYPE.ToList().FirstOrDefault(d1 => d1.CodeType == item["PropertyType"]).ID,
                        Content = item["Content"].ToString(),
                        Street_ID = db.STREETs.ToList().FirstOrDefault(s => s.StreetName == item["Street"]).ID,
                        Ward_ID = db.WARDs.ToList().FirstOrDefault(d => d.WardName == item["Ward"]).ID,
                        District_ID = db.DISTRICTs.ToList().FirstOrDefault(d => d.DistrictName == item["District"]).ID,
                        Price = Convert.ToInt32(item["Price"]),
                        UnitPrice = "VND",
                        Area = Convert.ToInt32(item["Area"]),
                        BedRoom = Convert.ToInt32(item["Bedroom"]),
                        BathRoom = Convert.ToInt32(item["Bathroom"]),
                        PackingPlace = Convert.ToInt32(item["PackingPlace"]),
                        UserID = db.USERs.ToList().FirstOrDefault(u => u.Email == item["User"]).ID,
                        Created_at = DateTime.Now,
                        Create_post = DateTime.Now,
                        Status_ID = db.PROJECT_STATUS.ToList().FirstOrDefault(t => t.Status_Name == item["Status"]).ID,
                        Note = "Done",
                    };
                    
                }
                //_context.ReferenceProjects.Add(projects.Header.Contains("ID") ? item["Id"] : project.PropertyName, project);

                try
                {
                    db.PROPERTies.Add(project);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }

            }
        }
        public void ShowProjectDetails(Table shownProjectDetails)
        {
            //Arrange
            var expectedProjectDetails = shownProjectDetails.Rows.Single();

            //Act
            var actualProjectDetails = _result.Model<PROPERTY>();

            //Assert
            actualProjectDetails.Should().Match<PROPERTY>(
                b => b.PropertyName == expectedProjectDetails["PropertyName"]
                && b.Content == expectedProjectDetails["Content"]);
               
        }
         
        public void OpenProjectDetails(string projectId)
        {
            var project = _context.ReferenceProjects.GetById(projectId);
            using (var controller = new ProjectController())
            {
                _result = controller.projectDetail(project.ID);
            }
        }
    }
}
