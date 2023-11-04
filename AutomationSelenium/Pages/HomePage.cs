using AutomationSelenium.Pages.Components.ProfilePageOverview;
using AutomationSelenium.Utilities;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSelenium.Pages
{
    public class HomePage : Base
    {
#pragma warning disable
        private IWebElement userNameLabel;
       
        public void renderUserComponent()
        {
            userNameLabel = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span"));
        }
       public string VerifyUserName()
        {
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span", 12);
            renderUserComponent();
            return userNameLabel.Text;
        }




    }
}
