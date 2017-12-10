using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PPCRental.AcceptanceTests.Features
{
    [Binding]
    public class UC007_Login_LogoutSteps
    {
        IWebDriver driver;
        [Given(@"I am in homepage\.")]
        public void GivenIAmInHomepage_()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:53887/Home/Index");
        }
        
        [Given(@"Navigate to login page\.")]
        public void GivenNavigateToLoginPage_()
        {
            driver.Navigate().GoToUrl("http://localhost:53887/User/Login");
        }
        
        [When(@"I enter username and password\.")]
        public void WhenIEnterUsernameAndPassword_()
        {
            driver.FindElement(By.Id("user_login")).SendKeys("sale");
            driver.FindElement(By.Id("user_pass")).SendKeys("123456");
        }
        
        [When(@"Click on login button\.")]
        public void WhenClickOnLoginButton_()
        {
            driver.FindElement(By.Id("wp-submit")).Click();
        }
        
        [Then(@"I could see logout button\.")]
        public void ThenICouldSeeLogoutButton_()
        {
            Assert.AreEqual(true, driver.FindElement(By.Id("logout")).Displayed);

        }

        [When(@"Click on logout button\.")]
        public void WhenClickOnLogoutButton_()
        {
            driver.FindElement(By.Id("logout")).Click();
        }

        [Then(@"I could see login button\.")]
        public void ThenICouldSeeLoginButton_()
        {
            Assert.AreEqual(true, driver.FindElement(By.Id("loginbtn")).Displayed);

        }
    }
}
