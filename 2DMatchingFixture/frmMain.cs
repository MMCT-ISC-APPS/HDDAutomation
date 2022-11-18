using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MachineDLL;
using System.IO;

namespace _2DMatchingFixture
{
    public partial class frmMain : Form
    {

        private HHGTraceability objHHGTraceability;
        private const String MonitorPath = "c:\\MonitorPath\\";
        private const String sBackup = "c:\\MonitorBackup\\";
        private String sBackupTmp = "";
        private DataTable dt;
        private DataTable dtHistory;
        private String  sProgramName = "Fixture Macthing";

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {            
            try
            {
                objHHGTraceability = new HHGTraceability(false);

                this.Text = sProgramName + "(SW V" + getVersion() + " , DLL v" + objHHGTraceability.GetVersion()  + " , WS v" + objHHGTraceability.GetWebServiceVersion() + ")" ;

                String sDate = DateTime.Now.ToString("yyyyMMdd");

                sBackupTmp = sBackup + @"\" + sDate;

                DirectoryInfo  di = new DirectoryInfo(sBackupTmp);

                if (di.Exists == false)
                {
                    di.Create();
                }

                di = null;

                di = new DirectoryInfo(MonitorPath);

                if (di.Exists == false)
                {
                    di.Create();
                }

                btnNext.Visible = false;

                //tmrJobQ.Enabled = false;                
                ClearData();
                ClearHistoryFixture();                
                SetJobQGrid();
                SetHistoryGrid();                
                StatusConnected();
                LoadDataGrid();

            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;          
            }
        }

        private void LoadDataGrid()
        {
            int iCount = 0;
            int iColumns = 0;
            DataRow dsRow = null;

            try
            {                

                /* Display Job Q 
                 */
                dt = objHHGTraceability.getJobInQue();

                objHHGTraceability.UpdateJobStatus();

                grdJobQ.Rows.Clear();

                for (iCount = 0; iCount <= dt.Rows.Count - 1; iCount++)
                {
                    dsRow = dt.Rows[iCount];

                    DataGridViewRow dsGridRow = new DataGridViewRow();

                    dsGridRow.CreateCells(grdJobQ);

                    for (iColumns = 0; iColumns <= dt.Columns.Count - 1; iColumns++)
                        dsGridRow.Cells[iColumns].Value = dsRow[iColumns];

                    grdJobQ.Rows.Add(dsGridRow);

                }

                if (dt.Rows.Count == 0)
                {
                    bgSVR.CancelAsync();
                    tmrJobQ.Enabled = false;
                    tmrMonitor.Enabled = false;
                    EnableControl(1);
                }

                             
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;
            }
            
        }

        private void LoadFixtureHistory(String sJobName)
        {
            int iCount = 0;
            int iColumns = 0;
            DataRow dsRow = null;

            try
            {

                /* 
                 * Display Job Q 
                 */
                dtHistory = objHHGTraceability.getFixturebyjob(sJobName) ;
                
                Grid1.Rows.Clear();

                for (iCount = 0; iCount <= dtHistory.Rows.Count - 1; iCount++)
                {
                    dsRow = dtHistory.Rows[iCount];

                    DataGridViewRow dsGridRow = new DataGridViewRow();

                    dsGridRow.CreateCells(Grid1);

                    for (iColumns = 0; iColumns <= dtHistory.Columns.Count - 1; iColumns++)
                        dsGridRow.Cells[iColumns].Value = dsRow[iColumns];

                    Grid1.Rows.Add(dsGridRow);

                }

                Grid1.CurrentCell = Grid1.Rows[dtHistory.Rows.Count].Cells[0];
                lblCount.Text = Convert.ToString (dtHistory.Rows.Count) + " Records";

                dtHistory = null;

            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;
            }

        }
        private void SetJobQGrid()
        {
            {                
                var withBlock =  grdJobQ ;
            
                grdJobQ.Columns.Add("no", "no");
                grdJobQ.Columns.Add("jobname", "jobname");
                grdJobQ.Columns.Add("remain", "remain");
                grdJobQ.Columns.Add("checkin", "checkin");
                grdJobQ.Columns.Add("checkout", "checkout");
                grdJobQ.Columns.Add("status", "status");

                grdJobQ.Columns[0].ReadOnly = true;
                grdJobQ.Columns[1].ReadOnly = true;
                grdJobQ.Columns[2].ReadOnly = true;
                grdJobQ.Columns[3].ReadOnly = true;
                grdJobQ.Columns[4].ReadOnly = true;
                grdJobQ.Columns[5].ReadOnly = true;

                grdJobQ.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                grdJobQ.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                grdJobQ.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                grdJobQ.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                grdJobQ.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                grdJobQ.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                grdJobQ.Columns[0].Width = 50;
                grdJobQ.Columns[2].Width = 200;

            }
        }

        private void SetHistoryGrid()
        {
            {
                var withBlock =  Grid1 ;


                Grid1.Columns.Add("no", "no");
                Grid1.Columns.Add("fixture", "fixture");                
                Grid1.Columns.Add("status", "status");

                Grid1.Columns[0].ReadOnly = true;
                Grid1.Columns[1].ReadOnly = true;
                Grid1.Columns[2].ReadOnly = true;

                Grid1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Grid1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Grid1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                Grid1.Columns[0].Width = 50;
                Grid1.Columns[1].Width = Grid1.Width / 2;
                Grid1.Columns[2].Width = Grid1.Width / 2;

            }
        }
        private void ClearData()
        {
            try
            {
                Txt2DBarCode.Text = "Connecting to Database";
                txtJobNo.Text = "Job Name"; lblModel.Text = "Model";
                lblJobQty.Text = "0"; lblCount.Text = "0 Records";
                lblFixtureSize.Text = "0";

                dt = new DataTable();

                dt.Columns.Add("no");
                dt.Columns.Add("jobname");
                dt.Columns.Add("remain");
                dt.Columns.Add("checkin");
                dt.Columns.Add("checkout");
                dt.Columns.Add("status");
                dt.Columns.Add("model");

                grdJobQ.Rows.Clear();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void ClearHistoryFixture()
        {
            dtHistory = new DataTable();

            dtHistory.Columns.Add("no");
            dtHistory.Columns.Add("fixture");
            dtHistory.Columns.Add("status");
                        
            Grid1.Rows.Clear();
        }

        public string getVersion()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            return version;
        }


        private void EnableControl(int iCase)
        {
            txtEn.Enabled = false;
            txtJobNo.Enabled = false;
            Txt2DBarCode.Enabled = false;
            btnStart.Enabled = false;
            btnCancel.Enabled = false;
            btnConnect.Enabled = false;
            btnAdd.Enabled = false;

            if (iCase == 0) // Disconnect
            {
                btnConnect.Enabled = true;
            }
            else {
                if (iCase == 1) // Already connect
                {
                    btnStart.Enabled = true; btnCancel.Enabled = true;
                    btnAdd.Enabled = true;
                    btnConnect.Visible = false; txtEn.Enabled = true;
                    txtJobNo.Enabled = true; Txt2DBarCode.Enabled = true;
                }
                else {
                    if (iCase == 2) // After click start button
                    {

                    }
                }
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                ClearData();
                ClearHistoryFixture();
                SetJobQGrid();
                SetHistoryGrid();
                StatusConnected();
                LoadDataGrid();
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;
            }
            
        }

        private void StatusConnected()
        {
            String sStatus;
            try
            {
                
                sStatus = objHHGTraceability.ConnectDatabase();
                
                if (sStatus == "OK")
                {
                    btnConnect.Visible = false;
                    lblStatus.Text = "Connected (Waiting select en and job !!!!!!)";                    
                    EnableControl(1);
                }
                else
                {
                    btnConnect.Visible = true;
                    lblStatus.Text = sStatus;                    
                    EnableControl(0);
                }
            }
            catch (Exception ex)
            {
                btnConnect.Visible = true;
                lblStatus.Text = ex.Message;
                tmrMonitor.Enabled = false;
                EnableControl(0);
            }
        }

        private void tmrMonitor_Tick(object sender, EventArgs e)
        {
            lblStatus.Text = "Staring !!!!!";
            bgSVR.WorkerReportsProgress = true;
            bgSVR.WorkerSupportsCancellation = true;
            if (!bgSVR.IsBusy) {
             bgSVR.RunWorkerAsync();
            }
            
        }

        private void bgSVR_DoWork(object sender, DoWorkEventArgs e)
        {
            //BackgroundWorker worker = sender as BackgroundWorker;

            try
            {
                /* ************************************
                 * Time stop for running process
                 **************************************/
                bool bNoJob = true;
                tmrMonitor.Enabled = false;

                // get job history 
                for (int j = 0; j < dt.Rows.Count ; j++)
                {
                    if (dt.Rows[j]["status"].ToString() == "LOADING")
                    {
                        if (txtJobNo.Text == "Wait" || txtJobNo.Text == "")
                        {
                            DisplayByJob(dt.Rows[j]["jobname"].ToString(), true);
                        }

                        //MonitorPath
                        DirectoryInfo DiTmp = new DirectoryInfo(MonitorPath);
                        FileInfo[] FileTemp = DiTmp.GetFiles("*.txt");
                        string[] MonitorData;
                        string sTmp;
                        string sFixtureNo = "";
                        string sError;

                        for (int i = 0; i < FileTemp.Length; i++)
                        {
                            if (bgSVR.CancellationPending == true)
                            {
                                e.Cancel = true;
                                break;
                            }
                            else
                            {
                                /*  *************************************
                                 *  Get File in directory Name
                                 ****************************************/

                                // Matching
                                MonitorData = System.IO.File.ReadAllLines(FileTemp[i].FullName.ToString().Trim());

                                sTmp = MonitorData[0]; //MonitorData[0].Split(',');

                                sFixtureNo = sTmp;

                                SetBarcode(sFixtureNo);

                                sError = objHHGTraceability.RegisterFixture(sFixtureNo);

                                if (sError != "OK")
                                {
                                    throw new Exception(sError);
                                }

                                //System.Threading.Thread.Sleep(100);

                                SetText("FILE:" + FileTemp[i].Name.ToString().Trim());

                                /**********
                                 * Remove File
                                 */

                                FileInfo objFile = new FileInfo(sBackupTmp + @"\" + FileTemp[i].Name.ToString().Trim());

                                if (objFile.Exists == false)
                                {
                                    File.Move(FileTemp[i].FullName.ToString().Trim(), sBackupTmp + @"\" + FileTemp[i].Name.ToString().Trim());
                                }
                                else
                                {
                                    File.Delete(FileTemp[i].FullName.ToString().Trim());
                                }

                                System.Threading.Thread.Sleep(100);
                                bgSVR.ReportProgress(i * (FileTemp.Length - 1));

                            }

                        }
                        bNoJob = false;
                        break;
                    }
                    else
                    {
                        bNoJob = true;
                    }
                }

                if (bNoJob == true)
                {
                    tmrJobQ.Enabled = false;
                    tmrMonitor.Enabled = false;
                    bgSVR.CancelAsync();
                    lblStatus.ForeColor = Color.Red;
                    SetText("Stop!!!!!");
                    EnableControl(1);
                }
                else
                {
                    lblStatus.Tag = "OK";
                    lblStatus.ForeColor = Color.Blue;
                    SetText("Waiting for New Fixture!!!!!");
                }
                //tmrMonitor.Enabled = true;

            }
            catch (Exception ex)
            {                
                e.Cancel = true;
                lblStatus.ForeColor = Color.Red;
                lblStatus.Tag = "ERROR";
                SetText(ex.Message);                
                System.Threading.Thread.Sleep(100);
                
            }

        }

        delegate void SetTextCallback(string text);

        delegate void SetBarcodeCallback(string text);

        delegate void DisplayJobCallBack(string jobname , bool AutoSelect);

        private void SetBarcode(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.Txt2DBarCode.InvokeRequired)
            {
                SetBarcodeCallback d = new SetBarcodeCallback(SetBarcode);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.Txt2DBarCode.Text = text;
            }
        }

        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.lblStatus.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                if (lblStatus.Tag.ToString () == "ERROR")
                {
                    btnNext.Visible = true;
                }

                this.lblStatus.Text = text;
            }
        }

        private void bgSVR_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblStatus.Text = (e.ProgressPercentage.ToString() + "%");
        }

        private void bgSVR_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)                
            {
                //bgSVR.CancelAsync();
                //SetText ("Canceled!" + e.Error.Message) ;                
            }            
            else if (e.Error != null)            
            {
                //bgSVR.CancelAsync();
                //SetText("Error!" + e.Error.Message);
            }            
            else
            {
                lblStatus.Text = "Starting!!!!";
            }
                tmrMonitor.Enabled = true;
                btnCancel.Enabled = true;

                if (txtJobNo.Text != "")
                {
                    LoadFixtureHistory(txtJobNo.Text);
                }
                
                //btnStart.Enabled = true;
                //MessageBox.Show("Working Finished.");
        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (bgSVR.IsBusy != true)
                {
                    if (txtEn.Text != "")
                    {
                        // Start the asynchronous operation.
                        this.btnStart.Enabled = false;
                        tmrMonitor.Enabled = true;
                        tmrJobQ.Enabled = true;
                    }
                    else {
                        MessageBox.Show("ยังไม่ได้ใส่ EN");
                    }                    
                }

        }

        private void txtEn_KeyPress(object sender, KeyPressEventArgs e)
        {
            try {
                if (e.KeyChar == Convert.ToChar(13))
                {
                    if (txtEn.Text != "")
                        txtJobNo.Focus();
                    else
                        throw new Exception("ยังไม่ได้ใส่ EN");
                }
            } catch (Exception ex)
            {
                lblStatus.Text = ex.Message;
            }              
        }

        private void txtJobNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(13))
            {
                if (txtJobNo.Text != "")
                {
                    DisplayByJob(txtJobNo.Text , false);
                    EnableControl(1);
                }
            }
        }

        private void DisplayByJob(String sJobno , bool bAutoSelect)
        {
            string[] str;
            String sJobName = "";
            try
            {
                if (lblJobQty.InvokeRequired && lblModel.InvokeRequired && lblFixtureSize.InvokeRequired && lblStatus.InvokeRequired)
                {
                    DisplayJobCallBack d = new DisplayJobCallBack(DisplayByJob);
                    this.Invoke(d, new object[] { sJobno , bAutoSelect });
                }
                else
                {
                    if (bAutoSelect == true)
                    {
                        for (int i = 0; i <= grdJobQ.RowCount - 1; i++)
                        {
                            if (grdJobQ.Rows[i].Cells[5].Value.ToString() == "LOADING")
                            {
                                sJobName = grdJobQ.Rows[i].Cells[1].Value.ToString();
                                break;
                            }
                        }
                    }
                    else {
                        sJobName = sJobno;
                    }

                    str = objHHGTraceability.getJobinfo(sJobName, txtEn.Text, sProgramName);

                    LoadDataGrid();
                    LoadFixtureHistory(sJobName);

                    txtJobNo.Text = sJobName;
                    lblJobQty.Text = str[2];
                    lblModel.Text = str[4];
                    lblFixtureSize.Text = str[6];
                    lblStatus.Text = "Waiting fixture!!!!!";

                }             
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message , "Error" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            try
            {
                objHHGTraceability.AddJobInQue();
                LoadDataGrid();

            }
            catch (Exception ex) {
                StatusConnected();
                lblStatus.Text = ex.Message;
            }
        }

        private void txtJobNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void tmrJobQ_Tick(object sender, EventArgs e)
        {
            tmrJobQ.Enabled = false;
            Application.DoEvents();
            LoadDataGrid();

            if (txtJobNo.Text != "")
            {
                Application.DoEvents();
                LoadFixtureHistory(txtJobNo.Text);
            }
            
            tmrJobQ.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            tmrJobQ.Enabled = false;
            tmrMonitor.Enabled = false;

            if (MessageBox.Show("Stop Application!!!!", "Stop", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bgSVR.CancelAsync();
                lblStatus.Text = "Stop!!!!";
                EnableControl(1);
            }
            else {
                tmrJobQ.Enabled = true;
                tmrMonitor.Enabled = true;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tmrJobQ.Enabled = false;
            tmrMonitor.Enabled = false;

            try
            {
                DirectoryInfo DiTmp = new DirectoryInfo(MonitorPath);
                FileInfo[] FileTemp = DiTmp.GetFiles("*.txt");                

                for (int i = 0; i < FileTemp.Length; i++)
                {
                    FileInfo objFile = new FileInfo(sBackupTmp + @"\" + FileTemp[i].Name.ToString().Trim());
                    File.Delete(FileTemp[i].FullName.ToString().Trim());
                    Txt2DBarCode.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                btnNext.Visible = false;
                tmrJobQ.Enabled = true;
                tmrMonitor.Enabled = true;
            }

        }

        private void txtEn_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
