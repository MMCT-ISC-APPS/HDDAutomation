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
using System.Data.SqlClient;
using System.Globalization;
using System.Web.Script.Serialization;
using MachineDLL.Infrastructure;
using System.Drawing;

namespace MachineDLL.DAO
{
    class ReworkDAO
    {
        private static String CenConstr = "Data Source=prdsvr.mektec.co.th;Initial Catalog=CenterConOra;User ID=sa;Password=P@ssw0rd;";
        public ItemReworkInfoM GetModelRework(ItemReworkInfoM objItemRework)
        {
            byte[] bytImg = null;
            MemoryStream ms;

            try
            {
               
                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;

                    HttpResponseMessage response = client.PostAsJsonAsync("WIP/Rework/GetModelRework", objItemRework).Result;

                    if (response.IsSuccessStatusCode)
                    {                            
                        var data = response.Content.ReadAsAsync<dynamic>().Result;

                        objItemRework = JsonConvert.DeserializeObject<ItemReworkInfoM>(data.ToString());
                    }
                    else
                    {
                        var data = response.Content.ReadAsStringAsync();
                        throw new Exception(data.Result);
                    }
                }

                if (objItemRework.BytePic != null)
                {
                    bytImg = (byte[])objItemRework.BytePic;

                    ms = new MemoryStream(bytImg);

                    ms.Position = 0;
                    Image img;

                    img = Image.FromStream(ms);

                    objItemRework.imgPanel = img;

                }

                return objItemRework;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                bytImg = null;
                ms = null;
                //dbFactory.CloseConnection(objConn, ds, dsTmp);
            }
        }

        public ItemReworkInfoM GetModelReworkHistory(ItemReworkInfoM objItemRework)
        {
            try
            {

                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;

                    HttpResponseMessage response = client.PostAsJsonAsync("WIP/Rework/GetModelReworkHistory", objItemRework).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsAsync<dynamic>().Result;

                        objItemRework = JsonConvert.DeserializeObject<ItemReworkInfoM>(data.ToString());
                    }
                    else
                    {
                        var data = response.Content.ReadAsStringAsync();
                        throw new Exception(data.Result);
                    }
                }
             
                return objItemRework;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
        public ItemReworkInfoM SaveReworkModel(ItemReworkInfoM objItem) //Get All Events Records  
        {
            DBFactory dbFactory = new DBFactory();
            dbFactory.SetDBConnString(CenConstr);
            SqlConnection objConn = dbFactory.GetDBConnection();

            try
            {
                byte[] ImageBytes = new byte[1];
                Image MyImage = objItem.imgPanel;

                using (MemoryStream mStream = new MemoryStream())
                {
                    MyImage.Save(mStream, MyImage.RawFormat);
                    ImageBytes = mStream.ToArray();
                }

                String sql = "SaveReworkModel";

                List<SqlParameter> sqlParamsIn = new List<SqlParameter>();

                sqlParamsIn.Add(dbFactory.CreateParameterInput("@Model", SqlDbType.VarChar, objItem.Model));
                sqlParamsIn.Add(dbFactory.CreateParameterInput("@Image", SqlDbType.Image, ImageBytes));
                sqlParamsIn[1].Size = ImageBytes.Length;

                sqlParamsIn.Add(dbFactory.CreateParameterInput("@Customer", SqlDbType.VarChar, objItem.Customer));

                List<SqlParameter> sqlParamsOut = new List<SqlParameter>();

                sqlParamsOut.Add(dbFactory.CreateParameterOutput("@reworkID", SqlDbType.Int, 0));

                dbFactory.ExecuteQueryStoredProc(objConn, null, sql, sqlParamsIn.ToArray(), sqlParamsOut.ToArray());

                objItem.reworkmodelid = sqlParamsOut[0].Value.ToString();

                return objItem;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally {
                dbFactory.CloseConnection(objConn, null, null);
            }

        }

        public String SaveLayoutReworkItem(ItemReworkInfoM  objItem) //Get All Events Records  
        {
            try
            {
                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;

                    HttpResponseMessage response = client.PostAsJsonAsync("WIP/Rework/SaveLayoutReworkItem", objItem).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsStringAsync();                        
                        return data.Result;
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

        public  ItemReworkInfoM  GetAllReworkCriteriaData(ItemReworkInfoM objItem) //Get All Events Records  
        {
            try
            {
                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;

                    HttpResponseMessage response = client.PostAsJsonAsync("WIP/Rework/GetAllReworkCriteriaData", objItem).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsAsync<dynamic>().Result;
                        objItem = JsonConvert.DeserializeObject<ItemReworkInfoM>(data.ToString());
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

        public ItemReworkInfoM SaveRework2D(ItemReworkInfoM objItem) //Get All Events Records  
        {
            try
            {
                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;

                    HttpResponseMessage response = client.PostAsJsonAsync("WIP/Rework/SaveRework2D", objItem).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsAsync<dynamic>().Result;
                        objItem = JsonConvert.DeserializeObject<ItemReworkInfoM>(data.ToString());
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
