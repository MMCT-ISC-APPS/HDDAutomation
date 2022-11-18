namespace BendingProject
{
    partial class frmBending
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.gConsole1 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtBendingMachine2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtStatus1 = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.grdView1 = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.txt2DBarcode1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUsbPort1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBendingMachine1 = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.textReady = new System.Windows.Forms.TextBox();
            this.txtMC_2 = new System.Windows.Forms.TextBox();
            this.txtMC_1 = new System.Windows.Forms.TextBox();
            this.txtEnStatus = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtEN = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtBendingMachine_2 = new System.Windows.Forms.TextBox();
            this.cboConsole = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cboUSBPort = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBendingMachine = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtComputerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gConsole1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // gConsole1
            // 
            this.gConsole1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.gConsole1.Controls.Add(this.label14);
            this.gConsole1.Controls.Add(this.txtTotal);
            this.gConsole1.Controls.Add(this.label13);
            this.gConsole1.Controls.Add(this.txtBendingMachine2);
            this.gConsole1.Controls.Add(this.label9);
            this.gConsole1.Controls.Add(this.txtStatus1);
            this.gConsole1.Controls.Add(this.btnConnect);
            this.gConsole1.Controls.Add(this.grdView1);
            this.gConsole1.Controls.Add(this.label8);
            this.gConsole1.Controls.Add(this.txt2DBarcode1);
            this.gConsole1.Controls.Add(this.label7);
            this.gConsole1.Controls.Add(this.txtUsbPort1);
            this.gConsole1.Controls.Add(this.label6);
            this.gConsole1.Controls.Add(this.txtBendingMachine1);
            this.gConsole1.Controls.Add(this.Label5);
            this.gConsole1.Location = new System.Drawing.Point(377, 6);
            this.gConsole1.Name = "gConsole1";
            this.gConsole1.Size = new System.Drawing.Size(897, 670);
            this.gConsole1.TabIndex = 0;
            this.gConsole1.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Verdana", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(503, 139);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(159, 25);
            this.label14.TabIndex = 75;
            this.label14.Text = "Total Record";
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(502, 167);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(294, 65);
            this.txtTotal.TabIndex = 74;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(408, 62);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(270, 25);
            this.label13.TabIndex = 73;
            this.label13.Text = "Bending JB2 (Tag No)";
            // 
            // txtBendingMachine2
            // 
            this.txtBendingMachine2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBendingMachine2.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBendingMachine2.Location = new System.Drawing.Point(405, 90);
            this.txtBendingMachine2.Name = "txtBendingMachine2";
            this.txtBendingMachine2.ReadOnly = true;
            this.txtBendingMachine2.Size = new System.Drawing.Size(358, 43);
            this.txtBendingMachine2.TabIndex = 72;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(5, 238);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 25);
            this.label9.TabIndex = 71;
            this.label9.Text = "Status";
            // 
            // txtStatus1
            // 
            this.txtStatus1.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus1.Location = new System.Drawing.Point(2, 266);
            this.txtStatus1.Multiline = true;
            this.txtStatus1.Name = "txtStatus1";
            this.txtStatus1.ReadOnly = true;
            this.txtStatus1.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtStatus1.Size = new System.Drawing.Size(891, 43);
            this.txtStatus1.TabIndex = 70;
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(291, 9);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(142, 32);
            this.btnConnect.TabIndex = 68;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Visible = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // grdView1
            // 
            this.grdView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.grdView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.grdView1.BackgroundColor = System.Drawing.Color.DarkOrange;
            this.grdView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdView1.GridColor = System.Drawing.SystemColors.MenuHighlight;
            this.grdView1.Location = new System.Drawing.Point(3, 361);
            this.grdView1.MultiSelect = false;
            this.grdView1.Name = "grdView1";
            this.grdView1.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.grdView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.grdView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.grdView1.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdView1.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.grdView1.RowTemplate.Height = 18;
            this.grdView1.Size = new System.Drawing.Size(890, 303);
            this.grdView1.TabIndex = 67;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(5, 161);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(146, 25);
            this.label8.TabIndex = 66;
            this.label8.Text = "2D Barcode";
            // 
            // txt2DBarcode1
            // 
            this.txt2DBarcode1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt2DBarcode1.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt2DBarcode1.Location = new System.Drawing.Point(2, 189);
            this.txt2DBarcode1.Name = "txt2DBarcode1";
            this.txt2DBarcode1.Size = new System.Drawing.Size(492, 43);
            this.txt2DBarcode1.TabIndex = 65;
            this.txt2DBarcode1.TextChanged += new System.EventHandler(this.txt2DBarcode1_TextChanged);
            this.txt2DBarcode1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt2DBarcode_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(430, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 25);
            this.label7.TabIndex = 64;
            this.label7.Text = "USB Port";
            this.label7.Visible = false;
            // 
            // txtUsbPort1
            // 
            this.txtUsbPort1.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsbPort1.Location = new System.Drawing.Point(552, 16);
            this.txtUsbPort1.Name = "txtUsbPort1";
            this.txtUsbPort1.ReadOnly = true;
            this.txtUsbPort1.Size = new System.Drawing.Size(245, 43);
            this.txtUsbPort1.TabIndex = 63;
            this.txtUsbPort1.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(5, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(270, 25);
            this.label6.TabIndex = 62;
            this.label6.Text = "Bending JB1 (Tag No)";
            // 
            // txtBendingMachine1
            // 
            this.txtBendingMachine1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBendingMachine1.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBendingMachine1.Location = new System.Drawing.Point(2, 90);
            this.txtBendingMachine1.Name = "txtBendingMachine1";
            this.txtBendingMachine1.ReadOnly = true;
            this.txtBendingMachine1.Size = new System.Drawing.Size(358, 43);
            this.txtBendingMachine1.TabIndex = 61;
            this.txtBendingMachine1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Verdana", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.Color.Maroon;
            this.Label5.Location = new System.Drawing.Point(5, 16);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(213, 25);
            this.Label5.TabIndex = 41;
            this.Label5.Text = "Bending Machine";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Controls.Add(this.btnLogout);
            this.groupBox2.Controls.Add(this.btnLogin);
            this.groupBox2.Controls.Add(this.textReady);
            this.groupBox2.Controls.Add(this.txtMC_2);
            this.groupBox2.Controls.Add(this.txtMC_1);
            this.groupBox2.Controls.Add(this.txtEnStatus);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtEN);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtBendingMachine_2);
            this.groupBox2.Controls.Add(this.cboConsole);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.btnExit);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.cboUSBPort);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtBendingMachine);
            this.groupBox2.Controls.Add(this.Label2);
            this.groupBox2.Controls.Add(this.txtComputerName);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(4, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(368, 670);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(249, 470);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(114, 32);
            this.btnClose.TabIndex = 210;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(129, 470);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(114, 32);
            this.btnLogout.TabIndex = 209;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(8, 469);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(114, 32);
            this.btnLogin.TabIndex = 208;
            this.btnLogin.Text = "Log in";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // textReady
            // 
            this.textReady.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textReady.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.textReady.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textReady.Location = new System.Drawing.Point(2, 399);
            this.textReady.Name = "textReady";
            this.textReady.ReadOnly = true;
            this.textReady.Size = new System.Drawing.Size(363, 36);
            this.textReady.TabIndex = 207;
            this.textReady.Text = "Operation is not ready";
            this.textReady.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtMC_2
            // 
            this.txtMC_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtMC_2.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMC_2.Location = new System.Drawing.Point(274, 330);
            this.txtMC_2.Name = "txtMC_2";
            this.txtMC_2.ReadOnly = true;
            this.txtMC_2.Size = new System.Drawing.Size(91, 33);
            this.txtMC_2.TabIndex = 206;
            this.txtMC_2.Text = "Waiting";
            // 
            // txtMC_1
            // 
            this.txtMC_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtMC_1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMC_1.Location = new System.Drawing.Point(274, 244);
            this.txtMC_1.Name = "txtMC_1";
            this.txtMC_1.ReadOnly = true;
            this.txtMC_1.Size = new System.Drawing.Size(91, 33);
            this.txtMC_1.TabIndex = 205;
            this.txtMC_1.Text = "Waiting";
            // 
            // txtEnStatus
            // 
            this.txtEnStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.txtEnStatus.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEnStatus.Location = new System.Drawing.Point(274, 160);
            this.txtEnStatus.Name = "txtEnStatus";
            this.txtEnStatus.ReadOnly = true;
            this.txtEnStatus.Size = new System.Drawing.Size(91, 33);
            this.txtEnStatus.TabIndex = 204;
            this.txtEnStatus.Text = "Waiting";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(7, 132);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(163, 25);
            this.label12.TabIndex = 71;
            this.label12.Text = "EN# Number";
            // 
            // txtEN
            // 
            this.txtEN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEN.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEN.Location = new System.Drawing.Point(5, 160);
            this.txtEN.Name = "txtEN";
            this.txtEN.Size = new System.Drawing.Size(193, 33);
            this.txtEN.TabIndex = 102;
            this.txtEN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEN_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(8, 302);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(270, 25);
            this.label11.TabIndex = 69;
            this.label11.Text = "Bending JB2 (Tag No)";
            // 
            // txtBendingMachine_2
            // 
            this.txtBendingMachine_2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBendingMachine_2.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBendingMachine_2.Location = new System.Drawing.Point(5, 330);
            this.txtBendingMachine_2.Name = "txtBendingMachine_2";
            this.txtBendingMachine_2.Size = new System.Drawing.Size(268, 33);
            this.txtBendingMachine_2.TabIndex = 104;
            this.txtBendingMachine_2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBendingMachine_2_KeyPress);
            // 
            // cboConsole
            // 
            this.cboConsole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboConsole.FormattingEnabled = true;
            this.cboConsole.Items.AddRange(new object[] {
            "Console1",
            "Console2"});
            this.cboConsole.Location = new System.Drawing.Point(14, 536);
            this.cboConsole.Name = "cboConsole";
            this.cboConsole.Size = new System.Drawing.Size(318, 28);
            this.cboConsole.TabIndex = 200;
            this.cboConsole.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(9, 508);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(196, 25);
            this.label10.TabIndex = 66;
            this.label10.Text = "Console Display";
            this.label10.Visible = false;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(187, 623);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(142, 32);
            this.btnExit.TabIndex = 203;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Visible = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(39, 623);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(142, 32);
            this.btnAdd.TabIndex = 202;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Visible = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cboUSBPort
            // 
            this.cboUSBPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUSBPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboUSBPort.FormattingEnabled = true;
            this.cboUSBPort.Location = new System.Drawing.Point(14, 595);
            this.cboUSBPort.Name = "cboUSBPort";
            this.cboUSBPort.Size = new System.Drawing.Size(318, 28);
            this.cboUSBPort.TabIndex = 201;
            this.cboUSBPort.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 567);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 25);
            this.label4.TabIndex = 62;
            this.label4.Text = "USB Port";
            this.label4.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(270, 25);
            this.label3.TabIndex = 60;
            this.label3.Text = "Bending JB1 (Tag No)";
            // 
            // txtBendingMachine
            // 
            this.txtBendingMachine.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBendingMachine.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBendingMachine.Location = new System.Drawing.Point(4, 244);
            this.txtBendingMachine.Name = "txtBendingMachine";
            this.txtBendingMachine.Size = new System.Drawing.Size(268, 33);
            this.txtBendingMachine.TabIndex = 103;
            this.txtBendingMachine.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBendingMachine_KeyPress);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Verdana", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(7, 55);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(202, 25);
            this.Label2.TabIndex = 58;
            this.Label2.Text = "Computer Name";
            // 
            // txtComputerName
            // 
            this.txtComputerName.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComputerName.Location = new System.Drawing.Point(4, 83);
            this.txtComputerName.Name = "txtComputerName";
            this.txtComputerName.ReadOnly = true;
            this.txtComputerName.Size = new System.Drawing.Size(321, 43);
            this.txtComputerName.TabIndex = 109;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(34, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 25);
            this.label1.TabIndex = 42;
            this.label1.Text = "Bending Console";
            // 
            // frmBending
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(1284, 688);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gConsole1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmBending";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bending";
            this.Load += new System.EventHandler(this.frmBending_Load);
            this.gConsole1.ResumeLayout(false);
            this.gConsole1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.GroupBox gConsole1;
        internal System.Windows.Forms.Label Label5;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.TextBox txtEN;
        internal System.Windows.Forms.TextBox txtComputerName;
        internal System.Windows.Forms.TextBox txtBendingMachine;
        internal System.Windows.Forms.TextBox txtBendingMachine_2;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.ComboBox cboUSBPort;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox txtBendingMachine1;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.TextBox txtUsbPort1;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.TextBox txt2DBarcode1;
        internal System.Windows.Forms.DataGridView grdView1;
        internal System.Windows.Forms.Button btnConnect;
        internal System.Windows.Forms.Button btnAdd;
        internal System.Windows.Forms.Button btnExit;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.TextBox txtStatus1;
        internal System.Windows.Forms.ComboBox cboConsole;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Label label12;        
        internal System.Windows.Forms.Label label11;        
        internal System.Windows.Forms.Label label13;
        internal System.Windows.Forms.TextBox txtBendingMachine2;
        internal System.Windows.Forms.TextBox txtMC_2;
        internal System.Windows.Forms.TextBox txtMC_1;
        internal System.Windows.Forms.TextBox txtEnStatus;
        internal System.Windows.Forms.Button btnLogout;
        internal System.Windows.Forms.Button btnLogin;
        internal System.Windows.Forms.TextBox textReady;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Label label14;
        internal System.Windows.Forms.TextBox txtTotal;
    }
}

