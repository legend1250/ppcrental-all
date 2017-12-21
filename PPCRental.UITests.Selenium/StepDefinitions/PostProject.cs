using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace PPCRental.UITests.Selenium.StepDefinitions
{
    [Binding]
    public class PostProject
    {
        public IWebDriver driver;
        [Given(@"Login successful")]
        public void GivenLoginSuccessful()
        {
            //Homepage
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:53887/");
            //Navigate to Login page 
            driver.Navigate().GoToUrl("http://localhost:53887/User/Login");
            //input username & password
            driver.FindElement(By.Id("user_login")).SendKeys("annguyen");
            driver.FindElement(By.Id("user_pass")).SendKeys("123456");
            //Click Login button
            driver.FindElement(By.Id("wp-submit")).Click();
        }

        [Given(@"Navigate to Add Project page")]
        public void GivenNavigateToAddProjectPage()
        {
            //Navigate to Post project page
            driver.Navigate().GoToUrl("http://localhost:53887/Project/addProject");
        }

        [When(@"I input information for a new project")]
        public void WhenIInputInformationForANewProject()
        {
            //set name for project
            driver.FindElement(By.Id("name")).SendKeys("KantoPlaza");
            //add district
            IWebElement district = driver.FindElement(By.Id("district"));
            district.Click();
            SelectElement district_select = new SelectElement(district);
            district_select.SelectByIndex(2);

            //add street
            IWebElement street = driver.FindElement(By.Id("street"));
            district.Click();
            SelectElement street_select = new SelectElement(street);
            district_select.SelectByIndex(2);

            //add ward
            IWebElement ward = driver.FindElement(By.Id("ward"));
            district.Click();
            SelectElement ward_select = new SelectElement(ward);
            district_select.SelectByIndex(2);

            //add price
            driver.FindElement(By.Id("price")).SendKeys("53000");
            //add area
            driver.FindElement(By.Id("area")).SendKeys("140");

            //Project type
            IWebElement type = driver.FindElement(By.Id("ptype"));
            district.Click();
            SelectElement type_select = new SelectElement(type);
            district_select.SelectByIndex(2);

            //add number of bedroom
            driver.FindElement(By.Id("bed")).SendKeys("2");
            //add number of bathroom
            driver.FindElement(By.Id("bath")).SendKeys("2");
            //add number of parkinglot
            driver.FindElement(By.Id("packing")).SendKeys("1");
            // add content
            driver.FindElement(By.Id("content")).SendKeys("We have a fully furnished master room attached toilet with air con, fan, queen sized bed, 4 door wardrobe and dressing table and TV. All newly purchased items.");

            //driver.FindElement(By.Id("submit")).Click();
        }

        [Then(@"Show message ""(.*)""")]
        public void ThenShowMessage(string p0)
        {
            driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div[1]")).Text.CompareTo("Success! Add Success,wait for appover.");
        }

    }
}
