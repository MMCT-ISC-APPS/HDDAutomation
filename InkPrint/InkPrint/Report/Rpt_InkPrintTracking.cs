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
using System.Diagnostics;
using System.IO;
using System.Globalization;
using System.Text.RegularExpressions;
//using Microsoft.Office.Interop;

namespace InkPrint.Report
{
    public partial class Rpt_InkPrintTracking : Form
    {
        private bool bFullScreen;
        private string TranID = "";
        Common common = new Common();
        Model_Common_Data common_func = new Model_Common_Data();

        public Rpt_InkPrintTracking()
        {
            InitializeComponent();
        }

        public Rpt_InkPrintTracking(MDIParent1 containerForm)
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

        private void txtPanel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                DataTable dtDetail = new DataTable();
                dtDetail = Getdata(txtPanel.Text);

                gvDetail.AutoGenerateColumns = true;
                gvDetail.DataSource = dtDetail;
                displayDataGridview();
            }

        }


        private void btnExecute_Click(object sender, EventArgs e)
        {
            DataTable dtDetail = new DataTable();
            dtDetail = Getdata(txtPanel.Text);

            gvDetail.AutoGenerateColumns = true;
            gvDetail.DataSource = dtDetail;
            displayDataGridview();
        }

        private DataTable Getdata(string Serial)
        {

            common.OpenConnect();
            DataTable dt = new DataTable();
            StringBuilder sql = new StringBuilder();
            sql.Append("	SELECT ROW_NUMBER() OVER(ORDER BY [PrintCode_ID], [PrintCode_ID],PANELID_REF_SEQ asc) AS RowNo	");
            sql.Append("	  ,[SERIALNO]	");
            sql.Append("	      ,JOBNAME");
            sql.Append("	      ,JOBNAME_PUNCH");
            sql.Append("	      ,[MACHINENAME]	");
            sql.Append("	      ,[Print_Flag]	");
            sql.Append("	      ,[GenCode_Date]	");
            sql.Append("	      ,[PrintCode_Date]	");
            sql.Append("	      ,PANELID_REF_SEQ as Print_Seq	");
            sql.Append("	      ,[InkPrint_Result]	");
            sql.Append("	      ,[VerifyCode]	");
            sql.Append("	      ,[GenCode_ID]	");
            sql.Append("	      ,[PrintCode_ID]	");
            sql.Append("	  FROM [cofdb].[dbo].[Printinfo]	");
            sql.Append("	 WHERE 1 = 1	");
            sql.Append("	   AND SERIALNO = '" + Serial + "'	");
            SqlCommand sqlCmd = new SqlCommand(sql.ToString());
            dt = common.ExecuteReader(sqlCmd);
            common.closeConnect();

            return dt;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DataTable dtDetail = (DataTable)gvDetail.DataSource;
            if (dtDetail.Rows.Count > 0)
            {
                ExportToExcel(dtDetail);
            }
        }

        public void ExportToExcel(System.Data.DataTable dt)
        {
            string filename = "";
            string fileDate = DateTime.Now.ToString("ddMMyyyyhmm");

            filename = "RptPanel_"+ txtPanel.Text + fileDate.Trim() + ".xls";

            StreamWriter wr = new StreamWriter(@"D:\\" + filename);

            try
            {

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    wr.Write(dt.Columns[i].ToString().ToUpper() + "\t");
                }

                wr.WriteLine();

                //write rows to excel file
                for (int i = 0; i < (dt.Rows.Count); i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (dt.Rows[i][j] != null)
                        {
                            wr.Write(Convert.ToString(dt.Rows[i][j]) + "\t");
                        }
                        else
                        {
                            wr.Write("\t");
                        }
                    }
                    //go to next line
                    wr.WriteLine();
                }
                //close file
                wr.Close();

                Process.Start(@"D:\\" + filename);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        private void displayDataGridview()
        {
            System.Data.DataTable dtg = (System.Data.DataTable)gvDetail.DataSource;
            int DSeq = 0;
            string GRuncard = "";
            
            for (DSeq = 0; DSeq < gvDetail.RowCount - 1; DSeq++)
            {
                int i = DSeq;
                if (DSeq == gvDetail.RowCount) i--;

                if (GRuncard == gvDetail.Rows[i].Cells[1].Value.ToString() + gvDetail.Rows[i].Cells[2].Value.ToString() + gvDetail.Rows[i].Cells[3].Value.ToString())
                {
                    GRuncard = gvDetail.Rows[i].Cells[1].Value.ToString() + gvDetail.Rows[i].Cells[2].Value.ToString() + gvDetail.Rows[i].Cells[3].Value.ToString();

                    gvDetail.Rows[i].Cells[1].Style.ForeColor = Color.White;
                    gvDetail.Rows[i].Cells[2].Style.ForeColor = Color.White;
                    gvDetail.Rows[i].Cells[3].Style.ForeColor = Color.White;
                                     
                }
                else
                {
                    GRuncard = gvDetail.Rows[i].Cells[1].Value.ToString() + gvDetail.Rows[i].Cells[2].Value.ToString() + gvDetail.Rows[i].Cells[3].Value.ToString();
                    
                }

            }
        }

        private void gvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10)
            {
                int row;
                row = e.RowIndex;

                if (gvDetail.Rows[row].Cells[10].Value.ToString() != "")
                {
                    string Serial_No = gvDetail.Rows[0].Cells[10].Value.ToString();
                    Rpt_InkPrintTrackingDetail obj = new Rpt_InkPrintTrackingDetail(Serial_No);

                    obj.ShowDialog();
                }
            }

            if (e.ColumnIndex == 11)
            {
                int row;
                row = e.RowIndex;

                if (gvDetail.Rows[row].Cells[11].Value.ToString() != "")
                {
                    string Serial_No = gvDetail.Rows[0].Cells[11].Value.ToString();
                    Rpt_InkPrintTrackingDetail obj = new Rpt_InkPrintTrackingDetail(Serial_No);

                    obj.ShowDialog();
                }
            }
        }

    }
}
