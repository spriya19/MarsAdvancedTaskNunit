using AutomationSelenium.Pages;
using AutomationSelenium.Pages.Components.signin;
using AutomationSelenium.Test_Model;
using AutomationSelenium.Utilities;
using AventStack.ExtentReports;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSelenium.Process
{
    public class LoginProcess : Base
    {
#pragma warning disable
        LocalPage localPageObj;
        HomePage homePageObj;
        LoginComponent loginComponentObj;
        ExtentTest testreport;
        //private ExtentReports extent;


        public LoginProcess()
        {
            localPageObj = new LocalPage();
            homePageObj = new HomePage();
            loginComponentObj = new LoginComponent();

        }

        public void doLogin()
        {
            // Read test data from the JSON file using JsonHelper
            string sFile = "UserInformation.json";
            List<LoginTestModel> UserInformation = Jsonhelper.ReadTestDataFromJson<LoginTestModel>(sFile);
            foreach (var data in UserInformation)
            {

                localPageObj.clickSingIn();
                loginComponentObj.validLogin(data);
            }   
        }
        public void validusernameInvalidPasswordProcess()
        {

            // Read test data from the JSON file using JsonHelper
            string sFile = "LoginNegativeData.json";
            List<LoginTestModel> LoginNegativeData = Jsonhelper.ReadTestDataFromJson<LoginTestModel>(sFile);
            foreach (var data in LoginNegativeData)
            {
                LogScreenshot("InValid Login");

                loginComponentObj.validUserInvalidPassword(data);
                string passwordAlertMessage = loginComponentObj.verifypassAlertMessage();
                var alertErrorMessage = passwordAlertMessage;
                string alertMessage = passwordAlertMessage;
                if (passwordAlertMessage.Contains("Password must be at least 6 characters"))
                {
                    Console.WriteLine("Password must be at least 6 characters");
                }
                else
                {
                    Console.WriteLine("Check Error");
                }

                Assert.AreEqual(alertMessage, passwordAlertMessage, "actual message and expected message do not match");
                if (testreport != null)
                {
                    testreport.Log(Status.Pass, "Test Passed");
                }
            }
        }
        public void invalidUsernameValidPasswordProcess()
        {
            // Read test data from the JSON file using JsonHelper
            string sFile = ".json";
            List<LoginTestModel> InvalidUserData = Jsonhelper.ReadTestDataFromJson<LoginTestModel>(sFile);
            foreach (var data in InvalidUserData)
            {
                LogScreenshot("InvaliduserName");

                loginComponentObj.invalidUsernameValidPassword(data);
                string userNameAlertMessageBox = loginComponentObj.verifyUsernameMessage();
                var errorMessage = userNameAlertMessageBox;
                string alertMessage = userNameAlertMessageBox;
                if (userNameAlertMessageBox.Contains("Please enter a valid email address"))
                {
                    Console.WriteLine("Please enter a valid email address");
                }
                else
                {
                    Console.WriteLine("Check Error");
                }
                Assert.AreEqual(alertMessage, userNameAlertMessageBox, "actual message and expected message do not match");
                if (testreport != null)
                {
                    testreport.Log(Status.Pass, "Test Passed");
                }

            }
        }
    }
}
