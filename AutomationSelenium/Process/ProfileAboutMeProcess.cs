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
        }
        public void updateUserName()
        {
            // Read test data from the JSON file using JsonHelper
            string sFile = "UserNameAvailabilityData.json";
            List<ProfileAvailabilityTestModel> UserNameAvailabilityData = Jsonhelper.ReadTestDataFromJson<ProfileAvailabilityTestModel>(sFile);
            foreach(var user in UserNameAvailabilityData) 
            {
                profileAboutMeObj.usernameAvailabilityDetails(user);
            }

        }
        public void updateAvailabilityType()
        {
            string sFile = "ProfileavailabilityData.json";
            List<ProfileAvailabilityTestModel> ProfileavailabilityData = Jsonhelper.ReadTestDataFromJson<ProfileAvailabilityTestModel>(sFile);
            foreach (var profile in ProfileavailabilityData)
            {
                string availability = profile.availability;
                profileAboutMeObj.addAndUpdateAvailabilityDetails(profile);
                
            }
        }
        public void updateAvailabilityHours()
        {
            string sFile = "profileHourData.json";
            List<ProfileAvailabilityTestModel> profileHourDataData = Jsonhelper.ReadTestDataFromJson<ProfileAvailabilityTestModel>(sFile);
            foreach (var profile in profileHourDataData)
            {
                string hours = profile.hours;
                profileAboutMeObj.addAndUpdateHourDetails(profile);
            }
        }
        public void updatedAvailabilityEarnTarget()
        {
            string sFile = "ProfileEarnTargetData.json";
            List<ProfileAvailabilityTestModel> ProfileEarnTargetData = Jsonhelper.ReadTestDataFromJson<ProfileAvailabilityTestModel>(sFile);
            foreach (var profile in ProfileEarnTargetData)
            {
                string earntarget = profile.earntarget;
                profileAboutMeObj.addAndUpdateAvailabilityTargetDetails(profile);
               
            }
        }

    }
}
