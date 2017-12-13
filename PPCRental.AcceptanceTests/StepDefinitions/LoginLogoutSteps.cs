using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PPCRental.AcceptanceTests.StepDefinitions
{
    [Binding]
   public class LoginLogoutSteps
    {
        IWebDriver driver;
        [Given(@"I am in home page")]
        public void GivenIAmInHomePage()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:53887/Home/Index");
        }

        [Given(@"Navigate to login page")]
        public void GivenNavigateToLoginPage()
        {
            driver.Navigate().GoToUrl("http://localhost:53887/User/Login");
        }

        [When(@"I enter username and password")]
        public void WhenIEnterUsernameAndPassword()
        {
            driver.FindElement(By.Id("user_login")).SendKeys("sale");
            driver.FindElement(By.Id("user_pass")).SendKeys("ppc123");
        }

        [When(@"Click on login button")]
        public void WhenClickOnLoginButton()
        {
            driver.FindElement(By.Id("wp-submit")).Click();
        }

        [Then(@"I could see logout button")]
        public void ThenICouldSeeLogoutButton()
        {
            Assert.AreEqual(true, driver.FindElement(By.Id("logout")).Displayed);
        }

        [Given(@"I were login")]
        public void IWereLogin()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:53887/User/Login");
            driver.FindElement(By.Id("user_login")).SendKeys("sale");
            driver.FindElement(By.Id("user_pass")).SendKeys("ppc123");
            driver.FindElement(By.Id("wp-submit")).Click();
            Assert.AreEqual(true, driver.FindElement(By.Id("logout")).Displayed);
        }

        [When(@"Click on logout button")]
        public void WhenClickOnLogoutButton()
        {
            driver.FindElement(By.Id("logout")).Click();
        }

        [Then(@"I could see login button")]
        public void ThenICouldSeeLoginButton()
        {
            Assert.AreEqual(true, driver.FindElement(By.Id("loginbtn")).Displayed);
        }

    }
}
