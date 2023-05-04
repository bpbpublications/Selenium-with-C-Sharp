using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BPBSeleniumCSharp.Chapter_9
{
    class workWithJSConfirmAlert
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
                //Click on the JSConfirm button
                driver.FindElement(By.XPath("//button[contains(text(), 'Click for JS Confirm')]")).Click();
                //switch to the alert window as it appears
                IAlert jsAlert = driver.SwitchTo().Alert();
                //introducing forceful wait to observe the alert
                System.Threading.Thread.Sleep(2000);
                jsAlert.Accept(); //press on ok button
                //fetch the text on result element
                IWebElement resultEle = driver.FindElement(By.Id("result"));
                String message = resultEle.Text;
                File.AppendAllText(path, message + "\n\n");
                //switching back to main page
                driver.SwitchTo().DefaultContent();
                //Click on the JSAlert button to get the popup again for cancel button
                driver.FindElement(By.XPath("//button[contains(text(), 'Click for JS Confirm')]")).Click();
                //switch to the alert window as it appears
                jsAlert = driver.SwitchTo().Alert();
                //introducing forceful wait to observe the alert
                System.Threading.Thread.Sleep(2000);
                jsAlert.Dismiss(); //press on cancel button
                //fetch the text on result element
                resultEle = driver.FindElement(By.Id("result"));
                message = resultEle.Text;
                File.AppendAllText(path, message);
                //switching back to main page
                driver.SwitchTo().DefaultContent();

            }
            catch (Exception e)
            {
                File.AppendAllText(path, "Error: \n\n");
                File.AppendAllText(path, e.Message);
            }
            driver.Quit();
        }
    }
}
