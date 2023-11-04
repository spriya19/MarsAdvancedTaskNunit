using AutomationSelenium.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSelenium.Pages.Components.ProfilePageOverview
{
    public class ProfileAboutMe : Base
    {
#pragma warning disable
        private IWebElement enterFirstname;
        private IWebElement enterLastname;
        private IWebElement saveBtn;
        private IWebElement addedUserName;
        private IWebElement availabilityType;
        private IWebElement availabilityHour;
        private IWebElement availabilityTarget;
        private IWebElement addedAvailability;
        private IWebElement addedHours;
        private IWebElement addedEarnTarget;
        private IWebElement message;

        public void renderUserComponents()
        {
            try
            {
                enterFirstname = driver.FindElement(By.Name("firstName"));
                enterLastname = driver.FindElement(By.Name("lastName"));
                saveBtn = driver.FindElement(By.XPath("//button[normalize-space()='Save']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
       
        }
        public void renderavailabilityTypeComponent()
        {
            availabilityType = driver.FindElement(By.Name("availabiltyType"));

        }

        public void renderAddTestComponent()
        {
            addedUserName = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[2]/div/div/div[1]"));

        }
        public void renderAvailabilityHourComponent() 
        {
            availabilityHour = driver.FindElement(By.Name("availabiltyHour"));

        }
        public void renderavailabilityEarnTargetComponent()
        {
            availabilityTarget = driver.FindElement(By.Name("availabiltyTarget"));
        }
        public void renderAvailabilityTestComponent()
        {
            addedAvailability = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span"));
        }
        public void renderHoursTestComponent()
        {
            addedHours = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div"));
        }
        public void renderEarnTargetTestComponent()
        {
            addedEarnTarget = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span"));
        }
        public void renderMessageComponent() 
        {
            message = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
        }
        public void usernameAvailabilityDetails(string firstname,string lastname)
        {
            renderUserComponents();
            enterFirstname.Clear();
            enterFirstname.SendKeys(firstname);
            enterLastname.Clear();
            enterLastname.SendKeys(lastname);
            saveBtn.Click();
        }
        public string getVerifyUserName()
        {
            renderAddTestComponent();
            return addedUserName.Text;
        }
        public void addAndUpdateAvailabilityDetails(string availability)
        {
            renderavailabilityTypeComponent();
            availabilityType.SendKeys(availability);
        }
        public string getAddedAvailability()
        {
            renderAvailabilityTestComponent();
            return addedAvailability.Text;
        }
        public string getSuccessMessage()
        {
            Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 12);
            renderMessageComponent();
            //Saving error or Success message
            return message.Text;
        }
        public void addAndUpdateHourDetails(string hour)
        {
            renderAvailabilityHourComponent();
            availabilityHour.SendKeys(hour);
        }
        public string getAddedHours()
        { 
            renderHoursTestComponent();
            return addedHours.Text;
        }
        public void addAndUpdateAvailabilityTargetDetails(string earntarget)
        {
            renderavailabilityEarnTargetComponent();
            availabilityTarget.SendKeys(earntarget);
        }
        public string getAddedEarntarget()
        {
            renderEarnTargetTestComponent();
            return addedEarnTarget.Text;
        }



    }
}
