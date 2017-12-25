using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace PPCRental.UITests.Selenium
{
    [Binding]
    public sealed class ForgotPassword
    {
        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef
        public IWebDriver driver;
        [Given(@"I am in Homepage")]
        public void GivenIAmInHomepage()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:53887/");
            //Navigate to Login page
            driver.Navigate().GoToUrl("http://localhost:53887/User/Login");
        }

        [Given(@"I go to Forgot password page")]
        public void GivenIGoToForgotPasswordPage()
        {
            //Click 
            driver.FindElement(By.XPath("//*[@id='nav']/a[2]")).Click();
        }

        [When(@"I input all the fields")]
        public void WhenIInputAllTheFields()
        {
            driver.FindElement(By.Id("Email")).SendKeys("pt@gmail.com");
            //
            IWebElement question = driver.FindElement(By.Id("SecretQuestion_ID"));
            question.Click();
            SelectElement question_select = new SelectElement(question);
            question_select.SelectByIndex(1);
            //
            driver.FindElement(By.Id("Answer")).SendKeys("Ho Chi Minh");
        }

        [When(@"I click Submit button")]
        public void WhenIClickSubmitButton()
        {
            driver.FindElement(By.XPath("/html/body/div[1]/form/div/div/div[4]/div/button")).Click();
        }

        [Then(@"Show message ""(.*)"" and new password")]
        public void ThenShowMessageAndNewPassword(string p0)
        {
            driver.FindElement(By.XPath("/html/body/div[1]/form/div/div/div[5]/div[1]/span")).Text.CompareTo("Successful reset your password. Your new password is ");
        }

    }
}
