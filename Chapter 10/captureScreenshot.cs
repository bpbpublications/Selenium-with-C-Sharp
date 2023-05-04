using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BPBSeleniumCSharp.Chapter_10
{
    class captureScreenshot
    {
        static void Main(string[] args)
        {
            //create object of ChromeDriver
            IWebDriver driver = new ChromeDriver();
            //adding implicit wait
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //Launch Chrome browser with the given url
            driver.Url = "http://practice.bpbonline.com/";
            string path = System.IO.Directory.GetCurrentDirectory() + "/baduser.jpg";
            //Launch Chrome browser with the given url
            driver.Url = "http://practice.bpbonline.com/";
            //Identify My Account link, and click on it
            driver.FindElement(By.LinkText("My Account")).Click();
            //Identify the emaill address element, and type on it
            driver.FindElement(By.Name("email_address")).SendKeys("bpb@bpb.com");
            //Identify the password element and type on it
            driver.FindElement(By.Name("password")).SendKeys("junkpassord");
            //Click on the submit button, using the ID property to find it
            driver.FindElement(By.Id("tdb1")).Click();
            //Capture the screenshot
            Screenshot screenshot = (driver as ITakesScreenshot).GetScreenshot();
            screenshot.SaveAsFile(path, ScreenshotImageFormat.Jpeg); // Format values are Bmp, Gif, Jpeg, Png, Tiff
            driver.Quit();
        }
    }
}

