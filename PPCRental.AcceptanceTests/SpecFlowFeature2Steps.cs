using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PPCRental.AcceptanceTests
{
    [Binding]
    public class SpecFlowFeature2Steps
    {
        IWebDriver driver;
        [Given(@"I am in homepage")]
        public void GivenIAmInHomepage()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:53887");
        }
        
        [Given(@"Navigate to login page")]
        public void GivenNavigateToLoginPage()
        {
            driver.Navigate().GoToUrl("http://localhost:53887/User/Login");
        }
        
        [When(@"I enter Username and Password")]
        public void WhenIEnterUsernameAndPassword()
        {
            driver.FindElement(By.Id("user_login")).SendKeys("sale");
            driver.FindElement(By.Id("user_pass")).SendKeys("e10adc3949ba59abbe56e057f20f883e");
        }
        
        [When(@"Click on login button")]
        public void WhenClickOnLoginButton()
        {
            driver.FindElement(By.Id("wp-submit")).Click();
            
        }
        
        [Then(@"i could see logout button")]
        public void ThenICouldSeeLogoutButton()
        {
            Assert.AreEqual(true, driver.FindElement(By.Id("logout")).Displayed);
            driver.FindElement(By.Id("logout")).Click();
        }
    }
}
