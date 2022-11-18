namespace Rework2D
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtSerialNo = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.grpPanelInfo = new System.Windows.Forms.GroupBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.cboCriteria = new System.Windows.Forms.ComboBox();
            this.txtNewPart = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLotNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOldPart = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtJobname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstData = new System.Windows.Forms.ListView();
            this.PicPanel = new System.Windows.Forms.PictureBox();
            this.FileDi = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.grpPanelInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicPanel)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(39, 389);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(142, 32);
            this.btnClose.TabIndex = 77;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(209, 351);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(142, 32);
            this.btnSave.TabIndex = 75;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtSerialNo
            // 
            this.txtSerialNo.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerialNo.Location = new System.Drawing.Point(123, 52);
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.Size = new System.Drawing.Size(248, 26);
            this.txtSerialNo.TabIndex = 70;
            this.txtSerialNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSerialNo.TextChanged += new System.EventHandler(this.txtSerialNo_TextChanged);
            this.txtSerialNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSerialNo_KeyPress);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(11, 57);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(69, 16);
            this.Label4.TabIndex = 71;
            this.Label4.Text = "SerialNo :";
            // 
            // grpPanelInfo
            // 
            this.grpPanelInfo.Controls.Add(this.btnNew);
            this.grpPanelInfo.Controls.Add(this.cboCriteria);
            this.grpPanelInfo.Controls.Add(this.txtNewPart);
            this.grpPanelInfo.Controls.Add(this.label8);
            this.grpPanelInfo.Controls.Add(this.label7);
            this.grpPanelInfo.Controls.Add(this.txtPosition);
            this.grpPanelInfo.Controls.Add(this.label6);
            this.grpPanelInfo.Controls.Add(this.txtLotNo);
            this.grpPanelInfo.Controls.Add(this.label5);
            this.grpPanelInfo.Controls.Add(this.txtOldPart);
            this.grpPanelInfo.Controls.Add(this.label3);
            this.grpPanelInfo.Controls.Add(this.txtModel);
            this.grpPanelInfo.Controls.Add(this.label2);
            this.grpPanelInfo.Controls.Add(this.txtJobname);
            this.grpPanelInfo.Controls.Add(this.label1);
            this.grpPanelInfo.Controls.Add(this.btnClose);
            this.grpPanelInfo.Controls.Add(this.btnSave);
            this.grpPanelInfo.Controls.Add(this.txtSerialNo);
            this.grpPanelInfo.Controls.Add(this.Label4);
            this.grpPanelInfo.Location = new System.Drawing.Point(850, 16);
            this.grpPanelInfo.Name = "grpPanelInfo";
            this.grpPanelInfo.Size = new System.Drawing.Size(395, 584);
            this.grpPanelInfo.TabIndex = 79;
            this.grpPanelInfo.TabStop = false;
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Location = new System.Drawing.Point(39, 351);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(142, 32);
            this.btnNew.TabIndex = 95;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // cboCriteria
            // 
            this.cboCriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCriteria.FormattingEnabled = true;
            this.cboCriteria.Location = new System.Drawing.Point(126, 222);
            this.cboCriteria.Name = "cboCriteria";
            this.cboCriteria.Size = new System.Drawing.Size(247, 21);
            this.cboCriteria.TabIndex = 94;
            this.cboCriteria.SelectedIndexChanged += new System.EventHandler(this.cboCriteria_SelectedIndexChanged);
            // 
            // txtNewPart
            // 
            this.txtNewPart.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPart.Location = new System.Drawing.Point(126, 285);
            this.txtNewPart.Name = "txtNewPart";
            this.txtNewPart.ReadOnly = true;
            this.txtNewPart.Size = new System.Drawing.Size(248, 26);
            this.txtNewPart.TabIndex = 92;
            this.txtNewPart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(11, 290);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 16);
            this.label8.TabIndex = 93;
            this.label8.Text = "New Part :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(11, 223);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 16);
            this.label7.TabIndex = 90;
            this.label7.Text = "Rework Criteria :";
            // 
            // txtPosition
            // 
            this.txtPosition.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPosition.Location = new System.Drawing.Point(125, 155);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.ReadOnly = true;
            this.txtPosition.Size = new System.Drawing.Size(248, 26);
            this.txtPosition.TabIndex = 87;
            this.txtPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 16);
            this.label6.TabIndex = 88;
            this.label6.Text = "Position";
            // 
            // txtLotNo
            // 
            this.txtLotNo.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLotNo.Location = new System.Drawing.Point(126, 249);
            this.txtLotNo.Name = "txtLotNo";
            this.txtLotNo.Size = new System.Drawing.Size(248, 26);
            this.txtLotNo.TabIndex = 85;
            this.txtLotNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLotNo.TextChanged += new System.EventHandler(this.txtLotNo_TextChanged);
            this.txtLotNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLotNo_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 254);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 16);
            this.label5.TabIndex = 86;
            this.label5.Text = "New Lot No :";
            // 
            // txtOldPart
            // 
            this.txtOldPart.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOldPart.Location = new System.Drawing.Point(125, 190);
            this.txtOldPart.Name = "txtOldPart";
            this.txtOldPart.ReadOnly = true;
            this.txtOldPart.Size = new System.Drawing.Size(248, 26);
            this.txtOldPart.TabIndex = 83;
            this.txtOldPart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 84;
            this.label3.Text = "Old Part :";
            // 
            // txtModel
            // 
            this.txtModel.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModel.Location = new System.Drawing.Point(125, 121);
            this.txtModel.Name = "txtModel";
            this.txtModel.ReadOnly = true;
            this.txtModel.Size = new System.Drawing.Size(248, 26);
            this.txtModel.TabIndex = 81;
            this.txtModel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 82;
            this.label2.Text = "Model :";
            // 
            // txtJobname
            // 
            this.txtJobname.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJobname.Location = new System.Drawing.Point(124, 87);
            this.txtJobname.Name = "txtJobname";
            this.txtJobname.ReadOnly = true;
            this.txtJobname.Size = new System.Drawing.Size(248, 26);
            this.txtJobname.TabIndex = 79;
            this.txtJobname.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 80;
            this.label1.Text = "JobName :";
            // 
            // lstData
            // 
            this.lstData.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lstData.AutoArrange = false;
            this.lstData.CheckBoxes = true;
            this.lstData.HideSelection = false;
            this.lstData.LabelEdit = true;
            this.lstData.Location = new System.Drawing.Point(449, 367);
            this.lstData.Name = "lstData";
            this.lstData.Size = new System.Drawing.Size(362, 194);
            this.lstData.TabIndex = 91;
            this.lstData.UseCompatibleStateImageBehavior = false;
            this.lstData.Visible = false;
            // 
            // PicPanel
            // 
            this.PicPanel.Location = new System.Drawing.Point(12, 37);
            this.PicPanel.Name = "PicPanel";
            this.PicPanel.Size = new System.Drawing.Size(803, 563);
            this.PicPanel.TabIndex = 78;
            this.PicPanel.TabStop = false;
            // 
            // FileDi
            // 
            this.FileDi.FileName = "FileDi";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1275, 27);
            this.menuStrip1.TabIndex = 80;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(64, 23);
            this.settingToolStripMenuItem.Text = "Setting";
            this.settingToolStripMenuItem.Click += new System.EventHandler(this.settingToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(1275, 608);
            this.Controls.Add(this.grpPanelInfo);
            this.Controls.Add(this.PicPanel);
            this.Controls.Add(this.lstData);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.grpPanelInfo.ResumeLayout(false);
            this.grpPanelInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicPanel)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Button btnSave;
        internal System.Windows.Forms.TextBox txtSerialNo;
        internal System.Windows.Forms.Label Label4;
        private System.Windows.Forms.GroupBox grpPanelInfo;
        internal System.Windows.Forms.PictureBox PicPanel;
        internal System.Windows.Forms.OpenFileDialog FileDi;
        internal System.Windows.Forms.TextBox txtModel;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtJobname;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtOldPart;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtLotNo;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox txtPosition;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView lstData;
        internal System.Windows.Forms.TextBox txtNewPart;
        internal System.Windows.Forms.Label label8;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ComboBox cboCriteria;
        private System.Windows.Forms.ToolTip toolTip;
        internal System.Windows.Forms.Button btnNew;
    }
}