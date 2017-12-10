using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;

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
        
        [When(@"I press add project button")]
        public void WhenIPressAddProjectButton()
        {
            driver.FindElement(By.XPath("//*[@id='qa - top - menu']/section/div/div[2]/div/ul")).Click();
            driver.FindElement(By.XPath("//*[@id='qa - top - menu']/section/div/div[2]/div/ul/li[7]/a")).Click();
        }
        
        [When(@"Navigate to add project page")]
        public void WhenNavigateToAddProjectPage()
        {
            driver.Navigate().GoToUrl("http://localhost:53887/Project/addProject");
        }
        
        [When(@"I fill in all the fields")]
        public void WhenIFillInAllTheFields()
        {
            driver.FindElement(By.Id("name")).SendKeys("home stay ba con soc");
            string ava = driver.FindElement(By.Id("ava")).Text;
            string ima = driver.FindElement(By.Id("ima")).Text;
            //GetAttribute(attributeName: "");
           string price= driver.FindElement(By.Id("price")).Text;
           string area= driver.FindElement(By.Id("area")).Text;
            string bed= driver.FindElement(By.Id("bed")).Text;
            string bath = driver.FindElement(By.Id("bath")).Text;
            //driver.FindElement(By.Id("superior")).FindElements(By.XPath("./option[@selected]"))[0].Text;
            IWebElement comboBox = driver.FindElement(By.Id("packing"));
            SelectElement selectedValue = new SelectElement(comboBox);
            string wantedText = selectedValue.SelectedOption.GetAttribute("2");

            driver.FindElement(By.Id("content")).SendKeys("Thoai mai, tien loi, gan cong vien, benh vien ");

        }
        
        [When(@"I press submit button")]
        public void WhenIPressSubmitButton()
        {
            driver.FindElement(By.Id("submit")).Click();
        }
        
        [Then(@"I could see message add success")]
        public void ThenICouldSeeMessageAddSuccess()
        {
            driver.FindElement(By.XPath(""));
            ScenarioContext.Current.Pending();
        }
    }
}
