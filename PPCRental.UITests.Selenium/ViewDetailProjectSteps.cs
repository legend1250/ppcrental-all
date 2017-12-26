using System.Linq;
using TechTalk.SpecFlow;
using PPCRental.UITests.Selenium.Support;
using PPCRental.AcceptanceTests.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PPCRental.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PPCRental.UITests.Selenium
{
    [Binding, Scope(Tag = "web")]
    public class ViewDetailProjectSteps: SeleniumStepsBase
    {
        IWebDriver driver;
        [When(@"I open the details of '(.*)'")]
        public void WhenIOpenTheDetailsOf(string expectedTitleList)
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:53887/Home/Index");
            driver.FindElement(By.XPath("//*[@id='home - property - listing']/div/div/div[1]/article/div/header/div/h6/a")).Click();
        }

        [Then(@"the project details should show")]
        public void ThenTheProjectDetailsShouldShow(Table showProjectDetail)
        {
            Assert.AreEqual(true, driver.FindElement(By.XPath("//*[@id='property - single']/div[2]/div/div[1]/section[1]/h3")).Displayed);
        }
    }
}
