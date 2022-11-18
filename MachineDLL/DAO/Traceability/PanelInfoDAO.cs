using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using MachineDLL.Entities;

using System.Data;
using Newtonsoft.Json;
using MachineDLL.Infrastructure;
using System.Data.SqlClient;

namespace MachineDLL.DAO
{
    class PanelInfoDAO
    {
        private String sConstr = @"Data Source=prdsvrb\hdd;Initial Catalog=HGSTVericode;User ID=sa;Password=P@ssw0rd;";

        public PanelInfoM GetPanelInfo(PanelInfoM objPanel)
        {
            try
            {
                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;

                    HttpResponseMessage response = client.PostAsJsonAsync("WIP/PrintInfo/GetPanelInfo", objPanel).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var data =  response.Content.ReadAsAsync<dynamic>().Result ;
                                                
                        PanelInfoM objPanelM = JsonConvert.DeserializeObject<PanelInfoM>(data.ToString ());
                                                
                        return objPanelM;
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

        public DataTable  GeneratedSerial(JobinfoM objJob)
        {
            try
            {
                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;

                    HttpResponseMessage response = client.PostAsJsonAsync("WIP/PrintInfo/GenerateSerials", objJob).Result;

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

        public DataTable GetBraketView(PrintinfoM objPrintM)
        {
            try
            {
                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;

                    HttpResponseMessage response = client.PostAsJsonAsync("WIP/PrintInfo/GetBraketView", objPrintM).Result;

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

        
        public String HaveBraketInfo(PrintinfoM objPrintM)
        {
            DBFactory dbFactory = new DBFactory();
            dbFactory.SetDBConnString(sConstr);
            SqlConnection objConn = dbFactory.GetDBConnection();

            try
            {
                String sql = "HaveBraketInfo";
                List<SqlParameter> sqlParamsIn = new List<SqlParameter>();
                sqlParamsIn.Add(dbFactory.CreateParameterInput("@StrSerial", SqlDbType.VarChar, objPrintM.Serialno));

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

        public DataTable  StartRead(JobinfoM  objJobM)
        {
            DBFactory dbFactory = new DBFactory();
            dbFactory.SetDBConnString(sConstr);
            SqlConnection objConn = dbFactory.GetDBConnection();
            DataTable dt = null;
            DataSet ds = null;

            try
            {
                String sql = "StartJob";

                List<SqlParameter> sqlParamsIn = new List<SqlParameter>();

                sqlParamsIn.Add(dbFactory.CreateParameterInput("@JobQty", SqlDbType.Int , objJobM.JobQty));
                sqlParamsIn.Add(dbFactory.CreateParameterInput("@model", SqlDbType.VarChar , objJobM.ModelName ));

                ds = dbFactory.ExecuteQueryStoredProc(objConn, null, sql, sqlParamsIn.ToArray(), null);

                if (ds.Tables.Count == 1)
                {
                    return ds.Tables[0];
                }
                else {
                    return ds.Tables[1];
                }                

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dbFactory.CloseConnection(objConn, ds, dt);
            }
        }

        public DataTable StartReadSpecial(JobinfoM objJobM)
        {
            DBFactory dbFactory = new DBFactory();
            dbFactory.SetDBConnString(sConstr);
            SqlConnection objConn = dbFactory.GetDBConnection();
            DataTable dt = null;
            DataSet ds = null;

            try
            {
                String sql = "StartJobSpecial";

                List<SqlParameter> sqlParamsIn = new List<SqlParameter>();

                sqlParamsIn.Add(dbFactory.CreateParameterInput("@JobQty", SqlDbType.Int, objJobM.JobQty));
                sqlParamsIn.Add(dbFactory.CreateParameterInput("@model", SqlDbType.VarChar, objJobM.ModelName));

                ds = dbFactory.ExecuteQueryStoredProc(objConn, null, sql, sqlParamsIn.ToArray(), null);

                if (ds.Tables.Count == 1)
                {
                    return ds.Tables[0];
                }
                else
                {
                    return ds.Tables[1];
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dbFactory.CloseConnection(objConn, ds, dt);
            }
        }
        public DataTable GetModelConfig(JobinfoM objJobM)
        {
            DBFactory dbFactory = new DBFactory();
            dbFactory.SetDBConnString(sConstr);
            SqlConnection objConn = dbFactory.GetDBConnection();
            DataTable dt = null;
            DataSet ds = null;

            try
            {
                String sql = "GetModelConfig";

                List<SqlParameter> sqlParamsIn = new List<SqlParameter>();
                 
                sqlParamsIn.Add(dbFactory.CreateParameterInput("@model", SqlDbType.VarChar, objJobM.ModelName));

                ds = dbFactory.ExecuteQueryStoredProc(objConn, null, sql, sqlParamsIn.ToArray(), null);

                if (ds.Tables.Count == 1)
                {
                    return ds.Tables[0];
                }
                else
                {
                    return ds.Tables[1];
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dbFactory.CloseConnection(objConn, ds, dt);
            }
        }
        //public String[] GetSerials(JobinfoM objJob)
        //{
        //    string[] Tmp;
        //    try
        //    {
        //        using (var client = new HttpClient()) //WebClient  
        //        {
        //            Uri baseAddress = new Uri(SystemController.HTTP_PATH);

        //            client.BaseAddress = baseAddress;

        //            HttpResponseMessage response = client.PostAsJsonAsync("wip/jobinfo/GetSerials", objJob).Result;

        //            if (response.IsSuccessStatusCode)
        //            {
        //                var data = response.Content.ReadAsAsync<dynamic>().Result;
        //                Tmp = JsonConvert.DeserializeObject<String []>(data.ToString());
        //                return Tmp;
        //            }
        //            else
        //            {
        //                var data = response.Content.ReadAsStringAsync();
        //                throw new Exception(data.ToString());
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}



        public String InsertBraketSerial(JobinfoM objJobM,String sSerialno)
        {
            DBFactory dbFactory = new DBFactory();
            dbFactory.SetDBConnString(sConstr);
            SqlConnection objConn = dbFactory.GetDBConnection();           

            try
            {
                String sql = "InsertBraketSerial";
                List<SqlParameter> sqlParamsIn = new List<SqlParameter>();
                sqlParamsIn.Add(dbFactory.CreateParameterInput("@Serialno", SqlDbType.VarChar , sSerialno.Trim()));
                sqlParamsIn.Add(dbFactory.CreateParameterInput("@Prefix", SqlDbType.VarChar, objJobM.Prefix2D ));
                sqlParamsIn.Add(dbFactory.CreateParameterInput("@jobname", SqlDbType.VarChar, objJobM.JobName));
                sqlParamsIn.Add(dbFactory.CreateParameterInput("@Model", SqlDbType.VarChar, objJobM.ModelName));
                sqlParamsIn.Add(dbFactory.CreateParameterInput("@createby", SqlDbType.VarChar, objJobM.ComputerName ));

                dbFactory.ExecuteNotQueryStoredProc (objConn,  sql, sqlParamsIn.ToArray(),null);

                return "OK";

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dbFactory.CloseConnection(objConn, null, null);
            }
        }

        public String UpdateBraketSerial(String sSerialno, String sComputerName)
        {
            DBFactory dbFactory = new DBFactory();
            dbFactory.SetDBConnString(sConstr);
            SqlConnection objConn = dbFactory.GetDBConnection();

            try
            {
                String sql = "UpdateBraketSerial";
                List<SqlParameter> sqlParamsIn = new List<SqlParameter>();
                sqlParamsIn.Add(dbFactory.CreateParameterInput("@Serialno", SqlDbType.VarChar, sSerialno.Trim()));
                sqlParamsIn.Add(dbFactory.CreateParameterInput("@createby", SqlDbType.VarChar, sComputerName ));

                dbFactory.ExecuteNotQueryStoredProc(objConn, sql, sqlParamsIn.ToArray(), null);

                return "OK";

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dbFactory.CloseConnection(objConn, null, null);
            }
        }
        public DataTable  GetBraketSerialNo(JobinfoM objJobM)
        {
            DBFactory dbFactory = new DBFactory();
            dbFactory.SetDBConnString(sConstr);
            SqlConnection objConn = dbFactory.GetDBConnection();
            DataTable dt = null;
            DataSet ds = null;

            try
            {
                String sql = "GetBraketSerials";
                List<SqlParameter> sqlParamsIn = new List<SqlParameter>();
                sqlParamsIn.Add(dbFactory.CreateParameterInput("@Jobname", SqlDbType.VarChar, objJobM.JobName));
                sqlParamsIn.Add(dbFactory.CreateParameterInput("@panelsize", SqlDbType.VarChar, objJobM.PanelSize));

                ds = dbFactory.ExecuteQueryStoredProc(objConn,null, sql, sqlParamsIn.ToArray(), null);

                dt = ds.Tables[0];

                return dt;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dbFactory.CloseConnection(objConn, ds, dt);
            }
        }

        public int GetBraketPanelSizeByMachine(String sComputerName)
        {
            DBFactory dbFactory = new DBFactory();
            dbFactory.SetDBConnString(sConstr);
            SqlConnection objConn = dbFactory.GetDBConnection();

            try
            {
                String sql = "GetBraketMachinePanelSize";
                List<SqlParameter> sqlParamsIn = new List<SqlParameter>();
                sqlParamsIn.Add(dbFactory.CreateParameterInput("@machineName", SqlDbType.VarChar, sComputerName));

                List<SqlParameter> sqlParamsOut = new List<SqlParameter>();

                sqlParamsOut.Add(dbFactory.CreateParameterOutput("@PanelSize", SqlDbType.Int, 16));

                dbFactory.ExecuteNotQueryStoredProc(objConn, null, sql, sqlParamsIn.ToArray(), sqlParamsOut.ToArray());

                return Convert.ToInt16( sqlParamsOut[0].Value);

            }
            catch (Exception ex)
            {
                return 15;
            }
            finally
            {
                dbFactory.CloseConnection(objConn, null, null);
            }
        }

        public int GetBraketPanelSizeByMachineNew(String sComputerName)
        {
            DBFactory dbFactory = new DBFactory();
            dbFactory.SetDBConnString(sConstr);
            SqlConnection objConn = dbFactory.GetDBConnection();
            DataTable dt = null;
            DataSet ds = null;
            int PanelSize = 15;
            try
            {
                String sql = "GetBraketMachine";
                List<SqlParameter> sqlParamsIn = new List<SqlParameter>();
                sqlParamsIn.Add(dbFactory.CreateParameterInput("@machineName", SqlDbType.VarChar, sComputerName));

                ds = dbFactory.ExecuteQueryStoredProc(objConn, null, sql, sqlParamsIn.ToArray(), null);

                dt = ds.Tables[0];

                    if (dt.Rows.Count == 0)
                    {
                        PanelSize =  15;
                    }else
                    {
                        PanelSize =  Convert.ToInt16(dt.Rows[0]["LoadCavity"]);
                    }
                return PanelSize;

                }
            catch (Exception ex)
            {
                return 15;
            }
            finally
            {
                dbFactory.CloseConnection(objConn, null, null);
            }
            //return PanelSize;
        }

        public Boolean HaveBraketBarcodeGen(String Jobname)
        {
            DBFactory dbFactory = new DBFactory();
            dbFactory.SetDBConnString(sConstr);
            SqlConnection objConn = dbFactory.GetDBConnection();
            DataTable dt = null;
            DataSet ds = null;

            try
            {
                String sql = "HaveBraketBarcodeGen";
                List<SqlParameter> sqlParamsIn = new List<SqlParameter>();
                sqlParamsIn.Add(dbFactory.CreateParameterInput("@Jobname", SqlDbType.VarChar, Jobname));

                ds = dbFactory.ExecuteQueryStoredProc(objConn, null, sql, sqlParamsIn.ToArray(), null);

                dt = ds.Tables[0];

                if (dt.Rows.Count == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dbFactory.CloseConnection(objConn, ds, dt);
            }
        }

        public Boolean  HaveAfterReflow(String sSerialno)
        {
            DBFactory dbFactory = new DBFactory();
            dbFactory.SetDBConnString(sConstr);
            SqlConnection objConn = dbFactory.GetDBConnection();
            DataTable dt = null;
            DataSet ds = null;

            try
            {
                String sql = "GetAfterReflow";
                List<SqlParameter> sqlParamsIn = new List<SqlParameter>();
                sqlParamsIn.Add(dbFactory.CreateParameterInput("@Serialno", SqlDbType.VarChar, sSerialno));
                
                ds = dbFactory.ExecuteQueryStoredProc(objConn, null, sql, sqlParamsIn.ToArray(), null);

                dt = ds.Tables[0];

                if (dt.Rows.Count == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dbFactory.CloseConnection(objConn, ds, dt);
            }
        }

        //public String GetTotalBraket(String sJobname)
        //{
        //    DBFactory dbFactory = new DBFactory();
        //    dbFactory.SetDBConnString(@"Data Source=prdsvrb\hdd;Initial Catalog=HGSTVericode;User ID=sa;Password=P@ssw0rd;");
        //    SqlConnection objConn = dbFactory.GetDBConnection();

        //    try
        //    {
        //        String sql = "HaveBraketInfo";

        //        List<SqlParameter> sqlParamsIn = new List<SqlParameter>();
        //        sqlParamsIn.Add(dbFactory.CreateParameterInput("@StrSerial", SqlDbType.VarChar, objPrintM.Serialno));

        //        List<SqlParameter> sqlParamsOut = new List<SqlParameter>();

        //        sqlParamsOut.Add(dbFactory.CreateParameterOutput("@ErrorMsg", SqlDbType.NVarChar, 240));

        //        dbFactory.ExecuteNotQueryStoredProc(objConn, null, sql, sqlParamsIn.ToArray(), sqlParamsOut.ToArray());

        //        return sqlParamsOut[0].Value.ToString();

        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }
        //    finally
        //    {
        //        dbFactory.CloseConnection(objConn, null, null);
        //    }
        //}

        public String SaveBraketInfo(PrintinfoM objPrintM)
        {
            try
            {
                using (var client = new HttpClient()) //WebClient  
                {
                    Uri baseAddress = new Uri(SystemController.HTTP_PATH);

                    client.BaseAddress = baseAddress;

                    HttpResponseMessage response = client.PostAsJsonAsync("WIP/PrintInfo/SaveBraketInfo", objPrintM).Result;

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

        public String GetJigsawResult(String Jigsaw)
        {
            using (var client = new WebClient()) //WebClient  
            {
                client.Headers.Add("Content-Type:application/json"); //Content-Type  
                client.Headers.Add("Accept:application/json");

                var result = client.DownloadString(SystemController.HTTP_PATH + "wip/jobinfo/GetJigsawResult?Jigsaw=" + Jigsaw); //URI  

                return result;
                //Console.WriteLine(Environment.NewLine + result);

            }

        }

        public String GetJigsawResult1(int FixtureID)
        {
            using (var client = new WebClient()) //WebClient  
            {
                client.Headers.Add("Content-Type:application/json"); //Content-Type  
                client.Headers.Add("Accept:application/json");

                var result = client.DownloadString(SystemController.HTTP_PATH + "wip/jobinfo/GetJigsawResult1?FixtureID=" + FixtureID); //URI  

                return result;
                //Console.WriteLine(Environment.NewLine + result);

            }

        }
    }
}
