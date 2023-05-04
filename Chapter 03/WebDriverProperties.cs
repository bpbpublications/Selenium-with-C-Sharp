using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace BPBSeleniumCSharp.Chapter_3
{
    class WebDriverProperties
    {
        static void Main(string[] args)
        {
            //create object of ChromeDriver
            IWebDriver driver = new ChromeDriver();
            //Launch Chrome with the given url
            driver.Url = "http://practice.bpbonline.com/";
            if (driver.Title.Contains("BPB"))
            {
                //if title contains BPB mention page is launched
                Console.WriteLine("Web page launched");
            }
            if (driver.WindowHandles.Count == 1)
            {
                Console.WriteLine("Only main window is launched with window handle: " + driver.CurrentWindowHandle);
            }
            if (driver.PageSource.Contains("Guest"))
            {
                //if page contains guest mention user is not logged in
                Console.WriteLine(" user not logged in, click on my account to login ");
            }
            
            //Close browser instance
            driver.Close();
        }
    }
}
