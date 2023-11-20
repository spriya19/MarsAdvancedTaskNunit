using AutomationSelenium.AssertHelpers;
using AutomationSelenium.Pages.Components.ServiceListingOverView;
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
    [TestFixture]
    public class ShareSkillTest :Base
    {
        LoginProcess loginProcessObj;
        HomePageProcess homePageProcessObj;
        ShareSkillAddComponent ShareSkillAddComponentObj;
        ShareskillProcess shareskillProcessObj;
        ShareSkillAssert shareSkillAssertObj;
        public ShareSkillTest() 
        {
            loginProcessObj = new LoginProcess();
            homePageProcessObj = new HomePageProcess();
            ShareSkillAddComponentObj = new ShareSkillAddComponent();
            shareskillProcessObj = new ShareskillProcess();
            shareSkillAssertObj = new ShareSkillAssert();
        }
        [Test,Order(1)]
        public void AddShareSkill_Test()
        {
            loginProcessObj.doLogin();
            homePageProcessObj.clickOnProfileManageListing();
            ShareSkillAddComponentObj.clearExistingdata();
            homePageProcessObj.clickonManageShareSkillTab();
            shareskillProcessObj.addShareSkillDetails();
            shareSkillAssertObj.addShareSkillAssert();
        }
        [Test,Order(2)]
        public void UpdateShareSkill_Test()
        {
            loginProcessObj.doLogin();
            homePageProcessObj.clickOnProfileManageListing();
            shareskillProcessObj.shareSkillUpdate();
            shareSkillAssertObj.shareSkillUpdateAssert();

        }
        
        [Test,Order(3)]
        public void NegativeShareSkill_Test()
        {
            loginProcessObj.doLogin();
            homePageProcessObj.clickShareskill();
            shareskillProcessObj.negativeShareSkillProcess();
            shareSkillAssertObj.negativeShareSkillAssert();

        }
        [Test,Order(4)]
        public void NegativeShareSkillUpdate_Test()
        {
            loginProcessObj.doLogin();
            homePageProcessObj.clickOnProfileManageListing();
            shareskillProcessObj.negativeShareskillUpdateProcess();
            shareSkillAssertObj.negativeShareskillUpdateAssert();

        }

    }
}
