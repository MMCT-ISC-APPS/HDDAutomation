using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using MachineDLL.Entities;
using Newtonsoft.Json;

namespace MachineDLL
{
    public class FunctionTestDLL
    {
        static HttpClient client = new HttpClient();
             
        static void Main()
        {
                        
        }
             
        public String DoTestResult(String sMachineType , String sFixtureNo , Int64 iLocation, String sResult , String sPictureNG, String sPathFileData)
        {
            String sMsg = "";

            if (sMachineType == "XRAY")
            {
                sMsg = "OK";
            }
            else
            {
                sMsg = "Machine are wrong type. (it's not xray)";
            }

            //RunAsync().GetAwaiter().GetResult();

            return sMsg;

        }

    }
}
