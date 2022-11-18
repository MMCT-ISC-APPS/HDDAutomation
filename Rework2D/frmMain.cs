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
    public partial class frmMain : Form
    {
        private Int32 iLayoutX;
        private Int32 iLayoutY;
        private DataTable dsData;        

        private ItemMasterM objItemM;
        private ItemReworkInfoM objReworkLayout;
        private PrintinfoM objPrintM; 
        private ReworkProcess objRework;
        private HSGTraceability objHsg;
        private ItemMaster  objItem;

        private String sProgramName = "Rework2D";

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            objReworkLayout = new ItemReworkInfoM();
            objRework = new ReworkProcess();
            objHsg = new HSGTraceability(false);
            objPrintM = new PrintinfoM();
            objItem = new ItemMaster();
            objItemM = new ItemMasterM();

            try
            {
                this.Text = "";
                ClearBuffer();

                this.Text = sProgramName + "(SW V" + getVersion() + " , DLL v" + objHsg.GetVersion() + " , WS " + objHsg.GetWebServiceVersion() + ")";

                objReworkLayout.Customer = "HSG";
                objReworkLayout = objRework.GetAllReworkCriteriaData(objReworkLayout);

                DisplayReworkAllcriteria(objReworkLayout);

                //DisplayReworkAllCriteria(objReworkLayout.DisplayReworkCriteria );

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }


        public string getVersion()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            return version;
        }

        private void DisplayReworkAllcriteria(ItemReworkInfoM ReworkCreLst)
        {
            try
            {
                cboCriteria.Items.Clear();

                cboCriteria.Items.Add("****Select Criteria****");

                for (int i = 0; i <= ReworkCreLst.DisplayReworkCriteria.Count - 1; i++)
                {
                    cboCriteria.Items.Add(ReworkCreLst.DisplayReworkCriteria[i].CriteriaName);
                }

                cboCriteria.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //private void DisplayReworkAllCriteria(IEnumerable<ReworkCriteriaM> ReworkCreLst)
        //{

        //    try
        //    {               

        //       //lstData.BeginUpdate();
        //       // lstData.Groups.Clear();

        //       // ReworkCreLst
        //       //     .GroupBy (ReworkCre => ReworkCre.GroupName , CreateListViewGroup)
        //       //     .ToList();

        //       // lstData.EndUpdate(); 

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        //private  ListViewGroup CreateListViewGroup(String GroupName , IEnumerable<ReworkCriteriaM> ReworkCre)
        //{
        //    var group = new ListViewGroup(GroupName);
        //    lstData.Groups.Add(group);

        //    foreach (var assignment in ReworkCre)
        //    {
        //        var item = new ListViewItem(assignment.CriteriaName , group);
        //        //item.SubItems.Add(assignment.Description);
        //        lstData.Items.Add(item);
        //    }

        //    return group;
        //}

        private void ClearBuffer()
        {
            dsData = null;
            iLayoutX = 0;
            iLayoutY = 0;
          

            dsData = new DataTable();

            dsData.Columns.Add("Position");
            dsData.Columns.Add("blockno");
            dsData.Columns.Add("pixelx");
            dsData.Columns.Add("pixely");


        }

        private void txtSerialNo_KeyPress(object sender, KeyPressEventArgs e)
        {            
            try
            {
                if (e.KeyChar == Convert.ToChar(13))
                {
                    if (txtSerialNo.Text  != "")
                    {                                            
                        objPrintM.Customer = "HSG";
                        objPrintM.Serialno = txtSerialNo.Text.Trim().ToUpper();
                        objPrintM = objHsg.GetPrintInfo(objPrintM);

                        objReworkLayout.Customer = objPrintM.Customer;
                        objReworkLayout.Model = objPrintM.ModelName;
                        objReworkLayout.SerialNo = objPrintM.Serialno;                        
                        txtModel.Text = objPrintM.ModelName;
                        txtJobname.Text = objPrintM.JobName;

                        DisplayAllLayoutbyModel(objPrintM.ModelName);

                        objReworkLayout = objRework.GetModelReworkHistory (objReworkLayout);
                        
                        if (objReworkLayout.ReworkID  != 0)
                        {
                            for (int i = 0; i <= objReworkLayout.PartsRework.Count - 1; i++)
                            {
                                ReworkInfoM objDetail = objReworkLayout.PartsRework[i];

                                foreach (Label Label in PicPanel.Controls)
                                {
                                    if (Label.Tag.ToString().Contains(objDetail.PartNo) == true)
                                    {
                                        Label.ForeColor = Color.White;
                                        Label.BackColor = Color.Green;
                                        toolTip.SetToolTip(Label, "CriteriaName:" + objDetail.CriteriaName);                                        
                                        break;
                                    }
                                    else {
                                        if (Label.BackColor != Color.Green)
                                        {
                                            Label.ForeColor = Color.White;
                                            Label.BackColor = Color.Blue;
                                            toolTip.SetToolTip(Label, "CriteriaName:");                                            
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
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void DisplayAllLayoutbyModel(String sModel)
        {
            ItemMaster objItemDll = new ItemMaster();

            try
            {
                    if (sModel != "")
                    {

                        if (objItemM == null)
                        {
                            objItemM = new ItemMasterM();
                        }

                        objItemM.ItemNo = txtModel.Text.Trim();

                        objReworkLayout.Model = objItemM.ItemNo;
                        objReworkLayout.Customer = "HSG";

                        objReworkLayout = objRework.GetModelRework(objReworkLayout);

                        if (objReworkLayout.Model == "")
                        {
                            throw new Exception("ยังไม่ได้ Set Layout for Rework โปรดแจ้ง Engineer");
                        }
                        else
                        {
                        
                            PicPanel.Image = objReworkLayout.imgPanel;
                            PicPanel.Width = this.Width - grpPanelInfo.Width - 50;
                            PicPanel.Height = this.Height - PicPanel.Top - 50;
                            PicPanel.SizeMode = PictureBoxSizeMode.StretchImage;

                            DisplayAllMaterialTemplate();
                            
                        }

                    }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
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
                    this.PicPanel.Controls.Clear();

                    for (int i = 0; i <= objReworkLayout.PartsRework.Count - 1; i++)
                    {
                        objReworkM = objReworkLayout.PartsRework[i];

                        if (ExisingLabelControl(objReworkM.Position + ":" + objReworkM.PartNo) == false)
                        {
                            dr = dsData.NewRow();
                            Label = new Label();
                            Label.Location = new Point(objReworkM.LocationX, objReworkM.LocationY);
                            //Label.Size = new Size(30, 30);
                            Label.ForeColor = Color.White;
                            Label.BackColor = Color.Blue;

                            Label.Text = objReworkM.Position + ":" + objReworkM.PartNo;
                            Label.Tag = objReworkM.PartNo;

                            dr = null;
                            PicPanel.Controls.Add(Label);

                            toolTip.SetToolTip(Label, objReworkM.PartNo);

                            Label.Click += new EventHandler(myClickHandler);

                            iLayoutX = 0; iLayoutY = 0;

                        }                      

                        objReworkM = null;

                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void DisplayMaterial(ItemReworkInfoM objItem)
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
                        
                        if (ExisingLabelControl(objReworkM.Position +":"+ objReworkM.PartNo) == true)
                        {
                            //dr = dsData.NewRow();
                            Label = new Label();
                            Label.Location = new Point(objReworkM.LocationX, objReworkM.LocationY);
                            //Label.Size = new Size(30, 30);
                            Label.ForeColor = Color.White;
                            Label.BackColor = Color.Blue;

                            Label.Text = objReworkM.Position + ":" + objReworkM.PartNo;
                            Label.Tag = objReworkM.PartNo;

                            dr = null;
                            PicPanel.Controls.Add(Label);

                            Label.Click += new EventHandler(myClickHandler);

                            iLayoutX = 0; iLayoutY = 0;

                        }

                        objReworkM = null;

                    }
                }

            }
            catch (Exception ex)
            {
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
                txtOldPart.Text = str[1];

                txtLotNo.Text = "";
                txtNewPart.Text = "";
                cboCriteria.SelectedIndex = 0;

                if (txtOldPart.Text.Contains("SFL") == true)
                {
                    txtNewPart.Enabled = false;
                    txtLotNo.Enabled = false;
                    cboCriteria.Enabled = false;
                }
                else
                {
                    txtNewPart.Enabled = true;
                    txtLotNo.Enabled = true;
                    cboCriteria.Enabled = true;
                }

                txtLotNo.Focus();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private bool ExisingLabelControl(string sText)
        {
            //Label Label = new Label ();
            bool bHave;

            bHave = false;
            foreach (Label Label in PicPanel.Controls)
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

        private void txtLotNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            String[] str ;
            Boolean bValid ;

            try
            {
                if (e.KeyChar == Convert.ToChar(13))
                {
                    if (txtLotNo.Text != "")
                    {
                        bValid = false;

                        str = txtOldPart.Text.ToString().Split(';');

                        for (int i = 0; i <= str.Length - 1; i++)
                        {
                            objItemM.Model = txtModel.Text;
                            objItemM.JobName = txtJobname.Text;
                            objItemM.LotNo = txtLotNo.Text;
                            //objItemM.ItemNo = txtOldPart.Text;
                            objItemM.ItemNo = str[i];                            
                            objItemM = objItem.GetOnhandByJobandLot(objItemM);

                            if (objItemM.ItemNo != "")
                            {
                                txtNewPart.Text = objItemM.ItemNo;
                                bValid = true;
                                break;
                            }
                            else
                            {
                                bValid = false;
                            }
                            

                        }

                        if (bValid == false)
                        {
                            txtLotNo.Text = "";
                            txtLotNo.Focus();
                            throw new Exception("หา Lot ที่ตรงกับ Part นี้ไม่เจอ");
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {                
                objReworkLayout.ReworkCriteria = new List<ReworkCriteriaM>();

                objReworkLayout.OldJobname = txtJobname.Text;
                objReworkLayout.PartNo = txtNewPart.Text;
                objReworkLayout.LotNo = txtLotNo.Text;
                objReworkLayout.SerialNo = txtSerialNo.Text;
                objReworkLayout.Position = txtPosition.Text;
                objReworkLayout.En = "";
                objReworkLayout.OldPartNo = txtOldPart.Text;
                objReworkLayout.JobName = "";

                if (txtOldPart.Text.Contains("SFL") == true)
                {
                    objReworkLayout.CriteriaName = txtOldPart.Text;
                    objReworkLayout.PartNo = txtOldPart.Text;
                }
                else
                {
                    if (cboCriteria.SelectedIndex == 0)
                    {
                        throw new Exception("ยังไม่ได้เลือก Criteria");
                    }
                    else
                    {
                        objReworkLayout.CriteriaName = cboCriteria.SelectedItem.ToString() ;
                    }                    
                }

                if (txtLotNo.Tag != null)
                {
                    if (txtLotNo.Tag.ToString () == "0")
                    {
                        if (txtLotNo.Text != "")
                        {
                            if (txtNewPart.Text == "")
                            {
                                throw new Exception("ยังไม่ได้เลือก Lot No");
                            }
                        }
                        else
                        {
                            throw new Exception("ยังไม่ได้เลือก Lot No");
                        }
                    }
                }

                objRework.SaveRework2D(objReworkLayout);

                foreach (Label Label in PicPanel.Controls)
                {
                    if (Label.Tag != null)
                    {
                        if (Label.Tag.ToString()  == objReworkLayout.OldPartNo)
                        {
                            Label.ForeColor = Color.White;
                            Label.BackColor = Color.Green;

                            toolTip.SetToolTip(Label, "CriteriaName:" + objReworkLayout.CriteriaName);

                            break;
                        }

                    }
                }

                //foreach (ListViewItem item in lstData.Items)
                //{
                //    if (item.Checked == true)
                //    {
                //        ReworkCriteriaM objCri = new ReworkCriteriaM();
                //        objCri.CriteriaName = item.Text;
                //        objReworkLayout.ReworkCriteria.Add(objCri);
                //        objCri = null;
                //    }
                //    //index is now zero based index of selected item
                //}


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSetup frmSetup = new frmSetup();

            try
            {
                frmSetup.ShowDialog();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtJobname.Text = "";
            txtLotNo.Text = "";
            //txtModel.Text = "";
            txtNewPart.Text = "";
            txtOldPart.Text = "";
            txtPosition.Text = "";
            txtSerialNo.Text = "";
            txtSerialNo.Focus();
            cboCriteria.SelectedIndex = 0;

            try
            {
                DisplayAllLayoutbyModel(objReworkLayout.Model);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void cboCriteria_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i <= objReworkLayout.DisplayReworkCriteria.Count - 1; i++)
                {
                    if (cboCriteria.SelectedItem.ToString()  == objReworkLayout.DisplayReworkCriteria[i].CriteriaName)
                    {
                        if (objReworkLayout.DisplayReworkCriteria[i].GroupName == "Other")
                        {
                            txtLotNo.Text = "";
                            txtLotNo.Tag = "1";
                            txtNewPart.Text = "";                            
                            txtLotNo.Enabled = false;
                            txtNewPart.Enabled = false;
                            break;
                        }
                        else
                        {
                            txtLotNo.Tag = "0";
                            txtLotNo.Enabled = true;
                            txtNewPart.Enabled = true;
                        }
                    }

                    //cboCriteria.Items.Add(ReworkCreLst.DisplayReworkCriteria[i].CriteriaName);
                }

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtLotNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSerialNo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
