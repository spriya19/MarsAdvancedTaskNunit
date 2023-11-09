using AutomationSelenium.Test_Model;
using AutomationSelenium.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSelenium.Pages.Components.ProfilePageOverview
{
    public class DescriptionComponent : Base
    {
#pragma warning disable
        private IWebElement enterTextArea;
        private IWebElement saveBtn;
        private IWebElement messageBox;
        private IWebElement addedDescription;
        private IWebElement deletePopupMessage;

        public void renderDescriptionComponents()
        {
            try
            {
                enterTextArea = driver.FindElement(By.Name("value"));
                saveBtn = driver.FindElement(By.XPath("//button[@type='button']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderMessageTestComponent()
        {
            messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

        }
        public void renderDescriptionTestComponent()
        {
            addedDescription = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/div/div/div/span"));
        }
        public void renderDelMessageComponent()
        {
            deletePopupMessage = driver.FindElement(By.XPath("//div[@class='ns-box ns-growl ns-effect-jelly ns-type-error ns-show']\r\n"));
        }
        public void addAndUpdateDescriptionDetails(DescriptionTestModel data)
        {
            Thread.Sleep(2000);
            renderDescriptionComponents();
            enterTextArea.Clear();
            enterTextArea.SendKeys(data.textarea);
            Thread.Sleep(1000);
            saveBtn.Click();
        }
        public void addNegativedes(DescriptionTestModel data)
        {
            renderDescriptionComponents();
            enterTextArea.Clear();
            enterTextArea.SendKeys(data.textarea);
            saveBtn.Click();
        }
        public string negativeDesMessage()
        {
            Wait.WaitToExist(driver, "XPath", "//div[@class='ns-box-inner']", 12);

            renderMessageTestComponent();
            //Wait for the popup message window to display
            return messageBox.Text;
        }
        public string getVerifyAddedDescription()
        {
            Thread.Sleep(2000);
            renderDescriptionTestComponent();
            //Verify the description details
            return addedDescription.Text;
        }
        public string SuccessMessage()
        {
            Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 12);
            renderMessageTestComponent();
            //Saving error or Success message
            return messageBox.Text;
        }
        public void deleteDesc(DescriptionTestModel data)
        {
            renderDescriptionComponents();
            enterTextArea.SendKeys(Keys.Control+"A");
            enterTextArea.SendKeys(Keys.Delete);
            enterTextArea.SendKeys(data.textarea);
            Thread.Sleep(500);
            saveBtn.Click();
        }
        public string verifyPopupMessage()
        {
            Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 12);
            renderDelMessageComponent();
            return deletePopupMessage.Text;
        }

    }

}
