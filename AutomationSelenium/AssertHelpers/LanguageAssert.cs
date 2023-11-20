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

namespace AutomationSelenium.AssertHelpers
{
    public class LanguageAssert : Base
    {
        AddEditLanguageComponent addEditLanguageComponentObj;
        ExtentTest testreport;
#pragma warning disable

        public LanguageAssert() 
        {
            addEditLanguageComponentObj = new AddEditLanguageComponent();
        }
        public void addedLanguageAssert()
        {

            // Read test data from the JSON file using JsonHelper
            string sFile = "LanguageAddData.json";
            List<LanguageTestModel> LanguageAddData = Jsonhelper.ReadTestDataFromJson<LanguageTestModel>(sFile);
            foreach (var data in LanguageAddData)
            {
                string language = data.language;
                string addedNewLanguage = addEditLanguageComponentObj.verifyAddedLanguage();
                Assert.AreEqual(language,addedNewLanguage, "Actual language and expected language do not match");
                if (testreport != null)
                {
                    testreport.Log(Status.Pass, "Test Passed");
                }
            }

        }
        public void UpdatedLanguageAssert()
        {
           // Read test data from the JSON file using JsonHelper
            string sFile = "LanguageUpdateData.json";
            List<LanguageTestModel> LanguageUpdateData = Jsonhelper.ReadTestDataFromJson<LanguageTestModel>(sFile);
            foreach (var data in LanguageUpdateData)
            {
                string language = data.language;
                string updatedLanguage = addEditLanguageComponentObj.verifyUpdatedLanguage();
                Assert.AreEqual(updatedLanguage, language, "Actual language and expected language do not match ");
                if (testreport != null)
                {
                    testreport.Log(Status.Pass, "Test Passed");
                }
            }
        }
        public void deletedLanguageAssert()
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
        public void negativeAddLanguageAssert()
        {
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
        public void NegativeUpdatedLanguageAssert()
        {
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
