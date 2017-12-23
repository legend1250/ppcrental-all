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


                    var project = new PROPERTY()
                    {

                        PropertyName = item["PropertyName"],
                        PropertyType_ID = db.PROPERTY_TYPE.ToList().FirstOrDefault(d1 => d1.CodeType == item["PropertyType"]).ID,
                        Street_ID = db.STREETs.ToList().FirstOrDefault(s => s.StreetName == item["Street"]).ID,
                        District_ID = db.DISTRICTs.ToList().FirstOrDefault(d => d.DistrictName == item["District"]).ID,
                        Ward_ID = db.WARDs.ToList().FirstOrDefault(d => d.WardName == item["Ward"]).ID,
                        // Avatar= item["Avatar"],//Price = item["Price"].ToString(),

                        UnitPrice = "VND",
                        Created_at = DateTime.Now,
                        Create_post = DateTime.Now,
                        Note = "Done",
                        UserID= db.USERs.ToList().FirstOrDefault(u => u.Email == item["User"]).ID,
                        Price = int.Parse(item["Price"].ToString()),
                        BathRoom = int.Parse(item["Bathroom"].ToString()),
                        BedRoom = int.Parse(item["Bedroom"].ToString()),
                        PackingPlace = int.Parse(item["PackingPlace"].ToString()),
                        Content = item["Content"].ToString(),
                        Area = int.Parse(item["Area"].ToString())
                    };
                    _context.ReferenceProjects.Add(
                        projects.Header.Contains("ID") ? item["ID"] : project.PropertyName, project);

                    db.PROPERTies.Add(project);
                }
                db.SaveChanges();

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
                && b.Street_ID == int.Parse(expectedProjectDetails["Street"])
                && b.Ward_ID == int.Parse(expectedProjectDetails["Ward"])
                && b.District_ID == int.Parse(expectedProjectDetails["District"])
                && b.Avatar == expectedProjectDetails["Avatar"]
                && b.PropertyType_ID == int.Parse(expectedProjectDetails["PropertyType_ID"])
                && b.Price == int.Parse(expectedProjectDetails["Price"])
                && b.Area == int.Parse(expectedProjectDetails["Area"])
                && b.BedRoom == int.Parse(expectedProjectDetails["Bedroom"])
                && b.BathRoom == int.Parse(expectedProjectDetails["Bathroom"])
                && b.PackingPlace == int.Parse(expectedProjectDetails["PackingPlace"])
                && b.UserID == int.Parse(expectedProjectDetails["User"]));

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
