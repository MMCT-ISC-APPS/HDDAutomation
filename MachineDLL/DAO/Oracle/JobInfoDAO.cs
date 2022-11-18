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
    class JobInfoDAO
    {
        Boolean bSG2D;
        public JobInfoDAO()
        {

        }

        public JobInfoDAO(bool SG2D)
        {
            bSG2D = SG2D;
        }

        public void  getJobinfoCollection(String sJobName) //Get All Events Records  
        {
            using (var client = new WebClient()) //WebClient  
            {
                client.Headers.Add("Content-Type:application/json"); //Content-Type  
                client.Headers.Add("Accept:application/json");

                var result = client.DownloadString(SystemController.HTTP_PATH + "/api/Jobs?Jobname=" + sJobName); //URI  

                Console.WriteLine(Environment.NewLine + result);

            }
        }

        public List<JobinfoM>  getJobInQue(String sConputerName) //Get All Events Records  
        {
            List<JobinfoM> str;
            //Jobinfo objJob;

            using (var client = new WebClient()) //WebClient  
            {
                client.Headers.Add("Content-Type:application/json"); //Content-Type  
                client.Headers.Add("Accept:application/json");

                var result = client.DownloadString(SystemController.HTTP_PATH + "/wip/jobinfo/GetJobInQue?sComputer=" + sConputerName); //URI  

                str = JsonConvert.DeserializeObject<List<JobinfoM>>(result);

                return str;

                //Console.WriteLine(Environment.NewLine + result);

            }
        }

        public String TransferToJigsaw(PanelInfoM objPanel) //Get All Events Records  
        {
            try
            {
                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;

                    HttpResponseMessage response = client.PostAsJsonAsync("wip/jobinfo/TranferJigsaw", objPanel).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        //var data = response.Content.ReadAsAsync<string>().Result;

                        //String sTmp = JsonConvert.DeserializeObject<string>(data.ToString());
                        String sTmp = "OK";
                        
                        return sTmp;
                    }
                    else
                    {
                        return null;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }           
        }

        public JobinfoM  ValidateJobBuild(JobinfoM  objJobM) //Get All Events Records  
        {
            try
            {
                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;

                    HttpResponseMessage response = client.PostAsJsonAsync("wip/jobinfo/ValidateJobBuild", objJobM).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsAsync<JobinfoM>();
                        objJobM = (JobinfoM)(data.Result );                         
                        return objJobM;
                    }
                    else
                    {
                        String data = response.Content.ReadAsStringAsync().Result  ;
                        throw new Exception(data);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public JobinfoM IsValidJob(JobinfoM objJobM) //Get All Events Records  
        {
            try
            {
                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;

                    HttpResponseMessage response = client.PostAsJsonAsync("wip/jobinfo/IsValidJob", objJobM).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsAsync<JobinfoM>();
                        objJobM = (JobinfoM)(data.Result);
                        return objJobM;
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

        public JobinfoM  GetAvailableQty(JobinfoM objJob) //Get All Events Records  
        {
            try
            {
                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;

                    HttpResponseMessage response = client.PostAsJsonAsync("wip/jobinfo/GetAvailableQty", objJob).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsAsync<string>().Result;

                        JobinfoM objJobM = JsonConvert.DeserializeObject<JobinfoM>(data.ToString());
                        
                        return objJobM;
                    }
                    else
                    {
                        return null;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public List<JobinfoM> UpdateStatusJobQ(String sConputerName) //Get All Events Records  
        {
            List<JobinfoM> str;
            //Jobinfo objJob;

            using (var client = new WebClient()) //WebClient  
            {
                client.Headers.Add("Content-Type:application/json"); //Content-Type  
                client.Headers.Add("Accept:application/json");

                var result = client.DownloadString(SystemController.HTTP_PATH + "/wip/jobinfo/UpdateJobQueStatus?ComputerName=" + sConputerName); //URI  

                str = JsonConvert.DeserializeObject<List<JobinfoM>>(result);

                return str;
                //Console.WriteLine(Environment.NewLine + result);

            }
        }



        public JobinfoM getJobinfo(String sJobName ) //Get All Events Records  
        {
            try
            {
                JobinfoM objJobM = new JobinfoM();

                if (bSG2D == true)
                {
                    objJobM = getJobInfoSG2D(sJobName);
                }
                else
                {
                    objJobM = getJobInfo(sJobName);
                }
                
                return objJobM;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        private JobinfoM getJobInfoSG2D(String sJobname)
        {
            try
            {
                using (var client = new WebClient()) //WebClient  
                {
                    client.Headers.Add("Content-Type:application/json"); //Content-Type  
                    client.Headers.Add("Accept:application/json");
                                        
                    var result = client.DownloadString(SystemController.HTTP_PATH + "wip/jobinfo/Master2D?Jobname=" + sJobname); //URI  

                    JobinfoM objJobM = JsonConvert.DeserializeObject<JobinfoM>(result);

                    return objJobM;

                    //Console.WriteLine(Environment.NewLine + result);

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private JobinfoM getJobInfo(String sJobname)
        {
            try
            {
                using (var client = new WebClient()) //WebClient  
                {
                    client.Headers.Add("Content-Type:application/json"); //Content-Type  
                    client.Headers.Add("Accept:application/json");

                    var result = client.DownloadString(SystemController.HTTP_PATH + "wip/jobinfo/Jobs?Jobname=" + sJobname); //URI  

                    JobinfoM objJobM = JsonConvert.DeserializeObject<JobinfoM>(result);

                    return objJobM;
                    
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public  JobinfoM getMachineJobInfo(String sJobname)
        {
            
            JobinfoM objJobM = null;

            try
            {
                DataTable dt = getJobInfoM(sJobname);

                if (dt.Rows.Count == 0)
                {
                    throw new Exception("Error: Cannot found jobname:" + sJobname.ToString());
                }
                else
                {
                    objJobM = new JobinfoM()
                    {
                        ModelName = dt.Rows[0]["segment1"].ToString()
                        ,
                        PanelNo = "",
                        CPN = ""
                        ,
                        JobQty = Convert.ToInt64(dt.Rows[0]["jobsize"].ToString())
                        ,
                        Status = ""
                        ,
                        PanelSize = Convert.ToInt64(dt.Rows[0]["fixturesize"].ToString())
                        ,
                        StandardPackSize = Convert.ToInt64(dt.Rows[0]["attribute2"].ToString())
                        ,
                        WIPID = dt.Rows[0]["wip_entity_id"].ToString()
                        ,
                        ClassCode = dt.Rows[0]["classcode"].ToString()
                        ,
                        PrefixCust = ""
                        ,
                        JobName = sJobname
                        ,
                        InventoryItemID = Convert.ToInt64(dt.Rows[0]["inventory_item_id"].ToString())
                        ,
                        PrimaryUOM = dt.Rows[0]["primary_uom_code"].ToString()
                    };
                }
                return objJobM;

                }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable getJobInfoM(String sJobname)
        {
            DBFactory dbFactory = new DBFactory();
            dbFactory.SetDBConnString(@"Data Source=prdsvr.mektec.co.th;Initial Catalog=CenterConOra;User ID=sa;Password=P@ssw0rd;");
            SqlConnection objConn = dbFactory.GetDBConnection();

            DataSet ds = new DataSet();
            DataTable dataTbl = null;

            try
            {

                String sql = "getjobbuildinfo";

                List<SqlParameter> sqlParamsIn = new List<SqlParameter>();
                sqlParamsIn.Add(dbFactory.CreateParameterInput("@Jobname", SqlDbType.VarChar, sJobname));

                ds = dbFactory.ExecuteQueryStoredProc(objConn, null, sql, sqlParamsIn.ToArray(), null);

                dataTbl = ds.Tables[0];

                return dataTbl;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dbFactory.CloseConnection(objConn, ds, dataTbl);
            }
        }


        public DataTable GetPanelImg(string sLayoutId)
        {
            DBFactory dbFactory = new DBFactory();
            SqlConnection objConn = dbFactory.GetDBConnection();
            string sSql = "";
            DataTable dsTmp = null/* TODO Change to default(_) if this is not a reference type */;
            DataSet ds = null;
            try
            {
                sSql = "GetPanelImg";

                List<SqlParameter> sqlParamsIn = new List<SqlParameter>();

                sqlParamsIn.Add(dbFactory.CreateParameterInput("@LayoutID", SqlDbType.VarChar, sLayoutId));

                ds = dbFactory.ExecuteQueryStoredProc(objConn, null, sSql, sqlParamsIn.ToArray(), null);

                dsTmp = ds.Tables[0];

                return dsTmp;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dbFactory.CloseConnection(objConn, ds, dsTmp);
            }
        }

        public DataTable getFixturebyjob(JobinfoM objJob)
        {
            try
            {
                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;

                    HttpResponseMessage response = client.PostAsJsonAsync("wip/jobinfo/getFixturebyjob", objJob).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsAsync<dynamic>().Result;

                        DataTable  dt = JsonConvert.DeserializeObject<DataTable>(data.ToString());

                        return dt;
                    }
                    else
                    {
                        return null;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public  String UpdateStatusJobQ(JobinfoM objJob)
        {
            try
            {
                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;

                    HttpResponseMessage response = client.PostAsJsonAsync("wip/jobinfo/UpdateStatusJobQ", objJob).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        return "OK";
                    }
                    else
                    {
                        return response.ToString()  ;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public String StartRead(JobinfoM objJob , Int64 Remain)
        {
            try
            {
                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;
                    objJob.Remain = Remain;

                    HttpResponseMessage response = client.PostAsJsonAsync("wip/jobinfo/StartRead", objJob).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        return "OK";
                    }
                    else {
                        return  "Error:" + response.ToString();
                    }                    
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public String AddJobInQue(JobinfoM objJob)
        {
            try
            {
                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;
                                        
                    HttpResponseMessage response = client.PostAsJsonAsync("wip/jobinfo/AddJobInQue", objJob).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        return "OK";
                    }
                    else
                    {
                        return "Error:" + response.ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public String  UpdateRemain(JobinfoM objJob)
        {
            try
            {
                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;

                    HttpResponseMessage response = client.PostAsJsonAsync("wip/jobinfo/UpdateRemain", objJob).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsStringAsync ();
                        
                        return data.Result.ToString() ;
                    }
                    else
                    {
                        String data = response.Content.ReadAsStringAsync().Result;
                        throw new Exception(data);
                    }
                    //var result = client.PostAsJsonAsync("wip/jobinfo/UpdateRemain", objJob).Result;

                    //return result.ToString() ;

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<String> get2DLabelsHSG(JobinfoM objJob)
        {
            try
            {
                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;

                    HttpResponseMessage response = client.PostAsJsonAsync("wip/jobinfo/get2DLabelsHSG", objJob).Result;

                    if (response.IsSuccessStatusCode)
                    {                        
                        var data =  response.Content.ReadAsAsync <IList<String>>();
                        List<String> objList = (List<String>)data.Result;


                        return objList;
                        
                        //return ResponseMessage(response);

                    }
                    else
                    {
                        throw new Exception("Error:" + response.ToString());
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public String RegisterFixture(JobinfoM objJob)
        {
            try
            {
                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;

                    HttpResponseMessage response = client.PostAsJsonAsync("wip/jobinfo/RegisterFiture", objJob).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result ;

                        return result.ToString();
                    }
                    else
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        throw new Exception ( result.ToString());
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public String DeleteFixture(JobinfoM objJob)
        {
            try
            {
                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;

                    HttpResponseMessage response = client.PostAsJsonAsync("wip/jobinfo/DeleteFixture", objJob).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;

                        return result.ToString();
                    }
                    else
                    {
                        return "Error:" + response.ToString();
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
