using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
using System.Threading;
using System.Globalization;
using System.Text.RegularExpressions;
using System.IO;
using System.Data.OracleClient;
using System.Data.OleDb;
using MachineDLL;
using MachineDLL.Entities;

namespace InkPrint.Print2D_New
{
    public partial class Print2D_New : Form
    {
        static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        static int alarmCounter = 1;
        static bool exitFlag = false;
        string StrGenCode = "";
        string dropBoxPath = "D:\\InspectionData\\";
        String constr = "Data Source = prdsvr.mektec.co.th; Initial Catalog = AUTODB; Persist Security Info = True; User ID = sa; Password = P@ssw0rd";
        String logfile = "D:\\DataToPrint\\ErrorLog.txt";//ConfigurationSettings.AppSettings["CSV_Log_File"].ToString();
        String LCRPath = "D:\\DataToPrint\\";//ConfigurationSettings.AppSettings["CSV_LCR_Path"].ToString();

        DataTable dtResultdata;

        private bool bFullScreen;
        static DataTable dtgvSerial;
        Common common = new Common();
        Model_Common_Data common_func = new Model_Common_Data();


        private AITraceability objTraceability;

        public Print2D_New()
        {
            InitializeComponent();
        }

        public Print2D_New(MDIParent1 containerForm)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

            InitializeComponent();
            MdiParent = containerForm;

            if (bFullScreen == false)
            {
                this.FormBorderStyle = FormBorderStyle.Sizable; this.WindowState = FormWindowState.Maximized; bFullScreen = true;

            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.Sizable; this.WindowState = FormWindowState.Normal;
            }
        }

        private void Print2D_Load(object sender, EventArgs e)
        {
            try
            {
                objTraceability = new AITraceability();

                String sMsg = objTraceability.ConnectDatabase();

                if (sMsg != "OK")
                {
                    throw new Exception(sMsg);
                }

                SetTextBox();
                GetDataMachine();
                               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
            //chkConnection();

            //cbMachine.Focus();
        }


        #region "Defuat Data"

        //private void chkConnection()
        //{
        //    using (OracleConnection cn = new OracleConnection(System.Configuration.ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.PROD"].ConnectionString.ToString()))
        //    {
        //        using (OracleCommand cmd = new OracleCommand())
        //        {
        //            try
        //            {
        //                cn.Open();
        //                //MessageBox.Show(cn.ServerVersion, "Connect OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                cn.Close();
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show(ex.Message);
        //            }
        //        }
        //    }


        //}

        public void GetDataMachine()
        {

            DataTable dtMachine = new DataTable();
            //dtMachine = GetDataMac(Environment.MachineName);
            dtMachine = GetDataMac();

            if (dtMachine.Rows.Count > 0)
            {
                txtMachine.Text = dtMachine.Rows[0]["Computer_Name"].ToString();
                txtOutPutPath.Text = dtMachine.Rows[0]["Ink_OutPut"].ToString();
                txtFileName.Text = dtMachine.Rows[0]["Ink_FileName"].ToString();
                txtJobNo.Enabled = true;
            }
            else
            {
                MessageBox.Show("ไม่พบข้อมูลเครื่อง Ink Print สำหรับ Computer Name :" + Environment.MachineName, "ไม่พบข้อมูลเครื่อง", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtJobNo.Enabled = false;
            }

        }

        private void SetTextBox()
        {
            //cbMachine.Enabled = true;

            exitFlag = false;
            myTimer.Stop();
            txtJobNo.Text = "";
            txtQtyBoard.Text = "";
            txtQtySheet.Text = "";
            txtQty.Text = "";
            StrGenCode = "";
            txtMpn.Text = "";            
            txtJobNo.Enabled = true;
            txtQty.Enabled = false;
            btnGenSerial.Enabled = false;

            gvSerial.AutoGenerateColumns = true;
            gvSerial.DataSource = GenSerialTable();
            

        }

        public DataTable GetDataMac()
        {
            try
            {              

                return objTraceability.GetMachineData();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
            //DataTable dt = new DataTable();
            //common.OpenConnect();

            //StringBuilder sql = new StringBuilder();

            //sql.Append("    SELECT * ");
            //sql.Append("      FROM [cofdb].[dbo].[tb_InkPrintPath]  ");
            //sql.Append("    WHERE ");
            //sql.Append("      Ink_Status = 'Active' ");
            //sql.Append("    AND Computer_Name = '" + ComName + "' ");

            //SqlCommand sqlCmd = new SqlCommand(sql.ToString());
            //dt = common.ExecuteReader(sqlCmd);
            //common.closeConnect();

            //return dt;

        }

        public DataTable GetDataMacDetail(string Machine)
        {
            DataTable dt = new DataTable();
            common.OpenConnect();

            StringBuilder sql = new StringBuilder();
            sql.Append("    SELECT  [Ink_OutPut]");
            sql.Append("           ,[Ink_FileName] ");
            sql.Append("           ,[Ink_QtyBoard] ");
            sql.Append("      FROM autodb.[dbo].[tb_InkPrintPath]  ");
            sql.Append("    WHERE ");
            sql.Append("     [Ink_Mac] = '" + Machine + "' ");

            SqlCommand sqlCmd = new SqlCommand(sql.ToString());
            dt = common.ExecuteReader(sqlCmd);
            common.closeConnect();

            return dt;

        }

        #endregion



        #region "Event KeyPress"

        private void txtJobNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    if (txtJobNo.Text.Trim() != "")
                    {
                        String[] str = GetJobDataOracle(txtJobNo.Text.Trim());

                        if (str[4] != "")
                        {
                            //string strQtyPerSht = GetQtyPerSheet(dt.Rows[0]["MPN"].ToString().Substring(0, 6));
                            string strQtyPerSht = str[6];

                            if (strQtyPerSht != "NO")
                            {
                                txtQtySheet.Text = strQtyPerSht;
                                //txtQtyBoard.Text = (int.Parse(strQtyPerSht) * 2).ToString();
                                txtQtyBoard.Text = strQtyPerSht;
                                txtQtySheet.Text = strQtyPerSht;//dtMachine.Rows[0]["Ink_QtySheet"].ToString();
                                txtQty.Text = str[2];
                                txtMpn.Text = str[4];
                                txtJobNo.Enabled = false;
                                txtQty.Enabled = true;
                                txtQty.Focus();
                            }
                            else
                            {
                                MessageBox.Show("ไม่พบข้อมูล Model ของ Job นี้  ==>  กรุณาเพิ่ม Config Model", "กรุณาเพิ่ม Config Model", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtJobNo.Text = "";
                                txtJobNo.Focus();
                                return;
                            }

                        }
                        else
                        {
                            MessageBox.Show("ไม่พบข้อมูล Job No : " + txtJobNo.Text + " ใน Oracle", "ไม่พบข้อมูล Job", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtJobNo.Text = "";
                            txtJobNo.Focus();
                            return;
                        }


                    }
                    else
                    {
                        MessageBox.Show("กรุณากรอกข้อมูล Job No ", "กรุณากรอกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtQty.Enabled = false;
                        txtJobNo.Enabled = true;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }

        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtQty.Text.Trim() != "")
                {
                    int num;
                    if (int.TryParse(txtQty.Text, out num))
                    {
                        btnGenSerial.Enabled = true;
                        txtQty.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("กรุณากรอกข้อมูลเป็นตัวเลข ", "กรุณาตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtQty.Text = "";
                    }
                }
            }
        }


        #endregion



        #region "Validate Data"

        private string[] GetJobDataOracle(string Jobname)
        {
            return objTraceability.GetJobInfo(Jobname);
            //DataTable dt = new DataTable();
            //using (OracleConnection cn = new OracleConnection(System.Configuration.ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.PROD"].ConnectionString.ToString()))
            //{
            //    using (OracleCommand cmd = new OracleCommand())
            //    {

            //        cn.Open();
            //        string sql = "";
            //        cmd.Connection = cn;
            //        sql = " SELECT w.wip_entity_name    " +
            //              "     ,MITEM.SEGMENT1 MPN " +
            //              "     ,MITEM.ATTRIBUTE7 CPN " +
            //              "     ,DECODE(J.STATUS_TYPE,1,'Unrelease' " +
            //              "     ,3,'Release'    " +
            //              "     ,4,'Complete'   " +
            //              "     ,6,'Hold'    " +
            //              "     ,7,'Cancle' " +
            //              "     ,5,'Complete - No Charges'  " +
            //              "     ,14,'Pending Close' " +
            //              "     ,15,'Failed Close'  " +
            //              "     ,12,'Close') JOB_STATUS " +
            //              "     ,J.START_QUANTITY   " +
            //              "     ,J.CLASS_CODE  " +
            //              "     ,MITEM.ATTRIBUTE3 CONFIG  " +
            //              " FROM WIP_DISCRETE_JOBS J,WIP_ENTITIES W,MTL_SYSTEM_ITEMS MITEM  " +
            //              " WHERE J.WIP_ENTITY_ID = W.WIP_ENTITY_ID " +
            //              "     AND J.PRIMARY_ITEM_ID = MITEM.INVENTORY_ITEM_ID " +
            //              "     AND J.ORGANIZATION_ID = MITEM.ORGANIZATION_ID   " +
            //              "     AND J.ORGANIZATION_ID = 84  " +
            //              "     AND W.WIP_ENTITY_NAME = '" + Jobname + "'  ";

            //        OracleDataAdapter oraAdapt = new OracleDataAdapter(sql, cn);
            //        oraAdapt.Fill(dt);
            //        cn.Close();
            //    }
            //}

            //return dt;
        }

        

        private String chkDuplicateCorssBoard(string Serial)
        {
            string Result = "";
            SqlConnection OCPds = new SqlConnection();
            SqlDataReader ODRPrd;
            SqlCommand OCSql;

            DataTable dt = new DataTable();
            StringBuilder sql = new StringBuilder();
            {

                sql.Append("	SELECT *	");
                sql.Append("	   FROM autodb.dbo.Printinfo	");
                sql.Append("	 WHERE SERIALNO = '" + Serial + "'	");
                sql.Append("	 and VerifyCode is not null	");

                //OCPds.ConnectionString = ConfigurationManager.ConnectionStrings["COFConnectionString"].ToString();
                OCPds.ConnectionString = constr;//"Data Source = prdsvr.mektec.co.th; Initial Catalog = AUTODB; Persist Security Info = True; User ID = sa; Password = P@ssw0rd";

                if (OCPds.State == ConnectionState.Closed)
                {
                    OCPds.Open();
                }

                OCSql = new SqlCommand(sql.ToString(), OCPds);
                ODRPrd = OCSql.ExecuteReader();
                dt.Load(ODRPrd);
                OCPds.Close();
                ODRPrd.Dispose();

            }

            if (dt.Rows.Count > 0)
            {
                Result = "Serial Duplicate Cross Board";
            }


            return Result;
        }

        private String chkJobInfo(string JonName)
        {
            SqlConnection OCPds = new SqlConnection();
            SqlDataReader ODRPrd;
            SqlCommand OCSql;
            DataTable dt = new DataTable();
            string Result = "";

            StringBuilder sql = new StringBuilder();
            sql.Append("	SELECT *	");
            sql.Append("	 FROM autodb.dbo.JobInfo	");
            sql.Append("	  WHERE 1=1	");
            sql.Append("	        AND [JOBNAME] = '" + JonName + "'	");

            OCPds.ConnectionString = constr;//"Data Source = prdsvr.mektec.co.th; Initial Catalog = AUTODB; Persist Security Info = True; User ID = sa; Password = P@ssw0rd";//ConfigurationManager.ConnectionStrings["COFConnectionString"].ToString();
            if (OCPds.State == ConnectionState.Closed)
            {
                OCPds.Open();
            }

            OCSql = new SqlCommand(sql.ToString(), OCPds);
            ODRPrd = OCSql.ExecuteReader();
            dt.Load(ODRPrd);
            OCPds.Close();
            ODRPrd.Dispose();

            if (dt.Rows.Count > 0)
            {
                Result = "NO";
            }

            return Result;
        }

        private String GetQtyPerSheet(string ModelJob)
        {
            SqlConnection OCPds = new SqlConnection();
            SqlDataReader ODRPrd;
            SqlCommand OCSql;
            DataTable dt = new DataTable();
            string Result = "";

            StringBuilder sql = new StringBuilder();
            sql.Append("	SELECT *	");
            sql.Append("	 FROM autodb.dbo.[tb_ConfigCOF]	");
            sql.Append("	  WHERE 1=1	");
            sql.Append("	        AND [Config_Code] like '" + ModelJob + "%'	");
            sql.Append("	and [Config_Type] = 'MODEL'	");

            OCPds.ConnectionString = constr;//"Data Source = prdsvr.mektec.co.th; Initial Catalog = AUTODB; Persist Security Info = True; User ID = sa; Password = P@ssw0rd";//ConfigurationManager.ConnectionStrings["COFConnectionString"].ToString();
            if (OCPds.State == ConnectionState.Closed)
            {
                OCPds.Open();
            }

            OCSql = new SqlCommand(sql.ToString(), OCPds);
            ODRPrd = OCSql.ExecuteReader();
            dt.Load(ODRPrd);
            OCPds.Close();
            ODRPrd.Dispose();

            if (dt.Rows.Count > 0)
            {
                Result = dt.Rows[0]["Max_Value"].ToString();
            }
            else
            {
                Result = "NO";
            }

            return Result;
        }

        #endregion


        #region "Get Serial Form Oracle to Sql Server"

        private void btnGenSerial_Click(object sender, EventArgs e)
        {
            string err = GenSerial();
            if (err == "")
            {
                btnGenSerial.Enabled = false;
                Main1();
            }
            else
            {
                MessageBox.Show(err, "เกิดข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetTextBox();
            }

        }

        private DataTable GenSerialTable()
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn("SerialNo", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("JobName", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("SUBJOB", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("GenCode", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("Print_Flag", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);

            return dt;
        }

        private string GenSerial()
        {
            string Result = "";
            string p_gen_id = "";
            string p_cpn = "";
            string p_mpn = "";
            string p_job_type = "";
            string p_job_size = "";

            DataTable dtSerial = new DataTable();

            string[] csvList = Directory.GetFiles(txtOutPutPath.Text, "*.csv");

            string[] txtList = Directory.GetFiles(txtOutPutPath.Text, "*.txt");

            try
            {
                // Delete File
                foreach (string f in csvList)
                {
                    File.Delete(f);
                }

                foreach (string x in txtList)
                {
                    File.Delete(x);
                }
                // end Delete


                DataTable dt = GenSerialTable();
                StrGenCode = Environment.MachineName + txtJobNo.Text + DateTime.Now.ToString("yyyyMMddhhmmssFFF");
                
                dtSerial = objTraceability.GenerateSerialNo(txtJobNo.Text , Convert.ToInt64 (txtQty.Text) );

                if (dtSerial.Rows.Count > 0)
                    {
                        //if (dtSerial.Rows.Count == Int32.Parse(txtQty.Text))
                        //{
                                Result = chkDuplicateSerial(dtSerial);

                                if (Result == "OK")
                                {
                                   foreach (DataRow dr in dtSerial.Rows)
                                    {
                                        DataRow dtRow = dt.NewRow();

                                        dtRow["SerialNo"] = dr["serialno"].ToString();
                                        dtRow["JobName"] = txtJobNo.Text;
                                        dtRow["SUBJOB"] = "";
                                        dtRow["GenCode"] = "";
                                        dtRow["Print_Flag"] = "N";

                                        dt.Rows.Add(dtRow);
                                                        
                                    }
                                }

                                if (dt.Rows.Count > 0)
                                {
                                    Result = CompleteMasterSheet(dt, "", txtJobNo.Text.Trim(), txtMpn.Text , "", txtQty.Text );

                                    if (Result == "")
                                    {
                                        gvSerial.AutoGenerateColumns = true;
                                        gvSerial.DataSource = dt;
                                    }
                                    
                                }
                                else
                                {
                                    Result = "ไม่พบข้อมูล Serial ที่ถูก Gen";
                                }


                            //}
                            //else
                            //{
                            //   Result = "จำนวน Serial ที่ถูกจาก Oracle ไม่เท่ากับ จำนวนที่ขอไป";
                            //}

                }

                return Result;

            }
            catch (Exception ex)
            {
                Result = ex.Message;
                return Result;
            }

        }

        private string chkDuplicateSerial(DataTable dt)
        {
            PrintinfoM objPrint ;
            List<PrintinfoM> LstPrint = new List<PrintinfoM>() ;
            

            String StrResult = "OK";

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                objPrint = new PrintinfoM();

                objPrint.Serialno = dt.Rows[i]["serialno"].ToString();
                objPrint.JobName= dt.Rows[i]["jobname"].ToString();

                LstPrint.Add(objPrint);

                objPrint = null;
            }

            StrResult = objTraceability.IsValid2D(LstPrint);

            return StrResult;

        }

        private string CompleteMasterSheet(DataTable dt, string cpn, string JobName, string mpn, string JobType, string JobSize)
        {
            string result = "";
            SqlTransaction OTPds;
            SqlConnection OCPds = new SqlConnection();
            SqlCommand OCSql;
            OTPds = null;

            try
            {
                OCPds.ConnectionString = constr;//"Data Source = prdsvr.mektec.co.th; Initial Catalog = AUTODB; Persist Security Info = True; User ID = sa; Password = P@ssw0rd";//ConfigurationManager.ConnectionStrings["COFConnectionString"].ToString();
                OCPds.Open();
                OTPds = OCPds.BeginTransaction();

                foreach (DataRow dr in dt.Rows)
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append(" INSERT INTO autodb.dbo.Printinfo");
                    sql.Append(" 	( 	            ");
                    sql.Append(" 	 [SERIALNO]	    ");
                    sql.Append(" 	,[JOBNAME]	    ");
                    sql.Append(" 	,[GenCode_ID]	    ");
                    sql.Append(" 	,[GenCode_Date]	    ");
                    sql.Append(" 	,[Print_Flag]	    ");
                    sql.Append(" 	,[MACHINENAME]      ");
                    sql.Append(" 	) 	            ");
                    sql.Append("  values( ");
                    sql.Append("  '" + dr["SerialNo"].ToString() + "' ");
                    sql.Append("  ,'" + dr["JobName"].ToString() + "' ");
                    sql.Append("  ,'" + dr["GenCode"].ToString() + "' ");
                    sql.Append("  ,GETDATE() ");
                    sql.Append("  ,'N' ");
                    sql.Append("  ,'" + Environment.MachineName + "' ");
                    sql.Append("  ) ");
                    OCSql = new SqlCommand(sql.ToString(), OCPds, OTPds);
                    OCSql.ExecuteNonQuery();
                }

                string chkJob = chkJobInfo(JobName.Trim());

                if (chkJob == "")
                {
                    StringBuilder sqlJob = new StringBuilder();
                    sqlJob.Append(" INSERT INTO autodb.dbo.JobInfo");
                    sqlJob.Append(" 	( 	            ");
                    sqlJob.Append(" 	 [CPN]	    ");
                    sqlJob.Append(" 	,[JOBNAME]	    ");
                    sqlJob.Append(" 	,[MPN]	    ");
                    sqlJob.Append(" 	,[JOBTYPE]	    ");
                    sqlJob.Append(" 	,[JOBSIZE]	    ");
                    sqlJob.Append(" 	,[CREATE_DATE]	    ");
                    sqlJob.Append(" 	,[CREATE_BY]	    ");
                    sqlJob.Append(" 	) 	            ");
                    sqlJob.Append("  values( ");
                    sqlJob.Append("  '" + cpn + "' ");
                    sqlJob.Append("  ,'" + JobName.Trim() + "' ");
                    sqlJob.Append("  ,'" + mpn + "' ");
                    sqlJob.Append("  ,'" + JobType + "' ");
                    sqlJob.Append("  ,'" + JobSize + "' ");
                    sqlJob.Append("  ,GETDATE() ");
                    sqlJob.Append("  ,'Print2D' ");
                    sqlJob.Append("  ) ");
                    OCSql = new SqlCommand(sqlJob.ToString(), OCPds, OTPds);
                    OCSql.ExecuteNonQuery();
                }

                OTPds.Commit();
                OCPds.Close();
                OCPds.Dispose();
                result = "";

            }
            catch (Exception ex)
            {
                if (OTPds != null)
                {
                    OTPds.Rollback();
                    OTPds = null;
                    OCPds.Close();
                    OCPds.Dispose();
                    result = ex.Message;
                }
                else
                {
                    result = ex.Message;
                }
            }

            return result;
        }

        #endregion


        #region "Gen File To Ink Print Machine"

        public int Main1()
        {
            /* Adds the event and the event handler for the method that will 
               process the timer event to the timer. */
            myTimer.Tick += new EventHandler(TimerEventProcessor);

            // Sets the timer interval to 5 seconds.
            myTimer.Interval = 1000;
            myTimer.Start();

            //string Result = GenFileSerial();
            //if (Result != "")
            //{
            //    myTimer.Stop();
            //    MessageBox.Show(Result, "เกิดข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    exitFlag = false;
            //}

            // Runs the timer, and raises the event. 
            while (exitFlag == false)
            {
                // Processes all the events in the queue.
                Application.DoEvents();
            }
            return 0;
        }

        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            myTimer.Stop();

            Process_PrintResult();

            DataTable dtx = (DataTable)gvSerial.DataSource;
            if (dtx.Rows.Count > 0)
            {
                string Result = GenFileSerial();
                if (Result != "")
                {
                    //myTimer.Stop();
                    MessageBox.Show(Result, "เกิดข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //exitFlag = false;
                    alarmCounter += 1;
                    myTimer.Enabled = true;
                }
                else
                {
                    alarmCounter += 1;
                    myTimer.Enabled = true;
                }

            }
            else
            {
                SetTextBox();
                exitFlag = true;
            }

        }

        private string GenFileSerial()
        {
            string StrResult = "";
            dtgvSerial = (DataTable)gvSerial.DataSource;

            int QtyBoard = int.Parse(txtQtyBoard.Text);

            if (dtgvSerial.Rows.Count > 0)
            {
                DataTable dtTop = dtgvSerial.Rows.Cast<DataRow>().Take(QtyBoard).CopyToDataTable();
                string dropBoxPath = txtOutPutPath.Text; // @"D:\InkPrintText\";
                DirectoryInfo di = new DirectoryInfo(dropBoxPath);
                FileInfo[] file = di.GetFiles();
                if (file.Length <= 0)
                {
                    DataTable dtSerialUpdate = GenSerialUpdateTable();
                    int iSeqPanel = 1;
                    string StrPanel = "";
                    foreach (DataRow dr in dtTop.Rows)
                    {
                        if (StrPanel == "")
                        {
                            StrPanel = dr["SerialNo"].ToString();
                        }

                        if (iSeqPanel > Int32.Parse(txtQtySheet.Text))
                        {
                            StrPanel = dr["SerialNo"].ToString();
                            iSeqPanel = 1;
                        }

                        DataRow dtRow = dtSerialUpdate.NewRow();
                        dtRow["SerialNo"] = dr["SerialNo"].ToString();
                        dtRow["PANELID_REF"] = StrPanel;
                        dtSerialUpdate.Rows.Add(dtRow);
                        iSeqPanel++;
                    }


                    string err = UpdateSerial(dtSerialUpdate);
                    if (err == "")
                    {
                        StrResult = ExportToExcel(dtSerialUpdate);
                        string xxx = ExportToExcelBK(dtSerialUpdate);
                        gvSerial.AutoGenerateColumns = true;
                        gvSerial.DataSource = GetDataSerial(txtJobNo.Text, StrGenCode);

                    }
                    else
                    {
                        StrResult = err;
                    }
                }
            }
            else
            {
                StrResult = "Serial ถูกใช้งานหมดแล้ว";
            }

            return StrResult;
        }

        private DataTable GenSerialUpdateTable()
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn("SerialNo", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("PANELID_REF", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            return dt;
        }

        private string UpdateSerial(DataTable dt)
        {
            string result = "";
            SqlTransaction OTPds;
            SqlConnection OCPds = new SqlConnection();
            SqlCommand OCSql;
            OTPds = null;
            int i = 1;
            try
            {
                OCPds.ConnectionString = constr;//"Data Source = prdsvr.mektec.co.th; Initial Catalog = AUTODB; Persist Security Info = True; User ID = sa; Password = P@ssw0rd";//ConfigurationManager.ConnectionStrings["COFConnectionString"].ToString();
                OCPds.Open();
                OTPds = OCPds.BeginTransaction();

                foreach (DataRow dr in dt.Rows)
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append(" UPDATE autodb.dbo.Printinfo SET ");
                    sql.Append(" 	 [Print_Flag] = 'Y'	    ");
                    sql.Append(" 	,[PrintCode_ID] = '" + dt.Rows[0]["SerialNo"].ToString() + "'	    ");
                    sql.Append(" 	,[PANELID_REF] = '" + dr["PANELID_REF"].ToString() + "'	    ");
                    sql.Append(" 	,[PrintCode_Date] = GETDATE()	    ");
                    sql.Append(" 	,[PANELID_REF_SEQ] = '" + i + "'	    ");
                    sql.Append(" WHERE  ");
                    sql.Append("  [SERIALNO] = '" + dr["SerialNo"].ToString() + "' ");
                    SqlCommand sqlCmdInt = new SqlCommand(sql.ToString());
                    OCSql = new SqlCommand(sql.ToString(), OCPds, OTPds);
                    OCSql.ExecuteNonQuery();
                    i++;
                }

                OTPds.Commit();
                OCPds.Close();
                OCPds.Dispose();
                result = "";

            }
            catch (Exception ex)
            {
                if (OTPds != null)
                {
                    OTPds.Rollback();
                    OTPds = null;
                    OCPds.Close();
                    OCPds.Dispose();
                    result = ex.Message;
                }
                else
                {
                    result = ex.Message;
                }
            }

            return result;
        }

        private string ExportToExcel(System.Data.DataTable dt)
        {
            string ResultExport = "";

            string filename = "";
            string fileDate = DateTime.Now.ToString("ddMMyyyyhmm");

            filename = "Serial_" + txtJobNo.Text + fileDate.Trim() + ".csv";

            //StreamWriter wr = new StreamWriter(@"D:\\InkPrintText\\" + filename);
            //StreamWriter wr = new StreamWriter(txtOutPutPath.Text + "\\" + txtFileName.Text);
            StreamWriter wr = new StreamWriter(txtOutPutPath.Text + "\\" + dt.Rows[0]["SerialNo"].ToString() + ".csv");
            try
            {
                for (int i = 0; i < (dt.Rows.Count); i++)
                {
                    //for (int j = 0; j < dt.Columns.Count; j++)
                    //{
                    if (dt.Rows[i][0] != null)
                    {
                        
                        wr.Write(Convert.ToString(dt.Rows[i][0].ToString().Trim()));
                       
                    }
                    //go to next line
                    wr.Write(wr.NewLine);
                    // wr.WriteLine();
                }
                //close file
                wr.Close();
                wr.Dispose();
                ResultExport = "";
            }
            catch (Exception ex)
            {
                //throw ex;
                ResultExport = ex.Message;
            }

            return ResultExport;
        }

        private string ExportToExcelBK(System.Data.DataTable dt)
        {
            string ResultExport = "";

            string filename = "";
            string fileDate = DateTime.Now.ToString("ddMMyyyyhmm");
            String BackupFile = ""; //ConfigurationSettings.AppSettings["CSV_Bk_File"].ToString();

            filename = "Serial_" + txtJobNo.Text + fileDate.Trim() + ".csv";

            //StreamWriter wr = new StreamWriter(@"D:\\InkPrintText\\" + filename);
            StreamWriter wr = new StreamWriter(BackupFile + dt.Rows[0]["SerialNo"].ToString() + ".csv");
            try
            {

                //////for (int i = 0; i < dt.Columns.Count; i++)
                //////{
                //    wr.Write(dt.Columns[0].ToString().ToUpper() + "\t");
                //////}

                //wr.WriteLine();

                //write rows to excel file
                for (int i = 0; i < (dt.Rows.Count); i++)
                {
                    //for (int j = 0; j < dt.Columns.Count; j++)
                    //{
                    if (dt.Rows[i][0] != null)
                    {
                        //if (Environment.MachineName == "DT597")
                        //{
                        wr.Write(Convert.ToString(dt.Rows[i][0].ToString().Trim()));
                        //}
                        //else
                        //{
                        //wr.Write(Convert.ToString(dt.Rows[i][0].ToString().Trim()));
                        //}

                    }
                    else
                    {
                        //wr.Write("\n");
                    }
                    //}
                    //go to next line
                    wr.Write(wr.NewLine);
                    // wr.WriteLine();
                }
                //close file
                wr.Close();
                ResultExport = "";
            }
            catch (Exception ex)
            {
                //throw ex;
                ResultExport = ex.Message;
            }

            return ResultExport;
        }

        #endregion

        #region "Update Verify Grade"

        private System.Data.DataTable GenInkPrintResult()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            DataColumn dc = new DataColumn("Serial", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("VerifyCode", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            dc = new DataColumn("Position", System.Type.GetType("System.String"));
            dt.Columns.Add(dc);
            return dt;
        }

        private void Process_PrintResult()
        {

            //string logfile = "D:\\DataToPrint\\ErrorLog.txt";//ConfigurationSettings.AppSettings["CSV_Log_File"].ToString();
            //string LCRPath = "D:\\DataToPrint\\";//ConfigurationSettings.AppSettings["CSV_LCR_Path"].ToString();

            //dropBoxPath = "D:\\InspectionData\\";//ConfigurationSettings.AppSettings["CSV_DropBox_Path"].ToString();

            string LCRFinishPath = LCRPath + @"\Finish\";
            string LCRErrorPath = LCRPath + @"\Error\";
            string LCRDuplicatePath = LCRPath + @"\Duplicate\";

            string mcName = Environment.MachineName;
            string filePrefix = mcName + "_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0') + "_" + DateTime.Now.ToString("HHmmss");

            DirectoryInfo di = new DirectoryInfo(dropBoxPath);

            if (di.Exists == false)
            {
                di.Create();
            }

            FileInfo[] file = di.GetFiles();

            foreach (FileInfo fi in file)
            {
                try
                {
                    // process file to db
                    string filePath = fi.DirectoryName + "\\" + fi.Name;
                    string newFileName = filePrefix + "_" + fi.Name;

                    string Result = ProcessFile_LCR(filePath, newFileName);
                    // move file to finish folder

                    if (Result != "")
                    {
                        DialogResult result;
                        result = MessageBox.Show(Result, "Please Check", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (result.Equals(DialogResult.OK))
                        {
                            filePath = fi.DirectoryName + "\\" + fi.Name;
                            string filePathError = LCRDuplicatePath + "\\" + filePrefix + "_" + fi.Name;

                            // Keep log file
                            string errorText = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " --------- " + fi.Name + " --------- " + Result;
                            using (FileStream fs = new FileStream(logfile, FileMode.Append, FileAccess.Write))
                            using (StreamWriter sw = new StreamWriter(fs))
                            {
                                sw.WriteLine(errorText);
                            }

                            // Move file to Error Folder
                            File.Move(filePath, filePathError);
                            Console.WriteLine("Serial_Duplicate" + newFileName);
                            Console.WriteLine(Result);
                        }

                    }
                    else
                    {
                        string filePathFinish = LCRFinishPath + "\\" + filePrefix + "_" + fi.Name;
                        // Save Data
                        string errmsg = UpdatePrintResult(dtResultdata);

                        if (errmsg == "")
                        {
                            File.Move(filePath, filePathFinish);
                            Console.WriteLine("Finish " + newFileName);
                        }
                        else
                        {
                            filePath = fi.DirectoryName + "\\" + fi.Name;
                            string filePathError = LCRErrorPath + "\\" + filePrefix + "_" + fi.Name;

                            // Keep log file
                            string errorText = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " --------- " + fi.Name + " --------- " + errmsg;
                            using (FileStream fs = new FileStream(logfile, FileMode.Append, FileAccess.Write))
                            using (StreamWriter sw = new StreamWriter(fs))
                            {
                                sw.WriteLine(errorText);
                            }

                            // Move file to Error Folder
                            File.Move(filePath, filePathError);
                            Console.WriteLine("Error" + newFileName);
                            Console.WriteLine(errmsg);
                        }
                    }


                }
                catch (Exception ex)
                {
                    string filePath = fi.DirectoryName + "\\" + fi.Name;
                    string filePathError = LCRErrorPath + "\\" + fi.Name;

                    // Keep log file
                    string errorText = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " --------- " + fi.Name + " --------- " + ex.Message;
                    using (FileStream fs = new FileStream(logfile, FileMode.Append, FileAccess.Write))
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine(errorText);
                    }

                    // Move file to Error Folder
                    File.Move(filePath, filePathError);
                    Console.WriteLine("Error");
                    Console.WriteLine(ex.Message);

                }
            }
        }

        private string ProcessFile_LCR(string filePath, string newFileName)
        {
            String Result = "";
            string StrDateTime = DateTime.Now.ToString();
            string StrDateCode = DateTime.Now.ToString("yyyyMMddhhmmssFFF");

            StreamReader StrWer;
            String strLine;
            StrWer = File.OpenText(System.IO.Path.GetFullPath(filePath));

            dtResultdata = new System.Data.DataTable();
            dtResultdata = GenInkPrintResult();
            int i = 1;
            try
            {
                while (StrWer.EndOfStream == false)
                {
                    strLine = StrWer.ReadLine();

                    if (strLine.Trim() != "")
                    {

                        if (strLine.Split(',')[3] != "")
                        {
                            DataRow[] ChkDup = dtResultdata.Select("Serial = '" + strLine.Split(',')[3].Trim() + "'");
                            if (ChkDup.Length <= 0)
                            {
                                String StrResult = chkDuplicateCorssBoard(strLine.Split(',')[3].Trim());

                                if (StrResult == "")
                                {
                                    DataRow dtRow = dtResultdata.NewRow();

                                    dtRow["Serial"] = strLine.Split(',')[3].Trim();

                                    if (strLine.Split(',')[4].Trim() != "")
                                    {
                                        dtRow["VerifyCode"] = strLine.Split(',')[4].Trim();
                                    }
                                    else
                                    {
                                        dtRow["VerifyCode"] = "";
                                    }
                                    dtRow["Position"] = i.ToString();
                                    dtResultdata.Rows.Add(dtRow);
                                }
                                else
                                {
                                    //StrWer.Close();
                                    Result = Result + "Pos. " + i.ToString() + " ==> " + StrResult + Environment.NewLine;
                                }
                            }
                            else
                            {
                                //StrWer.Close();
                                Result = Result + "Pos. " + i.ToString() + " ==> " + "Dpuplicate Pos. " + ChkDup[0]["Position"].ToString() + Environment.NewLine;
                            }
                        }
                    }
                    i++;
                }

                StrWer.Close();
                return Result;
            }
            catch (Exception ex)
            {
                StrWer.Close();
                return ex.ToString();
            }
            
        }

        private string UpdatePrintResult(DataTable dt)
        {
            string result = "";
            SqlTransaction OTPds;
            SqlConnection OCPds = new SqlConnection();
            SqlCommand OCSql;
            OTPds = null;

            try
            {
                OCPds.ConnectionString = constr;//"Data Source = prdsvr.mektec.co.th; Initial Catalog = AUTODB; Persist Security Info = True; User ID = sa; Password = P@ssw0rd";//ConfigurationManager.ConnectionStrings["COFConnectionString"].ToString();
                OCPds.Open();
                OTPds = OCPds.BeginTransaction();

                foreach (DataRow dr in dt.Rows)
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append(" UPDATE autodb.dbo.Printinfo SET ");
                    sql.Append(" 	[InkPrint_Result] = 'PASS'	    ");
                    sql.Append(" 	,[VerifyCode] = '" + dr["VerifyCode"].ToString().Trim() + "'	    ");
                    sql.Append(" WHERE  ");
                    sql.Append("  [SERIALNO] = '" + dr["Serial"].ToString().Trim() + "' ");
                    SqlCommand sqlCmdInt = new SqlCommand(sql.ToString());
                    OCSql = new SqlCommand(sql.ToString(), OCPds, OTPds);
                    OCSql.ExecuteNonQuery();
                }

                OTPds.Commit();
                OCPds.Close();
                OCPds.Dispose();
                result = "";
            }
            catch (Exception ex)
            {
                if (OTPds != null)
                {
                    OTPds.Rollback();
                    OTPds = null;
                    OCPds.Close();
                    OCPds.Dispose();
                    result = ex.Message;
                }
                else
                {
                    result = ex.Message;
                }
            }

            return result;
        }

        private DataTable GetDataSerial(string JonName, string GenCode)
        {
            SqlConnection OCPds = new SqlConnection();
            SqlDataReader ODRPrd;
            SqlCommand OCSql;
            DataTable dt = new DataTable();

            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("	SELECT [SERIALNO],[JOBNAME],[SUBJOB],[GenCode_ID],[Print_Flag]	");
                sql.Append("	FROM autodb.dbo.[Printinfo]	");
                sql.Append("	  WHERE 1=1	");
                sql.Append("	        AND [JOBNAME] = '" + JonName + "'	");
                sql.Append("	        AND [Print_Flag] = 'N'	");
                //sql.Append("	        AND GenCode_ID = '" + GenCode + "'	");

                OCPds.ConnectionString = constr; // "Data Source = prdsvr.mektec.co.th; Initial Catalog = AUTODB; Persist Security Info = True; User ID = sa; Password = P@ssw0rd";//ConfigurationManager.ConnectionStrings["COFConnectionString"].ToString();
                if (OCPds.State == ConnectionState.Closed)
                {
                    OCPds.Open();
                }

                OCSql = new SqlCommand(sql.ToString(), OCPds);
                ODRPrd = OCSql.ExecuteReader();
                dt.Load(ODRPrd);
                OCPds.Close();
                ODRPrd.Dispose();
            }
            catch (Exception ex)
            {
                OCPds.Close();
                MessageBox.Show(ex.Message);
            }


            return dt;
        }

        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetTextBox();
        }

        private void txtSerialOnFPC_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtJobNo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
