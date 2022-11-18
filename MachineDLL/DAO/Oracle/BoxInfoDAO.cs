using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using MachineDLL.Entities;
using MachineDLL.Infrastructure;
using MachineDLL.Common;
using Newtonsoft.Json;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MachineDLL.DAO
{
    class BoxInfoDAO
    {
        public List<String> getStampcancelType()
        {
            try
            {
                using (var client = new WebClient()) //WebClient  
                {
                    client.Headers.Add("Content-Type:application/json"); //Content-Type  
                    client.Headers.Add("Accept:application/json");

                    var result = client.DownloadString(SystemController.HTTP_PATH + "/INV/BoxInfo/GetStampcancelType"); //URI  

                    List<String> sTmp = JsonConvert.DeserializeObject<List<String>>(result);

                    return sTmp;

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<String> getScanType()
        {
            try
            {
                using (var client = new WebClient()) //WebClient  
                {
                    client.Headers.Add("Content-Type:application/json"); //Content-Type  
                    client.Headers.Add("Accept:application/json");

                    var result = client.DownloadString(SystemController.HTTP_PATH + "/INV/BoxInfo/GetScanType"); //URI  

                    List<String> sTmp = JsonConvert.DeserializeObject<List<String>>(result);

                    return sTmp;

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
