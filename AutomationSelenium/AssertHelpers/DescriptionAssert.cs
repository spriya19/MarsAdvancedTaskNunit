using AutomationSelenium.Pages.Components.ProfilePageOverview;
using AutomationSelenium.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSelenium.AssertHelpers
{
    public class DescriptionAssert : Base
    {
        DescriptionComponent descriptionComponentObj;
        public DescriptionAssert()
        {
            descriptionComponentObj = new DescriptionComponent();
        }
        public string messageAssertion()
        {
            IWebElement messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 12);
            string actualMessage = messageBox.Text;
            return actualMessage;
        }
    }

}
