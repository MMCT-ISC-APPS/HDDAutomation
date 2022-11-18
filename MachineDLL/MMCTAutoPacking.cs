using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MachineDLL.DAO;
using MachineDLL.Common;
using MachineDLL.Entities;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Data;
using System.Drawing.Printing;
using System.IO;

namespace MachineDLL
{
    public class MMCTAutoPacking : UtilityDll
    {
        private bool bOffline = false;
        private BundleInfoM objBundleInfo = null;
        private bool _dllReady = false;
        private bool IsComplete = false;
        private bool boolSpecialPack = false;
        int iMode = 0;
        private bool bNone2D = false;
        private bool bBraket2D = false;
        private Int64 Pack2DOk = 0;
        private Int64 Pack2DNG = 0;
        private Int64 iTotalCount = 0;
        private int[] ArrCnt;
        private bool bHTS = false;

        public MMCTAutoPacking(Boolean Offline)
        {
            bOffline = Offline;
        }

        public MMCTAutoPacking(Boolean Offline, Boolean None2D)
        {
            bOffline = Offline;
            bNone2D = None2D;

        }

        // Mode 0 = Normal Packing
        // Model 1 = SI Bundle
        public MMCTAutoPacking(Boolean Offline, int Mode, bool HTS)
        {
            bOffline = Offline;
            iMode = Mode;
            bHTS = HTS;
            if (objBundleInfo != null)
            {
                objBundleInfo = null;
                objBundleInfo = new BundleInfoM();
            } 
        }

        public String[] GetSIBundleDetail(String SIBundle, String EN)
        {
            string[] Arr = new string[14];
            DataTable dt;
            BundleDAO objBundleDAO = new BundleDAO();
            BundleInfoM objBundleM = new BundleInfoM();
            JobinfoM objJobM;
            try
            {
                if (iMode == 0)
                {
                    throw new Exception("ไม่สามารถใช้ function นี้ได้เนื่องจาก ไม่ได้เลือก Mode ที่เป็น SI");
                }

                if (objBundleInfo == null)
                {
                    objBundleInfo = new BundleInfoM();
                }

                if (bOffline == true)
                {
                    Arr[0] = "OK";
                    Arr[1] = "H201400001";
                    Arr[2] = "NT0xxxx";
                    Arr[3] = "200";
                    Arr[4] = "jobname1";
                    Arr[5] = "400";
                    Arr[6] = "jobname2";
                    Arr[7] = "250";
                }
                else
                {
                    if (objBundleInfo.JobBuildInfo != null)
                    {
                        if (objBundleInfo.JobBuildInfo.Count == 5)
                        {
                            throw new Exception("Error: Jobbuild can not be added more than 5 Jobs!");
                        }
                    }
                    else
                    {
                        objBundleInfo.JobBuildInfo = new List<JobinfoM>();
                    }

                    objBundleM.SIBundle = SIBundle;
                    objBundleM.En = EN;

                    dt = objBundleDAO.GetSIBundleDetail(objBundleM);

                    int j = 5;
                    Arr[0] = "OK";
                    Arr[1] = dt.Rows[0]["oracle_bundle"].ToString();
                    Arr[2] = dt.Rows[0]["model"].ToString();
                    Arr[3] = dt.Rows[0]["stdsize"].ToString();
                    Arr[4] = dt.Rows.Count.ToString();

                    objBundleInfo.BundleNo = dt.Rows[0]["oracle_bundle"].ToString();
                    objBundleInfo.StandardSize = Convert.ToInt16(dt.Rows[0]["stdsize"].ToString());

                    if (objBundleInfo.JobBuildInfo.Count > 1)
                    {
                        for (int i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            objJobM = objBundleInfo.JobBuildInfo[i];

                            if (objJobM.JobName == dt.Rows[i]["job_name"].ToString())
                            {
                                throw new Exception("Error : Duplicate job build");
                            }
                        }
                    }

                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        objJobM = new JobinfoM();

                        Arr[j] = dt.Rows[i]["job_name"].ToString();

                        objJobM.JobName = Arr[j];
                        j = j + 1;
                        Arr[j] = dt.Rows[i]["qty"].ToString();
                        objJobM.JobQty = Convert.ToInt16(Arr[j]);
                        j = j + 1;
                        objBundleInfo.JobBuildInfo.Add(objJobM);

                        objJobM = null;

                    }

                    objBundleInfo.MachineName = GetComputerName();
                    objBundleInfo.InventoryItemID = Convert.ToInt64 (dt.Rows[0]["InventoryItemID"].ToString());
                    objBundleInfo.TotalJob = objBundleInfo.JobBuildInfo.Count;
                    objBundleInfo.PrimaryUOM = dt.Rows[0]["primaryuom"].ToString();

                    //StartRead2D(objBundleInfo.StandardSize, "en", objBundleInfo.MachineName, 60);

                }

            }
            catch (Exception ex)
            {
                Arr[0] = ex.Message;
            }

            _dllReady = false;
            return Arr;
        }
        public bool Braket2D
        {
            get { return this.bBraket2D; }
            set { this.bBraket2D = value; }
        }

        //public MMCTAutoPacking(Boolean Offline, Boolean None2D , )
        //{
        //    bOffline = Offline;
        //    bNone2D = None2D;
        //}


        public string[] DllReady()
        {
            string[] Arr = new string[2];

            Arr[0] = "OK";
            if (_dllReady == true)
            {
                Arr[1] = "OK";
            }
            else {
                Arr[1] = "NotOK";
            }

            return Arr;
        }

        public String StartRead2D(Int64 PackQty, String TesterNo, String En, Int64 TraySize)
        {
            ArrCnt = new int[4];
            BundleDAO objBundle = new BundleDAO();

            try
            {
                for (int i = 0; i < 4; i++)
                {
                    ArrCnt[i] = 0;
                }

                IsComplete = false;

                if (bOffline == false)
                {
                    if (PackQty > objBundleInfo.StandardSize)
                    {
                        throw new Exception("Error : Qty greater than standard packsize!!!");
                    }

                    Int64  iTotal = 0; 

                    for (int i = 0; i <= objBundleInfo.JobBuildInfo.Count - 1; i++)
                    {
                        if (iTotal == 0)
                        {
                            iTotal = objBundleInfo.JobBuildInfo[i].JobQty;
                        }
                        else {
                            iTotal = iTotal + objBundleInfo.JobBuildInfo[i].JobQty;
                        }                       
                    }

                    if (PackQty > iTotal)
                    {
                        throw new Exception("Error : Qty greater than job pack on hand!!!");
                    }

                    if (TesterNo == "" || En == "")
                    {
                        throw new Exception("Error : Information not complete (EN Code)");
                    }
                }

                objBundleInfo.MachineName = TesterNo;
                objBundleInfo.En = En;
                objBundleInfo.Traysize = TraySize;
                objBundleInfo.PackCounter = 0;
                objBundleInfo.TotalQty = PackQty;

                // Clear Temp auto packing
                objBundle.CancelPack(objBundleInfo);

                Pack2DNG = 0;
                Pack2DOk = 0;
                iTotalCount = 0;

                return "OK";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public String[] IsValidJobBuild(String JobName)
        {
            JobInfoDAO objJobDAO = new JobInfoDAO();
            BundleDAO objBundleDAO = new BundleDAO();

            JobinfoM objJobM = null;
            String[] str = new String[4];

            try
            {
                if (objBundleInfo != null)
                {
                    if (objBundleInfo.JobBuildInfo != null)
                    {
                        if (objBundleInfo.JobBuildInfo.Count == 5)
                        {
                            throw new Exception("Error: Jobbuild can not be added more than 5 Jobs!");
                        }

                        for (int i = 0; i <= objBundleInfo.JobBuildInfo.Count - 1; i++)
                        {
                            if (objBundleInfo.JobBuildInfo[i].JobName == JobName)
                            {
                                throw new Exception("Error : Duplicate job build");
                            }
                        }

                    }
                }

                objJobM = objJobDAO.getJobinfo(JobName);

                objJobM = objJobDAO.ValidateJobBuild(objJobM);

                if (objJobM.OnhandQty <= 0)
                {
                    throw new Exception("Error : Oracle Onhand ไม่พอสำหรับการ Pack (" + objJobM.OnhandQty + ")");
                }

                //objJobM = objJobDAO.GetAvailableQty(objJobM);

                if (objBundleInfo == null)
                {
                    objBundleInfo = new BundleInfoM();

                    if (bHTS == true)
                    {
                        objBundleInfo.PrefixCustomer = "HTS";
                    }   
                    
                    objBundleInfo = objBundleDAO.getBundleNo(objBundleInfo);

                }

                if (objBundleInfo.JobBuildInfo != null)
                {
                    if (objBundleInfo.JobBuildInfo.Count > 0)
                    {
                        for (int i = 0; i <= objBundleInfo.JobBuildInfo.Count - 1; i++)
                        {
                            if (objBundleInfo.JobBuildInfo[i].ModelName != objJobM.ModelName)
                            {
                                throw new Exception("Error : Mix Model");
                            }
                        }
                    }
                }
                else {
                    objBundleInfo.JobBuildInfo = new List<JobinfoM>();
                }
                objBundleInfo.MachineName = GetComputerName();
                objBundleInfo.JobBuildInfo.Add(objJobM);
                objBundleInfo.InventoryItemID = objJobM.InventoryItemID;
                objBundleInfo.TotalJob = objBundleInfo.JobBuildInfo.Count;
                objBundleInfo.StandardSize = objJobM.StandardPackSize;
                objBundleInfo.PrimaryUOM = objJobM.PrimaryUOM;

                str[0] = "OK";
                str[1] = objJobM.ModelName;
                str[2] = objBundleInfo.TotalJob.ToString();
                str[3] = objJobM.OnhandQty.ToString();

                objJobM = null;

            }
            catch (Exception ex)
            {
                str[0] = ex.Message;
            }

            _dllReady = false;
            return str;
        }

        public String[] IsValidJob(String JobName)
        {
            JobInfoDAO objJobDAO = new JobInfoDAO();
            BundleDAO objBundleDAO = new BundleDAO();

            JobinfoM objJobM = null;
            String[] str = new String[4];

            try
            {
                if (iMode == 1)
                {
                    throw new Exception("ไม่สามารถใช้ function นี้ได้เนื่องจาก ไม่ได้เลือก Mode ที่เป็นปรกติ");
                }

                if (objBundleInfo == null)
                {
                    objBundleInfo = new BundleInfoM();
                }

                if (bOffline == true)
                {
                    str[0] = "OK";
                    str[1] = "NT0xxxx";
                    str[2] = "1";
                    str[3] = "400";
                }
                else
                {
                    if (objBundleInfo != null)
                    {
                        if (objBundleInfo.JobBuildInfo != null)
                        {
                            if (objBundleInfo.JobBuildInfo.Count == 5)
                            {
                                throw new Exception("Error: Jobbuild can not be added more than 5 Jobs!");
                            }

                            for (int i = 0; i <= objBundleInfo.JobBuildInfo.Count - 1; i++)
                            {
                                if (objBundleInfo.JobBuildInfo[i].JobName == JobName)
                                {
                                    throw new Exception("Error : Duplicate job build");
                                }
                            }
                        }
                    }

                    objJobM = objJobDAO.getJobinfo(JobName);

                    objJobM = objJobDAO.ValidateJobBuild(objJobM);

                    if (objJobM.OnhandQty <= 0)
                    {
                        throw new Exception("Error : Oracle Onhand ไม่พอสำหรับการ Pack (" + objJobM.OnhandQty + ")");
                    }


                    //objJobM = objJobDAO.GetAvailableQty(objJobM);

                    if (objBundleInfo == null)
                    {
                        objBundleInfo = new BundleInfoM();

                        objBundleInfo.PrefixCustomer = objJobM.PrefixCust;

                        //objBundleInfo = objBundleDAO.getBundleNo(objBundleInfo);

                    }

                    if (objBundleInfo.JobBuildInfo != null)
                    {
                        if (objBundleInfo.JobBuildInfo.Count > 0)
                        {
                            for (int i = 0; i <= objBundleInfo.JobBuildInfo.Count - 1; i++)
                            {
                                if (objBundleInfo.JobBuildInfo[i].ModelName != objJobM.ModelName)
                                {
                                    throw new Exception("Error : Mix Model");
                                }
                            }
                        }
                    }
                    else
                    {
                        objBundleInfo.JobBuildInfo = new List<JobinfoM>();
                    }

                    objBundleInfo.JobBuildInfo.Add(objJobM);
                    objBundleInfo.MachineName = GetComputerName();
                    objBundleInfo.InventoryItemID = objJobM.InventoryItemID;
                    objBundleInfo.TotalJob = objBundleInfo.JobBuildInfo.Count;
                    objBundleInfo.StandardSize = objJobM.StandardPackSize;                    
                    objBundleInfo.PrimaryUOM = objJobM.PrimaryUOM;

                    str[0] = "OK";
                    str[1] = objJobM.ModelName;
                    str[2] = objBundleInfo.TotalJob.ToString();
                    str[3] = objJobM.OnhandQty.ToString();

                    objJobM = null;
                }



            }
            catch (Exception ex)
            {
                str[0] = ex.Message;
            }

            _dllReady = false;
            return str;
        }

        public List<String> getStampCancelType()
        {
            BoxInfoDAO objBoxDAO = new BoxInfoDAO();

            try
            {
                return objBoxDAO.getStampcancelType();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                objBoxDAO = null;
            }
        }

        public List<String> getScanType()
        {
            BoxInfoDAO objBoxDAO = new BoxInfoDAO();

            try
            {
                return objBoxDAO.getScanType();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                objBoxDAO = null;
            }
        }

        public String GetBundleNo()
        {
            if (bOffline == true)
            {
                return "H202000001";
            }
            else
            {
                return objBundleInfo.BundleNo;
            }

        }

        public String[] Validated2d(String[] arr)
        {
            String[] str = new String[objBundleInfo.Traysize + 1];
            PrintinfoM objPrintinfo = null;
            BundleDAO objBundle = new BundleDAO();
            PrintinfoDAO objPrintinfoDAO = new PrintinfoDAO();

            try
            {

                //File.Create(@"d:\temp.txt");
                

                //Console.ReadLine();
                StreamWriter streamWriter = new StreamWriter(@"d:\temp.txt");

                using (streamWriter)
                {
                    for (int i = 0; i <= arr.Length-1; i++)
                {                   
                    streamWriter.WriteLine(arr[i]);                 
                }
                    streamWriter.WriteLine("array:" + arr.Length );
                    streamWriter.WriteLine("tray:" + objBundleInfo.Traysize);

                    streamWriter.Flush();
                    streamWriter.Close();
                }
                
                if (arr.Length != objBundleInfo.Traysize)
                {
                    throw new Exception("จำนวน 2D ไม่ตรงกับ tray ที่กำหนดใน StartJob function");
                }

                str[0] = "OK";

                if (bOffline == true)
                {
                    for (int i = 0; i <= objBundleInfo.Traysize - 1; i++)
                    {
                        str[i + 1] = "OK";
                    }
                }
                else
                {
                    if (bHTS == true)
                    {
                        objBundleInfo.PrefixCustomer = "HTS"; 
                        //bool bresult = true;
                        DataTable dt = new DataTable();
                        dt.Columns.Add();
                        dt.Columns.Add(); 

                        objBundleInfo.Serials  = null;
                        objBundleInfo.Serials = new List<PrintinfoM>();

                        for (int i = 0; i <= objBundleInfo.Traysize - 1; i++)
                        {
                            objPrintinfo = new PrintinfoM();
                            if(arr[i].IndexOf(':') > 0)
                            {
                                String[] sResult = arr[i].Split(':');

                                objPrintinfo.Serialno = sResult[0];
                                objPrintinfo.Result = "";
                                objPrintinfo.ScanGrade = sResult[1];
                                objPrintinfoDAO.UpScanGradePrintInfo(sResult[0], sResult[1]);// 2021-05-04  ISC Request ISC-21-00455 Request display 2D grade in trace back ability database
                                dt.Rows.Add(sResult[0], sResult[1]); 
                            }
                            else{
                                objPrintinfo.Serialno = arr[i];
                                objPrintinfo.Result = "";
                                objPrintinfo.ScanGrade = "";
                                dt.Rows.Add(arr[i], "");
                            }                           

                            objBundleInfo.Serials.Add(objPrintinfo);

                            objPrintinfo = null;

                        }

                        // Start modify check Duplicate serial in tray
                        var duplicates = dt.AsEnumerable().GroupBy(r => r[0]).Where(gr => gr.Count() > 1).ToList();
                        if (duplicates.Any())
                        {
                            //Console.WriteLine("Duplicate serial in tray: {0}", String.Join(", ", duplicates.Select(dupl => dupl.Key)));
                            string strError = String.Join(", ", duplicates.Select(dupl => dupl.Key));
                            str[0] = "ERROR.";
                            for (int z = 0; z <= objBundleInfo.Traysize - 1; z++)
                            {
                                if (arr[z].IndexOf(':') > 0)
                                {
                                    String[] sResult = arr[z].Split(':');

                                    if (strError.Contains(sResult[0]))
                                    {
                                        str[z + 1] = "Duplicate serial in tray :"+ sResult[0];
                                        
                                    }
                                    else
                                    {
                                        str[z + 1] = "OK";
                                    }
                                       
                                }
                                else
                                { 
                                    if (strError.Contains(arr[z]))
                                    {
                                        str[z + 1] = "Duplicate serial in tray :" + arr[z];
                                         
                                    }
                                    else
                                    {
                                        str[z + 1] = "OK";
                                    }
                                }                            
                                 
                            }
                            //throw new Exception("Duplicate serial in tray: "+ String.Join(", ", duplicates.Select(dupl => dupl.Key)));
                        }else
                        {
                            objBundleInfo = objBundle.Validate2D(objBundleInfo);
                            //objBundleInfo = objBundle.Validate2D(objBundleInfo);

                            bool bresult = true;
                            for (int j = 0; j <= objBundleInfo.Serials.Count - 1; j++)
                            {
                                objPrintinfo = objBundleInfo.Serials[j];
                                str[j + 1] = objPrintinfo.Result;

                                if (objPrintinfo.Result != "OK")
                                {
                                    bresult = false;
                                }

                                objPrintinfo = null;
                            }

                            if (bresult == false)
                            {
                                str[0] = "ERROR.";
                            }
                            else
                            {
                                int iTotal;
                                iTotal = Convert.ToInt16(GetJobCounterFromTempTable(objBundleInfo.BundleNo));

                                if (objBundleInfo.TotalQty == iTotal)
                                {
                                    str[0] = "COMPLETED";
                                }
                                else
                                {
                                    str[0] = "OK";
                                }
                            }
                        }
                        // End modify check Duplicate serial in tray 
                    }
                }           

            }
            catch (Exception ex)
            {
                str[0] = ex.Message;
            }

            return str;

        }
        public String[] Validated2dManual(String[] arr)
        {
            String[] str = new String[objBundleInfo.Traysize + 1];
            PrintinfoM objPrintinfo = null;
            BundleDAO objBundle = new BundleDAO();
            PrintinfoDAO objPrintinfoDAO = new PrintinfoDAO();

            try
            {

                //File.Create(@"d:\temp.txt");

                StreamWriter streamWriter = new StreamWriter(@"d:\temp.txt");

                using (streamWriter)
                {
                    for (int i = 0; i <= arr.Length - 1; i++)
                    {
                        streamWriter.WriteLine(arr[i]);
                    }
                    streamWriter.WriteLine("array:" + arr.Length);
                    streamWriter.WriteLine("tray:" + objBundleInfo.Traysize);

                    streamWriter.Flush();
                    streamWriter.Close();
                }

                //if (arr.Length != objBundleInfo.Traysize)
                //{
                //    throw new Exception("จำนวน 2D ไม่ตรงกับ tray ที่กำหนดใน StartJob function");
                //}

                str[0] = "OK";

                if (bOffline == true)
                {
                    for (int i = 0; i <= objBundleInfo.Traysize - 1; i++)
                    {
                        str[i + 1] = "OK";
                    }
                }
                else
                {
                    if (bHTS == true)
                    {
                        objBundleInfo.PrefixCustomer = "HTS";

                        objBundleInfo.Serials = null;
                        objBundleInfo.Serials = new List<PrintinfoM>();
                        objBundleInfo.Traysize = 1;

                        for (int i = 0; i <= objBundleInfo.Traysize - 1; i++)
                        {
                            objPrintinfo = new PrintinfoM();
                            if (arr[i].IndexOf(':') > 0)
                            {
                                String[] sResult = arr[i].Split(':');

                                objPrintinfo.Serialno = sResult[0];
                                objPrintinfo.Result = "";
                                objPrintinfo.ScanGrade = sResult[1];
                                objPrintinfoDAO.UpScanGradePrintInfo(sResult[0], sResult[1]);// 2021-05-04  ISC Request ISC-21-00455 Request display 2D grade in trace back ability database
                            }
                            else
                            {
                                objPrintinfo.Serialno = arr[i];
                                objPrintinfo.Result = "";
                                objPrintinfo.ScanGrade = "";
                            }



                            objBundleInfo.Serials.Add(objPrintinfo);

                            objPrintinfo = null;

                        }

                        objBundleInfo = objBundle.Validate2D(objBundleInfo);

                        bool bresult = true;

                        for (int j = 0; j <= objBundleInfo.Serials.Count - 1; j++)
                        {
                            objPrintinfo = objBundleInfo.Serials[j];
                            str[j + 1] = objPrintinfo.Result;

                            if (objPrintinfo.Result != "OK")
                            {
                                bresult = false;
                                str[0] = objPrintinfo.Result.ToString();
                            }

                            objPrintinfo = null;
                        }

                        if (bresult == false)
                        {
                            str[0] = "ERROR :"+ str[0];
                        }
                        else
                        {
                            int iTotal;
                            iTotal = Convert.ToInt16(GetJobCounterFromTempTable(objBundleInfo.BundleNo));

                            if (objBundleInfo.TotalQty == iTotal)
                            {
                                str[0] = "COMPLETED";
                            }
                            else
                            {
                                str[0] = "OK";
                            }

                        }


                    }
                }

            }
            catch (Exception ex)
            {
                str[0] = ex.Message;
            }

            return str;

        }

        public Int64  PackingSize()
        {
            return objBundleInfo.StandardSize ;
        }

        public String ValidatedAISkipProcess(String sPanelNo  , int GoodQty , int NGQty)
        {
            PrintinfoM objPrintM = new PrintinfoM();
            BundleDAO objBundle = new BundleDAO();

            try
            {
                // objPrintM.Serialno = sPanelNo;
                objBundleInfo.TempSerialno = sPanelNo;
                objBundleInfo.GoodQty = GoodQty;
                objBundleInfo.NGQty = NGQty;
               

                return objBundle.ValidatedAISkipProcess(objBundleInfo);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                objPrintM = null;
                objBundle = null;
            }
        }

        public String GetJobCounterFromTempTable(String BundleNo)
        {            
            BundleDAO objBundle = new BundleDAO();
            BundleInfoM bundleInfoM = new BundleInfoM();

            try
            {

                bundleInfoM.BundleNo = BundleNo;

                if (bHTS == true)
                {
                    bundleInfoM.PrefixCustomer = "HTS";
                }

                return objBundle.GetJobCounterFromTempTable (bundleInfoM);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {              
                objBundle = null;
            }
        }

        public String Add2DTempAutopack(BundleInfoM objBundleM)
        {
            BundleDAO objBundle = new BundleDAO();

            try
            {
                return objBundle.Add2DTempAutopack(objBundleM);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                objBundle = null;
            }
        }

        public string[] GetTotalQty()
        {
            BundleDAO objBundleDAO = new DAO.BundleDAO();
            try
            {
                string[] Arr = new string[8];
                Arr[0] = "OK";
                int i;
                for (i = 1; i <= 6; i++)
                {
                    Arr[i + 1] = "0";
                }

                Arr[1] = objBundleInfo.PackCounter.ToString();
                
                for (i = 1; i <= objBundleInfo.JobBuildInfo.Count; i++)
                {
                    Arr[i + 1] = objBundleDAO.GetJobCounterFromTempTable(objBundleInfo);
                    objBundleInfo.TotalQty = Convert.ToInt16(Arr[i + 1]);
                }

                return Arr;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            
            // 'For i = 1 To JobPackData.JobBuild.Count
            // '    Arr(i + 1) = JobPackData.JobBuild(i).ListScan2D.Count
            // 'Next
           
        }

        public String[] GetBundleNo(String sPrefixCust)
        {
            //BundleInfoM objBundle = new BundleInfoM();
            BundleDAO objBundleDAO = new BundleDAO();
            String[] str = new String[2];

            try
            {

                objBundleInfo.PrefixCustomer = sPrefixCust;
                objBundleInfo = objBundleDAO.getBundleNo(objBundleInfo);                               
                str[0] = objBundleInfo.BundleNo;
                str[1] = "0";

                objBundleInfo.BundleNo = objBundleInfo.BundleNo;

                return str;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {                
                objBundleDAO = null;
            }
        }

        public string CompletePacking(Int64 TotalQty, int GoodQty, int NGQty, Int64 StandardSizeAdjust)
        {
            string[] Arr = new string[2];
            PrintDocument pd = new PrintDocument();
            BundleDAO objBundle = new BundleDAO();
            int iTotalQty = 0;

            // Dim ArrJob() As String = Split(JobBuildInfo, ",")
            try
            {
                if (bOffline == true)
                {
                    if (IsComplete == true)
                        Arr[0] = "OK";
                }
                else
                {
                    Arr[0] = "OK";
                    objBundleInfo.TotalQty = 0;
                    //iTotalQty = GoodQty + NGQty;
                    iTotalQty = GoodQty;

                    int i;

                    if (objBundleInfo.PrefixCustomer == "PA")
                    {
                        iTotalQty = GoodQty + NGQty;

                        if (iTotalQty != objBundleInfo.StandardSize)
                        {
                            if (StandardSizeAdjust > 0 ){
                                if (iTotalQty != StandardSizeAdjust)
                                {
                                    throw new Exception("จำนวนที่ใส่ :"+ iTotalQty+" กับ Adjust Standard pack :"+ StandardSizeAdjust+" ไม่ตรงกันโปรดตรจสอบใหม่อีกครั้ง");
                                }
                                else
                                {
                                    objBundleInfo.TotalQty = iTotalQty;
                                }
                            }
                            else
                            {
                                throw new Exception("จำนวนที่ใส่ กับ Standard pack ไม่ตรงกันโปรดตรจสอบใหม่อีกครั้ง");
                            }
                            
                        }
                        else
                        {
                            objBundleInfo.TotalQty = iTotalQty;
                        }

                    }
                    else
                    {
                        for (i = 1; i <= objBundleInfo.JobBuildInfo.Count; i++)
                        {
                            if (objBundleInfo.JobBuildInfo.Count > 0)
                            {
                                objBundleInfo.TotalJob = objBundleInfo.TotalJob + 1;
                                objBundleInfo.TotalQty = iTotalQty;
                                //objBundleInfo.TotalQty = objBundleInfo.JobBuildInfo[i].Serials.Count ;
                                // JobPackData.TotalQty = objBundleInfo.TotalQty + objBundleInfo.JobBuild(i).TotalQty;
                            }
                        }

                    }

                    for (i = 1; i <= objBundleInfo.JobBuildInfo.Count; i++)
                    {
                        if (objBundleInfo.JobBuildInfo.Count > 0)
                        {
                            objBundleInfo.TotalJob = objBundleInfo.TotalJob;
                            //objBundleInfo.TotalQty = objBundleInfo.TotalQty + objBundleInfo.JobBuildInfo[i].TotalQty;
                            objBundleInfo.TotalQty = iTotalQty;
                            //objBundleInfo.TotalQty = objBundleInfo.JobBuildInfo[i].Serials.Count ;
                            // JobPackData.TotalQty = objBundleInfo.TotalQty + objBundleInfo.JobBuild(i).TotalQty;
                        }
                    }

                    objBundleInfo.TotalQty = iTotalQty;

                    objBundleInfo = objBundle.GetSummarizeJobQtyByBundle(objBundleInfo);

                    objBundleInfo.UserName = "SUP-AS2-11";
                    objBundleInfo.PrintCopy = 1;
                    objBundleInfo.PrinterName = pd.PrinterSettings.PrinterName;
                    //objBundleInfo.PrinterName = "SATONTK3";

                    //bool isCompleteOK = objBundle.CompletePackNone2D (objBundleInfo);
                    bool isCompleteOK = objBundle.CompletePackNone2D(objBundleInfo);

                    if (isCompleteOK)
                    {
                        try
                        {
                            Arr[0] = "OK";
                        }
                        catch (Exception e)
                        {
                            Arr[0] = "Error " + e.Message;
                        }
                    }
                    else
                        Arr[0] = "Error";
                }

                return Arr[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string CompletePacking(Int64 TotalQty , int GoodQty , int NGQty )
        {
            string[] Arr = new string[2];
            PrintDocument pd = new PrintDocument();
            BundleDAO objBundle = new BundleDAO();
            int iTotalQty = 0;

            // Dim ArrJob() As String = Split(JobBuildInfo, ",")
            try
            {
                if (bOffline  == true)
                {
                    if (IsComplete == true)
                        Arr[0] = "OK";
                }
                else
                {                
                    Arr[0] = "OK";                   
                    objBundleInfo.TotalQty = 0;
                    //iTotalQty = GoodQty + NGQty;
                    iTotalQty = GoodQty ;

                    int i;
                    
                    if (objBundleInfo.PrefixCustomer == "PA")
                    {        
                        iTotalQty = GoodQty + NGQty;

                        if (iTotalQty != objBundleInfo.StandardSize)
                        {
                            throw new Exception("จำนวนที่ใส่ กับ Standard pack ไม่ตรงกันโปรดตรจสอบใหม่อีกครั้ง");
                        }
                        else
                        {
                            objBundleInfo.TotalQty = iTotalQty;
                        }

                    }
                    else
                    {
                        for (i = 1; i <= objBundleInfo.JobBuildInfo.Count; i++)
                        {
                            if (objBundleInfo.JobBuildInfo.Count > 0)
                            {
                                objBundleInfo.TotalJob = objBundleInfo.TotalJob + 1;
                                objBundleInfo.TotalQty = iTotalQty;
                                //objBundleInfo.TotalQty = objBundleInfo.JobBuildInfo[i].Serials.Count ;
                                // JobPackData.TotalQty = objBundleInfo.TotalQty + objBundleInfo.JobBuild(i).TotalQty;
                            }
                        }

                    }

                    for (i = 1; i <= objBundleInfo.JobBuildInfo.Count; i++)
                    {
                        if (objBundleInfo.JobBuildInfo.Count > 0)
                        {
                            objBundleInfo.TotalJob = objBundleInfo.TotalJob;
                            //objBundleInfo.TotalQty = objBundleInfo.TotalQty + objBundleInfo.JobBuildInfo[i].TotalQty;
                            objBundleInfo.TotalQty = iTotalQty;
                            //objBundleInfo.TotalQty = objBundleInfo.JobBuildInfo[i].Serials.Count ;
                            // JobPackData.TotalQty = objBundleInfo.TotalQty + objBundleInfo.JobBuild(i).TotalQty;
                        }
                    }

                        objBundleInfo.TotalQty = iTotalQty;

                    objBundleInfo = objBundle.GetSummarizeJobQtyByBundle(objBundleInfo);

                    objBundleInfo.UserName = "SUP-AS2-11";
                    objBundleInfo.PrintCopy = 1;
                    objBundleInfo.PrinterName = pd.PrinterSettings.PrinterName;
                    //objBundleInfo.PrinterName = "SATONTK3";

                    //bool isCompleteOK = objBundle.CompletePackNone2D (objBundleInfo);
                    bool isCompleteOK = objBundle.CompletePackNone2D (objBundleInfo);

                    if (isCompleteOK)
                    {
                        try
                        {
                            Arr[0] = "OK";
                        }
                        catch (Exception e)
                        {
                            Arr[0] = "Error " + e.Message;
                        }
                    }
                    else
                        Arr[0] = "Error";
                }

                return Arr[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        //public string CompletePacking()
        //{
        //    string[] Arr = new string[2];
        //    PrintDocument pd = new PrintDocument();
        //    BundleDAO objBundle = new BundleDAO();
        //    int iTotalQty = 0;
            
        //    try
        //    {
        //        if (bOffline == true)
        //        {
        //            if (IsComplete == true)
        //                Arr[0] = "OK";
        //        }
        //        else
        //        {
        //            Arr[0] = "OK";
        //            objBundleInfo.TotalQty = 0;

        //            iTotalQty = Convert.ToInt16 (GetJobCounterFromTempTable(objBundleInfo.BundleNo));
        //            int i;

                  
        //            for (i = 1; i <= objBundleInfo.JobBuildInfo.Count; i++)
        //            {
        //                if (objBundleInfo.JobBuildInfo.Count > 0)
        //                {
        //                    objBundleInfo.TotalJob = objBundleInfo.TotalJob;
        //                    objBundleInfo.TotalQty = iTotalQty;
        //                }
        //            }
                                     

        //            //objBundleInfo.TotalQty = iTotalQty;

        //            objBundleInfo = objBundle.GetSummarizeJobQtyByBundle(objBundleInfo);

        //            objBundleInfo.UserName = "SUP-AS2-11";
        //            objBundleInfo.PrintCopy = 1;
        //            objBundleInfo.PrinterName = pd.PrinterSettings.PrinterName;
        //            //objBundleInfo.PrinterName = "ISC3";

        //            //bool isCompleteOK = objBundle.CompletePackNone2D (objBundleInfo);
        //            bool isCompleteOK = objBundle.CompletedPacking(objBundleInfo);

        //            if (isCompleteOK)
        //            {
        //                try
        //                {
        //                    Arr[0] = "OK";                            
        //                }
        //                catch (Exception e)
        //                {
        //                    Arr[0] = "Error " + e.Message;
        //                }
        //            }
        //            else
        //                Arr[0] = "Error";
        //        }

        //        return Arr[0];
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }
        //}

        public string CompletePacking()
        {
            string[] Arr = new string[2];
            PrintDocument pd = new PrintDocument();
            BundleDAO objBundle = new BundleDAO();
            int iTotalQty = 0;

            try
            {
                if (bOffline == true)
                {
                    if (IsComplete == true)
                        Arr[0] = "OK";
                }
                else
                {
                    Arr[0] = "OK";
                    //objBundleInfo = new BundleInfoM();                    
                    objBundleInfo.TotalQty = 0;
                    
                    iTotalQty = Convert.ToInt16(GetJobCounterFromTempTable(objBundleInfo.BundleNo));

                    int i;

                    for (i = 1; i <= objBundleInfo.JobBuildInfo.Count; i++)
                    {
                        if (objBundleInfo.JobBuildInfo.Count > 0)
                        {
                            objBundleInfo.TotalJob = objBundleInfo.TotalJob;
                            objBundleInfo.TotalQty = iTotalQty;
                        }
                    }

                    objBundleInfo = objBundle.GetSummarizeJobQtyByBundle(objBundleInfo);

                    objBundleInfo.UserName = "SUP-AS2-11";
                    objBundleInfo.PrintCopy = 1;
                    objBundleInfo.PrinterName = pd.PrinterSettings.PrinterName;
                    //objBundleInfo.PrinterName = "SATONTK3";

                    bool isCompleteOK = objBundle.CompletePackNone2D (objBundleInfo);

                    //bool isCompleteOK;
                    //isCompleteOK = objBundle.ReprintHitashiBundle(objBundleInfo);

                    //isCompleteOK = objBundle.ReprintHitashiBundle(objBundleInfo);

                    //if (String.IsNullOrEmpty(objBundleInfo.SIBundle) == false)
                    //{
                    //    isCompleteOK = objBundle.ReprintHitashiBundle(objBundleInfo);
                    //}
                    //else
                    //{
                    //    isCompleteOK = objBundle.CompletePackNone2D(objBundleInfo);
                    //}

                    if (isCompleteOK)
                    {
                        try
                        {
                            Arr[0] = "OK";
                            
                        }
                        catch (Exception e)
                        {
                            Arr[0] = "Error " + e.Message;
                        }
                    }
                    else
                        Arr[0] = "Error";
                }

                return Arr[0];
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
