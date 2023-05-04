using System;
using OpenQA.Selenium;

namespace TestProjectSelenium.Chapter_12.PageObjects
{
    class LoginPage
    {
        IWebDriver driver;

        public LoginPage(IWebDriver browser)
        {
            this.driver = browser;
        }

        //Web Elements creation by providing locator information
        private IWebElement emailTextBox => driver.FindElement(By.Name("email_address"));
        private IWebElement passwordTextBox => driver.FindElement(By.Name("password"));
        private IWebElement signinButton => driver.FindElement(By.Id("tdb1"));

        
        //clearing email address field to perform type action on it

        public void typeEmail(String email)
        {
            emailTextBox.Clear();
            emailTextBox.SendKeys(email);
        }
        //clearing password field to perform type action on it
        public void typePassword(String pwd)
        {
            passwordTextBox.Clear();
            passwordTextBox.SendKeys(pwd);
        }
        //performing click action on sign in button
        public void clickSignIn()
        {
            signinButton.Click();
        }
    }
}
