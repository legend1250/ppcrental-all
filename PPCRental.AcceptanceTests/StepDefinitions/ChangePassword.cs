﻿using System;
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
    public class ChangePassword
    {
        public IWebDriver driver;
        [Given(@"I login success with the given username and password")]
        public void GivenILoginSuccessWithTheGivenUsernameAndPassword(Table table)
        {

            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:53887/");
            driver.Navigate().GoToUrl("http://localhost:53887/User/Login");
            driver.FindElement(By.Id("user_login")).SendKeys("sale");
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
            driver.FindElement(By.Id("Answer")).SendKeys("Tran Hung Dao");
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
            IWebElement element = driver.FindElement(By.XPath("//*[@id='login']/p[1]"));
            Assert.AreEqual("Your password has been changed successfully", element.Text);
        }

    }
}
