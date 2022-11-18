using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MachineDLL.DAO;
using MachineDLL.Common;
using MachineDLL.Entities;
using MachineDLL.Entities.Traceability;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using MachineDLL.Infrastructure;


namespace MachineDLL
{
    public class HSGTraceability : UtilityDll 
    {
        private bool bOffline;
        private JobinfoM objJobInfo = null;
        private bool bCompleted;

        public HSGTraceability(Boolean Offline)
        {
            bOffline = Offline;
            objJobInfo = new JobinfoM();
        }


        public void CopyJobFile()
        {
            try
            {
                String SourcePath = @"\\mmctsg2d\2Dsys\2DLOG\Mprint\FunctionTest\";
                String Destination = @"D:\temp_job\";

                DataTable dt = GetJob();

                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {

                    var files = new List<string>();

                    foreach (var file in Directory.EnumerateFiles(SourcePath).Where(m => m.Contains(dt.Rows[i][0].ToString())))
                    {
                        files.Add(file);
                    }

                    foreach (var subDir in Directory.EnumerateDirectories(SourcePath))
                    {
                        try
                        {
                            
                        }
                        catch (UnauthorizedAccessException ex)
                        {
                            // ...
                        }
                    }

                }


                /*foreach (String sFileName in Directory.GetFiles(SourcePath))
                {

                }*/
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private DataTable GetJob() {
            DBFactory dbFactory = new DBFactory();
            SqlConnection objConn = dbFactory.GetDBConnection();
            DataSet ds;
            DataTable dt;

            try
            {
              
                String sql = "select distinct jobname from temp_serial_fctwithjob";

                List<SqlParameter> sqlParamsIn = new List<SqlParameter>();


                ds = dbFactory.ExecuteQuerySQL (objConn, sql,null);

                dt = ds.Tables[0];
              

                return dt;

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
        public String ConnectDatabase(bool bSG2D)
        {
            try
            {
                if (bOffline == true)
                {
                    return "OK";
                }
                else
                {
                    Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    var result = socket.BeginConnect(SystemController.WSSERVER, 80, null, null);
                    bool success = result.AsyncWaitHandle.WaitOne(3000, false); // test the connection for 3 seconds
                    var resturnVal = socket.Connected;
                    if (socket.Connected)
                        socket.Disconnect(true);
                    socket.Dispose();

                    if (resturnVal == true)
                    {
                        UtilityDAO objUtility = new UtilityDAO();
                        objJobInfo = new JobinfoM();

                        return objUtility.ConnectDatabase(bSG2D);

                    }
                    else
                    {
                        return "Disconnect(Webservice)";
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public  JobBySerialsM  GetHSG2DLasermark(String sJobName , String sFileName) 
        {
            PrintinfoDAO objPrintDAO = new PrintinfoDAO();
            JobBySerialsM objJobInfoM = new JobBySerialsM();
            String jsonString;

            try
            {
                objJobInfoM.JobName = sJobName;
                objJobInfoM.MachineName = GetComputerName();

                objJobInfoM = objPrintDAO.GetHSG2DLasermark(objJobInfoM);

                jsonString = JsonConvert.SerializeObject(objJobInfoM);

                if (File.Exists(sFileName))
                {
                    File.Delete(sFileName);
                }

                //File.Create(sFileName);
                using (var tw = new StreamWriter(sFileName, true))
                {
                    tw.WriteLine(jsonString.ToString());
                    tw.Close();
                }

                return objJobInfoM;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public PrintinfoM GetPrintInfo(PrintinfoM objPrintM) //Get All Events Records  
        {
            PrintinfoDAO objPrintDAO = new PrintinfoDAO();

            try
            {

                objPrintM = objPrintDAO.GetPrintInfo(objPrintM);

                return objPrintM;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                objPrintDAO = null;
            }
        }

        
        public String[] getJobinfo(String sJobname, String sEn)
        {
            SystemUtility objSystem = new SystemUtility();
            JobInfoDAO objsync = new JobInfoDAO(true);

            JobinfoM objJob;
            String[] str = new string[13];

            String sMachineName = "";
            String sProgramVersion = "";

            try
            {
                sMachineName = objSystem.GetComputerName();
                sProgramVersion = objSystem.getApplicationPath();

                if (bOffline == true)
                {
                    str[0] = "CPN";
                    str[1] = sJobname;
                    str[2] = "480";
                    str[3] = "XXXXXXX";
                    str[4] = "NJXXXXXX";
                    str[5] = "1";
                    str[6] = "16";
                    str[7] = "30";
                    str[8] = "P";
                    str[9] = "LOT";
                    str[10] = "A";
                }
                else
                {
                    objJob = objsync.getJobinfo(sJobname);

                    str[0] = objJob.CPN;
                    str[1] = objJob.JobName;
                    str[2] = objJob.JobQty.ToString();
                    str[3] = objJob.Master2D;
                    str[4] = objJob.ModelName;
                    str[5] = objJob.PanelNo;
                    str[6] = objJob.PanelSize.ToString();
                    str[7] = objJob.Remain.ToString();
                    str[8] = objJob.Status;
                    str[9] = objJob.ICLot ;
                    str[10] = objJob.SubLot;
                    //str[11] = objJob.SubLots.Count.ToString ();

                    //String sSubLots = "";

                    //foreach (string sublot in objJob.SubLots.Keys )
                    //{
                    //    if (sSubLots == "")
                    //    {
                    //        sSubLots = sublot + " , " + objJob.SubLots[sublot];
                    //    }
                    //    else
                    //    {
                    //        sSubLots = sSubLots + ";" + sublot + " , " + objJob.SubLots[sublot];
                    //    }
                    //}

                    //str[12] = sSubLots;

                    //str[10] = objJob.SubLot;

                }

                objJobInfo.CPN = str[0];
                objJobInfo.JobName = str[1];
                objJobInfo.JobQty = Convert.ToInt64(str[2].ToString());
                objJobInfo.Master2D = str[3];
                objJobInfo.ModelName = str[4];
                objJobInfo.PanelNo = str[5];
                objJobInfo.PanelSize = Convert.ToInt64(str[6]);
                objJobInfo.Remain = Convert.ToInt64(str[7]);
                objJobInfo.Status = str[8];
                objJobInfo.En = sEn;
                objJobInfo.MachineName = sMachineName;
                objJobInfo.ProgramVersion = sProgramVersion;
                objJobInfo.SubLot = str[10];
                objJobInfo.ICLot = str[9];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                objsync = null;
                objSystem = null;
                objJob = null;
            }

            return str;

        }

       
        public String StartRead(String sJobName, Int64 JobSize, Int64 Remain, Int64 PanelSize)
        {
            try
            {
                JobInfoDAO objDAO = new JobInfoDAO();

                bCompleted = false;
                objJobInfo.JobName = sJobName;
                objJobInfo.Remain = Remain;
                //objDAO.StartRead(objJobInfo, Remain);
                return "OK";
                //return Generated2DHSG(sJobName, JobSize, Remain, PanelSize );
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public String[] get2DLabelsHSG(ref String PanelNo)
        {
            //objJobInfo.PanelSize = 1000;
            String[] str = new string[objJobInfo.PanelSize + 1];
            JobInfoDAO objJob = new JobInfoDAO();

            try
            {
                if (bOffline == true)
                {
                    str[0] = "29"; //Remain
                    str[1] = "B61208609399B3 100700761B";
                    str[2] = "B6120860A399B3 100700761B";
                    str[3] = "B6120860B399B3 100700761B";
                    str[4] = "B6120860C399B3 100700761B";
                    str[5] = "B6120860D399B3 100700761B";
                    str[6] = "B6120860E399B3 100700761B";
                    str[7] = "B6120860F399B3 100700761B";
                    str[8] = "B6120860G399B3 100700761B";
                    str[9] = "B6120860H399B3 100700761B";
                    str[10] = "B6120860J399B3 100700761B";
                    str[11] = "B6120860K399B3 100700761B";
                    str[12] = "B6120860L399B3 100700761B";
                    str[13] = "B6120860R399B3 100700761B";
                    str[14] = "B6120860S399B3 100700761B";
                    str[15] = "B6120860T399B3 100700761B";
                    str[16] = "B6120860U399B3 100700761B";
                }
                else
                {
                    IList<String> lstData =  objJob.get2DLabelsHSG(objJobInfo);
                    IList<PrintinfoM> objSerial = new List<PrintinfoM>();
                    PrintinfoDAO objPrintDAO = new PrintinfoDAO();

                    PrintinfoM objPrintinfo;

                    for (int i = 0; i <= lstData.Count - 1  ; i++)
                    {
                        objPrintinfo = new PrintinfoM();
                         
                        str[i] = lstData[i];
                        objPrintinfo.Serialno = lstData[i];

                        objSerial.Add(objPrintinfo);

                        objPrintinfo = null;

                    }

                    PanelNo = lstData[0];
                    objJobInfo.Serials = objSerial;          
                    PanelNo = lstData[0];
                    objJobInfo.Serials = objSerial;          
                         
                    //objPrintDAO.UpdateSerialno(objJobInfo);
                    //str[objJobInfo.PanelSize] = Convert.ToString(objJobInfo.Remain - 1);
                    return str;

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return str;
        }

        public String  ConfirmPrint()
        {
            PrintinfoDAO objPrintDAO = new PrintinfoDAO();

            try
            {
                return objPrintDAO.PrintUpdate(objJobInfo);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally {
                objPrintDAO = null;
            }
            
             
        }

        public String UpdateRemain()
        {
            JobInfoDAO objJobDAO = new JobInfoDAO();

            try
            {
                return objJobDAO.UpdateRemain(objJobInfo);
                //return objJobDAO.update.PrintUpdate(objJobInfo);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                objJobDAO = null;
            }
        }

        public String[] Verify2D(String[] Array2D , String[] ScanGrade)
        {
            String[] str = new string[Array2D.Length + 1];
            PrintinfoM objPrint;
            IList<PrintinfoM> objList = new List<PrintinfoM>();
            PrintinfoDAO objPrintDAO = new PrintinfoDAO();

            if (bOffline == true)
            {
                str[0] = "COMPLETED";
                str[1] = "OK";
                str[2] = "OK";
                str[3] = "OK";
                str[4] = "OK";
                str[5] = "OK";
                str[6] = "OK";
                str[7] = "OK";
                str[8] = "OK";
                str[9] = "OK";
                str[10] = "OK";
                str[11] = "OK";
                str[12] = "OK";
                str[13] = "OK";
                str[14] = "OK";
                str[15] = "OK";
                str[16] = "OK";

                bCompleted = true;

            }
            else
            {
                for (int i = 0; i <= Array2D.Length - 1; i++)
                {
                    objPrint = new PrintinfoM();

                    objPrint.Serialno = Array2D[i];
                    objPrint.ScanResult = "P";
                    objPrint.ScanGrade = ScanGrade[i];

                    objList.Add(objPrint);

                    objPrint = null;

                }

                objJobInfo.Serials = objList;

                objPrintDAO.ScanUpdate(objJobInfo);

                for (int j = 0; j <= Array2D.Length - 1; j++)
                {
                    if (Array2D[j] == "")
                    {
                        str[j] = "NG";
                    }
                    else {
                        str[j] = "OK";
                    }                    
                }
            }
            
            return str;

        }

        public JobBySerialsM Verify2D(JobBySerialsM objJobinfoM)
        {
            PrintinfoDAO objPrintDAO = new PrintinfoDAO();

            try
            {
                return objPrintDAO.Verify2D (objJobinfoM);                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                objPrintDAO = null;
            }
        }


        public String CompletedLaserMark()
        {
            if (bCompleted == false)
            {
                return "Verify ข้อมูลยังไม่ครบ Lot";
            }
            else
            {
                return "OK";
            }
        }

        private String Generated2DHSG(String sJobname, Int64 JobSize, Int64 Remain, Int64 PanelSize)
        {
            // Updated remain


            return "OK";
        }


    }
}
