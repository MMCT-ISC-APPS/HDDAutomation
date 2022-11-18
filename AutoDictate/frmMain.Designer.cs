namespace AutoDictate
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.lblModel = new System.Windows.Forms.Label();
            this.txtEn = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cboProdLine = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboLane = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grdView = new System.Windows.Forms.DataGridView();
            this.no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.processname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileName = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmrProcess = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.GroupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).BeginInit();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label10.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label10.Location = new System.Drawing.Point(130, 18);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(369, 29);
            this.label10.TabIndex = 15;
            this.label10.Text = "AI Traceability :: Auto Dictate";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(7, 13);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(115, 43);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Label8.ForeColor = System.Drawing.Color.Blue;
            this.Label8.Location = new System.Drawing.Point(26, 48);
            this.Label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(50, 23);
            this.Label8.TabIndex = 65;
            this.Label8.Text = "EN :";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Label2.ForeColor = System.Drawing.Color.Blue;
            this.Label2.Location = new System.Drawing.Point(26, 123);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(75, 23);
            this.Label2.TabIndex = 69;
            this.Label2.Text = "Model:";
            // 
            // txtModel
            // 
            this.txtModel.AcceptsReturn = true;
            this.txtModel.BackColor = System.Drawing.SystemColors.Window;
            this.txtModel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtModel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtModel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtModel.Location = new System.Drawing.Point(153, 123);
            this.txtModel.Margin = new System.Windows.Forms.Padding(4);
            this.txtModel.MaxLength = 25;
            this.txtModel.Name = "txtModel";
            this.txtModel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtModel.Size = new System.Drawing.Size(277, 27);
            this.txtModel.TabIndex = 68;
            this.txtModel.Text = "Wait";
            this.txtModel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtModel.TextChanged += new System.EventHandler(this.txtJobNo_TextChanged);
            this.txtModel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtJobNo_KeyPress);
            // 
            // lblModel
            // 
            this.lblModel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblModel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblModel.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblModel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblModel.ForeColor = System.Drawing.Color.Blue;
            this.lblModel.Location = new System.Drawing.Point(438, 123);
            this.lblModel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblModel.Name = "lblModel";
            this.lblModel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblModel.Size = new System.Drawing.Size(185, 29);
            this.lblModel.TabIndex = 70;
            this.lblModel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtEn
            // 
            this.txtEn.AcceptsReturn = true;
            this.txtEn.BackColor = System.Drawing.SystemColors.Window;
            this.txtEn.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtEn.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtEn.Location = new System.Drawing.Point(153, 48);
            this.txtEn.Margin = new System.Windows.Forms.Padding(4);
            this.txtEn.MaxLength = 10;
            this.txtEn.Name = "txtEn";
            this.txtEn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtEn.Size = new System.Drawing.Size(276, 26);
            this.txtEn.TabIndex = 0;
            this.txtEn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEn_KeyPress);
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatus.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblStatus.ForeColor = System.Drawing.Color.Blue;
            this.lblStatus.Location = new System.Drawing.Point(30, 166);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblStatus.Size = new System.Drawing.Size(463, 29);
            this.lblStatus.TabIndex = 77;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // GroupBox2
            // 
            this.GroupBox2.BackColor = System.Drawing.Color.Aqua;
            this.GroupBox2.Controls.Add(this.btnCancel);
            this.GroupBox2.Controls.Add(this.cboProdLine);
            this.GroupBox2.Controls.Add(this.label3);
            this.GroupBox2.Controls.Add(this.cboLane);
            this.GroupBox2.Controls.Add(this.label1);
            this.GroupBox2.Controls.Add(this.btnUpload);
            this.GroupBox2.Controls.Add(this.btnConnect);
            this.GroupBox2.Controls.Add(this.lblStatus);
            this.GroupBox2.Controls.Add(this.txtEn);
            this.GroupBox2.Controls.Add(this.lblModel);
            this.GroupBox2.Controls.Add(this.txtModel);
            this.GroupBox2.Controls.Add(this.Label2);
            this.GroupBox2.Controls.Add(this.Label8);
            this.GroupBox2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.GroupBox2.Location = new System.Drawing.Point(7, 69);
            this.GroupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.GroupBox2.Size = new System.Drawing.Size(878, 207);
            this.GroupBox2.TabIndex = 16;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Runcard Information";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(759, 40);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(107, 37);
            this.btnCancel.TabIndex = 85;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cboProdLine
            // 
            this.cboProdLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProdLine.FormattingEnabled = true;
            this.cboProdLine.Location = new System.Drawing.Point(539, 88);
            this.cboProdLine.Name = "cboProdLine";
            this.cboProdLine.Size = new System.Drawing.Size(276, 31);
            this.cboProdLine.TabIndex = 84;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(436, 88);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 23);
            this.label3.TabIndex = 83;
            this.label3.Text = "Prod Line:";
            // 
            // cboLane
            // 
            this.cboLane.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLane.FormattingEnabled = true;
            this.cboLane.Location = new System.Drawing.Point(153, 85);
            this.cboLane.Name = "cboLane";
            this.cboLane.Size = new System.Drawing.Size(276, 31);
            this.cboLane.TabIndex = 82;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(26, 85);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 23);
            this.label1.TabIndex = 81;
            this.label1.Text = "LANE:";
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(644, 37);
            this.btnUpload.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(107, 37);
            this.btnUpload.TabIndex = 80;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(437, 41);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(133, 37);
            this.btnConnect.TabIndex = 79;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Aqua;
            this.groupBox1.Controls.Add(this.grdView);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox1.Location = new System.Drawing.Point(7, 284);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(878, 263);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Machine Configuration";
            // 
            // grdView
            // 
            this.grdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.no,
            this.processname,
            this.FileName,
            this.Status});
            this.grdView.Location = new System.Drawing.Point(7, 39);
            this.grdView.Name = "grdView";
            this.grdView.RowTemplate.Height = 24;
            this.grdView.Size = new System.Drawing.Size(864, 217);
            this.grdView.TabIndex = 0;
            // 
            // no
            // 
            this.no.DataPropertyName = "no";
            this.no.FillWeight = 50F;
            this.no.Frozen = true;
            this.no.HeaderText = "No";
            this.no.Name = "no";
            this.no.Width = 50;
            // 
            // processname
            // 
            this.processname.DataPropertyName = "opername";
            this.processname.FillWeight = 150F;
            this.processname.Frozen = true;
            this.processname.HeaderText = "Process Name";
            this.processname.Name = "processname";
            this.processname.ReadOnly = true;
            this.processname.Width = 150;
            // 
            // FileName
            // 
            this.FileName.DataPropertyName = "filename";
            this.FileName.FillWeight = 300F;
            this.FileName.HeaderText = "FileName";
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            this.FileName.Width = 300;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "status";
            this.Status.FillWeight = 200F;
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 200;
            // 
            // tmrProcess
            // 
            this.tmrProcess.Interval = 3000;
            this.tmrProcess.Tick += new System.EventHandler(this.tmrProcess_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(892, 553);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Auto Dictate";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Label8;
        private System.Windows.Forms.Label Label2;
        public System.Windows.Forms.TextBox txtModel;
        public System.Windows.Forms.Label lblModel;
        public System.Windows.Forms.TextBox txtEn;
        public System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.Button btnConnect;
        internal System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView grdView;
        private System.Windows.Forms.DataGridViewTextBoxColumn no;
        private System.Windows.Forms.DataGridViewTextBoxColumn processname;
        private System.Windows.Forms.DataGridViewLinkColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboLane;
        private System.Windows.Forms.ComboBox cboProdLine;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer tmrProcess;
        internal System.Windows.Forms.Button btnCancel;
    }
}

