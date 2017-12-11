using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;
using System.Threading;
namespace PPCRental.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class UC004_PostProjectSteps
    {
        IWebDriver driver;
        [Given(@"I login role Agency")]
        public void GivenILoginRoleAgency()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:53887/User/Login");
            driver.FindElement(By.Id("user_login")).SendKeys("agency");
            driver.FindElement(By.Id("user_pass")).SendKeys("123456");
            driver.FindElement(By.Id("wp-submit")).Click();
            Assert.AreEqual(true, driver.FindElement(By.Id("logout")).Displayed);


        }

        [When(@"Navigate to add project page")]
        public void WhenNavigateToAddProjectPage()
        {
            driver.Navigate().GoToUrl("http://localhost:53887/Project/addProject");

        }
        
        [When(@"I fill in all the fields")]
        public void WhenIFillInAllTheFields()
        {
            driver.FindElement(By.Id("name")).SendKeys("3 con soc");
            IWebElement district = driver.FindElement(By.Id("district"));
            district.Click();
            SelectElement district_select = new SelectElement(district);
            district_select.SelectByIndex(1);
            //Thread.Sleep(2000);
            //String abc = district_select.ToString();
            //se.selectByIndex(0);
         
        }
         
        [When(@"I press submit button")]
        public void WhenIPressSubmitButton()
        {
            driver.FindElement(By.Id("submit")).Click();
        }
        
        [Then(@"I could see message add success")]
        public void ThenICouldSeeMessageAddSuccess()
        {
            
        }
    }
}
