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
       
        private readonly CatalogContext _context;
        private ActionResult result;
        
        public ProjectDetailDriver(CatalogContext context)
        {
            _context = context;
        }
        public void InsertProjectToDB(Table projects)
        {
            using (var db = new ppcrental3119Entities())
            {
                
                foreach (var item in projects.Rows)
                {
                    var tPropertyType = item["PropertyType"].ToString();
                    var tStreet_ID = item["Street"].ToString();
                    var tDistrict_ID = item["District"].ToString();
                    var tWard_ID = item["Ward"].ToString();
                    var tPropertyName = item["PropertyName"].ToString();
                    var tUnitPrice = item["UnitPrice"].ToString();
                    var tContent = item["Content"].ToString();
                    var tStatus_ID = item["Status"].ToString();
                    var tUser_ID = item["User"].ToString();
                    var tSale_ID = item["Sale"].ToString();

                    var a = db.PROPERTY_TYPE.FirstOrDefault(d1 => d1.CodeType == tPropertyType);
                    var b = db.STREETs.FirstOrDefault(s => s.StreetName == tStreet_ID);
                    var c = db.DISTRICTs.FirstOrDefault(d2 => d2.DistrictName == tDistrict_ID);
                    var d3 = db.WARDs.FirstOrDefault(d2 => d2.WardName == tWard_ID);
                    var e = db.PROJECT_STATUS.FirstOrDefault(st => st.Status_Name == tStatus_ID);
                    var h = db.USERs.FirstOrDefault(u => u.Email == tUser_ID);
                    var project = new PROPERTY()
                    {

                        PropertyName = item["PropertyName"].ToString(),
                        PropertyType_ID = a.ID,
                        Street_ID = db.STREETs.FirstOrDefault(s => s.StreetName == tStreet_ID).ID,
                        District_ID = db.DISTRICTs.FirstOrDefault(d => d.DistrictName == tDistrict_ID).ID,
                        Ward_ID = db.WARDs.FirstOrDefault(d => d.WardName == tWard_ID).ID,
                        UnitPrice = item["UnitPrice"].ToString(),
                        Price = int.Parse(item["Price"].ToString()),
                        BathRoom = int.Parse(item["Bathroom"].ToString()),
                        BedRoom = int.Parse(item["Bedroom"].ToString()),
                        PackingPlace = int.Parse(item["PackingPlace"].ToString()),
                        Content = item["Content"].ToString(),
                        Area = int.Parse(item["Area"].ToString()),
                        Avatar = item["Avatar"],
                        Created_at = DateTime.Today,
                        Create_post = DateTime.Today,
                        Updated_at = DateTime.Today,
                        Sale_ID = db.ROLEs.FirstOrDefault(sale => sale.roleName == tSale_ID).id,
                       // UserID = db.USERs.FirstOrDefault(m => m.Email == tUser_ID).ID,
                        Note= item["Note"],
                        Status_ID = e.ID
                    };
                   
                    _context.ReferenceProjects.Add(projects.Header.Contains("ID") ? item["ID"] : project.PropertyName, project);
                    db.PROPERTies.Add(project);
                }

                db.SaveChanges();
            }
            
        }
      
        public void ShowProjectDetails(Table shownProjectDetails)
        {
            //Arrange- lấy data từ table 2 feature
            var expectedProjectDetails = shownProjectDetails.Rows.Single();

            //Act
            var actualProjectDetails = result.Model<View_project_from_index>();

            //Assert
            actualProjectDetails.Should().Match<View_project_from_index>(
                b => b.PropertyName == expectedProjectDetails["PropertyName"]
                && b.Content == expectedProjectDetails["Content"]);
               
        }
         
        public void OpenProjectDetails(string projectId)
        {
            var project = _context.ReferenceProjects.GetById(projectId);
            using (var controller = new ProjectController())
            {
                result = controller.projectDetail(project.ID);
            }
        }
    }
}
