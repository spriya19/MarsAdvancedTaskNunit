using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V117.Page;
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
        private static ExtentTest testreport;
        private static ExtentSparkReporter htmlReporter;


        [SetUp]
        public void SetupAuction()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5000/");
            driver.Manage().Window.Maximize();
            testreport = extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }
        [OneTimeSetUp]
        public void SetupReport()
        {
            if (extent == null)
            {
                extent = new ExtentReports();
                htmlReporter = new ExtentSparkReporter("C:\\ICProject\\AdvancedNunit\\MarsAdvancedTaskNunit\\AutomationSelenium\\Utilities\\Report.html"); // Path to the report file
                extent.AttachReporter(htmlReporter);
            }
        }
        public void LogScreenshot(string ScreenshotName)
        {
            string screenshotPath = CaptureScreenshot(ScreenshotName);
            if (testreport != null)
            {
                testreport.Log(Status.Info, "Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
            }
        }
        public static string CaptureScreenshot(string screenshotName)
        {
                ITakesScreenshot screenshotDriver = (ITakesScreenshot)driver;
                Screenshot screenshot = screenshotDriver.GetScreenshot();
                string screenshotPath = Path.Combine("ScreenshotReport", $"{screenshotName}_{DateTime.Now:yyyyMMddHHmmss}.png");
                string fullPath = Path.Combine("C:\\ICProject\\AdvancedNunit\\MarsAdvancedTaskNunit\\AutomationSelenium", screenshotPath);
#pragma warning disable
                screenshot.SaveAsFile(fullPath, ScreenshotImageFormat.Png);
            
               return fullPath;
        }
        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
        [OneTimeTearDown]
        public void TeardownReport()
        {
            extent.Flush();
        }



    }
}
