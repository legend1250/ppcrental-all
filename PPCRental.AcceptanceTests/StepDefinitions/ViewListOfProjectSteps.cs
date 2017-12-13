using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PPCRental.AcceptanceTests.StepDefinitions
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
        
        [When(@"I press property button")]
        public void WhenIPressPropertyButton()
        {
            driver.FindElement(By.Id("property")).Click();
        }
        
        [Then(@"I see list of project")]
        public void ThenISeeListOfProject()
        {
            driver.Navigate().GoToUrl("http://localhost:53887/Project/ProjectList");
            string element = driver.FindElement(By.XPath("//*[@id='property - listing']/div/div/div[1]/article/div/header/div/h6/a")).Text;
            Assert.AreEqual("ASA LightT", element);
            string element2 = driver.FindElement(By.XPath("//*[@id='property - listing']/div/div/div[2]/article/div/header/div/h6/a")).Text;
            Assert.AreEqual("CALEDON Tan Phu", element2);
        }
    }
}
