using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UPLOAD_FILE
{
    public partial class Frm_Monitor : Form
    {
        String ConDB = "Data Source=prdsvr;Initial Catalog=MC_CONTROL;User ID=sa;Password=P@ssw0rd";

        ClassDB db = new ClassDB();
        DataTable DT;

        public Frm_Monitor()
        {
            InitializeComponent();
        }

        private void Frm_Monitor_Load(object sender, EventArgs e)
        {

        }

        private void cbBuType_SelectedIndexChanged(object sender, EventArgs e)
        {
            db.TSql = "SELECT [UPLOAD_TYPE] FROM [MC_CONTROL].[dbo].[UPLOAD_TYPE] WHERE [BU_TYPE] = '" + cbBuType.SelectedItem.ToString() + "'";
            DT = db.GetDataSql(ConDB);
            if (DT.Rows.Count >= 1)
            {
                cbUploadType.Enabled = true;
                cbUploadType.DataSource = DT;
                cbUploadType.ValueMember = "UPLOAD_TYPE";
                cbUploadType.Focus();

                cbBuType.BackColor = Color.LightGreen;
            }
        }

        private void cbUploadType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbUploadType.SelectedItem.ToString() != "Select Data...")
            {
                db.TSql = "SELECT [MODEL_TYPE],[UPLOAD_TYPE] FROM [MC_CONTROL].[dbo].[MODEL_TYPE] WHERE [UPLOAD_TYPE] = '" + cbUploadType.SelectedValue.ToString() + "'";
                DT = db.GetDataSql(ConDB);
                if (DT.Rows.Count >= 1)
                {
                    cbModel.Enabled = true;
                    cbModel.DataSource = DT;
                    cbModel.ValueMember = "MODEL_TYPE";
                    cbModel.Focus();

                    cbUploadType.BackColor = Color.LightGreen;
                }
            }
        }

        private void cbModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbModel.SelectedItem.ToString() != "Select Data...")
            {
                txtTestNo.Enabled = true;
                txtTestNo.Focus();
                cbModel.BackColor = Color.LightGreen;

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtTestNo.Text.Trim().Length == 0)
            {
                db.TSql = "SELECT [MACHINE_NAME],[BU_TYPE],[UPLOAD_TYPE],[MODEL_TYPE],[YIELD_TRICKRING_STATUS],[BARCODE_MATCHING_STATUS],[LINER_MATCHING_STATUS],[CHANGE_STATUS],[SETUP_STATUS],[MACHINE_STATUS],[PATH_FILE],[PIC_FILE],[UPDATE_DATE],[UPDATE_TIME] FROM [MC_CONTROL].[dbo].[MACHINE_STATUS]";
            }
            else
            {
                db.TSql = "SELECT [MACHINE_NAME],[BU_TYPE],[UPLOAD_TYPE],[MODEL_TYPE],[YIELD_TRICKRING_STATUS],[BARCODE_MATCHING_STATUS],[LINER_MATCHING_STATUS],[CHANGE_STATUS],[SETUP_STATUS],[MACHINE_STATUS],[PATH_FILE],[PIC_FILE],[UPDATE_DATE],[UPDATE_TIME] FROM [MC_CONTROL].[dbo].[MACHINE_STATUS] WHERE MACHINE_NAME = '" + txtTestNo.Text.Trim() + "'";
            }

            DT = db.GetDataSql(ConDB);
            if (DT.Rows.Count >= 1)
            {
                dgv01.DataSource = DT;
            }
        }
    }
}
