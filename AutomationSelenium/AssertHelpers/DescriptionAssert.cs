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

namespace AutomationSelenium.AssertHelpers
{
    public class DescriptionAssert : Base
    {
        DescriptionComponent descriptionComponentObj;
        ExtentTest testreport;
#pragma warning disable
        public DescriptionAssert()
        {
            descriptionComponentObj = new DescriptionComponent();

        }

        public void updatedDescriptionAssert()
        {
            // Read test data from the JSON file using JsonHelper
            string sFile = "DescriptionData.json";
            List<DescriptionTestModel> DescriptionData = Jsonhelper.ReadTestDataFromJson<DescriptionTestModel>(sFile);
            foreach (var data in DescriptionData)
            {
                string textarea = data.textarea;
                string addedDescription = descriptionComponentObj.getVerifyAddedDescription();
                Assert.AreEqual(addedDescription, textarea, "Actual text and expected text do not match");
                if (testreport != null)
                {
                    testreport.Log(Status.Pass, "Test Passed");
                }
            }


        }
        public void NegativeDescriAssert()
        {
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
        public void deleteDescriptionAssert()
        {
                string deletePopupMessage = descriptionComponentObj.verifyPopupMessage();
                var popupMessageText = deletePopupMessage;
                string expectedMessage1 = "Please, a description is required";

                if (popupMessageText == expectedMessage1)
                {
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
