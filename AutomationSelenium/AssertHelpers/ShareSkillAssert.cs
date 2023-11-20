using AutomationSelenium.Pages.Components.ProfilePageOverview;
using AutomationSelenium.Pages.Components.ServiceListingOverView;
using AutomationSelenium.Process;
using AutomationSelenium.Test_Model;
using AutomationSelenium.Utilities;
using AventStack.ExtentReports;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSelenium.AssertHelpers
{
    public class ShareSkillAssert :Base
    {
        ShareSkillAddComponent shareSkillAddComponentObj;
        ManageListingComponet manageListingComponetObj;
        ExtentTest testreport;
#pragma warning disable

        public ShareSkillAssert()
        {
            shareSkillAddComponentObj = new ShareSkillAddComponent();
            manageListingComponetObj = new ManageListingComponet();
        }
        public void addShareSkillAssert()
        {
            // Read test data from the JSON file using JsonHelper
            string sFile = "ShareSkillAddData.json";
            List<ShareSkillAddTestModel> ShareSkillAddData = Jsonhelper.ReadTestDataFromJson<ShareSkillAddTestModel>(sFile);
            foreach (var data in ShareSkillAddData)
            {
                string category = data.category;
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
        public void shareSkillUpdateAssert()
        {
            // Read test data from the JSON file using JsonHelper
            string sFile = "ShareSkillUpdateData.json";
            List<ShareSkillAddTestModel> ShareSkillUpdateData = Jsonhelper.ReadTestDataFromJson<ShareSkillAddTestModel>(sFile);
            foreach (var data in ShareSkillUpdateData)
            {
                string category = data.category;
                string updatedSkill = shareSkillAddComponentObj.verifyUpdatedShareSkill();
                if  (updatedSkill == data.category)
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
        public void negativeShareSkillAssert()
        {
            string errorMessageBox = shareSkillAddComponentObj.verifyErrorMessage();
            string expectedMessage = "Please complete the form correctly.";
            Assert.AreEqual(errorMessageBox, expectedMessage, "Actual and expected do not match");
            if (testreport != null)
            {
                testreport.Log(Status.Pass, "Test Passed");
            }
        }
        public void DeleteShareSkillAssert()
        {
            string messageBox = manageListingComponetObj.verifyDeletedList();
            var popupMessageText = messageBox;

            string popupMessage = messageBox;
            if (popupMessage.Contains("has been deleted"))
            {
                Console.WriteLine("API Testing has been deleted");
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
        public void negativeShareskillUpdateAssert()
        {
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
