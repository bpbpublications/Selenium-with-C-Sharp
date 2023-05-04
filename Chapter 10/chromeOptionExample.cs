using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BPBSeleniumCSharp.Chapter_10
{
    class chromeOptionExample
    {
        static void Main(string[] args)
        {
            //create Chrome option class
            ChromeOptions options = new ChromeOptions();
            //add start maximized argument
            options.AddArgument("start-maximized");
            //add incognito argument
            options.AddArgument("incognito");
            //create object of ChromeDriver
            IWebDriver driver = new ChromeDriver(options);
            //adding implicit wait
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //Launch Chrome browser with the given url
            driver.Url = "https://the-internet.herokuapp.com";
        }
    }
}
