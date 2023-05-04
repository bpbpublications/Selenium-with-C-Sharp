using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace BPBSeleniumCSharp.Chapter_10
{
    class firefoxOptionClassExample
    {
        static void Main(string[] args)
        {
            FirefoxProfile profile = new FirefoxProfile("C:\\Users\\write\\AppData\\Roaming\\Mozilla\\Firefox\\Profiles\\teyclyzb.SeleniumTest");
            FirefoxOptions options = new FirefoxOptions();
            options.Profile = profile;
            IWebDriver driver = new FirefoxDriver(options);
            //adding implicit wait
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //Launch Firefox browser with the given url
            driver.Url = "http://practice.bpbonline.com/";
        }
    }
}
