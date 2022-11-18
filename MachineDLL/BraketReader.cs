using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using MachineDLL;

namespace MachineDLL
{
    public class BraketClass
    {

        private SqlTransaction trans;
        private SqlConnection conn;
        private int iTotalCavity = 0;
        private Boolean bOnline = false;
        //private HHGTraceability HHGTraceabilityObj;

        public BraketClass(Boolean Online)
        {
            bOnline = Online;
        }

         public string ConnectDatabse()
        {
            try
            {

                if (bOnline == true)
                {
                    OpenConnect();
                    return "OK";
                }
                else {
                    return "OK";
                }
                
            }
            catch (Exception ex) {
                return ex.Message;
            }
        }

        public void SetTotalCavitybyPanel(int iCavity)
        {
            iTotalCavity = iCavity;
        }
                
        public string getVersion()
        {
            //Assembly assembly  ;
            //var attribute = (AssemblyVersionAttribute)Assembly
            //.GetExecutingAssembly()
            //.GetCustomAttributes(typeof(AssemblyVersionAttribute), true)
            //.Single();
            Assembly asm = Assembly.GetExecutingAssembly();
            return asm.FullName.ToString ();
        }

        public DataTable SerialRead(string[] arrSerial, string StrModel)
        {
            DataTable dtSerial = new DataTable();
            HHGTraceability objHHGTraceability = new HHGTraceability();
            try
            {
                iTotalCavity = GetBraket_Machine(Environment.MachineName);
                dtSerial = objHHGTraceability.SerialRead(arrSerial, StrModel, "", iTotalCavity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //return Result = ex.ToString();
            }
            return dtSerial;

        }
        public DataTable SerialRead(string[] arrSerial, string StrModel, string jobName)
        {
            DataTable dtSerial = new DataTable();
            HHGTraceability objHHGTraceability = new HHGTraceability();
            int ReaderConfig = 0;
            try
            {
                iTotalCavity = GetBraket_Machine(Environment.MachineName);
                ReaderConfig = GetBraket_Machine_Reader(Environment.MachineName);
                if (ReaderConfig == iTotalCavity)
                {
                    dtSerial = objHHGTraceability.SerialRead(arrSerial, StrModel, jobName, iTotalCavity, "Y");
                }
                else
                {
                    dtSerial = objHHGTraceability.SerialRead(arrSerial, StrModel, jobName, iTotalCavity,"N");
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //return Result = ex.ToString();
            }
            return dtSerial;

        }
        public  DataTable  SerialReadOld(string[] arrSerial,string StrModel )
        {
            string strFileDate = DateTime.Now.ToString("yyyyMMdd");

            string logfile = @"D:\" + strFileDate + ".txt";

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

            string Result = "";
            string StrReadGroup = DateTime.Now.ToString("yyyyMMddHHmmssFFF");
            DataTable dtSerial = new DataTable();
            Boolean bGrade = false;
            //SerialRead(string[] arrSerial, string StrModel, string jobname)
            dtSerial = GenHeadSerial();
            try
            {

                //if (iTotalCavity == 0)
                //{
                //    throw new Exception("ยังไม่ได้ใส่ระบุข้อมูล Cavity per panel");
                //}

                 iTotalCavity = 15;
                 iTotalCavity = GetBraket_Machine(Environment.MachineName);



                //if (arrSerial.Count() != 0)
                //{
                //    if (Convert.ToInt64(arrSerial.Count()) != Convert.ToInt64(iTotalCavity.ToString()))
                //    {K
                //        throw new Exception("จำนวน Cavity per panel กับ Serial ที่ยิงได้ไม่ตรงกัน");
                //    }
                //}
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
                if (arrSerial.Length > 0)
                {
                    for (int i = 0; (i <= (arrSerial.Length - 1)); i++)
                    {
                        int iSeq = i + 1;
                        string StrData = arrSerial[i].ToString();
                        string StrSerial = "";
                        string StrScore = "";

                        StrSerial = StrData.Substring(0, StrData.IndexOf(","));
                        StrScore = StrData.Substring(StrData.IndexOf(",") + 1, StrData.Length - StrData.IndexOf(",") - 1);

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

                            if (bOnline == false)
                            {
                                chkSerial = "";
                            }
                            else
                            {
                                chkSerial = GetSerialData(StrSerial, StrScore);
                            }
                            
                            if (chkSerial == "")
                            {
                                DataRow[] chkDup = dtSerial.Select(("SerialNo = '" + StrSerial + "'"));
                                if (chkDup.Length <= 0)
                                {
                                    DataRow dtRow;
                                    dtRow = dtSerial.NewRow();
                                    dtRow["SerialNo"] = StrSerial;
                                    dtRow["grade"] = StrScore;
                                    dtRow["SerialSeq"] = iSeq;
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
                            dtRow["ReadGroup"] = StrReadGroup;
                            dtRow["result"] = "Grade fail";
                            dtSerial.Rows.Add(dtRow);

                            Result = Result + "POS : " + iSeq + " ==> " + "Grade ต่ำกว่า E" + " ( Grade = " + StrScore +" )"+ Environment.NewLine;

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
                    if (bOnline == false)
                    {
                        Result = "OK";
                    }
                    else {
                        Result = CompleteMasterSheet(dtSerial, StrModel);
                    }
                    
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

        private  DataTable GenHeadSerial()
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn("SerialNo", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("grade", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("SerialSeq", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("ReadGroup", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("result", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            return dt;
        }

        public  DataTable GetDataGrid(string strMachinename)
        {
            DataTable dt = new DataTable();
            OpenConnect();

            StringBuilder sql = new StringBuilder();
            sql.Append("   SELECT TOP 100 [SerialNo]	");
            sql.Append("  ,[grade]	");
            sql.Append("  ,[SerialSeq]	");
            sql.Append("  ,[ModelCode]	");
            sql.Append("  ,[CreateDate]	");
            sql.Append("  ,[ReadGroup]	");
            sql.Append("  ,[MachineName]  	");
            sql.Append(" FROM tb_Serial	");
            sql.Append(" WHERE MachineName = '" + strMachinename + "'	");
            sql.Append(" AND CreateDate BETWEEN DATEADD(HOUR,-1,GETDATE()) AND GETDATE()	");
            sql.Append(" ORDER BY CreateDate desc	");
            SqlCommand sqlCmd = new SqlCommand(sql.ToString());
            dt = ExecuteReader(sqlCmd);
            closeConnect();

            return dt;

        }

        private  string GetSerialData(string StrSerial, string strNewScore)
        {
            string StrResult = "";
            DataTable dt = new DataTable();
            OpenConnect();

            StringBuilder sql = new StringBuilder();
            sql.Append(" 	SELECT SerialNo,grade,ModelCode	");
            sql.Append(" 	  FROM [tb_Serial]	");
            sql.Append("    WHERE 1=1 ");
            sql.Append("      AND SerialNo = '" + StrSerial + "' ");
            SqlCommand sqlCmd = new SqlCommand(sql.ToString());
            dt = ExecuteReader(sqlCmd);
            closeConnect();

            if (dt.Rows.Count > 0)
            {
                StrResult = "SN." + dt.Rows[0]["SerialNo"] + " มีข้อมูลแล้ว Grade : " + strNewScore + " MPN: " + dt.Rows[0]["ModelCode"].ToString();
            }

            return StrResult;

        }
        private int GetBraket_Machine(string machineName)
        {
            int StrResult = 15;
            DataTable dt = new DataTable();
            OpenConnect();

            StringBuilder sql = new StringBuilder();
            sql.Append(" 	SELECT LoadCavity	");
            sql.Append(" 	  FROM  Braket_Machine 	");
            sql.Append("    WHERE  machine_name = '" + machineName + "' ");
            SqlCommand sqlCmd = new SqlCommand(sql.ToString());
            dt = ExecuteReader(sqlCmd);
            closeConnect();

            if (dt.Rows.Count > 0)
            {
                StrResult = Convert.ToInt16(dt.Rows[0]["LoadCavity"]);
            }

            return StrResult;

        }
        private int GetBraket_Machine_Reader(string machineName)
        {
            int StrResult = 15;
            DataTable dt = new DataTable();
            OpenConnect();

            StringBuilder sql = new StringBuilder();
            sql.Append(" 	SELECT ReaderConfig	");
            sql.Append(" 	  FROM  Braket_Machine 	");
            sql.Append("    WHERE  machine_name = '" + machineName + "' ");
            SqlCommand sqlCmd = new SqlCommand(sql.ToString());
            dt = ExecuteReader(sqlCmd);
            closeConnect();

            if (dt.Rows.Count > 0)
            {
                StrResult = Convert.ToInt16(dt.Rows[0]["ReaderConfig"]);
            }

            return StrResult;

        }
        private  string CompleteMasterSheet(DataTable dtSerialData, string StrModel)
        {
            try
            {

                BeginTrans();

                foreach (DataRow dr in dtSerialData.Rows)
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append("INSERT INTO tb_Serial ");
                    sql.Append(" (   [SerialNo]           ");
                    sql.Append("    ,[grade]             "); 
                    sql.Append("    ,[SerialSeq]         ");
                    sql.Append("    ,[ModelCode]          ");
                    sql.Append("    ,[CreateDate]         ");
                    sql.Append("    ,[ReadGroup]        ");
                    sql.Append("    ,[MachineName]        ");
                    sql.Append("    )                       ");
                    sql.Append(" values(                    ");
                    sql.Append("    '" + dr["SerialNo"].ToString() + "'       ");
                    sql.Append("    ,'" + dr["grade"].ToString() + "'       ");
                    sql.Append("    ,'" + dr["SerialSeq"].ToString() + "'       ");
                    sql.Append("    ,'" + StrModel + "'       ");
                    sql.Append("    ,GETDATE()      ");
                    sql.Append("    ,'" + dr["ReadGroup"].ToString() + "'       ");
                    sql.Append("    ,'" + Environment.MachineName + "'       ");
                    sql.Append("     ) ");
                    SqlCommand sqlCmd = new SqlCommand(sql.ToString());
                    string errMsg = ExecuteData(sqlCmd);
                    if (errMsg != "")
                    {
                        RollBackTrans();
                        return errMsg;
                    }
                }
                    
                CommitTrans();

                return "OK";
            }
            catch (Exception ex)
            {
                RollBackTrans();
                return ex.Message;
            }
        }

        #region DB Transaction
        private string ExecuteData(SqlCommand sqlCmd)
        {
            sqlCmd.Connection = conn;
            string s = sqlCmd.CommandText;
            sqlCmd.Transaction = trans;
            try
            {
                int rowEffect = sqlCmd.ExecuteNonQuery();
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        private  void OpenConnect()
        {
            //conn = new SqlConnection("Data Source=cofsvr.mektec.co.th;Initial Catalog=Bracket;Persist Security Info=True;User ID=sa;Password=P@ssw0rd");
            conn = new SqlConnection(@"Data Source=prdsvrb\hdd;Initial Catalog=HGSTVericode;User ID=sa;Password=P@ssw0rd;");
            if (conn.State == ConnectionState.Open) conn.Close();
            conn.Open();
        }

        private  void BeginTrans()
        {
            OpenConnect();
            trans = conn.BeginTransaction();

        }

        private  void CommitTrans()
        {
            trans.Commit();
            trans = null;
            conn.Close();
        }

        private  void RollBackTrans()
        {
            if (trans != null)
            {
                trans.Rollback();
                trans = null;
                conn.Close();
            }
        }

        private  void closeConnect()
        {
            conn.Close();
            conn.Dispose();
        }

        private  DataTable ExecuteReader(SqlCommand sqlCmd)
        {
            DataTable dt = new DataTable();
            sqlCmd.Connection = conn;
            string s = sqlCmd.CommandText;
            SqlDataReader reader = null;
            try
            {
                reader = sqlCmd.ExecuteReader();
                dt.Load(reader);
            }
            catch (Exception ex)
            {
                throw ;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                    reader.Dispose();
                }
            }
            return dt;
        }

        #endregion

    }

    
}
