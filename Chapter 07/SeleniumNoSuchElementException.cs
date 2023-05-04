using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BPBSeleniumCSharp.Chapter_7
{
    class SeleniumNoSuchElementException
    {
        static void Main(string[] args)
        {
            //create object of ChromeDriver
            IWebDriver driver = new ChromeDriver();

            //adding implicit wait
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Launch Chrome browser with the given url
            driver.Url = "http://practice.bpbonline.com/";

            //adding the try catch and finally code to handle NoSuchElementException

            try
            {
                //Click on My Accounts link with wrong information, the link name is My Account
                //exception will be generated on this line
                driver.FindElement(By.LinkText("My Accounts")).Click();
            }
            catch (NoSuchElementException ex)
            {
                string text = ex.ToString();
                string path = System.IO.Directory.GetCurrentDirectory() + "/nosuchelement.txt";
                File.WriteAllText(path, text);

            }
            catch (Exception ex)
            {
                string text = ex.ToString();
                string path = System.IO.Directory.GetCurrentDirectory() + "/genericexception.txt";
                File.WriteAllText(path, text);

            }
            finally
            {
                driver.Quit();
            }

        }
    }
}
