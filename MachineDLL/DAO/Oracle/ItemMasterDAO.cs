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
using Newtonsoft.Json;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using MachineDLL.Common;
using System.Data.SqlClient;

namespace MachineDLL.DAO
{
    class ItemMasterDAO
    {

        public  ItemMasterM  GetItemMaster(ItemMasterM objItem) //Get All Events Records  
        {
            try
            {
                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;

                    HttpResponseMessage response = client.PostAsJsonAsync("INV/ItemMaster/GetItemMaster", objItem).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsAsync<ItemMasterM>();
                        objItem = (ItemMasterM)(data.Result);
                        return objItem;
                    }
                    else
                    {
                        var data = response.Content.ReadAsStringAsync();
                        throw new Exception(data.Result) ;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ItemMasterM GetOnhandByJobandLot(ItemMasterM objItem) //Get All Events Records  
        {
            try
            {
                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;

                    HttpResponseMessage response = client.PostAsJsonAsync("INV/ItemMaster/GetOnhandByJobandLot", objItem).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsAsync<ItemMasterM>();
                        objItem = (ItemMasterM)(data.Result);
                        return objItem;
                    }
                    else
                    {
                        var data = response.Content.ReadAsStringAsync();
                        throw new Exception(data.Result);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
