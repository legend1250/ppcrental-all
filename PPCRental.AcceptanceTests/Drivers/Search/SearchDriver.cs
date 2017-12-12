using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPCRental.Controllers;
using PPCRental.Models;

namespace PPCRental.AcceptanceTests.Drivers.Search
{
    class SearchDriver
    {
        private readonly SearchResultState _state;

        public SearchDriver()
        {
        }

        public SearchDriver(SearchResultState state)
        {
            _state = state;
        }
        public void Search(string searchTerm)
        {
            var controller = new ProjectController();
            //_state.ActionResult = controller.Searching(searchTerm);
        }
        public void ShowProjects(string expectedNameProjectString)
        {
            //Arrange
            var expectedTitles = from t in expectedNameProjectString.Split(',')
                                 select t.Trim().Trim('\'');

            //Action
            var ShowProjects = _state.ActionResult;

            //Assert
            //BookAssertions.HomeScreenShouldShow(ShownBooks, expectedTitles);
        }
    }
}
