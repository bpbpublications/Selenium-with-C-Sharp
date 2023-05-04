using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BPBSeleniumCSharp.Chapter_3
{
    class LoginLogout
    {
        static void Main(string[] args)
        {
            //create object of ChromeDriver
            IWebDriver driver = new ChromeDriver();
            //Launch Chrome browser with the given url
            driver.Url = "http://practice.bpbonline.com/";
            //Identify My Account link, and click on it
            driver.FindElement(By.LinkText("My Account")).Click();
            //Identify the emaill address element, and type on it
            driver.FindElement(By.Name("email_address")).SendKeys("bpb@bpb.com");
            //Identify the password element and type on it
            driver.FindElement(By.Name("password")).SendKeys("bpb@123");
            //Click on the submit button, using the ID property to find it
            driver.FindElement(By.Id("tdb1")).Click();
            //Click on the Log Off link
            driver.FindElement(By.LinkText("Log Off")).Click();
            //Click on the Continue link
            driver.FindElement(By.LinkText("Continue")).Click();
            //Close browser instance
            driver.Close();

        }
    }
}
