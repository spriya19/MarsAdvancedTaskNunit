using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSelenium.Utilities
{
    public class Base
    {
#pragma warning disable CS8618
        public static IWebDriver driver;
        private static ExtentReports extent;
        private static ExtentTest test;
        private static ExtentSparkReporter htmlReporter;

        [SetUp]
        public void SetupAuction()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5000/");
            driver.Manage().Window.Maximize();

        }
        public void InitializeExtentReports()
        {

            if (extent == null)
            {
                extent = new ExtentReports();
                htmlReporter = new ExtentSparkReporter("C:\\ICProject\\AdvancedNunit\\MarsAdvancedTaskNunit\\AutomationSelenium\\Utilities\\Report.html"); // Path to the report file
                extent.AttachReporter(htmlReporter);
            }

        }
        public void SetupTest(string testName)
        {
            test = extent.CreateTest(testName);
            test.Log(Status.Pass, "Test Passed");

        }

        public void CaptureScreenshot(string screenshotName)
        {
            try
            {
                ITakesScreenshot screenshotDriver = (ITakesScreenshot)driver;
                Screenshot screenshot = screenshotDriver.GetScreenshot();
                string screenshotPath = Path.Combine("ScreenshotReport", $"{screenshotName}_{DateTime.Now:yyyyMMddHHmmss}.png");
                string fullPath = Path.Combine("C:\\ICProject\\AdvancedNunit\\MarsAdvancedTaskNunit\\AutomationSelenium", screenshotPath);
#pragma warning disable
                screenshot.SaveAsFile(fullPath, ScreenshotImageFormat.Png);
                //return fullPath;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error capturing screenshot: " + ex.Message);
            }

        }
        [TearDown]
        public void TearDownAction()
        {
            driver.Quit();
            extent.Flush();
        }




    }
}
