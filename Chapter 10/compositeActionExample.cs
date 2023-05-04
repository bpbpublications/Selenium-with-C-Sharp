using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace BPBSeleniumCSharp.Chapter_10
{
    class compositeActionExample
    {
        static void Main(string[] args)
        {
            //create object of ChromeDriver
            IWebDriver driver = new ChromeDriver();
            //adding implicit wait
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //Launch Chrome browser with the given url
            driver.Url = "https://the-internet.herokuapp.com/horizontal_slider";
            //create object of action class
            Actions act = new Actions(driver);
            //create web element object of slider
            IWebElement slider = driver.FindElement(By.XPath("//input[@type='range']"));
            //first perform click operation, and then drag and drop by offset.
            //build into a composite action and then perform
            act.Click(slider).DragAndDropToOffset(slider, 10,0).Build().Perform();
            //quit the driver to close the browser. 
            driver.Quit();
        }

    }
}
