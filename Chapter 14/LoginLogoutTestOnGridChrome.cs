using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;

namespace TestProjectSelenium.Chapter_14
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    class LoginLogoutTestOnGridChrome
    {
        RemoteWebDriver driver;
        ChromeOptions options = new ChromeOptions();
        [SetUp]
        public void setUpMethod()
        {
            //set chrome options.
            options.AddArgument("start-maximized");
            //set the driver to remote webdriver
            driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), options);

        }
        [Test]
        
        [Category("grid")]
        
        public void loginTestonGridChrome()
        {
            //open the application
            driver.Url = "http://practice.bpbonline.com/index.php";
            //click my account link
            driver.FindElement(By.LinkText("My Account")).Click();
            //perform login
            driver.FindElement(By.Name("email_address")).SendKeys("bpb@bpb.com");
            driver.FindElement(By.Name("password")).SendKeys("bpb@123");
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
