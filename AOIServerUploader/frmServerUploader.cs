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
using MachineDLL.Entities;


namespace AOIServerUploader
{
    public partial class frmServerUploader : Form
    {
        private const String sTitleErrorBar = "AOI TRI Error";

        private Machine objMachine = new Machine();
        private MachineInfoM objMachineM = new MachineInfoM();

        public frmServerUploader()
        {
            InitializeComponent();
        }

        private void frmServerUploader_Load(object sender, EventArgs e)
        {
            notifyIcon1.Text = "AOI Server Uploader";
            notifyIcon1.Visible = true;

            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.BalloonTipText = "AOI Server Uploader Active";
            notifyIcon1.BalloonTipTitle = "Welcome Message";
            notifyIcon1.ShowBalloonTip(1000);

            try
            {
                this.Text = "AOI Server Uploader SW V." + getVersion() + " Dll v." + objMachine.GetVersion() + "API v." + objMachine.GetWebServiceVersion();
                BeginingLoad();
                lblServerStatus.Cursor = Cursors.Default;

            }
            catch (Exception ex)
            {
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                notifyIcon1.BalloonTipText = sTitleErrorBar;
                notifyIcon1.BalloonTipTitle = "AOI TRI Error:" + ex.Message;
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
                        tmrResult.Enabled = false;
                        btnConnected.Visible = false;
                    }
                    else
                    {
                        tmrResult.Enabled = true;
                        btnConnected.Visible = true;

                        objMachineM.ResultPathFile = dtConfig.Rows[0]["RESULT_PATH_FILE"].ToString();
                        objMachineM.SolderHFile = dtConfig.Rows[0]["SOLDER_H_FILE"].ToString();
                        objMachineM.MachineID = Convert.ToInt64(dtConfig.Rows[0]["MACHINE_ID"].ToString());
                        objMachineM.MachineName = dtConfig.Rows[0]["machine_name"].ToString();
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

        private void lblServerStatus_DoubleClick(object sender, EventArgs e)
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

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                tmrResult.Enabled = false;

                objMachineM.Status = "NEW";
                //SetCompletedText("LOAD");
                DataTable dtTotal = objMachine.GetMachineFileUpload(objMachineM);
                int iTotal = dtTotal.Rows.Count;

                SetText(iTotal.ToString());

                objMachine.UploadAOIFromServer(objMachineM);

                //SetCompletedText("NOT LOAD");


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            //backgroundWorker1.ReportProgress(0);
            
        }

        delegate void SetSetCompletedTextCallback(string text);

        private void SetCompletedText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.lblTotalCompleted.InvokeRequired)
            {
                SetSetCompletedTextCallback d = new SetSetCompletedTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.lblTotalCompleted.Text = text;
            }
        }

        delegate void SetTextCallback(string text);

        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.lblBatchFileCount.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {                
                this.lblBatchFileCount.Text = text;
            }
        }

        private void tmrFileCount_Tick(object sender, EventArgs e)
        {

        }
    }
}
