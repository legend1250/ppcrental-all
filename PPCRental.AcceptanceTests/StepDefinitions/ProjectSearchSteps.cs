using System;
using TechTalk.SpecFlow;
using PPCRental.AcceptanceTests.Drivers.Search;

namespace PPCRental.AcceptanceTests.StepDefinitions
{
    [Binding, Scope(Tag = "automated")]
    public class ProjectSearchSteps
    {
        private readonly SearchDriver _searchDriver = new SearchDriver();
        
        [Given(@"the following Project")]
        public void GivenTheFollowingProject(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I search for books by the phrase '(.*)'")]
        public void WhenISearchForBooksByThePhrase(string p0)
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
