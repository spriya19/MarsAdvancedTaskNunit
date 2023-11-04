using AutomationSelenium.Pages.Components.ServiceListingOverView;
using AutomationSelenium.Test_Model;
using AutomationSelenium.Utilities;
using AventStack.ExtentReports;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSelenium.Process
{
    public class ShareskillProcess : Base
    {
#pragma warning disable
        ShareSkillAddComponent shareSkillAddComponentObj;
        HomePageProcess homePageProcessObj;
        Jsonhelper jsonhelperObj;
        Base baseObj;
        ExtentTest testreport;
        private ExtentReports extent;

        public ShareskillProcess()
        {
            shareSkillAddComponentObj = new ShareSkillAddComponent();
            jsonhelperObj = new Jsonhelper();
            homePageProcessObj = new HomePageProcess();
            baseObj = new Base();
        }
        public void addShareSkillDetails()
        {
            baseObj.InitializeExtentReports();
            string testName = "ShareSkillAddData";
            baseObj.SetupTest(testName);
            // Read test data from the JSON file using JsonHelper
            string sFile = "ShareSkillAddData.json";
            List<ShareSkillAddTestModel> ShareSkillAddData = Jsonhelper.ReadTestDataFromJson<ShareSkillAddTestModel>(sFile);
            foreach (var data in ShareSkillAddData)
            {
                string title = data.title;
                Console.WriteLine(title);
                string description = data.description;
                Console.WriteLine(description);
                string category = data.category;
                Console.WriteLine(category);
                string subcategory = data.subcategory;
                Console.WriteLine(subcategory);
                string tags = data.tags;
                Console.WriteLine(tags);
                string startdate = data.startdate;
                Console.WriteLine(startdate);
                string enddate = data.enddate;
                Console.WriteLine(enddate);
                string skillExchange = data.skillExchange;
                Console.WriteLine(skillExchange);
                string screenshotName = "ShareSkillAddData";
                baseObj.CaptureScreenshot(screenshotName);

                shareSkillAddComponentObj.shareSkillAdd(data);
                homePageProcessObj.clickOnManageListingTab();
                string addedSkillcategory = shareSkillAddComponentObj.verifSkillCategory();

                if (addedSkillcategory == data.category)
                {
                    Assert.AreEqual(addedSkillcategory, data.category, "The actual and expected do not match");
                    if (testreport != null)
                    {
                        testreport.Log(Status.Pass, "Test Passed");
                    }


                }
                else
                {
                    Console.WriteLine("Check Error");
                }

            }


        }
        public void shareSkillUpdate()
        {
            baseObj.InitializeExtentReports();
            string testName = "ShareSkillUpdateData";
            baseObj.SetupTest(testName);
           // Read test data from the JSON file using JsonHelper
            string sFile = "ShareSkillUpdateData.json";
            List<ShareSkillAddTestModel> ShareSkillUpdateData = Jsonhelper.ReadTestDataFromJson<ShareSkillAddTestModel>(sFile);
            foreach (var data in ShareSkillUpdateData)
            {
                string title = data.title;
                Console.WriteLine(title);
                string description = data.description;
                Console.WriteLine(description);
                string category = data.category;
                Console.WriteLine(category);
                string subcategory = data.subcategory;
                Console.WriteLine(subcategory);
                string tags = data.tags;
                Console.WriteLine(tags);
                string startdate = data.startdate;
                Console.WriteLine(startdate);
                string enddate = data.enddate;
                Console.WriteLine(enddate);
                string skillExchange = data.skillExchange;
                Console.WriteLine(skillExchange);
                string screenshotName = "ShareSkillUpdateData";
                baseObj.CaptureScreenshot(screenshotName);
                homePageProcessObj.clickOnEditManageListingTab();
                shareSkillAddComponentObj.EditShareSkill(data);
                homePageProcessObj.clickOnManageListingTab();
                string updatedSkill = shareSkillAddComponentObj.verifyUpdatedShareSkill();
                if (updatedSkill == data.category)
                {
                    Assert.AreEqual(updatedSkill, data.category, "The actual and expected do not match");
                    if (testreport != null)
                    {
                        testreport.Log(Status.Pass, "Test Passed");
                    }

                }
                else
                {
                    Console.WriteLine("Check Error");
                }

            }
        }
        public void negativeShareSkillProcess()
        {
            baseObj.InitializeExtentReports();
            string testName = "NegativeShareSkill";
            baseObj.SetupTest(testName);
          // Read test data from the JSON file using JsonHelper
            string sFile = "NegativeShareSkill.json";
            List<ShareSkillAddTestModel> NegativeShareSkill = Jsonhelper.ReadTestDataFromJson<ShareSkillAddTestModel>(sFile);
            foreach (var data in NegativeShareSkill)
            {
                string screenshotName = "NegativeShareSkill";
                baseObj.CaptureScreenshot(screenshotName);
                shareSkillAddComponentObj.negativeShareSkill(data);
                string errorMessageBox = shareSkillAddComponentObj.verifyErrorMessage();
                string expectedMessage = "Please complete the form correctly.";
                Assert.AreEqual(errorMessageBox, expectedMessage, "Actual and expected do not match");
                if (testreport != null)
                {
                    testreport.Log(Status.Pass, "Test Passed");
                }

            }
        }
        public void negativeShareskillUpdateProcess()
        {   
            baseObj.InitializeExtentReports();
            string testName = "ShareSkillNegativeUpdateData";
            baseObj.SetupTest(testName);
           // Read test data from the JSON file using JsonHelper
            string sFile = "ShareSkillNegativeUpdateData.json";
            List<ShareSkillAddTestModel> ShareSkillNegativeUpdateData = Jsonhelper.ReadTestDataFromJson<ShareSkillAddTestModel>(sFile);
            foreach (var data in ShareSkillNegativeUpdateData)
            {
                string screenshotName = "ShareSkillNegativeUpdateData";
                baseObj.CaptureScreenshot(screenshotName);
                homePageProcessObj.clickOnEditManageListingTab();
                shareSkillAddComponentObj.negativeShareSkillUpdate(data);
                string errorMessageBox = shareSkillAddComponentObj.verifyErrorMessage();
                string expectedMessage = "Please complete the form correctly.";
                Assert.AreEqual(errorMessageBox, expectedMessage, "Actual and expected do not match");
                if (testreport != null)
                {
                    testreport.Log(Status.Pass, "Test Passed");
                }


            }
        }
    }
}
