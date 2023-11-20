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
                addEditLanguageComponentObj.addNewLanguage(data);
            }

        }
        public void UpdatedLanguageDetails()
        {
           
            // Read test data from the JSON file using JsonHelper
            string sFile = "LanguageUpdateData.json";
            List<LanguageTestModel> LanguageUpdateData = Jsonhelper.ReadTestDataFromJson<LanguageTestModel>(sFile);
            foreach (var data in LanguageUpdateData)
            {
                LogScreenshot("UpdateLanguage");
                addEditLanguageComponentObj.editLanguage(data);
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
            }
        }
        public void NegativeUpdatedLanguage()
        {
            string sFile = "NegativeLanguageUpdateData.json";
            List<LanguageTestModel> NegativeLanguageUpdateData = Jsonhelper.ReadTestDataFromJson<LanguageTestModel>(sFile);
            foreach (var data in NegativeLanguageUpdateData)
            {
                LogScreenshot("NegativeUpdateLanguage");
                addEditLanguageComponentObj.negtiveEditLanguage(data);
            }
        }
    }
}
