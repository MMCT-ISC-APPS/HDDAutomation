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
        private String  sProgramName = "AutoVericode";

        private List<string> list2dscan = null;        
        private bool isActive2Scan = false;
        private string strCodeControlled = null;
        Label[] labels;

        private Int64 iIndexBarcode = 0;
        String[] lstData;

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
                SetHistoryGrid();                
                StatusConnected();

            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;          
            }
        }


        private string Validated2D(String sSerialno)
        {

            return "OK";
        }
        private void SetInatialDisplay(Int64 Index)
        {
            labels = new Label[Index];
            int xLocation = 24;
            int yLocation = 31;
            int Width = 46;
            int Height = 33;
            //int RowNum = 1;
            int PixelX = 0;
            int PixelY = 0;

            try
            {                

                iIndexBarcode = Index;

                for (int i = 0; i <= Index - 1; i++)
                {
                    labels[i] = new Label();

                    labels[i].Text = Convert.ToString(i + 1);
                    labels[i].AutoSize = false;
                    labels[i].BorderStyle = BorderStyle.FixedSingle;
                    labels[i].BackColor = System.Drawing.Color.Gray;
                    labels[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 18, FontStyle.Bold);
                    labels[i].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                    PixelX = PixelX + (xLocation + Width) + 30;

                    if (i % 8 == 0)
                    {
                        PixelX = xLocation;
                        PixelY = PixelY + yLocation + Height;
                    }

                    labels[i].Location = new System.Drawing.Point(PixelX, PixelY);
                    labels[i].Size = new System.Drawing.Size(Width, Height);

                    p.Controls.Add(labels[i]);

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
                lblCount.Tag = dtHistory.Rows.Count;

                dtHistory = null;

            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;
            }

        }

        private void SetHistoryGrid()
        {
            {
                var withBlock =  Grid1 ;


                Grid1.Columns.Add("no", "no");
                Grid1.Columns.Add("fixture", "fixture");                
                Grid1.Columns.Add("vericode", "vericode");

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
                txtJobNo.Text = "Job Name"; lblModel.Text = "Model";
                lblJobQty.Text = "0"; lblCount.Text = "0 Records";
                lblFixtureSize.Text = "0";

                dt = new DataTable();

                dt.Columns.Add("no");
                dt.Columns.Add("fixture");
                dt.Columns.Add("location");
                dt.Columns.Add("vericode");
                dt.Columns.Add("jobname");
                dt.Columns.Add("model");

                Grid1.Rows.Clear();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
            btnStart.Enabled = false;
            btnCancel.Enabled = false;
            btnConnect.Enabled = false;

            if (iCase == 0) // Disconnect
            {
                btnConnect.Enabled = true;
            }
            else
            {
                if (iCase == 1) // Already connect
                {
                    btnStart.Enabled = true; btnCancel.Enabled = true;
                    btnConnect.Visible = false; txtEn.Enabled = true;
                    txtJobNo.Enabled = true;

                }
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                ClearData();
                SetHistoryGrid();
                StatusConnected();
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
                tmrMonitor.Enabled = false;
       
                //MonitorPath
                DirectoryInfo DiTmp = new DirectoryInfo(MonitorPath);
                FileInfo[] FileTemp = DiTmp.GetFiles("*.txt");
                string[] MonitorData;
                string sTmp;
                string sFixtureNo = "";
                string sError;
                string[] Vercodes ;

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
                        SetIniDisplay(24);

                        // Matching
                        MonitorData = System.IO.File.ReadAllLines(FileTemp[i].FullName.ToString().Trim());
                        sTmp = MonitorData[0];
                        sFixtureNo = FileTemp[i].Name.Substring (0 , FileTemp[i].Name.IndexOf(".") );
                        Vercodes = MonitorData[0].Split(',');
                                               
                        if (Convert.ToInt64 (lblFixtureSize.Text) != Vercodes.Length - 1)
                        {
                            throw new Exception("Fixture ที่สแกนไม่ตรงกับที่เซ็ทไว้ในระบบ");
                        }

                        sError = objHHGTraceability.RegisterFixture(sFixtureNo);

                        if (sError != "OK")
                        {
                            throw new Exception(sError);
                        }

                        sError = objHHGTraceability.Completed2DMatching(sFixtureNo , MonitorData[0]);

                        if (sError != "OK")
                        {
                            throw new Exception(sError);
                        }
                        else
                        {
                            sError = "OK";
                            SetDisplayBarcode(Vercodes.Length - 1);
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
                //if (bNoJob == true)
                //{
                //    tmrJobQ.Enabled = false;
                //    tmrMonitor.Enabled = false;
                //    bgSVR.CancelAsync();
                //    lblStatus.ForeColor = Color.Red;
                //    SetText("Stop!!!!!");
                //    EnableControl(1);
                //}
                //else
                //{
                //    lblStatus.Tag = "OK";
                //    lblStatus.ForeColor = Color.Blue;
                //    SetText("Waiting for New Fixture!!!!!");
                //}
                //tmrMonitor.Enabled = true;

            }
            catch (Exception ex)
            {                
                e.Cancel = true;
                tmrMonitor.Enabled = false;
                lblStatus.ForeColor = Color.Red;                
                lblStatus.Tag = "ERROR";
                e.Result = ex.Message;
                bgSVR.CancelAsync();
                SetText(ex.Message);                
                System.Threading.Thread.Sleep(100);                
            }

        }

        delegate void SetTextCallback(string text);

        delegate void SetBarcodeCallback(string text);

        delegate void DisplayJobCallBack(string jobname );


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
                if (text.Contains("ERROR") == true)
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
                bgSVR.CancelAsync();
                SetText ("Canceled!" + lblStatus.Text ) ;                
            }            
            else if (e.Error != null)            
            {
                bgSVR.CancelAsync();
                SetText("Error!" + lblStatus.Text);
            }            
            else
            {
                Int64 iTmp = 0;

                iTmp = Convert.ToInt64(lblJobQty.Text) / Convert.ToInt64(lblFixtureSize.Text);

                if (iTmp == Convert.ToInt64 (lblCount.Tag) )
                {
                    EnableControl(1);
                    lblStatus.Text = "Completed!!!!(Waiting new job)";
                }
                else
                {
                    lblStatus.Text = "Starting!!!!";
                    tmrMonitor.Enabled = true;
                    btnCancel.Enabled = true;

                    if (txtJobNo.Text != "")
                    {
                        LoadFixtureHistory(txtJobNo.Text);
                    }

                }



            }


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
                    DisplayByJob(txtJobNo.Text );
                    EnableControl(1);
                }
            }
        }

        private void DisplayByJob(String sJobno )
        {
            string[] str;
          
            try
            {
                if (lblJobQty.InvokeRequired && lblModel.InvokeRequired && lblFixtureSize.InvokeRequired && lblStatus.InvokeRequired)
                {
                    DisplayJobCallBack d = new DisplayJobCallBack(DisplayByJob);
                    this.Invoke(d, new object[] { sJobno });
                }
                else
                {

                    str = objHHGTraceability.getJobinfo(sJobno, txtEn.Text, sProgramName);

                    //LoadDataGrid();
                    LoadFixtureHistory(sJobno);

                    txtJobNo.Text = sJobno;
                    lblJobQty.Text = str[2];
                    lblModel.Text = str[4];
                    lblFixtureSize.Text = str[6];
                    SetInatialDisplay(Convert.ToInt64 (lblFixtureSize.Text));
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
            //tmrJobQ.Enabled = false;
            //Application.DoEvents();
            

            //if (txtJobNo.Text != "")
            //{
            //    Application.DoEvents();
            //    LoadFixtureHistory(txtJobNo.Text);
            //}
            
            //tmrJobQ.Enabled = true;
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

        private void SetDisplayBarcode(int iIndexBarcode )
        {
            String sStatus = "";

            try
            {
                for (int i = 0; i <= iIndexBarcode - 1; i++)
                {
                    //sStatus = Validated2D(lstData[i].ToString());

                    sStatus = "OK";

                    if (sStatus == "OK")
                    {
                        labels[i].BackColor = Color.Green;
                    }
                    else
                    {
                        if (sStatus.Contains("ERROR") == true)
                        {
                            ToolTip Tooltip1 = new ToolTip();
                            Tooltip1.ToolTipIcon = ToolTipIcon.Error;
                            Tooltip1.IsBalloon = true;
                            Tooltip1.ShowAlways = true;

                            labels[i].BackColor = Color.Red;
                            Tooltip1.SetToolTip(labels[i], sStatus);
                            Tooltip1 = null;

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }
        }

        private void SetIniDisplay(int iIndexBarcode)
        {
            try
            {
                    for (int i = 0; i <= iIndexBarcode - 1; i++) 
                    {
                        labels[i].BackColor = System.Drawing.Color.Gray;
                    }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

       private void txtEn_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
