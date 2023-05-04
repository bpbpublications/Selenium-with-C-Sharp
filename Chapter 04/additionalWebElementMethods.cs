using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BPBSeleniumCSharp.Chapter_4
{
    class additionalWebElementMethods
    {
        static void Main(string[] args)
        {
            //create object of ChromeDriver
            IWebDriver driver = new ChromeDriver();

            //Launch Chrome browser with the given url
            driver.Url = "http://practice.bpbonline.com/";
            //Fetch all the links on the home page
            ReadOnlyCollection<IWebElement> allLinks = driver.FindElements(By.TagName("a"));
            foreach (IWebElement eleLink in allLinks)
            {
                Console.WriteLine(eleLink.GetAttribute("href"));
                Console.WriteLine(eleLink.GetCssValue("color"));
            }
            driver.Close();

        } 
    }
}
