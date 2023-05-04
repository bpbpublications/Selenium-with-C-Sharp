using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BPBSeleniumCSharp.Chapter_4
{
    class webElementMethods
    {
        static void Main(string[] args)
        {
            //create object of ChromeDriver
            IWebDriver driver = new ChromeDriver();
            
            //Launch Chrome browser with the given url
            driver.Url = "http://practice.bpbonline.com/";
            //Identify My Account link, and click on it
            driver.FindElement(By.LinkText("My Account")).Click();
            //Identify the email address text box
            IWebElement emailaddr_txtbox = driver.FindElement(By.Name("email_address"));
            //clear the text box
            emailaddr_txtbox.Clear();
            //type username 
            emailaddr_txtbox.SendKeys("bpb@bpb.com");
            //Identify the password text box
            IWebElement pwd_txtbox = driver.FindElement(By.Name("password"));
            //clear the text box
            pwd_txtbox.Clear();
            //type username 
            pwd_txtbox.SendKeys("bpb@123");
            //identify the sign in button and click on it, for this we will use the id property
            driver.FindElement(By.Id("tdb1")).Submit();
            //click on the log off link
            driver.FindElement(By.LinkText("Log Off")).Click();
            //click on the continue link
            driver.FindElement(By.LinkText("Continue")).Click();
            //close the browser
            driver.Close();
        }

    }
}
