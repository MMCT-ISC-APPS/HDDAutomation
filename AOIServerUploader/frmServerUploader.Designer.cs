namespace AOIServerUploader
{
    partial class frmServerUploader
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServerUploader));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.executeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblBatchFileCount = new System.Windows.Forms.Label();
            this.tmrResult = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnConnected = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.ResultFileBro = new System.Windows.Forms.FolderBrowserDialog();
            this.lblTotalCompleted = new System.Windows.Forms.Label();
            this.lblServerStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMachineName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.pHeader = new System.Windows.Forms.Panel();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.pHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.executeToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 52);
            // 
            // executeToolStripMenuItem
            // 
            this.executeToolStripMenuItem.Name = "executeToolStripMenuItem";
            this.executeToolStripMenuItem.Size = new System.Drawing.Size(124, 24);
            this.executeToolStripMenuItem.Text = "Execute";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(124, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // lblBatchFileCount
            // 
            this.lblBatchFileCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblBatchFileCount.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblBatchFileCount.Location = new System.Drawing.Point(233, 187);
            this.lblBatchFileCount.Name = "lblBatchFileCount";
            this.lblBatchFileCount.Size = new System.Drawing.Size(145, 23);
            this.lblBatchFileCount.TabIndex = 12;
            this.lblBatchFileCount.Text = "0";
            // 
            // tmrResult
            // 
            this.tmrResult.Tick += new System.EventHandler(this.tmrResult_Tick);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // btnConnected
            // 
            this.btnConnected.Location = new System.Drawing.Point(23, 86);
            this.btnConnected.Name = "btnConnected";
            this.btnConnected.Size = new System.Drawing.Size(84, 23);
            this.btnConnected.TabIndex = 8;
            this.btnConnected.Text = "Disconnect";
            this.btnConnected.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.ForeColor = System.Drawing.Color.ForestGreen;
            this.label6.Location = new System.Drawing.Point(21, 210);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(215, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Total(Completed) Record:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.ForeColor = System.Drawing.Color.ForestGreen;
            this.label4.Location = new System.Drawing.Point(21, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(181, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Total(Result) Record:";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // lblTotalCompleted
            // 
            this.lblTotalCompleted.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblTotalCompleted.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblTotalCompleted.Location = new System.Drawing.Point(233, 210);
            this.lblTotalCompleted.Name = "lblTotalCompleted";
            this.lblTotalCompleted.Size = new System.Drawing.Size(149, 23);
            this.lblTotalCompleted.TabIndex = 13;
            this.lblTotalCompleted.Text = "0";
            // 
            // lblServerStatus
            // 
            this.lblServerStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblServerStatus.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblServerStatus.Location = new System.Drawing.Point(144, 49);
            this.lblServerStatus.Name = "lblServerStatus";
            this.lblServerStatus.Size = new System.Drawing.Size(192, 72);
            this.lblServerStatus.TabIndex = 4;
            this.lblServerStatus.Text = "Machine Name";
            this.lblServerStatus.DoubleClick += new System.EventHandler(this.lblServerStatus_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.ForeColor = System.Drawing.Color.ForestGreen;
            this.label2.Location = new System.Drawing.Point(15, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Server Status:";
            // 
            // lblMachineName
            // 
            this.lblMachineName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblMachineName.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblMachineName.Location = new System.Drawing.Point(144, 22);
            this.lblMachineName.Name = "lblMachineName";
            this.lblMachineName.Size = new System.Drawing.Size(192, 23);
            this.lblMachineName.TabIndex = 1;
            this.lblMachineName.Text = "Machine Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.ForestGreen;
            this.label1.Location = new System.Drawing.Point(15, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server Name:";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // pHeader
            // 
            this.pHeader.BackColor = System.Drawing.Color.Transparent;
            this.pHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pHeader.Controls.Add(this.btnConnected);
            this.pHeader.Controls.Add(this.lblServerStatus);
            this.pHeader.Controls.Add(this.label2);
            this.pHeader.Controls.Add(this.lblMachineName);
            this.pHeader.Controls.Add(this.label1);
            this.pHeader.Location = new System.Drawing.Point(25, 36);
            this.pHeader.Name = "pHeader";
            this.pHeader.Size = new System.Drawing.Size(348, 123);
            this.pHeader.TabIndex = 8;
            // 
            // frmServerUploader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(402, 303);
            this.Controls.Add(this.lblBatchFileCount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblTotalCompleted);
            this.Controls.Add(this.pHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmServerUploader";
            this.Text = "AOI Server Upload";
            this.Load += new System.EventHandler(this.frmServerUploader_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.pHeader.ResumeLayout(false);
            this.pHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem executeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label lblBatchFileCount;
        private System.Windows.Forms.Timer tmrResult;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnConnected;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Label lblTotalCompleted;
        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.Label lblServerStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMachineName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog ResultFileBro;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

