namespace _2DMatchingFixture
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
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtEn = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblFixtureSize = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.lblJobQty = new System.Windows.Forms.Label();
            this.lblModel = new System.Windows.Forms.Label();
            this.txtJobNo = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Frame4 = new System.Windows.Forms.GroupBox();
            this.Grid1 = new System.Windows.Forms.DataGridView();
            this.tmrMonitor = new System.Windows.Forms.Timer(this.components);
            this.bgSVR = new System.ComponentModel.BackgroundWorker();
            this.tmrJobQ = new System.Windows.Forms.Timer(this.components);
            this.p = new System.Windows.Forms.GroupBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.Frame4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupBox2
            // 
            this.GroupBox2.BackColor = System.Drawing.Color.Aqua;
            this.GroupBox2.Controls.Add(this.lblCount);
            this.GroupBox2.Controls.Add(this.btnNext);
            this.GroupBox2.Controls.Add(this.btnConnect);
            this.GroupBox2.Controls.Add(this.lblStatus);
            this.GroupBox2.Controls.Add(this.txtEn);
            this.GroupBox2.Controls.Add(this.btnCancel);
            this.GroupBox2.Controls.Add(this.btnStart);
            this.GroupBox2.Controls.Add(this.lblFixtureSize);
            this.GroupBox2.Controls.Add(this.Label3);
            this.GroupBox2.Controls.Add(this.lblJobQty);
            this.GroupBox2.Controls.Add(this.lblModel);
            this.GroupBox2.Controls.Add(this.txtJobNo);
            this.GroupBox2.Controls.Add(this.Label2);
            this.GroupBox2.Controls.Add(this.Label8);
            this.GroupBox2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.GroupBox2.Location = new System.Drawing.Point(12, 53);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(1251, 119);
            this.GroupBox2.TabIndex = 12;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Runcard Information";
            this.GroupBox2.Enter += new System.EventHandler(this.GroupBox2_Enter);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(528, 78);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(78, 30);
            this.btnNext.TabIndex = 80;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(950, 34);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(100, 30);
            this.btnConnect.TabIndex = 78;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatus.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblStatus.ForeColor = System.Drawing.Color.Blue;
            this.lblStatus.Location = new System.Drawing.Point(612, 79);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblStatus.Size = new System.Drawing.Size(436, 24);
            this.lblStatus.TabIndex = 77;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtEn
            // 
            this.txtEn.AcceptsReturn = true;
            this.txtEn.BackColor = System.Drawing.SystemColors.Window;
            this.txtEn.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtEn.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtEn.Location = new System.Drawing.Point(115, 39);
            this.txtEn.MaxLength = 10;
            this.txtEn.Name = "txtEn";
            this.txtEn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtEn.Size = new System.Drawing.Size(208, 22);
            this.txtEn.TabIndex = 0;
            this.txtEn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEn.TextChanged += new System.EventHandler(this.txtEn_TextChanged);
            this.txtEn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEn_KeyPress);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(444, 78);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(78, 30);
            this.btnCancel.TabIndex = 76;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(362, 78);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(80, 30);
            this.btnStart.TabIndex = 75;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblFixtureSize
            // 
            this.lblFixtureSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblFixtureSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFixtureSize.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblFixtureSize.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblFixtureSize.ForeColor = System.Drawing.Color.Blue;
            this.lblFixtureSize.Location = new System.Drawing.Point(116, 79);
            this.lblFixtureSize.Name = "lblFixtureSize";
            this.lblFixtureSize.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblFixtureSize.Size = new System.Drawing.Size(207, 24);
            this.lblFixtureSize.TabIndex = 74;
            this.lblFixtureSize.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Label3.ForeColor = System.Drawing.Color.Blue;
            this.Label3.Location = new System.Drawing.Point(14, 78);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(103, 18);
            this.Label3.TabIndex = 73;
            this.Label3.Text = "Fixture Size:";
            // 
            // lblJobQty
            // 
            this.lblJobQty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblJobQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblJobQty.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblJobQty.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblJobQty.ForeColor = System.Drawing.Color.Blue;
            this.lblJobQty.Location = new System.Drawing.Point(802, 38);
            this.lblJobQty.Name = "lblJobQty";
            this.lblJobQty.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblJobQty.Size = new System.Drawing.Size(139, 24);
            this.lblJobQty.TabIndex = 71;
            this.lblJobQty.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblModel
            // 
            this.lblModel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblModel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblModel.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblModel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblModel.ForeColor = System.Drawing.Color.Blue;
            this.lblModel.Location = new System.Drawing.Point(657, 38);
            this.lblModel.Name = "lblModel";
            this.lblModel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblModel.Size = new System.Drawing.Size(139, 24);
            this.lblModel.TabIndex = 70;
            this.lblModel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtJobNo
            // 
            this.txtJobNo.AcceptsReturn = true;
            this.txtJobNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtJobNo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtJobNo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtJobNo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtJobNo.Location = new System.Drawing.Point(436, 38);
            this.txtJobNo.MaxLength = 25;
            this.txtJobNo.Name = "txtJobNo";
            this.txtJobNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtJobNo.Size = new System.Drawing.Size(209, 23);
            this.txtJobNo.TabIndex = 68;
            this.txtJobNo.Text = "Wait";
            this.txtJobNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtJobNo.TextChanged += new System.EventHandler(this.txtJobNo_TextChanged);
            this.txtJobNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtJobNo_KeyPress);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Label2.ForeColor = System.Drawing.Color.Blue;
            this.Label2.Location = new System.Drawing.Point(340, 40);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(76, 18);
            this.Label2.TabIndex = 69;
            this.Label2.Text = "Job No   :";
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Label8.ForeColor = System.Drawing.Color.Blue;
            this.Label8.Location = new System.Drawing.Point(14, 39);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(38, 18);
            this.Label8.TabIndex = 65;
            this.Label8.Text = "EN :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label10.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label10.Location = new System.Drawing.Point(104, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(331, 23);
            this.label10.TabIndex = 11;
            this.label10.Text = "HDD Traceability :: Auto Vericode";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(86, 35);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // Frame4
            // 
            this.Frame4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Frame4.Controls.Add(this.Grid1);
            this.Frame4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Frame4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Frame4.Location = new System.Drawing.Point(14, 178);
            this.Frame4.Name = "Frame4";
            this.Frame4.Padding = new System.Windows.Forms.Padding(0);
            this.Frame4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Frame4.Size = new System.Drawing.Size(1263, 428);
            this.Frame4.TabIndex = 17;
            this.Frame4.TabStop = false;
            this.Frame4.Text = "History";
            // 
            // Grid1
            // 
            this.Grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid1.Location = new System.Drawing.Point(10, 19);
            this.Grid1.Name = "Grid1";
            this.Grid1.Size = new System.Drawing.Size(292, 397);
            this.Grid1.TabIndex = 52;
            // 
            // tmrMonitor
            // 
            this.tmrMonitor.Tick += new System.EventHandler(this.tmrMonitor_Tick);
            // 
            // bgSVR
            // 
            this.bgSVR.WorkerReportsProgress = true;
            this.bgSVR.WorkerSupportsCancellation = true;
            this.bgSVR.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgSVR_DoWork);
            this.bgSVR.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgSVR_ProgressChanged);
            this.bgSVR.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgSVR_RunWorkerCompleted);
            // 
            // tmrJobQ
            // 
            this.tmrJobQ.Tick += new System.EventHandler(this.tmrJobQ_Tick);
            // 
            // p
            // 
            this.p.BackColor = System.Drawing.Color.MidnightBlue;
            this.p.Location = new System.Drawing.Point(337, 178);
            this.p.Name = "p";
            this.p.Size = new System.Drawing.Size(924, 419);
            this.p.TabIndex = 6;
            this.p.TabStop = false;
            this.p.Text = "Screen";
            // 
            // lblCount
            // 
            this.lblCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCount.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblCount.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblCount.ForeColor = System.Drawing.Color.Blue;
            this.lblCount.Location = new System.Drawing.Point(1079, 34);
            this.lblCount.Name = "lblCount";
            this.lblCount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblCount.Size = new System.Drawing.Size(166, 69);
            this.lblCount.TabIndex = 81;
            this.lblCount.Text = "0 Records";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1275, 616);
            this.Controls.Add(this.p);
            this.Controls.Add(this.Frame4);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.GroupBox2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutoVericode";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.Frame4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnStart;
        public System.Windows.Forms.Label lblFixtureSize;
        private System.Windows.Forms.Label Label3;
        public System.Windows.Forms.Label lblJobQty;
        public System.Windows.Forms.Label lblModel;
        public System.Windows.Forms.TextBox txtJobNo;
        private System.Windows.Forms.Label Label2;
        public System.Windows.Forms.TextBox txtEn;
        private System.Windows.Forms.Label Label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.GroupBox Frame4;
        internal System.Windows.Forms.DataGridView Grid1;
        private System.Windows.Forms.Timer tmrMonitor;
        public System.Windows.Forms.Label lblStatus;
        internal System.Windows.Forms.Button btnConnect;
        public System.ComponentModel.BackgroundWorker bgSVR;
        private System.Windows.Forms.Timer tmrJobQ;
        internal System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.GroupBox p;
        public System.Windows.Forms.Label lblCount;
    }
}

