using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using System.Threading;
using System.Globalization;

namespace InkPrint.Print2D
{
    public partial class InkPrintPath : Form
    {
        private bool bFullScreen;
        private string Action = "ADD";
        private string StatusMac;
        private string ComName = Environment.MachineName;
      
        Common common = new Common();
        Model_Common_Data common_func = new Model_Common_Data();

        public InkPrintPath()
        {
            InitializeComponent();
        }

        public InkPrintPath(MDIParent1 containerForm)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

            InitializeComponent();
            MdiParent = containerForm;

            if (bFullScreen == false)
            {
                this.FormBorderStyle = FormBorderStyle.Sizable; this.WindowState = FormWindowState.Maximized; bFullScreen = true;

            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.Sizable; this.WindowState = FormWindowState.Normal;
            }
        }


        #region Event

        private void Master_Machine_New_Load(object sender, EventArgs e)
        {
            BindGrid();
            BindMachine(txtMacCode.Text);
            RadioButton("Active");
        }

        private void txtMacCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtMacCode.Text.Trim() != "")
                {
                    BindMachine(txtMacCode.Text);
                }
            }
        }
        
        private void txtOutPutPath_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtOutPutPath.Text.Trim() != "")
                {
                    txtFileName.Focus();
                }
            }
        }

        private void txtFileName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtFileName.Text.Trim() != "")
                {
                    txtQtyBoard.Focus();
                }
            }
        }

        private void rdAactive_CheckedChanged(object sender, EventArgs e)
        {
            if (rdAactive.Checked == true)
            {
                StatusMac = "Active";
                rdInactive.Checked = false;
            }
        }

        private void rdInactive_CheckedChanged(object sender, EventArgs e)
        {
            if (rdInactive.Checked == true)
            {
                rdAactive.Checked = false;
                StatusMac = "Inactive";
            }
        }

        private void dtMachine_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row;
            row = e.RowIndex;

            if (e.ColumnIndex == 5)
            {
                txtMacCode.Text = dtMachine.Rows[row].Cells[0].Value.ToString();
                txtOutPutPath.Text = dtMachine.Rows[row].Cells[1].Value.ToString();
                txtFileName.Text = dtMachine.Rows[row].Cells[2].Value.ToString();
                txtQtyBoard.Text = dtMachine.Rows[row].Cells[3].Value.ToString();
                RadioButton(dtMachine.Rows[row].Cells[4].Value.ToString());
                Action = "UPDATE";
                txtMacCode.ReadOnly = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string errMsg = CompleteMasterSheet();
            if (errMsg != "")
            {
                MessageBox.Show("การบันทึกข้อมูลล้มเหลว : " + errMsg, "การบันทึกข้อมูลล้มเหลว", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                MessageBox.Show("บันทึกข้อมูลเรียบร้อย ", "บันทึกข้อมูลเรียบร้อย", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindGrid();
                ClearData();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        #endregion





        private void RadioButton(string status)
        {
            if (status == "Active")
            {
                rdAactive.Checked = true;
                rdInactive.Checked = false;
            }
            else
            {
                rdAactive.Checked = false;
                rdInactive.Checked = true;
            }
        }

        private void BindGrid()
        {
            DataTable dt = new DataTable();
            dt = GetDataMachine("", ComName);

            dtMachine.AutoGenerateColumns = true;
            dtMachine.DataSource = dt;
        }

        private void BindMachine(string mac_code)
        {
            DataTable dt = new DataTable();

            dt = GetDataMachine(mac_code, ComName);

            if (dt.Rows.Count > 0)
            {
                txtMacCode.Text = dt.Rows[0]["Ink_Mac"].ToString();
                txtOutPutPath.Text = dt.Rows[0]["Ink_OutPut"].ToString();
                txtFileName.Text = dt.Rows[0]["Ink_FileName"].ToString();
                txtQtyBoard.Text = dt.Rows[0]["Ink_QtyBoard"].ToString();
                RadioButton(dt.Rows[0]["Ink_Status"].ToString());
                Action = "UPDATE";
            }
            else
            {
                txtOutPutPath.Text = "";
                txtFileName.Text = "";
                txtQtyBoard.Text = "";
                RadioButton("Active");
                txtOutPutPath.Focus();
            }
        }

        private void ClearData()
        {
            txtMacCode.ReadOnly = false;
            txtMacCode.Text = "";
            txtOutPutPath.Text = "";
            txtFileName.Text = "";
            txtQtyBoard.Text = "";
            Action = "ADD";
            RadioButton("Active");
        }




        #region DataAccess

        private DataTable GetDataMachine(string mac_code, string mac_name)
        {
           
            DataTable dt = new DataTable();
            common.OpenConnect();

            StringBuilder sql = new StringBuilder();
            sql.Append("	SELECT [Ink_Mac]	");
            sql.Append("	      ,[Ink_OutPut]	");
            sql.Append("	      ,[Ink_FileName]	");
            sql.Append("	      ,[Ink_QtyBoard]	");
            sql.Append("	      ,[Ink_Status]	");
            sql.Append("	      ,'Edit' as Edit	");
            sql.Append("	FROM [tb_InkPrintPath] ");
            sql.Append("	  WHERE 1=1	");
            sql.Append("	    AND Computer_Name = '" + mac_name + "'	");
            if (mac_code != "")
            {
                sql.Append("	    AND Ink_Mac = '" + mac_code + "'	");
            }
            sql.Append("	 ORDER BY [Ink_Mac]	");
            
            SqlCommand sqlCmd = new SqlCommand(sql.ToString());
            dt = common.ExecuteReader(sqlCmd);
            common.closeConnect();

            return dt;
        }

        private string CompleteMasterSheet()
        {
            try
            {
                StringBuilder sql;
                SqlCommand sqlCmd;
                string errMsg = "";
                common.BeginTrans();

                if (Action == "UPDATE")
                {
                    sql = new StringBuilder();
                    sql.Append(" UPDATE [tb_InkPrintPath] SET ");
                    sql.Append("    [Ink_OutPut] = @Ink_OutPut ");
                    sql.Append("    ,[Ink_FileName] = @Ink_FileName ");
                    sql.Append("    ,[Ink_QtyBoard] = @Ink_QtyBoard ");
                    sql.Append("    ,[Ink_Status] = @Ink_Status ");
                    sql.Append(" WHERE  [Ink_Mac] = @Ink_Mac ");
                    sqlCmd = new SqlCommand(sql.ToString());
                    sqlCmd.Parameters.Add("Ink_OutPut", SqlDbType.VarChar).Value = txtOutPutPath.Text;
                    sqlCmd.Parameters.Add("Ink_FileName", SqlDbType.VarChar).Value = txtFileName.Text;
                    sqlCmd.Parameters.Add("Ink_QtyBoard", SqlDbType.Int).Value = txtQtyBoard.Text;
                    sqlCmd.Parameters.Add("Ink_Status", SqlDbType.VarChar).Value = StatusMac;
                    sqlCmd.Parameters.Add("Ink_Mac", SqlDbType.VarChar).Value = txtMacCode.Text;
                  
                    errMsg = common.ExecuteData(sqlCmd);
                    if (errMsg != "")
                    {
                        common.RollBackTrans();
                        return errMsg;
                    }

                }
                else
                {
                    sql = new StringBuilder();
                    sql.Append("INSERT INTO [tb_InkPrintPath] ");
                    sql.Append(" (  [Ink_Mac]");
                    sql.Append("    ,[Ink_OutPut]");
                    sql.Append("    ,[Ink_FileName]");
                    sql.Append("    ,[Ink_QtyBoard]");
                    sql.Append("    ,[Ink_Status]");
                    sql.Append("     )");
                    sql.Append(" values( ");
                    sql.Append("    @Ink_Mac ");
                    sql.Append("    ,@Ink_OutPut");
                    sql.Append("    ,@Ink_FileName");
                    sql.Append("    ,@Ink_QtyBoard");
                    sql.Append("    ,@Ink_Status");
                   sql.Append("    ) ");
                    sqlCmd = new SqlCommand(sql.ToString());
                    sqlCmd.Parameters.Add("Ink_Mac", SqlDbType.VarChar).Value = txtMacCode.Text;
                    sqlCmd.Parameters.Add("Ink_OutPut", SqlDbType.VarChar).Value = txtOutPutPath.Text;
                    sqlCmd.Parameters.Add("Ink_FileName", SqlDbType.VarChar).Value = txtFileName.Text;
                    sqlCmd.Parameters.Add("Ink_QtyBoard", SqlDbType.VarChar).Value = txtQtyBoard.Text;
                    sqlCmd.Parameters.Add("Ink_Status", SqlDbType.VarChar).Value = StatusMac;
                   
                    errMsg = common.ExecuteData(sqlCmd);
                    if (errMsg != "")
                    {
                        common.RollBackTrans();
                        return errMsg;
                    }
                }

                common.CommitTrans();

                return "";
            }
            catch (Exception ex)
            {
                common.RollBackTrans();
                return ex.Message;
            }
        }

        #endregion

    }
}
