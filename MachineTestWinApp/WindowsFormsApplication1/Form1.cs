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
using System.Net.Http;
using System.IO;
using MachineDLL.Entities;
using MachineDLL.Entities.Traceability;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private  HSGTraceability  objMachineDLl = null;
        private MachineDLL.Machine  objMachine = null;
        private MMCTAutoPacking objPacking = null;

        IList<String> objLst;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String str;

            if (chkOffline.Checked == true)
            {
                objPacking = new MMCTAutoPacking(true, 0 , true);
                txtMsg.Text = "Offline Mode: mode = normal";
            }
            else
            {
                if (checkBox1.Checked == true)
                {
                    objPacking = new MMCTAutoPacking(false, 1 , true);
                    txtMsg.Text = "Online Mode: mode = SI";
                }
                else
                {
                    objPacking = new MMCTAutoPacking(false, 0 , true);
                    txtMsg.Text = "Online Mode: mode = normal";
                }

                str = objMachineDLl.ConnectDatabase();
                txtMsg.Text = str;
            }
                        
        }

        private void txtRuncard_TextChanged(object sender, EventArgs e)
        {

        }
      
        private void Form1_Load(object sender, EventArgs e)
        {
            //MachineDLL.ToolingManagement objTooling = new MachineDLL.ToolingManagement ();

            //String str =  objTooling.CheckToolingStatus("NJXXX-D1A-01", "NJXXX");

            if (chkOffline.Checked == true)
            {
                //objMachineDLl = new HHGTraceability(false);
                objMachineDLl = new HSGTraceability(true);
            }
            else
            {
                //objMachineDLl = new HHGTraceability(true);
                objMachineDLl = new HSGTraceability(false);
            }
        }

        private void txtRuncard_KeyPress(object sender, KeyPressEventArgs e)
        {
            String[] str;
            try
            {

                //55531608
                if (e.KeyChar == 13)
                {
                    if (txtRuncard.Text != "")
                    {
                        //Arr[0] = "OK";
                        //Arr[1] = "H201400001";
                        //Arr[2] = "NT0xxxx";
                        //Arr[3] = "200";
                        //Arr[4] = "jobname1";
                        //Arr[5] = "400";
                        //Arr[6] = "jobname2";
                        //Arr[7] = "250";
                        /*
                        if (checkBox1.Checked == true)
                        {
                            int j = 5;
                            str = objPacking.GetSIBundleDetail(txtRuncard.Text, "aaaa");
                            lblModel.Text = str[2];
                            lblJobsize.Text = str[3];

                            for (int i = 0; i <= Convert.ToInt16(str[4]); i++)
                            {
                                txtMsg.Text += "\\n jobname" + Convert.ToString(i + 1) + str[j];
                                j = j + 1;
                                txtMsg.Text += "\\n qty" + Convert.ToString(i + 1) + str[j];
                                j = j + 1;
                            }

                            txtMsg.Text += "\\n Select Runcard completed";

                        }
                        else
                        {
                            str = objPacking.IsValidJobBuild (txtRuncard.Text);

                            if (str[0] != "OK")
                            {
                                txtMsg.Text += "\\n Error:" + str[0];                                
                            }
                            else
                            {
                                txtMsg.Text += "\\n BundleNo:" + objPacking.GetBundleNo();
                                txtMsg.Text += "\\n OK Jobname:" + txtRuncard.Text + ":" +str[3];
                            }
                        }

    */

                        //str = objPacking.IsValidJob("aaa");

                        //if (str[0] == "OK")
                        //{
                        //    str[0] = "OK";

                        //    lblModel.Text = str[1];
                        //    lblJobsize.Text = str[3];
                        //}

                        //txtMsg.Text += "\\n Select Runcard completed";
                        //str = objPacking.IsValidJob(txtRuncard.Text);
                        ////str = objMachineDLl.getJobinfo (txtRuncard.Text , txtRemain.Text );
                        //if (str[0] == "OK")
                        //{
                        //    lblModel.Text = str[1];
                        //    lblJobsize.Text = str[3]
                        //}
                        //else
                        //{
                        //    txtMsg.Text += str[0];
                        //}
                        
                        //lblCpn.Text = str[0];
                        //lblJobsize.Text = str[2];
                        //lblMaster2D.Text = str[3];
                        //lblModel.Text = str[4];
                        //lblPanelSize.Text = str[6];
                        //txtRemain.Text   = str[7];

                        //txtMsg.Text += "\\n Select Runcard completed";

                    }
                }

            }
            catch (Exception ex)
            {
                txtMsg.Text += ex.Message;
            }
        }

        private void chkOffline_CheckedChanged(object sender, EventArgs e)
        {
            objMachineDLl = null;

            if (chkOffline.Checked == true)
            {                
                objMachineDLl = new HSGTraceability(true);
            }
            else
            {
                objMachineDLl = new HSGTraceability(false);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                
                //objPacking.StartRead2D(300 , "aaaa", "aaaa", 15);

                //txtMsg.Text += "\\n StartRead2D packing: 200 , en:aaaa ,testerno:aaa, traysize = 15 ";

                DateTime startdte = DateTime.Now; 

                int x;

                x = 5000;

                objMachineDLl.getJobinfo("58144410", "aaa");

                //for (int j = 0; j <= x; j++)
                //{

                //objMachineDLl.IsValidJob("TEST", "58074168");
                
                    
                //objMachineDLl.StartRead("58074647", 5000, x , 5000) ;

                    String sPanelNo = "";

                txtMsg.Text += "Start Generate 2DDate:" + DateTime.Now  + "\r\n";
                String[] str = objMachineDLl.get2DLabelsHSG(ref sPanelNo);
                txtMsg.Text += "End Function:" + DateTime.Now  + "\r\n";

                objLst = new List<String>();

                for (int i = 0; i <= str.Length - 1; i++)
                {
                    objLst.Add(str[i]);
                    txtMsg.Text += str[i] + "\r\n";
                }


                x = x - 1;

                   label2.Text = x.ToString ();
                   label3.Text = (DateTime.Now - startdte).ToString();

                //}


            }
            catch (Exception ex)
            {
                txtMsg.Text += ex.Message  + "\r\n";
            }
                

            //objMachineDLl.get2DLabelsHSG( );

        }

        private void button3_Click(object sender, EventArgs e)
        {
            String[] arr = new String[15];
            String[] str;

            for (int i = 0; i <= arr.Length - 1; i++)
            {
                if (i == 5)
                {
                    arr[i] = "aaa" + i.ToString() + ":" + "D";
                }
                else
                {
                    arr[i] = "aaa" + i.ToString() + ":" + "A";
                }                
                
            }

            str =  objPacking.Validated2d(arr);

            for (int i = 0; i <= str.Length - 1; i++)
            {
                txtMsg.Text += str[i] + "\r\n";
            }

            //txtMsg.Text += objMachineDLl.ConfirmPrint() + "\r\n";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String[] Arr2D = new string[objLst.Count];
            String[] Grade = new string[objLst.Count];

            for (int i = 0; i <= objLst.Count - 1; i++)
            {
                Arr2D[i] = objLst[i];
                Grade[i] = "F";
            }
            String[] str = objMachineDLl.Verify2D(Arr2D , Grade);


            for (int i = 0; i <= str.Length - 1; i++)
            {            
                txtMsg.Text += str[i] + "\r\n";
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            string[] str;

            txtRemain.Text = objMachineDLl.UpdateRemain();

            str = objMachineDLl.getJobinfo(txtRuncard.Text, txtRemain.Text);

            lblCpn.Text = str[0];
            lblJobsize.Text = str[2];
            lblMaster2D.Text = str[3];
            lblModel.Text = str[4];
            lblPanelSize.Text = str[6];
            //txtRemain.Text = str[7];

        }

        private void button6_Click(object sender, EventArgs e)
        {
            MachineDLL.HHGTraceability objHHG = new HHGTraceability(false);

            try
            {
                objHHG.ConnectDatabase();

                MessageBox.Show(objHHG.getJigsawResult1(507314));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            HHGTraceability objHHG = new HHGTraceability();


            //objHHG.SerialRead ()

            //objMachine = new MachineDLL.Machine ();

            //objMachine.UploadFile("e:\\AS_PP Daily Check Sheet Format01.xls" , "HWT" ) ;


        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string[] str;

            //55531608
            if (e.KeyChar == 13)
            {
                if (textBox1.Text != "")
                {
                    str = objPacking.IsValidJobBuild(textBox1.Text);

                    if (str[0] != "OK")
                    {
                        txtMsg.Text += "\\n Error:" + str[0];
                        //txtMsg.Text += "\\n BundleNo:" + objPacking.GetBundleNo();
                    }
                    else {
                        txtMsg.Text += "\\n jobname:" + textBox1.Text + ":" + str[3];
                    }

                }
            }
                



        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            string[] str;

            if (e.KeyChar == 13)
            {
                if (textBox2.Text != "")
                {
                    str = objPacking.IsValidJobBuild(textBox2.Text);
                    if (str[0] != "OK")
                    {
                        txtMsg.Text += "\\n Error:" + str[0];
                    }
                    else {
                        txtMsg.Text += "\\n jobname:" + textBox2.Text + ":" + str[3];
                    }

                }
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            string[] str;

            if (e.KeyChar == 13)
            {
                if (textBox3.Text != "")
                {
                    str = objPacking.IsValidJobBuild(textBox3.Text);
                    if (str[0] != "OK")
                    {
                        txtMsg.Text += "\\n Error:" + str[0];
                    }
                    else
                    {
                        txtMsg.Text += "\\n jobname:" + textBox3.Text + ":" + str[3];
                    }

                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            HSGTraceability objHsg = new HSGTraceability(false );
            JobBySerialsM  objJobM  = objHsg.GetHSG2DLasermark("58330795", @"d:\test.json");
        }

        private void button9_Click(object sender, EventArgs e)
        {

            MachineDLL.HSGTraceability obj = new MachineDLL.HSGTraceability(true);

            try
            {
                obj.CopyJobFile();
            }
            catch (Exception ex)
            {

            }
        }

    }
}
