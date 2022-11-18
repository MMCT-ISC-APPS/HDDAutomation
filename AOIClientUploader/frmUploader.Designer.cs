using System.Windows.Forms;

namespace AOIClientUploader
{
    partial class frmUploader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUploader));
            this.pHeader = new System.Windows.Forms.Panel();
            this.btnConnected = new System.Windows.Forms.Button();
            this.lblServerStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMachineName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pSetting = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSetting = new System.Windows.Forms.Button();
            this.btnSolderPath = new System.Windows.Forms.Button();
            this.lblSolderPath = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnResultPath = new System.Windows.Forms.Button();
            this.lblResultPath = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ResultFileBro = new System.Windows.Forms.FolderBrowserDialog();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.executeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pFileCount = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.lblBatchFileCount = new System.Windows.Forms.Label();
            this.tmrResult = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblTotalCompleted = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pHeader.SuspendLayout();
            this.pSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.pHeader.Location = new System.Drawing.Point(12, 4);
            this.pHeader.Name = "pHeader";
            this.pHeader.Size = new System.Drawing.Size(348, 123);
            this.pHeader.TabIndex = 0;
            // 
            // btnConnected
            // 
            this.btnConnected.Location = new System.Drawing.Point(23, 86);
            this.btnConnected.Name = "btnConnected";
            this.btnConnected.Size = new System.Drawing.Size(84, 23);
            this.btnConnected.TabIndex = 8;
            this.btnConnected.Text = "Disconnect";
            this.btnConnected.UseVisualStyleBackColor = true;
            this.btnConnected.Click += new System.EventHandler(this.btnConnected_Click);
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
            this.lblServerStatus.Click += new System.EventHandler(this.lblServerStatus_Click);
            this.lblServerStatus.DoubleClick += new System.EventHandler(this.lblServerStatus_DoubleClick_1);
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
            this.label1.Size = new System.Drawing.Size(132, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Machine Name:";
            // 
            // pSetting
            // 
            this.pSetting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pSetting.Controls.Add(this.btnSave);
            this.pSetting.Controls.Add(this.btnSetting);
            this.pSetting.Controls.Add(this.btnSolderPath);
            this.pSetting.Controls.Add(this.lblSolderPath);
            this.pSetting.Controls.Add(this.label5);
            this.pSetting.Controls.Add(this.btnResultPath);
            this.pSetting.Controls.Add(this.lblResultPath);
            this.pSetting.Controls.Add(this.label3);
            this.pSetting.Location = new System.Drawing.Point(12, 133);
            this.pSetting.Name = "pSetting";
            this.pSetting.Size = new System.Drawing.Size(348, 153);
            this.pSetting.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(113, 90);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save Setting";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.Location = new System.Drawing.Point(13, 90);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(84, 23);
            this.btnSetting.TabIndex = 7;
            this.btnSetting.Text = "Setting";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // btnSolderPath
            // 
            this.btnSolderPath.Location = new System.Drawing.Point(300, 48);
            this.btnSolderPath.Name = "btnSolderPath";
            this.btnSolderPath.Size = new System.Drawing.Size(39, 23);
            this.btnSolderPath.TabIndex = 6;
            this.btnSolderPath.Text = "...";
            this.btnSolderPath.UseVisualStyleBackColor = true;
            this.btnSolderPath.Click += new System.EventHandler(this.btnSolderPath_Click);
            // 
            // lblSolderPath
            // 
            this.lblSolderPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblSolderPath.ForeColor = System.Drawing.Color.Turquoise;
            this.lblSolderPath.Location = new System.Drawing.Point(110, 51);
            this.lblSolderPath.Name = "lblSolderPath";
            this.lblSolderPath.Size = new System.Drawing.Size(192, 23);
            this.lblSolderPath.TabIndex = 5;
            this.lblSolderPath.Text = "Path";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.ForeColor = System.Drawing.Color.ForestGreen;
            this.label5.Location = new System.Drawing.Point(-1, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Solder Path:";
            // 
            // btnResultPath
            // 
            this.btnResultPath.Location = new System.Drawing.Point(300, 11);
            this.btnResultPath.Name = "btnResultPath";
            this.btnResultPath.Size = new System.Drawing.Size(39, 23);
            this.btnResultPath.TabIndex = 3;
            this.btnResultPath.Text = "...";
            this.btnResultPath.UseVisualStyleBackColor = true;
            this.btnResultPath.Click += new System.EventHandler(this.btnResultPath_Click);
            // 
            // lblResultPath
            // 
            this.lblResultPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblResultPath.ForeColor = System.Drawing.Color.Turquoise;
            this.lblResultPath.Location = new System.Drawing.Point(110, 14);
            this.lblResultPath.Name = "lblResultPath";
            this.lblResultPath.Size = new System.Drawing.Size(192, 23);
            this.lblResultPath.TabIndex = 2;
            this.lblResultPath.Text = "Path";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.ForeColor = System.Drawing.Color.ForestGreen;
            this.label3.Location = new System.Drawing.Point(-1, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Result Path:";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseMove);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.executeToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 52);
            this.contextMenuStrip1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.contextMenuStrip1_MouseDoubleClick);
            // 
            // executeToolStripMenuItem
            // 
            this.executeToolStripMenuItem.Name = "executeToolStripMenuItem";
            this.executeToolStripMenuItem.Size = new System.Drawing.Size(124, 24);
            this.executeToolStripMenuItem.Text = "Execute";
            this.executeToolStripMenuItem.Click += new System.EventHandler(this.executeToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(124, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // pFileCount
            // 
            this.pFileCount.Location = new System.Drawing.Point(23, 360);
            this.pFileCount.Name = "pFileCount";
            this.pFileCount.Size = new System.Drawing.Size(326, 23);
            this.pFileCount.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.ForeColor = System.Drawing.Color.ForestGreen;
            this.label4.Location = new System.Drawing.Point(22, 299);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Total(Result) Files:";
            // 
            // lblBatchFileCount
            // 
            this.lblBatchFileCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblBatchFileCount.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblBatchFileCount.Location = new System.Drawing.Point(217, 301);
            this.lblBatchFileCount.Name = "lblBatchFileCount";
            this.lblBatchFileCount.Size = new System.Drawing.Size(145, 23);
            this.lblBatchFileCount.TabIndex = 5;
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
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // lblTotalCompleted
            // 
            this.lblTotalCompleted.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblTotalCompleted.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblTotalCompleted.Location = new System.Drawing.Point(215, 324);
            this.lblTotalCompleted.Name = "lblTotalCompleted";
            this.lblTotalCompleted.Size = new System.Drawing.Size(149, 23);
            this.lblTotalCompleted.TabIndex = 6;
            this.lblTotalCompleted.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.ForeColor = System.Drawing.Color.ForestGreen;
            this.label6.Location = new System.Drawing.Point(22, 324);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(195, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "Total(Completed) Files:";
            // 
            // lblTime
            // 
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblTime.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblTime.Location = new System.Drawing.Point(167, 400);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(202, 52);
            this.lblTime.TabIndex = 9;
            this.lblTime.Text = "Time";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.ForeColor = System.Drawing.Color.ForestGreen;
            this.label8.Location = new System.Drawing.Point(4, 401);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(164, 20);
            this.label8.TabIndex = 8;
            this.label8.Text = "Last Running Time:";
            // 
            // frmUploader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(372, 498);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblTotalCompleted);
            this.Controls.Add(this.lblBatchFileCount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pFileCount);
            this.Controls.Add(this.pSetting);
            this.Controls.Add(this.pHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmUploader";
            this.Text = "AOI Client Uploader";
            this.Load += new System.EventHandler(this.frmUploader_Load);
            this.pHeader.ResumeLayout(false);
            this.pHeader.PerformLayout();
            this.pSetting.ResumeLayout(false);
            this.pSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMachineName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pSetting;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FolderBrowserDialog ResultFileBro;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Label lblResultPath;
        private System.Windows.Forms.Button btnResultPath;
        private System.Windows.Forms.Button btnSolderPath;
        private System.Windows.Forms.Label lblSolderPath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ProgressBar pFileCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblBatchFileCount;
        private System.Windows.Forms.Timer tmrResult;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripMenuItem executeToolStripMenuItem;
        private System.Windows.Forms.Button btnSave;
        private Label lblServerStatus;
        private Button btnConnected;
        private Label label6;
        private Label lblTotalCompleted;
        private Label lblTime;
        private Label label8;
    }
}

