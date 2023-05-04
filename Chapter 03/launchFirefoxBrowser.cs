using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;

namespace BPBSeleniumCSharp.Chapter_3
{
    class launchFirefoxBrowser
    {
        static void Main(string[] args)
        {
            //create object of FirefoxDriver
            IWebDriver driver = new FirefoxDriver();
            //Launch Firefox with the given url
            driver.Url = "http://practice.bpbonline.com/";
            //Close browser instance
            driver.Close();

        }
    }
}
