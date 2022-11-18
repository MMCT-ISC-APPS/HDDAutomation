using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MachineDLL;
using MachineDLL.Entities;

namespace AOIClientUploader
{
    public partial class frmUploader : Form
    {
        private const String sTitleErrorBar = "AOI TRI Error";

        private Machine objMachine = new Machine();
        private MachineInfoM objMachineM = new MachineInfoM();

        Int64 TotalFile = 0;
        Int64 TotalCompleted = 0;

        public frmUploader()
        {
            InitializeComponent();
        }

        private void btnResultPath_Click(object sender, EventArgs e)
        {
            DialogResult Result = ResultFileBro.ShowDialog();

            if (Result == DialogResult.OK)
            {
                lblResultPath.Text = ResultFileBro.SelectedPath;
            }

        }

        private void btnSolderPath_Click(object sender, EventArgs e)
        {
            DialogResult Result = ResultFileBro.ShowDialog();

            if (Result == DialogResult.OK)
            {
                 lblSolderPath.Text  = ResultFileBro.SelectedPath;
            }
        }

        private void frmUploader_Load(object sender, EventArgs e)
        {
            notifyIcon1.Text = "AOI TRI Uploader";
            notifyIcon1.Visible = true;

            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.BalloonTipText = "AOI TRI Uploader Active";
            notifyIcon1.BalloonTipTitle = "Welcome Message";
            notifyIcon1.ShowBalloonTip(1000);

            try
            {
                this.Text = "AOI Client SW V." + getVersion() + " Dll v." + objMachine.GetVersion() + "API v." + objMachine.GetWebServiceVersion();
                BeginingLoad();
                lblServerStatus.Cursor = Cursors.Default;

            }
            catch (Exception ex)
            {
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                notifyIcon1.BalloonTipText = sTitleErrorBar;
                notifyIcon1.BalloonTipTitle = "AOI TRI Error:" + ex.Message ;
                lblServerStatus.Cursor = Cursors.Hand;
                lblServerStatus.ForeColor = Color.Red;
                lblServerStatus.Text = ex.Message;
                notifyIcon1.ShowBalloonTip(1000);
            }
        }

        public string getVersion()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            return version;
        }



        private void BeginingLoad()
        {
            String sStatus;
            DataTable dtConfig;
            try
            {
                sStatus = objMachine.ConnectDatabase();

                if (sStatus == "OK")
                {
                    lblServerStatus.ForeColor = Color.White;
                    objMachineM.MachineName = objMachine.GetComputerName();
                    lblMachineName.Text = objMachineM.MachineName;
                    objMachineM.IPAddress = "N/A";
                    lblServerStatus.Text = "Connected";

                    dtConfig = objMachine.GetMachineConfig(objMachineM.MachineName);
                    
                    if (dtConfig.Rows.Count == 0)
                    {
                        btnResultPath.Enabled = true;
                        btnSolderPath.Enabled = true;
                        btnSave.Visible = true;
                        btnSetting.Visible = false;
                        tmrResult.Enabled = false;
                        btnConnected.Visible = false;
                    }
                    else
                    {
                        btnResultPath.Enabled = false;
                        btnSolderPath.Enabled = false;
                        btnSave.Visible = false;
                        btnSetting.Visible = true;
                        tmrResult.Enabled = true;
                        btnConnected.Visible = true;

                        objMachineM.ResultPathFile = dtConfig.Rows[0]["RESULT_PATH_FILE"].ToString();
                        objMachineM.SolderHFile = dtConfig.Rows[0]["SOLDER_H_FILE"].ToString();
                        objMachineM.MachineID = Convert.ToInt64(dtConfig.Rows[0]["MACHINE_ID"].ToString());
                        lblResultPath.Text = objMachineM.ResultPathFile;
                        lblSolderPath.Text = objMachineM.SolderHFile;

                    }

                    lblServerStatus.Tag = "OK";

                }
                else
                {
                    btnConnected.Visible = false;
                    lblServerStatus.Text = sStatus;
                    lblServerStatus.Tag = "ERROR";
                    throw new Exception(sStatus);                    
                }
                

                // Load. 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void notifyIcon1_MouseMove(object sender, MouseEventArgs e)
        {            
            //notifyIcon1.BalloonTipText = "AOI TRI Mouse Move";
            //notifyIcon1.BalloonTipTitle = "Mouse Move";
            //notifyIcon1.ShowBalloonTip(1000);
        }

        private void executeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) this.WindowState = FormWindowState.Normal;
            this.Activate();
        }

        private void contextMenuStrip1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) this.WindowState = FormWindowState.Normal;
            this.Activate();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblResultPath.Text != "")
                {
                    objMachineM.ResultPathFile = lblResultPath.Text;
                    objMachineM.SolderHFile = lblSolderPath.Text;

                    objMachineM = objMachine.SaveMachineInfo(objMachineM);


                }
                else {
                    throw new Exception("ยังไม่ได้เลือก Result Path ก่อนกดปุ่ม Save");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    
        private void lblServerStatus_DoubleClick_1(object sender, EventArgs e)
        {
            try
            {
                if (lblServerStatus.Text != "Connected")
                {
                    BeginingLoad();
                }
            }
            catch (Exception ex)
            {
                lblServerStatus.ForeColor = Color.Red;
                lblServerStatus.Text = ex.Message;
            }
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

        }

        private void btnConnected_Click(object sender, EventArgs e)
        {            
            try
            {
                if (lblServerStatus.Text != "Connected")
                {
                    BeginingLoad();
                }
            }
            catch (Exception ex)
            {
                lblServerStatus.ForeColor = Color.Red;
                lblServerStatus.Text = ex.Message;
            }
        }

        private void tmrResult_Tick(object sender, EventArgs e)
        {
            tmrResult.Enabled = false;

            lblTime.Text = DateTime.Now.ToString();
            
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();                
            }

            tmrResult.Enabled = true;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            tmrResult.Enabled = true;
        }

        delegate void SetTextCallback(string text);

        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.lblServerStatus.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text});
            }
            else
            {
                this.lblServerStatus.ForeColor = Color.Red;
                this.lblServerStatus.Text = text;
            }
        }

        delegate void SetFileCountTextCallback(string text);

        private void SetFileCountText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.lblBatchFileCount.InvokeRequired)
            {
                SetFileCountTextCallback d = new SetFileCountTextCallback(SetFileCountText);
                this.Invoke(d, new object[] { text });
            }
            else
            {                
                this.lblBatchFileCount.Text = text;
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            //pFileCount.Minimum = 0;
            //pFileCount.Maximum = 100;

            lblTime.Text = DateTime.Now.ToString();

            pFileCount.Value = e.ProgressPercentage ;

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            tmrResult.Enabled = false;
            String PatternFile = "*.txt";
            String ResultPath = objMachineM.ResultPathFile + "\\" + PatternFile;

            String ScanFolder = ResultPath.Substring(0, ResultPath.LastIndexOf("\\"));
            String Pattern = ResultPath.Substring(ResultPath.LastIndexOf("\\") + 1);
             
            int iTotal = 0;
            decimal   fTotal;
            string[] files = Directory.GetFiles(ScanFolder, Pattern);
            String ServerPath;

            SetFileCountText (files.Count().ToString());

            if (files.Count() > 0)
            {
                foreach (string fileResult in files)
                {
                    string foundFile = fileResult;

                    FixtureFile fixture = new FixtureFile(foundFile, objMachineM );

                    try
                    {

                        fixture.Validate();

                        string filedate = fixture.FileInfo.Name;

                        String[] Temp = filedate.ToLower().Split('_');
                        FixtureResult objResult = new FixtureResult();

                        objResult.ProgramName = "AOITRI_Service";
                        objResult.ProgramVersion = objMachine.GetVersion();
                        objResult.ComputerName = fixture.ComputerName;

                        int Position = Convert.ToInt16(Temp[2].Substring(0, Temp[2].IndexOf(".txt")));

                        //if (Temp[2].)

                        String[] Result = fixture.Content.Split(';');
                        String sDefect = "";

                        objResult.DefectCode = "WAITING";

                        //throw new Exception("Error test");
                        for (int i = 0; i <= Result.Length - 1; i++)
                        {
                            objResult.Model = Result[0].ToString();
                            objResult.PanelID = Result[1].ToString();
                            objResult.Position = Position.ToString();
                            objResult.CreatedDate = Convert.ToDateTime(Result[2].ToString());

                            if (Result[3].ToString().ToLower() == "pass")
                            {
                                objResult.Status = "PASS";
                                objResult.DefectCode = "";
                                break;
                            }
                            else
                            {
                                if (Result[3].ToString().ToLower() == "rpair")
                                {
                                    objResult.Status = "FAIL";
                                    objResult.DefectCode = "rpair";
                                    break;
                                }
                                else
                                {
                                    if (Result[3].ToString().ToLower() == "rpass")
                                    {
                                        objResult.Status = "PASS";
                                        objResult.DefectCode = "";
                                        break;
                                    }
                                    else
                                    {
                                        if (Result[3].ToString().ToLower() == "skip")
                                        {
                                            objResult.Status = "FAIL";
                                            objResult.DefectCode = "";
                                            break;
                                        }
                                        else
                                        {
                                            if (Result[3].ToString().ToLower() != "")
                                            {
                                                objResult.Status = "FAIL";
                                                objResult.DefectCode = Result[3].ToString().ToLower();
                                                break;
                                            }
                                            else
                                            {
                                                if (i >= 7)
                                                {
                                                    if (sDefect == "")
                                                    {
                                                        sDefect = Result[i];
                                                    }
                                                    else
                                                    {
                                                        sDefect = sDefect + ";" + Result[i];
                                                    }
                                                }
                                            }


                                        }                                        

                                    }


                                }
                            }

                        }

                        objResult.Result = sDefect;

                        ServerPath = objMachine.UploadFileFromServer(fixture.FileInfo.FullName, "HSG_AOI", fixture.ComputerName);
                        objResult.AOIPath = ServerPath;
                        objMachineM.FixtureResult = objResult;

                        objMachine.InsertAOIInfo(objMachineM);

                        fixture.Pick();

                        fixture = null;

                        iTotal = iTotal + 1;

                        TotalFile = Convert.ToInt64(files.Count());
                        TotalCompleted = Convert.ToInt64(iTotal);
                        int TotalProgress = 0;

                        fTotal = Convert.ToDecimal (TotalFile - TotalCompleted);
                        fTotal = fTotal / TotalFile;
                        TotalProgress = Convert.ToInt16(100 - (fTotal * 100));

                        string[] Totalfiles = Directory.GetFiles(ScanFolder, Pattern);

                        SetFileCountText(Convert.ToString (Totalfiles.Count().ToString ()));

                        

                        backgroundWorker1.ReportProgress(TotalProgress);

                        

                    }
                    catch (Exception ex)
                    {
                        SetText(ex.Message);
                    }

                }
            }

        }

        private void lblServerStatus_Click(object sender, EventArgs e)
        {

        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            lblServerStatus.Text = "Disconnected";
            lblMachineName.Enabled = true;
            btnConnected.Text = "Connect";
            tmrResult.Enabled = false;
            btnSave.Enabled = true;
            btnSave.Visible = true;

        }
    }
}
