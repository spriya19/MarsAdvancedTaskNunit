using AutomationSelenium.AssertHelpers;
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
    public class DescriptionTest : Base
    {
#pragma warning disable
        LoginProcess loginProcessObj;
        HomePageProcess homePageProcessObj;
        DescriptionProcess descriptionProcessObj;
        DescriptionAssert descriptionAssertObj;

        public DescriptionTest()
        {
            loginProcessObj  = new LoginProcess();
            homePageProcessObj = new HomePageProcess();
            descriptionProcessObj = new DescriptionProcess();
            descriptionAssertObj = new DescriptionAssert();

        }
        [Test,Order(1)]
        public void updatedUserDescription_Test()
        {
            loginProcessObj.doLogin();
            homePageProcessObj.clickOnDescriptionEditBtn();
            descriptionProcessObj.updatedDescription();
            descriptionAssertObj.updatedDescriptionAssert();
        }
        [Test,Order(2)]
        public void deletedDescription_Test() 
        {
            loginProcessObj.doLogin();
            homePageProcessObj.clickOnDescriptionEditBtn();
            descriptionProcessObj.deleteDescription();
            descriptionAssertObj.deleteDescriptionAssert();
        }
        [Test,Order(3)]
        public void negativeDescri_Test()
        {
            loginProcessObj.doLogin();
            homePageProcessObj.clickOnDescriptionEditBtn();
            descriptionProcessObj.addNegativeDescri();
            descriptionAssertObj.NegativeDescriAssert();
        }

    }
}

