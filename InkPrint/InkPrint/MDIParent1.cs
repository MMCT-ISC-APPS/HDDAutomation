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
using System.Diagnostics;
using System.Reflection;
using System.Deployment.Application;
using MachineDLL;

namespace InkPrint
{
    public partial class MDIParent1 : Form
    {
        private bool bFullScreen;
        private int childFormNumber = 0;
        Common common = new Common();
        DataTable dtMenu = new DataTable();
        private AITraceability objTraceability;
        public MDIParent1()
        {
            InitializeComponent();

            objTraceability = new AITraceability();

            if (bFullScreen == false)
            {
                this.FormBorderStyle = FormBorderStyle.Sizable; this.WindowState = FormWindowState.Maximized; bFullScreen = true;

            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.Sizable; this.WindowState = FormWindowState.Normal;
            }
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
 
      private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

      private void toolStripMenuBox_Click(object sender, EventArgs e)
      {
          
      }

      private void MDIParent1_Load(object sender, EventArgs e)
      {
            //this.Text = "Ink Print" + " ( version : " + AssemblyVersion.Major.ToString() + "." + AssemblyVersion.Minor.ToString() + "." + AssemblyVersion.Build.ToString() + "." + AssemblyVersion.Revision.ToString() + " )";

            this.Text = "Ink Print" + " ( DLL version : " + objTraceability.GetVersion() + " , SW Version: "+ getVersion() +" )";

            string thisProcessName = Assembly.GetEntryAssembly().GetName().Name;

            Process[] localProcess = Process.GetProcessesByName(thisProcessName);

            if (localProcess != null && localProcess.Length > 1)
            {
                //MessageBox.Show("");
                //Application.Current.Shutdown(0);
                localProcess[0].Kill();
                foreach (var process in Process.GetProcessesByName(thisProcessName))
                {
                    process.Kill();
                }

            }

        }

        public string getVersion()
        {
            System.Reflection.Assembly ProjectAssembly;
            ProjectAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            return ProjectAssembly.GetName().Version.ToString();
        }

        //private void GetItems(ToolStripMenuItem item)
        //{
        //    foreach (ToolStripMenuItem dropDownItem in item.DropDownItems)
        //    {

        //        foreach (DataRow drx in dtMenu.Rows)
        //        {
        //            if (dropDownItem.Name.Trim() == drx["menu_name"].ToString().Trim())
        //            {
        //                dropDownItem.Enabled = true;
        //            }
        //        }
        //    }
        //}

        //private DataTable menu_list(string Proc)
        //{
        //    //DataTable dt = new DataTable();

        //    //common.OpenConnect();
        //    //StringBuilder sql = new StringBuilder();
        //    //sql.Append("    SELECT DISTINCT [Master_Menu].[Menu_ID] as menu_id,	 ");
        //    //sql.Append("                    [Master_Menu].[Menu_Desc] as menu_name,	  ");
        //    //sql.Append("                    ISNULL([Master_Menu].[Menu_Sort], 0) as menu_sort,  ");
        //    //sql.Append("                    convert(CHAR,[Master_Menu].[Menu_Parent],100) as menu_parent ");
        //    //sql.Append("    FROM [cofdb].[dbo].[Master_Menu] ");
        //    //sql.Append("    WHERE [Master_Menu].[Menu_Status] = '0' ");
        //    //sql.Append("    AND   ([Master_Menu].[Process_Code] = '" + Proc + "' or [Master_Menu].[Process_Code] is null)  ");
        //    //sql.Append("    ORDER BY 4 ASC, 3 ASC ");
        //    //SqlCommand sqlCmd = new SqlCommand(sql.ToString());
        //    //dt = common.ExecuteReader(sqlCmd);
        //    //common.closeConnect();

        //    //return dt;

        //}


        private void generate2DToolStripMenuItem1_Click(object sender, EventArgs e)
      {
          closeAllToolStripMenuItem_Click(sender, e);
          InkPrint.Print2D.Print2D frm1 = new InkPrint.Print2D.Print2D(this);
          frm1.LayoutMdi(MdiLayout.Cascade);
          frm1.Show();
      }

      private void generate2DToolStripMenuItem_Click(object sender, EventArgs e)
      {
          closeAllToolStripMenuItem_Click(sender, e);
          InkPrint.Print2D.InkPrintPath frm1 = new InkPrint.Print2D.InkPrintPath(this);
          frm1.LayoutMdi(MdiLayout.Cascade);
          frm1.Show();
      }

        private void reportInkPrintTrackingToolStripMenuItem_Click(object sender, EventArgs e)
      {
          closeAllToolStripMenuItem_Click(sender, e);
          InkPrint.Report.Rpt_InkPrintTracking frm1 = new InkPrint.Report.Rpt_InkPrintTracking(this);
          frm1.LayoutMdi(MdiLayout.Cascade);
          frm1.Show();
      }

        private void generate2DNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeAllToolStripMenuItem_Click(sender, e);
            InkPrint.Print2D_New.Print2D_New frm1 = new InkPrint.Print2D_New.Print2D_New(this);
            frm1.LayoutMdi(MdiLayout.Cascade);
            frm1.Show();
        }

        private void MDIParent1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.Close();
        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
