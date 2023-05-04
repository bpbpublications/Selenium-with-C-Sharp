using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.ObjectModel;


namespace BPBSeleniumCSharp.Chapter_5
{
    class FindElementsUsingTagName
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
                Console.WriteLine(eleLink.Text);
            }
            driver.Close();

        }
    }
}
