using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PPCRental.UITests.Selenium.Support;

namespace PPCRental.UITests.Selenium.StepDefinitions
{
    [Binding]
   public class LoginLogoutSteps: SeleniumStepsBase
    {
        IWebDriver driver;
        //[Given(@"following user account:")]
        //public void GivenFollowingUserAccount(Table table)
        //{
            
        //}

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
        
        [When(@"I enter username and password of user")]
        public void WhenIEnterUsernameAndPasswordOfUser(Table table)
        {
            driver.FindElement(By.Id("user_login")).SendKeys("user@gmail.com");
            driver.FindElement(By.Id("user_pass")).SendKeys("user123");
        }

        [When(@"I enter username and password of sale")]
        public void WhenIEnterUsernameAndPasswordOfSale(Table table)
        {
            driver.FindElement(By.Id("user_login")).SendKeys("SaleNo1@gmail.com");
            driver.FindElement(By.Id("user_pass")).SendKeys("sale123");
        }

        [When(@"I enter username and password of agency")]
        public void WhenIEnterUsernameAndPasswordOfAgency(Table table)
        {
            driver.FindElement(By.Id("user_login")).SendKeys("Agency@gmail.com");
            driver.FindElement(By.Id("user_pass")).SendKeys("agency123");
        }

        [When(@"I enter username and password of admin")]
        public void WhenIEnterUsernameAndPasswordOfAdmin(Table table)
        {

            driver.FindElement(By.Id("user_login")).SendKeys("admin@gmail.com");
            driver.FindElement(By.Id("user_pass")).SendKeys("admin123");
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
            driver.FindElement(By.Id("user_login")).SendKeys("user@gmail.com");
            driver.FindElement(By.Id("user_pass")).SendKeys("user123");
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

        [When(@"I enter right username and wrong password")]
        public void WhenIEnterRightUsernameAndWrongPassword()
        {
 
            driver.FindElement(By.Id("user_login")).SendKeys("user@gmail.com");
            driver.FindElement(By.Id("user_pass")).SendKeys("user12345678");
            driver.FindElement(By.Id("wp-submit")).Click();
            Assert.AreEqual(true, driver.FindElement(By.Id("wp-submit")).Displayed);
        }
        [When(@"I enter wrong username and right password")]
        public void WhenIEnterWrongUsernameAndRightPassword()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:53887/User/Login");
            driver.FindElement(By.Id("user_login")).SendKeys("User@gmail.com");
            driver.FindElement(By.Id("user_pass")).SendKeys("user123");
            driver.FindElement(By.Id("wp-submit")).Click();
        }

        [When(@"I enter wrong username and password")]
        public void WhenIEnterWrongUsernameAndPassword()
        {
            driver = new ChromeDriver();

            driver.FindElement(By.Id("user_login")).SendKeys("user");
            driver.FindElement(By.Id("user_pass")).SendKeys("user12345");
            driver.FindElement(By.Id("wp-submit")).Click();
        }
        [Then(@"I could see message wrong password or username")]
        public void ThenICouldSeeMessageWrongPasswordOrUsername()
        {
            Assert.AreEqual(true, driver.FindElement(By.Id("login_error")).Displayed);
        }

        

    }
}
