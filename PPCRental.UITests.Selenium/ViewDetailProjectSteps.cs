using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using PPCRental.UITests.Selenium.Support;
using PPCRental.AcceptanceTests.Common;
using OpenQA.Selenium;
using PPCRental.Models;

namespace PPCRental.UITests.Selenium
{
    [Binding, Scope(Tag = "web")]
    public sealed class ViewDetailProjectSteps: SeleniumStepsBase
    {
        [Given(@"the following project")]
        public void GivenTheFollowingProject(Table givenProject)
        {
            Browser.NavigateTo("Home");
            Browser.NavigateTo("Project/ProjectList");

          //  Browser.SetTextBoxValue("searchTerm", searchText);
           // Browser.SubmitForm("searchForm");
        }

        [When(@"I open the details of '(.*)'")]
        public void WhenIOpenTheDetailsOf(string expectedTitleList)
        {
            //Arrange
            var expectedTitles = expectedTitleList.Split(',').Select(t => t.Trim().Trim('\''));

            //Action
            Browser.SwitchTo().DefaultContent();
           // var foundProjects = from row in Browser.FindElements(By.XPath("//*[@id='property - listing']/div/div/div[9]/article/div/header/div/h6/a"))
             //                let PropertyName = row.FindElement(By.XPath("")).Text
                             //let Content = row.FindElement(By.Id("author")).Text
                //             select new  PROPERTY { PropertyName= PropertyName };

            //Assert
            // ProjectAssertions.FoundProjectShouldMatchTitles(foundProjects, expectedTitles);
        }

        [Then(@"the project details should show")]
        public void ThenTheProjectDetailsShouldShow(Table showProjectDetail)
        {
           
        }
    }
}
