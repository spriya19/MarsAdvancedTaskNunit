using AutomationSelenium.Pages.Components.ProfilePageOverview;
using AutomationSelenium.Process;
using AutomationSelenium.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSelenium.Test
{
    public class LanguageTest : Base
    {
        LoginProcess loginProcessObj;
        HomePageProcess homePageProcessObj;
        LanguageProcess languageProcessObj;
        AddEditLanguageComponent addEditLanguageComponentObj;
        public LanguageTest()
        {
            loginProcessObj = new LoginProcess();
            homePageProcessObj = new HomePageProcess();
            languageProcessObj = new LanguageProcess();
            addEditLanguageComponentObj = new AddEditLanguageComponent();
        }
        [Test,Order(1)]
        public void addedLanguage_Iest()
        {
            loginProcessObj.doLogin();
            homePageProcessObj.clickOnLanguageTab();
            addEditLanguageComponentObj.clearExistingdata();
            languageProcessObj.addedLanguageDetails();
        }
        [Test,Order(2)]
        public void updatedLanguage_Test()
        {
            loginProcessObj.doLogin();
            homePageProcessObj.clickEditLanguage();
            languageProcessObj.UpdatedLanguageDetails();
        }
        [Test,Order(3)]
        public void DeletedLanguage_Test()
        {
            loginProcessObj.doLogin();
            homePageProcessObj.clickDeleteLanguage();
            languageProcessObj.deletedLanguageDetails();
        }
        [Test,Order(4)]
        public void NegativeAddLanguage_Test()
        {
            loginProcessObj.doLogin();
            homePageProcessObj.clickOnLanguageTab();
            addEditLanguageComponentObj.clearExistingdata();
            languageProcessObj.negativeAddLanguage();

        }
        [Test,Order(5)]
        public void NegativeEditedLanguage_Test()
        {
            loginProcessObj.doLogin();
            homePageProcessObj.clickEditLanguage();
            languageProcessObj.NegativeUpdatedLanguage();
        }
    }
}
