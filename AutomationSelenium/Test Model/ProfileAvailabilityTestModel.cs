using AutomationSelenium.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSelenium.Test_Model
{
    public class ProfileAvailabilityTestModel : Base
    {
#pragma warning disable
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string availability { get; set; }
        public string hours { get; set; }
        public string earntarget { get; set; }
    }
}
