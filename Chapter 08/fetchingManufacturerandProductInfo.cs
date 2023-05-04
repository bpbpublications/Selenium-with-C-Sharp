using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace BPBSeleniumCSharp.Chapter_8
{
    class fetchingManufacturerandProductInfo
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
            string path = System.IO.Directory.GetCurrentDirectory() + "/manufacturer.txt";
            //if the file exists in the location, delete it. 
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            //find the drop down element using xpath
            SelectElement manuf_dropdown = new SelectElement(driver.FindElement(By.XPath("//select[@name='manufacturers_id']")));
            //fetch all the options from drop down
            IList<IWebElement> allManufacturers = manuf_dropdown.Options;
            //create a string array to fill in all manufacturers names
            List<string> manufNames = new List<string>();
            //fetch all manufacturer names in a list
            foreach (IWebElement manufName in allManufacturers)
            {
                manufNames.Add(manufName.Text);
            }
            manufNames.RemoveAt(0); //removing Please Select from the list.
            //iterate through the manufacturers to fetch the product information related to it
            foreach (String mname in manufNames)
            {
                manuf_dropdown.SelectByText(mname);
                manuf_dropdown = new SelectElement(driver.FindElement(By.XPath("//select[@name='manufacturers_id']")));
                if (driver.PageSource.Contains("There are no products available in this category."))
                {
                    File.AppendAllText(path, "The manufacturer " + mname + " has no products\n");
                }
                else
                {
                    //create the table element
                    IWebElement productTable = driver.FindElement(By.ClassName("productListingData"));
                    //Fetch all table rows
                    File.AppendAllText(path, "\n\nThe manufacturer - " + mname + " products are listed--\n");
                    ReadOnlyCollection<IWebElement> rows = productTable.FindElements(By.XPath("//tbody/tr"));
                    foreach (WebElement row in rows)
                    {
                        //print the product information in file as fetched
                        File.AppendAllText(path, row.Text);
                        File.AppendAllText(path, "\n");                    
                    }

                }
            }
            driver.Quit();
        }
    }
}


