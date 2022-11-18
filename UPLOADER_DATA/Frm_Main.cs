using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MachineDLL;

namespace UPLOAD_FILE
{
    public partial class Frm_Main : Form
    {
        String PF_ECHECK = @"D:\E-Check\";
        String PF_ICT = @"D:\ICT\";
        String PF_FCT = @"D:\FCT\";
        String PF_YAG = @"D:\YAG\";
        String PF_IPULSE = @"D:\IPULSE\";

        String ConDB = "Data Source=prdsvr;Initial Catalog=MC_CONTROL;User ID=sa;Password=P@ssw0rd";
        String ConDB_B = "Data Source=prdsvr;Initial Catalog=dflex;User ID=sa;Password=P@ssw0rd";
        String ConDB_AI = "Data Source=prdsvr;Initial Catalog=autodb;User ID=sa;Password=P@ssw0rd";
        String ConDB_HDD_HWT = @"Data Source=192.168.236.129\hdd;Initial Catalog=HWT;User ID=sa;Password=P@ssw0rd";
        //String ConDB_HDD_HWT = @"Provider=SQLOLEDB.1;Password=P @ssw0rd; Persist Security Info=True;User ID = sa;;Password=P@ssw0rd; Initial Catalog = HWT; Data Source = 192.168.236.129\hdd";
        String ConDB_HDD_HGST = @"Data Source=prdsvrb\hdd;Initial Catalog=HGSTVericode;User ID=sa;Password=P@ssw0rd";
        String ConDB_FP = "Data Source=prdsvr;Initial Catalog=FPDB;User ID=sa;Password=P@ssw0rd";
        String ConDB_PP = "Data Source=prdsvr;Initial Catalog=PPDB;User ID=sa;Password=P@ssw0rd";
        //String Path_File = @"F:\E-Check\";

        String Path_File_OK = @"C:\";
        String Path_File_ERROR = @"C:\";
        String Path_File_TEMP = @"C:\";
        String Path_File_PC = @"C:\";
        String Path_File_MC = @"C:\";
        String Path_File_BK = @"C:\";
        String Path_File_SVR = @"\\FCTDATA\";

        String ProductType = "";
        String UploadType = "";
        String ModelType = "";

        ClassDB db = new ClassDB();

        private String sProgramName = "Uploader";
        private MachineDLL.Machine  objMachine;
        private String ServerPath;

        String[] PC_CLINE;
        String[] MC_CLINE;

        Int32 PC_CREAD = 0;
        Int32 MC_CREAD = 0;

        Int32 R_READ = 0;
        Int32 R_PASS = 0;
        Int32 R_FAIL = 0;
        Int32 R_TOTAL = 0;
        Int32 R_ERROR = 0;

        String T_File = "";
        Int32 T_READ = 0;
        Int32 T_PASS = 0;
        Int32 T_FAIL = 0;
        Int32 T_ERROR = 0;

        String H1_NAME = "-";
        Int32 H1_READ = 0;
        Int32 H1_TOTAL = 0;
        Int32 H1_PASS = 0;
        Int32 H1_FAIL = 0;
        Int32 H1_ERROR = 0;

        String H2_NAME = "-";
        Int32 H2_READ = 0;
        Int32 H2_TOTAL = 0;
        Int32 H2_PASS = 0;
        Int32 H2_FAIL = 0;
        Int32 H2_ERROR = 0;

        DataTable DT;
        DataTable DTS;
        DataTable TMP_DT;

        Int32 ROW_POINT = 0;
        Int32 SERIALNO_POINT = 0;
        Int32 LINER_POINT = 0;
        Int32 RESULT_POINT = 0;
        Int32 DATE_POINT = 0;
        Int32 TIME_POINT = 0;
        Int32 SERIALNO_LENGTH = 0;
        Int32 LINER_LENGTH = 0;
        Int32 HEAD_POINT = 0;
        Int32 TIME_COUNT = 0;

        String REWORK_2D_MATCHING = "OFF";
        String REWORK_LINER_MATCHING = "OFF";

        String P_RELOAD = "N";
        String P_BACKUP = "N";
        String P_GROUP = "N";
        Double P_VERSION = 0.0;

        String M_Error_MC = "";
        String M_Error_PC = "";

        String TMP_PANEL = "";
        String TMP_JOBNAME = "";

        String TMP_SQL = "";

        String TMP_CHANGE = "OFF";
        String TMP_SETUP = "OFF";

        Color TMP_Color = Color.LightGreen;

        String Cur_DATE = DateTime.Now.ToString("ddMMyyyy");
        public Frm_Main()
        {
            InitializeComponent();
        }

        public string getVersion()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            return version;
        }


        private void btnStatus_Click(object sender, EventArgs e)
        {
            if (btnStatus.Text == "Save")
            {
                db.TSql = "INSERT INTO [PRDSVR].[MC_CONTROL].[dbo].[MACHINE_STATUS]([MACHINE_NAME],[BU_TYPE],[UPLOAD_TYPE],[MODEL_TYPE],[UPDATE_DATE],[UPDATE_TIME]) VALUES('" + txtTestNo.Text.Trim() + "','" + cbProductType.SelectedItem.ToString() + "','" + cbUploadType.SelectedValue.ToString() + "','" + cbModel.SelectedValue.ToString() + "','" + DateTime.Now.ToString("ddMMyyyy") + "','" + DateTime.Now.ToString("hhmmss") + "')";
                if (db.UpdateDataSql(ConDB) == 1)
                {
                    this.Close();
                }
            }
            else
            {
                db.TSql = "UPDATE [PRDSVR].[MC_CONTROL].[dbo].[MACHINE_STATUS] SET [MACHINE_STATUS] = 'CONNECT' WHERE [MACHINE_NAME] = '" + txtTestNo.Text.Trim() + "'";
                db.UpdateDataSql(ConDB);

                if (TM01.Enabled)
                {
                    btnStatus.Text = "Disconnect";
                    btnStatus.BackColor = Color.LightYellow;
                    btnStatus.Enabled = false;
                    TM01.Enabled = false;

                    this.ControlBox = true;
                    if (btnUploadType.Text == "FCT")
                    {
                        if (btnBuType.Text == "HDD")
                        {
                            if (txtTestNo.Text.Trim().Contains("TESTER") == true)
                            {
                                txtFCT_EN_FCT_HDD_SVR.Text = "";
                                txtFCT_EN_FCT_HDD_SVR.Focus();
                                txtFCT_EN_FCT_HDD_SVR.BackColor = SystemColors.Window;

                                button144.BackColor = SystemColors.Control;
                                button147.BackColor = SystemColors.Control;
                                button129.BackColor = SystemColors.Control;
                                button146.BackColor = SystemColors.Control;
                                button148.BackColor = SystemColors.Control;
                                button110.BackColor = SystemColors.Control;
                                button21.BackColor = SystemColors.Control;
                            }
                            else
                            {
                                txtFCT_EN_FCT_HDD.Text = "";
                                txtFCT_EN_FCT_HDD.Focus();
                                txtFCT_EN_FCT_HDD.BackColor = SystemColors.Window;

                                button171.BackColor = SystemColors.Control;
                                button175.BackColor = SystemColors.Control;
                                button151.BackColor = SystemColors.Control;
                                button174.BackColor = SystemColors.Control;
                                button177.BackColor = SystemColors.Control;
                                button12.BackColor = SystemColors.Control;
                                button170.BackColor = SystemColors.Control;
                            }
                        }
                        else if (btnBuType.Text == "AI")
                        {
                            txtFCT_EN_FCT_AI.Text = "";
                            txtFCT_EN_FCT_AI.Focus();
                            txtFCT_EN_FCT_AI.BackColor = SystemColors.Window;

                            button136.BackColor = SystemColors.Control;
                            button140.BackColor = SystemColors.Control;
                            button93.BackColor = SystemColors.Control;
                            button139.BackColor = SystemColors.Control;
                            button141.BackColor = SystemColors.Control;
                            button74.BackColor = SystemColors.Control;
                            button24.BackColor = SystemColors.Control;
                        }
                        else if (btnBuType.Text == "HTS")
                        {
                            txtFCT_EN_FCT_HDD_SVR.Text = "";
                            txtFCT_EN_FCT_HDD_SVR.Focus();
                            txtFCT_EN_FCT_HDD_SVR.BackColor = SystemColors.Window;

                            button144.BackColor = SystemColors.Control;
                            button147.BackColor = SystemColors.Control;
                            button129.BackColor = SystemColors.Control;
                            button146.BackColor = SystemColors.Control;
                            button148.BackColor = SystemColors.Control;
                            button110.BackColor = SystemColors.Control;
                            button21.BackColor = SystemColors.Control;

                        }
                    }
                }
                else
                {
                    btnStatus.Text = "Connect";
                    btnStatus.BackColor = TMP_Color;
                    TM01.Enabled = true;

                    this.ControlBox = false;

                    if (btnUploadType.Text == "FCT")
                    {
                        if (btnBuType.Text == "HDD")
                        {
                            if (txtTestNo.Text.Trim().Contains("TESTER") == true)
                            {
                                button144.BackColor = TMP_Color;
                                button147.BackColor = TMP_Color;
                                button129.BackColor = TMP_Color;
                                button146.BackColor = TMP_Color;
                                button148.BackColor = TMP_Color;
                                button110.BackColor = TMP_Color;
                                button21.BackColor = TMP_Color;
                            }
                            else
                            {
                                button171.BackColor = TMP_Color;
                                button175.BackColor = TMP_Color;
                                button151.BackColor = TMP_Color;
                                button174.BackColor = TMP_Color;
                                button177.BackColor = TMP_Color;
                                button12.BackColor = TMP_Color;
                                button170.BackColor = TMP_Color;
                            }
                        }
                        else if (btnBuType.Text == "AI")
                        {
                            button136.BackColor = TMP_Color;
                            button140.BackColor = TMP_Color;
                            button93.BackColor = TMP_Color;
                            button139.BackColor = TMP_Color;
                            button141.BackColor = TMP_Color;
                            button74.BackColor = TMP_Color;
                            button24.BackColor = TMP_Color;
                        }
                        else if (btnBuType.Text == "HWT")
                        {
                            button144.BackColor = TMP_Color;
                            button147.BackColor = TMP_Color;
                            button129.BackColor = TMP_Color;
                            button146.BackColor = TMP_Color;
                            button148.BackColor = TMP_Color;
                            button110.BackColor = TMP_Color;
                            button21.BackColor = TMP_Color;
                        }
                        else if (btnBuType.Text == "HTS")
                        {
                            button171.BackColor = TMP_Color;
                            button175.BackColor = TMP_Color;
                            button151.BackColor = TMP_Color;
                            button174.BackColor = TMP_Color;
                            button177.BackColor = TMP_Color;
                            button12.BackColor = TMP_Color;
                            button170.BackColor = TMP_Color;

                        }
                    }
                }
            }
        }

        private void TM01_Tick(object sender, EventArgs e)
        {
            TM01.Enabled = false;
            if (btnUploadType.Text == "FCT")
            {
                try
                {
                    if (btnBuType.Text == "HDD")
                    {
                        if (txtTestNo.Text.Trim().Contains("TESTER") == true)
                        {
                            bgFCT_HDD_SVR.RunWorkerAsync();
                        }
                        else
                        {
                            bgFCT_HDD.RunWorkerAsync();
                        }
                    }
                    else if (btnBuType.Text == "AI")
                    {
                        bgFCT_AI_SVR.RunWorkerAsync();
                    }
                    else if (btnBuType.Text == "HWT")
                    {
                        bgFCT_HDD_SVR.RunWorkerAsync();
                    }
                    else if (btnBuType.Text == "HTS")
                    {
                        bgFCT_HDD.RunWorkerAsync();
                    }

                }
                catch (Exception ex)
                {
                    TM01.Enabled = true;
                    textErrorShow.Text = ex.Message;
                }
            }

            TM01.Enabled = true;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DesktopLocation = new Point(0, 0);
            txtTestNo.Text = System.Environment.MachineName;
            //txtTestNo.Text = "AI_TESTER_01";

            objMachine = new MachineDLL.Machine();

            this.Text = sProgramName + "(SW V" + getVersion() + " , DLL v" + objMachine.GetVersion() + " , WS v" + objMachine.GetWebServiceVersion() + ")";

            db.TSql = "SELECT * FROM MACHINE_STATUS WHERE MACHINE_NAME = '" + txtTestNo.Text + "'";
            DT = db.GetDataSql(ConDB);

            if (DT.Rows.Count >= 1)
            {
                TMP_DT = DT;
                btnBuType.Text = DT.Rows[0]["BU_TYPE"].ToString();
                btnUploadType.Text = DT.Rows[0]["UPLOAD_TYPE"].ToString();
                btnModelType.Text = DT.Rows[0]["MODEL_TYPE"].ToString();
                txt_SOURE_PATH_FILE.Text = DT.Rows[0]["SOURE_PATH_FILE"].ToString();   
                cbProductType.Visible = false;
                cbUploadType.Visible = false;
                cbModel.Visible = false;
                
                btnBuType.Visible = true;
                btnUploadType.Visible = true;
                btnModelType.Visible = true;

                if (btnBuType.Text == "HDD")
                {
                    if (txtTestNo.Text.Trim().Contains("HWT") == true) { ConDB = ConDB_HDD_HWT; }
                    else { ConDB = ConDB_HDD_HGST; }
                }
                else if (btnBuType.Text == "AI")
                {
                    ConDB = ConDB_AI;
                }
                else if (btnBuType.Text == "HWT")
                {
                    ConDB = ConDB_HDD_HWT;
                }
                else if (btnBuType.Text == "HTS")
                {
                    ConDB = ConDB_HDD_HGST;
                }

                if (btnUploadType.Text == "FCT")
                {
                    db.TSql = "SELECT * FROM [PRDSVR].[MC_CONTROL].[dbo].[MACHINE_STATUS] LEFT OUTER JOIN [dbo].[FCT_SETUP] ON MACHINE_STATUS.MODEL_TYPE COLLATE SQL_Latin1_General_CP1_CI_AS = FCT_SETUP.MODEL_TYPE COLLATE SQL_Latin1_General_CP1_CI_AS WHERE [MACHINE_NAME] = '" + txtTestNo.Text + "'";
                    DT = db.GetDataSql(ConDB);

                    if (DT.Rows.Count != 0)
                    {
                        TMP_DT = DT;
                    }

                    TMP_CHANGE = DT.Rows[0]["CHANGE_STATUS"].ToString();
                    TMP_SETUP = DT.Rows[0]["SETUP_STATUS"].ToString();
                    ROW_POINT = Convert.ToInt32(DT.Rows[0]["ROW_POINT"]);
                    SERIALNO_POINT = Convert.ToInt32(DT.Rows[0]["SERIALNO_POINT"]);
                    LINER_POINT = Convert.ToInt32(DT.Rows[0]["LINER_POINT"]);
                    RESULT_POINT = Convert.ToInt32(DT.Rows[0]["RESULT_POINT"]);
                    DATE_POINT = Convert.ToInt32(DT.Rows[0]["DATE_POINT"]);
                    TIME_POINT = Convert.ToInt32(DT.Rows[0]["TIME_POINT"]);
                    SERIALNO_LENGTH = Convert.ToInt32(DT.Rows[0]["SERIALNO_LENGTH"]);
                    LINER_LENGTH = Convert.ToInt32(DT.Rows[0]["LINER_LENGTH"]);
                    HEAD_POINT = Convert.ToInt32(DT.Rows[0]["HEAD_POINT"]);
                    P_BACKUP = DT.Rows[0]["P_BACKUP"].ToString();
                    P_RELOAD = DT.Rows[0]["P_RELOAD"].ToString();
                    P_VERSION = Convert.ToDouble(DT.Rows[0]["P_VERSION"]);
                    TIME_COUNT = Convert.ToInt32(DT.Rows[0]["TIME_COUNT"]);
                    REWORK_2D_MATCHING = DT.Rows[0]["BARCODE_MATCHING_STATUS"].ToString();
                    REWORK_LINER_MATCHING = DT.Rows[0]["LINER_MATCHING_STATUS"].ToString();

               
                    for (int i = 0; i < TMP_DT.Rows.Count; i++)
                    {
                        try
                        {
                            Path_File_MC = TMP_DT.Rows[i]["SOURE_PATH_FILE"].ToString();
                            Path_File_PC = TMP_DT.Rows[i]["CALCULATOR_PATH_FILE"].ToString();
                            Path_File_TEMP = TMP_DT.Rows[i]["DESTINATION_PATH_FILE"].ToString();
                            Path_File_OK = TMP_DT.Rows[i]["CALCULATOR_PATH_FILE"].ToString() + @"OK\";
                            Path_File_ERROR = TMP_DT.Rows[i]["CALCULATOR_PATH_FILE"].ToString() + @"ERROR\";

                            if (!Directory.Exists(Path_File_MC)) { System.IO.Directory.CreateDirectory(Path_File_MC); }
                            if (!Directory.Exists(Path_File_PC)) { System.IO.Directory.CreateDirectory(Path_File_PC); }
                            if (!Directory.Exists(Path_File_TEMP)) { System.IO.Directory.CreateDirectory(Path_File_TEMP); }
                            if (!Directory.Exists(Path_File_OK)) { System.IO.Directory.CreateDirectory(Path_File_OK); }
                            if (!Directory.Exists(Path_File_ERROR)) { System.IO.Directory.CreateDirectory(Path_File_ERROR); }

                            bool IsExistSV = db.StatusServer(ConDB);
                            bool IsExistMC = Directory.Exists(Path_File_MC);
                            bool IsExistPC = Directory.Exists(Path_File_PC);
                            bool IsExistTEMP = Directory.Exists(Path_File_TEMP);
                            bool IsExistOK = Directory.Exists(Path_File_OK);
                            bool IsExistERROR = Directory.Exists(Path_File_ERROR);
                            bool IsExistSVR = Directory.Exists(Path_File_SVR);

                            if ((IsExistSV) && (IsExistMC) && (IsExistPC) && (IsExistTEMP) && (IsExistOK) && (IsExistERROR))
                            {
                                txtAllStatus.Text = "Connect";
                                txtAllStatus.BackColor = TMP_Color;
                            }
                            else
                            {
                                txtAllStatus.Text = "Disconnect";
                                txtAllStatus.BackColor = Color.LightYellow;
                            }
                        }
                        catch (Exception)
                        {

                        }
                    }

               
                    btnBuType.BackColor = TMP_Color;
                    btnUploadType.BackColor = TMP_Color;
                    btnModelType.BackColor = TMP_Color;

                    txtTestNo.BackColor = TMP_Color;

                    if (btnBuType.Text == "HDD")
                    {
                        if (txtTestNo.Text.Trim().Contains("HWT") == true)
                        {
                            pnMain.Visible = true;
                            pnFCT_HDD.Visible = false;
                            pnFCT_HDD_SVR.Visible = true;
                            pnFCT_AI_SVR.Visible = false;

                            KeyEventArgs x = new KeyEventArgs(Keys.Enter);
                            txtFCT_EN_FCT_HDD_SVR_KeyDown(sender, x);

                            btnStatus_Click(sender, e);

                            this.Size = new System.Drawing.Size(345, 572);
                        }
                        else
                        {
                            pnMain.Visible = true;
                            pnFCT_HDD.Visible = true;
                            pnFCT_HDD_SVR.Visible = false;
                            pnFCT_AI_SVR.Visible = false;

                            this.Size = new System.Drawing.Size(345, 604);
                        }

                    }
                    else if (btnBuType.Text == "AI")
                    {
                        pnMain.Visible = true;
                        pnFCT_HDD.Visible = false;
                        pnFCT_HDD_SVR.Visible = false;
                        pnFCT_AI_SVR.Visible = true;

                        KeyEventArgs x = new KeyEventArgs(Keys.Enter);
                        txtFCT_EN_FCT_AI_KeyDown(sender, x);

                        btnStatus_Click(sender, e);

                        this.Size = new System.Drawing.Size(345, 572);
                    }
                    else if (btnBuType.Text == "HWT")
                    {
                        pnMain.Visible = true;
                        pnFCT_HDD.Visible = false;
                        pnFCT_HDD_SVR.Visible = true;
                        pnFCT_AI_SVR.Visible = false;

                        KeyEventArgs x = new KeyEventArgs(Keys.Enter);
                        txtFCT_EN_FCT_HDD_SVR_KeyDown(sender, x);

                        btnStatus_Click(sender, e);

                        this.Size = new System.Drawing.Size(345, 572);

                    }
                    else if (btnBuType.Text == "HTS")
                    {
                        pnMain.Visible = true;
                        pnFCT_HDD.Visible = true;
                        pnFCT_HDD_SVR.Visible = false;
                        pnFCT_AI_SVR.Visible = false;

                        //this.Size = new System.Drawing.Size(345, 604);
                        this.Size = new System.Drawing.Size(345, 780);

                    }

                }
            }
            else
            {
                cbProductType.Visible = true;
                cbUploadType.Visible = true;
                cbModel.Visible = true;

                btnBuType.Visible = false;
                btnUploadType.Visible = false;
                btnModelType.Visible = false;

                cbProductType.Enabled = true;
                btnStatus.Text = "Save";
            }
        }

        private void cbUploadType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbUploadType.SelectedItem.ToString() != "Select Data...")
            {
                db.TSql = "SELECT [MODEL_TYPE],[UPLOAD_TYPE] FROM [PRDSVR].[MC_CONTROL].[dbo].[MODEL_TYPE] WHERE [UPLOAD_TYPE] = '" + cbUploadType.SelectedValue.ToString() + "'";
                DT = db.GetDataSql(ConDB);
                if (DT.Rows.Count >= 1)
                {
                    cbModel.Enabled = true;
                    cbModel.DataSource = DT;
                    cbModel.ValueMember = "MODEL_TYPE";
                    cbModel.Focus();

                    cbUploadType.BackColor = TMP_Color;
                }
            }
        }

        private void cbModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbModel.SelectedItem.ToString() != "Select Data...")
            {
                cbModel.BackColor = TMP_Color;
                if (btnStatus.Text == "Save")
                {
                    btnStatus.Enabled = true;
                }
                else
                {
                    btnStatus.Enabled = false;
                }
            }
        }

        private void cbProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            db.TSql = "SELECT [UPLOAD_TYPE] FROM [PRDSVR].[MC_CONTROL].[dbo].[UPLOAD_TYPE] WHERE [BU_TYPE] = '" + cbProductType.SelectedItem.ToString() + "'";
            DT = db.GetDataSql(ConDB);
            if (DT.Rows.Count >= 1)
            {
                cbUploadType.Enabled = true;
                cbUploadType.DataSource = DT;
                cbUploadType.ValueMember = "UPLOAD_TYPE";
                cbUploadType.Focus();

                cbProductType.BackColor = TMP_Color;
            }
        }

        private void CheckAllStatus()
        {
            if (!Directory.Exists(Path_File_OK))
            {
                System.IO.Directory.CreateDirectory(Path_File_OK);
            }

            if (!Directory.Exists(Path_File_ERROR))
            {
                System.IO.Directory.CreateDirectory(Path_File_ERROR);
            }

            if (!Directory.Exists(Path_File_TEMP))
            {
                System.IO.Directory.CreateDirectory(Path_File_TEMP);
            }

            //if (!Directory.Exists(Path_File_SVR))
            //{
            //    System.IO.Directory.CreateDirectory(Path_File_SVR);
            //}

            if (!Directory.Exists(Path_File_BK))
            {
                System.IO.Directory.CreateDirectory(Path_File_BK);
            }

            bool IsExistSV = db.StatusServer(ConDB);
            bool IsExistPC = Directory.Exists(Path_File_PC);
            bool IsExistMC = Directory.Exists(Path_File_MC);
            bool IsExistSVR = Directory.Exists(Path_File_SVR);

            //if ((IsExistSV) && (IsExistPC) && (IsExistMC) && (IsExistSVR))
            if ((IsExistSV) && (IsExistPC) && (IsExistMC) && (IsExistSVR))
            {
                txtAllStatus.Text = "Connect";
                txtAllStatus.BackColor = TMP_Color;
            }
            else
            {
                txtAllStatus.Text = "Disconnect";
                txtAllStatus.BackColor = Color.LightYellow;
            }
        }

        private void Frm_Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                if (TMP_CHANGE == "ON")
                {
                    Frm_Change Frm = new Frm_Change();
                    Frm.Show();
                }
            }
            else if (e.Control && e.KeyCode == Keys.M)
            {

                if (TMP_SETUP == "ON")
                {
                    Frm_Monitor Frm = new Frm_Monitor();
                    Frm.Show();
                }
            }
            else if (e.Control && e.KeyCode == Keys.S)
            {

                if (TMP_SETUP == "ON")
                {
                    Frm_Setup Frm = new Frm_Setup();
                    Frm.Show();
                }
            }
            else if (e.Control && e.KeyCode == Keys.R)
            {
                try
                {
                    DirectoryInfo TMP_ICT = new DirectoryInfo(@"D:\ICT\");
                    FileInfo[] TMP_ICTX = TMP_ICT.GetFiles("*.csv");

                    for (int i = 0; i < TMP_ICTX.Length; i++)
                    {
                        File.Delete(@"D:\ICT\" + TMP_ICTX[i].Name.ToString().Trim());
                    }
                }
                catch (Exception)
                {
                }

                try
                {
                    DirectoryInfo TMP_ICT = new DirectoryInfo(@"D:\ICT\TEMP\");
                    FileInfo[] TMP_ICTX = TMP_ICT.GetFiles("*.csv");

                    for (int i = 0; i < TMP_ICTX.Length; i++)
                    {
                        File.Delete(@"D:\ICT\TEMP\" + TMP_ICTX[i].Name.ToString().Trim());
                    }
                }
                catch (Exception)
                {
                }

                try
                {
                    DirectoryInfo TMP_FCT = new DirectoryInfo(@"D:\FCT\");
                    FileInfo[] TMP_FCTX = TMP_FCT.GetFiles("*.csv");

                    for (int i = 0; i < TMP_FCTX.Length; i++)
                    {
                        File.Delete(@"D:\FCT\" + TMP_FCTX[i].Name.ToString().Trim());
                    }
                }
                catch (Exception)
                {
                }

                try
                {
                    DirectoryInfo TMP_FCT = new DirectoryInfo(@"D:\FCT\TEMP\");
                    FileInfo[] TMP_FCTX = TMP_FCT.GetFiles("*.csv");

                    for (int i = 0; i < TMP_FCTX.Length; i++)
                    {
                        File.Delete(@"D:\FCT\TEMP\" + TMP_FCTX[i].Name.ToString().Trim());
                    }
                }
                catch (Exception)
                {
                }

                try
                {
                    DirectoryInfo TMP_FCT = new DirectoryInfo(@"C:\E-Check\");
                    FileInfo[] TMP_FCTX = TMP_FCT.GetFiles("*.csv");

                    for (int i = 0; i < TMP_FCTX.Length; i++)
                    {
                        File.Delete(@"C:\E-Check\" + TMP_FCTX[i].Name.ToString().Trim());
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private void Frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            DirectoryInfo TMP_DPMX = new DirectoryInfo(Path_File_MC);
            FileInfo[] TMP_DPMSX = TMP_DPMX.GetFiles("*.csv");

            for (int i = 0; i < TMP_DPMSX.Length; i++)
            {
                if (UploadType == "ICT")
                {
                    if (!TMP_DPMSX[i].Name.ToString().Trim().Contains(DateTime.Now.ToString("yyyyMMdd")))
                    {
                        try
                        {
                            if (System.IO.File.ReadAllLines(Path_File_MC + TMP_DPMSX[i].Name.ToString().Trim()).Length == System.IO.File.ReadAllLines(Path_File_PC + TMP_DPMSX[i].Name.ToString().Trim()).Length)
                            {
                                File.Copy(Path_File_MC + TMP_DPMSX[i].Name.ToString().Trim(), Path_File_SVR + TMP_DPMSX[i].Name.ToString().Trim(), true);
                                File.Delete(Path_File_MC + TMP_DPMSX[i].Name.ToString().Trim());
                                File.Delete(Path_File_PC + TMP_DPMSX[i].Name.ToString().Trim());
                            }

                            objMachine = null;

                        }
                        catch (Exception)
                        {
                        }
                    }
                }
                else if (UploadType == "FCT")
                {
                    if (!TMP_DPMSX[i].Name.ToString().Trim().Contains(DateTime.Now.ToString("yyyy-MM-dd")))
                    {
                        try
                        {
                            if (System.IO.File.ReadAllLines(Path_File_MC + TMP_DPMSX[i].Name.ToString().Trim()).Length == System.IO.File.ReadAllLines(Path_File_PC + TMP_DPMSX[i].Name.ToString().Trim()).Length)
                            {
                                File.Copy(Path_File_MC + TMP_DPMSX[i].Name.ToString().Trim(), Path_File_SVR + TMP_DPMSX[i].Name.ToString().Trim(), true);
                                File.Delete(Path_File_MC + TMP_DPMSX[i].Name.ToString().Trim());
                                File.Delete(Path_File_PC + TMP_DPMSX[i].Name.ToString().Trim());
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }
        }
        

        private void button6_Click(object sender, EventArgs e)
        {

        }

      

        private void bgFCT_AI_SVR_DoWork(object sender, DoWorkEventArgs e)
        {
            TM01.Enabled = false;

            if ((H1_READ == H1_TOTAL) && (H1_READ != 0))
            {
                this.Close();
            }

            for (int j = 0; j < TMP_DT.Rows.Count; j++)
            {
                Path_File_MC = TMP_DT.Rows[j]["SOURE_PATH_FILE"].ToString();
                Path_File_TEMP = TMP_DT.Rows[j]["DESTINATION_PATH_FILE"].ToString();
                Path_File_PC = TMP_DT.Rows[j]["CALCULATOR_PATH_FILE"].ToString();

                try
                {

                    DirectoryInfo TMP_DPM = new DirectoryInfo(Path_File_MC);
                    FileInfo[] TMP_DPMS = TMP_DPM.GetFiles("*.csv");

                    for (int i = 0; i < TMP_DPMS.Length; i++)
                    {
                        try
                        {
                            File.Copy(Path_File_MC + TMP_DPMS[i].Name.ToString().Trim(), Path_File_TEMP + TMP_DPMS[i].Name.ToString().Trim(), true);
                        }
                        catch (Exception)
                        {
                        }

                        try
                        {
                            MC_CLINE = System.IO.File.ReadAllLines(Path_File_TEMP + TMP_DPMS[i].Name.ToString().Trim());
                            MC_CREAD = MC_CLINE.Length;
                        }
                        catch (Exception)
                        {
                            MC_CREAD = 0;
                        }

                        try
                        {
                            PC_CLINE = System.IO.File.ReadAllLines(Path_File_PC + TMP_DPMS[i].Name.ToString().Trim());
                            PC_CREAD = PC_CLINE.Length;
                        }
                        catch (Exception)
                        {
                            PC_CREAD = ROW_POINT;
                        }

                        if (PC_CREAD < MC_CREAD)
                        {
                            File.Copy(Path_File_TEMP + TMP_DPMS[i].Name.ToString().Trim(), Path_File_PC + TMP_DPMS[i].Name.ToString().Trim(), true);
                            PC_CLINE = System.IO.File.ReadAllLines(Path_File_PC + TMP_DPMS[i].Name.ToString().Trim());
                            T_READ = PC_CLINE.Length - PC_CREAD;

                            H1_READ = H1_READ + T_READ;
                            H1_NAME = TMP_DPMS[i].Name.ToString().Trim();

                            for (int r = PC_CREAD; r < MC_CREAD; r++)
                            {
                                String[] TMPDATA = PC_CLINE[r].Split(',');
                                if (TMPDATA.Length > 1)
                                {
                                    db.TSql = "EXEC SP_UPLOAD_FCT_AI '" + TMPDATA[SERIALNO_POINT].ToString().Trim().ToUpper() + "','" + TMPDATA[RESULT_POINT].ToString().Trim() + "','" + TMPDATA[DATE_POINT].ToString().Trim() + "','" + TMPDATA[TIME_POINT].ToString().Trim() + "','" + txtTestNo.Text.Trim().ToUpper() + "','" + txtFCT_EN_FCT_AI.Text.Trim() + "','" + TMP_DPMS[i].Name.ToString().Trim() + "','" + Path_File_SVR + TMP_DPMS[i].Name.ToString().Trim() + "','All','" + SERIALNO_LENGTH + "','" + LINER_LENGTH + "'";
                                    DT = db.GetDataSql(ConDB);
                                    if (DT.Rows[0][0].ToString() == "FAIL")
                                    {
                                        H1_TOTAL++; H1_FAIL++;
                                    }
                                    else if (DT.Rows[0][0].ToString() == "PASS")
                                    {
                                        H1_TOTAL++; H1_PASS++;
                                    }
                                    else
                                    {
                                        H1_TOTAL++; H1_ERROR++;
                                    }
                                }
                                else
                                {
                                    H1_TOTAL++; H1_ERROR++;
                                }

                                Thread.Sleep(750);
                                bgFCT_AI_SVR.ReportProgress(r);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private void bgFCT_AI_SVR_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            button136.Text = H1_NAME;
            button140.Text = H1_READ.ToString();
            button93.Text = H1_TOTAL.ToString();
            button139.Text = H1_PASS.ToString();
            button141.Text = H1_FAIL.ToString();
            button74.Text = H1_ERROR.ToString();
            button24.Text = (Convert.ToDouble((H1_PASS - H1_FAIL) * 100) / Convert.ToDouble(H1_PASS)).ToString("#,##0.00") + "%";
        }

        private void bgFCT_AI_SVR_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TM01.Enabled = true;
            if (btnStatus.Text == "Disconnect")
            {
                this.ControlBox = true;
            }
            else
            {
                this.ControlBox = false;
            }
        }

        private void txtFCT_EN_FCT_AI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtFCT_EN_FCT_AI.Text.Trim().Length > 0)
                {
                    txtFCT_EN_FCT_AI.BackColor = TMP_Color;
                    btnStatus.Enabled = true;
                }
                else
                {
                    btnStatus.Enabled = false;
                }
            }
        }

        private void bgFCT_HDD_SVR_DoWork(object sender, DoWorkEventArgs e)
        {
            TM01.Enabled = false;
            String sDestinationPAth = "";

            //if ((H1_READ == H1_TOTAL) && (H1_READ != 0))
            //{
            //    H1_READ = 0;
            //    H1_READ = 0;
            //    //this.Close();
            //}

            for (int j = 0; j < TMP_DT.Rows.Count; j++)
            {
                Path_File_MC = TMP_DT.Rows[j]["SOURE_PATH_FILE"].ToString();
                Path_File_TEMP = TMP_DT.Rows[j]["DESTINATION_PATH_FILE"].ToString();
                Path_File_PC = TMP_DT.Rows[j]["CALCULATOR_PATH_FILE"].ToString();
                //Path_File_MC = "C:\\FCT\\";
                //Path_File_TEMP = "E:\\FCT\\TEMP\\";
                //Path_File_PC = "E:\\FCT\\";

                try
                {
                    DirectoryInfo TMP_DPM = new DirectoryInfo(Path_File_MC);
                    FileInfo[] TMP_DPMS = TMP_DPM.GetFiles("*.csv");

                    for (int i = 0; i < TMP_DPMS.Length; i++)
                    {
                        try
                        {
                            sDestinationPAth = Path_File_TEMP + TMP_DPMS[i].Name.ToString().Trim();

                            File.Copy(Path_File_MC + TMP_DPMS[i].Name.ToString().Trim(), sDestinationPAth, true);

                        }
                        catch (Exception)
                        {
                        }

                        try
                        {
                            MC_CLINE = System.IO.File.ReadAllLines(sDestinationPAth);
                            MC_CREAD = MC_CLINE.Length;
                        }
                        catch (Exception)
                        {
                            MC_CREAD = 0;
                        }

                        try
                        {
                            PC_CLINE = System.IO.File.ReadAllLines(Path_File_PC + TMP_DPMS[i].Name.ToString().Trim());
                            PC_CREAD = PC_CLINE.Length;
                        }
                        catch (Exception)
                        {
                            PC_CREAD = ROW_POINT;
                        }

                        if (PC_CREAD < MC_CREAD)
                        {
                            File.Copy(sDestinationPAth, Path_File_PC + TMP_DPMS[i].Name.ToString().Trim(), true);
                            PC_CLINE = System.IO.File.ReadAllLines(Path_File_PC + TMP_DPMS[i].Name.ToString().Trim());
                            T_READ = PC_CLINE.Length - PC_CREAD;

                            H1_READ = H1_READ + T_READ;
                            H1_NAME = TMP_DPMS[i].Name.ToString().Trim();

                            //ServerPath = objMachine.UploadFile(Path_File_PC + TMP_DPMS[i].Name.ToString().Trim(), "HWT");
                            ServerPath = "";

                            for (int r = PC_CREAD; r < MC_CREAD; r++)
                            {
                                String[] TMPDATA = PC_CLINE[r].Split(',');

                                if (TMPDATA.Length > 1)
                                {

                                    db.TSql = "EXEC SP_UPLOAD_FCT_HDD '" + TMPDATA[SERIALNO_POINT].ToString().Trim().ToUpper() + "','" + TMPDATA[RESULT_POINT].ToString().Trim() + "','" + TMPDATA[DATE_POINT].ToString().Trim() + "','" + TMPDATA[TIME_POINT].ToString().Trim() + "','" + txtTestNo.Text.Trim().ToUpper() + "','" + txtFCT_EN_FCT_AI.Text.Trim() + "','" + TMP_DPMS[i].Name.ToString().Trim() + "','" + Path_File_SVR + TMP_DPMS[i].Name.ToString().Trim() + "','" + ServerPath.Trim () + "','" + SERIALNO_LENGTH + "','" + LINER_LENGTH + "'";

                                    DT = db.GetDataSql(ConDB);
                                    if (DT.Rows[0][0].ToString() == "FAIL")
                                    {
                                        H1_TOTAL++; H1_FAIL++;
                                    }
                                    else if (DT.Rows[0][0].ToString() == "PASS")
                                    {
                                        H1_TOTAL++; H1_PASS++;
                                    }
                                    else
                                    {
                                        H1_TOTAL++; H1_ERROR++;
                                    }
                                }
                                else
                                {
                                    H1_TOTAL++; H1_ERROR++;
                                }

                                //Thread.Sleep(750);
                                bgFCT_HDD_SVR.ReportProgress(r);

                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    //MC_CREAD = "0";
                    //SetText(ex.Message , sDestinationPAth);
                }
            }
        }

        private void bgFCT_HDD_SVR_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            button144.Text = H1_NAME;
            button147.Text = H1_READ.ToString();
            button129.Text = H1_TOTAL.ToString();
            button146.Text = H1_PASS.ToString();
            button148.Text = H1_FAIL.ToString();
            button110.Text = H1_ERROR.ToString();
            button21.Text = (Convert.ToDouble((H1_PASS - H1_FAIL) * 100) / Convert.ToDouble(H1_PASS)).ToString("#,##0.00") + "%";
        }

        private void bgFCT_HDD_SVR_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TM01.Enabled = true;
            if (btnStatus.Text == "Disconnect")
            {
                this.ControlBox = true;
            }
            else
            {
                this.ControlBox = false;
            }
        }

        private void txtFCT_EN_FCT_HDD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtFCT_EN_FCT_HDD.Text.Length > 0)
                {
                    txtFCT_EN_FCT_HDD.BackColor = TMP_Color;
                    txtFCT_EN_FINAL_HDD.Enabled = true;
                    txtFCT_EN_FINAL_HDD.Focus();
                }
                else
                {
                    txtFCT_EN_FINAL_HDD.Enabled = false;
                }
            }
        }

        private void txtFCT_EN_FCT_HDD_SVR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtFCT_EN_FCT_HDD_SVR.Text.Trim().Length > 0)
                {
                    txtFCT_EN_FCT_HDD_SVR.BackColor = TMP_Color;
                    btnStatus.Enabled = true;
                }
                else
                {
                    btnStatus.Enabled = false;
                }
            }
        }

        private void txtFCT_EN_FINAL_HDD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtFCT_EN_FINAL_HDD.Text.Length > 0)
                {
                    txtFCT_EN_FINAL_HDD.BackColor = TMP_Color;
                    btnStatus.Enabled = true;
                    btnStatus.Focus();
                }
                else
                {
                    btnStatus.Enabled = false;
                }
            }
        }

        private void bgFCT_HDD_DoWork(object sender, DoWorkEventArgs e)
        {
            TM01.Enabled = false;
            try
            {
                for (int j = 0; j < TMP_DT.Rows.Count; j++)
                {
                    Path_File_MC = TMP_DT.Rows[j]["SOURE_PATH_FILE"].ToString();
                    Path_File_TEMP = TMP_DT.Rows[j]["DESTINATION_PATH_FILE"].ToString();
                    Path_File_PC = TMP_DT.Rows[j]["CALCULATOR_PATH_FILE"].ToString();
                    //Path_File_MC = @"E:\FCT1\";
                    //Path_File_TEMP = "E:\\FCT\\TEMP\\";
                    //Path_File_PC = "E:\\FCT\\";

                    DirectoryInfo TMP_DPM = new DirectoryInfo(Path_File_MC);
                    FileInfo[] TMP_DPMS = TMP_DPM.GetFiles("*.csv");
                    //SetText("Start");
                    for (int i = 0; i < TMP_DPMS.Length; i++)
                    {

                        try
                        {
                            File.Copy(Path_File_MC + TMP_DPMS[i].Name.ToString().Trim(), Path_File_TEMP + TMP_DPMS[i].Name.ToString().Trim(), true);
                        }
                        catch (Exception EX)
                        {
                            throw new Exception(EX.Message);
                        }

                        try
                        {
                            MC_CLINE = System.IO.File.ReadAllLines(Path_File_TEMP + TMP_DPMS[i].Name.ToString().Trim());
                            MC_CREAD = MC_CLINE.Length;
                        }
                        catch (Exception)
                        {
                            MC_CREAD = 0;
                        }

                        try
                        {
                            PC_CLINE = System.IO.File.ReadAllLines(Path_File_PC + TMP_DPMS[i].Name.ToString().Trim());
                            PC_CREAD = PC_CLINE.Length;
                        }
                        catch (Exception)
                        {
                            PC_CREAD = ROW_POINT;
                        }

                        //SetText("PC:" + PC_CREAD.ToString() + "MC:" + MC_CREAD.ToString());

                        if (PC_CREAD < MC_CREAD)
                        {
                            //SetText("Start Upload");

                            File.Copy(Path_File_TEMP + TMP_DPMS[i].Name.ToString().Trim(), Path_File_PC + TMP_DPMS[i].Name.ToString().Trim(), true);
                            PC_CLINE = System.IO.File.ReadAllLines(Path_File_PC + TMP_DPMS[i].Name.ToString().Trim());
                            T_READ = PC_CLINE.Length - PC_CREAD;

                            H1_READ = H1_READ + T_READ;
                            H1_NAME = TMP_DPMS[i].Name.ToString().Trim();

                            if (btnBuType.Text == "HDD")
                            {
                                ServerPath = objMachine.UploadFile(Path_File_PC + TMP_DPMS[i].Name.ToString().Trim(), "HHG");
                            }else
                            {
                                ServerPath = objMachine.UploadFile(Path_File_PC + TMP_DPMS[i].Name.ToString().Trim(), btnBuType.Text);
                            }
                            

                            for (int r = PC_CREAD; r < MC_CREAD; r++)
                            {
                                String[] TMPDATA = PC_CLINE[r].Split(',');
                                if (TMPDATA.Length > 1)
                                {
                                    //db.TSql = "EXEC SP_IFCT '" + TMPDATA[SERIALNO_POINT].ToString().Trim().ToUpper() + "','" + TMPDATA[RESULT_POINT].ToString().Trim() + "','" + TMPDATA[DATE_POINT].ToString().Trim() + "','" + TMPDATA[TIME_POINT].ToString().Trim() + "','" + txtTestNo.Text.Trim().ToUpper() + "','" + txtFCT_EN_FCT_HDD.Text.Trim() + "','" + txtFCT_EN_FINAL_HDD.Text.Trim() + "','" + TMP_DPMS[i].Name.ToString().Trim() + "','" + ServerPath + "','" + btnModelType.Text.Trim() + "'";

                                    if (btnBuType.Text == "HDD")
                                    {
                                        db.TSql = "EXEC SP_IFCT_NEW '" + TMPDATA[SERIALNO_POINT].ToString().Trim().ToUpper() + "','" + TMPDATA[RESULT_POINT].ToString().Trim() + "','" + TMPDATA[DATE_POINT].ToString().Trim() + "','" + TMPDATA[TIME_POINT].ToString().Trim() + "','" + txtTestNo.Text.Trim().ToUpper() + "','" + txtFCT_EN_FCT_HDD.Text.Trim() + "','" + txtFCT_EN_FINAL_HDD.Text.Trim() + "','" + TMP_DPMS[i].Name.ToString().Trim() + "','" + ServerPath + "','" + btnModelType.Text.Trim() + "' ,  '" + TMPDATA[8].ToString().Trim() + "'";
                                    }
                                    else
                                    {
                                        db.TSql = "EXEC SP_IFCT '" + TMPDATA[SERIALNO_POINT].ToString().Trim().ToUpper() + "','" + TMPDATA[RESULT_POINT].ToString().Trim() + "','" + TMPDATA[DATE_POINT].ToString().Trim() + "','" + TMPDATA[TIME_POINT].ToString().Trim() + "','" + txtTestNo.Text.Trim().ToUpper() + "','" + txtFCT_EN_FCT_HDD.Text.Trim() + "','" + txtFCT_EN_FINAL_HDD.Text.Trim() + "','" + TMP_DPMS[i].Name.ToString().Trim() + "','" + ServerPath + "','" + btnModelType.Text.Trim() + "'";
                                    }
                                    
                                    DT = db.GetDataSql(ConDB);

                                    if (DT.Rows[0][0].ToString() == "PASS")
                                    {
                                        H1_TOTAL++;
                                        H1_PASS++;
                                    }
                                    else if (DT.Rows[0][0].ToString() == "FAIL")
                                    {
                                        H1_TOTAL++;
                                        H1_FAIL++;
                                    }
                                    else
                                    {
                                        H1_TOTAL++;
                                        H1_ERROR++;
                                    }
                                }
                                else
                                {
                                    H1_TOTAL++;
                                    H1_ERROR++;
                                }

                                Thread.Sleep(750);

                                bgFCT_HDD.ReportProgress(r);

                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                textErrorShow.Text = ex.Message;
                SetText(ex.Message , "" );
                
            }


        }

        delegate void SetTextCallback(string text , string sPath);

        private void SetText(string text , string sPath)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.txtAllStatus.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText );
                this.Invoke(d, new object[] { text , sPath });
            }
            else
            {
                this.txtAllStatus.Text = text;
                if (sPath != "")
                {
                    File.Delete(sPath);
                }                
            }
        }

        private void bgFCT_HDD_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            button171.Text = H1_NAME;
            button175.Text = H1_READ.ToString();
            button151.Text = H1_TOTAL.ToString();
            button174.Text = H1_PASS.ToString();
            button177.Text = H1_FAIL.ToString();
            button12.Text = H1_ERROR.ToString();
            button170.Text = (Convert.ToDouble((H1_PASS - H1_FAIL) * 100) / Convert.ToDouble(H1_PASS)).ToString("#,##0.00") + "%";
        }

        private void bgFCT_HDD_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TM01.Enabled = true;
            if (btnStatus.Text == "Disconnect")
            {
                this.ControlBox = true;
            }
            else
            {
                this.ControlBox = false;
            }

        }

        private void pnMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
