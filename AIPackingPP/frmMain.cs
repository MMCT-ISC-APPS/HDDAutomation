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

namespace AIPackingPP
{
    public partial class frmMain : Form
    {
        private MMCTAutoPacking objPacking;
        private DataTable dsData;
        private const Int64  iSheetQty = 16;
        private Int64 StandardSizeAdjust;

        public frmMain()
        {
            InitializeComponent();
        }

        private void txtJobNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                String[] str;
                String[] bundle;
                if (e.KeyChar == 13)
                {
                    if ((txtJobNo.Text != "") && (txtJobNo.Text != "Wait"))
                    {
                        str = objPacking.IsValidJob(txtJobNo.Text);

                        if (str[0] == "OK")
                        {
                            lblModel.Text = str[1];
                            lblJobQty.Text = str[3];
                            bundle = objPacking.GetBundleNo("PA");
                            lblBundleNo.Text = bundle[0];
                            //lblFixtureSize.Text = objPacking.PackingSize().ToString();
                            txtFixturesize.Text = Convert.ToString(objPacking.PackingSize() / iSheetQty) + "/" + objPacking.PackingSize().ToString();//Convert.ToString ( Convert.ToInt16(lblJobQty.Text) /10);
                            txtFixturesize.Tag = Convert.ToString(objPacking.PackingSize() / iSheetQty);
                            lblSheetQty.Text = iSheetQty.ToString();
                            StandardSizeAdjust = 0;

                            txtJobNo1.Focus();

                        }
                        else
                        {
                            throw new Exception(str[0]);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtJobNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                objPacking = new MMCTAutoPacking(false);
                
                StatusConnected();
            }
            catch (Exception ex)
            {
            }

        }

        public string getVersion()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            return version;
        }


        private void StatusConnected()
        {
            String sStatus;
            try
            {

                sStatus = objPacking.ConnectDatabase();

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

                this.Text = "Packing PP SW V." + getVersion() + " Dll v." + objPacking.GetVersion() + "API v." + objPacking.GetWebServiceVersion();

            }
            catch (Exception ex)
            {
                btnConnect.Visible = true;
                lblStatus.Text = ex.Message;                                
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                StatusConnected();
            }
            catch (Exception ex) {
            }
        }

        private void txtEn_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    if (txtEn.Text != "")
                    {
                        txtJobNo.Focus();
                    }                    
                }
            }
            catch (Exception ex) {
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnCancel.Enabled = true;
            Txt2DBarCode.ReadOnly = false;
            Txt2DBarCode.Focus();
            lblCount.Text = "0 Records" ;
            dsData = new DataTable();
            dsData.Columns.Add("no");
            dsData.Columns.Add("panelno");
            dsData.Columns.Add("status");
            dsData.Columns.Add("okqty");
            dsData.Columns.Add("ngqty");
            dsData.Columns.Add("scantime");

            lblGoodQty.Text = "0";
            lblNGQty.Text = "0";

            objPacking.StartRead2D(Convert.ToInt64(txtFixturesize.Tag), objPacking.GetComputerName(), txtEn.Text, Convert.ToInt64(txtFixturesize.Tag));

        }

        private void Txt2DBarCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void Txt2DBarCode_KeyPress(object sender, KeyPressEventArgs e)
        {

            DataRow dr;
            String sResult = "";
            int iTotalQty = 0;
            int GoodQty = 0;

            try
            {
                if (e.KeyChar == 13)
                {                  
                    if (dsData == null)
                    {
                        throw new Exception("ยังไม่ได้กดปุ่ม start (dsdata = null)");
                    }
                    else
                    {                         
                        frmConfirmQty frmConfirm = new frmConfirmQty();

                        frmConfirm.PanelNo = Txt2DBarCode.Text;

                        if (CheckDuplicate(Txt2DBarCode.Text) == true)
                        {
                            throw new Exception("ไม่สามารถยิง FPC Sheet :" + Txt2DBarCode.Text + " ได้เนื่องจาก ยิงซ้ำ");
                        }

                        frmConfirm.ShowDialog();

                        if (frmConfirm.Ok == true)
                        {
                            GoodQty = Convert.ToInt16 (iSheetQty) - frmConfirm.NGQty;

                            sResult = objPacking.ValidatedAISkipProcess(Txt2DBarCode.Text , GoodQty, frmConfirm.NGQty);

                            if (sResult != "OK")
                            {
                                throw new Exception(sResult);

                            }

                            dr = dsData.NewRow();
                            dr[0] = dsData.Rows.Count + 1;
                            dr[1] = Txt2DBarCode.Text;
                            dr[2] = "PASS";
                            dr[3] = GoodQty;
                            dr[4] = frmConfirm.NGQty;
                            dr[5] = Convert.ToString (DateTime.Today);
                            dsData.Rows.Add(dr);

                            iTotalQty = Convert.ToInt16 (iSheetQty) - Convert.ToInt16(frmConfirm.NGQty);
                            lblGoodQty.Text = Convert.ToString (Convert.ToInt16(lblGoodQty.Text) + iTotalQty);
                            lblNGQty.Text = Convert.ToString(Convert.ToInt16(lblNGQty.Text) + Convert.ToInt16(frmConfirm.NGQty));

                            Grid1.DataSource = dsData;
                            Grid1.Refresh();

                        }
                           
                        lblCount.Text = Convert.ToString (dsData.Rows.Count ) + " Records";

                        Txt2DBarCode.Text = "";
                        Txt2DBarCode.Focus();
                        dr = null;

                        //lblFixtureSize.Tag = 2;

                        if (Convert.ToInt16(txtFixturesize.Tag) == dsData.Rows.Count)
                        {
                            sResult = "COMPLETED";
                        }
                        else
                        {
                            sResult = "OK";
                        }
                                              
                        if (sResult == "COMPLETED")
                        {
                            /* 2021-02-27  Modify packing งานเศษ */
                            //objPacking.CompletePacking(dsData.Rows.Count , Convert.ToInt16 (lblGoodQty.Text) , Convert.ToInt16 (lblNGQty.Text) );
                            objPacking.CompletePacking(dsData.Rows.Count, Convert.ToInt16(lblGoodQty.Text), Convert.ToInt16(lblNGQty.Text), StandardSizeAdjust);
                            /* 2021-02-27  Modify packing งานเศษ */
                            Grid1.DataSource = null;
                            dsData = null;
                            btnStart.Enabled = true;
                            btnCancel.Enabled = false;
                            txtJobNo.Text = "";
                            txtJobNo.Focus();
                            lblModel.Text = "";
                            lblCount.Tag = "0";
                            lblCount.Text = " 0 Records";
                            lblSheetQty.Text = ""; txtFixturesize.Text = "";
                            lblJobQty.Text = ""; lblJobQty1.Text = "";
                            lblJobQty2.Text = "";


                            objPacking = null;
                            objPacking = new MMCTAutoPacking(false);
                            MessageBox.Show("Completed");
                        }

                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Boolean CheckDuplicate(String Serialno)
        {
            Boolean bDup = false;

            for (int i = 0; i <= dsData.Rows.Count - 1; i++)
            {
                if (dsData.Rows[i]["panelno"].ToString().Trim().ToUpper() == Serialno.Trim().ToUpper())
                {
                    bDup = true;
                    break;
                }
                else
                {
                    bDup = false;
                }
            }

            return bDup;

        }

        private void txtJobNo1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                String[] str;              
                if (e.KeyChar == 13)
                {
                    if ((txtJobNo1.Text != "") && (txtJobNo1.Text != "Wait"))
                    {
                        str = objPacking.IsValidJob(txtJobNo1.Text);

                        if (str[0] == "OK")
                        {
                            lblModel.Text = str[1];
                            lblJobQty1.Text = str[3];
                            StandardSizeAdjust = 0;
                        }

                        txtJobNo2.Focus();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtJobNo2_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                String[] str;
                if (e.KeyChar == 13)
                {
                    if ((txtJobNo2.Text != "") && (txtJobNo2.Text != "Wait"))
                    {
                        str = objPacking.IsValidJob(txtJobNo2.Text);

                        if (str[0] == "OK")
                        {
                            lblModel.Text = str[1];
                            lblJobQty2.Text = str[3];
                            StandardSizeAdjust = 0;
                        }

                        btnStart.Focus();

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnDel_Click(object sender, EventArgs e)
        {

        }

        private void Grid1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            Grid1.RowsDefaultCellStyle.SelectionBackColor = Color.BlanchedAlmond;
            if (e.RowIndex > -1)
                Grid1.Rows[e.RowIndex].Selected = true;
        }

        private void Grid1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            Grid1.RowsDefaultCellStyle.SelectionBackColor = Color.DimGray;
        }

        private void txtJobNo1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Grid1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataRow dr;
                String sResult = "";
                int iTotalQty = 0;
                int GoodQty = 0;

                var dataIndexNo = Grid1.Rows[e.RowIndex].Index.ToString();
                string cellValue = Grid1.Rows[e.RowIndex].Cells[1].Value.ToString();
                string cellValueNG = Grid1.Rows[e.RowIndex].Cells[4].Value.ToString();
                string cellValueGood = Grid1.Rows[e.RowIndex].Cells[3].Value.ToString();

                frmConfirmQty frmConfirm = new frmConfirmQty();

                frmConfirm.PanelNo = cellValue;
                frmConfirm.NGQty = Convert.ToInt16 (cellValueNG);

                frmConfirm.ShowDialog();

                if (frmConfirm.Ok == true)
                {
                    GoodQty = Convert.ToInt16(iSheetQty) - frmConfirm.NGQty;

                    sResult = objPacking.ValidatedAISkipProcess(cellValue, GoodQty, frmConfirm.NGQty);

                    if (sResult != "OK")
                    {
                        throw new Exception(sResult);
                    }

                    for (int i = 0; i <= dsData.Rows.Count - 1; i++)
                    {
                        dr = dsData.Rows[i];

                        if (dr[1].ToString () == cellValue)
                        {

                            dr[3] = GoodQty;
                            dr[4] = frmConfirm.NGQty;

                            break;

                        }

                    }

                    iTotalQty = Convert.ToInt16(iSheetQty) - Convert.ToInt16 (cellValueGood) - Convert.ToInt16(frmConfirm.NGQty);
                    lblGoodQty.Text = Convert.ToString(Convert.ToInt16(lblGoodQty.Text) + iTotalQty);
                    lblNGQty.Text = Convert.ToString(Convert.ToInt16(lblNGQty.Text) - Convert.ToInt16 (cellValueNG) + Convert.ToInt16(frmConfirm.NGQty));

                    Grid1.DataSource = dsData;
                    Grid1.Refresh();

                }

                lblCount.Text = Convert.ToString(dsData.Rows.Count) + " Records";

                Txt2DBarCode.Text = "";
                Txt2DBarCode.Focus();
                dr = null;

                //lblFixtureSize.Tag = 2;

                if (Convert.ToInt16(txtFixturesize.Tag) == dsData.Rows.Count)
                {
                    sResult = "COMPLETED";
                }
                else
                {
                    sResult = "OK";
                }

                if (sResult == "COMPLETED")
                {
                     
                    objPacking.CompletePacking(dsData.Rows.Count, Convert.ToInt16(lblGoodQty.Text), Convert.ToInt16(lblNGQty.Text), StandardSizeAdjust);
                    Grid1.DataSource = null;
                    dsData = null;
                    btnStart.Enabled = true;
                    btnCancel.Enabled = false;
                    txtJobNo.Text = "";
                    txtJobNo.Focus();
                    lblModel.Text = "";
                    lblCount.Tag = "0";
                    lblCount.Text = " 0 Records";
                    lblSheetQty.Text = ""; txtFixturesize.Text = "";
                    lblJobQty.Text = ""; lblJobQty1.Text = "";
                    lblJobQty2.Text = "";

                    objPacking = null;
                    objPacking = new MMCTAutoPacking(false);
                    MessageBox.Show("Completed");
                }

            }


        }

        private void Grid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtEn_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFixturesize_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFixturesize_Enter(object sender, EventArgs e)
        {
            
        }

        private void ReviseFixtureSize()
        {
            if (Convert.ToInt16 ( txtFixturesize.Text) != Convert.ToInt16 (txtFixturesize.Tag))
            {
                if (MessageBox.Show("ต้องการเปลี่ยนจำนวนใช่ไหม", "Confirm",  MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    txtFixturesize.Tag = txtFixturesize.Text;

                    txtFixturesize.Text = txtFixturesize.Tag + "/" + Convert.ToInt16(txtFixturesize.Tag) * Convert.ToInt16(lblSheetQty.Text);
                    StandardSizeAdjust = Convert.ToInt16(txtFixturesize.Tag) * Convert.ToInt16(lblSheetQty.Text);
                    //objBundleInfo.StandardSize


                }
            }



        }

        private void txtFixturesize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ReviseFixtureSize();
                btnStart.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            objPacking = new MMCTAutoPacking(false);
            txtEn.Text = "";
            txtJobNo.Text = "Wait";
            txtJobNo1.Text = "Wait";
            txtJobNo2.Text = "Wait";
            lblBundleNo.Text = "";
            txtFixturesize.Text = "";
            lblSheetQty.Text = "";


        }
    }
}
