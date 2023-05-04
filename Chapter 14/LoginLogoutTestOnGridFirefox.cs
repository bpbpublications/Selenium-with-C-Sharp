using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Firefox;

namespace TestProjectSelenium.Chapter_14
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    class LoginLogoutTestOnGrid
    {
        RemoteWebDriver driver;
        FirefoxOptions options = new FirefoxOptions();
        [SetUp]
        public void setUpMethod()
        {
            //set firefox options.
            FirefoxProfile profile = new FirefoxProfile("C:\\Users\\write\\AppData\\Roaming\\Mozilla\\Firefox\\Profiles\\teyclyzb.SeleniumTest");
            FirefoxOptions options = new FirefoxOptions();
            options.Profile = profile;
            //set the driver to remote webdriver
            driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), options);

        }
        [Test]
        
        [Category("grid")]
        
        public void loginTestonGridFirefox()
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
