using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace PPCRental.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class UC003_ViewDetailProjectSteps
    {
        IWebDriver driver;
        [Given(@"I am in home page")]
        public void GivenIAmInHomePage()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:53887/Home/Index");
        }
        
        [When(@"I press name of project")]
        public void WhenIPressNameOfProject()
        {
            driver.FindElement(By.XPath("//*[@id='qa - top - menu']/section/div/div[2]/div/ul/li[7]/a"));

        }

        [Then(@"Navigate detail project page and success")]
        public void ThenNavigateDetailProjectPageAndSuccess()
        {
            driver.Navigate().GoToUrl("http://localhost:53887/Project/projectDetail/1");

        }
    }
}
