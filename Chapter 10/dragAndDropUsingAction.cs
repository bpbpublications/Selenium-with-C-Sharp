using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace BPBSeleniumCSharp.Chapter_10
{
    class dragAndDropUsingAction
    {
        static void Main(string[] args)
        {
            //create object of ChromeDriver
            IWebDriver driver = new ChromeDriver();
            //adding implicit wait
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //Launch Chrome browser with the given url
            driver.Url = "https://jqueryui.com/droppable/";
            //switch to iframe
            driver.SwitchTo().Frame(driver.FindElement(By.ClassName("demo-frame")));
            //create action class object
            Actions act = new Actions(driver);
            //create drag element
            IWebElement dragEle = driver.FindElement(By.Id("draggable"));
            //create drop element
            IWebElement dropEle = driver.FindElement(By.Id("droppable"));
            //call the drag drop method, build and perform
            act.DragAndDrop(dragEle, dropEle).Perform();
            //switch back to default content
            driver.SwitchTo().DefaultContent();
            //close the page
            driver.Close();
        }
    }
}
