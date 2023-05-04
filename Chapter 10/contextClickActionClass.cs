using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace BPBSeleniumCSharp.Chapter_10
{
    class contextClickActionClass
    {
        static void Main(string[] args)
        {
            //create object of ChromeDriver
            IWebDriver driver = new ChromeDriver();
            //adding implicit wait
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //Launch Chrome browser with the given url
            driver.Url= "https://the-internet.herokuapp.com/context_menu";
            //identify the web element for context click
            IWebElement theInternetbox = driver.FindElement(By.Id("hot-spot"));
            //create action class object
            Actions act = new Actions(driver);
            //perform context click on web element
            act.ContextClick(theInternetbox).Perform();
            //switch to the alert which pops up
            IAlert alert = driver.SwitchTo().Alert();
            //accept the alert
            alert.Accept();
            //quit application
            driver.Quit();
          }
    }
}