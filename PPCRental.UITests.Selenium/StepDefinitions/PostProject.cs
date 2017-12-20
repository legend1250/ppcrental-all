using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PPCRental.UITests.Selenium.StepDefinitions
{
    [Binding]
    public class PostProject
    {
        public IWebDriver driver;
        [Given(@"Login successful")]
        public void GivenLoginSuccessful()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:53887/");
            driver.Navigate().GoToUrl("http://localhost:53887/User/Login");
            driver.FindElement(By.Id("user_login")).SendKeys("annguyen");
            driver.FindElement(By.Id("user_pass")).SendKeys("123456");
            driver.FindElement(By.Id("wp-submit")).Click();
        }

        [Given(@"Navigate to Add Project page")]
        public void GivenNavigateToAddProjectPage()
        {
            driver.Navigate().GoToUrl("http://localhost:53887/Project/addProject");
        }

        [When(@"I input information for a new project")]
        public void WhenIInputInformationForANewProject()
        {
            driver.FindElement(By.Id("name")).SendKeys("KantoPlaza");
            //driver.FindElement(By.Id("district")).SendKeys("");
            //driver.FindElement(By.Id("street")).SendKeys("");
            //driver.FindElement(By.Id("ward")).SendKeys("");

            driver.FindElement(By.Id("price")).SendKeys("53000");
            driver.FindElement(By.Id("area")).SendKeys("140");
            //driver.FindElement(By.Id("ptype")).SendKeys("");
            driver.FindElement(By.Id("name")).SendKeys("KantoPlaza");
        }

        [Then(@"Show message ""(.*)""")]
        public void ThenShowMessage(string p0)
        {
            ScenarioContext.Current.Pending();
        }

    }
}
