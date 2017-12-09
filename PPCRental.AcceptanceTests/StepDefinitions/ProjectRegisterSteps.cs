using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PPCRental.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class ProjectRegisterSteps
    {
        public IWebDriver driver;
        [Given(@"I'm in HomePage")]
        public void GivenIMInHomePage()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:53887/");
        }
        
        [Given(@"I click Register button")]
        public void GivenIClickRegisterButton()
        {
            driver.FindElement(By.Id("registerfixed")).Click();
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I input my information")]
        public void WhenIInputMyInformation()
        {
            driver.FindElement(By.Id("UserName")).SendKeys("Thang");
            driver.FindElement(By.Id("Email")).SendKeys("Thang@gmail.com");
            driver.FindElement(By.Id("Password")).SendKeys("123456");
            driver.FindElement(By.Id("ConfirmPassword")).SendKeys("123456");
            driver.FindElement(By.Id("Address")).SendKeys("20 Nguyen Khac Nhu");
            driver.FindElement(By.Id("Phone")).SendKeys("0982817691");
        }
        
        [When(@"I click Submit button")]
        public void WhenIClickSubmitButton()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Show successful message")]
        public void ThenShowSuccessfulMessage()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
