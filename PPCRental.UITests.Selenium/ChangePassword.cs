using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PPCRental.UITests.Selenium.StepDefinitions
{
    [Binding]
    public class ChangePassword
    {
        //Change success
        public IWebDriver driver;
        [Given(@"I login success with the given username and password")]
        public void GivenILoginSuccessWithTheGivenUsernameAndPassword(Table table)
        {

            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:53887/");
            driver.Navigate().GoToUrl("http://localhost:53887/User/Login");
            driver.FindElement(By.Id("user_login")).SendKeys("qqqq");
            driver.FindElement(By.Id("user_pass")).SendKeys("123456");
            driver.FindElement(By.Id("wp-submit")).Click();
        }

        [Given(@"I go to Change Password page")]
        public void GivenIGoToChangePasswordPage()
        {
            driver.Navigate().GoToUrl("http://localhost:53887/User/VerifyUser");
        }

        [When(@"I input all the following fields")]
        public void WhenIInputAllTheFollowingFields(Table table)
        {
            driver.FindElement(By.Id("Answer")).SendKeys("123456789");
            driver.FindElement(By.Id("submit")).Click();
            driver.Navigate().GoToUrl("http://localhost:53887/User/Security");
            driver.FindElement(By.Id("password")).SendKeys("123456");
            driver.FindElement(By.Id("newPassword")).SendKeys("ppc123");
            driver.FindElement(By.Id("rePassword")).SendKeys("ppc123");
        }

        [When(@"I click Set new Password button")]
        public void WhenIClickSetNewPasswordButton()
        {
            driver.FindElement(By.Id("qa_submit")).Click();
        }

        [Then(@"I see a message ""(.*)""")]
        public void ThenISeeAMessage(string p0)
        {
           
            driver.FindElement(By.XPath("//*[@id='login']/p[1]")).Text.CompareTo("Your password has been changed successfully");
        }

        //Input wrong answer for security question
        [Given(@"Login successfully")]
        public void GivenLoginSuccessfully(Table table)
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:53887/");
            driver.Navigate().GoToUrl("http://localhost:53887/User/Login");
            driver.FindElement(By.Id("user_login")).SendKeys("md5");
            driver.FindElement(By.Id("user_pass")).SendKeys("123456");
            driver.FindElement(By.Id("wp-submit")).Click();
        }

        [Given(@"Navigate to Change Pasword page")]
        public void GivenNavigateToChangePaswordPage()
        {
            driver.Navigate().GoToUrl("http://localhost:53887/User/VerifyUser");
        }


        [When(@"I input wrong answer for security question")]
        public void WhenIInputWrongAnswerForSecurityQuestion(Table table)
        {
            driver.FindElement(By.Id("Answer")).SendKeys("abcd");
            driver.FindElement(By.Id("submit")).Click();
        }

        [Then(@"I will see a message ""(.*)""")]
        public void ThenIWillSeeAMessage(string p0)
        {
            driver.FindElement(By.XPath("//*[@id='questionform']/div/div/div/div[1]/span")).Text.CompareTo("Error! Your answer not match with the answer in database.");
        }

        //Input wrong current password in change password page
        [Given(@"I Login successfully")]
        public void GivenILoginSuccessfully(Table table)
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:53887/");
            driver.Navigate().GoToUrl("http://localhost:53887/User/Login");
            driver.FindElement(By.Id("user_login")).SendKeys("md5");
            driver.FindElement(By.Id("user_pass")).SendKeys("123456");
            driver.FindElement(By.Id("wp-submit")).Click();
        }

        [Given(@"I Navigate to Change Pasword page")]
        public void GivenINavigateToChangePaswordPage()
        {
            driver.Navigate().GoToUrl("http://localhost:53887/User/VerifyUser");
        }


        [When(@"I input wrong current password")]
        public void WhenIInputWrongCurrentPassword(Table table)
        {
            driver.FindElement(By.Id("Answer")).SendKeys("123456789");
            driver.FindElement(By.Id("submit")).Click();
            driver.Navigate().GoToUrl("http://localhost:53887/User/Security");
            driver.FindElement(By.Id("password")).SendKeys("123321");
            driver.FindElement(By.Id("newPassword")).SendKeys("123456");
            driver.FindElement(By.Id("rePassword")).SendKeys("123456");
        }

        [Then(@"Show a message ""(.*)""")]
        public void ThenShowAMessage(string p0)
        {
            driver.FindElement(By.XPath("//*[@id='login_error']")).Text.CompareTo("Error! Your answer not match with the answer in database.");
        }

        //The new password does not meet the requirements

        [Given(@"I login success with my account")]
        public void GivenILoginSuccessWithMyAccount(Table table)
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:53887/");
            driver.Navigate().GoToUrl("http://localhost:53887/User/Login");
            driver.FindElement(By.Id("user_login")).SendKeys("md5");
            driver.FindElement(By.Id("user_pass")).SendKeys("123456");
            driver.FindElement(By.Id("wp-submit")).Click();
        }

        [Given(@"Go to change password page")]
        public void GivenGoToChangePasswordPage()
        {
            driver.Navigate().GoToUrl("http://localhost:53887/User/VerifyUser");
        }
     
        [When(@"I Input a new wrong password")]
        public void WhenIInputANewWrongPassword(Table table)
        {
            driver.FindElement(By.Id("Answer")).SendKeys("123456789");
            driver.FindElement(By.Id("submit")).Click();
            driver.Navigate().GoToUrl("http://localhost:53887/User/Security");
            driver.FindElement(By.Id("password")).SendKeys("123456");
            driver.FindElement(By.Id("newPassword")).SendKeys("ad");
            driver.FindElement(By.Id("rePassword")).SendKeys("ad");
        }

        [When(@"Click Set new Password button")]
        public void WhenClickSetNewPasswordButton()
        {
            driver.FindElement(By.Id("qa_submit")).Click();
        }

        [Then(@"There will show a message ""(.*)""")]
        public void ThenThereWillShowAMessage(string p0)
        {
            driver.FindElement(By.XPath("//*[@id='changePassword']/p[2]/label/div/ul/li")).Text.CompareTo("New Password must be at least 6 characters");
        }

        //input wrong cofirm password

        [Given(@"I login to my account")]
        public void GivenILoginToMyAccount(Table table)
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:53887/");
            driver.Navigate().GoToUrl("http://localhost:53887/User/Login");
            driver.FindElement(By.Id("user_login")).SendKeys("md5");
            driver.FindElement(By.Id("user_pass")).SendKeys("123456");
            driver.FindElement(By.Id("wp-submit")).Click();
        }

        [Given(@"I navigate to page Change Password")]
        public void GivenINavigateToPageChangePassword()
        {
            driver.Navigate().GoToUrl("http://localhost:53887/User/VerifyUser");
        }

        [When(@"I input a wrong cofirm password")]
        public void WhenIInputAWrongCofirmPassword(Table table)
        {
            driver.FindElement(By.Id("Answer")).SendKeys("123456789");
            driver.FindElement(By.Id("submit")).Click();
            driver.Navigate().GoToUrl("http://localhost:53887/User/Security");
            driver.FindElement(By.Id("password")).SendKeys("123456");
            driver.FindElement(By.Id("newPassword")).SendKeys("ppc123");
            driver.FindElement(By.Id("rePassword")).SendKeys("ppp123");
        }

        [When(@"I choose the Set new Password button")]
        public void WhenIChooseTheSetNewPasswordButton()
        {
            driver.FindElement(By.Id("qa_submit")).Click();
        }

        [Then(@"It will show a message ""(.*)""")]
        public void ThenItWillShowAMessage(string p0)
        {
            driver.FindElement(By.XPath("//*[@id='changePassword']/p[3]/label/div/ul/li")).Text.CompareTo("RePassword does not match the new password");
        }

        //Empty current password form

        [Given(@"Login success to my account")]
        public void GivenLoginSuccessToMyAccount(Table table)
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:53887/");
            driver.Navigate().GoToUrl("http://localhost:53887/User/Login");
            driver.FindElement(By.Id("user_login")).SendKeys("md5");
            driver.FindElement(By.Id("user_pass")).SendKeys("123456");
            driver.FindElement(By.Id("wp-submit")).Click();
        }

        [Given(@"Go to page Change Password")]
        public void GivenGoToPageChangePassword()
        {
            driver.Navigate().GoToUrl("http://localhost:53887/User/VerifyUser");
        }

        [When(@"I forgot to input current password form")]
        public void WhenIForgotToInputCurrentPasswordForm(Table table)
        {
            driver.FindElement(By.Id("Answer")).SendKeys("123456789");
            driver.FindElement(By.Id("submit")).Click();
            driver.Navigate().GoToUrl("http://localhost:53887/User/Security");
            driver.FindElement(By.Id("password")).SendKeys("");
            driver.FindElement(By.Id("newPassword")).SendKeys("ppc123");
            driver.FindElement(By.Id("rePassword")).SendKeys("ppp123");
        }

        [When(@"I click the Set new password button")]
        public void WhenIClickTheSetNewPasswordButton()
        {
            driver.FindElement(By.Id("qa_submit")).Click();
        }

        [Then(@"It show message ""(.*)""")]
        public void ThenItShowMessage(string p0)
        {
            driver.FindElement(By.XPath("//*[@id='changePassword']/p[1]/label/div/ul/li")).Text.CompareTo("Password must not be at least empty");
        }



    }
}
