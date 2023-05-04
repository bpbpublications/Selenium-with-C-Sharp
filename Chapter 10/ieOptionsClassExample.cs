using System;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;

namespace BPBSeleniumCSharp.Chapter_10
{
    class ieOptionsClassExample
    {
        static void Main(string[] args)
        {
            InternetExplorerOptions options = new InternetExplorerOptions();
            options.IgnoreZoomLevel = true;
            options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            IWebDriver driver = new InternetExplorerDriver(options);
            //adding implicit wait
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //Launch Firefox browser with the given url
            driver.Url = "http://practice.bpbonline.com/";
        }
    }
}
