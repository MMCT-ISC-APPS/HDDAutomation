namespace UPLOAD_FILE
{
    partial class Frm_Change
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPictureFile = new System.Windows.Forms.TextBox();
            this.txtPathFile = new System.Windows.Forms.TextBox();
            this.cbSetupStatus = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbChangeStatus = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbBuType = new System.Windows.Forms.ComboBox();
            this.cbUploadType = new System.Windows.Forms.ComboBox();
            this.cbModel = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbYieldTrickring = new System.Windows.Forms.ComboBox();
            this.cbLinerMatching = new System.Windows.Forms.ComboBox();
            this.cb2DMatching = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbMachineName = new System.Windows.Forms.ComboBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDisAdd = new System.Windows.Forms.Button();
            this.label76 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtPictureFile);
            this.groupBox1.Controls.Add(this.txtPathFile);
            this.groupBox1.Controls.Add(this.cbSetupStatus);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbChangeStatus);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbBuType);
            this.groupBox1.Controls.Add(this.cbUploadType);
            this.groupBox1.Controls.Add(this.cbModel);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cbYieldTrickring);
            this.groupBox1.Controls.Add(this.cbLinerMatching);
            this.groupBox1.Controls.Add(this.cb2DMatching);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbMachineName);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.btnDisAdd);
            this.groupBox1.Controls.Add(this.label76);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(353, 382);
            this.groupBox1.TabIndex = 279;
            this.groupBox1.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(78, 322);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 15);
            this.label10.TabIndex = 307;
            this.label10.Text = "Picture File : ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(92, 295);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 15);
            this.label8.TabIndex = 306;
            this.label8.Text = "Path File : ";
            // 
            // txtPictureFile
            // 
            this.txtPictureFile.Enabled = false;
            this.txtPictureFile.Location = new System.Drawing.Point(160, 319);
            this.txtPictureFile.Name = "txtPictureFile";
            this.txtPictureFile.Size = new System.Drawing.Size(176, 21);
            this.txtPictureFile.TabIndex = 305;
            // 
            // txtPathFile
            // 
            this.txtPathFile.Enabled = false;
            this.txtPathFile.Location = new System.Drawing.Point(160, 292);
            this.txtPathFile.Name = "txtPathFile";
            this.txtPathFile.Size = new System.Drawing.Size(176, 21);
            this.txtPathFile.TabIndex = 304;
            // 
            // cbSetupStatus
            // 
            this.cbSetupStatus.Enabled = false;
            this.cbSetupStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbSetupStatus.FormattingEnabled = true;
            this.cbSetupStatus.Items.AddRange(new object[] {
            "Select Data...",
            "ON",
            "OFF"});
            this.cbSetupStatus.Location = new System.Drawing.Point(160, 261);
            this.cbSetupStatus.Name = "cbSetupStatus";
            this.cbSetupStatus.Size = new System.Drawing.Size(175, 24);
            this.cbSetupStatus.TabIndex = 303;
            this.cbSetupStatus.Text = "Select Data...";
            this.cbSetupStatus.SelectedIndexChanged += new System.EventHandler(this.cbSetupStatus_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(74, 264);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 15);
            this.label7.TabIndex = 302;
            this.label7.Text = "Setup Status : ";
            // 
            // cbChangeStatus
            // 
            this.cbChangeStatus.Enabled = false;
            this.cbChangeStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbChangeStatus.FormattingEnabled = true;
            this.cbChangeStatus.Items.AddRange(new object[] {
            "Select Data...",
            "ON",
            "OFF"});
            this.cbChangeStatus.Location = new System.Drawing.Point(160, 231);
            this.cbChangeStatus.Name = "cbChangeStatus";
            this.cbChangeStatus.Size = new System.Drawing.Size(175, 24);
            this.cbChangeStatus.TabIndex = 301;
            this.cbChangeStatus.Text = "Select Data...";
            this.cbChangeStatus.SelectedIndexChanged += new System.EventHandler(this.cbChangeStatus_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(61, 234);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 15);
            this.label6.TabIndex = 300;
            this.label6.Text = "Change Status : ";
            // 
            // cbBuType
            // 
            this.cbBuType.Enabled = false;
            this.cbBuType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbBuType.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBuType.Items.AddRange(new object[] {
            "Select Data...",
            "All",
            "B"});
            this.cbBuType.Location = new System.Drawing.Point(160, 50);
            this.cbBuType.Name = "cbBuType";
            this.cbBuType.Size = new System.Drawing.Size(175, 24);
            this.cbBuType.TabIndex = 297;
            this.cbBuType.Text = "Select Data...";
            this.cbBuType.SelectedIndexChanged += new System.EventHandler(this.cbBuType_SelectedIndexChanged);
            // 
            // cbUploadType
            // 
            this.cbUploadType.Enabled = false;
            this.cbUploadType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbUploadType.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbUploadType.Items.AddRange(new object[] {
            "Select Data..."});
            this.cbUploadType.Location = new System.Drawing.Point(160, 81);
            this.cbUploadType.Name = "cbUploadType";
            this.cbUploadType.Size = new System.Drawing.Size(175, 24);
            this.cbUploadType.TabIndex = 299;
            this.cbUploadType.Text = "Select Data...";
            this.cbUploadType.SelectedIndexChanged += new System.EventHandler(this.cbUploadType_SelectedIndexChanged);
            // 
            // cbModel
            // 
            this.cbModel.Enabled = false;
            this.cbModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbModel.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbModel.Items.AddRange(new object[] {
            "Select Data..."});
            this.cbModel.Location = new System.Drawing.Point(160, 111);
            this.cbModel.Name = "cbModel";
            this.cbModel.Size = new System.Drawing.Size(175, 24);
            this.cbModel.TabIndex = 298;
            this.cbModel.Text = "Select Data...";
            this.cbModel.SelectedIndexChanged += new System.EventHandler(this.cbModel_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(98, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 15);
            this.label9.TabIndex = 290;
            this.label9.Text = "Bu Type :";
            // 
            // cbYieldTrickring
            // 
            this.cbYieldTrickring.Enabled = false;
            this.cbYieldTrickring.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbYieldTrickring.FormattingEnabled = true;
            this.cbYieldTrickring.Items.AddRange(new object[] {
            "Select Data...",
            "ON",
            "OFF"});
            this.cbYieldTrickring.Location = new System.Drawing.Point(160, 141);
            this.cbYieldTrickring.Name = "cbYieldTrickring";
            this.cbYieldTrickring.Size = new System.Drawing.Size(175, 24);
            this.cbYieldTrickring.TabIndex = 296;
            this.cbYieldTrickring.Text = "Select Data...";
            this.cbYieldTrickring.SelectedIndexChanged += new System.EventHandler(this.cbYieldTrickring_SelectedIndexChanged);
            // 
            // cbLinerMatching
            // 
            this.cbLinerMatching.Enabled = false;
            this.cbLinerMatching.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbLinerMatching.FormattingEnabled = true;
            this.cbLinerMatching.Items.AddRange(new object[] {
            "Select Data...",
            "ON",
            "OFF"});
            this.cbLinerMatching.Location = new System.Drawing.Point(160, 201);
            this.cbLinerMatching.Name = "cbLinerMatching";
            this.cbLinerMatching.Size = new System.Drawing.Size(175, 24);
            this.cbLinerMatching.TabIndex = 295;
            this.cbLinerMatching.Text = "Select Data...";
            this.cbLinerMatching.SelectedIndexChanged += new System.EventHandler(this.cbLinerMatching_SelectedIndexChanged);
            // 
            // cb2DMatching
            // 
            this.cb2DMatching.Enabled = false;
            this.cb2DMatching.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb2DMatching.FormattingEnabled = true;
            this.cb2DMatching.Items.AddRange(new object[] {
            "Select Data...",
            "ON",
            "OFF"});
            this.cb2DMatching.Location = new System.Drawing.Point(160, 171);
            this.cb2DMatching.Name = "cb2DMatching";
            this.cb2DMatching.Size = new System.Drawing.Size(175, 24);
            this.cb2DMatching.TabIndex = 294;
            this.cb2DMatching.Text = "Select Data...";
            this.cb2DMatching.SelectedIndexChanged += new System.EventHandler(this.cb2DMatching_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 15);
            this.label3.TabIndex = 286;
            this.label3.Text = "Yield Trickring Status : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 15);
            this.label4.TabIndex = 285;
            this.label4.Text = "Liner Matching Status : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(36, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 15);
            this.label5.TabIndex = 284;
            this.label5.Text = "2D Matching Status : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(78, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 283;
            this.label2.Text = "Model Type :";
            // 
            // cbMachineName
            // 
            this.cbMachineName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbMachineName.FormattingEnabled = true;
            this.cbMachineName.Location = new System.Drawing.Point(160, 20);
            this.cbMachineName.Name = "cbMachineName";
            this.cbMachineName.Size = new System.Drawing.Size(175, 24);
            this.cbMachineName.TabIndex = 290;
            this.cbMachineName.Text = "Select Data...";
            this.cbMachineName.SelectedIndexChanged += new System.EventHandler(this.cbMachineName_SelectedIndexChanged);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(160, 346);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(85, 23);
            this.btnUpdate.TabIndex = 261;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDisAdd
            // 
            this.btnDisAdd.Location = new System.Drawing.Point(251, 346);
            this.btnDisAdd.Name = "btnDisAdd";
            this.btnDisAdd.Size = new System.Drawing.Size(85, 23);
            this.btnDisAdd.TabIndex = 263;
            this.btnDisAdd.Text = "Clear";
            this.btnDisAdd.UseVisualStyleBackColor = true;
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label76.Location = new System.Drawing.Point(58, 23);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(96, 15);
            this.label76.TabIndex = 281;
            this.label76.Text = "Machine Name :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(74, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 15);
            this.label1.TabIndex = 282;
            this.label1.Text = "Upload Type :";
            // 
            // Frm_Change
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 403);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm_Change";
            this.Text = "Frm_Change";
            this.Load += new System.EventHandler(this.Frm_Change_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbBuType;
        private System.Windows.Forms.ComboBox cbUploadType;
        private System.Windows.Forms.ComboBox cbModel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbYieldTrickring;
        private System.Windows.Forms.ComboBox cbLinerMatching;
        private System.Windows.Forms.ComboBox cb2DMatching;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbMachineName;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDisAdd;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPictureFile;
        private System.Windows.Forms.TextBox txtPathFile;
        private System.Windows.Forms.ComboBox cbSetupStatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbChangeStatus;
        private System.Windows.Forms.Label label6;
    }
}