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
using System.IO;
using System.Data.SqlClient;
using MachineDLL.Common;

namespace WindowsFormsApplication1
{
    public partial class FormTestMachineDll : Form
    {

        private Machine objMachine ;
        MachineDLL.HHGTraceability objHHG;
        delegate void SetTextCallback(string text);
        delegate void SetResultTextCallback(string text);
        delegate void SetErrorTextCallback(string text);

        
        public FormTestMachineDll()
        {
            InitializeComponent();
        }

        private void SetErrorText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.        

            try
            {
                if (this.textBox2.InvokeRequired)
                {
                    SetErrorTextCallback d = new SetErrorTextCallback(SetErrorText);
                    this.Invoke(d, new object[] { text });
                }
                else
                   // sBarcode = barcode
                   // If Not (text.Contains("ERROR")) Then
                   if (text.ToUpper().Trim() != textBox2.Text.ToUpper().Trim())
                {
                    Application.DoEvents();
                    // ClearData()
                    textBox2.Text = text;
                }
            }
            // End If

            catch (Exception ex)
            {
                //Interaction.MsgBox("Err Desc:" + ex.Message);
            }
        }
        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.        

            try
            {
                if (this.textBox1.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetText);
                    this.Invoke(d, new object[] { text });
                }
                else
                   // sBarcode = barcode
                   // If Not (text.Contains("ERROR")) Then
                   if (text.ToUpper().Trim() != textBox1.Text.ToUpper().Trim())
                {
                    Application.DoEvents();
                    // ClearData()
                    textBox1.Text = text;
                }
            }
            // End If

            catch (Exception ex)
            {
                //Interaction.MsgBox("Err Desc:" + ex.Message);
            }
        }

        private void SetResultText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.        

            try
            {
                if (this.txtMsg.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetResultText);
                    this.Invoke(d, new object[] { text });
                }
                else
                   // sBarcode = barcode
                   // If Not (text.Contains("ERROR")) Then
                   if (text.ToUpper().Trim() != txtMsg.Text.ToUpper().Trim())
                {
                    
                    Application.DoEvents();
                    // ClearData()
                    txtMsg.Text += "\\r\\n " + text;
                }
            }
            // End If

            catch (Exception ex)
            {
                //Interaction.MsgBox("Err Desc:" + ex.Message);
            }
        }

        private void FormTestMachineDll_Load(object sender, EventArgs e)
        {
            objHHG = new MachineDLL.HHGTraceability(false);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        //    if (chkOffline.Checked == true)
        //    {
        //        objMachine = new Machine(false);
        //    }
        //    else
        //    {
        //        objMachine = new Machine( true);
        //    }

        //    txtMsg.Text =  objMachine.ConnectDatabase();
        //    txtMsg.Text += "\\n\\r Version" + objMachine.GetVersion() + objMachine.GetWebServiceVersion() ;
            //objMachine.getre
        }

        private void button2_Click(object sender, EventArgs e)
        {
            JobinfoM objJobM = new JobinfoM();            

            DataTable dt;

            objJobM.ModelName = "AQ-B";
            objJobM.PrefixCust = "HTS";
            objJobM.Prefix2D = "M1";
            objJobM.UserNo = "1111";

            objJobM.TotalQtyBarcode = Convert.ToInt64("100");

            objJobM.CustomerName = "HTS";
            objJobM.PrinterName = @"\\songdechs\\sato_hr224";

            dt =  objMachine.Generate2DBarcode(ref objJobM);

            //txtMsg.Text += "\\n" + objMachine.DoTestResult("XRAY", "xxx", 1, "Machine1", "NG", "", "");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String[] str = new string[9];
            MachineDLL.HHGTraceability objHHG = new MachineDLL.HHGTraceability(false);


            str = objHHG.getJobinfoM(textBox1.Text , "1A018936" , "aa");
            textQty.Text = str[2];

        }

        private void button4_Click(object sender, EventArgs e)
        {
            String sError = "";

            sError = objHHG.StartJob(textModel.Text, Convert.ToInt16( textQty.Text), textBox1.Text , Convert.ToInt16(textPanelSize.Text));

            if (sError == "OK")
            {
                txtMsg.Text += "statread OK \r\n"; 
            }
            else {
                txtMsg.Text += sError + "\r\n";
            }

            //string[] arr = new string [4];
            //DataTable dt;


            //arr[0] = "M7B6G8R01,A,100";
            //arr[1] = "M7B6G8R21,A,100";
            //arr[2] = "M7C16CP41,A,100";
            //arr[3] = "M7C16CP51,A,100";


            //objHHG.SetTotalCavitybyPanel(4);
            
            //dt = objHHG.SerialRead(arr, "AAAAA", "aaaaa");



        }

        private void button5_Click(object sender, EventArgs e)
        {
            String[] sTmp;
            sTmp = objHHG.GetSerials();

            for (int i = 0; i <= sTmp.Length - 1; i++)
            {               
                txtMsg.Text += sTmp[i] + "\r\n";
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                int Error = 0;

                foreach (string file in Directory.GetFiles(@"D:\AOIRESULT\")  )
                {
                    String sResult = File.ReadAllText(file);                    
                    string destination = Path.Combine(@"d:\aoi_error\", Path.GetFileName (file) );
                    //SetResultText(sResult);
                    if (sResult.ToUpper().Contains("RPASS") == true)
                    {
                        if (sResult.ToUpper().Contains("3D LAYER1") == true)
                        {
                            String[] Temp = file.ToLower().Split('_');

                            int Position = Convert.ToInt16(Temp[2].Substring(0, Temp[2].IndexOf(".txt")));

                            String[] Result = sResult.Split(';');
                            String sPanelID = Result[1].Trim() + "*";
                            String sPanelNo = "";
                            string[] files = Directory.GetFiles(@"d:\AOIRESULT\", sPanelID, SearchOption.AllDirectories);
                            //.Where(s => s.EndsWith("*.txt") || s.EndsWith("*.txt"));

                            foreach (String FileName in files)
                            {
                                String[] Temp1 = FileName.ToLower().Split('_');

                                int Position1 = Convert.ToInt16(Temp1[2].Substring(0, Temp1[2].IndexOf(".txt")));

                                if (Position1 == 1)
                                {
                                    String sResult1 = File.ReadAllText(FileName);
                                    String[] sTempResult = sResult1.Split(';');
                                    sPanelNo = sTempResult[1].Trim();

                                    break;
                                }
                            }


                            Error = Error + 1;
                            UpdateAOIResultByTri(sPanelNo, Position.ToString(), "3D LAYER1", sPanelID, file);
                            SetErrorText(Error.ToString());                            
                            SetResultText(sPanelNo + ";" + Position + "FAIL" + "Updated:OK");
                            File.Move(file, destination);

                        }                        
                    }
                    else if (sResult.ToUpper().Contains("RPAIR") == true)
                    {
                        String[] Temp = file.ToLower().Split('_');

                        int Position = Convert.ToInt16(Temp[2].Substring(0, Temp[2].IndexOf(".txt")));

                        String[] Result = sResult.Split(';');
                        String sPanelID = Result[1].Trim() + "*";
                        String sPanelNo = "";
                        string[] files = Directory.GetFiles(@"d:\AOIRESULT\", sPanelID, SearchOption.AllDirectories);
                        //.Where(s => s.EndsWith("*.txt") || s.EndsWith("*.txt"));

                        foreach (String FileName in files)
                        {
                            String[] Temp1 = FileName.ToLower().Split('_');

                            int Position1 = Convert.ToInt16(Temp1[2].Substring(0, Temp1[2].IndexOf(".txt")));

                            if (Position1 == 1)
                            {
                                String sResult1 = File.ReadAllText(FileName);
                                String[] sTempResult = sResult1.Split(';');
                                sPanelNo = sTempResult[1].Trim();

                                break;
                            }
                        }


                        Error = Error + 1;
                        UpdateAOIResultByTri(sPanelNo, Position.ToString(), "rpair" , sPanelID , file);
                        SetErrorText(Error.ToString());
                        SetResultText(sPanelNo + ";" + Position + "FAIL" + "Updated:OK");
                        File.Move(file, destination);

                    }

                    i = i + 1;

                    SetText(i.ToString ());

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Desc" + ex.Message);
            }
        }

        public String UpdateAOIResultByTri(String sPanelID , String Position , String sDefectCode , String sBacth , String sFileName)
        {
            DBFactory dbFactory = new DBFactory();
            dbFactory.SetDBConnString("Data Source=mmctsg2d2;Initial Catalog=Mprint2;User ID=hsm;Password=hsm;");
            SqlConnection objConn = dbFactory.GetDBConnection();

            DataSet ds = new DataSet();
            DataTable dataTbl = null;

            try
            {

                String sql = "UpdateAOIResultByTri";

                List<SqlParameter> sqlParamsIn = new List<SqlParameter>();
                sqlParamsIn.Add(dbFactory.CreateParameterInput("@Panelid", SqlDbType.NVarChar, sPanelID));
                sqlParamsIn.Add(dbFactory.CreateParameterInput("@Position", SqlDbType.VarChar, Position));
                sqlParamsIn.Add(dbFactory.CreateParameterInput("@AOIResult", SqlDbType.VarChar, "FAIL"));
                sqlParamsIn.Add(dbFactory.CreateParameterInput("@AOIDate", SqlDbType.DateTime, DateTime.Now ));
                sqlParamsIn.Add(dbFactory.CreateParameterInput("@MachineName", SqlDbType.VarChar, "Manual Update"));
                sqlParamsIn.Add(dbFactory.CreateParameterInput("@DefectCode", SqlDbType.VarChar, sDefectCode));
                sqlParamsIn.Add(dbFactory.CreateParameterInput("@Result", SqlDbType.VarChar, sBacth));
                sqlParamsIn.Add(dbFactory.CreateParameterInput("@AOIPath", SqlDbType.VarChar, sFileName));

                List<SqlParameter> sqlParamsOutput = new List<SqlParameter>();

                sqlParamsOutput.Add(dbFactory.CreateParameterOutput("@Errormsg", SqlDbType.NVarChar, 240));

                dbFactory.ExecuteNotQueryStoredProc(objConn, null, sql, sqlParamsIn.ToArray(), sqlParamsOutput.ToArray());


                if (sqlParamsOutput[0].Value.ToString() == "OK")
                {
                    return "OK";
                }
                else
                {
                    return sqlParamsOutput[0].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dbFactory.CloseConnection(objConn, ds, dataTbl);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DBFactory dbFactory = new DBFactory();
            dbFactory.SetDBConnString("Data Source=mmctsg2d2;Initial Catalog=Mprint2;User ID=hsm;Password=hsm;");
            SqlConnection objConn = dbFactory.GetDBConnection();

            String sql = "";

            foreach (string  filename in Directory.GetFiles(@"\\hdd-picsave\HSG_AOI\AOIDATA\2020\Sep\9\10.80.228.62\"))
            {
                String fileName1;

                fileName1 = Path.GetFileName(filename);

                sql = "insert into temp_aoi_check(filename , creationdate) values(@filename , '2020-09-09') ";

                List<SqlParameter> sqlParamsIn = new List<SqlParameter>();

                sqlParamsIn.Add(dbFactory.CreateParameterInput("@filename", SqlDbType.VarChar, fileName1));

                dbFactory.ExecuteNonQuerySQL(objConn, null, sql, sqlParamsIn.ToArray());

            }

            MessageBox.Show("OK");

        }

        private void txtConvert2D_Click(object sender, EventArgs e)
        {
            txtMsg.Text =  Converter.Convert(10, 33, textQty.Text);
           // txtMsg.Text = "";
           //1185920
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(textQty.Text);
            int b = 10;

            int div = a / b; //quotient is 1
            int mod = a % b; //remainder is 2
            //txtMsg.Text = Convert.ToString(Math.Round(Convert.ToDouble(Convert.ToDouble(textQty.Text) / 10), MidpointRounding.ToEven)  );
            if(mod > 0) { div = div + 1; }
            txtMsg.Text = Convert.ToString(div);

        }
    }
}
