using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace BPBSeleniumCSharp.Chapter_7
{
    class SeleniumStaleElementException
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
                //select element
                SelectElement manuf_select = new SelectElement(driver.FindElement(By.XPath("//select[@name='manufacturers_id']")));
                manuf_select.SelectByText("Fox");
                //exception will be generated on this line
                manuf_select.SelectByText("Canon");
            }
            catch (StaleElementReferenceException ex)
            {
                string text = ex.ToString();
                string path = System.IO.Directory.GetCurrentDirectory() + "/staleelementexception.txt";
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
