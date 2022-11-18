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
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using MachineDLL.Common;
using MachineDLL.Entities.TMS;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.Script.Serialization;
using MachineDLL.Infrastructure;
using System.Drawing;

namespace MachineDLL.DAO.TMS
{
    public class PMRecordDAO
    {
        public ItemStorage GetItemStorage(ItemStorage objItem )
        {
            try
            {

                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;

                    HttpResponseMessage response = client.PostAsJsonAsync("TMS/Tooling/GetItemStorage", objItem).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsAsync<dynamic>().Result;

                        objItem = JsonConvert.DeserializeObject<ItemStorage>(data.ToString());

                    }
                    else
                    {
                        var data = response.Content.ReadAsStringAsync();
                        throw new Exception(data.Result);
                    }
                }

                return objItem;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }



    }
}
