using AutomationSelenium.Pages;
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
    public class LoginAssert : Base
    {
        HomePage homePageObj;

        public LoginAssert()
        {
            homePageObj = new HomePage();
        }
        public void LoginAssertion()
        {
            // Read test data from the JSON file using JsonHelper
            string sFile = "UserInformation.json";
            List<LoginTestModel> UserInformation = Jsonhelper.ReadTestDataFromJson<LoginTestModel>(sFile);
            foreach (var data in UserInformation)
            {
                string userNameLabel = homePageObj.VerifyUserName();
                string expectedUserName = "Hi " + data.firstname;
                Assert.AreEqual(userNameLabel, expectedUserName, "Actual and expected do not match");
            }
        }

    }
}
