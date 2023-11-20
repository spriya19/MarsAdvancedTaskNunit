using AutomationSelenium.Pages.Components.ProfilePageOverview;
using AutomationSelenium.Test_Model;
using AutomationSelenium.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSelenium.AssertHelpers
{
    public class ProfileAboutMeAssert : Base
    {
        ProfileAboutMe profileAboutMeObj;

        public ProfileAboutMeAssert()
        {
            profileAboutMeObj = new ProfileAboutMe();
        }

        public void UserNameAssert()
        {
            // Read test data from the JSON file using JsonHelper
            string sFile = "UserNameAvailabilityData.json";
            List<ProfileAvailabilityTestModel> UserNameAvailabilityData = Jsonhelper.ReadTestDataFromJson<ProfileAvailabilityTestModel>(sFile);
            foreach (var profile in UserNameAvailabilityData)
            {
                string addedUserName = profileAboutMeObj.getVerifyUserName();
                string expectedUsername = profile.firstname + " " + profile.lastname;
                Assert.AreEqual(expectedUsername, addedUserName, "Actual Username do not match");

            }
        }
        public void AvailabilityTypeAssert()
        {
            string sFile = "ProfileavailabilityData.json";
            List<ProfileAvailabilityTestModel> ProfileavailabilityData = Jsonhelper.ReadTestDataFromJson<ProfileAvailabilityTestModel>(sFile);
            foreach (var profile in ProfileavailabilityData)
            {
                string availability = profile.availability;
                string addedAvailability = profileAboutMeObj.getAddedAvailability();
                Assert.AreEqual(addedAvailability, availability, "Actual availability and Expected availability do not match");
            }
        }
        public void AvailabilityHoursAssert()
        {
            string sFile = "profileHourData.json";
            List<ProfileAvailabilityTestModel> profileHourDataData = Jsonhelper.ReadTestDataFromJson<ProfileAvailabilityTestModel>(sFile);
            foreach (var profile in profileHourDataData)
            {
                string hours = profile.hours;
                string addedHours = profileAboutMeObj.getAddedHours();
                Assert.AreEqual(addedHours, hours, "Actual availability and Expected availability do not match");
            }
        }
        public void EarnTargetAssert()
        {
            string sFile = "ProfileEarnTargetData.json";
            List<ProfileAvailabilityTestModel> ProfileEarnTargetData = Jsonhelper.ReadTestDataFromJson<ProfileAvailabilityTestModel>(sFile);
            foreach (var profile in ProfileEarnTargetData)
            {
                string earntarget = profile.earntarget;
                string addedEarnTarget = profileAboutMeObj.getAddedEarntarget();
                Assert.AreEqual(addedEarnTarget, earntarget, "Actual availability and Expected availability do not match");
            }
        }

    }
}
