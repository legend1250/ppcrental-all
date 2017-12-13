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
    public class Register
    {
        public IWebDriver driver;
        [Given(@"In HomePage")]
        public void GivenInHomePage()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:53887/");   
        }

        [Given(@"Navigate to Register Page")]
        public void GivenNavigateToRegisterPage()
        {
            driver.Navigate().GoToUrl("http://localhost:53887/User/Register");
        }

        [When(@"Input my information")]
        public void WhenInputMyInformation(Table table)
        {
            foreach (var item in table.Rows)
            {
                driver.FindElement(By.Id(item["Name"])).SendKeys(item["Input"]);
            }
            
        }

        [When(@"Click Submit button")]
        public void WhenClickSubmitButton()
        {
            driver.FindElement(By.Id("submit")).Click();
        }

        [Then(@"Show successful message")]
        public void ThenShowSuccessfulMessage()
        {
            driver.FindElement(By.XPath("/html/body/div/div/div/div/div[1]")).Text.CompareTo("Success! you have signed up successfully.Your account will be actived after 24 hour if all information is valid");
            
        }

    }
}
