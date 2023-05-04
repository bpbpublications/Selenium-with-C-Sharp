using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;

namespace TestProjectSelenium.Chapter_13
{
    [TestFixture]
    class LoginLogoutWithExcel
    {
        IWebDriver driver;

        //excel file path
        private static string excelFile = "C:\\Users\\write\\source\\repos\\BPBSeleniumCSharp\\TestProjectSelenium\\TestData\\testData.xlsx";
        //excel sheet name
        private static string sheetInfo = "TestData";
        
        //method calling the exceldatareader, readExcel method which creates LoginDataExcel
        public static IEnumerable<TestCaseData> LoginDataExcel()
        {
            return DataReaders.ExcelDataReader.readExcel(excelFile,sheetInfo);
        }

        [Category("excel")]
        [Test, TestCaseSource("LoginDataExcel")]
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
