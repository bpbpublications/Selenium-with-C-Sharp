using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace BPBSeleniumCSharp.Chapter_8
{
    class workingWithDropDown
    {
        static void Main(string[] args)
        {
            //create object of ChromeDriver
            IWebDriver driver = new ChromeDriver();
            //adding implicit wait
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //Launch Chrome browser with the given url
            driver.Url = "http://practice.bpbonline.com/";
            //identify the drop down element using name property
            string path = System.IO.Directory.GetCurrentDirectory() + "/dropdowninfo.txt";
            //if the file exists in the location, delete it. 
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            SelectElement manuf_dropdown = new SelectElement(driver.FindElement(By.XPath("//select[@name='manufacturers_id']")));
            //select by text
            manuf_dropdown.SelectByText("Logitech");
            //reassociate select element, due to stale element exception
            manuf_dropdown = new SelectElement(driver.FindElement(By.Name("manufacturers_id")));
            if (driver.FindElement(By.XPath("//div[@id='bodyContent']/h1")).Text == manuf_dropdown.SelectedOption.Text)
            {
                File.AppendAllText(path, "Select by Text works\n");
            }
            else
            {
                File.AppendAllText(path, "Select by Text has error");
            }
            //select by value
            manuf_dropdown.SelectByValue("7");
            //reassociate select element, due to stale element exception
            manuf_dropdown = new SelectElement(driver.FindElement(By.XPath("//select[@name='manufacturers_id']")));
            if (driver.FindElement(By.XPath("//div[@id='bodyContent']/h1")).Text == manuf_dropdown.SelectedOption.Text)
            {
                File.AppendAllText(path, "Select by Value works\n");
            }
            else
            {
                File.AppendAllText(path, "Select by Value has error");
            }
            //select by index
            manuf_dropdown.SelectByIndex(3);
            //reassociate select element, due to stale element exception
            manuf_dropdown = new SelectElement(driver.FindElement(By.XPath("//select[@name='manufacturers_id']")));
            if (driver.FindElement(By.XPath("//div[@id='bodyContent']/h1")).Text == manuf_dropdown.SelectedOption.Text)
            {
                File.AppendAllText(path, "Select by Index works");
            }
            else
            {
                File.AppendAllText(path, "Select by Index has error");
            }
            driver.Quit();
        }
    }
}
