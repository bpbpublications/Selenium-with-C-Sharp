using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;

namespace TestProjectSelenium.Chapter_13
{
    [TestFixture]
    class LoginLogoutWithCSV
    {
        IWebDriver driver;
        
        //csv file path
        private static string csvfile = "C:\\Users\\write\\source\\repos\\BPBSeleniumCSharp\\TestProjectSelenium\\TestData\\datatest.csv";
       
        //method to call the readCSV method from the CSVDataReader file
        public static IEnumerable<TestCaseData> LoginDataCSV()
        {
            return DataReaders.CSVDataReader.readCSV(csvfile);
        }
        
        [Category("csv")]
        [Test, TestCaseSource("LoginDataCSV")]
        public void loginTestParam(String username, String passwd)
        {
            driver = new ChromeDriver();
            //open the application
            driver.Url = "http://practice.bpbonline.com/index.php";
            //click my account link
            driver.FindElement(By.LinkText("My Account")).Click();
            //perform login
            driver.FindElement(By.Name("email_address")).SendKeys(username);
            driver.FindElement(By.Name("password")).SendKeys(passwd);
            driver.FindElement(By.Id("tdb1")).Click();
            //Add login Assertion
            Assert.IsTrue(driver.PageSource.Contains("My Account Information"), "Test pass if My Account Information present, else fails");
            //perform logout
            driver.FindElement(By.LinkText("Log Off")).Click();
            driver.FindElement(By.LinkText("Continue")).Click();
        }
        [TearDown]
        public void tearDown()
        {
            //close the browser
            driver.Quit();
        }
    }
}
