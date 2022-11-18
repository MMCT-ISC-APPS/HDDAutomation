namespace InkPrint.Print2D
{
    partial class InkPrintPath
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InkPrintPath));
            this.dtMachine = new System.Windows.Forms.DataGridView();
            this.Ink_Mac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ink_OutPut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ink_FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ink_QtyBoard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ink_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.rdAactive = new System.Windows.Forms.RadioButton();
            this.rdInactive = new System.Windows.Forms.RadioButton();
            this.txtMacCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOutPutPath = new System.Windows.Forms.TextBox();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtQtyBoard = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtMachine)).BeginInit();
            this.SuspendLayout();
            // 
            // dtMachine
            // 
            this.dtMachine.AllowUserToDeleteRows = false;
            this.dtMachine.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.dtMachine.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtMachine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtMachine.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ink_Mac,
            this.Ink_OutPut,
            this.Ink_FileName,
            this.Ink_QtyBoard,
            this.Ink_Status,
            this.Edit});
            this.dtMachine.Location = new System.Drawing.Point(12, 336);
            this.dtMachine.Name = "dtMachine";
            this.dtMachine.ReadOnly = true;
            this.dtMachine.Size = new System.Drawing.Size(1260, 369);
            this.dtMachine.TabIndex = 9;
            this.dtMachine.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtMachine_CellContentClick);
            // 
            // Ink_Mac
            // 
            this.Ink_Mac.DataPropertyName = "Ink_Mac";
            this.Ink_Mac.HeaderText = "Ink Machine";
            this.Ink_Mac.Name = "Ink_Mac";
            this.Ink_Mac.ReadOnly = true;
            // 
            // Ink_OutPut
            // 
            this.Ink_OutPut.DataPropertyName = "Ink_OutPut";
            this.Ink_OutPut.FillWeight = 150F;
            this.Ink_OutPut.HeaderText = "Output Path File";
            this.Ink_OutPut.Name = "Ink_OutPut";
            this.Ink_OutPut.ReadOnly = true;
            this.Ink_OutPut.Width = 150;
            // 
            // Ink_FileName
            // 
            this.Ink_FileName.DataPropertyName = "Ink_FileName";
            this.Ink_FileName.FillWeight = 130F;
            this.Ink_FileName.HeaderText = "FileName";
            this.Ink_FileName.Name = "Ink_FileName";
            this.Ink_FileName.ReadOnly = true;
            this.Ink_FileName.Width = 130;
            // 
            // Ink_QtyBoard
            // 
            this.Ink_QtyBoard.DataPropertyName = "Ink_QtyBoard";
            this.Ink_QtyBoard.HeaderText = "Qty/Board";
            this.Ink_QtyBoard.Name = "Ink_QtyBoard";
            this.Ink_QtyBoard.ReadOnly = true;
            // 
            // Ink_Status
            // 
            this.Ink_Status.DataPropertyName = "Ink_Status";
            this.Ink_Status.FillWeight = 80F;
            this.Ink_Status.HeaderText = "Status";
            this.Ink_Status.Name = "Ink_Status";
            this.Ink_Status.ReadOnly = true;
            this.Ink_Status.Width = 80;
            // 
            // Edit
            // 
            this.Edit.DataPropertyName = "Edit";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Edit.DefaultCellStyle = dataGridViewCellStyle1;
            this.Edit.HeaderText = "Edit";
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.Location = new System.Drawing.Point(117, 168);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 20);
            this.label8.TabIndex = 42;
            this.label8.Text = "Status :";
            // 
            // rdAactive
            // 
            this.rdAactive.AutoSize = true;
            this.rdAactive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.rdAactive.Location = new System.Drawing.Point(190, 166);
            this.rdAactive.Name = "rdAactive";
            this.rdAactive.Size = new System.Drawing.Size(70, 24);
            this.rdAactive.TabIndex = 43;
            this.rdAactive.TabStop = true;
            this.rdAactive.Text = "Active";
            this.rdAactive.UseVisualStyleBackColor = true;
            this.rdAactive.CheckedChanged += new System.EventHandler(this.rdAactive_CheckedChanged);
            // 
            // rdInactive
            // 
            this.rdInactive.AutoSize = true;
            this.rdInactive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.rdInactive.Location = new System.Drawing.Point(291, 166);
            this.rdInactive.Name = "rdInactive";
            this.rdInactive.Size = new System.Drawing.Size(82, 24);
            this.rdInactive.TabIndex = 44;
            this.rdInactive.TabStop = true;
            this.rdInactive.Text = "Inactive";
            this.rdInactive.UseVisualStyleBackColor = true;
            this.rdInactive.CheckedChanged += new System.EventHandler(this.rdInactive_CheckedChanged);
            // 
            // txtMacCode
            // 
            this.txtMacCode.Enabled = false;
            this.txtMacCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtMacCode.Location = new System.Drawing.Point(187, 36);
            this.txtMacCode.Name = "txtMacCode";
            this.txtMacCode.Size = new System.Drawing.Size(147, 26);
            this.txtMacCode.TabIndex = 3;
            this.txtMacCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMacCode_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(26, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 20);
            this.label3.TabIndex = 34;
            this.label3.Text = "Ink Print Mac. Code :";
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::InkPrint.Properties.Resources.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(221, 238);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 45);
            this.btnCancel.TabIndex = 52;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::InkPrint.Properties.Resources.Save;
            this.btnSave.Location = new System.Drawing.Point(372, 238);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 45);
            this.btnSave.TabIndex = 51;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(49, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 20);
            this.label1.TabIndex = 53;
            this.label1.Text = "Output File Path :";
            // 
            // txtOutPutPath
            // 
            this.txtOutPutPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtOutPutPath.Location = new System.Drawing.Point(187, 68);
            this.txtOutPutPath.Name = "txtOutPutPath";
            this.txtOutPutPath.Size = new System.Drawing.Size(316, 26);
            this.txtOutPutPath.TabIndex = 54;
            this.txtOutPutPath.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOutPutPath_KeyPress);
            // 
            // txtFileName
            // 
            this.txtFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtFileName.Location = new System.Drawing.Point(187, 100);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(147, 26);
            this.txtFileName.TabIndex = 56;
            this.txtFileName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFileName_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(93, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 55;
            this.label2.Text = "File Name :";
            // 
            // txtQtyBoard
            // 
            this.txtQtyBoard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtQtyBoard.Location = new System.Drawing.Point(187, 132);
            this.txtQtyBoard.Name = "txtQtyBoard";
            this.txtQtyBoard.Size = new System.Drawing.Size(83, 26);
            this.txtQtyBoard.TabIndex = 58;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(93, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 20);
            this.label4.TabIndex = 57;
            this.label4.Text = "Qty/Board :";
            // 
            // InkPrintPath
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1284, 720);
            this.Controls.Add(this.txtQtyBoard);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOutPutPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.rdAactive);
            this.Controls.Add(this.rdInactive);
            this.Controls.Add(this.txtMacCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtMachine);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InkPrintPath";
            this.Text = "Master Machine";
            this.Load += new System.EventHandler(this.Master_Machine_New_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtMachine)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtMachine;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton rdAactive;
        private System.Windows.Forms.RadioButton rdInactive;
        private System.Windows.Forms.TextBox txtMacCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOutPutPath;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtQtyBoard;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ink_Mac;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ink_OutPut;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ink_FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ink_QtyBoard;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ink_Status;
        private System.Windows.Forms.DataGridViewLinkColumn Edit;
    }
}