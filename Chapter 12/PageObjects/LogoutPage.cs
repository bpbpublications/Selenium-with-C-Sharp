using System;
using OpenQA.Selenium;


namespace TestProjectSelenium.Chapter_12.PageObjects
{
    class LogoutPage
    {
        IWebDriver driver;
        public LogoutPage(IWebDriver browser)
        {
            this.driver = browser;
        }

        //Web Elements creation by providing locator information
        private IWebElement logoffLink => driver.FindElement(By.LinkText("Log Off"));
        private IWebElement continueLink => driver.FindElement(By.LinkText("Continue"));

        //Methods of the web elements

        public void clickLogOffLink()
        {
            logoffLink.Click();
        }
        public void clickContinue()
        {
            continueLink.Click();
        }
    }
}
