using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using MachineDLL.Entities;
using MachineDLL.Entities.Traceability;
using MachineDLL.Infrastructure;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;

namespace MachineDLL.DAO
{
    class PrintinfoDAO
    {
        private String sConstr = @"Data Source=prdsvrb\hdd;Initial Catalog=HGSTVericode;User ID=sa;Password=P@ssw0rd;";
        public String PrintUpdate(JobinfoM objJob)
        {
            try
            {
                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;

                    HttpResponseMessage response = client.PostAsJsonAsync("WIP/PrintInfo/PrintUpdate", objJob).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        return "OK";
                    }
                    else
                    {
                        var data = response.Content.ReadAsStringAsync();
                        return "Error:" + data.Result ;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public JobBySerialsM GetHSG2DLasermark(JobBySerialsM objJobM)
        {
            try
            {
                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;

                    HttpResponseMessage response = client.PostAsJsonAsync("WIP/Traceability/GetHSG2DLasermark", objJobM).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsAsync<dynamic>().Result;
                        return JsonConvert.DeserializeObject<JobBySerialsM>(data.ToString());
                    }
                    else
                    {
                        var data = response.Content.ReadAsStringAsync();
                        throw new Exception(data.ToString ());                        
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public JobBySerialsM Verify2D(JobBySerialsM objJobM)
        {
            try
            {
                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;

                    HttpResponseMessage response = client.PostAsJsonAsync("WIP/Traceability/Verify2D", objJobM).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsAsync<dynamic>().Result;
                        return JsonConvert.DeserializeObject<JobBySerialsM>(data.ToString());
                    }
                    else
                    {
                        var data = response.Content.ReadAsStringAsync();
                        throw new Exception(data.ToString());
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public String Completed2DMatching(JobinfoM objJob)
        {
            try
            {
                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;

                    HttpResponseMessage response = client.PostAsJsonAsync("WIP/PrintInfo/Completed2DMatching", objJob).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        return "OK";
                    }
                    else
                    {
                        var data = response.Content.ReadAsStringAsync();
                        return "ERROR:" + data.Result;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public String ScanUpdate(JobinfoM objJob)
        {
            try
            {
                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;

                    HttpResponseMessage response = client.PostAsJsonAsync("WIP/PrintInfo/ScanUpdate", objJob).Result;

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

        public String IsValid2D(List<PrintinfoM> lstSerials)
        {
            try
            {
                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;

                    HttpResponseMessage response = client.PostAsJsonAsync("WIP/PrintInfo/IsValid2D", lstSerials).Result;

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

        public String UpdateSerialno(JobinfoM objJob)
        {
            try
            {
                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;

                    HttpResponseMessage response = client.PostAsJsonAsync("WIP/PrintInfo/UpdateSerialno", objJob).Result;

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

        public PrintinfoM GetPrintInfo(PrintinfoM  objPrintM) //Get All Events Records  
        {
            try
            {
                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;

                    HttpResponseMessage response = client.PostAsJsonAsync("WIP/PrintInfo/GetPrintInfo", objPrintM).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsAsync<dynamic>().Result;
                        objPrintM = JsonConvert.DeserializeObject<PrintinfoM>(data.ToString());
                    }
                    else
                    {
                        var data = response.Content.ReadAsStringAsync();
                        throw new Exception(data.Result);
                    }
                }

                return objPrintM;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public String UpScanGradePrintInfo(String pSerialNo,String pScanGrade)
        {
            DBFactory dbFactory = new DBFactory();
            dbFactory.SetDBConnString(sConstr);
            SqlConnection objConn = dbFactory.GetDBConnection();

            try
            {
                String sql = "UpScanGradePrintInfo";
                List<SqlParameter> sqlParamsIn = new List<SqlParameter>();
                sqlParamsIn.Add(dbFactory.CreateParameterInput("@StrSerial", SqlDbType.VarChar, pSerialNo));
                sqlParamsIn.Add(dbFactory.CreateParameterInput("@StrScanGrade", SqlDbType.VarChar, pScanGrade));

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

        public String isValidateEN(String pEnNo)
        {
            DBFactory dbFactory = new DBFactory();
            dbFactory.SetDBConnString(sConstr);
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

        public String SaveBendingLogin(String ComputerName, String Machine1, String Machine2, String EnNo) //Get All Events Records  
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
                dbFactory.ExecuteNotQueryStoredProc(objConn, null, sql, sqlParamsIn.ToArray(), sqlParamsOut.ToArray());

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


    }
}
