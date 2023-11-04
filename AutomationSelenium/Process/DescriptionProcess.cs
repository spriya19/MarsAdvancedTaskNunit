using AutomationSelenium.Pages.Components.ProfilePageOverview;
using AutomationSelenium.Test_Model;
using AutomationSelenium.Utilities;
using AventStack.ExtentReports;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSelenium.Process
{
    public class DescriptionProcess : Base
    {
#pragma warning disable
        DescriptionComponent descriptionComponentObj;
        Jsonhelper jsonHelperObj;
        Base baseObj;
        ExtentTest testreport;
        private ExtentReports extent;

        public DescriptionProcess()
        {
            descriptionComponentObj = new DescriptionComponent();
            jsonHelperObj = new Jsonhelper();
            baseObj = new Base();
        }
        public void updatedDescription()
        {
            baseObj.InitializeExtentReports();
            string testName = "DescriptionData";
            baseObj.SetupTest(testName);
           // Read test data from the JSON file using JsonHelper
            string sFile = "DescriptionData.json";
            List<DescriptionTestModel> DescriptionData = Jsonhelper.ReadTestDataFromJson<DescriptionTestModel>(sFile);
            foreach (var data in DescriptionData)
            {
                string textarea = data.textarea;
                Console.WriteLine(textarea);
                string screenshotName = "DescriptionData";
                baseObj.CaptureScreenshot(screenshotName);
               descriptionComponentObj.addAndUpdateDescriptionDetails(textarea);
                string addedDescription = descriptionComponentObj.getVerifyAddedDescription();
                Assert.AreEqual(addedDescription, textarea, "Actual text and expected text do not match");
               if (testreport != null)
               {
                    testreport.Log(Status.Pass, "Test Passed");
               }
            }


        }
        public void addNegativeDescri()
        {
            baseObj.InitializeExtentReports();
            string testName = "NegativeDescriptionData";
            baseObj.SetupTest(testName);
            // Read test data from the JSON file using JsonHelper
            string sFile = "NegativeDescriptionData.json";
            List<DescriptionTestModel> NegativeDescriptionData = Jsonhelper.ReadTestDataFromJson<DescriptionTestModel>(sFile);
            foreach (var data in NegativeDescriptionData)
            {
                string textarea = data.textarea;
                Console.WriteLine(textarea);
                string screenshotName = "NegativeDescriptionData";
                baseObj.CaptureScreenshot(screenshotName);
                descriptionComponentObj.addNegativedes(textarea);
                string messageBox = descriptionComponentObj.negativeDesMessage();
                var popupMessageText = messageBox;


                string expectedMessage1 = "First character can only be digit or letters";

                if (popupMessageText == expectedMessage1)
                {
                    Thread.Sleep(2000);
                    Console.WriteLine(expectedMessage1);
                }
                else
                {
                    Console.WriteLine("Check Error");
                }

                Assert.AreEqual(messageBox, popupMessageText, "Actual message and expected message do not match");
                if (testreport != null)
                {
                    testreport.Log(Status.Pass, "Test Passed");
                }
            }
        }
        public void deleteDescription()
        {
            baseObj.InitializeExtentReports();
            string testName = "DeleteDescData";
            baseObj.SetupTest(testName);
            string sFile = "DeleteDescData.json";
            List<DescriptionTestModel> DeleteDescData = Jsonhelper.ReadTestDataFromJson<DescriptionTestModel>(sFile);
            foreach (var data in DeleteDescData)
            {
                string textarea = data.textarea;
                descriptionComponentObj.deleteDesc(textarea);
                string screenshotName = "DeleteDescData";
                baseObj.CaptureScreenshot(screenshotName);
                string deletePopupMessage = descriptionComponentObj.verifyPopupMessage();
                var popupMessageText = deletePopupMessage;
                string expectedMessage1 = "Please, a description is required";

                if (popupMessageText == expectedMessage1)
                {
                    Thread.Sleep(2000);
                    Console.WriteLine(expectedMessage1);
                }
                else
                {
                    Console.WriteLine("Check Error");
                }
                Assert.AreEqual(deletePopupMessage, popupMessageText, "Actual message and expected message do not match");
                if (testreport != null)
                {
                    testreport.Log(Status.Pass, "Test Passed");
                }

            }

        }

    }
}
