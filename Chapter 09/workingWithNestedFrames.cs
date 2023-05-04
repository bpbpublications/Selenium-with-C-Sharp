using System;
using System.Collections.ObjectModel;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace BPBSeleniumCSharp.Chapter_9
{
    class workingWithNestedFrames
    {
        static void Main(string[] args)
        {
            //create object of ChromeDriver
            IWebDriver driver = new ChromeDriver();
            //adding implicit wait
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //Launch Chrome browser with the given url
            driver.Url = "https://the-internet.herokuapp.com/nested_frames";
            string path = System.IO.Directory.GetCurrentDirectory() + "/nestedframes.txt";
            //if the file exists in the location, delete it. 
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            try
            {
                //fetch count of all parent frames
                int frameCount = driver.FindElements(By.TagName("frame")).Count;
                File.AppendAllText(path, "Number of parent frames in the web application is: "+ frameCount.ToString()+"\n\n");
                //fetch count of child frames in the top frame
                driver.SwitchTo().Frame(0);
                int childFrameCount= driver.FindElements(By.TagName("frame")).Count;
                File.AppendAllText(path, "Number of child frames in the first frame are: " + childFrameCount.ToString()+"\n\n");
                //fetch the content of the middle frame
                //switch to middle frame
                driver.SwitchTo().Frame(1);
                String htmlContent = driver.PageSource;
                File.AppendAllText(path, "Content of the page in middle frame: "+ htmlContent+ "\n\n");
                //switch back to main html document
                driver.SwitchTo().DefaultContent();
                //switch to the bottom frame
                driver.SwitchTo().Frame(1);
                String bottomFrameContent = driver.PageSource;
                File.AppendAllText(path, "Content of the page in bottom frame: " + bottomFrameContent + "\n\n");
                //switch to main html page
                driver.SwitchTo().ParentFrame();
                //raise nosuchframeexception
                //switching to frame number 3, passing index value 2
                try
                {
                    driver.SwitchTo().Frame(2); //doesn't exists
                }catch(Exception e)
                {
                    File.AppendAllText(path, "frame not found\n\n");
                    File.AppendAllText(path, e.Message);
                }
            }
            catch (Exception e)
            {
                File.AppendAllText(path, "unable to access the element\n\n");
                File.AppendAllText(path, e.Message);
            }
            driver.Quit();
        }
    }
}
