using AutomationSelenium.AssertHelpers;
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
    public class ManageListingTest : Base
    {
        LoginProcess loginProcessObj;
        HomePageProcess homePageProcessObj;
        ManageListingProcess manageListingProcessObj;
        ShareSkillAssert shareSkillAsserObj;

        public ManageListingTest() 
        {
            loginProcessObj = new LoginProcess();
            homePageProcessObj = new HomePageProcess();
            manageListingProcessObj = new ManageListingProcess();
            shareSkillAsserObj = new ShareSkillAssert();
        }
        [Test,Order(1)]
        public void DeletedManageListing_Test()
        {
            loginProcessObj.doLogin();
            homePageProcessObj.clickOnProfileManageListing();
            manageListingProcessObj.deleteManageListProcess();
            shareSkillAsserObj.DeleteShareSkillAssert();
        }
    }
}
