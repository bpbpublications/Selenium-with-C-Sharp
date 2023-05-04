using System;
using OpenQA.Selenium;

namespace TestProjectSelenium.Chapter_12.PageObjects
{
    class HomePage
    {
        IWebDriver driver;
        
        public HomePage(IWebDriver browser)
        {
            this.driver = browser;
        }

        //my account link object creation with locator information
        private IWebElement myAccountLink => driver.FindElement(By.LinkText("My Account"));
        
        //Click method for My Account link

        public void clickMyAccount()
        {
            myAccountLink.Click();
        }
    }
}
