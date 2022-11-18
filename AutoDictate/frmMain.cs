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
using MachineDLL.Entities.AutoDictate;
using System.IO;

namespace AutoDictate
{
    public partial class frmMain : Form
    {
        private Machine objMachine;
        private AutoDictConfigurationM objConfigM;
        private DataTable dtData = null;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                objMachine = new Machine ();
                StatusConnected();
                dtData = new DataTable();
                dtData.Columns.Add("no");
                dtData.Columns.Add("opername");
                dtData.Columns.Add("filename");
                dtData.Columns.Add("path");
                dtData.Columns.Add("temppath");
                dtData.Columns.Add("status");

                cboLane.Items.Add("ALL");
                cboLane.Items.Add("1");
                cboLane.Items.Add("2");

                /*cboProdLine.Items.Add("AI-AS-02");
                cboProdLine.Items.Add("AI-AS-03");
                cboProdLine.Items.Add("AI-AS-04");
                cboProdLine.Items.Add("AI-AS-05");
                cboProdLine.Items.Add("AI-AS-06");
                cboProdLine.Items.Add("AI-AS-07");
                */

                cboProdLine.Items.Add("L02");
                cboProdLine.Items.Add("L03");
                cboProdLine.Items.Add("L04");
                cboProdLine.Items.Add("L05");
                cboProdLine.Items.Add("L06");
                cboProdLine.Items.Add("L07");
                cboProdLine.Items.Add("L08");

                cboProdLine.SelectedIndex = 1;

                tmrProcess.Enabled = false;

                btnCancel.Visible = false;
                btnUpload.Visible = true;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void StatusConnected()
        {
            String sStatus;
            try
            {

                sStatus = objMachine.ConnectDatabase();

                if (sStatus == "OK")
                {
                    btnConnect.Visible = false;
                    lblStatus.Text = "Connected (Waiting select en and job !!!!!!)";

                }
                else
                {
                    btnConnect.Visible = true;
                    lblStatus.Text = sStatus;
                }

                this.Text = "Auto Dictate SW V." + getVersion() + " Dll v." + objMachine.GetVersion() + "API v." + objMachine.GetWebServiceVersion();

            }
            catch (Exception ex)
            {
                btnConnect.Visible = true;
                lblStatus.Text = ex.Message;
            }
        }

        public string getVersion()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            return version;
        }

        private void txtJobNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtJobNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            int i = 0;
            DataRow dr;
            AutoDictLayoutM objLayout;            

            try
            {
                if (e.KeyChar == 13)
                {
                    if (txtModel.Text != "")
                    {
                        //objConfigM = objMachine.GetModelConfiguration(txtModel.Text , cboProdLine.SelectedText);
                        objConfigM = objMachine.GetModelConfiguration(txtModel.Text, "L-04");
                        lblModel.Text = objConfigM.ModelName;
                        objConfigM.LANE = cboLane.SelectedItem.ToString ()  ;

                        //** 
                        //*            Generated File with Laytout
                        //**
                        //objConfigM.LANE = "ALL";


                        String FileName = "";

                        foreach (AutoDictModelConfigM objModel in objConfigM.ModelConfigM)
                        {
                            dr = dtData.NewRow();

                            i = i + 1;
                            foreach (AutoDictProdLineConfigM objProdLine in objModel.ProdLineM)
                            {
                                string[] Arr = new string[3];
                                dr["no"] = i.ToString();
                                dr["opername"] = objModel.OperName;
                                objLayout = objProdLine.LayoutM;

                                Arr = GenerateFormatWithLayout(objProdLine.LayoutM.LayoutFileName, objProdLine, objProdLine.LayoutM , objConfigM , objModel);

                                dr["filename"] = Arr[0];
                                dr["status"] = "CREATE";
                                dr["temppath"] = Arr[1] ;

                                dtData.Rows.Add(dr);

                                dr = null;
                                FileName = "";

                            }

                            grdView.DataSource = dtData;


                        }
                    }

                }          
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private String[] GenerateFormatWithLayout(String LayoutFileName , AutoDictProdLineConfigM objProdLine , AutoDictLayoutM objLayout , AutoDictConfigurationM objConfigM ,  AutoDictModelConfigM objModel)
        {
            String FileName = "";
            String[] LayoutFile;
            String[] LayoutContext;
            string[] Arr = new string[3];

            String sTempFileName = "";

            /*** FileName ****/
            LayoutFile = LayoutFileName.Split('_');

            for (int z = 0; z <= LayoutFile.Length - 1; z++)
            {
                String[] SplitCommand = LayoutFile[z].Split('@');

                for (int x = 0; x <= SplitCommand.Length - 1; x++)
                {
                    if (SplitCommand[x] == "LANE")
                    {
                        if (objConfigM.LANE == "ALL")
                        {
                            FileName = SplitCommand[0] + "@1" + "|" + SplitCommand[0] + "@2";
                        }
                        else
                        {
                            FileName = SplitCommand[0] + "@" + objConfigM.LANE.Trim();
                        }
                    }
                    else
                    {
                        if (SplitCommand[x] == "DATETIME")
                        {
                            if (FileName == "")
                            {
                                FileName = DateTime.Now.ToString("yyyyMMdd");
                            }
                            else
                            {
                                FileName = FileName + "_" + DateTime.Now.ToString("yyyyMMdd");
                            }

                        }
                        else
                        {
                            if (SplitCommand[x] == "MACHINENAME")
                            {
                                if (FileName == "")
                                {
                                    FileName = objProdLine.MachineName.Trim();
                                }
                                else
                                {
                                    FileName = FileName + "_" + objProdLine.MachineName.Trim();
                                }

                            }
                            else
                            {
                                if (FileName == "")
                                {
                                    FileName = SplitCommand[x];
                                }
                                else
                                {
                                    if (SplitCommand[x].ToString() == "")
                                    {
                                        FileName = FileName + SplitCommand[x].ToString();
                                    }
                                    else
                                    {
                                        FileName = FileName + "_" + SplitCommand[x];
                                    }
                                    
                                }

                            }
                        }
                    }

                }
            }

            String[] Col = FileName.Split('|');

            String sTemp = "";

            if (Col.Length == 1)
            {
                FileName = FileName + objLayout.ExtensionFile.Trim();
            }
            else
            {
                for (int k = 0; k <= Col.Length - 1; k++)
                {
                    if (sTemp == "")
                    {
                        sTemp = Col[k] + objLayout.ExtensionFile.Trim();
                    }
                    else
                    {
                        sTemp = sTemp + "|" + Col[k] + objLayout.ExtensionFile.Trim();
                    }
                }

                FileName = sTemp;
            }

            /*** Create file****/
            String LayoutDetail = "";
            LayoutContext = objLayout.LayoutContext.Split('_');

            for (int i = 0; i <= LayoutContext.Length - 1; i++)
            {
                String[] SplitCommand = LayoutContext[i].Split('@');

                if (SplitCommand.Length > 2)
                {                    
                    LayoutDetail = LayoutContext[i];
                    LayoutDetail = LayoutDetail.Replace("@LANE", objConfigM.LANE);
                    LayoutDetail = LayoutDetail.Replace("@PROGRAMNAME", ReplaceProgramName(objModel.ProgramName));
                    LayoutDetail = LayoutDetail.Replace("@VIEW", objModel.SizeView);
                }
                else
                {
                    if (LayoutContext[i].Contains("@JOBNAME"))
                    {
                        LayoutDetail = LayoutContext[i].Replace("@JOBNAME", objConfigM.JobName);
                    }
                    else
                    {
                        if (LayoutContext[i].Contains("@PROGRAMNAME"))
                        {
                            LayoutDetail = LayoutContext[i].Replace("@PROGRAMNAME", ReplaceProgramName(objModel.ProgramName));
                        }
                        else
                        {
                            if (LayoutContext[i].Contains("@LANE"))
                            {
                                LayoutDetail = LayoutContext[i].Replace("@LANE", objConfigM.LANE);
                            }
                            else
                            {
                                if (LayoutContext[i].Contains("@VIEW"))
                                {
                                    LayoutDetail = LayoutContext[i].Replace("@VIEW", objModel.SizeView);
                                }
                                else
                                {
                                    LayoutDetail = LayoutContext[i];
                                }
                            }

                        }
                    }

                }



                sTempFileName = @"d:\temp\" + FileName;
                StreamWriter sw;

                FileInfo fi = new FileInfo(sTempFileName);

                //objProdLine.SourceFileName = sTempFileName;

                object lockObj = new object();

                if (!System.IO.File.Exists(sTempFileName))
                {
                    //fi.Create();
                    sw = new StreamWriter(sTempFileName);
                }
                else
                {
                    sw = File.AppendText(sTempFileName);
                    //sw.WriteLine(LayoutDetail, Environment.NewLine);                    
                }

                lock (lockObj)
                {
                    using (sw)
                    {
                        sw.WriteLine(LayoutDetail , Environment.NewLine);
                        sw.Flush();
                        sw.Close();
                    }
                }

                LayoutDetail = "";

            }

            Arr[0] = FileName;
            Arr[1] = sTempFileName;

            return Arr;

        }

        private String ReplaceProgramName(String ProgramName)
        {
            String sTmp = "";

            if (ProgramName.Contains("@PROLINE") == true)
            {
                sTmp = ProgramName.Replace("@PROLINE", cboProdLine.Text );
            }
            else
            {
                sTmp = ProgramName;
            }

            return sTmp;
        }

        private String ReplaceCommand(String Data, String ReplaceStr, String Command)
        {
            String sTemp = "";

            if (Data.Contains(Command) == true)
            {
                sTemp = Data.Replace(Command, ReplaceStr);
            }
            else {
                sTemp = Data;
            }

            return sTemp;

        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                String SourceFile;
                String DestinationFile;


                foreach (AutoDictModelConfigM objModel in objConfigM.ModelConfigM)
                {
                    foreach (AutoDictProdLineConfigM objprod in objModel.ProdLineM)
                    {
                        for (int i = 0; i <= dtData.Rows.Count - 1; i++)
                        {
                            if (objModel.OperName == dtData.Rows[i]["opername"].ToString())
                            {
                                SourceFile = dtData.Rows[i]["temppath"].ToString();
                                DestinationFile = objprod.Path + dtData.Rows[i]["filename"].ToString();

                                if (File.Exists(SourceFile) == true)
                                {
                                    File.Move(SourceFile, DestinationFile);
                                    dtData.Rows[i]["status"] = "UPLOADING";
                                }

                            }

                        }

                    }
                }

                tmrProcess.Enabled = true;
                btnUpload.Enabled = false;
                txtEn.Enabled = false;
                txtModel.Enabled = false;
                btnUpload.Visible = false;
                btnCancel.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void txtEn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                cboLane.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            tmrProcess.Enabled = false;
            btnUpload.Enabled = true;
            btnCancel.Enabled = false;
            btnCancel.Visible = false;
            btnUpload.Visible = true;
            txtEn.Enabled = true;
            txtModel.Enabled = true;
            txtEn.Text = "";
            txtModel.Text = "";
            lblModel.Text = "";
            lblStatus.Text = "New Upload";
            cboLane.SelectedIndex = 0;
            cboProdLine.SelectedIndex = 0;
            dtData = null;

            dtData = new DataTable();
            dtData.Columns.Add("no");
            dtData.Columns.Add("opername");
            dtData.Columns.Add("filename");
            dtData.Columns.Add("path");
            dtData.Columns.Add("temppath");
            dtData.Columns.Add("status");

            grdView.DataSource = dtData;
        }

        private void tmrProcess_Tick(object sender, EventArgs e)
        {
            String SourceFile;
            String DestinationFile;

            foreach (AutoDictModelConfigM objModel in objConfigM.ModelConfigM)
            {
                foreach (AutoDictProdLineConfigM objprod in objModel.ProdLineM)
                {
                    if (objprod.ComputerName != "N/A")
                    {
                        for (int i = 0; i <= dtData.Rows.Count - 1; i++)
                        {
                            if (objModel.OperName == dtData.Rows[i]["opername"].ToString())
                            {                                
                                DestinationFile = objprod.Path + @"\" + dtData.Rows[i]["filename"].ToString();

                                if (File.Exists(DestinationFile) == false)
                                {
                                    dtData.Rows[i]["status"] = "COMPLETED";
                                }
                            }
                        }
                        
                    }
                    else
                    {
                        for (int i = 0; i <= dtData.Rows.Count - 1; i++) 
                        {
                            if (dtData.Rows[i]["opername"].ToString() == objprod.OperName  ) 
                            {
                                if (objprod.ComputerName == "N/A")
                                {
                                    SourceFile = objprod.Path + dtData.Rows[i]["filename"].ToString();

                                    if (File.Exists(SourceFile) == false)
                                    {
                                        dtData.Rows[i]["status"] = "COMPLETED";
                                    }
                                }
                            }
                        }
                    }
                }
            }


        }

    }
}
