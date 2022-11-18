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
using System.Threading;
using System.Globalization;
using MachineDLL.Logs;
using System.Text.RegularExpressions;

namespace MachineDLL
{
    public class HHGTraceability : UtilityDll 
    {
        private bool bOffline;
        private JobinfoM objJobInfo = null;
        private bool bCompleted;
        private int iTotalCavity = 0;
        private Int64  iJobQty = 0;
        private String  sCustiomer = "";
        private Boolean bHaveFixture = false;

        public HHGTraceability(Boolean Offline )
        {
            bOffline = Offline;
            objJobInfo = new JobinfoM();
        }

        public HHGTraceability()
        {            
            objJobInfo = new JobinfoM();
        }


        public HHGTraceability(String Customer , Boolean HaveFixture)
        {
            sCustiomer = Customer;
            bHaveFixture = HaveFixture;
        }

        //public String[] IsValid2D(String[] Array2D)
        //{

        //}

        public void SetTotalCavitybyPanel(int iCavity)
        {
            iTotalCavity = iCavity;
        }

        //public String[] GetSerials()
        //{
        //    DataTable dt;
        //    PanelInfoDAO objPanel = new DAO.PanelInfoDAO();
        //    String[] sTmp;

        //    try
        //    {

        //        sTmp = new String[objJobInfo.PanelSize];

        //        dt = objPanel.GetBraketSerialNo(objJobInfo);

        //        if (dt.Rows.Count == 0)
        //        {
        //            throw new Exception("หา Serials ของ jobname เบอร์นี้ไม่เจอ");
        //        }

        //        for (int i = 0; i <= objJobInfo.PanelSize - 1; i++)
        //        {
        //            sTmp[i] = dt.Rows[i]["serialno"].ToString();
        //            objPanel.UpdateBraketSerial(sTmp[i], objJobInfo.ComputerName);
        //        }

        //        return sTmp;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    finally
        //    {
        //        objPanel = null;
        //    }
        //}
        //String Jobname , int CavitySize 
        public String[] GetSerials()
        {
            PanelInfoDAO objPanel = new DAO.PanelInfoDAO();
            String[] sTmp;
            DataTable dt;

            try
            {

                LogHelper.Log(LogTarget.File, "******************Log Date: JobName:" + objJobInfo.JobName + "--" + DateTime.Now.ToString() + " **************************", objJobInfo.ComputerName );

                //objJobInfo.PanelSize = iTotalCavity;
                objJobInfo.PanelSize = 15;
                objJobInfo.PanelSize = objPanel.GetBraketPanelSizeByMachine(objJobInfo.ComputerName);
                sTmp = new String[objJobInfo.PanelSize];
               //sTmp = new String[CavitySize];

                //dt = objPanel.GetBraketSerialNo (objJobInfo);
                dt = objPanel.GetBraketSerialNo(objJobInfo);

                if (dt.Rows.Count == 0)
                {
                    throw new Exception("หา Serials ของ jobname เบอร์นี้ไม่เจอ jobname=" + objJobInfo.JobName +  "Panel Size:" + objJobInfo.PanelSize );
                }

                if (dt.Rows.Count != objJobInfo.PanelSize)
                {
                    throw new Exception("จำนวน Serials ที่ Gen ไม่เท่ากับที่ระบุ " + dt.Rows.Count);
                }

                for (int i = 0; i <= objJobInfo.PanelSize - 1; i++)
                {
                    sTmp[i] = dt.Rows[i]["serialno"].ToString();
                    LogHelper.Log(LogTarget.File, sTmp[i], objJobInfo.ComputerName);
                    objPanel.UpdateBraketSerial(sTmp[i], objJobInfo.ComputerName);

                }               
                
                return sTmp;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                LogHelper.Log(LogTarget.File, "********************************************", objJobInfo.ComputerName );
                objPanel = null;
            }
        }

        public String StartRead2D(int TraySize, int JobQty, String JobName)
        {
            try
            {
                objJobInfo.PanelSize = TraySize;
                objJobInfo.JobQty = JobQty;
                objJobInfo.JobName = JobName;
                return "OK";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public String StartJob( String Model , int  JobQty ,String JobName, int PanelSize )
        {
            PanelInfoDAO objPanel = new DAO.PanelInfoDAO();
            DataTable dt;
            DataTable dtModel;
            Int64  iStartSerialno = 0;
            Int64  iFinished = 0;
            int lastMaxDegit = 10;
            string sModel = "";
            string sYY = "";
            string sMM = "";
            string sfirstcode = "";
            string sTemp = "";
            String[] sTmp;
            String sZero = "0000";
            String sCutZero = "";

            try
            {

                objJobInfo.JobName = JobName;
                objJobInfo.ModelName = Model;
                objJobInfo.JobQty = JobQty;
                objJobInfo.ComputerName = GetComputerName();
                objJobInfo.PanelSize = PanelSize;

                if (objPanel.HaveBraketBarcodeGen(JobName) == false)
                {
                    sTmp = new String[objJobInfo.JobQty];
                    dtModel = objPanel.GetModelConfig(objJobInfo);
                    if (dtModel.Rows[0]["special_format"].ToString() == "@@@@$$$$")
                    {
                        dt = objPanel.StartReadSpecial(objJobInfo);

                        if (dt.Rows.Count == 0)
                        {
                            throw new Exception("ไม่สามารถ start job ได้");
                        }

                        sModel = dt.Rows[0]["model"].ToString();
                        sMM = dt.Rows[0]["mm"].ToString();
                        sYY = dt.Rows[0]["yy"].ToString();

                        iStartSerialno = Convert.ToInt64(dt.Rows[0]["startserial"].ToString());
                        iFinished = Convert.ToInt64(dt.Rows[0]["NextSerialNoBase10"].ToString());

                        Int64 j = 0;

                        for (Int64 i = iStartSerialno; i <= iFinished; i++)
                        {
                            sTemp = Converter.Convert(10, 33, i.ToString());

                            if (sTemp.Length <= 4)
                            {
                                sCutZero = sZero.Substring(sTemp.Length);
                            }
                            else
                            {
                                sCutZero = "";
                            }

                            //sTmp[j] = sModel + sMM + sCutZero + sTemp + sYY;
                            
                            sTmp[j] = sModel + sCutZero + sTemp;                            
                            objJobInfo.Prefix2D = sModel.Trim();

                           
                            if (dtModel.Rows[0]["special_format"].ToString().Length != sTmp[j].Length ) {
                                throw new Exception("Config format Length :"+ dtModel.Rows[0]["special_format"].ToString()+" ไม่ตรงกับ 2D :"+ sTmp[j].ToString());
                            }

                            int freq = Regex.Matches(dtModel.Rows[0]["special_format"].ToString(), "@").Count;

                            if (freq != sModel.Trim().Length)
                            {
                                throw new Exception("Config Model format Length :" + Regex.Matches(dtModel.Rows[0]["special_format"].ToString(), "@").ToString() + " ไม่ตรงกับ Model :" + sModel.Trim());
                            }
                            objPanel.InsertBraketSerial(objJobInfo, sTmp[j]);

                            j = j + 1;
                        }
                    }else if (dtModel.Rows[0]["special_format"].ToString() == "@@@@$$$%")
                    {
                        sZero = "000";
                        lastMaxDegit = 10;
                        //sTemp max = 35936 
                        


                        if (JobQty > lastMaxDegit) {
                            int tempJobQty = JobQty / lastMaxDegit; //quotient is 1
                            int modJobQty = JobQty % lastMaxDegit; //remainder is 2 
                            if (modJobQty > 0) { tempJobQty = tempJobQty + 1; }
                            //objJobInfo.JobQty = Convert.ToInt32(JobQty / lastMaxDegit) ;
                            objJobInfo.JobQty = Convert.ToInt32(tempJobQty);
                        }
                        else { objJobInfo.JobQty = 1; }
                        
                        dt = objPanel.StartReadSpecial(objJobInfo);

                        if (dt.Rows.Count == 0)
                        {
                            throw new Exception("ไม่สามารถ start job ได้");
                        }

                        sModel = dt.Rows[0]["model"].ToString();
                        sMM = dt.Rows[0]["mm"].ToString();
                        sYY = dt.Rows[0]["yy"].ToString();

                        iStartSerialno = Convert.ToInt64(dt.Rows[0]["startserial"].ToString());
                        iFinished = Convert.ToInt64(dt.Rows[0]["NextSerialNoBase10"].ToString());

                        Int64 j = 0;
                        if (iFinished >= 35936)
                        {
                            throw new Exception("Current running :" + iFinished.ToString() + " Over max Running = 35936" );
                        }

                        for (Int64 i = iStartSerialno; i <= iFinished; i++)
                        {
                            sTemp = Converter.Convert(10, 33, i.ToString());

                            if (sTemp.Length <= 3)
                            {
                                sCutZero = sZero.Substring(sTemp.Length);
                            }
                            else
                            {
                                sCutZero = "";
                            }

                            //sTmp[j] = sModel + sMM + sCutZero + sTemp + sYY;
                            for ( int z = 0;  z <= 9; z++) {
                                    //AZ8007A+Z
                                sTmp[j] = sModel + sCutZero + sTemp + Convert.ToString(z) ;
                                    objJobInfo.Prefix2D = sModel.Trim();


                                    if (dtModel.Rows[0]["special_format"].ToString().Length != sTmp[j].Length)
                                    {
                                        throw new Exception("Config format Length :" + dtModel.Rows[0]["special_format"].ToString() + " ไม่ตรงกับ 2D :" + sTmp[j].ToString());
                                    }

                                    int freq = Regex.Matches(dtModel.Rows[0]["special_format"].ToString(), "@").Count;

                                    if (freq != sModel.Trim().Length)
                                    {
                                        throw new Exception("Config Model format Length :" + Regex.Matches(dtModel.Rows[0]["special_format"].ToString(), "@").ToString() + " ไม่ตรงกับ Model :" + sModel.Trim());
                                    }
                                    objPanel.InsertBraketSerial(objJobInfo, sTmp[j]);
                            }

                            j = j + 1;
                        }
                    }
                    else
                    {
                        dt = objPanel.StartRead(objJobInfo);

                        if (dt.Rows.Count == 0)
                        {
                            throw new Exception("ไม่สามารถ start job ได้");
                        }

                        sModel = dt.Rows[0]["model"].ToString();
                        sMM = dt.Rows[0]["mm"].ToString();
                        sYY = dt.Rows[0]["yy"].ToString();

                        iStartSerialno = Convert.ToInt64(dt.Rows[0]["startserial"].ToString());
                        iFinished = Convert.ToInt64(dt.Rows[0]["NextSerialNoBase10"].ToString());

                        Int64 j = 0;

                        for (Int64 i = iStartSerialno; i <= iFinished; i++)
                        {
                            sTemp = Converter.Convert(10, 33, i.ToString());

                            if (sTemp.Length <= 4)
                            {
                                sCutZero = sZero.Substring(sTemp.Length);
                            }
                            else
                            {
                                sCutZero = "";
                            }

                            sTmp[j] = sModel + sMM + sCutZero + sTemp + sYY;
                            objJobInfo.Prefix2D = sModel.Trim();

                            objPanel.InsertBraketSerial(objJobInfo, sTmp[j]);

                            j = j + 1;
                        }
                    }


                    //throw new Exception("มี job :" + JobName + "เบอร์นี้อยู่แล้วไม่สามารถ Startใหม่ได้");
                }
   
                return "OK";

            }
            catch (Exception ex)
            {
               return ex.Message;
            }
        }

        public DataTable SerialRead(string[] arrSerial, string StrModel, string jobname,int iTotalCavityNew)
        {
            string strFileDate = DateTime.Now.ToString("yyyyMMdd");

            string logfile = @"D:\" + strFileDate + ".txt";

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            //LogHelper.Log(LogTarget.File, arrSerial[0], objJobInfo.ComputerName);
            //LogHelper.Log(LogTarget.File, arrSerial[1], objJobInfo.ComputerName);
            //LogHelper.Log(LogTarget.File, arrSerial[2], objJobInfo.ComputerName);
            //LogHelper.Log(LogTarget.File, arrSerial[3], objJobInfo.ComputerName);
            string Result = "";
            string ResultTmp = "";
            
            string StrReadGroup = DateTime.Now.ToString("yyyyMMddHHmmssFFF");
            SystemUtility objSystem = new SystemUtility();

            PanelInfoDAO objPanelDAO = new PanelInfoDAO();
            MachineDAO objMachineDAO = new MachineDAO();

            PrintinfoM objPrintinfo = new PrintinfoM();

            DataTable dtSerial = new DataTable();
            Boolean bGrade = false;

            dtSerial = GenHeadSerial();
            string sMachineName;
            iTotalCavity = 15;
            if(iTotalCavityNew > 0)
            {
                iTotalCavity = iTotalCavityNew;
            }
            //iTotalCavity = objPanelDAO.GetBraketPanelSizeByMachine(objSystem.GetComputerName());
            try
            {

                if (iTotalCavity == 0)
                {
                    throw new Exception("ยังไม่ได้ใส่ระบุข้อมูล Cavity per panel");
                }

                if (arrSerial.Count() != 0)
                {
                    if (Convert.ToInt64(arrSerial.Count()) != Convert.ToInt64(iTotalCavity.ToString()))
                    {
                        throw new Exception("จำนวน Cavity per panel " + iTotalCavity.ToString() + " กับ Serial " + arrSerial.Count().ToString() + " ที่ยิงได้ไม่ตรงกัน  ");
                    }
                }

                sMachineName = objSystem.GetComputerName();

                if (arrSerial.Length > 0)
                {
                    for (int i = 0; (i <= (arrSerial.Length - 1)); i++)
                    {
                        int iSeq = i + 1;
                         
                        string[] StrData = arrSerial[i].ToString().Split(',');
                        string StrSerial = "";
                        string StrScore = "";
                        string StrScored = "";
                        

                        StrSerial = StrData[0];
                        StrScore = StrData[1];
                        ResultTmp = tmpSaveKeepBraketReader(jobname, StrSerial, StrModel, sMachineName, arrSerial[i].ToString(), "SaveKeepBraketReader-1");
                        StrScored = StrData[2];

                        //StrSerial = StrData.Substring(0, StrData.IndexOf(","));
                        //StrScore = StrData.Substring(StrData.IndexOf(",") + 1, StrData.Length - StrData.IndexOf(",") - 1);
                        //StrScored = StrData.Substring(StrData.IndexOf(",") + 1, StrData.Length - StrData.IndexOf(",") - 1); ;


                        objPrintinfo.Serialno = StrSerial;
                        objPrintinfo.ScanGrade = StrScore;
                        objPrintinfo.ModelName = StrModel;
                        objPrintinfo.PanelID = StrReadGroup;
                        objPrintinfo.Sequence = iSeq;
                        objPrintinfo.JobName = jobname;
                        objPrintinfo.MachineName = sMachineName;
                        objPrintinfo.Score = StrScored;

                        switch (StrScore)
                        {
                            case "A":
                                //statements 
                                bGrade = true;
                                break;
                            case "B":
                                bGrade = true;
                                //statements 
                                break;
                            case "C":
                                bGrade = true;
                                break;
                            case "D":
                                bGrade = true;
                                break;
                            case "E":
                                bGrade = true;
                                break;
                            default:
                                bGrade = false;
                                break;
                        }

                        if (bGrade == true)
                        {
                            string chkSerial;

                            chkSerial = objPanelDAO.HaveBraketInfo(objPrintinfo);

                            if (chkSerial == "OK")
                            {

                                DataRow[] chkDup = dtSerial.Select(("SerialNo = '" + StrSerial + "'"));
                                if (chkDup.Length <= 0)
                                {
                                    if (objPanelDAO.HaveAfterReflow(StrSerial) == false)
                                    {
                                        DataRow dtRow;
                                        dtRow = dtSerial.NewRow();
                                        dtRow["SerialNo"] = StrSerial;
                                        dtRow["grade"] = StrScore;
                                        dtRow["SerialSeq"] = iSeq;
                                        dtRow["score"] = StrScored;
                                        dtRow["ReadGroup"] = StrReadGroup;
                                        dtRow["result"] = "OK";
                                        dtSerial.Rows.Add(dtRow);
                                    }
                                    else
                                    {
                                        DataRow dtRow;
                                        dtRow = dtSerial.NewRow();
                                        dtRow["SerialNo"] = StrSerial;
                                        dtRow["grade"] = StrScore;
                                        dtRow["SerialSeq"] = iSeq;
                                        dtRow["score"] = StrScored;
                                        dtRow["ReadGroup"] = StrReadGroup;
                                        dtRow["result"] = "Duplicated Serial";
                                        dtSerial.Rows.Add(dtRow);

                                        Result = Result + "POS : " + iSeq + " ซ้ำกับ POS : " + chkDup[0]["SerialSeq"].ToString() + Environment.NewLine;

                                    }

                                }
                                else
                                {
                                    DataRow dtRow;
                                    dtRow = dtSerial.NewRow();
                                    dtRow["SerialNo"] = StrSerial;
                                    dtRow["grade"] = StrScore;
                                    dtRow["SerialSeq"] = iSeq;
                                    dtRow["score"] = StrScored;
                                    dtRow["ReadGroup"] = StrReadGroup;
                                    dtRow["result"] = "Duplicated Serial";
                                    dtSerial.Rows.Add(dtRow);

                                    Result = Result + "POS : " + iSeq + " ซ้ำกับ POS : " + chkDup[0]["SerialSeq"].ToString() + Environment.NewLine;
                                }
                            }
                            else
                            {
                                DataRow dtRow;
                                dtRow = dtSerial.NewRow();
                                dtRow["SerialNo"] = StrSerial;
                                dtRow["grade"] = StrScore;
                                dtRow["SerialSeq"] = iSeq;
                                dtRow["score"] = StrScored;
                                dtRow["ReadGroup"] = StrReadGroup;
                                dtRow["result"] = "Duplicated Serial";
                                dtSerial.Rows.Add(dtRow);

                                Result = Result + "POS : " + iSeq + " ==> " + chkSerial + Environment.NewLine;

                            }
                        }
                        else
                        {
                            DataRow dtRow;
                            dtRow = dtSerial.NewRow();
                            dtRow["SerialNo"] = StrSerial;
                            dtRow["grade"] = StrScore;
                            dtRow["SerialSeq"] = iSeq;
                            dtRow["score"] = StrScored;
                            dtRow["ReadGroup"] = StrReadGroup;
                            dtRow["result"] = "Grade fail";
                            dtSerial.Rows.Add(dtRow);

                            Result = Result + "POS : " + iSeq + " ==> " + "Grade ต่ำกว่า E" + " ( Grade = " + StrScore + " )" + Environment.NewLine;

                            string ErrMsg = "";
                            ErrMsg = StrSerial + ";" + StrScore + ";" + iSeq + ";" + StrModel + ";" + DateTime.Now.ToString() + ";" + Environment.MachineName;

                            //using (FileStream fs = new FileStream(logfile, FileMode.Append, FileAccess.Write))
                            //using (StreamWriter sw = new StreamWriter(fs))
                            //{
                            //    sw.WriteLine(ErrMsg);
                            //}
                        }
                    }
                }
                else
                {
                    Result = "ไม่พบข้อมูล Serial ที่ส่งมา";
                }

                if (Result == "")
                {
                    Result = CompleteMasterSheet(dtSerial, StrModel, jobname, sMachineName);
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //return Result = ex.ToString();
            }
            return dtSerial;
            //return Result;
        }
        public DataTable SerialRead(string[] arrSerial, string StrModel, string jobname, int iTotalCavityNew, string validateCavity)
        {
            string strFileDate = DateTime.Now.ToString("yyyyMMdd");

            string logfile = @"D:\" + strFileDate + ".txt";

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            //LogHelper.Log(LogTarget.File, arrSerial[0], objJobInfo.ComputerName);
            //LogHelper.Log(LogTarget.File, arrSerial[1], objJobInfo.ComputerName);
            //LogHelper.Log(LogTarget.File, arrSerial[2], objJobInfo.ComputerName);
            //LogHelper.Log(LogTarget.File, arrSerial[3], objJobInfo.ComputerName);
            string Result = "";
            string ResultTmp = "";

            string StrReadGroup = DateTime.Now.ToString("yyyyMMddHHmmssFFF");
            SystemUtility objSystem = new SystemUtility();

            PanelInfoDAO objPanelDAO = new PanelInfoDAO();
            MachineDAO objMachineDAO = new MachineDAO();

            PrintinfoM objPrintinfo = new PrintinfoM();

            DataTable dtSerial = new DataTable();
            Boolean bGrade = false;

            dtSerial = GenHeadSerial();
            string sMachineName;
            iTotalCavity = 15;
            if (iTotalCavityNew > 0)
            {
                iTotalCavity = iTotalCavityNew;
            }
            //iTotalCavity = objPanelDAO.GetBraketPanelSizeByMachine(objSystem.GetComputerName());
            try
            {

                if (iTotalCavity == 0)
                {
                    throw new Exception("ยังไม่ได้ใส่ระบุข้อมูล Cavity per panel");
                }

                if (arrSerial.Count() != 0)
                {
                    if (Convert.ToInt64(arrSerial.Count()) != Convert.ToInt64(iTotalCavity.ToString()) && validateCavity == "Y")
                    {
                        throw new Exception("จำนวน Cavity per panel " + iTotalCavity.ToString() + " กับ Serial " + arrSerial.Count().ToString() + " ที่ยิงได้ไม่ตรงกัน  ");
                    }
                }

                sMachineName = objSystem.GetComputerName();

                if (arrSerial.Length > 0)
                {
                    for (int i = 0; (i <= (arrSerial.Length - 1)); i++)
                    {
                        int iSeq = i + 1;

                        string[] StrData = arrSerial[i].ToString().Split(',');
                        string StrSerial = "";
                        string StrScore = "";
                        string StrScored = "";


                        StrSerial = StrData[0];
                        StrScore = StrData[1];
                        ResultTmp = tmpSaveKeepBraketReader(jobname, StrSerial, StrModel, sMachineName, arrSerial[i].ToString(), "SaveKeepBraketReader-2");
                        StrScored = StrData[2];

                        //StrSerial = StrData.Substring(0, StrData.IndexOf(","));
                        //StrScore = StrData.Substring(StrData.IndexOf(",") + 1, StrData.Length - StrData.IndexOf(",") - 1);
                        //StrScored = StrData.Substring(StrData.IndexOf(",") + 1, StrData.Length - StrData.IndexOf(",") - 1); ;


                        objPrintinfo.Serialno = StrSerial;
                        objPrintinfo.ScanGrade = StrScore;
                        objPrintinfo.ModelName = StrModel;
                        objPrintinfo.PanelID = StrReadGroup;
                        objPrintinfo.Sequence = iSeq;
                        objPrintinfo.JobName = jobname;
                        objPrintinfo.MachineName = sMachineName;
                        objPrintinfo.Score = StrScored;

                        switch (StrScore)
                        {
                            case "A":
                                //statements 
                                bGrade = true;
                                break;
                            case "B":
                                bGrade = true;
                                //statements 
                                break;
                            case "C":
                                bGrade = true;
                                break;
                            case "D":
                                bGrade = true;
                                break;
                            case "E":
                                bGrade = true;
                                break;
                            default:
                                bGrade = false;
                                break;
                        }

                        if (bGrade == true)
                        {
                            string chkSerial;

                            chkSerial = objPanelDAO.HaveBraketInfo(objPrintinfo);

                            if (chkSerial == "OK")
                            {

                                DataRow[] chkDup = dtSerial.Select(("SerialNo = '" + StrSerial + "'"));
                                if (chkDup.Length <= 0)
                                {
                                    if (objPanelDAO.HaveAfterReflow(StrSerial) == false)
                                    {
                                        DataRow dtRow;
                                        dtRow = dtSerial.NewRow();
                                        dtRow["SerialNo"] = StrSerial;
                                        dtRow["grade"] = StrScore;
                                        dtRow["SerialSeq"] = iSeq;
                                        dtRow["score"] = StrScored;
                                        dtRow["ReadGroup"] = StrReadGroup;
                                        dtRow["result"] = "OK";
                                        dtSerial.Rows.Add(dtRow);
                                    }
                                    else
                                    {
                                        DataRow dtRow;
                                        dtRow = dtSerial.NewRow();
                                        dtRow["SerialNo"] = StrSerial;
                                        dtRow["grade"] = StrScore;
                                        dtRow["SerialSeq"] = iSeq;
                                        dtRow["score"] = StrScored;
                                        dtRow["ReadGroup"] = StrReadGroup;
                                        dtRow["result"] = "Duplicated Serial";
                                        dtSerial.Rows.Add(dtRow);

                                        Result = Result + "POS : " + iSeq + " ซ้ำกับ POS : " + chkDup[0]["SerialSeq"].ToString() + Environment.NewLine;

                                    }

                                }
                                else
                                {
                                    DataRow dtRow;
                                    dtRow = dtSerial.NewRow();
                                    dtRow["SerialNo"] = StrSerial;
                                    dtRow["grade"] = StrScore;
                                    dtRow["SerialSeq"] = iSeq;
                                    dtRow["score"] = StrScored;
                                    dtRow["ReadGroup"] = StrReadGroup;
                                    dtRow["result"] = "Duplicated Serial";
                                    dtSerial.Rows.Add(dtRow);

                                    Result = Result + "POS : " + iSeq + " ซ้ำกับ POS : " + chkDup[0]["SerialSeq"].ToString() + Environment.NewLine;
                                }
                            }
                            else
                            {
                                DataRow dtRow;
                                dtRow = dtSerial.NewRow();
                                dtRow["SerialNo"] = StrSerial;
                                dtRow["grade"] = StrScore;
                                dtRow["SerialSeq"] = iSeq;
                                dtRow["score"] = StrScored;
                                dtRow["ReadGroup"] = StrReadGroup;
                                dtRow["result"] = "Duplicated Serial";
                                dtSerial.Rows.Add(dtRow);

                                Result = Result + "POS : " + iSeq + " ==> " + chkSerial + Environment.NewLine;

                            }
                        }
                        else
                        {
                            DataRow dtRow;
                            dtRow = dtSerial.NewRow();
                            dtRow["SerialNo"] = StrSerial;
                            dtRow["grade"] = StrScore;
                            dtRow["SerialSeq"] = iSeq;
                            dtRow["score"] = StrScored;
                            dtRow["ReadGroup"] = StrReadGroup;
                            dtRow["result"] = "Grade fail";
                            dtSerial.Rows.Add(dtRow);

                            Result = Result + "POS : " + iSeq + " ==> " + "Grade ต่ำกว่า E" + " ( Grade = " + StrScore + " )" + Environment.NewLine;

                            string ErrMsg = "";
                            ErrMsg = StrSerial + ";" + StrScore + ";" + iSeq + ";" + StrModel + ";" + DateTime.Now.ToString() + ";" + Environment.MachineName;

                            //using (FileStream fs = new FileStream(logfile, FileMode.Append, FileAccess.Write))
                            //using (StreamWriter sw = new StreamWriter(fs))
                            //{
                            //    sw.WriteLine(ErrMsg);
                            //}
                        }
                    }
                }
                else
                {
                    Result = "ไม่พบข้อมูล Serial ที่ส่งมา";
                }

                if (Result == "")
                {
                    Result = CompleteMasterSheet(dtSerial, StrModel, jobname, sMachineName);
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //return Result = ex.ToString();
            }
            return dtSerial;
            //return Result;
        }
        public DataTable SerialRead(string[] arrSerial, string StrModel , string jobname)
        {
            string strFileDate = DateTime.Now.ToString("yyyyMMdd");

            string logfile = @"D:\" + strFileDate + ".txt";

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

            string Result = "";
            string ResultTmp = "";
            
            string StrReadGroup = DateTime.Now.ToString("yyyyMMddHHmmssFFF");
            SystemUtility objSystem = new SystemUtility();

            PanelInfoDAO objPanelDAO = new  PanelInfoDAO ();
            MachineDAO objMachineDAO = new MachineDAO();

            PrintinfoM objPrintinfo = new PrintinfoM();

            DataTable dtSerial = new DataTable();
            Boolean bGrade = false;

            dtSerial = GenHeadSerial();
            string sMachineName;
            int iCavity = objPanelDAO.GetBraketPanelSizeByMachineNew(objSystem.GetComputerName());
            if(iCavity > 0)
            {
                SetTotalCavitybyPanel(iCavity);
            }            
            //iTotalCavity = 15;
            //iTotalCavity = objPanelDAO.GetBraketPanelSizeByMachine(objSystem.GetComputerName());


            try
            {
               
                if (iTotalCavity == 0)
                {
                    throw new Exception("ยังไม่ได้ใส่ระบุข้อมูล Cavity per panel");
                }             

                if (arrSerial.Count() != 0)
                {
                    if (Convert.ToInt64(arrSerial.Count()) != Convert.ToInt64(iTotalCavity.ToString()))
                    {                        
                        throw new Exception("จำนวน Cavity per panel "+ iTotalCavity.ToString()+" กับ Serial "+ arrSerial.Count().ToString()+" ที่ยิงได้ไม่ตรงกัน  ");
                    }
                }

                sMachineName = objSystem.GetComputerName();

                if (arrSerial.Length > 0)
                {
                    for (int i = 0; (i <= (arrSerial.Length - 1)); i++)
                    {
                        int iSeq = i + 1;
                        string[] StrData = arrSerial[i].ToString().Split (',');
                        string StrSerial = "";
                        string StrScore = "";
                        string StrScored = "";
                        
                        StrSerial = StrData[0];
                        StrScore = StrData[1];
                        ResultTmp = tmpSaveKeepBraketReader(jobname, StrSerial, StrModel, sMachineName, arrSerial[i].ToString(), "SaveKeepBraketReader-0");
                        StrScored = StrData[2];

                        //StrSerial = StrData.Substring(0, StrData.IndexOf(","));
                        //StrScore = StrData.Substring(StrData.IndexOf(",") + 1, StrData.Length - StrData.IndexOf(",") - 1);
                        //StrScored = StrData.Substring(StrData.IndexOf(",") + 1, StrData.Length - StrData.IndexOf(",") - 1); ;

                        objPrintinfo.Serialno = StrSerial;
                        objPrintinfo.ScanGrade = StrScore;
                        objPrintinfo.ModelName = StrModel;
                        objPrintinfo.PanelID = StrReadGroup;
                        objPrintinfo.Sequence = iSeq;
                        objPrintinfo.JobName = jobname;
                        objPrintinfo.MachineName = sMachineName;
                        objPrintinfo.Score = StrScored;

                        switch (StrScore)
                        {
                            case "A":
                                //statements 
                                bGrade = true;
                                break;
                            case "B":
                                bGrade = true;
                                //statements 
                                break;
                            case "C":
                                bGrade = true;
                                break;
                            case "D":
                                bGrade = true;
                                break;
                            case "E":
                                bGrade = true;
                                break;
                            default:
                                bGrade = false;
                                break;
                        }

                        if (bGrade == true)
                        {
                            string chkSerial;

                            chkSerial = objPanelDAO.HaveBraketInfo(objPrintinfo);
                           
                            if (chkSerial == "OK")
                            {

                                DataRow[] chkDup = dtSerial.Select(("SerialNo = '" + StrSerial + "'"));
                                if (chkDup.Length <= 0)
                                {
                                    if (objPanelDAO.HaveAfterReflow(StrSerial) == false)
                                    {
                                        DataRow dtRow;
                                        dtRow = dtSerial.NewRow();
                                        dtRow["SerialNo"] = StrSerial;
                                        dtRow["grade"] = StrScore;
                                        dtRow["SerialSeq"] = iSeq;
                                        dtRow["score"] = StrScored;
                                        dtRow["ReadGroup"] = StrReadGroup;
                                        dtRow["result"] = "OK";
                                        dtSerial.Rows.Add(dtRow);
                                    }
                                    else
                                    {
                                        DataRow dtRow;
                                        dtRow = dtSerial.NewRow();
                                        dtRow["SerialNo"] = StrSerial;
                                        dtRow["grade"] = StrScore;
                                        dtRow["SerialSeq"] = iSeq;
                                        dtRow["score"] = StrScored;
                                        dtRow["ReadGroup"] = StrReadGroup;
                                        dtRow["result"] = "Duplicated Serial";
                                        dtSerial.Rows.Add(dtRow);

                                        Result = Result + "POS : " + iSeq + " ซ้ำกับ POS : " + chkDup[0]["SerialSeq"].ToString() + Environment.NewLine;

                                    }

                                }
                                else
                                {
                                    DataRow dtRow;
                                    dtRow = dtSerial.NewRow();
                                    dtRow["SerialNo"] = StrSerial;
                                    dtRow["grade"] = StrScore;
                                    dtRow["SerialSeq"] = iSeq;
                                    dtRow["score"] = StrScored;
                                    dtRow["ReadGroup"] = StrReadGroup;
                                    dtRow["result"] = "Duplicated Serial";
                                    dtSerial.Rows.Add(dtRow);

                                    Result = Result + "POS : " + iSeq + " ซ้ำกับ POS : " + chkDup[0]["SerialSeq"].ToString() + Environment.NewLine;
                                }
                            }
                            else
                            {
                                DataRow dtRow;
                                dtRow = dtSerial.NewRow();
                                dtRow["SerialNo"] = StrSerial;
                                dtRow["grade"] = StrScore;
                                dtRow["SerialSeq"] = iSeq;
                                dtRow["score"] = StrScored;
                                dtRow["ReadGroup"] = StrReadGroup;
                                dtRow["result"] = "Duplicated Serial";
                                dtSerial.Rows.Add(dtRow);

                                Result = Result + "POS : " + iSeq + " ==> " + chkSerial + Environment.NewLine;

                            }
                        }
                        else
                        {
                            DataRow dtRow;
                            dtRow = dtSerial.NewRow();
                            dtRow["SerialNo"] = StrSerial;
                            dtRow["grade"] = StrScore;
                            dtRow["SerialSeq"] = iSeq;
                            dtRow["score"] = StrScored;
                            dtRow["ReadGroup"] = StrReadGroup;
                            dtRow["result"] = "Grade fail";
                            dtSerial.Rows.Add(dtRow);

                            //Result = Result + "POS : " + iSeq + " ==> " + "Grade ต่ำกว่า E" + " ( Grade = " + StrScore + " )" + Environment.NewLine;

                            //string ErrMsg = "";
                            //ErrMsg = StrSerial + ";" + StrScore + ";" + iSeq + ";" + StrModel + ";" + DateTime.Now.ToString() + ";" + Environment.MachineName;

                            //using (FileStream fs = new FileStream(logfile, FileMode.Append, FileAccess.Write))
                            //using (StreamWriter sw = new StreamWriter(fs))
                            //{
                            //    sw.WriteLine(ErrMsg);
                            //}
                        }
                    }
                }
                else
                {
                    Result = "ไม่พบข้อมูล Serial ที่ส่งมา";
                }

                if (Result == "")
                {
                    Result = CompleteMasterSheet(dtSerial,StrModel , jobname , sMachineName);
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //return Result = ex.ToString();
            }
            return dtSerial;
            //return Result;
        }

        public String PrintBraketBarcode(String sJobName)
        {
            PanelInfoDAO objPanelDAO = new PanelInfoDAO();
            SystemUtility objSystem = new SystemUtility();
            PrintinfoM objPrintM = new PrintinfoM();

            DataTable dt;

            String sMachineName;

            try
            {
                sMachineName = objSystem.GetComputerName();
                objPrintM.MachineName = sMachineName;
                objPrintM.JobName = sJobName;

                dt = objPanelDAO.GetBraketView(objPrintM);

                if (dt.Rows.Count != iJobQty)
                {
                    throw new Exception("ไม่สามารถ Print barcode ได้เนื่องจากยังยิงไม่ครบจำนวน");
                }

                return "OK";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                objPanelDAO = null;
                objSystem = null;
                objPrintM = null;
                dt = null;
            }
        }
        private string tmpSaveKeepBraketReader( string Jobname, string SerialNo, string StrModel, string Machinename, string dataReader, string UpdBy)
        {
            PrintinfoM objPrintM = new PrintinfoM();
            MachineDAO objMachine = new MachineDAO();
            String sResult = "";

            try
            {
                    sResult = objMachine.SaveKeepBraketReader(Jobname,  SerialNo,  StrModel,  Machinename, dataReader,  UpdBy);

                    if (sResult != "OK")
                    {
                        throw new Exception(sResult);
                    }  

                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        private string CompleteMasterSheet(DataTable dtSerialData, string StrModel, string Jobname , string Machinename )
        {
            PrintinfoM objPrintM = new PrintinfoM();
            MachineDAO objMachine = new MachineDAO();
            String sResult = "";

            try
            {                
                foreach (DataRow dr in dtSerialData.Rows)
                {
                    objPrintM.Serialno = dr["SerialNo"].ToString();
                    objPrintM.ScanGrade = dr["grade"].ToString();
                    objPrintM.Sequence = Convert.ToInt16 (dr["SerialSeq"].ToString());
                    objPrintM.ModelName = StrModel;
                    objPrintM.PanelID = dr["ReadGroup"].ToString();
                    objPrintM.MachineName = Machinename;
                    objPrintM.JobName = Jobname.Trim();
                    objPrintM.Score = dr["score"].ToString();

                    sResult = objMachine.SaveBraketInfo(objPrintM);

                    if (sResult != "OK")
                    {
                        throw new Exception(sResult);
                    } 
                   
                }

                
                return "OK";
            }
            catch (Exception ex)
            {               
                return ex.Message;
            }
        }

        private DataTable GenHeadSerial()
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn("SerialNo", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("grade", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("SerialSeq", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("score", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("ReadGroup", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("result", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            return dt;
        }

        
        public Boolean IsValid2D(String FixtureNo , ref PanelInfoM objPanelM)
        {
            PanelInfoM objPanel = new PanelInfoM();
            PanelInfoDAO objPanelDAO = new PanelInfoDAO();

            try
            {
                objPanel.PanelNo = FixtureNo;
                objPanel.PanelType = "FIXTURE";
                objPanel.Status = "CHECKIN";
                objPanel.Layout = "1";

                objPanelM = objPanelDAO.GetPanelInfo(objPanel);

                objPanelM.ImageData = GetPanelImg(objPanel.Layout);
                     
                return true;

            }
            catch (Exception ex) {                
                return false;
            }
        }

        public String AddJobInQue()
        {
            try
            {
                JobInfoDAO objDAO = new JobInfoDAO();

                bCompleted = false;
                
                objDAO.AddJobInQue(objJobInfo);

                return "OK";
                                
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public String TransferToJigsaw(String FixtureNo, String Jigsaw)
        {
            JobInfoDAO objJob = new JobInfoDAO();
            PanelInfoM objPanel = new PanelInfoM();

            try
            {
                objPanel.FixtureNo = FixtureNo;
                objPanel.Jigsaw = Jigsaw;

                return objJob.TransferToJigsaw(objPanel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                objJob = null;
            }
        }

        public String RegisterFixture(String sFixtureNo)
        {
            String sTmp;

            try
            {
                JobInfoDAO objDAO = new JobInfoDAO();

                objJobInfo.PanelNo = sFixtureNo;
                sTmp = objDAO.RegisterFixture(objJobInfo);
                
                return sTmp;


            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public String Completed2DMatching(String sFixtureNo , String sArr2D  )
        {
            String sTmp;
            PrintinfoDAO objPrintDAO = new PrintinfoDAO();

            try
            {
                objJobInfo.PanelNo = sFixtureNo;
                objJobInfo.Arr2D = sArr2D;

                sTmp = objPrintDAO.Completed2DMatching(objJobInfo);

                return sTmp;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                objPrintDAO = null;
            }

        }

        public String DeleteFixture(String sFixtureNo)
        {
            String sTmp;

            JobInfoDAO objDAO = new JobInfoDAO();
            try
            {
                objJobInfo.PanelNo = sFixtureNo;
                sTmp = objDAO.DeleteFixture(objJobInfo);

                return sTmp;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally {
                objDAO = null;
            }

        }
        //public Boolean IsValid2D(String sPanelType , DataTable dtFixtureInfo , String ref sErrorMsg , String sJobName ref )
        //{
        //    try
        //    {

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        public DataTable GetPanelImg(String sLayout)
        {
            try
            {
                JobInfoDAO objDAO = new JobInfoDAO();
                
                return objDAO.GetPanelImg (sLayout);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public String getBadmarkResult(String Barcode)
        {
            return "1,4,7";
        }

        public DataTable getFixturebyjob(String sJobName )
        {
            try
            {
                JobInfoDAO objDAO = new JobInfoDAO();

                objJobInfo.JobName = sJobName;
                return objDAO.getFixturebyjob (objJobInfo);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        public string getJigsawResult(String Jigsaw)
        {
            PanelInfoDAO objPanel = new PanelInfoDAO();

            try
            {
                return objPanel.GetJigsawResult(Jigsaw);
                //return "1A0001; 2,3,8; 1,4,5";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally {
                objPanel = null;
            }
            
        }

        public string getJigsawResult1(int FixtureID)
        {
            PanelInfoDAO objPanel = new PanelInfoDAO();
            try
            {
                return objPanel.GetJigsawResult1(FixtureID);
                //return "1A0001; 2,3,8; 1,4,5";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                objPanel = null;
            }

        }


        public String[] getJobinfo(String sJobname, String sEn , String sProgramName)
        {
            SystemUtility objSystem = new SystemUtility();
            JobInfoDAO objsync = new JobInfoDAO(false);

            JobinfoM objJob;
            String[] str = new string[9];

            String sMachineName = "";
            String sProgramVersion = "";

            try
            {
                sMachineName = objSystem.GetComputerName();
                //sMachineName = "FPC_SETW8";

                sProgramVersion = objSystem.getVersion ();

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
                }

                objJobInfo.CPN = str[0];
                objJobInfo.JobName = sJobname;
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
                objJobInfo.ProgramName = sProgramName;
                iJobQty = objJobInfo.JobQty;

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

        public String[] getJobinfoM(String sJobname, String sEn, String sProgramName)
        {
            SystemUtility objSystem = new SystemUtility();
            JobInfoDAO objsync = new JobInfoDAO(false);

            JobinfoM objJob;
            String[] str = new string[9];

            String sMachineName = "";
            String sProgramVersion = "";

            try
            {
                sMachineName = objSystem.GetComputerName();
                //sMachineName = "FPC_SETW8";

                sProgramVersion = objSystem.getVersion();

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
                }
                else
                {
                    objJob = objsync.getMachineJobInfo(sJobname);

                    str[0] = objJob.CPN;
                    str[1] = objJob.JobName;
                    str[2] = objJob.JobQty.ToString();
                    str[3] = objJob.Master2D;
                    str[4] = objJob.ModelName;
                    str[5] = objJob.PanelNo;
                    str[6] = objJob.PanelSize.ToString();
                    str[7] = objJob.Remain.ToString();
                    str[8] = objJob.Status;
                }

                objJobInfo.CPN = str[0];
                objJobInfo.JobName = sJobname;
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
                objJobInfo.ProgramName = sProgramName;
                iJobQty = objJobInfo.JobQty;

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

        public  DataTable  getJobInQue()
        {
            JobInfoDAO objsync = new JobInfoDAO(false);
            SystemUtility objSystem = new SystemUtility();
            DataTable dt = new DataTable() ;
            DataRow dr;
            JobinfoM objJobInfo;
            try
            {
                String sComputer = objSystem.GetComputerName();
                //String sComputer = "FPC_SETW8";

                List<JobinfoM> objJobs =  objsync.getJobInQue(sComputer);                

                dt.Columns.Add("no");
                dt.Columns.Add("jobname");
                dt.Columns.Add("remain");
                dt.Columns.Add("checkin");
                dt.Columns.Add("checkout");
                dt.Columns.Add("status");

                if (objJobs != null)
                {
                    if (objJobs.Count > 0)
                    {
                        for (int i = 0; i <= objJobs.Count - 1; i++)
                        {
                            objJobInfo = objJobs[i];

                            dr = dt.NewRow();

                            dr[0] = objJobInfo.SeqNo;
                            dr[1] = objJobInfo.JobName;
                            dr[2] = objJobInfo.Remain;
                            dr[3] = objJobInfo.CheckIn;
                            dr[4] = objJobInfo.CheckOut;
                            dr[5] = objJobInfo.QueStatus;

                            dt.Rows.Add(dr);

                            dr = null;

                        }
                    }
                }
              
                return dt;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                objSystem = null;
                objsync = null;
            }            
        }

        

        public String UpdateJobStatus()
        {
            JobInfoDAO objsync = new JobInfoDAO(false);
            SystemUtility objSystem = new SystemUtility();
            JobinfoM objJobInfo = new JobinfoM() ;
            try
            {
                String sComputer = objSystem.GetComputerName();
                //String sComputer = "FPC_SETW8";

                objJobInfo.MachineName = sComputer;

                return objsync.UpdateStatusJobQ(objJobInfo);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                objSystem = null;
                objsync = null;
                objJobInfo = null;
            }
        }


    }
}

