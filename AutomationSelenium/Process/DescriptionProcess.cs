using AutomationSelenium.Pages.Components.ProfilePageOverview;
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
    public class DescriptionProcess : Base
    {
#pragma warning disable
        DescriptionComponent descriptionComponentObj;
        
        public DescriptionProcess()
        {
            descriptionComponentObj = new DescriptionComponent();
        }
        public void updatedDescription()
        {
           // Read test data from the JSON file using JsonHelper
            string sFile = "DescriptionData.json";
            List<DescriptionTestModel> DescriptionData = Jsonhelper.ReadTestDataFromJson<DescriptionTestModel>(sFile);
            foreach (var data in DescriptionData)
            {
                LogScreenshot("AddDescription");
                 descriptionComponentObj.addAndUpdateDescriptionDetails(data);
                
            }


        }
        public void addNegativeDescri()
        {
            // Read test data from the JSON file using JsonHelper
            string sFile = "NegativeDescriptionData.json";
            List<DescriptionTestModel> NegativeDescriptionData = Jsonhelper.ReadTestDataFromJson<DescriptionTestModel>(sFile);
            foreach (var data in NegativeDescriptionData)
            {
                LogScreenshot("AddNeagtiveDescription");

                descriptionComponentObj.addNegativedes(data);
            }
        }
        public void deleteDescription()
        {
            string sFile = "DeleteDescData.json";
            List<DescriptionTestModel> DeleteDescData = Jsonhelper.ReadTestDataFromJson<DescriptionTestModel>(sFile);
            foreach (var data in DeleteDescData)
            {
                LogScreenshot("DeleteDescription");

                descriptionComponentObj.deleteDesc(data);
            }

        }

    }
}
