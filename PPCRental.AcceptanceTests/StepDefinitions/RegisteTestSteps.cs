﻿using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PPCRental.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class RegisterTestSteps
    {
        public IWebDriver driver;
        [Given(@"I'm in HomePage")]
        public void GivenIMInHomePage()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:53887/");
        }


        [Given(@"Navigate to Register Page")]
        public void GivenNavigateToRegisterPage()
        {
            driver.Navigate().GoToUrl("http://localhost:53887/User/Register");
        }

        [When(@"I input my information")]
        public void WhenIInputMyInformation()
        {
            driver.FindElement(By.Id("UserName")).SendKeys("pThang");
            driver.FindElement(By.Id("Email")).SendKeys("Thang@gmail.com");
            driver.FindElement(By.Id("password")).SendKeys("123456");
            driver.FindElement(By.Id("confirm")).SendKeys("123456");
            driver.FindElement(By.Id("address")).SendKeys("20 Nguyen Khac Nhu");
            driver.FindElement(By.Id("phone")).SendKeys("0982817690");
            driver.FindElement(By.Id("answer")).SendKeys("An");
        }

        [When(@"I click Submit button")]
        public void WhenIClickSubmitButton()
        {
            driver.FindElement(By.Id("submit")).Click();
        }

        [Then(@"Show successful message")]
        public void ThenShowSuccessfulMessage()
        {
            ScenarioContext.Current.Pending();
        }
    }
}