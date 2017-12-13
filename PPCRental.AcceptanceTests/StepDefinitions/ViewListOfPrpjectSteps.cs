using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PPCRental.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class UC002_ViewListOfPrpjectSteps
    {
        IWebDriver driver;
        [Given(@"I am in homepage")]
        public void GivenIAmInHomepage()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:53887/");
        }
        
        [When(@"I press property button")]
        public void WhenIPressPropertyButton()
        {
            driver.FindElement(By.XPath("//*[@id='property']")).Click();
        }
        
        [Then(@"I see list of project")]
        public void ThenISeeListOfProject()
        {
            string element = driver.FindElement(By.CssSelector("#property-listing > div > div > div:nth-child(1) > article > div > header > div > h6 > a")).Text;
            Assert.AreEqual("ASA LightT", element);
        }
    }
}
