using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestProjectSelenium.Chapter_12.PageObjects;

namespace TestProjectSelenium.Chapter_12
{
    [TestFixture]
    class LoginLogoutTestPOM
    {
        IWebDriver driver;
        HomePage homePage;
        LoginPage loginPage;
        LogoutPage logoutPage;

        [SetUp]
        public void setUpMethod()
        {
            //set the driver to chromedriver
            driver = new ChromeDriver();
            homePage = new HomePage(driver);
            loginPage = new LoginPage(driver);
            logoutPage = new LogoutPage(driver);
        }
        [Test]
        [Category("pom")]
        public void loginTest()
        {
            
            //open the application
            driver.Url = "http://practice.bpbonline.com/index.php";
            //calling the page objects methods
            homePage.clickMyAccount();
            //performing the login action
            loginPage.typeEmail("bpb@bpb.com");
            loginPage.typePassword("bpb@123");
            loginPage.clickSignIn();
            //Add login Assertion
            Assert.IsTrue(driver.PageSource.Contains("My Account Information"), "valid user credential");
            //performing the logout action
            logoutPage.clickLogOffLink();
            logoutPage.clickContinue();
        }
        [TearDown]
        public void tearDown()
        {
            //close the browser
            driver.Quit();
        }
    }
}
