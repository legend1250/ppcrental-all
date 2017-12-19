using System;
using TechTalk.SpecFlow;
using PPCRental.AcceptanceTests.Drivers.Search;
namespace PPCRental.AcceptanceTests.StepDefinitions
{
    [Binding, Scope(Tag = "web")]
    public class UC001_SearchSteps
    {
        private  SearchDriver _searchDriver;
        public void SearchSteps(SearchDriver driver)
        {
            _searchDriver = driver;
        }
        [Given(@"the following project")]
        public void GivenTheFollowingProject(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I search for project by the phrase '(.*)'")]
        public void WhenISearchForProjectByThePhrase(string searchText,int district, int street, int ward, int ptype)
        {
            _searchDriver.Searching(searchText,district,street,ward,ptype);
        }
        
        [Then(@"the list of found project should contain only: '(.*)'")]
        public void ThenTheListOfFoundProjectShouldContainOnly(string expectedTitleList)
        {
            _searchDriver.ShowProject(expectedTitleList);
        }
    }
}
