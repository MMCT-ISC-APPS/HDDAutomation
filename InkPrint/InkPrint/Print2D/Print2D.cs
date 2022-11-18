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

namespace InkPrint.Print2D
{
    public partial class Print2D : Form
    {
        static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        static int alarmCounter = 1;
        static bool exitFlag = false;
        string StrGenCode = "";
        string dropBoxPath = "";
        DataTable dtResultdata;

        private bool bFullScreen;
        static DataTable dtgvSerial;
        Common common = new Common();
        Model_Common_Data common_func = new Model_Common_Data();

        public Print2D()
        {
            InitializeComponent();
        }

        public Print2D(MDIParent1 containerForm)
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
            SetTextBox();
            GetDataMachine();

            //chkConnection();

            //cbMachine.Focus();
        }

        private void SetTextBox()
        {
            //cbMachine.Enabled = true;

            txtJobNo.Text = "";
            //txtQtyBoard.Text = "";
            txtQty.Text = "";
            StrGenCode = "";

            txtJobNo.Enabled = true;
            txtQty.Enabled = false;
            btnGenSerial.Enabled = false;

            gvSerial.AutoGenerateColumns = true;
            gvSerial.DataSource = GenSerialTable();

            txtJobNo.Focus();

           // GetDataComboMachine();
        }

        #region "Defuat Data"

        public DataTable GetDataMac(string ComName)
        {
            DataTable dt = new DataTable();
            common.OpenConnect();

            StringBuilder sql = new StringBuilder();
            sql.Append("    SELECT * ");
            sql.Append("      FROM [cofdb].[dbo].[tb_InkPrintPath]  ");
            sql.Append("    WHERE ");
            sql.Append("      Ink_Status = 'Active' ");
            sql.Append("    AND Computer_Name = '" + ComName + "' ");

            SqlCommand sqlCmd = new SqlCommand(sql.ToString());
            dt = common.ExecuteReader(sqlCmd);
            common.closeConnect();

            return dt;

        }

        public void GetDataMachine()
        {

            DataTable dtMachine = new DataTable();
            dtMachine = GetDataMac(Environment.MachineName);
            if (dtMachine.Rows.Count > 0)
            {
                txtMachine.Text = dtMachine.Rows[0]["Ink_Mac"].ToString();
                txtOutPutPath.Text = dtMachine.Rows[0]["Ink_OutPut"].ToString();
                txtFileName.Text = dtMachine.Rows[0]["Ink_FileName"].ToString();
                txtQtyBoard.Text = dtMachine.Rows[0]["Ink_QtyBoard"].ToString();
                txtJobNo.Enabled = true;
            }
            else
            {
                MessageBox.Show("ไม่พบข้อมูลเครื่อง Ink Print สำหรับ Computer Name :" + Environment.MachineName, "ไม่พบข้อมูลเครื่อง", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtJobNo.Enabled = false;
            }

        }

        #endregion

        #region "Event KeyPress"

        private void txtJobNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtJobNo.Text.Trim() != "")
                {
                   DataTable dt = GetJobDataOracle(txtJobNo.Text.Trim());
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["CLASS_CODE"].ToString().Substring(0, 2) == "AS")
                        {
                            txtJobNo.Enabled = false;
                            txtQty.Enabled = true;
                            txtQty.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Job No : " + txtJobNo.Text + " ไม่ใช่ Job Class Assembly", "Job Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                }
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

        private DataTable GetJobDataOracle(string Jobname)
        {
            DataTable dt = new DataTable();
            using (OracleConnection cn = new OracleConnection(System.Configuration.ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.PROD"].ConnectionString.ToString()))
            {
                using (OracleCommand cmd = new OracleCommand())
                {

                    cn.Open();
                    string sql = "";
                    cmd.Connection = cn;
                    sql = " SELECT w.wip_entity_name    " +
                          "     ,MITEM.SEGMENT1 MPN " +
                          "     ,MITEM.ATTRIBUTE7 CPN " +
                          "     ,DECODE(J.STATUS_TYPE,1,'Unrelease' " +
                          "     ,3,'Release'    " +
                          "     ,4,'Complete'   " +
                          "     ,6,'Hold'    " +
                          "     ,7,'Cancle' " +
                          "     ,5,'Complete - No Charges'  " +
                          "     ,14,'Pending Close' " +
                          "     ,15,'Failed Close'  " +
                          "     ,12,'Close') JOB_STATUS " +
                          "     ,J.START_QUANTITY   " +
                          "     ,J.CLASS_CODE   " +
                          " FROM WIP_DISCRETE_JOBS J,WIP_ENTITIES W,MTL_SYSTEM_ITEMS MITEM  " +
                          " WHERE J.WIP_ENTITY_ID = W.WIP_ENTITY_ID " +
                          "     AND J.PRIMARY_ITEM_ID = MITEM.INVENTORY_ITEM_ID " +
                          "     AND J.ORGANIZATION_ID = MITEM.ORGANIZATION_ID   " +
                          "     AND J.ORGANIZATION_ID = 84  " +
                          "     AND W.WIP_ENTITY_NAME = '" + Jobname + "'  ";

                    OracleDataAdapter oraAdapt = new OracleDataAdapter(sql, cn);
                    oraAdapt.Fill(dt);
                    cn.Close();
                }
            }

            return dt;
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
                sql.Append("	   FROM [cofdb].[dbo].[Printinfo]	");
                sql.Append("	 WHERE SERIALNO = '" + Serial + "'	");
                sql.Append("	 and VerifyCode is not null	");

                OCPds.ConnectionString = ConfigurationManager.ConnectionStrings["COFConnectionString"].ToString();
                if (OCPds.State == ConnectionState.Closed)
                {
                    OCPds.Open();
                }

                OCSql = new SqlCommand(sql.ToString(), OCPds);
                ODRPrd = OCSql.ExecuteReader();
                dt.Load(ODRPrd);
                OCPds.Close();

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

            OCPds.ConnectionString = ConfigurationManager.ConnectionStrings["COFConnectionString"].ToString();
            if (OCPds.State == ConnectionState.Closed)
            {
                OCPds.Open();
            }

            OCSql = new SqlCommand(sql.ToString(), OCPds);
            ODRPrd = OCSql.ExecuteReader();
            dt.Load(ODRPrd);
            OCPds.Close();
            if (dt.Rows.Count > 0)
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
                //cbMachine.Enabled = false;
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

                using (OracleConnection cn = new OracleConnection(System.Configuration.ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.PROD"].ConnectionString.ToString()))
                {
                    using (OracleCommand cmd = new OracleCommand())
                    {

                        OracleCommand objCmd = new OracleCommand();
                        objCmd.Connection = cn;
                        objCmd.CommandText = "APPS.MMT_2D_COF_INK_PRINT.Request_2D";
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.Parameters.Add("p_job_number", OracleType.VarChar).Value = txtJobNo.Text;
                        objCmd.Parameters.Add("p_org_id", OracleType.Number).Value = 84;
                        objCmd.Parameters.Add("p_qty", OracleType.Number).Value = Int32.Parse(txtQty.Text);
                        objCmd.Parameters.Add("p_gen_id", OracleType.Number).Direction = ParameterDirection.InputOutput;
                        objCmd.Parameters.Add("p_cpn", OracleType.VarChar, 50).Direction = ParameterDirection.InputOutput;
                        objCmd.Parameters.Add("p_mpn", OracleType.VarChar, 50).Direction = ParameterDirection.InputOutput;
                        objCmd.Parameters.Add("p_job_type", OracleType.Number).Direction = ParameterDirection.InputOutput;
                        objCmd.Parameters.Add("p_job_size", OracleType.Number).Direction = ParameterDirection.InputOutput;
                        objCmd.Parameters.Add("p_user_id", OracleType.Number).Value = 4554;
                        objCmd.Parameters.Add("o_resultset", OracleType.Cursor).Direction = ParameterDirection.Output;

                        cn.Open();

                        OracleDataReader reader;
                        reader = objCmd.ExecuteReader();

                        p_gen_id = objCmd.Parameters["p_gen_id"].Value.ToString();
                        p_cpn = objCmd.Parameters["p_cpn"].Value.ToString();
                        p_mpn = objCmd.Parameters["p_mpn"].Value.ToString();
                        p_job_type = objCmd.Parameters["p_job_type"].Value.ToString();
                        p_job_size = objCmd.Parameters["p_job_size"].Value.ToString();

                        dtSerial.Load(reader);

                        if (dtSerial.Rows.Count > 0)
                        {
                            //MessageBox.Show("Connect Pass", "OK", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            if (dtSerial.Rows.Count == Int32.Parse(txtQty.Text))
                            {
                                foreach (DataRow dr in dtSerial.Rows)
                                {
                                    // Check Serial in Duplicate 
                                    Result = chkDuplicateSerial(dr["SERIAL"].ToString());

                                    if (Result == "")
                                    {
                                        // Check Serial in dt 
                                        DataRow[] result = dt.Select("SerialNo = '" + dr["SERIAL"].ToString() + "'");
                                        if (result.Length <= 0)
                                        {
                                            DataRow dtRow = dt.NewRow();
                                            dtRow["SerialNo"] = dr["SERIAL"].ToString();
                                            dtRow["JobName"] = dr["WIP_ENTITY_NAME"].ToString();
                                            dtRow["SUBJOB"] = dr["SUBJOB"].ToString();
                                            dtRow["GenCode"] = StrGenCode;
                                            dtRow["Print_Flag"] = "N";
                                            dt.Rows.Add(dtRow);
                                        }
                                        else
                                        {
                                            return Result = "มี Serial ถูก Gen ซ้ำ";
                                        }
                                    }
                                    else
                                    {
                                        return Result;
                                    }
                                }


                                if (dt.Rows.Count > 0)
                                {
                                    Result = CompleteMasterSheet(dt, p_cpn, txtJobNo.Text.Trim(), p_mpn, p_job_type, p_job_size);

                                    if (Result == "")
                                    {
                                        gvSerial.AutoGenerateColumns = true;
                                        gvSerial.DataSource = dt;

                                    }

                                    return Result;
                                }
                                else
                                {
                                    return Result = "ไม่พบข้อมูล Serial ที่ถูก Gen";
                                }


                            }
                            else
                            {
                                return Result = "จำนวน Serial ที่ถูกจาก Oracle ไม่เท่ากับ จำนวนที่ขอไป";
                            }

                        }
                        else
                        {
                            return Result = "ไม่พบ Serial ที่ถูก Gen จาก Oracle";
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Result = ex.Message;
                return Result;
            }

        }

        private string chkDuplicateSerial(string Serial)
        {
            string StrResult = "";

            SqlConnection OCPds = new SqlConnection();
            SqlDataReader ODRPrd;
            SqlCommand OCSql;

            DataTable dt = new DataTable();
            StringBuilder sql = new StringBuilder();
            {

                sql.Append("	SELECT *	");
                sql.Append("	   FROM [cofdb].[dbo].[Printinfo]	");
                sql.Append("	 WHERE SERIALNO = '" + Serial + "'	");

                OCPds.ConnectionString = ConfigurationManager.ConnectionStrings["COFConnectionString"].ToString();
                if (OCPds.State == ConnectionState.Closed)
                {
                    OCPds.Open();
                }

                OCSql = new SqlCommand(sql.ToString(), OCPds);
                ODRPrd = OCSql.ExecuteReader();
                dt.Load(ODRPrd);
                OCPds.Close();

                if (dt.Rows.Count > 0)
                {
                    StrResult = "มี Serial ที่ถูกใช้งานแล้ว";
                }

            }


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
                OCPds.ConnectionString = ConfigurationManager.ConnectionStrings["COFConnectionString"].ToString();
                OCPds.Open();
                OTPds = OCPds.BeginTransaction();

                foreach (DataRow dr in dt.Rows)
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append(" INSERT INTO [cofdb].[dbo].[Printinfo]");
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
                    sql.Append("  ,'" + DateTime.Now + "' ");
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
                    sqlJob.Append("  ,'" + DateTime.Now + "' ");
                    sqlJob.Append("  ,'Print2D' ");
                    sqlJob.Append("  ) ");
                    OCSql = new SqlCommand(sqlJob.ToString(), OCPds, OTPds);
                    OCSql.ExecuteNonQuery();
                }

                OTPds.Commit();
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

            string Result = GenFileSerial();
            if (Result != "")
            {
                myTimer.Stop();
                MessageBox.Show(Result, "เกิดข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetTextBox();
                exitFlag = true;
            }

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
                    myTimer.Stop();
                    MessageBox.Show(Result, "เกิดข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SetTextBox();
                    exitFlag = true;
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
                    string err = UpdateSerial(dtTop);
                    if (err == "")
                    {
                        StrResult = ExportToExcel(dtTop);
                        string xxx = ExportToExcelBK(dtTop);
                        gvSerial.AutoGenerateColumns = true;
                        gvSerial.DataSource = GetDataSerial(txtJobNo.Text, StrGenCode);

                    }
                    else
                    {
                        StrResult = err;
                        return StrResult;

                    }

                }
            }
            else
            {
                StrResult = "Serial ถูกใช้งานหมดแล้ว";
                return StrResult;
            }

            return StrResult;
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
                OCPds.ConnectionString = ConfigurationManager.ConnectionStrings["COFConnectionString"].ToString();
                OCPds.Open();
                OTPds = OCPds.BeginTransaction();

                foreach (DataRow dr in dt.Rows)
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append(" UPDATE [cofdb].[dbo].[Printinfo] SET ");
                    sql.Append(" 	 [Print_Flag] = 'Y'	    ");
                    sql.Append(" 	,[PrintCode_ID] = '" + dt.Rows[0]["SerialNo"].ToString() + "'	    ");
                    sql.Append(" 	,[PANELID] = '" + dt.Rows[0]["SerialNo"].ToString() + "'	    ");
                    sql.Append(" 	,[PrintCode_Date] = '" + DateTime.Now + "'	    ");
                    sql.Append(" 	,[Print_Seq] = '" + i + "'	    ");
                    sql.Append(" WHERE  ");
                    sql.Append("  [SERIALNO] = '" + dr["SerialNo"].ToString() + "' ");
                    SqlCommand sqlCmdInt = new SqlCommand(sql.ToString());
                    OCSql = new SqlCommand(sql.ToString(), OCPds, OTPds);
                    OCSql.ExecuteNonQuery();
                    i++;
                }

                OTPds.Commit();
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
            StreamWriter wr = new StreamWriter(txtOutPutPath.Text + "\\" + txtFileName.Text);
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

        private string ExportToExcelBK(System.Data.DataTable dt)
        {
            string ResultExport = "";

            string filename = "";
            string fileDate = DateTime.Now.ToString("ddMMyyyyhmm");

            filename = "Serial_" + txtJobNo.Text + fileDate.Trim() + ".csv";

            //StreamWriter wr = new StreamWriter(@"D:\\InkPrintText\\" + filename);
            StreamWriter wr = new StreamWriter(@"D:\\PrintBackUp" + "\\" + dt.Rows[0]["SerialNo"].ToString() + ".csv");
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
            return dt;
        }

        private void Process_PrintResult()
        {

            string logfile = "D:\\DataToPrint\\ErrorLog.txt"; //ConfigurationSettings.AppSettings["CSV_Log_File"].ToString();
            string LCRPath = "D:\\DataToPrint\\"; //ConfigurationSettings.AppSettings["CSV_LCR_Path"].ToString();

            dropBoxPath = "D:\\InspectionData\\";//ConfigurationSettings.AppSettings["CSV_DropBox_Path"].ToString();

            string LCRFinishPath = LCRPath + @"\Finish\";
            string LCRErrorPath = LCRPath + @"\Error\";
            string LCRDuplicatePath = LCRPath + @"\Duplicate\";

            string mcName = Environment.MachineName;
            string filePrefix = mcName + "_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0') + "_" + DateTime.Now.ToString("HHmmss");

            DirectoryInfo di = new DirectoryInfo(dropBoxPath);
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


            // OleDbConnection conn = new OleDbConnection
            //("Provider=Microsoft.ACE.OleDb.12.0; Data Source = '" + Path.GetDirectoryName(filePath) + "'; Extended Properties =Excel 8.0;Text;HDR=No;FMT=Delimited");

            // conn.Open();
            // string path = @Path.GetFileName(filePath);
            // OleDbDataAdapter adapter = new OleDbDataAdapter
            //         ("SELECT * FROM  [" + path + "]", conn);
            // DataSet ds = new DataSet("Temp");

            // adapter.Fill(ds, "CSVDelimited");
            // conn.Close();
            // System.Data.DataTable dt = ds.Tables[0];


            StreamReader StrWer;
            String strLine;
            StrWer = File.OpenText(System.IO.Path.GetFullPath(filePath));

            dtResultdata = new System.Data.DataTable();
            dtResultdata = GenInkPrintResult();

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
                            Result = chkDuplicateCorssBoard(strLine.Split(',')[3].Trim());

                            if (Result == "")
                            {
                                DataRow dtRow = dtResultdata.NewRow();
                                dtRow["Serial"] = strLine.Split(',')[3].Trim();
                                if (strLine.Split(',')[4].Trim() != "")
                                {
                                    dtRow["VerifyCode"] = strLine.Split(',')[4].Trim().Substring(0, 1);
                                }
                                else
                                {
                                    dtRow["VerifyCode"] = "";
                                }
                                dtResultdata.Rows.Add(dtRow);
                            }
                            else
                            {
                                StrWer.Close();
                                return Result;
                            }

                        }
                        else
                        {
                            StrWer.Close();
                            return Result = "Serial Print Dpuplicate";
                        }

                    }

                }
            }

            StrWer.Close();

            return Result;

            //foreach (DataRow dr in dt.Rows)
            //{
            //    if (dr["F4"].ToString().Trim() != "")
            //    {
            //        DataRow dtRow = dtResultdata.NewRow();
            //        dtRow["Serial"] = dr["F4"].ToString().Trim();
            //        dtRow["VerifyCode"] = dr["F5"].ToString().Trim();
            //        dtResultdata.Rows.Add(dtRow);
            //    }
            //}

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
                OCPds.ConnectionString = ConfigurationManager.ConnectionStrings["COFConnectionString"].ToString();
                OCPds.Open();
                OTPds = OCPds.BeginTransaction();

                foreach (DataRow dr in dt.Rows)
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append(" UPDATE [cofdb].[dbo].[Printinfo] SET ");
                    sql.Append(" 	[InkPrint_Result] = 'PASS'	    ");
                    sql.Append(" 	,[VerifyCode] = '" + dr["VerifyCode"].ToString().Trim() + "'	    ");
                    sql.Append(" WHERE  ");
                    sql.Append("  [SERIALNO] = '" + dr["Serial"].ToString().Trim() + "' ");
                    SqlCommand sqlCmdInt = new SqlCommand(sql.ToString());
                    OCSql = new SqlCommand(sql.ToString(), OCPds, OTPds);
                    OCSql.ExecuteNonQuery();
                }

                OTPds.Commit();
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

        private DataTable GetDataSerial(string JonName, string GenCode)
        {
            SqlConnection OCPds = new SqlConnection();
            SqlDataReader ODRPrd;
            SqlCommand OCSql;
            DataTable dt = new DataTable();
           
            StringBuilder sql = new StringBuilder();
            sql.Append("	SELECT [SERIALNO],[JOBNAME],[SUBJOB],[GenCode_ID],[Print_Flag]	");
            sql.Append("	FROM [Printinfo]	");
            sql.Append("	  WHERE 1=1	");
            sql.Append("	        AND [JOBNAME] = '" + JonName + "'	");
            sql.Append("	        AND [Print_Flag] = 'N'	");
            sql.Append("	        AND GenCode_ID = '" + GenCode + "'	");
            sql.Append("	ORDER BY [GenCode_Date]	");

            OCPds.ConnectionString = ConfigurationManager.ConnectionStrings["COFConnectionString"].ToString();
            if (OCPds.State == ConnectionState.Closed)
            {
                OCPds.Open();
            }

            OCSql = new SqlCommand(sql.ToString(), OCPds);
            ODRPrd = OCSql.ExecuteReader();
            dt.Load(ODRPrd);
            OCPds.Close();

            return dt;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetTextBox();
        }
        
        //private void button1_Click(object sender, EventArgs e)
        //{

        //    string constring = ConfigurationManager.ConnectionStrings["COFConnectionString"].ConnectionString;
        //    using (SqlConnection con = new SqlConnection(constring))
        //    {
        //        using (SqlCommand cmd = new SqlCommand("GetCountByLastName", con))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@Status", "Active");
        //            cmd.Parameters.Add("@StrResult", SqlDbType.VarChar, 50);
        //            cmd.Parameters["@StrResult"].Direction = ParameterDirection.Output;
        //            con.Open();
        //            cmd.ExecuteNonQuery();
        //            con.Close();
        //            string xx = cmd.Parameters["@StrResult"].Value.ToString();
        //        }
        //    }

        //}

       

        

        
       

       

       


        

        private void button1_Click_1(object sender, EventArgs e)
        {
            Process_PrintResult();
        }

        private void chkConnection()
        {
            using (OracleConnection cn = new OracleConnection(System.Configuration.ConfigurationManager.ConnectionStrings["WindowsFormsApplication1.Properties.Settings.PROD"].ConnectionString.ToString()))
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    try
                    {
                        cn.Open();
                        //MessageBox.Show(cn.ServerVersion, "Connect OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }


        }

        //private void button1_Click_2(object sender, EventArgs e)
        //{
        //    Process_PrintResult();
        //}

       
    }
}
