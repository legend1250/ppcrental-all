using System;
using TechTalk.SpecFlow;
using PPCRental.AcceptanceTests.Drivers.Search;
namespace PPCRental.AcceptanceTests.StepDefinitions
{
    [Binding, Scope(Tag = "automated")]
    public class UC001_SearchSteps
    {
        private  SearchDriver _searchDriver;
        public void SearchSteps(SearchDriver driver)
        {
            _searchDriver = driver;
        }
        
        [When(@"I search for project by the phrase '(.*)'")]
        public void WhenISearchForProjectByThePhrase(string searchText)
        {
            _searchDriver.Searching(searchText);
        }
        
        [Then(@"the list of found project should contain only: '(.*)'")]
        public void ThenTheListOfFoundProjectShouldContainOnly(string expectedTitleList)
        {
            _searchDriver.ShowProject(expectedTitleList);
        }
    }
}
