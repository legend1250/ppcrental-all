using System.Linq;
using TechTalk.SpecFlow;
using PPCRental.AcceptanceTests.Common;
using PPCRental.UITests.Selenium.Support;
using PPCRental.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PPCRental.UITests.Selenium.StepDefinitions
{
    [Binding, Scope(Tag = "web")]
    public class SearchSteps : SeleniumStepsBase
    {
        IWebDriver driver;

        [When(@"I search for project by the phrase '(.*)'")]
            public void WhenISearchForProjectByThePhrase(string searchText)
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:53887/Home/Index");
            driver.FindElement(By.Id("keyword")).SendKeys("CITY Gate");
            driver.FindElement(By.Id("keyword")).SendKeys("Garden");
            driver.FindElement(By.XPath("//*[@id='adv - search - form']/button")).Click();
        }
        
        [Then(@"the list of found project should contain only: '(.*)'")]
        public void ThenTheListOfFoundProjectShouldContainOnly(string expectedTitleList)
        {
            Assert.AreEqual(true, driver.FindElement(By.XPath("//*[@id='property - listing']/div/div/div[4]/article/div/header/div/h6/a")).Displayed);
            Assert.AreEqual(true, driver.FindElement(By.XPath("//*[@id='property - listing']/div/div/div/article/div/header/div/h6/a")).Displayed);
            
        }
    }
}
