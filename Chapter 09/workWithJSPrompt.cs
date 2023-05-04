using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace BPBSeleniumCSharp.Chapter_9
{
    class workWithJSPrompt
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
                //Click on the JSPrompt button
                driver.FindElement(By.XPath("//button[contains(text(), 'Click for JS Prompt')]")).Click();
                //switch to the alert window as it appears
                IAlert jsAlert = driver.SwitchTo().Alert();
                //introducing forceful wait to observe the alert
                System.Threading.Thread.Sleep(1000);
                jsAlert.SendKeys("hello there!");
                jsAlert.Accept(); //press on ok button
                //introducing forceful wait to observe the result message
                System.Threading.Thread.Sleep(2000);
                //fetch the text on result element
                IWebElement resultEle = driver.FindElement(By.Id("result"));
                String message = resultEle.Text;
                File.AppendAllText(path, message);
                //switching back to main page
                driver.SwitchTo().DefaultContent();

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
