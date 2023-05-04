using System;
using System.Collections.ObjectModel;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BPBSeleniumCSharp.Chapter_9
{
    class workingWithFramesWithException
    {
        static void Main(string[] args)
        {
            //create object of ChromeDriver
            IWebDriver driver = new ChromeDriver();
            //adding implicit wait
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //Launch Chrome browser with the given url
            driver.Url = "https://the-internet.herokuapp.com/iframe";
            string path = System.IO.Directory.GetCurrentDirectory() + "/iframeexception.txt";
            //if the file exists in the location, delete it. 
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            //identify the <p> element 
            
            try
            {
                //switch to the iframe using the id property
                driver.SwitchTo().Frame("mce_0_ifr");
                //we should now be to access the web element.
                IWebElement paragraphElement = driver.FindElement(By.XPath("//*[@id='tinymce']/p"));
                String contents = paragraphElement.Text;
                File.AppendAllText(path, contents);
            }
            catch (Exception e)
            {
                File.AppendAllText(path, "unable to access the element\n\n");
                File.AppendAllText(path, e.Message);
            }
            driver.Quit();
        }
    }
}
