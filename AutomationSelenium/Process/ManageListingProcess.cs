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
           
        }
    }
}
