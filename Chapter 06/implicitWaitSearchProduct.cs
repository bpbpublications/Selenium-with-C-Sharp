using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;



namespace BPBSeleniumCSharp.Chapter_6
{
    class implicitWaitSearchProduct
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

            //adding the block in try catch
            try
            {
                //Click on Buy Now link
                driver.FindElement(By.LinkText("Buy Now")).Click();

                //verify text
                if (driver.PageSource.Contains("junk"))
                {
                    Console.WriteLine("Scenario completed");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Timeout- " + ex.Message);

            }
            finally
            {
                driver.Close();
            }
        }
        

    }
}
