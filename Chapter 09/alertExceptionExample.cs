using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BPBSeleniumCSharp.Chapter_9
{
    class alertExceptionExample
    {
        static void Main(string[] args)
        {
            //create object of ChromeDriver
            IWebDriver driver = new ChromeDriver();
            //adding implicit wait
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //Launch Chrome browser with the given url
            driver.Url = "https://the-internet.herokuapp.com/javascript_alerts";
            string path = System.IO.Directory.GetCurrentDirectory() + "/javascriptalerts.txt";
            //if the file exists in the location, delete it. 
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            try
            {
                //switch to the alert window as it appears, no window will appear as no action is done on any button
                IAlert jsAlert = driver.SwitchTo().Alert();
                //introducing forceful wait to observe the alert
                System.Threading.Thread.Sleep(2000);
                jsAlert.Accept(); //press on ok button
                //switching back to main page
                driver.SwitchTo().DefaultContent();
            }
            catch (Exception e)
            {
                File.AppendAllText(path, "Error: \n\n");
                File.AppendAllText(path, e.ToString());
            }
            driver.Quit();
        }
    }
}
