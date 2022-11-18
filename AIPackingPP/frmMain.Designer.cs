namespace AIPackingPP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.txtFixturesize = new System.Windows.Forms.TextBox();
            this.lblNGQty = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblGoodQty = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblSheetQty = new System.Windows.Forms.Label();
            this.lblJobQty2 = new System.Windows.Forms.Label();
            this.lblJobQty1 = new System.Windows.Forms.Label();
            this.txtJobNo2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtJobNo1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblBundleNo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtEn = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.lblJobQty = new System.Windows.Forms.Label();
            this.lblModel = new System.Windows.Forms.Label();
            this.txtJobNo = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.Frame2 = new System.Windows.Forms.GroupBox();
            this.receive = new System.Windows.Forms.Button();
            this.Txt2DBarCode = new System.Windows.Forms.TextBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.Grid1 = new System.Windows.Forms.DataGridView();
            this.btnDel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.GroupBox2.SuspendLayout();
            this.Frame2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label10.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label10.Location = new System.Drawing.Point(96, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(250, 23);
            this.label10.TabIndex = 13;
            this.label10.Text = "AI Traceability :: Packing";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(86, 35);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // GroupBox2
            // 
            this.GroupBox2.BackColor = System.Drawing.Color.Aqua;
            this.GroupBox2.Controls.Add(this.txtFixturesize);
            this.GroupBox2.Controls.Add(this.lblNGQty);
            this.GroupBox2.Controls.Add(this.label12);
            this.GroupBox2.Controls.Add(this.lblGoodQty);
            this.GroupBox2.Controls.Add(this.label11);
            this.GroupBox2.Controls.Add(this.label7);
            this.GroupBox2.Controls.Add(this.lblSheetQty);
            this.GroupBox2.Controls.Add(this.lblJobQty2);
            this.GroupBox2.Controls.Add(this.lblJobQty1);
            this.GroupBox2.Controls.Add(this.txtJobNo2);
            this.GroupBox2.Controls.Add(this.label4);
            this.GroupBox2.Controls.Add(this.txtJobNo1);
            this.GroupBox2.Controls.Add(this.label6);
            this.GroupBox2.Controls.Add(this.lblBundleNo);
            this.GroupBox2.Controls.Add(this.label1);
            this.GroupBox2.Controls.Add(this.btnConnect);
            this.GroupBox2.Controls.Add(this.lblStatus);
            this.GroupBox2.Controls.Add(this.txtEn);
            this.GroupBox2.Controls.Add(this.btnCancel);
            this.GroupBox2.Controls.Add(this.btnStart);
            this.GroupBox2.Controls.Add(this.Label3);
            this.GroupBox2.Controls.Add(this.lblJobQty);
            this.GroupBox2.Controls.Add(this.lblModel);
            this.GroupBox2.Controls.Add(this.txtJobNo);
            this.GroupBox2.Controls.Add(this.Label2);
            this.GroupBox2.Controls.Add(this.Label8);
            this.GroupBox2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.GroupBox2.Location = new System.Drawing.Point(4, 46);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(1059, 172);
            this.GroupBox2.TabIndex = 14;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Runcard Information";
            this.GroupBox2.Enter += new System.EventHandler(this.GroupBox2_Enter);
            // 
            // txtFixturesize
            // 
            this.txtFixturesize.AcceptsReturn = true;
            this.txtFixturesize.BackColor = System.Drawing.SystemColors.Window;
            this.txtFixturesize.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFixturesize.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtFixturesize.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtFixturesize.Location = new System.Drawing.Point(652, 76);
            this.txtFixturesize.MaxLength = 25;
            this.txtFixturesize.Name = "txtFixturesize";
            this.txtFixturesize.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtFixturesize.Size = new System.Drawing.Size(88, 23);
            this.txtFixturesize.TabIndex = 96;
            this.txtFixturesize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFixturesize.TextChanged += new System.EventHandler(this.txtFixturesize_TextChanged);
            this.txtFixturesize.Enter += new System.EventHandler(this.txtFixturesize_Enter);
            this.txtFixturesize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFixturesize_KeyPress);
            // 
            // lblNGQty
            // 
            this.lblNGQty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblNGQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNGQty.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblNGQty.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblNGQty.ForeColor = System.Drawing.Color.Blue;
            this.lblNGQty.Location = new System.Drawing.Point(957, 98);
            this.lblNGQty.Name = "lblNGQty";
            this.lblNGQty.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblNGQty.Size = new System.Drawing.Size(88, 24);
            this.lblNGQty.TabIndex = 95;
            this.lblNGQty.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label12.ForeColor = System.Drawing.Color.Blue;
            this.label12.Location = new System.Drawing.Point(986, 76);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(36, 18);
            this.label12.TabIndex = 94;
            this.label12.Text = "NG:";
            // 
            // lblGoodQty
            // 
            this.lblGoodQty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblGoodQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblGoodQty.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblGoodQty.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblGoodQty.ForeColor = System.Drawing.Color.Blue;
            this.lblGoodQty.Location = new System.Drawing.Point(957, 48);
            this.lblGoodQty.Name = "lblGoodQty";
            this.lblGoodQty.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblGoodQty.Size = new System.Drawing.Size(88, 24);
            this.lblGoodQty.TabIndex = 93;
            this.lblGoodQty.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label11.ForeColor = System.Drawing.Color.Blue;
            this.label11.Location = new System.Drawing.Point(986, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 18);
            this.label11.TabIndex = 92;
            this.label11.Text = "OK:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(512, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 18);
            this.label7.TabIndex = 91;
            this.label7.Text = "Sheet Size:";
            // 
            // lblSheetQty
            // 
            this.lblSheetQty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblSheetQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSheetQty.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblSheetQty.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblSheetQty.ForeColor = System.Drawing.Color.Blue;
            this.lblSheetQty.Location = new System.Drawing.Point(651, 104);
            this.lblSheetQty.Name = "lblSheetQty";
            this.lblSheetQty.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSheetQty.Size = new System.Drawing.Size(88, 24);
            this.lblSheetQty.TabIndex = 90;
            this.lblSheetQty.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblJobQty2
            // 
            this.lblJobQty2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblJobQty2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblJobQty2.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblJobQty2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblJobQty2.ForeColor = System.Drawing.Color.Blue;
            this.lblJobQty2.Location = new System.Drawing.Point(337, 129);
            this.lblJobQty2.Name = "lblJobQty2";
            this.lblJobQty2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblJobQty2.Size = new System.Drawing.Size(139, 24);
            this.lblJobQty2.TabIndex = 89;
            this.lblJobQty2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblJobQty1
            // 
            this.lblJobQty1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblJobQty1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblJobQty1.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblJobQty1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblJobQty1.ForeColor = System.Drawing.Color.Blue;
            this.lblJobQty1.Location = new System.Drawing.Point(337, 100);
            this.lblJobQty1.Name = "lblJobQty1";
            this.lblJobQty1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblJobQty1.Size = new System.Drawing.Size(139, 24);
            this.lblJobQty1.TabIndex = 88;
            this.lblJobQty1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtJobNo2
            // 
            this.txtJobNo2.AcceptsReturn = true;
            this.txtJobNo2.BackColor = System.Drawing.SystemColors.Window;
            this.txtJobNo2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtJobNo2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtJobNo2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtJobNo2.Location = new System.Drawing.Point(114, 130);
            this.txtJobNo2.MaxLength = 25;
            this.txtJobNo2.Name = "txtJobNo2";
            this.txtJobNo2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtJobNo2.Size = new System.Drawing.Size(209, 23);
            this.txtJobNo2.TabIndex = 87;
            this.txtJobNo2.Text = "Wait";
            this.txtJobNo2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtJobNo2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtJobNo2_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(14, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 18);
            this.label4.TabIndex = 86;
            this.label4.Text = "Job No 3:";
            // 
            // txtJobNo1
            // 
            this.txtJobNo1.AcceptsReturn = true;
            this.txtJobNo1.BackColor = System.Drawing.SystemColors.Window;
            this.txtJobNo1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtJobNo1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtJobNo1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtJobNo1.Location = new System.Drawing.Point(114, 98);
            this.txtJobNo1.MaxLength = 25;
            this.txtJobNo1.Name = "txtJobNo1";
            this.txtJobNo1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtJobNo1.Size = new System.Drawing.Size(209, 23);
            this.txtJobNo1.TabIndex = 85;
            this.txtJobNo1.Text = "Wait";
            this.txtJobNo1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtJobNo1.TextChanged += new System.EventHandler(this.txtJobNo1_TextChanged);
            this.txtJobNo1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtJobNo1_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(14, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 18);
            this.label6.TabIndex = 82;
            this.label6.Text = "Job No 2:";
            // 
            // lblBundleNo
            // 
            this.lblBundleNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblBundleNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBundleNo.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblBundleNo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblBundleNo.ForeColor = System.Drawing.Color.Blue;
            this.lblBundleNo.Location = new System.Drawing.Point(613, 40);
            this.lblBundleNo.Name = "lblBundleNo";
            this.lblBundleNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblBundleNo.Size = new System.Drawing.Size(208, 24);
            this.lblBundleNo.TabIndex = 80;
            this.lblBundleNo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(512, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 18);
            this.label1.TabIndex = 79;
            this.label1.Text = "Bundle No:";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(827, 37);
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
            this.lblStatus.Location = new System.Drawing.Point(556, 133);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblStatus.Size = new System.Drawing.Size(348, 24);
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
            this.btnCancel.Location = new System.Drawing.Point(849, 73);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(78, 30);
            this.btnCancel.TabIndex = 76;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(758, 73);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(80, 30);
            this.btnStart.TabIndex = 75;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Label3.ForeColor = System.Drawing.Color.Blue;
            this.Label3.Location = new System.Drawing.Point(512, 76);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(139, 18);
            this.Label3.TabIndex = 73;
            this.Label3.Text = "Bundle(Sht/Qty):";
            // 
            // lblJobQty
            // 
            this.lblJobQty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblJobQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblJobQty.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblJobQty.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblJobQty.ForeColor = System.Drawing.Color.Blue;
            this.lblJobQty.Location = new System.Drawing.Point(337, 69);
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
            this.lblModel.Location = new System.Drawing.Point(337, 40);
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
            this.txtJobNo.Location = new System.Drawing.Point(114, 69);
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
            this.Label2.Location = new System.Drawing.Point(14, 69);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(82, 18);
            this.Label2.TabIndex = 69;
            this.Label2.Text = "Job No 1 :";
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
            // Frame2
            // 
            this.Frame2.BackColor = System.Drawing.Color.Aqua;
            this.Frame2.Controls.Add(this.receive);
            this.Frame2.Controls.Add(this.Txt2DBarCode);
            this.Frame2.Controls.Add(this.lblCount);
            this.Frame2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Frame2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Frame2.Location = new System.Drawing.Point(6, 218);
            this.Frame2.Name = "Frame2";
            this.Frame2.Padding = new System.Windows.Forms.Padding(0);
            this.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Frame2.Size = new System.Drawing.Size(1057, 76);
            this.Frame2.TabIndex = 17;
            this.Frame2.TabStop = false;
            this.Frame2.Text = "Panel No";
            // 
            // receive
            // 
            this.receive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.receive.Cursor = System.Windows.Forms.Cursors.Default;
            this.receive.Enabled = false;
            this.receive.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.receive.ForeColor = System.Drawing.SystemColors.ControlText;
            this.receive.Location = new System.Drawing.Point(767, -23);
            this.receive.Name = "receive";
            this.receive.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.receive.Size = new System.Drawing.Size(20, 17);
            this.receive.TabIndex = 67;
            this.receive.Text = "Start";
            this.receive.UseVisualStyleBackColor = false;
            this.receive.Visible = false;
            // 
            // Txt2DBarCode
            // 
            this.Txt2DBarCode.AcceptsReturn = true;
            this.Txt2DBarCode.BackColor = System.Drawing.SystemColors.Window;
            this.Txt2DBarCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Txt2DBarCode.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Txt2DBarCode.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Txt2DBarCode.Location = new System.Drawing.Point(51, 17);
            this.Txt2DBarCode.MaxLength = 25;
            this.Txt2DBarCode.Name = "Txt2DBarCode";
            this.Txt2DBarCode.ReadOnly = true;
            this.Txt2DBarCode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Txt2DBarCode.Size = new System.Drawing.Size(768, 43);
            this.Txt2DBarCode.TabIndex = 0;
            this.Txt2DBarCode.Tag = "";
            this.Txt2DBarCode.Text = "Connecting to Database";
            this.Txt2DBarCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Txt2DBarCode.TextChanged += new System.EventHandler(this.Txt2DBarCode_TextChanged);
            this.Txt2DBarCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt2DBarCode_KeyPress);
            // 
            // lblCount
            // 
            this.lblCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCount.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblCount.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblCount.ForeColor = System.Drawing.Color.Blue;
            this.lblCount.Location = new System.Drawing.Point(825, 17);
            this.lblCount.Name = "lblCount";
            this.lblCount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblCount.Size = new System.Drawing.Size(223, 43);
            this.lblCount.TabIndex = 72;
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Grid1
            // 
            this.Grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid1.Location = new System.Drawing.Point(8, 296);
            this.Grid1.Name = "Grid1";
            this.Grid1.Size = new System.Drawing.Size(1002, 239);
            this.Grid1.TabIndex = 53;
            this.Grid1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid1_CellContentClick);
            this.Grid1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Grid1_CellMouseDoubleClick);
            this.Grid1.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid1_CellMouseEnter);
            this.Grid1.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid1_CellMouseLeave);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(1016, 312);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(49, 30);
            this.btnDel.TabIndex = 76;
            this.btnDel.Text = "Del";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1118, 540);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.Grid1);
            this.Controls.Add(this.Frame2);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AI Packing PP";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.Frame2.ResumeLayout(false);
            this.Frame2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.Button btnConnect;
        public System.Windows.Forms.Label lblStatus;
        public System.Windows.Forms.TextBox txtEn;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label Label3;
        public System.Windows.Forms.Label lblJobQty;
        public System.Windows.Forms.Label lblModel;
        public System.Windows.Forms.TextBox txtJobNo;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Label Label8;
        public System.Windows.Forms.GroupBox Frame2;
        public System.Windows.Forms.Button receive;
        public System.Windows.Forms.TextBox Txt2DBarCode;
        public System.Windows.Forms.Label lblCount;
        public System.Windows.Forms.Label lblBundleNo;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.DataGridView Grid1;
        public System.Windows.Forms.TextBox txtJobNo2;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtJobNo1;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label lblJobQty2;
        public System.Windows.Forms.Label lblJobQty1;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label lblSheetQty;
        public System.Windows.Forms.Label lblNGQty;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.Label lblGoodQty;
        private System.Windows.Forms.Label label11;
        internal System.Windows.Forms.Button btnDel;
        public System.Windows.Forms.TextBox txtFixturesize;
    }
}

