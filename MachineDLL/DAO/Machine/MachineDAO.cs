using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using MachineDLL.Entities;
using MachineDLL.Entities.AutoDictate;
using MachineDLL.Infrastructure;
using Newtonsoft.Json;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using MachineDLL.Common;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
//using System.Web.Script.Serialization;

namespace MachineDLL.DAO
{
    class MachineDAO
    {
        public DataTable  Generate2DBarcode(ref JobinfoM objJobM)
        {
            String sTmp = "";
            String Y;
            String M;
            String D;

            try
            {
                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;

                    GetYWW_HTS(DateTime.Now.Date, out Y, out M, out D);

                    objJobM.PrefixBarcode = objJobM.Prefix2D + objJobM.PrefixCust.Trim() + Y.Trim() + M.Trim() + D.Trim();
                   
                   var json = new JavaScriptSerializer().Serialize(objJobM);

                    HttpContent inputContent = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = client.PostAsync("api/Machine/Generate2DBarcode", inputContent).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsStringAsync().Result;
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
            catch (OperationCanceledException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void GetYWW_HTS(DateTime date, out string Y, out string M, out string D)
        {
            try
            {
                Y = date.Year.ToString().Substring(3, 1);
                M = date.Month.ToString();
                if (Convert.ToInt64(M) >= 10)
                {
                    if (M == "10")
                    {
                        M = "X";
                    }
                    else
                    {
                        if (M == "11")
                        {
                            M = "Y";
                        }
                        else
                        {
                            if (M == "12")
                            {
                                M = "Z";
                            }
                        }

                    }
                }

                D = Datecode(date.Day.ToString());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        private String Datecode(String day)
        {
            String sDateCode = "";
            Int64 iTotal = 0;
            Int64 iAscii = 0;

            if (Convert.ToUInt64(day) < 10)
            {
                sDateCode = day;
            }
            else
            {
                iTotal = Convert.ToInt64(day) - 10;
                iAscii = 66 + iTotal;

                char character = (char)iAscii;
                sDateCode = character.ToString();
            }
            return sDateCode;
        }


        public JobinfoM GetTotalPrinted(JobinfoM objJobM)
        {
            try
            {
                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;

                    var json = new JavaScriptSerializer().Serialize(objJobM);

                    HttpContent inputContent = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = client.PostAsync ("api/Machine/GetTotalPrinted", inputContent).Result;
                    //HttpResponseMessage response = client.PostAsJsonAsync("api/Machine/GetTotalPrinted", objJobM).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsStringAsync().Result;
                        objJobM = JsonConvert.DeserializeObject<JobinfoM>(data.ToString());                        
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

        //public List<FixtureResult> UpdateAOIforTri(List<FixtureResult> objFixtures)
        public FixtureResult UpdateAOIforTri(FixtureResult objFixtures)
        {
            try
            {
                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;

                    var json = new JavaScriptSerializer().Serialize(objFixtures);

                    HttpContent inputContent = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = client.PostAsync("api/AOITRI/UpdateAOIforTri", inputContent).Result;                    

                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsStringAsync().Result;
                        objFixtures = JsonConvert.DeserializeObject<FixtureResult>(data.ToString());
                        return objFixtures;
                    }
                    else
                    {
                        var data = response.Content.ReadAsStringAsync().Result;                        
                        throw new Exception(data.ToString ());
                    }

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public AutoDictConfigurationM GetModelConfiguration(AutoDictConfigurationM objConfigM)
        {
            try
            {
                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;

                    var json = new JavaScriptSerializer().Serialize(objConfigM);

                    HttpContent inputContent = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = client.PostAsync("api/AutoDict/GetModelConfiguration", inputContent).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsStringAsync().Result;
                        objConfigM = JsonConvert.DeserializeObject<AutoDictConfigurationM>(data.ToString());
                        return objConfigM;
                    }
                    else
                    {
                        var data = response.Content.ReadAsStringAsync().Result;
                        //objFixtures = JsonConvert.DeserializeObject<FixtureResult>(data.ToString());
                        throw new Exception(data.ToString());
                    }

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable  SaveBendingInfo(PrintinfoM objPrintM) //Get All Events Records  
        {
            DataTable dt;

            try
            {
                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;

                    HttpResponseMessage response = client.PostAsJsonAsync("api/Machine/SaveBendingInfo", objPrintM).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsAsync<dynamic>().Result;
                        dt =   JsonConvert.DeserializeObject<DataTable >(data.ToString());
                    }
                    else
                    {
                        var data = response.Content.ReadAsStringAsync();
                        throw new Exception(data.Result);
                    }
                }

                return dt;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public String SaveKeepBraketReader(string Jobname, string SerialNo, string StrModel, string Machinename, string dataReader, string UpdBy) //Get All Events Records  
        {
            DBFactory dbFactory = new DBFactory();
            dbFactory.SetDBConnString(@"Data Source=prdsvrb\hdd;Initial Catalog=HGSTVericode;User ID=sa;Password=P@ssw0rd;");
            SqlConnection objConn = dbFactory.GetDBConnection();


            DataSet ds = new DataSet();

            try
            {
                String sql = "keep_tmp_read_serial";

                List<SqlParameter> sqlParamsIn = new List<SqlParameter>();
                sqlParamsIn.Add(dbFactory.CreateParameterInput("@jobname", SqlDbType.VarChar, Jobname));
                sqlParamsIn.Add(dbFactory.CreateParameterInput("@serialno", SqlDbType.VarChar, SerialNo));
                sqlParamsIn.Add(dbFactory.CreateParameterInput("@model", SqlDbType.VarChar, StrModel));
                sqlParamsIn.Add(dbFactory.CreateParameterInput("@MachineName", SqlDbType.VarChar, Machinename));
                sqlParamsIn.Add(dbFactory.CreateParameterInput("@dataReader", SqlDbType.VarChar, dataReader));
                sqlParamsIn.Add(dbFactory.CreateParameterInput("@updBy", SqlDbType.VarChar, UpdBy)); 

                dbFactory.ExecuteNotQueryStoredProc(objConn, null, sql, sqlParamsIn.ToArray(), null);

                return "OK";

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dbFactory.CloseConnection(objConn, ds, null);
            }
        }
        public String SaveBraketInfo(PrintinfoM objPrintM) //Get All Events Records  
        {
            DBFactory dbFactory = new DBFactory();
            dbFactory.SetDBConnString(@"Data Source=prdsvrb\hdd;Initial Catalog=HGSTVericode;User ID=sa;Password=P@ssw0rd;");
            SqlConnection objConn = dbFactory.GetDBConnection();


            DataSet ds = new DataSet();

            try
            {
                String sql = "InsertBraketInfo";

                List<SqlParameter> sqlParamsIn = new List<SqlParameter>();
                sqlParamsIn.Add(dbFactory.CreateParameterInput("@Serialno", SqlDbType.VarChar, objPrintM.Serialno));
                sqlParamsIn.Add(dbFactory.CreateParameterInput("@grade", SqlDbType.VarChar, objPrintM.ScanGrade));
                sqlParamsIn.Add(dbFactory.CreateParameterInput("@SerialSeq", SqlDbType.Int, objPrintM.Sequence));
                sqlParamsIn.Add(dbFactory.CreateParameterInput("@ModelCode", SqlDbType.VarChar, objPrintM.ModelName));
                sqlParamsIn.Add(dbFactory.CreateParameterInput("@ReadGroup", SqlDbType.VarChar, objPrintM.PanelID));
                sqlParamsIn.Add(dbFactory.CreateParameterInput("@MachineName", SqlDbType.VarChar, objPrintM.MachineName));
                sqlParamsIn.Add(dbFactory.CreateParameterInput("@Jobname", SqlDbType.VarChar, objPrintM.JobName));
                sqlParamsIn.Add(dbFactory.CreateParameterInput("@score", SqlDbType.VarChar, objPrintM.Score ));

                dbFactory.ExecuteNotQueryStoredProc(objConn, null, sql, sqlParamsIn.ToArray(), null);

                return "OK";

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dbFactory.CloseConnection(objConn, ds, null);
            }
        }
        public String SaveBendingLogin(String ComputerName,String Machine1, String Machine2, String EnNo) //Get All Events Records  
        {
            DBFactory dbFactory = new DBFactory();
            dbFactory.SetDBConnString(@"Data Source=prdsvrb\hdd;Initial Catalog=HGSTVericode;User ID=sa;Password=P@ssw0rd;");
            SqlConnection objConn = dbFactory.GetDBConnection();


            DataSet ds = new DataSet();

            try
            {
                String sql = "SaveBendingLogin";

                List<SqlParameter> sqlParamsIn = new List<SqlParameter>();
                sqlParamsIn.Add(dbFactory.CreateParameterInput("@ComputerName", SqlDbType.VarChar, ComputerName));
                sqlParamsIn.Add(dbFactory.CreateParameterInput("@MachineName", SqlDbType.VarChar, Machine1)); 
                sqlParamsIn.Add(dbFactory.CreateParameterInput("@MachineName2", SqlDbType.VarChar, Machine2)); 
                sqlParamsIn.Add(dbFactory.CreateParameterInput("@EnNumber", SqlDbType.VarChar, EnNo));


                List<SqlParameter> sqlParamsOut = new List<SqlParameter>();

                sqlParamsOut.Add(dbFactory.CreateParameterOutput("@ErrorMsg", SqlDbType.NVarChar, 240));

                dbFactory.ExecuteNotQueryStoredProc(objConn, null, sql, sqlParamsIn.ToArray(),  sqlParamsOut.ToArray());

                return sqlParamsOut[0].Value.ToString();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dbFactory.CloseConnection(objConn, ds, null);
            }
        }
        public String isValidateEN(String pEnNo)
        {
            DBFactory dbFactory = new DBFactory();
            dbFactory.SetDBConnString(@"Data Source=prdsvrb\hdd;Initial Catalog=HGSTVericode;User ID=sa;Password=P@ssw0rd;");
            
            SqlConnection objConn = dbFactory.GetDBConnection();

            try
            {
                String sql = "isValidateEN";
                List<SqlParameter> sqlParamsIn = new List<SqlParameter>();
                sqlParamsIn.Add(dbFactory.CreateParameterInput("@pEnNumber", SqlDbType.VarChar, pEnNo));
                //sqlParamsIn.Add(dbFactory.CreateParameterInput("@StrScanGrade", SqlDbType.VarChar, pScanGrade));

                List<SqlParameter> sqlParamsOut = new List<SqlParameter>();

                sqlParamsOut.Add(dbFactory.CreateParameterOutput("@ErrorMsg", SqlDbType.NVarChar, 240));

                dbFactory.ExecuteNotQueryStoredProc(objConn, null, sql, sqlParamsIn.ToArray(), sqlParamsOut.ToArray());

                return sqlParamsOut[0].Value.ToString();

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                dbFactory.CloseConnection(objConn, null, null);
            }
        }
        public String getBendingMachineName(String pComputerName)
        {
            DBFactory dbFactory = new DBFactory();
            dbFactory.SetDBConnString(@"Data Source=prdsvrb\hdd;Initial Catalog=HGSTVericode;User ID=sa;Password=P@ssw0rd;");

            SqlConnection objConn = dbFactory.GetDBConnection();

            try
            {
                String sql = "getBendingMachineName";
                List<SqlParameter> sqlParamsIn = new List<SqlParameter>();
                sqlParamsIn.Add(dbFactory.CreateParameterInput("@comName", SqlDbType.VarChar, pComputerName));
                //sqlParamsIn.Add(dbFactory.CreateParameterInput("@StrScanGrade", SqlDbType.VarChar, pScanGrade));

                List<SqlParameter> sqlParamsOut = new List<SqlParameter>();

                sqlParamsOut.Add(dbFactory.CreateParameterOutput("@ErrorMsg", SqlDbType.NVarChar, 240));
                sqlParamsOut.Add(dbFactory.CreateParameterOutput("@BendingMachineName1", SqlDbType.NVarChar, 240));
                sqlParamsOut.Add(dbFactory.CreateParameterOutput("@BendingMachineName2", SqlDbType.NVarChar, 240));

                dbFactory.ExecuteNotQueryStoredProc(objConn, null, sql, sqlParamsIn.ToArray(), sqlParamsOut.ToArray());

                return sqlParamsOut[0].Value.ToString()+","+ sqlParamsOut[1].Value.ToString() + "," + sqlParamsOut[2].Value.ToString();
                //return sqlParamsOut[0].Value.ToString() ;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                dbFactory.CloseConnection(objConn, null, null);
            }
        }
        public List<String> GetBendingMaster(String MachineName) //Get All Events Records  
        {
            List<string> objModel;

            using (var client = new WebClient()) //WebClient  
            {
                client.Headers.Add("Content-Type:application/json"); //Content-Type  
                client.Headers.Add("Accept:application/json");

                var result = client.DownloadString(SystemController.HTTP_PATH + "/api/Machine/GetBendingMaster?MachineName=" + MachineName); //URI  

                objModel = JsonConvert.DeserializeObject<List<String>>(result);

                return objModel;

            }
        }

        public DataTable GetInkDataMachine(JobinfoM objJob)
        {
            try
            {
                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;

                    HttpResponseMessage response = client.PostAsJsonAsync("api/Machine/GetInkDataMachine", objJob).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsAsync<dynamic>().Result;

                        DataTable dt = JsonConvert.DeserializeObject<DataTable>(data.ToString());

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

        public DataTable GetMachineConfig(MachineInfoM objMachineM)
        {
            try
            {
                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;

                    HttpResponseMessage response = client.PostAsJsonAsync("api/Machine/GetMachineConfig", objMachineM).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsAsync<dynamic>().Result;

                        DataTable dt = JsonConvert.DeserializeObject<DataTable >(data.ToString());

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

        public MachineInfoM  SaveMachineInfo(MachineInfoM objMachineM)
        {
            try
            {
                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;

                    HttpResponseMessage response = client.PostAsJsonAsync("api/Machine/SaveMachineInfo", objMachineM).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsAsync<dynamic>().Result;

                        MachineInfoM objMachineTmpM = JsonConvert.DeserializeObject<MachineInfoM>(data.ToString());

                        return objMachineTmpM;
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

        public String UploadAOIFromServer(MachineInfoM objMachineM)
        {
            try
            {
                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;

                    HttpResponseMessage response = client.PostAsJsonAsync("api/Machine/UploadAOITRIFromServer", objMachineM).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsStringAsync().Result ;
                        
                        return data.ToString ();
                    }
                    else
                    {
                        var data = response.Content.ReadAsStringAsync().Result;

                        throw new Exception(data.ToString());

                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable   GetMachineFileUpload(MachineInfoM objMachineM)
        {
            try
            {
                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;

                    HttpResponseMessage response = client.PostAsJsonAsync("api/Machine/GetMachineFileUpload", objMachineM).Result;

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


        public MachineInfoM InsertAOIInfo(MachineInfoM objMachineM)
        {
            try
            {
                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;

                    HttpResponseMessage response = client.PostAsJsonAsync("api/Machine/InsertAOIInfo", objMachineM).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsAsync<dynamic>().Result;

                        MachineInfoM objMachineTmpM = JsonConvert.DeserializeObject<MachineInfoM>(data.ToString());

                        return objMachineTmpM;
                    }
                    else
                    {
                        var data = response.Content.ReadAsStringAsync ().Result;
                        throw new Exception(data.ToString());
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public String UploadErrorFile(String sFileName, String CustName)
        {
            HttpClient httpClient = new HttpClient();
            String file = sFileName;
            FileInfoM objFile = new FileInfoM();

            // Read the files 
            try
            {
                var fileInfo = new FileInfo(file);
                var json = new JavaScriptSerializer().Serialize(objFile);

                //using (var content = new MultipartFormDataContent())

                using (var client = new HttpClient())
                using (var content = new MultipartFormDataContent())
                {
                    // Make sure to change API address
                    client.BaseAddress = new Uri(SystemController.HTTP_PATH);

                    // Add first file content 
                    var fileContent1 = new ByteArrayContent(File.ReadAllBytes(sFileName));

                    fileContent1.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                    {
                        FileName = fileInfo.Name
                    };

                    content.Add(fileContent1, "hdd-picsave");

                    var result = client.PostAsync("/api/Machine/UploadError?CustName=" + CustName, content).Result;

                    if (result.StatusCode == HttpStatusCode.OK)
                    {
                        //var data = result.Content.ReadAsAsync<List<String>>();
                        var data = result.Content.ReadAsStringAsync();
                        List<String> obj = JsonConvert.DeserializeObject<List<String>>(data.Result);

                        return obj[0];

                    }
                    else
                    {
                        var data = result.Content.ReadAsStringAsync().Result;
                        throw new Exception(data.ToString());
                    }


                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        public String UploadFile(String sFileName, String CustName)
        {
            HttpClient httpClient = new HttpClient();
            String file = sFileName;
            FileInfoM objFile = new FileInfoM();

            // Read the files 
            try
            {
                var fileInfo = new FileInfo(file);
                var json = new   JavaScriptSerializer().Serialize(objFile);

                //using (var content = new MultipartFormDataContent())

                using (var client = new HttpClient())
                using  (var content = new MultipartFormDataContent())
                {
                    // Make sure to change API address
                    client.BaseAddress = new Uri(SystemController.HTTP_PATH);

                    // Add first file content 
                    var fileContent1 = new ByteArrayContent(File.ReadAllBytes(sFileName));

                    fileContent1.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                    {
                        FileName = fileInfo.Name
                    };

                    content.Add(fileContent1, "hdd-picsave");

                    var result = client.PostAsync("/api/Machine/Post?CustName=" + CustName, content).Result;

                    if (result.StatusCode == HttpStatusCode.OK)
                    {
                        //var data = result.Content.ReadAsAsync<List<String>>();
                        var data = result.Content.ReadAsStringAsync();
                        List<String> obj =  JsonConvert.DeserializeObject<List<String>>(data.Result);

                        return obj[0];

                    }
                    else
                    {
                        var data = result.Content.ReadAsStringAsync();
                        throw new Exception(data.ToString());
                    }


                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public String UploadFileFromServer(String sFileName, String CustName , String sComputer)
        {
            HttpClient httpClient = new HttpClient();
            String file = sFileName;
            FileInfoM objFile = new FileInfoM();

            // Read the files 
            try
            {
                var fileInfo = new FileInfo(file);
                var json = new JavaScriptSerializer().Serialize(objFile);

                //using (var content = new MultipartFormDataContent())

                using (var client = new HttpClient())
                using (var content = new MultipartFormDataContent())
                {
                    // Make sure to change API address
                    client.BaseAddress = new Uri(SystemController.HTTP_PATH);

                    // Add first file content 
                    var fileContent1 = new ByteArrayContent(File.ReadAllBytes(sFileName));

                    fileContent1.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                    {
                        FileName = fileInfo.Name
                    };

                    content.Add(fileContent1, "hdd-picsave");

                    var result = client.PostAsync("/api/Machine/UploadOnServer?CustName=" + CustName + "&ComputerName=" + sComputer, content).Result;

                    if (result.StatusCode == HttpStatusCode.OK)
                    {
                        //var data = result.Content.ReadAsAsync<List<String>>();
                        var data = result.Content.ReadAsStringAsync();
                        List<String> obj = JsonConvert.DeserializeObject<List<String>>(data.Result);

                        return obj[0];

                    }
                    else
                    {
                        var data = result.Content.ReadAsStringAsync();
                        throw new Exception(data.ToString());
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
