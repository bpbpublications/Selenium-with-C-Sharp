using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace BPBSeleniumCSharp.Chapter_10
{
    class chromeAddExtensionExample
    {
        static void Main(string[] args)
        {
            //create Chrome option class
            ChromeOptions options = new ChromeOptions();
            //add start maximized argument
            options.AddArgument("start-maximized");
            //add the AdBlocker extension
            options.AddExtension("D:\\WORK\\BPB PUBLICATIONS\\THIRD BOOK\\crxfile\\extension_5_3_0_0.crx");
            //create object of ChromeDriver
            IWebDriver driver = new ChromeDriver(options);
            //adding implicit wait
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //Launch Chrome browser with the given url
            driver.Url = "https://usa.tommy.com/en";
        }
    }

}
