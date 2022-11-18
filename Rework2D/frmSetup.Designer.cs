namespace Rework2D
{
    partial class frmSetup
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PicPanel = new System.Windows.Forms.PictureBox();
            this.btnImage = new System.Windows.Forms.Button();
            this.lblImagePath = new System.Windows.Forms.Label();
            this.FileDi = new System.Windows.Forms.OpenFileDialog();
            this.btnPreview = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtY = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtX = new System.Windows.Forms.TextBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtPartNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.grdView = new System.Windows.Forms.DataGridView();
            this.grpPanelInfo = new System.Windows.Forms.GroupBox();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PicPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).BeginInit();
            this.grpPanelInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // PicPanel
            // 
            this.PicPanel.Location = new System.Drawing.Point(12, 12);
            this.PicPanel.Name = "PicPanel";
            this.PicPanel.Size = new System.Drawing.Size(803, 563);
            this.PicPanel.TabIndex = 4;
            this.PicPanel.TabStop = false;
            this.PicPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PicPanel_MouseClick);
            // 
            // btnImage
            // 
            this.btnImage.Location = new System.Drawing.Point(287, 70);
            this.btnImage.Name = "btnImage";
            this.btnImage.Size = new System.Drawing.Size(41, 29);
            this.btnImage.TabIndex = 57;
            this.btnImage.Text = "...";
            this.btnImage.UseVisualStyleBackColor = true;
            this.btnImage.Click += new System.EventHandler(this.btnImage_Click);
            // 
            // lblImagePath
            // 
            this.lblImagePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblImagePath.Location = new System.Drawing.Point(65, 70);
            this.lblImagePath.Name = "lblImagePath";
            this.lblImagePath.Size = new System.Drawing.Size(215, 24);
            this.lblImagePath.TabIndex = 58;
            this.lblImagePath.Text = "Image Path";
            // 
            // FileDi
            // 
            this.FileDi.FileName = "FileDi";
            // 
            // btnPreview
            // 
            this.btnPreview.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.Location = new System.Drawing.Point(65, 109);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(142, 32);
            this.btnPreview.TabIndex = 59;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Verdana", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(180, 153);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(27, 25);
            this.Label1.TabIndex = 69;
            this.Label1.Text = "Y";
            // 
            // txtY
            // 
            this.txtY.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtY.Location = new System.Drawing.Point(216, 147);
            this.txtY.Name = "txtY";
            this.txtY.ReadOnly = true;
            this.txtY.Size = new System.Drawing.Size(80, 43);
            this.txtY.TabIndex = 68;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Verdana", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(52, 154);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(28, 25);
            this.Label3.TabIndex = 67;
            this.Label3.Text = "X";
            // 
            // txtX
            // 
            this.txtX.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtX.Location = new System.Drawing.Point(88, 146);
            this.txtX.Name = "txtX";
            this.txtX.ReadOnly = true;
            this.txtX.Size = new System.Drawing.Size(80, 43);
            this.txtX.TabIndex = 66;
            // 
            // txtModel
            // 
            this.txtModel.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModel.Location = new System.Drawing.Point(123, 26);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(176, 26);
            this.txtModel.TabIndex = 70;
            this.txtModel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtModel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtModel_KeyPress);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(62, 31);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(55, 16);
            this.Label4.TabIndex = 71;
            this.Label4.Text = "Model :";
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(49, 254);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(96, 32);
            this.btnAdd.TabIndex = 72;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtPartNo
            // 
            this.txtPartNo.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPartNo.Location = new System.Drawing.Point(236, 209);
            this.txtPartNo.Name = "txtPartNo";
            this.txtPartNo.Size = new System.Drawing.Size(143, 26);
            this.txtPartNo.TabIndex = 73;
            this.txtPartNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPartNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPartNo_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(168, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 74;
            this.label2.Text = "Part No :";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(52, 531);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 32);
            this.btnSave.TabIndex = 75;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grdView
            // 
            this.grdView.BackgroundColor = System.Drawing.Color.DarkOrange;
            this.grdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdView.GridColor = System.Drawing.SystemColors.MenuHighlight;
            this.grdView.Location = new System.Drawing.Point(19, 292);
            this.grdView.MultiSelect = false;
            this.grdView.Name = "grdView";
            this.grdView.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.grdView.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.grdView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdView.Size = new System.Drawing.Size(352, 224);
            this.grdView.TabIndex = 76;
            this.grdView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdView_CellDoubleClick);
            this.grdView.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdView_CellMouseEnter);
            this.grdView.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdView_CellMouseLeave);
            // 
            // grpPanelInfo
            // 
            this.grpPanelInfo.Controls.Add(this.btnDelete);
            this.grpPanelInfo.Controls.Add(this.txtPosition);
            this.grpPanelInfo.Controls.Add(this.label5);
            this.grpPanelInfo.Controls.Add(this.btnCancel);
            this.grpPanelInfo.Controls.Add(this.btnClose);
            this.grpPanelInfo.Controls.Add(this.btnImage);
            this.grpPanelInfo.Controls.Add(this.grdView);
            this.grpPanelInfo.Controls.Add(this.lblImagePath);
            this.grpPanelInfo.Controls.Add(this.btnSave);
            this.grpPanelInfo.Controls.Add(this.btnPreview);
            this.grpPanelInfo.Controls.Add(this.label2);
            this.grpPanelInfo.Controls.Add(this.txtX);
            this.grpPanelInfo.Controls.Add(this.txtPartNo);
            this.grpPanelInfo.Controls.Add(this.Label3);
            this.grpPanelInfo.Controls.Add(this.btnAdd);
            this.grpPanelInfo.Controls.Add(this.txtY);
            this.grpPanelInfo.Controls.Add(this.txtModel);
            this.grpPanelInfo.Controls.Add(this.Label1);
            this.grpPanelInfo.Controls.Add(this.Label4);
            this.grpPanelInfo.Location = new System.Drawing.Point(833, 12);
            this.grpPanelInfo.Name = "grpPanelInfo";
            this.grpPanelInfo.Size = new System.Drawing.Size(395, 577);
            this.grpPanelInfo.TabIndex = 77;
            this.grpPanelInfo.TabStop = false;
            // 
            // txtPosition
            // 
            this.txtPosition.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPosition.Location = new System.Drawing.Point(88, 210);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Size = new System.Drawing.Size(72, 26);
            this.txtPosition.TabIndex = 80;
            this.txtPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPosition.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPosition_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(30, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 16);
            this.label5.TabIndex = 79;
            this.label5.Text = "Position :";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(254, 255);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 32);
            this.btnCancel.TabIndex = 78;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(252, 531);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(94, 32);
            this.btnClose.TabIndex = 77;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(154, 255);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(94, 32);
            this.btnDelete.TabIndex = 81;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // frmSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(1242, 603);
            this.Controls.Add(this.grpPanelInfo);
            this.Controls.Add(this.PicPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSetup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setup Visual Inspec";
            this.Load += new System.EventHandler(this.frmSetup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PicPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).EndInit();
            this.grpPanelInfo.ResumeLayout(false);
            this.grpPanelInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.PictureBox PicPanel;
        internal System.Windows.Forms.Button btnImage;
        internal System.Windows.Forms.Label lblImagePath;
        internal System.Windows.Forms.OpenFileDialog FileDi;
        internal System.Windows.Forms.Button btnPreview;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtY;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtX;
        internal System.Windows.Forms.TextBox txtModel;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Button btnAdd;
        internal System.Windows.Forms.TextBox txtPartNo;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Button btnSave;
        internal System.Windows.Forms.DataGridView grdView;
        private System.Windows.Forms.GroupBox grpPanelInfo;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.TextBox txtPosition;
        internal System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolTip toolTip;
        internal System.Windows.Forms.Button btnDelete;
    }
}