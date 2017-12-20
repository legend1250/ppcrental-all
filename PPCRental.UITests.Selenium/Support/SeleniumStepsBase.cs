using OpenQA.Selenium;

namespace PPCRental.UITests.Selenium.Support
{
    public abstract class SeleniumStepsBase
    {
        protected IWebDriver Browser
        {
            get { return SeleniumController.Instance.Browser; }
        }
    }
}
