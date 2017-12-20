using System;
using TechTalk.SpecFlow;
using PPCRental.AcceptanceTests.Drivers.ProjectDetail;

namespace PPCRental.AcceptanceTests.StepDefinitions
{
    [Binding]

    public class UC003_ViewDetailProjectSteps
    {
        private readonly ProjectDetailDriver _projectDriver;
        public UC003_ViewDetailProjectSteps(ProjectDetailDriver driver)
        {
            _projectDriver = driver;
        }
        
        [Given(@"the following project")]
        public void GivenTheFollowingProject(Table givenProjects)
        {
            _projectDriver.InsertProjectToDB(givenProjects);
        }
        [When(@"I open the details of '(.*)'")]
        public void WhenIOpenTheDetailsOf(string projectId)
        {
            _projectDriver.OpenProjectDetails(projectId);
        }
        [Then(@"the project details should show detail")]
        public void ThenTheProjectDetailsShouldShowDetail(Table shownBookDetails)
        {
            _projectDriver.ShowProjectDetails(shownBookDetails);
        }
    }
}
