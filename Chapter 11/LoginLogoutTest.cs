using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestProjectSelenium.Chapter11
{
    [TestFixture]
    class LoginLogoutTestOnGrid
    {
        IWebDriver driver;

        [SetUp]
        public void setUpMethod()
        {
            //set the driver to chromedriver
            driver = new ChromeDriver();

        }
        [Test]
        
        [Category("regression")]
        public void loginTest()
        {
            //open the application
            driver.Url = "http://practice.bpbonline.com/index.php";
            //click my account link
            driver.FindElement(By.LinkText("My Account")).Click();
            //perform login
            driver.FindElement(By.Name("email_address")).SendKeys("bpb@bpb.com");
            driver.FindElement(By.Name("password")).SendKeys("bpb123");
            driver.FindElement(By.Id("tdb1")).Click();
            //Add login Assertion
            Assert.IsTrue(driver.PageSource.Contains("My Account Information"), "valid user credential");
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
