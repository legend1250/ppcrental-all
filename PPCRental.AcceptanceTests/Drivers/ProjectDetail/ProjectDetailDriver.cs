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
        private const decimal ProjectDefaultPrice = 10;
        private  CatalogContext _context;
        private ActionResult _result;

        public void ProjectDetailsDriver(CatalogContext context)
        {
            _context = context;
        }

        //public void InsertProjectToDB(Table projects)
        //{
        //    using (var db = new ppcrental3119Entities())
        //    {
        //        foreach (var row in projects.Rows)
        //        {
        //            var project = new PROPERTY
        //            {
        //                PropertyName = row["Property"],
        //                //Price = projects.Header.Contains("Price")
        //                //    ? Convert.ToDecimal(row["Price"])
        //                //    : ProjectDefaultPrice
        //            };

        //            _context.ReferenceProjects.Add(
        //                    projects.Header.Contains("Id") ? row["Id"] : project.Property,
        //                    project);

        //            db.Books.Add(project);
        //        }

        //        db.SaveChanges();
        //    }
        //}
        public void InsertProjectToDB(Table projects)
        {
            using (var db = new ppcrental3119Entities())
            {
                var oStreets = db.STREETs.ToList();

                foreach (var item in projects.Rows)
                {
                    var tPropertyType = item["Property_type"].ToString();
                    var tStreet_ID = item["Street"].ToString();
                    var tDistrict_ID = item["District"].ToString();
                    var tWard_ID = item["Ward"].ToString();
                    var tPropertyName = item["PropertyName"].ToString();
                    var tUnitPrice = item["Price"].ToString();
                    var tContent = item["Content"].ToString();

                    //var a = db.PROPERTY_TYPE.FirstOrDefault(d1 => d1.CodeType == tPropertyType);
                    //var b = db.STREETs.FirstOrDefault(s => s.StreetName == tStreet_ID);
                    //var c = db.DISTRICTs.FirstOrDefault(d2 => d2.DistrictName == tDistrict_ID);
                    //var d3 = db.WARDs.FirstOrDefault(d2 => d2.WardName == tWard_ID);


                    PROPERTY project = new PROPERTY()
                    {

                        PropertyName = item["PropertyName"].ToString(),
                        PropertyType_ID = db.PROPERTY_TYPE.FirstOrDefault(d1 => d1.CodeType == tPropertyType).ID,
                        Street_ID = db.STREETs.FirstOrDefault(s => s.StreetName == tStreet_ID).ID,
                        District_ID = db.DISTRICTs.FirstOrDefault(d => d.DistrictName == tDistrict_ID).ID,
                        Ward_ID = db.WARDs.FirstOrDefault(d => d.WardName == tWard_ID).ID,
                        UnitPrice = item["Price"].ToString(),

                        Price = int.Parse(item["Price"].ToString()),
                        BathRoom = int.Parse(item["Bathroom"].ToString()),
                        BedRoom = int.Parse(item["Bedroom"].ToString()),
                        PackingPlace = int.Parse(item["PackingPlace"].ToString()),
                        Content = item["Content"].ToString(),
                        Area = "200m2",


                    };
                    //project.STREET = db.STREETs.Find(project.Street_ID);
                    // project.STREET.StreetName
                   // _context.ReferenceProjects.Add(projects.Header.Contains("ID") ? item["ID"] : project.PropertyName, project);
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
                && b.Street_ID == expectedProjectDetails["Street"]
                && b.Price == decimal.Parse(expectedBookDetails["Price"]));
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
