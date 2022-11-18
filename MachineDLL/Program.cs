using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MachineDLL.DAO;
using MachineDLL.Common;
using MachineDLL.Entities;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MachineDLL
{
    public class Program
    {
        private bool bOffline;
        private static JobinfoM objJobInfo = null;
        private bool bCompleted;        
        static void Main(string[] args)
        {
        }


        public Program(Boolean Offline )
        {
            bOffline = Offline;
        }


        public String DoTestResult(String sMachineType, String sFixtureNo, Int64 iLocation, String sResult, String sPictureNG, String sPathFileData)
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
