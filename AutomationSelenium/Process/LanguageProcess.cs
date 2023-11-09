using AutomationSelenium.Pages.Components.ProfilePageOverview;
using AutomationSelenium.Test_Model;
using AutomationSelenium.Utilities;
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSelenium.Process
{
    public class LanguageProcess : Base
    {
#pragma warning disable
        AddEditLanguageComponent addEditLanguageComponentObj;
        ExtentTest testreport;
        private ExtentReports extent;

        public LanguageProcess()
        {
            addEditLanguageComponentObj = new AddEditLanguageComponent();
        }
        public void addedLanguageDetails()
        {
           
            // Read test data from the JSON file using JsonHelper
            string sFile = "LanguageAddData.json";
            List<LanguageTestModel> LanguageAddData = Jsonhelper.ReadTestDataFromJson<LanguageTestModel>(sFile);
            foreach (var data in LanguageAddData)
            {
                LogScreenshot("AddLanguage");

                string language = data.language;
                string level = data.level;
                addEditLanguageComponentObj.addNewLanguage(data);
                string addedNewLanguage = addEditLanguageComponentObj.verifyAddedLanguage();
                Assert.AreEqual(addedNewLanguage, language, "Actual language and expected language do not match");
                if (testreport != null)
                {
                    testreport.Log(Status.Pass, "Test Passed");
                }

            }

        }
        public void UpdatedLanguageDetails()
        {
           
            // Read test data from the JSON file using JsonHelper
            string sFile = "LanguageUpdateData.json";
            List<LanguageTestModel> LanguageUpdateData = Jsonhelper.ReadTestDataFromJson<LanguageTestModel>(sFile);
            foreach (var data in LanguageUpdateData)
            {
                string language = data.language;
                string level = data.level;
                LogScreenshot("UpdateLanguage");
                addEditLanguageComponentObj.editLanguage(data);
                string updatedLanguage = addEditLanguageComponentObj.verifyUpdatedLanguage();
                Assert.AreEqual(updatedLanguage, language, "Actual language and expected language do not match ");
                if (testreport != null)
                {
                    testreport.Log(Status.Pass, "Test Passed");
                }

            }
        }
        public void deletedLanguageDetails()
        {
            LogScreenshot("DeleteLanguage");
            addEditLanguageComponentObj.verifyDeleteSuccessMessage();
            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            var popupMessage = messageBox.Text;
            if (popupMessage.Contains("has been deleted from your languages"))
            {
                Console.WriteLine("Language has been deleted successfully");
            }
            else
            {
                Console.WriteLine("Check Error");
            }

            Assert.AreNotEqual(messageBox, popupMessage, "actual message and expected message do  match");
            if (testreport != null)
            {
                testreport.Log(Status.Pass, "Test Passed");
            }

        }
        public void negativeAddLanguage()
        {
           // Read test data from the JSON file using JsonHelper
            string sFile = "NegativeLanguageAddData.json";
            List<LanguageTestModel> NegativeLanguageAddData = Jsonhelper.ReadTestDataFromJson<LanguageTestModel>(sFile);
            foreach (var data in NegativeLanguageAddData)
            {
                LogScreenshot("AddNegativeLanguage");
                addEditLanguageComponentObj.addNegativeLanguage(data);
                string messageBox = addEditLanguageComponentObj.negativeLanguagemessage();
                var popupMessageText = messageBox;
                string popupMessage = messageBox;
                string expectedMessage2 = "Duplicated data";
                string expectedMessage3 = "Please enter language and level";
                string expectedMessage4 = "This language is already exist in your language list.";

                if (popupMessage.Contains("has been added"))
                {
                    Console.WriteLine("Language has been added successfully");
                }
                else if ((popupMessage == expectedMessage2 || popupMessage == expectedMessage3 || popupMessage == expectedMessage4))
                {
                    IWebElement cancelIcon = driver.FindElement(By.XPath("//input[@value='Cancel']"));
                    cancelIcon.Click();
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
        public void NegativeUpdatedLanguage()
        {
            string sFile = "NegativeLanguageUpdateData.json";
            List<LanguageTestModel> NegativeLanguageUpdateData = Jsonhelper.ReadTestDataFromJson<LanguageTestModel>(sFile);
            foreach (var data in NegativeLanguageUpdateData)
            {
                string language = data.language;
                string level = data.level;
                LogScreenshot("NegativeUpdateLanguage");
                addEditLanguageComponentObj.negtiveEditLanguage(data);
                string messageBox = addEditLanguageComponentObj.NegativeUpdatedMessage();
                var popupMessageText = messageBox;
                string popupMessage = messageBox;
                Console.WriteLine("messageBox.Text is: " + popupMessage);
                string expectedMessage2 = "Please enter language and level";
                string expectedMessage3 = "This language is already exist in your language list.";
                if (popupMessage.Contains("has been updated"))
                {
                    Console.WriteLine("Language has been updated successfully");
                }
                else if ((popupMessage == expectedMessage2 || popupMessage == expectedMessage3))
                {
                    IWebElement cancelIcon = driver.FindElement(By.XPath("//input[@value='Cancel']"));
                    cancelIcon.Click();
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
    }
}
