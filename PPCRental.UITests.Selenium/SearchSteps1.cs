using System.Linq;
using TechTalk.SpecFlow;
using PPCRental.AcceptanceTests.Common;
using PPCRental.UITests.Selenium.Support;
using PPCRental.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PPCRental.UITests.Selenium.StepDefinitions
{
    [Binding, Scope(Tag = "web")]
    public class SearchSteps : SeleniumStepsBase
    {
        //IWebDriver driver;
    
        [When(@"I search for project by the phrase '(.*)'")]
            public void WhenISearchForProjectByThePhrase(string searchText)
        {
            //Navigate to home page
            Browser.NavigateTo("Home");

            //Input value to search for
            Browser.SetTextBoxValue("searchTerm", searchText);

            //Click on search button
            Browser.SubmitForm("searchForm");
        }
        
        [Then(@"the list of found project should contain only: '(.*)'")]
        public void ThenTheListOfFoundProjectShouldContainOnly(string expectedTitleList)
        {
            //Arrange
            var expectedTitles = expectedTitleList.Split(',').Select(t => t.Trim().Trim('\''));

            //Action
            Browser.SwitchTo().DefaultContent();
            var foundProjects = from row in Browser.FindElements(By.XPath("//table/tbody/tr")) //???xpath
                             let propertyname = row.FindElement(By.Id("keyword")).Text
                             select new PROPERTY { PropertyName= propertyname };

            //Assert
            ProjectAssertions.FoundProjectShouldMatchTitles(foundProjects, expectedTitles);
        }
    }
}
