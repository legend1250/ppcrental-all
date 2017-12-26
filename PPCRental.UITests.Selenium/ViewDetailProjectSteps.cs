using System.Linq;
using TechTalk.SpecFlow;
using PPCRental.UITests.Selenium.Support;
using PPCRental.AcceptanceTests.Common;
using OpenQA.Selenium;
using PPCRental.Models;

namespace PPCRental.UITests.Selenium
{
    [Binding, Scope(Tag = "web")]
    public class ViewDetailProjectSteps: SeleniumStepsBase
    {
        

        [When(@"I open the details of '(.*)'")]
        public void WhenIOpenTheDetailsOf(string expectedTitleList)
        {
            Browser.NavigateTo("Home");
            Browser.FindElement(By.CssSelector("#home-property-listing > div > div > div:nth-child(1) > article > div > header > div > h6 > a")).Click();
            
        }

        [Then(@"the project details should show")]
        public void ThenTheProjectDetailsShouldShow(Table showProjectDetail)
        {
            var expectedTitles = showProjectDetail.Rows.Select(r => r["PropertyName"]);
            // string found = 
            //Action
            string found = Browser.FindElement(By.XPath("//*[@id='property - single']/div[2]/div/div[1]/section[1]/h3")).Text;
            //var foundBooks = from row in Browser.FindElements(By.XPath("//*[@id='property - single']/div[2]/div/div[1]/section[1]/h3"))
            //                 let propertyName = row.FindElement(By.XPath("//*[@id='property - single']/div[2]/div/div[1]/section[1]/h3")).Text
            //                 select new PROPERTY { PropertyName = propertyName };

            //Assert
            //ProjectAssertions.FoundProjectShouldMatchTitlesInOrder(found, expectedTitles);
        }
    }
}
"