using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BPBSeleniumCSharp.Chapter_4
{
    class webElementProperties
    {
        static void Main(string[] args)
        {
            //create object of ChromeDriver
            IWebDriver driver = new ChromeDriver();
            //Launch Chrome browser with the given url
            driver.Url = "http://practice.bpbonline.com/";
            //Identify My Account link, and click on it
            driver.FindElement(By.LinkText("My Account")).Click();
            //Click on Continue button to go to register user page
            driver.FindElement(By.LinkText("Continue")).Click();
            //Identify the element Checkbox
            IWebElement newsletter_chkbox = driver.FindElement(By.Name("newsletter"));
            //Property- displayed
            bool displayed = newsletter_chkbox.Displayed;
            Console.WriteLine("Displayed: "+ displayed);
            //Property - enabled
            bool enabled = newsletter_chkbox.Enabled;
            Console.WriteLine("Enabled: "+enabled);
            //Property - selected
            bool selected = newsletter_chkbox.Selected;
            Console.WriteLine("Selected default: "+selected);
            //Selected property after clicking checkbox
            newsletter_chkbox.Click();
            selected = newsletter_chkbox.Selected;
            Console.WriteLine("Selected after click: "+ selected);
            //Property - tagname
            string tagname = newsletter_chkbox.TagName;
            Console.WriteLine(tagname);
            //Property - text, will return empty
            string textofCheckbox = newsletter_chkbox.Text;
            Console.WriteLine("text: "+ textofCheckbox);
            //Property - size -height and width
            int height = newsletter_chkbox.Size.Height;
            int width = newsletter_chkbox.Size.Width;
            Console.WriteLine("height: " + height + ", " + "width: " + width);
            //Property -location - x and y coordinates
            System.Drawing.Point location = newsletter_chkbox.Location;
            int x = location.X;
            int y = location.Y;
            Console.WriteLine("X Coordinates:" + x + ", " + "Y Coordinates: " + y);
        }
    }
}
