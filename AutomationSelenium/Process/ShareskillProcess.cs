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
        ExtentTest testreport;
        private ExtentReports extent;

        public ShareskillProcess()
        {
            shareSkillAddComponentObj = new ShareSkillAddComponent();
            homePageProcessObj = new HomePageProcess();
        }
        public void addShareSkillDetails()
        {
            // Read test data from the JSON file using JsonHelper
            string sFile = "ShareSkillAddData.json";
            List<ShareSkillAddTestModel> ShareSkillAddData = Jsonhelper.ReadTestDataFromJson<ShareSkillAddTestModel>(sFile);
            foreach (var data in ShareSkillAddData)
            {
                string title = data.title;
                string description = data.description;
                string category = data.category;
                string subcategory = data.subcategory;
                string tags = data.tags;
                string startdate = data.startdate;
                string enddate = data.enddate;
                string skillExchange = data.skillExchange;
                LogScreenshot("AddShareSkill");
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
           // Read test data from the JSON file using JsonHelper
            string sFile = "ShareSkillUpdateData.json";
            List<ShareSkillAddTestModel> ShareSkillUpdateData = Jsonhelper.ReadTestDataFromJson<ShareSkillAddTestModel>(sFile);
            foreach (var data in ShareSkillUpdateData)
            {
                string title = data.title;
                string description = data.description;
                string category = data.category;
                string subcategory = data.subcategory;
                string tags = data.tags;
                string startdate = data.startdate;
                string enddate = data.enddate;
                string skillExchange = data.skillExchange;
                LogScreenshot("shareSkillUpdate");
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
           // Read test data from the JSON file using JsonHelper
            string sFile = "NegativeShareSkill.json";
            List<ShareSkillAddTestModel> NegativeShareSkill = Jsonhelper.ReadTestDataFromJson<ShareSkillAddTestModel>(sFile);
            foreach (var data in NegativeShareSkill)
            {
                LogScreenshot("shareSkilladdNegative");
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
            // Read test data from the JSON file using JsonHelper
            string sFile = "ShareSkillNegativeUpdateData.json";
            List<ShareSkillAddTestModel> ShareSkillNegativeUpdateData = Jsonhelper.ReadTestDataFromJson<ShareSkillAddTestModel>(sFile);
            foreach (var data in ShareSkillNegativeUpdateData)
            {
                LogScreenshot("shareSkillUpdateNegative");
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
