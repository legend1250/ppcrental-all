using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using PPCRental.Controllers;
using PPCRental.Models;
using PPCRental.AcceptanceTests.Common;
using PPCRental.AcceptanceTests.Support;

namespace PPCRental.AcceptanceTests.Drivers.Search
{
    public class SearchDriver
    {
        private readonly SearchResultState _state;
        public SearchDriver(SearchResultState state)
        {
            _state = state;
        }
        public void Searching(String projectname, int district, int street, int ward, int ptype)
        {
            var controller = new ProjectController();
            _state.ActionResult = controller.Searching( projectname,  district,  street,ward, ptype);
        }
        public void ShowProject(string expectedTitlesString)
        {
            var expectesTitles= form t in expectedTitlesString.Slit(',')
                select t.Trim().Trim('\'');
            var ShowProject = _state.ActionResult.Model<IEnumerable<DBModel>>();
            ProjectAssertions.HomeScreenShouldShow(ShowProject, expectesTitles);


        }
        public void ShowBooks(Table expectedProject)
        {
            //Arrange
            var expectedTitles = expectedProject.Rows.Select(r => r["Title"]);

            //Action
            var ShownBooks = _state.ActionResult.Model<IEnumerable<DBModel>>();

            //Assert
            ProjectAssertions.HomeScreenShouldShowInOrder(ShownBooks, expectedTitles);
        }
    }
}
