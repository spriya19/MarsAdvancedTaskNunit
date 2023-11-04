using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSelenium.Utilities
{
    public class Jsonhelper
    {
        public static List<T> ReadTestDataFromJson<T>(string jsonFile)
        {
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            //Console.WriteLine("From JSON Helper.. Current Directory: " +sCurrentDirectory);
            string sFile = System.IO.Path.Combine(sCurrentDirectory, @"..\..\..\JsonData\" + jsonFile);
            string sFilePath = Path.GetFullPath(sFile);
            //Console.WriteLine("From JSON Helper.. file Path: "+sFilePath);  
            string jsonContent = File.ReadAllText(sFilePath);
#pragma warning disable 
            List<T> testData = JsonConvert.DeserializeObject<List<T>>(jsonContent);
#pragma warning disable
            return testData;
        }
    }
}
