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

namespace MachineDLL.DAO
{
    class UtilityDAO
    {
        public String ConnectDatabase(Boolean bSG2D)
        {
            try
            {
                using (var client = new WebClient()) //WebClient  
                {
                    client.Headers.Add("Content-Type:application/json"); //Content-Type  
                    client.Headers.Add("Accept:application/json");

                    var result = client.DownloadString(SystemController.HTTP_PATH + "/api/Utility?bSG2D=" + bSG2D ); //URI  

                    String sTmp = JsonConvert.DeserializeObject<String>(result);

                    return sTmp;
                    
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public String GetWebServiceVersion()
        {
            try
            {
                using (var client = new WebClient()) //WebClient  
                {
                    client.Headers.Add("Content-Type:application/json"); //Content-Type  
                    client.Headers.Add("Accept:application/json");

                    var result = client.DownloadString(SystemController.HTTP_PATH + "/api/Utility/GetWebServiceVersion"); //URI  

                    return result.ToString();

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

   

    }

    
}
