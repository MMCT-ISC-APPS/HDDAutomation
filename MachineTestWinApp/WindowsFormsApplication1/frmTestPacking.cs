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

namespace WindowsFormsApplication1
{
    public partial class frmTestPacking : Form
    {

        private MMCTAutoPacking objPAcking;//= new MMCTAutoPacking( true , true);

        public frmTestPacking()
        {
            InitializeComponent();
        }

        private void frmTestPacking_Load(object sender, EventArgs e)
        {
            //TextBox2.Text += "\\n Connect Database:" + objPAcking.ConnectDatabase();
            TextBox2.Text += "\\n\\r None 2D";
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            //String[] str = objPAcking.GetBundleNo("NS");
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                string[] Arr = objPAcking.IsValidJobBuild(TextBox1.Text);

                if (Arr[0] == "OK")
                {
                    TextBox3.Text = Arr[1];
                    TextBox4.Text = Arr[2];
                    TextBox25.Text = Arr[3];
                    TextBox24.Text = Arr[3];
                    TextBox23.Text = Arr[3];
                    txtPackSize.Text = objPAcking.PackingSize().ToString() ;
                    txtBundle.Text = objPAcking.GetBundleNo();
                }
                else {
                    TextBox2.Text += "\\n\\r " + Arr[0];
                }

            }
        }

        private void TextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button8_Click(object sender, EventArgs e)
        {
            String str;


            if (chkOffline.Checked == true)
            {
                 objPAcking = new MMCTAutoPacking(false, 1, true);
                 TextBox2.Text = "Offline Mode: mode = SI";
            }
            else
            {
                if (chkOffline.Checked == true)
                {
                    objPAcking = new MMCTAutoPacking(false, 1, true);
                    TextBox2.Text = "Online Mode: mode = SI";
                }
                else
                {
                    objPAcking = new MMCTAutoPacking(false, 0, true);                     
                    TextBox2.Text = "Online Mode: mode = Normal";
                }

                // str = objMachineDLl.ConnectDatabase();
                //txtMsg.Text = str;

            }

            TextBox2.Text += "\\n Connect Database:" + objPAcking.ConnectDatabase();

        }

        private void Button6_Click(object sender, EventArgs e)
        {

        }

        private void Button11_Click(object sender, EventArgs e)
        {
            if (objPAcking.CompletePacking() == "OK")
            {
                TextBox2.Text += "\\n\\r Completed";
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            string[] Arr = TextBox6.Text.Split(new[] { "\r\n", "\r", "\n" },
                StringSplitOptions.None);

            string[] str = objPAcking.Validated2d(Arr);

            for (int i = 0; i <= str.Length - 1; i++)
            {
                TextBox2.Text += "\\r\\n " + str[i]+ Environment.NewLine;
            }

            TextBox35.Text = objPAcking.GetJobCounterFromTempTable(txtBundle.Text);

        }

        private void TextBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            String[] str;
            try
            {
                //55531608
                if (e.KeyChar == 13)
                {
                    if (TextBox8.Text != "")
                    {

                        //Arr[0] = "OK";
                        //Arr[1] = "H201400001";
                        //Arr[2] = "NT0xxxx";
                        //Arr[3] = "200";
                        //Arr[4] = "jobname1";
                        //Arr[5] = "400";
                        //Arr[6] = "jobname2";
                        //Arr[7] = "250";
                        if (chkOffline.Checked == true)
                        {
                            int j = 5;
                            str = objPAcking.GetSIBundleDetail(TextBox8.Text, "aaaa");
                            TextBox9.Text = str[2];
                            TextBox35.Text = str[3];

                            for (int i = 0; i <= Convert.ToInt16(str[4]); i++)
                            {
                                TextBox2.Text += "\\n jobname" + Convert.ToString(i + 1) + str[j];
                                j = j + 1;
                                TextBox2.Text += "\\n qty" + Convert.ToString(i + 1) + str[j];
                                j = j + 1;
                            }

                            TextBox2.Text += "\\n Select Runcard completed";

                        }
                        else
                        {
                            str = objPAcking.IsValidJobBuild(TextBox8.Text);
                            if (str[0] != "OK")
                            {
                                TextBox2.Text += "\\n Error:" + str[0];
                            }
                            else
                            {
                                TextBox9.Text = str[1];
                                TextBox35.Text = str[3];
                                txtBundle.Text = objPAcking.GetBundleNo();
                                txtPackSize.Text = objPAcking.PackingSize().ToString() ;
                            }
                        }
             
                    }
                }

            }
            catch (Exception ex)
            {
                TextBox2.Text += ex.Message;
            }
        }

        private void TextBox18_KeyPress(object sender, KeyPressEventArgs e)
        {
            String[] str;
            try
            {                
                if (e.KeyChar == 13)
                {
                    if (TextBox18.Text != "")
                    {                                             
                        str = objPAcking.IsValidJobBuild(TextBox18.Text);
                        if (str[0] != "OK")
                        {
                            TextBox2.Text += "\\n Error:" + str[0];
                        }
                        else
                        {
                            TextBox14.Text = str[1];
                            TextBox34.Text = str[3];
                        }                                           
                    }
                }

            }
            catch (Exception ex)
            {
                TextBox2.Text += ex.Message;
            }
        }

        private void TextBox29_KeyPress(object sender, KeyPressEventArgs e)
        {
            String[] str;
            try
            {
                if (e.KeyChar == 13)
                {
                    if (TextBox29.Text != "")
                    {
                        str = objPAcking.IsValidJobBuild(TextBox29.Text);
                        if (str[0] != "OK")
                        {
                            TextBox2.Text += "\\n Error:" + str[0];
                        }
                        else
                        {
                            TextBox28.Text = str[1];
                            TextBox33.Text = str[3];
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                TextBox2.Text += ex.Message;
            }
        }

        private void TextBox31_KeyPress(object sender, KeyPressEventArgs e)
        {
            String[] str;
            try
            {
                if (e.KeyChar == 13)
                {
                    if (TextBox29.Text != "")
                    {
                        str = objPAcking.IsValidJobBuild(TextBox31.Text);
                        if (str[0] != "OK")
                        {
                            TextBox2.Text += "\\n Error:" + str[0];
                        }
                        else
                        {
                            TextBox30.Text = str[1];
                            TextBox32.Text = str[3];
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                TextBox2.Text += ex.Message;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            objPAcking.StartRead2D(Convert.ToInt64 (txtPackSize.Text) , "aaaa", "aaaa",  Convert.ToInt64 (TextBox7.Text ));

            TextBox2.Text += "\\n StartRead2D packing: " + txtPackSize.Text + "  , en:aaaa ,testerno:aaa, traysize =  " + TextBox7.Text;

        }

        private void textBox36_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox36_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                if (e.KeyChar == 13)
                {
                    if (textBox36.Text != "")
                    {
                        String[] str = objPAcking.GetSIBundleDetail(textBox36.Text, "aaaa");

                        if (str[0] == "OK")
                        {
                            txtBundle.Text = str[1];
                            TextBox3.Text = str[2];
                            txtPackSize.Text = str[3];

                            if (Convert.ToInt16(str[4]) == 1)
                            {
                                TextBox8.Text = str[5];
                                TextBox9.Text = str[2];
                                TextBox35.Text = str[6];
                            }
                            else
                            {
                                if (Convert.ToInt16(str[4]) == 2)
                                {
                                    // Job Name1
                                    TextBox8.Text = str[5];
                                    TextBox9.Text = str[2];
                                    TextBox35.Text = str[6];
                                    // Job Name2
                                    TextBox18.Text = str[7];
                                    TextBox14.Text = str[2];
                                    TextBox34.Text = str[8];
                                }
                                else
                                {
                                    if (Convert.ToInt16(str[4]) == 3)
                                    {
                                        // Job Name1
                                        TextBox8.Text = str[5];
                                        TextBox9.Text = str[2];
                                        TextBox35.Text = str[6];
                                        // Job Name2
                                        TextBox18.Text = str[7];
                                        TextBox14.Text = str[2];
                                        TextBox34.Text = str[8];

                                        // Job Name3
                                        TextBox29.Text = str[9];
                                        TextBox28.Text = str[2];
                                        TextBox33.Text = str[10];
                                    }
                                    else
                                    {
                                        if (Convert.ToInt16(str[4]) == 4)
                                        {
                                            // Job Name1
                                            TextBox8.Text = str[5];
                                            TextBox9.Text = str[2];
                                            TextBox35.Text = str[6];
                                            // Job Name2
                                            TextBox18.Text = str[7];
                                            TextBox14.Text = str[2];
                                            TextBox34.Text = str[8];

                                            // Job Name3
                                            TextBox29.Text = str[9];
                                            TextBox28.Text = str[2];
                                            TextBox33.Text = str[10];

                                            // Job Name4
                                            TextBox31.Text = str[11];
                                            TextBox30.Text = str[2];
                                            TextBox32.Text = str[12];
                                        }
                                    }
                                }

                            }

                        }

                    }

                }
            

            }
            catch (Exception ex)
            {
                TextBox2.Text += "\\n Error" + ex.Message ;
            }
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            String[] str  = objPAcking.GetBundleNo("TB");
            txtBundle.Text = str[0];
            txtPackSize.Text = str[1];

        }

        private void button10_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add();
            dt.Columns.Add();
            dt.Columns.Add();
            string[] Arr = TextBox6.Text.Split(new[] { "\r\n", "\r", "\n" },
                StringSplitOptions.None);

            //string[] str = objPAcking.Validated2d(Arr);

            for (int i = 0; i <= Arr.Length - 1; i++)
            {
               // TextBox2.Text += "\\r\\n " + Arr[i];
                if (Arr[i].IndexOf(':') > 0)
                {
                    String[] sResult = Arr[i].Split(':');
                     
                    dt.Rows.Add(sResult[0], sResult[1], i);
                }
                else
                { 
                    dt.Rows.Add( Arr[i], "", i);
                }
               // dt.Rows.Add(1, "Test1", "Sample1");
            }

            //dt.Rows.Add(1, "Test1", "Sample1");
            //dt.Rows.Add(2, "Test2", "Sample2");
            //dt.Rows.Add(3, "Test3", "Sample3");
            //dt.Rows.Add(4, "Test4", "Sample4");
            //dt.Rows.Add(5, "Test5", "Sample5");

            //var duplicates = dt.AsEnumerable().GroupBy(r => r[0]).Where(gr => gr.Count() > 1).ToList();
            //Console.WriteLine("Duplicate found: {0}", duplicates.Any());

            //dt.Rows.Add(1, "Test6", "Sample6");  // Duplicate on 1
            //dt.Rows.Add(1, "Test6", "Sample6");  // Duplicate on 1
            //dt.Rows.Add(3, "Test6", "Sample6");  // Duplicate on 3
            //dt.Rows.Add(5, "Test6", "Sample6");  // Duplicate on 5

            var duplicates = dt.AsEnumerable().GroupBy(r => r[0]).Where(gr => gr.Count() > 1).ToList();
            if (duplicates.Any())
            {
                Console.WriteLine("Duplicate found for Classes: {0}", String.Join(", ", duplicates.Select(dupl => dupl.Key)));
                TextBox2.Text += "@" + String.Join(", ", duplicates.Select(dupl => dupl.Key));
            }


            Console.ReadLine();
        }
    }
}
