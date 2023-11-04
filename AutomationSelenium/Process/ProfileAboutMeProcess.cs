using AutomationSelenium.Pages.Components.ProfilePageOverview;
using AutomationSelenium.Test_Model;
using AutomationSelenium.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSelenium.Process
{
    public class ProfileAboutMeProcess
    {
#pragma warning disable
        ProfileAboutMe profileAboutMeObj;
        Jsonhelper jsonHelperObj;

        public ProfileAboutMeProcess()
        {
            profileAboutMeObj = new ProfileAboutMe();
            jsonHelperObj = new Jsonhelper();
        }
        public void updateUserName()
        {
            // Read test data from the JSON file using JsonHelper
            string sFile = "UserNameAvailabilityData.json";
            List<UserNameAvailabilityTestModel> UserNameAvailabilityData = Jsonhelper.ReadTestDataFromJson<UserNameAvailabilityTestModel>(sFile);
            foreach(var profile in UserNameAvailabilityData) 
            {
                string firstname = profile.firstname;
                Console.WriteLine(firstname);
                string lastname = profile.lastname;
                Console.WriteLine(lastname);
                profileAboutMeObj.usernameAvailabilityDetails(firstname, lastname);
                string addedUserName = profileAboutMeObj.getVerifyUserName(); 
                string expectedUsername = profile.firstname + " " + profile.lastname;
                Assert.AreEqual(expectedUsername, addedUserName, "Actual Username do not match");
            }

        }
        public void updateAvailabilityType()
        {
            string sFile = "ProfileavailabilityData.json";
            List<ProfileAvailabilityTestModel> ProfileavailabilityData = Jsonhelper.ReadTestDataFromJson<ProfileAvailabilityTestModel>(sFile);
            foreach (var profile in ProfileavailabilityData)
            {
                string availability = profile.availability;
                Console.WriteLine(availability);
                profileAboutMeObj.addAndUpdateAvailabilityDetails(availability);
                string addedAvailability = profileAboutMeObj.getAddedAvailability();
                //string expectedAvailability = profile.availability;
                Assert.AreEqual(addedAvailability, availability,"Actual availability and Expected availability do not match");
            }
        }
        public void updateAvailabilityHours()
        {
            string sFile = "profileHourData.json";
            List<ProfileAvailabilityTestModel> profileHourDataData = Jsonhelper.ReadTestDataFromJson<ProfileAvailabilityTestModel>(sFile);
            foreach (var profile in profileHourDataData)
            {
                string hours = profile.hours;
                Console.WriteLine(hours);
                profileAboutMeObj.addAndUpdateHourDetails(hours);
                string addedHours = profileAboutMeObj.getAddedHours();
                Assert.AreEqual(addedHours, hours, "Actual availability and Expected availability do not match");
            }
        }
        public void updatedAvailabilityEarnTarget()
        {
            string sFile = "ProfileEarnTargetData.json";
            List<ProfileAvailabilityTestModel> ProfileEarnTargetData = Jsonhelper.ReadTestDataFromJson<ProfileAvailabilityTestModel>(sFile);
            foreach (var profile in ProfileEarnTargetData)
            {
                string earntarget = profile.earntarget;
                Console.WriteLine(earntarget);
                profileAboutMeObj.addAndUpdateAvailabilityTargetDetails(earntarget);
                string addedEarnTarget = profileAboutMeObj.getAddedEarntarget();
                Assert.AreEqual(addedEarnTarget, earntarget, "Actual availability and Expected availability do not match");
            }
        }

    }
}
