using System;
using System.Collections.ObjectModel;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace BPBSeleniumCSharp.Chapter_9
{
    class workWithWindows
    {
        static void Main(string[] args)
        {
            //create object of ChromeDriver
            IWebDriver driver = new ChromeDriver();
            //adding implicit wait
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //Launch Chrome browser with the given url
            driver.Url = "https://the-internet.herokuapp.com/windows";
            string path = System.IO.Directory.GetCurrentDirectory() + "/windows.txt";
            //if the file exists in the location, delete it. 
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            try
            {
                //click on the Click Here link in the main page
                driver.FindElement(By.LinkText("Click Here")).Click();
                ReadOnlyCollection<string> windowHandles = driver.WindowHandles;
                //Switch to child window, get information and close it.
                driver.SwitchTo().Window(windowHandles[1]);
                File.AppendAllText(path, "Window handle for child window: " + driver.CurrentWindowHandle.ToString() + "\n\n");
                File.AppendAllText(path, "The page content: " + driver.PageSource + "\n\n");
                driver.Close();
                //switch to the main window
                driver.SwitchTo().Window(windowHandles[0]);
                //as the child window closes, our focus goes backs to the main window.
                File.AppendAllText(path, "Window handle for child window: " + driver.CurrentWindowHandle.ToString() + "\n\n");
                File.AppendAllText(path, "The page content: " + driver.PageSource + "\n\n");


            }
            catch (Exception e)
            {
                File.AppendAllText(path, "Error message: \n\n");
                File.AppendAllText(path, e.Message);
            }
            driver.Quit();
        }
    }
}
