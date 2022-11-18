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
            this.gConsole1.Location = new System.Drawing.Point(370, 6);
            this.gConsole1.Name = "gConsole1";
            this.gConsole1.Size = new System.Drawing.Size(753, 670);
            this.gConsole1.TabIndex = 0;
            this.gConsole1.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(18, 284);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 25);
            this.label9.TabIndex = 71;
            this.label9.Text = "Status";
            // 
            // txtStatus1
            // 
            this.txtStatus1.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus1.Location = new System.Drawing.Point(23, 312);
            this.txtStatus1.Multiline = true;
            this.txtStatus1.Name = "txtStatus1";
            this.txtStatus1.ReadOnly = true;
            this.txtStatus1.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtStatus1.Size = new System.Drawing.Size(704, 43);
            this.txtStatus1.TabIndex = 70;
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(385, 16);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(142, 32);
            this.btnConnect.TabIndex = 68;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // grdView1
            // 
            this.grdView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.grdView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.grdView1.BackgroundColor = System.Drawing.Color.DarkOrange;
            this.grdView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdView1.GridColor = System.Drawing.SystemColors.MenuHighlight;
            this.grdView1.Location = new System.Drawing.Point(23, 361);
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
            this.grdView1.Size = new System.Drawing.Size(492, 294);
            this.grdView1.TabIndex = 67;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(18, 210);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(146, 25);
            this.label8.TabIndex = 66;
            this.label8.Text = "2D Barcode";
            // 
            // txt2DBarcode1
            // 
            this.txt2DBarcode1.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt2DBarcode1.Location = new System.Drawing.Point(23, 238);
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
            this.label7.Location = new System.Drawing.Point(18, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 25);
            this.label7.TabIndex = 64;
            this.label7.Text = "USB Port";
            // 
            // txtUsbPort1
            // 
            this.txtUsbPort1.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsbPort1.Location = new System.Drawing.Point(23, 162);
            this.txtUsbPort1.Name = "txtUsbPort1";
            this.txtUsbPort1.ReadOnly = true;
            this.txtUsbPort1.Size = new System.Drawing.Size(492, 43);
            this.txtUsbPort1.TabIndex = 63;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(324, 25);
            this.label6.TabIndex = 62;
            this.label6.Text = "Bending Machine (Tag No)";
            // 
            // txtBendingMachine1
            // 
            this.txtBendingMachine1.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBendingMachine1.Location = new System.Drawing.Point(23, 83);
            this.txtBendingMachine1.Name = "txtBendingMachine1";
            this.txtBendingMachine1.ReadOnly = true;
            this.txtBendingMachine1.Size = new System.Drawing.Size(492, 43);
            this.txtBendingMachine1.TabIndex = 61;
            this.txtBendingMachine1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Verdana", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.Color.Maroon;
            this.Label5.Location = new System.Drawing.Point(18, 16);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(213, 25);
            this.Label5.TabIndex = 41;
            this.Label5.Text = "Bending Machine";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
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
            this.groupBox2.Location = new System.Drawing.Point(12, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(342, 670);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // cboConsole
            // 
            this.cboConsole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboConsole.FormattingEnabled = true;
            this.cboConsole.Items.AddRange(new object[] {
            "Console1",
            "Console2"});
            this.cboConsole.Location = new System.Drawing.Point(11, 238);
            this.cboConsole.Name = "cboConsole";
            this.cboConsole.Size = new System.Drawing.Size(318, 28);
            this.cboConsole.TabIndex = 67;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 210);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(196, 25);
            this.label10.TabIndex = 66;
            this.label10.Text = "Console Display";
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(184, 351);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(142, 32);
            this.btnExit.TabIndex = 65;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(36, 351);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(142, 32);
            this.btnAdd.TabIndex = 64;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cboUSBPort
            // 
            this.cboUSBPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUSBPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboUSBPort.FormattingEnabled = true;
            this.cboUSBPort.Location = new System.Drawing.Point(11, 297);
            this.cboUSBPort.Name = "cboUSBPort";
            this.cboUSBPort.Size = new System.Drawing.Size(318, 28);
            this.cboUSBPort.TabIndex = 63;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 269);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 25);
            this.label4.TabIndex = 62;
            this.label4.Text = "USB Port";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(324, 25);
            this.label3.TabIndex = 60;
            this.label3.Text = "Bending Machine (Tag No)";
            // 
            // txtBendingMachine
            // 
            this.txtBendingMachine.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBendingMachine.Location = new System.Drawing.Point(11, 162);
            this.txtBendingMachine.Name = "txtBendingMachine";
            this.txtBendingMachine.Size = new System.Drawing.Size(323, 43);
            this.txtBendingMachine.TabIndex = 59;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Verdana", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(6, 55);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(202, 25);
            this.Label2.TabIndex = 58;
            this.Label2.Text = "Computer Name";
            // 
            // txtComputerName
            // 
            this.txtComputerName.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComputerName.Location = new System.Drawing.Point(11, 83);
            this.txtComputerName.Name = "txtComputerName";
            this.txtComputerName.ReadOnly = true;
            this.txtComputerName.Size = new System.Drawing.Size(321, 43);
            this.txtComputerName.TabIndex = 57;
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
            this.ClientSize = new System.Drawing.Size(1134, 688);
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
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtComputerName;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtBendingMachine;
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
    }
}

