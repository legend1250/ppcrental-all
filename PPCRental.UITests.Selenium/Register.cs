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
    public sealed class Register
    {
        public IWebDriver driver;
        [Given(@"I am in homepage")]
        public void GivenIAmInHomepage()
        {
            //homepage
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:53887/");
        }

        [Given(@"Navigate to Register page")]
        public void GivenNavigateToRegisterPage()
        {
            driver.Navigate().GoToUrl("http://localhost:53887/User/Register");

        }

        [When(@"I input all fields")]
        public void WhenIInputAllFields()
        {
            //input fields
            driver.FindElement(By.Id("Email")).SendKeys("sasuke@gmail.com");
            driver.FindElement(By.Id("Password")).SendKeys("Ppc123");
            driver.FindElement(By.Id("ConfirmPassword")).SendKeys("Ppc123");
            driver.FindElement(By.Id("FullName")).SendKeys("Sasuke");
            driver.FindElement(By.Id("Phone")).SendKeys("0900313333");
            driver.FindElement(By.Id("Address")).SendKeys("008 Lê Lợi");

            driver.FindElement(By.Id("")).SendKeys("sasuke@gmail.com");
            driver.FindElement(By.Id("Password")).SendKeys("Ppc123");

            //choose security question
            IWebElement question = driver.FindElement(By.Id("SecretQuestion_ID"));
            question.Click();
            SelectElement question_select = new SelectElement(question);
            question_select.SelectByIndex(7);

            //input fields
            driver.FindElement(By.Id("Answer")).SendKeys("Nguyễn");
        }

        [When(@"I click Create button")]
        public void WhenIClickCreateButton()
        {
            driver.FindElement(By.XPath("/html/body/div[1]/form/div/div/div[9]/div/input")).Click();

        }

        [Then(@"Show message Please enter a valid email address\.")]
        public void ThenShowMessagePleaseEnterAValidEmailAddress_()
        {
            driver.FindElement(By.XPath("/html/body/div[1]/form/div/div/div[10]/div/span")).Text.CompareTo("Successful Register");

        }
        //-------------------------------------------------

        [When(@"I input wrong email address")]
        public void WhenIInputWrongEmailAddress()
        {
            //input fields
            driver.FindElement(By.Id("Email")).SendKeys("tamtam");
            driver.FindElement(By.XPath("/html/body/div[1]/form/div/div/div[9]/div/input")).Click();
        }

        [Then(@"Show message ""(.*)""")]
        public void ThenShowMessage(string p0)
        {
            driver.FindElement(By.XPath("/html/body/div[1]/form/div/div/div[10]/div/span")).Text.CompareTo("Please enter a valid email address.");
        }


        //---------------------------------------------------
        [When(@"I input wrong password")]
        public void WhenIInputWrongPassword()
        {
            driver.FindElement(By.Id("Email")).SendKeys("tamtam@gmail.com");
            driver.FindElement(By.Id("Password")).SendKeys("ppctk");
            driver.FindElement(By.XPath("/html/body/div[1]/form/div/div/div[9]/div/input")).Click();
        }

        [Then(@"It show message""(.*)""")]
        public void ThenItShowMessage(string p0)
        {
            driver.FindElement(By.Id("Password-error")).Text.CompareTo("Minimum four characters and maximun twenty characters, at least one uppercase letter, one lowercase letter and one number.");
        }
        //----------------------------------------------------
        [When(@"I  don't input anything to any fields")]
        public void WhenIDonTInputAnythingToAnyFields()
        {
            driver.FindElement(By.Id("Email")).SendKeys("tamtam@gmail.com");
            driver.FindElement(By.Id("Password")).SendKeys("");
            driver.FindElement(By.Id("Password")).SendKeys("123ccp");
            driver.FindElement(By.XPath("/html/body/div[1]/form/div/div/div[9]/div/input")).Click();
        }

        [Then(@"I will see a message""(.*)""")]
        public void ThenIWillSeeAMessage(string p0)
        {
            driver.FindElement(By.Id("Password-error")).Text.CompareTo("Password must not be null");
        }
        //-----------------------------------------------------------
        [When(@"I input wrong current password")]
        public void WhenIInputWrongCurrentPassword()
        {
            driver.FindElement(By.Id("Email")).SendKeys("tamtam@gmail.com");
            driver.FindElement(By.Id("Password")).SendKeys("Ppc123");
            driver.FindElement(By.Id("Password")).SendKeys("123ccp");
            driver.FindElement(By.XPath("/html/body/div[1]/form/div/div/div[9]/div/input")).Click();
        }

        [Then(@"There will massage""(.*)""")]
        public void ThenThereWillMassage(string p0)
        {
            driver.FindElement(By.Id("ConfirmPassword-error")).Text.CompareTo("Password Mismatched. Re-enter your password");
        }





    }
}
