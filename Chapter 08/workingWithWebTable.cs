using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
namespace BPBSeleniumCSharp.Chapter_8
{
    class workingWithWebTable
    {
        static void Main(string[] args)
        {
            //create object of ChromeDriver
            IWebDriver driver = new ChromeDriver();

            //adding implicit wait
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Launch Chrome browser with the given url
            driver.Url = "http://practice.bpbonline.com/";

            //identify the web table
            IWebElement productTable = driver.FindElement(By.XPath("//*[@id='bodyContent']/div/div[2]/table"));
            //find the number of rows 
            ReadOnlyCollection<IWebElement> tableRows = productTable.FindElements(By.XPath("//tbody/tr"));
            string path = System.IO.Directory.GetCurrentDirectory() + "/productInformation.csv";
            //if the file exists in the location, delete it. 
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            //traverse through table rows to find the table columns -
            foreach (IWebElement trow in tableRows)
            {
                ReadOnlyCollection<IWebElement> tableCols = trow.FindElements(By.XPath("td"));
                foreach (IWebElement tcol in tableCols)
                {
                    //write product information extracted in file- name and cost
                    String data = tcol.Text;
                    String[] productInfo = data.Split('\n');
                    String printProductInfo = productInfo[0].Trim() + "," + productInfo[1].Trim() +"\n";
                    File.AppendAllText(path, printProductInfo);
                }
            }

            driver.Quit();
        }
    }
}
