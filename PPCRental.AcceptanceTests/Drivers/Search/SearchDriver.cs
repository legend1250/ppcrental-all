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
        public void Searching(String projectname)
        {
            var controller = new ProjectController();
            _state.ActionResult = controller.Searching(projectname,0,0,0,0,0,0,0,0,0,0);
        }
        public void ShowProject(string expectedTitlesString)
        {
            var expectesTitles = from t in expectedTitlesString.Split(',')
                select t.Trim().Trim('\'');
            var ShowProject = _state.ActionResult.Model<IEnumerable<PROPERTY>>();
            ProjectAssertions.HomeScreenShouldShow(ShowProject, expectesTitles);

        }
        public void ShowListProject(Table expectedProject)
        {
            //Arrange
            var expectedTitles = expectedProject.Rows.Select(r => r["Title"]);

            //Action
            var ShownProjects = _state.ActionResult.Model<IEnumerable<PROPERTY>>();

            //Assert
            ProjectAssertions.HomeScreenShouldShowInOrder(ShownProjects, expectedTitles);
        }
    }
}
