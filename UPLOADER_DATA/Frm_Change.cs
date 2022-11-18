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
    public partial class Frm_Change : Form
    {
        String ConDB = "Data Source=prdsvr;Initial Catalog=MC_CONTROL;User ID=sa;Password=P@ssw0rd";

        ClassDB db = new ClassDB();
        DataTable DT;
        public Frm_Change()
        {
            InitializeComponent();
        }
        private void Frm_Change_Load(object sender, EventArgs e)
        {
            db.TSql = "SELECT * FROM MACHINE_STATUS WHERE MACHINE_NAME = '" + System.Environment.MachineName + "'";
            DT = db.GetDataSql(ConDB);
            if (DT.Rows.Count > 0)
            {
                cbMachineName.Items.Add("Select Data...");
                for (int i = 0; i < DT.Rows.Count; i++)
                {
                    cbMachineName.Items.Add(DT.Rows[i]["MACHINE_NAME"].ToString() + " | " + DT.Rows[i]["BU_TYPE"].ToString() + " | " + DT.Rows[i]["UPLOAD_TYPE"].ToString() + " | " + DT.Rows[i]["MODEL_TYPE"].ToString());
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String[] TMPFILE = cbMachineName.SelectedItem.ToString().Trim().Split('|');
            db.TSql = "UPDATE [dbo].[MACHINE_STATUS] SET [BU_TYPE] = '" + cbBuType.SelectedItem.ToString() + "',[UPLOAD_TYPE] = '" + cbUploadType.SelectedItem.ToString() + "',[MODEL_TYPE] = '" + cbModel.SelectedItem.ToString() + "',[UPDATE_DATE] = '" + DateTime.Now.ToString("ddMMyyyy") + "',[UPDATE_TIME] = '" + DateTime.Now.ToString("hhmmss") + "',[YIELD_TRICKRING_STATUS] = '" + cbYieldTrickring.SelectedItem.ToString() + "' WHERE MACHINE_NAME = '" + TMPFILE[0].ToString().Trim() + "'"; //,[PATH_FILE] = '" + txtPathFile.Text.Trim() + "',[PIC_FILE] = '" + txtPictureFile.Text.Trim() + "'
            if (db.UpdateDataSql(ConDB) == 1)
            {
                db.TSql = "UPDATE [dbo].[MACHINE_STATUS] SET [BARCODE_MATCHING_STATUS] = '" + cb2DMatching.SelectedItem.ToString() + "',[LINER_MATCHING_STATUS] = '" + cbLinerMatching.SelectedItem.ToString() + "' WHERE MACHINE_NAME = '" + TMPFILE[0].ToString().Trim() + "' AND REWORK_STATUS = 'On'";//,[PATH_FILE] = '" + txtPathFile.Text.Trim() + "',[PIC_FILE] = '" + txtPictureFile.Text.Trim() + "'
                db.UpdateDataSql(ConDB);
                this.Close();
            }
        }

        private void cbMachineName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMachineName.SelectedItem.ToString() != "Select Data...")
            {
                cbBuType.Enabled = true;
                cbMachineName.BackColor = Color.LightGreen;
            }
        }

        private void cbBuType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBuType.SelectedItem.ToString() != "Select Data...")
            {
                db.TSql = "SELECT [UPLOAD_TYPE] FROM [MC_CONTROL].[dbo].[UPLOAD_TYPE] WHERE [BU_TYPE] = '" + cbBuType.SelectedItem.ToString() + "'";
                DT = db.GetDataSql(ConDB);
                if (DT.Rows.Count >= 1)
                {
                    cbUploadType.Items.Clear();
                    cbUploadType.Items.Add("Select Data...");
                    for (int i = 0; i < DT.Rows.Count; i++)
                    {
                        cbUploadType.Items.Add(DT.Rows[i][0].ToString());
                    }

                    cbUploadType.Enabled = true;
                    cbUploadType.Focus();
                    cbBuType.BackColor = Color.LightGreen;
                }
            }
        }

        private void cbUploadType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbUploadType.SelectedItem.ToString() != "Select Data...")
            {
                db.TSql = "SELECT [MODEL_TYPE] FROM [MC_CONTROL].[dbo].[MODEL_TYPE] WHERE [UPLOAD_TYPE] = '" + cbUploadType.SelectedItem.ToString() + "' AND [BU_TYPE] = '" + cbBuType.SelectedItem.ToString() + "' ORDER BY [MODEL_TYPE]";
                DT = db.GetDataSql(ConDB);
                if (DT.Rows.Count >= 1)
                {
                    cbModel.Items.Clear();
                    cbModel.Items.Add("Select Data...");
                    for (int i = 0; i < DT.Rows.Count; i++)
                    {
                        cbModel.Items.Add(DT.Rows[i][0].ToString());
                    }

                    cbModel.Enabled = true;
                    cbModel.Focus();
                    cbUploadType.BackColor = Color.LightGreen;
                }
            }
        }

        private void cbModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbModel.SelectedItem.ToString() != "Select Data...")
            {
                cbModel.BackColor = Color.LightGreen;
                cbYieldTrickring.Enabled = true;
            }
        }

        private void cbYieldTrickring_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbYieldTrickring.SelectedItem.ToString() != "Select Data...")
            {
                cbYieldTrickring.BackColor = Color.LightGreen;
                cb2DMatching.Enabled = true;
            }
        }

        private void cb2DMatching_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb2DMatching.SelectedItem.ToString() != "Select Data...")
            {
                cb2DMatching.BackColor = Color.LightGreen;
                cbLinerMatching.Enabled = true;
            }
        }

        private void cbLinerMatching_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLinerMatching.SelectedItem.ToString() != "Select Data...")
            {
                cbLinerMatching.BackColor = Color.LightGreen;
                //cbChangeStatus.Enabled = true;
                btnUpdate.Enabled = true;
            }
        }

        private void cbChangeStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbChangeStatus.SelectedItem.ToString() != "Select Data...")
            {
                cbChangeStatus.BackColor = Color.LightGreen;
                cbSetupStatus.Enabled = true;
            }
        }

        private void cbSetupStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSetupStatus.SelectedItem.ToString() != "Select Data...")
            {
                cbSetupStatus.BackColor = Color.LightGreen;
                btnUpdate.Enabled = true;
            }
        }
    }
}
