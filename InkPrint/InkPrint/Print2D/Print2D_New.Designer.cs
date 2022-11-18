namespace InkPrint.Print2D_New
{
    partial class Print2D_New
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Print2D_New));
            this.txtJobNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenSerial = new System.Windows.Forms.Button();
            this.txtQtyBoard = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gvSerial = new System.Windows.Forms.DataGridView();
            this.SerialNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JobName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SUBJOB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Print_Flag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GenCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOutPutPath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMachine = new System.Windows.Forms.TextBox();
            this.txtQtySheet = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMpn = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gvSerial)).BeginInit();
            this.SuspendLayout();
            // 
            // txtJobNo
            // 
            this.txtJobNo.BackColor = System.Drawing.Color.White;
            this.txtJobNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtJobNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtJobNo.ForeColor = System.Drawing.Color.Black;
            this.txtJobNo.Location = new System.Drawing.Point(148, 140);
            this.txtJobNo.Name = "txtJobNo";
            this.txtJobNo.Size = new System.Drawing.Size(250, 35);
            this.txtJobNo.TabIndex = 6;
            this.txtJobNo.TextChanged += new System.EventHandler(this.txtJobNo_TextChanged);
            this.txtJobNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtJobNo_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(79, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 20);
            this.label4.TabIndex = 59;
            this.label4.Text = "Job No:";
            // 
            // txtQty
            // 
            this.txtQty.BackColor = System.Drawing.Color.White;
            this.txtQty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtQty.ForeColor = System.Drawing.Color.Black;
            this.txtQty.Location = new System.Drawing.Point(148, 181);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(118, 35);
            this.txtQty.TabIndex = 10;
            this.txtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQty_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(101, 191);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 20);
            this.label1.TabIndex = 61;
            this.label1.Text = "Qty :";
            // 
            // btnGenSerial
            // 
            this.btnGenSerial.Image = global::InkPrint.Properties.Resources.Gen2D;
            this.btnGenSerial.Location = new System.Drawing.Point(376, 260);
            this.btnGenSerial.Name = "btnGenSerial";
            this.btnGenSerial.Size = new System.Drawing.Size(157, 44);
            this.btnGenSerial.TabIndex = 62;
            this.btnGenSerial.UseVisualStyleBackColor = true;
            this.btnGenSerial.Click += new System.EventHandler(this.btnGenSerial_Click);
            // 
            // txtQtyBoard
            // 
            this.txtQtyBoard.BackColor = System.Drawing.SystemColors.Window;
            this.txtQtyBoard.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQtyBoard.Enabled = false;
            this.txtQtyBoard.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtQtyBoard.ForeColor = System.Drawing.Color.Black;
            this.txtQtyBoard.Location = new System.Drawing.Point(376, 181);
            this.txtQtyBoard.Name = "txtQtyBoard";
            this.txtQtyBoard.Size = new System.Drawing.Size(94, 35);
            this.txtQtyBoard.TabIndex = 63;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(282, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 64;
            this.label2.Text = "Qty/Board :";
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::InkPrint.Properties.Resources.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(193, 259);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(159, 45);
            this.btnCancel.TabIndex = 65;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // gvSerial
            // 
            this.gvSerial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvSerial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SerialNo,
            this.JobName,
            this.SUBJOB,
            this.Print_Flag,
            this.GenCode});
            this.gvSerial.Location = new System.Drawing.Point(682, 32);
            this.gvSerial.Name = "gvSerial";
            this.gvSerial.Size = new System.Drawing.Size(613, 588);
            this.gvSerial.TabIndex = 66;
            // 
            // SerialNo
            // 
            this.SerialNo.DataPropertyName = "SerialNo";
            this.SerialNo.FillWeight = 150F;
            this.SerialNo.HeaderText = "Serial No";
            this.SerialNo.Name = "SerialNo";
            this.SerialNo.ReadOnly = true;
            this.SerialNo.Width = 150;
            // 
            // JobName
            // 
            this.JobName.DataPropertyName = "JobName";
            this.JobName.HeaderText = "Job Name";
            this.JobName.Name = "JobName";
            this.JobName.ReadOnly = true;
            // 
            // SUBJOB
            // 
            this.SUBJOB.DataPropertyName = "SUBJOB";
            this.SUBJOB.FillWeight = 80F;
            this.SUBJOB.HeaderText = "Sub Job";
            this.SUBJOB.Name = "SUBJOB";
            this.SUBJOB.ReadOnly = true;
            this.SUBJOB.Width = 80;
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
            // GenCode
            // 
            this.GenCode.DataPropertyName = "GenCode";
            this.GenCode.HeaderText = "GenCode";
            this.GenCode.Name = "GenCode";
            this.GenCode.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(39, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 20);
            this.label3.TabIndex = 69;
            this.label3.Text = "Ink Machine :";
            // 
            // txtFileName
            // 
            this.txtFileName.Enabled = false;
            this.txtFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtFileName.Location = new System.Drawing.Point(497, 106);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(171, 26);
            this.txtFileName.TabIndex = 73;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.Location = new System.Drawing.Point(403, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 20);
            this.label5.TabIndex = 72;
            this.label5.Text = "File Name :";
            // 
            // txtOutPutPath
            // 
            this.txtOutPutPath.Enabled = false;
            this.txtOutPutPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtOutPutPath.Location = new System.Drawing.Point(148, 106);
            this.txtOutPutPath.Name = "txtOutPutPath";
            this.txtOutPutPath.Size = new System.Drawing.Size(250, 26);
            this.txtOutPutPath.TabIndex = 71;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.Location = new System.Drawing.Point(10, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 20);
            this.label6.TabIndex = 70;
            this.label6.Text = "Output File Path :";
            // 
            // txtMachine
            // 
            this.txtMachine.BackColor = System.Drawing.Color.White;
            this.txtMachine.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMachine.Enabled = false;
            this.txtMachine.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtMachine.ForeColor = System.Drawing.Color.Black;
            this.txtMachine.Location = new System.Drawing.Point(148, 65);
            this.txtMachine.Name = "txtMachine";
            this.txtMachine.Size = new System.Drawing.Size(250, 35);
            this.txtMachine.TabIndex = 74;
            // 
            // txtQtySheet
            // 
            this.txtQtySheet.BackColor = System.Drawing.SystemColors.Window;
            this.txtQtySheet.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQtySheet.Enabled = false;
            this.txtQtySheet.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtQtySheet.ForeColor = System.Drawing.Color.Black;
            this.txtQtySheet.Location = new System.Drawing.Point(574, 176);
            this.txtQtySheet.Name = "txtQtySheet";
            this.txtQtySheet.Size = new System.Drawing.Size(94, 35);
            this.txtQtySheet.TabIndex = 75;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.Location = new System.Drawing.Point(480, 186);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 20);
            this.label7.TabIndex = 76;
            this.label7.Text = "Qty/Sheet :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(350, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(144, 25);
            this.label8.TabIndex = 77;
            this.label8.Text = "Ink Print Job";
            // 
            // txtMpn
            // 
            this.txtMpn.BackColor = System.Drawing.Color.White;
            this.txtMpn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMpn.Enabled = false;
            this.txtMpn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtMpn.ForeColor = System.Drawing.Color.Black;
            this.txtMpn.Location = new System.Drawing.Point(497, 135);
            this.txtMpn.Name = "txtMpn";
            this.txtMpn.Size = new System.Drawing.Size(171, 35);
            this.txtMpn.TabIndex = 78;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label9.Location = new System.Drawing.Point(440, 145);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 20);
            this.label9.TabIndex = 79;
            this.label9.Text = "MPN :";
            // 
            // Print2D_New
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1307, 632);
            this.Controls.Add(this.txtMpn);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtQtySheet);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtMachine);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtOutPutPath);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gvSerial);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtQtyBoard);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGenSerial);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtJobNo);
            this.Controls.Add(this.label4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Print2D_New";
            this.Text = "Ink Print Job ";
            this.Load += new System.EventHandler(this.Print2D_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvSerial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtJobNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGenSerial;
        private System.Windows.Forms.TextBox txtQtyBoard;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView gvSerial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtOutPutPath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMachine;
        private System.Windows.Forms.DataGridViewTextBoxColumn SerialNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn JobName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SUBJOB;
        private System.Windows.Forms.DataGridViewTextBoxColumn Print_Flag;
        private System.Windows.Forms.DataGridViewTextBoxColumn GenCode;
        private System.Windows.Forms.TextBox txtQtySheet;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMpn;
        private System.Windows.Forms.Label label9;
    }
}