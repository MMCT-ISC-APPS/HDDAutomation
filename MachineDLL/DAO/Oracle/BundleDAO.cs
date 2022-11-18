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
    class BundleDAO
    {
        public BundleInfoM getBundleNo(BundleInfoM objBundle)
        {
            try
            {
                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;

                    HttpResponseMessage response = client.PostAsJsonAsync("INV/Bundle/getBundleNo", objBundle).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsAsync<dynamic>().Result;
                        objBundle = JsonConvert.DeserializeObject<BundleInfoM>(data.ToString());                       
                        return objBundle;
                    }
                    else
                    {
                        String data = response.Content.ReadAsStringAsync().Result;
                        throw new Exception(data);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public String GetJobCounterFromTempTable(BundleInfoM objBundle)
        {
            try
            {
                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;

                    HttpResponseMessage response = client.PostAsJsonAsync("INV/Bundle/GetJobCounterFromTempTable", objBundle).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        String data = response.Content.ReadAsStringAsync().Result;
                        return data;
                    }
                    else
                    {
                        String data = response.Content.ReadAsStringAsync().Result;
                        throw new Exception(data);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public DataTable  GetSIBundleDetail(BundleInfoM objBundle)
        {
            try
            {
                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;

                    HttpResponseMessage response = client.PostAsJsonAsync("INV/Bundle/GetSIBundle", objBundle).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsAsync<dynamic>().Result;

                        DataTable dt = JsonConvert.DeserializeObject<DataTable>(data.ToString());

                        return dt;

                    }
                    else
                    {
                        String data = response.Content.ReadAsStringAsync().Result;
                        throw new Exception(data);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        public String Add2DTempAutopack(BundleInfoM objBundle)
        {
            try
            {
                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;

                    HttpResponseMessage response = client.PostAsJsonAsync("INV/Bundle/Add2DTempAutopack", objBundle).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        String data = response.Content.ReadAsStringAsync().Result;
                        return data;
                    }
                    else
                    {
                        String data = response.Content.ReadAsStringAsync().Result;
                        throw new Exception(data);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public BundleInfoM  Validate2D(BundleInfoM objBundle)
        {
            try
            {
                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;

                    HttpResponseMessage response = client.PostAsJsonAsync("INV/Bundle/Validate2D", objBundle).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsAsync<dynamic>().Result;
                        objBundle = JsonConvert.DeserializeObject<BundleInfoM>(data.ToString());
                        return objBundle;
                    }
                    else
                    {
                        String data = response.Content.ReadAsStringAsync().Result;
                        throw new Exception(data);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public String CancelPack(BundleInfoM objBundle)
        {
            try
            {
                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;

                    HttpResponseMessage response = client.PostAsJsonAsync("INV/Bundle/CancelPack", objBundle).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        String data = response.Content.ReadAsStringAsync().Result;                        
                        return data;
                    }
                    else
                    {
                        String data = response.Content.ReadAsStringAsync().Result;
                        throw new Exception(data);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public String ValidatedAISkipProcess(BundleInfoM  objBundleM)
        {
            try
            {
                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;

                    HttpResponseMessage response = client.PostAsJsonAsync("INV/Bundle/ValidatedAISkipProcess", objBundleM).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        String data = response.Content.ReadAsStringAsync().Result;
                        return data;                                           
                    }
                    else
                    {
                        String data = response.Content.ReadAsStringAsync().Result;
                        throw new Exception(data);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public Boolean  CompletePackNone2D(BundleInfoM objBundle)
        {
            try
            {
                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;

                    HttpResponseMessage response = client.PostAsJsonAsync("INV/Bundle/CompletedPackingNone2D", objBundle).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        //var data = response.Content.ReadAsAsync<dynamic>().Result;
                        //objBundle = JsonConvert.DeserializeObject<BundleInfoM>(data.ToString());
                        return true;
                    }
                    else
                    {
                        String data = response.Content.ReadAsStringAsync().Result;
                        throw new Exception(data);
                    }
                }

            }
            catch (Exception ex)
            {
                //return false;
                throw new Exception(ex.Message);
            }

        }

        public BundleInfoM GetSummarizeJobQtyByBundle(BundleInfoM objBundle)
        {
            try
            {
                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;

                    HttpResponseMessage response = client.PostAsJsonAsync("INV/Bundle/GetSummarizeJobQtyByBundle", objBundle).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsAsync<dynamic>().Result;
                        objBundle = JsonConvert.DeserializeObject<BundleInfoM>(data.ToString());     
                        return objBundle;
                    }
                    else
                    {
                        String data = response.Content.ReadAsStringAsync().Result;
                        throw new Exception(data);
                    }
                }

            }
            catch (Exception ex)
            {
                //return false;
                throw new Exception(ex.Message);
            }

        }

        public Boolean CompletedPacking(BundleInfoM objBundle)
        {
            try
            {
                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;

                    HttpResponseMessage response = client.PostAsJsonAsync("INV/Bundle/CompletedPacking", objBundle).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        //var data = response.Content.ReadAsAsync<dynamic>().Result;
                        //objBundle = JsonConvert.DeserializeObject<BundleInfoM>(data.ToString());
                        return true;
                    }
                    else
                    {
                        String data = response.Content.ReadAsStringAsync().Result;
                        throw new Exception(data);
                    }
                }

            }
            catch (Exception ex)
            {
                //return false;
                throw new Exception(ex.Message);
            }

        }

        public Boolean ReprintHitashiBundle(BundleInfoM objBundle)
        {
            try
            {
                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;

                    HttpResponseMessage response = client.PostAsJsonAsync("INV/Bundle/ReprintHitashiBundle", objBundle).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        //var data = response.Content.ReadAsAsync<dynamic>().Result;
                        //objBundle = JsonConvert.DeserializeObject<BundleInfoM>(data.ToString());
                        return true;
                    }
                    else
                    {
                        String data = response.Content.ReadAsStringAsync().Result;
                        throw new Exception(data);
                    }
                }

            }
            catch (Exception ex)
            {
                //return false;
                throw new Exception(ex.Message);
            }

        }


    }
}
