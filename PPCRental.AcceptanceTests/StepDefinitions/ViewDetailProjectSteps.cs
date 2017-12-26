using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using PPCRental.AcceptanceTests.Drivers.ProjectDetail;

namespace PPCRental.AcceptanceTests.StepDefinitions
{
    [Binding]
    public sealed class ViewDetailProjectSteps
    {
        private readonly ProjectDetailDriver _projectDetailDriver;
        public  ViewDetailProjectSteps(ProjectDetailDriver project)
        {
            _projectDetailDriver = project;
        }
        [Given(@"the following project")]
        public void GivenTheFollowingProject(Table givenProject)
        {
            _projectDetailDriver.InsertProjectToDB(givenProject);
        }

        [When(@"I open the details of '(.*)'")]
        public void WhenIOpenTheDetailsOf(string projectID)
        {
            _projectDetailDriver.OpenProjectDetails(projectID);
        }

        [Then(@"the project details should show")]
        public void ThenTheProjectDetailsShouldShow(Table showProjectDetail)
        {
            _projectDetailDriver.ShowProjectDetails(showProjectDetail);
        }

    }
}
