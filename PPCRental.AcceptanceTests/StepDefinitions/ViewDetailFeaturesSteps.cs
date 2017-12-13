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
    public class UC003_ViewDetailFeatures
    {
        // private readonly ViewDetailDriver _detailDriver;
        IWebDriver driver;
        [Given(@"the following appartment")]
        public void GivenTheFollowingAppartment()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:53887/Home/Index");

        }

        [When(@"I open the details of CITY Gate")]
        public void WhenIOpenTheDetailsOfCITYGate()
        {
            driver.FindElement(By.CssSelector("#home-property-listing > div > div > div:nth-child(5) > article > div > header > div > h6 > a")).Click();

        }

        [Then(@"the appartment details should show detail")]
        public void ThenTheAppartmentDetailsShouldShowDetail()
        {  
            //driver.Navigate().GoToUrl("http://localhost:53887/Project/projectDetail/16");
            string element = driver.FindElement(By.CssSelector("#property-single > div.container > div > div.col-lg-8.col-md-7 > section.property-meta-wrapper.common > h3")).Text;
            Assert.AreEqual("CITY Gate", element);

        }

    }
}

