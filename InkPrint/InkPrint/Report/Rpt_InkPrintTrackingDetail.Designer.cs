namespace InkPrint.Report
{
    partial class Rpt_InkPrintTrackingDetail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Rpt_InkPrintTrackingDetail));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.txtPanel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gvDetail = new System.Windows.Forms.DataGridView();
            this.RowNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SERIALNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JOBNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MACHINENAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Print_Flag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GenCode_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrintCode_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Print_Seq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InkPrint_Result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VerifyCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GenCode_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrintCode_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.txtPanel);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(603, 93);
            this.panel1.TabIndex = 1;
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnExport.Image = global::InkPrint.Properties.Resources.Export;
            this.btnExport.Location = new System.Drawing.Point(392, 18);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(126, 45);
            this.btnExport.TabIndex = 8;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // txtPanel
            // 
            this.txtPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtPanel.Location = new System.Drawing.Point(138, 26);
            this.txtPanel.Name = "txtPanel";
            this.txtPanel.Size = new System.Drawing.Size(195, 26);
            this.txtPanel.TabIndex = 6;
            this.txtPanel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPanel_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(34, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Code No :";
            // 
            // gvDetail
            // 
            this.gvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowNo,
            this.SERIALNO,
            this.JOBNAME,
            this.MACHINENAME,
            this.Print_Flag,
            this.GenCode_Date,
            this.PrintCode_Date,
            this.Print_Seq,
            this.InkPrint_Result,
            this.VerifyCode,
            this.GenCode_ID,
            this.PrintCode_ID});
            this.gvDetail.Location = new System.Drawing.Point(12, 129);
            this.gvDetail.Name = "gvDetail";
            this.gvDetail.Size = new System.Drawing.Size(1235, 530);
            this.gvDetail.TabIndex = 2;
            // 
            // RowNo
            // 
            this.RowNo.DataPropertyName = "RowNo";
            this.RowNo.FillWeight = 50F;
            this.RowNo.HeaderText = "No";
            this.RowNo.Name = "RowNo";
            this.RowNo.ReadOnly = true;
            this.RowNo.Width = 50;
            // 
            // SERIALNO
            // 
            this.SERIALNO.DataPropertyName = "SERIALNO";
            this.SERIALNO.FillWeight = 150F;
            this.SERIALNO.HeaderText = "Serial No";
            this.SERIALNO.Name = "SERIALNO";
            this.SERIALNO.ReadOnly = true;
            this.SERIALNO.Width = 150;
            // 
            // JOBNAME
            // 
            this.JOBNAME.DataPropertyName = "JOBNAME";
            this.JOBNAME.HeaderText = "Job Name";
            this.JOBNAME.Name = "JOBNAME";
            this.JOBNAME.ReadOnly = true;
            // 
            // MACHINENAME
            // 
            this.MACHINENAME.DataPropertyName = "MACHINENAME";
            this.MACHINENAME.FillWeight = 120F;
            this.MACHINENAME.HeaderText = "Machine Name";
            this.MACHINENAME.Name = "MACHINENAME";
            this.MACHINENAME.ReadOnly = true;
            this.MACHINENAME.Width = 120;
            // 
            // Print_Flag
            // 
            this.Print_Flag.DataPropertyName = "Print_Flag";
            this.Print_Flag.FillWeight = 80F;
            this.Print_Flag.HeaderText = "Print Flag";
            this.Print_Flag.Name = "Print_Flag";
            this.Print_Flag.ReadOnly = true;
            this.Print_Flag.Width = 80;
            // 
            // GenCode_Date
            // 
            this.GenCode_Date.DataPropertyName = "GenCode_Date";
            this.GenCode_Date.HeaderText = "Gen. Date";
            this.GenCode_Date.Name = "GenCode_Date";
            this.GenCode_Date.ReadOnly = true;
            // 
            // PrintCode_Date
            // 
            this.PrintCode_Date.DataPropertyName = "PrintCode_Date";
            this.PrintCode_Date.HeaderText = "Print Date";
            this.PrintCode_Date.Name = "PrintCode_Date";
            this.PrintCode_Date.ReadOnly = true;
            // 
            // Print_Seq
            // 
            this.Print_Seq.DataPropertyName = "Print_Seq";
            this.Print_Seq.FillWeight = 80F;
            this.Print_Seq.HeaderText = "Print Seq";
            this.Print_Seq.Name = "Print_Seq";
            this.Print_Seq.ReadOnly = true;
            this.Print_Seq.Width = 80;
            // 
            // InkPrint_Result
            // 
            this.InkPrint_Result.DataPropertyName = "InkPrint_Result";
            this.InkPrint_Result.FillWeight = 80F;
            this.InkPrint_Result.HeaderText = "Print Result";
            this.InkPrint_Result.Name = "InkPrint_Result";
            this.InkPrint_Result.ReadOnly = true;
            this.InkPrint_Result.Width = 80;
            // 
            // VerifyCode
            // 
            this.VerifyCode.DataPropertyName = "VerifyCode";
            this.VerifyCode.HeaderText = "Verify Code";
            this.VerifyCode.Name = "VerifyCode";
            this.VerifyCode.ReadOnly = true;
            // 
            // GenCode_ID
            // 
            this.GenCode_ID.DataPropertyName = "GenCode_ID";
            this.GenCode_ID.HeaderText = "Gen SN Group";
            this.GenCode_ID.Name = "GenCode_ID";
            this.GenCode_ID.ReadOnly = true;
            this.GenCode_ID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // PrintCode_ID
            // 
            this.PrintCode_ID.DataPropertyName = "PrintCode_ID";
            this.PrintCode_ID.HeaderText = "Print SN Group";
            this.PrintCode_ID.Name = "PrintCode_ID";
            this.PrintCode_ID.ReadOnly = true;
            this.PrintCode_ID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Rpt_InkPrintTrackingDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1362, 671);
            this.Controls.Add(this.gvDetail);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Rpt_InkPrintTrackingDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report InkPrint Tracking Detail";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridView gvDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn SERIALNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn JOBNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn MACHINENAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn Print_Flag;
        private System.Windows.Forms.DataGridViewTextBoxColumn GenCode_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrintCode_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Print_Seq;
        private System.Windows.Forms.DataGridViewTextBoxColumn InkPrint_Result;
        private System.Windows.Forms.DataGridViewTextBoxColumn VerifyCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn GenCode_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrintCode_ID;
    }
}