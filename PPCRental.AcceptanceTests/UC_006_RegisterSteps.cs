﻿using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace PPCRental.AcceptanceTests
{
    [Binding]
    public class UC_006_RegisterSteps
    {
        public IWebDriver driver;
        [Given(@"I'm in HomePage")]
        public void GivenIMInHomePage()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://ppcrental.tk/Home/Index");
        }

        [Given(@"I choose Register button")]
        public void GivenIChooseRegisterButton()
        {
            driver.FindElement(By.Id("register")).Click();
            ScenarioContext.Current.Pending();
        }

        [When(@"I input my information and click Submit")]
        public void WhenIInputMyInformationAndClickSubmit()
        {
            driver.FindElement(By.Id("UserName")).SendKeys("pThang");
            driver.FindElement(By.Id("Email")).SendKeys("Thang@gmail.com");
            driver.FindElement(By.Id("Password")).SendKeys("123456");
            driver.FindElement(By.Id("ConfirmPassword")).SendKeys("123456");
            driver.FindElement(By.Id("Address")).SendKeys("20 Nguyen Khac Nhu");
            driver.FindElement(By.Id("Phone")).SendKeys("0982817691");

        }
    }
}
//namespace PPCRental.AcceptanceTests
//    {
//        [Binding]
//        public class UC_006_RegisterSteps
//        {
//            public IWebDriver driver;
//            [Given(@"I'm in HomePage")]
//            public void GivenIMInHomePage()
//            {
//                driver = new ChromeDriver();
//                driver.Navigate().GoToUrl("https://ppcrental.tk/Home/Index");
//            }

//            [Given(@"I choose Register button")]
//            public void GivenIChooseRegisterButton()
//            {

//                driver.FindElement(By.Id("register")).Click();
//            }

//            [When(@"I input my information and click Submit")]
//            public void WhenIInputMyInformationAndClickSubmit()
//            {
//                driver.FindElement(By.Id("Username")).SendKeys("pThang");
//                driver.FindElement(By.Id("Email")).SendKeys("Thang@gmail.com");
//                driver.FindElement(By.Id("password")).SendKeys("123456");
//                driver.FindElement(By.Id("confirm")).SendKeys("123456");
//                driver.FindElement(By.Id("address")).SendKeys("20 Nguyen Khach Nhu");
//                driver.FindElement(By.Id("phone:")).SendKeys("0908000000");
//                driver.FindElement(By.Id("submit")).Click();
//                ScenarioContext.Current.Pending();
//            }

//            [Then(@"the result is successfull and send you back to HomePage")]
//            public void ThenTheResultIsAndSendYouBackToHomePage(string p0)
//            {
//                ScenarioContext.Current.Pending();
//            }
//        }
//    }

//}


