using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace BPBSeleniumCSharp.Chapter_3
{
    class launchChromeBrowser
    {
        static void Main(string[] args)
        {
            //create object of ChromeDriver
            IWebDriver driver = new ChromeDriver();
            //Launch Chrome with the given url
            driver.Url = "http://practice.bpbonline.com/";
            //Close browser instance
            driver.Close();

        }
    }
}
