using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PPCRental.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class ChangePasswordTestSteps
    {
        public IWebDriver driver;
        [Given(@"I'm in Home Page")]
        public void GivenIMInHomePage()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:53887/");
        }
        
        [Given(@"Navigate to Login Page")]
        public void GivenNavigateToLoginPage()
        {
            driver.Navigate().GoToUrl("http://localhost:53887/User/Login");
        }

        [Given(@"I input UserName and Password")]
        public void GivenIInputUserNameAndPassword()
        {
            driver.FindElement(By.Id("user_login")).SendKeys("md5");
            driver.FindElement(By.Id("user_pass")).SendKeys("123456");
        }
        
        [When(@"I click Log In button")]
        public void WhenIClickLogInButton()
        {
            driver.FindElement(By.Id("wp-submit")).Click();
        }

        [Then(@"I click  Change Password button")]
        public void ThenIClickChangePasswordButton()
        {
            driver.Navigate().GoToUrl("http://localhost:53887/User/VerifyUser");
        }

        [Then(@"I input my answer for security question")]
        public void ThenIInputMyAnswerForSecurityQuestion()
        {
            driver.FindElement(By.Id("Answer")).SendKeys("123456789");
        }

        [Then(@"I click Submit button")]
        public void ThenIClickSubmitButton()
        {
            driver.FindElement(By.Id("submit")).Click();
        }

        [Then(@"Navigate to Set New Password Page")]
        public void ThenNavigateToSetNewPasswordPage()
        {
            driver.Navigate().GoToUrl("http://localhost:53887/User/Security");
        }

        [When(@"I input my current Password, my new Password and Confirm it")]
        public void WhenIInputMyCurrentPasswordMyNewPasswordAndConfirmIt()
        {
            driver.FindElement(By.Id("password")).SendKeys("123456");
            driver.FindElement(By.Id("newPassword")).SendKeys("123456");
            driver.FindElement(By.Id("rePassword")).SendKeys("123456");
        }
        
        [When(@"I Click Set New Password button")]
        public void WhenIClickSetNewPasswordButton()
        {
            driver.FindElement(By.Id("qa_submit")).Click();
        }

        [Then(@"Show ""(.*)"" message")]
        public void ThenShowMessage(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
