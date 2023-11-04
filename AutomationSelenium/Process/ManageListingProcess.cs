using AutomationSelenium.Pages.Components.ProfilePageOverview;
using AutomationSelenium.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSelenium.Process
{
    public class ManageListingProcess : Base
    {
        ManageListingComponet manageListingComponetObj;

        public ManageListingProcess()
        {
            manageListingComponetObj = new ManageListingComponet();
        }
        public void deleteManageListProcess()
        {
            manageListingComponetObj.deleteManageList();
            string messageBox = manageListingComponetObj.verifyDeletedList();
            var popupMessageText = messageBox;

            string popupMessage = messageBox;
            Console.WriteLine("messageBox.Text is: " + popupMessage);
            if (popupMessage.Contains("has been deleted"))
            {
                Console.WriteLine("API Testing has been deleted");
            }
            else
            {
                Console.WriteLine("Check Error");
            }

            Assert.AreEqual(messageBox, popupMessageText, "Actual message and expected message do not match");

        }
    }
}
