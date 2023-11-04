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
        Jsonhelper jsonhelperObj;
        Base baseObj;
        ExtentTest testreport;
        private ExtentReports extent;


        public LoginProcess()
        {
            localPageObj = new LocalPage();
            homePageObj = new HomePage();
            loginComponentObj = new LoginComponent();
            jsonhelperObj = new Jsonhelper();
            baseObj = new Base();

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
                string userNameLabel = homePageObj.VerifyUserName();
                string expectedUserName = "Hi "+ data.firstname;
                Assert.AreEqual(userNameLabel, expectedUserName, "Actual and expected do not match");
            }
        }
        public void validusernameInvalidPasswordProcess()
        {
            baseObj.InitializeExtentReports();
            string testName = "LoginNegativeData";
            baseObj.SetupTest(testName);

            // Read test data from the JSON file using JsonHelper
            string sFile = "LoginNegativeData.json";
            List<LoginTestModel> LoginNegativeData = Jsonhelper.ReadTestDataFromJson<LoginTestModel>(sFile);
            foreach (var data in LoginNegativeData)
            {
                string email = data.email;
                string password = data.password;
                string screenshotName = "LoginNegativeData";
                baseObj.CaptureScreenshot(screenshotName);
                loginComponentObj.validUserInvalidPassword(data);
                string passwordAlertMessage = loginComponentObj.verifypassAlertMessage();
                var alertErrorMessage = passwordAlertMessage;
                string alertMessage = passwordAlertMessage;
                Console.WriteLine("messageBox.Text is: " + passwordAlertMessage);
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
            baseObj.InitializeExtentReports();
            string testName = "InvalidUserData";
            baseObj.SetupTest(testName);
            // Read test data from the JSON file using JsonHelper
            string sFile = ".json";
            List<LoginTestModel> InvalidUserData = Jsonhelper.ReadTestDataFromJson<LoginTestModel>(sFile);
            foreach (var data in InvalidUserData)
            {
                string email = data.email;
                string password = data.password;
                string screenshotName = "InvalidUserData";
                baseObj.CaptureScreenshot(screenshotName);
                loginComponentObj.invalidUsernameValidPassword(data);
                string userNameAlertMessageBox = loginComponentObj.verifyUsernameMessage();
                var errorMessage = userNameAlertMessageBox;
                string alertMessage = userNameAlertMessageBox;
                Console.WriteLine("messagebox.Text is:" + userNameAlertMessageBox);
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
