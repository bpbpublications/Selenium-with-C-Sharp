using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BPBSeleniumCSharp.Chapter_7
{
    class SeleniumElementNotInteractbleException
    {
        static void Main(string[] args)
        {
            //create object of ChromeDriver
            IWebDriver driver = new ChromeDriver();

            //adding implicit wait
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Launch Chrome browser with the given url
            driver.Url = "https://login.yahoo.com/";

            //adding the try catch and finally code to handle ElementNotInteractbleException

            try
            {
                //identify element- Stay Signed In
                IWebElement staySignedIn_chkbox = driver.FindElement(By.XPath("//input[@id='persistent']"));
                //Click on checkbox Stay Signed in
                //exception will be generated on this line
                staySignedIn_chkbox.Click();
            }
            catch (ElementNotInteractableException ex)
            {
                string text = ex.ToString();
                string path = System.IO.Directory.GetCurrentDirectory() + "/elementnotinteractble.txt";
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
