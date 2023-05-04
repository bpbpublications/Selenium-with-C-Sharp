using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace BPBSeleniumCSharp.Chapter_7
{
    class myAccountCreationScenario
    {
        static void Main(string[] args)
        {
            //create object of ChromeDriver
            IWebDriver driver = new ChromeDriver();

            //adding implicit wait
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //Launch Chrome browser with the given url
            driver.Url = "http://practice.bpbonline.com/";

            //Click on My Account link
            driver.FindElement(By.LinkText("My Account")).Click();

            //Click on Continue to go to account creation page
            driver.FindElement(By.LinkText("Continue")).Click();

            //select gender - using xpath. here female radio button is getting selected
            //html is - <input type="radio" name="gender" value="f">
            driver.FindElement(By.XPath("//input[@value='f']")).Click();

            //fill in firstname, lastname, dob, and email address. email address has to be unique to every user
            //as these are all textboxes we will use the SendKeys action

            driver.FindElement(By.Name("firstname")).SendKeys("Fiona");
            driver.FindElement(By.Name("lastname")).SendKeys("Golmes");
            driver.FindElement(By.Name("dob")).SendKeys("07/05/2000");
            //generate a random number for unique emaill address, and concatenate 
            Random rnd = new Random();
            int num = rnd.Next();
            String email = "fiona.golmes" + num.ToString() + "@bpb.com";
            driver.FindElement(By.Name("email_address")).SendKeys(email);

            //the next section is to fill in all address fields, which are again text boxes and mandatory
            driver.FindElement(By.Name("street_address")).SendKeys("London");
            driver.FindElement(By.Name("suburb")).SendKeys("London");
            driver.FindElement(By.Name("postcode")).SendKeys("223242");
            driver.FindElement(By.Name("city")).SendKeys("London");
            driver.FindElement(By.Name("state")).SendKeys("London");

            //The next element is a drop down, which we will cover in the next chapter. but here please refer to the statement
            //the command to select a value from the dropdown -
            //we will need to inherit  OpenQA.Selenium.Support.UI class.
            //we create a new select element, by identifying it using the name property and then selecting the country by passing value
            new SelectElement(driver.FindElement(By.Name("country"))).SelectByText("United Kingdom");

            //next we provide telephone number which is again textbox
            driver.FindElement(By.Name("telephone")).SendKeys("2432424112");

            //although news letter is not mandatory but since it is a checkbox we select it
            driver.FindElement(By.Name("newsletter")).Click();

            //The next are password and confirm password text boxes, which will use the send keys command - 

            driver.FindElement(By.Name("password")).SendKeys("fionabpb");
            driver.FindElement(By.Name("confirmation")).SendKeys("fionabpb");

            //the next is performing submit action on button
            driver.FindElement(By.Id("tdb4")).Submit();

            //We should not verify if we are on Account creation page, if yes we log off and go back to home page
            //else we generate an error

            if (driver.PageSource.Contains("Your Account Has Been Created!"))
            {
                driver.FindElement(By.LinkText("Log Off")).Click();
                driver.FindElement(By.LinkText("Continue")).Click();
                Console.WriteLine("User Account Created");
            }
            else
            {
                Console.WriteLine("User Account not created");
            }
            driver.Quit();
        }
    }
}
