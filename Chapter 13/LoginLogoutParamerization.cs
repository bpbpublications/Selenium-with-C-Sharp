using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestProjectSelenium.Chapter_13
{
    [TestFixture]
    class LoginLogoutParamerization
    {
        IWebDriver driver;

        //Test data method
        private static System.Collections.Generic.IEnumerable<object[]> LoginData()
        {
            yield return new object[] { "bpb@bpb.com", "bpb@123"};
            yield return new object[] { "junk@bpb.com", "junk" };
        }

        //passing the data method name in TestCaseSource to parameterize the test method
        [Category("hardcodedata")]
        [Test, TestCaseSource("LoginData")]
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