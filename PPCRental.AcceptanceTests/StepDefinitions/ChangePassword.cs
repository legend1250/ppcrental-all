using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace PPCRental.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class ChangePassword
    {
        public IWebDriver driver;
        
        [Given(@"I login success with the given username and password")]
        public void GivenILoginSuccessWithTheGivenUsernameAndPassword(string login)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I go to Change Password page")]
        public void GivenIGoToChangePasswordPage(string changePage)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I input all the following fields")]
        public void WhenIInputAllTheFollowingFields(string inputInfor )
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I click Set new Password button")]
        public void WhenIClickSetNewPasswordButton(string click)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I see a message ""(.*)""")]
        public void ThenISeeAMessage(string p0)
        {
            ScenarioContext.Current.Pending();
        }

    }
}
