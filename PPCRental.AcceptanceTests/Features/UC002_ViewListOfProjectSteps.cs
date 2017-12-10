using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PPCRental.AcceptanceTests.Features
{
    [Binding]
    public class UC002_ViewListOfProjectSteps
    {
        IWebDriver driver;
        [Given(@"I am in homepage")]
        public void GivenIAmInHomepage()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:53887/Home/Index");
        }
        
        [When(@"I press property")]
        public void WhenIPressProperty()
        {
            driver.FindElement(By.Id("property")).Click();
        }
        
        [Then(@"I see list project")]
        public void ThenISeeListProject()
        {
            driver.Navigate().GoToUrl("http://localhost:53887/Project/ProjectList");
        }
    }
}
