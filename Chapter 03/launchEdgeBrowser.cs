using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;

namespace BPBSeleniumCSharp.Chapter_3
{
    class launchEdgeBrowser
    {
        static void Main(string[] args)
        {
            //create object of EdgeDriver
            IWebDriver driver = new EdgeDriver();
            //Launch Edge browser with the given url
            driver.Url = "http://practice.bpbonline.com/";
            //Close browser instance
            driver.Close();

        }
    }
}
