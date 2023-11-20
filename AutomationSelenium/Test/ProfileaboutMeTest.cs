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
    public class ProfileaboutMeTest : Base
    {
#pragma warning disable
        LoginProcess loginProcessObj;
        HomePageProcess homePageProcessObj;
        ProfileAboutMeProcess profileAboutMeProcessObj;
        ProfileAboutMeAssert profileAboutMeAssertObj;

        public ProfileaboutMeTest() 
        {
            loginProcessObj = new LoginProcess();
            homePageProcessObj = new HomePageProcess();
            profileAboutMeProcessObj = new ProfileAboutMeProcess();
            profileAboutMeAssertObj = new ProfileAboutMeAssert();
        }
        [Test ,Order(1)]
        public void updatedProfileUsername_Test()
        {
            loginProcessObj.doLogin();
            homePageProcessObj.clickOnAvailabilityUserName();
            profileAboutMeProcessObj.updateUserName();
            profileAboutMeAssertObj.UserNameAssert();
         
        }
        [Test ,Order(2)]
        public void updatedProfileAvailabilityType_Test() 
        {
            loginProcessObj.doLogin();
            homePageProcessObj.clickOnAvailabilityEditIcon();
            profileAboutMeProcessObj.updateAvailabilityType();
            profileAboutMeAssertObj.AvailabilityTypeAssert();
        }
        [Test ,Order(3)]
        public void updatedProfileAvailabilityHours_Test() 
        {
            loginProcessObj.doLogin();
            homePageProcessObj.clickOnHoursEditIcon();
            profileAboutMeProcessObj.updateAvailabilityHours();
            profileAboutMeAssertObj.AvailabilityHoursAssert();
        }
        [Test ,Order(4)]
        public void updatedProfileAvailabilityEarnTarget_Test()
        {
            loginProcessObj.doLogin();
            homePageProcessObj.clickOnEarnTargetEditIcon();
            profileAboutMeProcessObj.updatedAvailabilityEarnTarget();
            profileAboutMeAssertObj.EarnTargetAssert();
        }

    }
}
