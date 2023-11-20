using AutomationSelenium.AssertHelpers;
using AutomationSelenium.Pages;
using AutomationSelenium.Pages.Components.signin;
using AutomationSelenium.Process;
using AutomationSelenium.Test_Model;
using AutomationSelenium.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSelenium.Test
{
    [TestFixture]
    public class LoginTest : Base
    {
        LocalPage localPageObj;
        LoginProcess loginProcessObj;
        LoginAssert loginAssertObj; 
        public LoginTest()
        {
            loginProcessObj = new LoginProcess();
            localPageObj = new LocalPage();
            loginAssertObj = new LoginAssert();
        }

        [Test , Order(1)]
        public void givenLoginCreds_whenDoLogin_thenIsLoggedIn_Test()
        {
            loginProcessObj.doLogin();
            loginAssertObj.LoginAssertion();
        }
        [Test , Order(2)]
        public void givenValidUserNameinvalidPassword_Test()
        {
            localPageObj.clickSingIn();
            loginProcessObj.validusernameInvalidPasswordProcess();

        }
        [Test , Order(3)]
        public void givenInvalidUserNameValidPassword_Test()
        {
            localPageObj.clickSingIn();
            loginProcessObj.validusernameInvalidPasswordProcess();

        }

    }
}
