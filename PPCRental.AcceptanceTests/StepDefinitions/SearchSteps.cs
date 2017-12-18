using System;
using TechTalk.SpecFlow;
using PPCRental.AcceptanceTests.Drivers.Search;
namespace PPCRental.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class UC001_SearchSteps
    {
        private readonly SearchDriver _searchDriver;
        [Given(@"the following project")]
        public void GivenTheFollowingProject(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I search for project by the phrase '(.*)'")]
        public void WhenISearchForProjectByThePhrase(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the list of found project should contain only: '(.*)'")]
        public void ThenTheListOfFoundProjectShouldContainOnly(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
