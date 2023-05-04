using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace BPBSeleniumCSharp.Chapter_6
{
    class localWaitSearchProduct
    {
        static void Main(string[] args)
        {
            //create object of ChromeDriver
            IWebDriver driver = new ChromeDriver();

            //adding implicit wait
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Launch Chrome browser with the given url
            driver.Url = "http://practice.bpbonline.com/";

            //Fill in the search field textbox
            driver.FindElement(By.Name("keywords")).SendKeys("junk");

            //Click on the search icon
            driver.FindElement(By.XPath("//input[@title=' Quick Find ']")).Click();

            //set the implicit wait to 0
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            //adding the block in try catch
            try
            {
                //create WebDriverWait Object, with timeout set to 10 seconds.
                WebDriverWait waitObj = new WebDriverWait(driver,TimeSpan.FromSeconds(10));
                //wait to identify the buy now link using the LinkText property. If the element is not found in 10 seconds, it will generate timeout exception
                //caused internally by Element not found exception. else it will execute further. 
                 
                IWebElement buyNow_lnk = waitObj.Until(e => e.FindElement((By.LinkText("Buy Now"))));
                //set the implicit wait to 0
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                buyNow_lnk.Click();
               
                //verify text
                if (driver.PageSource.Contains("junk"))
                {
                    Console.WriteLine("Scenario completed");
                }

            }
            catch (Exception ex)
            {
                //print inner exception and displayed
                Console.WriteLine("Inner Exception- " + ex.InnerException + "Exception Displayed- "+ex.Message);
            }
            finally
            {
                
                driver.Close();
            }
        }
    }
}
