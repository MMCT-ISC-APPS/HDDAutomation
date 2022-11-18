using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MachineDLL.Entities;
using MachineDLL;

namespace Rework2D
{
    public partial class frmSetup : Form
    {
        private Int32 iLayoutX ;
        private Int32 iLayoutY;
        private DataTable dsData;
        //private PanelInfoM objPanel;

        private ItemMasterM objItemM;
        private ItemReworkInfoM objReworkLayout;
        private ReworkProcess objRework;

        private String sTempLabel = "";

        public frmSetup()
        {             
            InitializeComponent();
            objReworkLayout = new ItemReworkInfoM();
            objRework = new ReworkProcess();
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            if (FileDi.ShowDialog() == DialogResult.OK)
            {
                lblImagePath.Text = FileDi.FileName;
            }

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtModel.Text != "")
                {
                    if (lblImagePath.Text != "" && lblImagePath.Text != "Image Path")
                    {
                        PicPanel.Image = Image.FromFile(lblImagePath.Text);
                        objReworkLayout.imgPanel = Image.FromFile(lblImagePath.Text);
                        objReworkLayout.Model = txtModel.Text;
                        objReworkLayout.Customer = "HSG";

                        objReworkLayout = objRework.SaveReworkModel(objReworkLayout);

                        PicPanel.Image = objReworkLayout.imgPanel;
                        PicPanel.Width = this.Width - grpPanelInfo.Width - 50;
                        PicPanel.Height = this.Height - PicPanel.Top - 50;
                        PicPanel.SizeMode = PictureBoxSizeMode.StretchImage;

                    }

                }
                else
                {
                    throw new Exception("Error:" + "ยังไม่ได้เลือก Model โปรดเลือก Model ก่อนเลือกรูป");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message , "Error");
            }

        }

        private void PicPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                iLayoutX = e.Location.X;
                iLayoutY = e.Location.Y;
                txtX.Text = iLayoutX.ToString() ;
                txtY.Text = iLayoutY.ToString() ;
                txtPartNo.Text = "";
                txtPosition.Text = "";
                btnCancel.Visible = false;
                txtPosition.Focus();

            }
        }

        private void ClearBuffer()
        {
            dsData = null;
            iLayoutX = 0;
            iLayoutY = 0;
            txtX.Text = iLayoutX.ToString() ;
            txtY.Text = iLayoutY.ToString() ;

            txtPartNo.Text = "";
            txtPosition.Text = "";

            btnCancel.Visible = false;
            PicPanel.Controls.Clear();

            dsData = new DataTable();

            dsData.Columns.Add("Position");
            dsData.Columns.Add("blockno");
            dsData.Columns.Add("pixelx");
            dsData.Columns.Add("pixely");

            btnAdd.Text = "Add";
            btnAdd.Tag = "0";
        }

        private bool ExisingLabelControl(string sText)
        {
            //Label Label = new Label ();
            bool bHave;

            bHave = false;
            foreach (Label  Label in PicPanel.Controls)
            {
                if (Label.Text == sText)
                {
                    bHave = true;
                    break;
                }
                else
                    bHave = false;
            }

            return bHave;
        }

        private void frmSetup_Load(object sender, EventArgs e)
        {
            try
            {
                objItemM = new ItemMasterM();
                ClearBuffer();
            }
            catch (Exception ex) {
                MessageBox.Show("Error:" + ex.Message, "Error");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                AddLayoutByControl();
            }
            catch (Exception ex)
            {
                MessageBox.Show ("Error:" + ex.Message , "Error");
            }
        }

        private void AddLayoutByControl()
        {
            DataRow dsRow;
            Label Label;
            String text;

            try
            {

                if (txtPartNo.Text != "")
                {
                    if (iLayoutX == 0)
                        throw new Exception("ยังไม่ได้เลือกตำแหน่งที่จะวาง");

                    if (iLayoutY == 0)
                        throw new Exception("ยังไม่ได้เลือกตำแหน่งที่จะวาง");

                    text = Convert.ToString(dsData.Rows.Count + 1);

                    //if (ExisingLabelControl(Convert.ToString(dsData.Rows.Count + 1)) == false)
                    if (ExisingLabelControl(sTempLabel) == false)
                    {
                        dsRow = dsData.NewRow();
                        dsRow[0] = txtPosition.Text.Trim();
                        dsRow[1] = txtPartNo.Text.ToUpper();
                        dsRow[2] = iLayoutX.ToString();
                        dsRow[3] = iLayoutY.ToString();

                        dsData.Rows.Add(dsRow);
                        dsRow = null;

                        Label = new Label();
                        Label.Location = new Point(iLayoutX, iLayoutY);
                        Label.Size = new Size(30, 30);
                        Label.ForeColor = Color.White;
                        Label.BackColor = Color.Green;

                        Label.Text = txtPosition.Text.Trim() + ":" + txtPartNo.Text.ToUpper();
                        Label.Tag = txtPartNo.Text.ToUpper();

                        Label.Click += new EventHandler(myClickHandler);

                        PicPanel.Controls.Add(Label);

                        iLayoutX = 0; iLayoutY = 0;
                    }
                    else
                    {
                        foreach (Label lbl in PicPanel.Controls)
                        {
                            if (lbl.Text.Trim() == sTempLabel.Trim())
                            {
                                lbl.Location = new Point(iLayoutX, iLayoutY);
                                lbl.ForeColor = Color.White;
                                lbl.BackColor = Color.Orange ;                                
                                lbl.Text = txtPosition.Text.Trim() + ":" + txtPartNo.Text.ToUpper();
                                lbl.Tag = txtPartNo.Text.ToUpper();

                                //lbl.AutoSize = true;

                                

                                break;
                            }
                        }

                        for (int i = 0; i <= dsData.Rows.Count - 1; i++)
                        {
                            dsRow = dsData.Rows[i];

                            if (dsRow[0].ToString().Trim()  == txtPosition.Text.Trim())
                            {
                                dsRow[0] = txtPosition.Text.Trim();
                                dsRow[1] = txtPartNo.Text.ToUpper();
                                dsRow[2] = iLayoutX.ToString();
                                dsRow[3] = iLayoutY.ToString();

                                break;
                            }
                            
                        }

                        iLayoutX = 0; iLayoutY = 0;

                    }
                   
                    grdView.DataSource = dsData;
                    grdView.Refresh();

                    btnAdd.Text = "Add";
                    btnAdd.Tag = "0";

                }

            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }
        
        private void myClickHandler(System.Object sender, System.EventArgs e)
        {
            Label clickedLabel = (Label)sender;

            try
            {
                String[] str = clickedLabel.Text.Split(':');

                txtPosition.Text = str[0];
                txtPartNo.Text = str[1];
                btnCancel.Visible = true;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void txtModel_KeyPress(object sender, KeyPressEventArgs e)
        { 
            try
            {
                if (e.KeyChar == Convert.ToChar(13))
                {
                    if (txtModel.Text != "")
                    {
                        DisplayModel(txtModel.Text);
                    }
                    else
                        throw new Exception("ยังไม่ได้ใส่ EN");
                }

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void DisplayModel(String sModel)
        {
            ItemMaster objItemDll = new ItemMaster();

            try
            {
                ClearBuffer();

                if (objItemM == null)
                {
                    objItemM = new ItemMasterM();
                }

                objItemM.ItemNo = sModel.Trim();

                objReworkLayout.Model = objItemM.ItemNo;
                objReworkLayout.Customer = "HSG";

                objReworkLayout = objRework.GetModelRework(objReworkLayout);

                if (objReworkLayout.Model == "")
                {
                    objItemM = objItemDll.GetItemMaster(objItemM);

                    if (objItemM.ItemDescription == "")
                    {
                        throw new Exception("หา Part นี้ไม่เจอในระบบ Oracle โปรดตรวจสอบใหม่อีกครั้ง");
                    }

                    btnImage.Focus();

                }
                else
                {
                    PicPanel.Image = objReworkLayout.imgPanel;
                    PicPanel.Width = this.Width - grpPanelInfo.Width - 50;
                    PicPanel.Height = this.Height - PicPanel.Top - 50;
                    PicPanel.SizeMode = PictureBoxSizeMode.StretchImage;

                    DisplayAllMaterialTemplate();

                    txtPartNo.Focus();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void DisplayAllMaterialTemplate()
        {
            try
            {
                ReworkInfoM objReworkM;
                Label Label;                
                DataRow dr;

                if (objReworkLayout.PartsRework != null)
                {
                    for (int i = 0; i <= objReworkLayout.PartsRework.Count - 1; i++)
                    {
                        objReworkM = objReworkLayout.PartsRework[i];

                        //if (ExisingLabelControl(Convert.ToString(dsData.Rows.Count + 1)) == false)
                        if (ExisingLabelControl(Convert.ToString(dsData.Rows.Count + 1)) == false)
                        {
                            dr = dsData.NewRow();
                            Label = new Label();
                            Label.Location = new Point(objReworkM.LocationX , objReworkM.LocationY );
                            //Label.Size = new Size(30, 30);
                            Label.ForeColor = Color.White;
                            Label.BackColor = Color.Green;

                            Label.Text = objReworkM.Position + ":" + objReworkM.PartNo ;
                            Label.Tag = objReworkM.PartNo ;

                            dr[0] = objReworkM.Position;
                            dr[1] = objReworkM.PartNo ;
                            dr[2] = objReworkM.LocationX ;
                            dr[3] = objReworkM.LocationY ;

                            dsData.Rows.Add(dr);

                            toolTip.SetToolTip(Label, Label.Text);

                            dr = null;
                            PicPanel.Controls.Add(Label);

                            Label.Click +=  new EventHandler(myClickHandler);

                            iLayoutX = 0; iLayoutY = 0;

                        }
                        grdView.DataSource = dsData;
                        grdView.Refresh(); 

                        objReworkM = null;

                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void txtPartNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            ItemMaster objItemDll = new ItemMaster();
            ItemMasterM objPartM = new ItemMasterM();

            try
            {
                if (e.KeyChar == Convert.ToChar(13))
                {
                    if (txtModel.Text != "")
                    {
                        if (objItemM == null)
                        {
                            objItemM = new ItemMasterM();
                        }

                        

                        objPartM.ItemNo = txtModel.Text.Trim();
                        objPartM = objItemDll.GetItemMaster(objPartM);

                        if (objPartM.ItemDescription == "")
                        {
                            throw new Exception("หา Part นี้ไม่เจอในระบบ Oracle โปรดตรวจสอบใหม่อีกครั้ง");
                        }

                        AddLayoutByControl();
                                                
                    }
                    else
                        throw new Exception("ยังไม่ได้ใส่ EN");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Label lbl;
            int iCount = 0;
            String sStatus = "";
            try
            {
                ReworkInfoM objReworkinfo;

                objReworkLayout.PartsRework = new List<ReworkInfoM>();

                foreach (Label lbl in PicPanel.Controls)
                {
                    objReworkinfo = new ReworkInfoM();
                    objReworkinfo.PartNo = lbl.Tag.ToString ();
                    objReworkinfo.LocationX = lbl.Location.X;
                    objReworkinfo.LocationY = lbl.Location.Y;
                    String[] str = lbl.Text.Split(':');
                    objReworkinfo.Position = str[0];

                    objReworkLayout.PartsRework.Add(objReworkinfo);

                    iCount = iCount + 1;

                    objReworkinfo = null;

                }

                sStatus = objRework.SaveLayoutReworkItem(objReworkLayout);

                if (sStatus != "OK")
                {
                    throw new Exception(sStatus);
                }
                else {
                    DisplayModel(txtModel.Text);
                }

                MessageBox.Show("Save Layout Completed", "Info");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DisplayModel(txtModel.Text);
                //ClearBuffer();            
                btnAdd.Text = "Add";
                btnAdd.Tag = "0";
                btnCancel.Visible = false;

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void txtPosition_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == Convert.ToChar(13))
                {
                    if (txtPosition.Text  != "")
                    {
                        txtPartNo.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            grdView.RowsDefaultCellStyle.SelectionBackColor = Color.BlanchedAlmond;
            if (e.RowIndex > -1)
                grdView.Rows[e.RowIndex].Selected = true;
        }

        private void grdView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            grdView.RowsDefaultCellStyle.SelectionBackColor = Color.DimGray;
        }

        private void grdView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtPosition.Text  = grdView.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtPartNo.Text = grdView.Rows[e.RowIndex].Cells[1].Value.ToString();
             txtX.Text = grdView.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtY.Text = grdView.Rows[e.RowIndex].Cells[3].Value.ToString();

            iLayoutX = Convert.ToInt16 (txtX.Text);
            iLayoutY = Convert.ToInt16(txtY.Text);

            sTempLabel = "";

            sTempLabel = txtPosition.Text.Trim() + ":" + txtPartNo.Text;

            btnAdd.Text = "Save";
            btnAdd.Tag = "1";
            btnCancel.Visible = true;


        }

    }

}
