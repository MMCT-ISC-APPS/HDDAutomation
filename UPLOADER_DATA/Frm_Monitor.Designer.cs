namespace UPLOAD_FILE
{
    partial class Frm_Monitor
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbUploadType = new System.Windows.Forms.ComboBox();
            this.cbBuType = new System.Windows.Forms.ComboBox();
            this.cbModel = new System.Windows.Forms.ComboBox();
            this.txtTestNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDisAdd = new System.Windows.Forms.Button();
            this.dgv01 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv01)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(496, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Upload Type :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(523, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 298;
            this.label2.Text = "BU Type :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(502, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 16);
            this.label3.TabIndex = 299;
            this.label3.Text = "Model Type :";
            // 
            // cbUploadType
            // 
            this.cbUploadType.Enabled = false;
            this.cbUploadType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbUploadType.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbUploadType.FormattingEnabled = true;
            this.cbUploadType.Items.AddRange(new object[] {
            "Select Data...",
            "All",
            "AI",
            "B",
            "HDD"});
            this.cbUploadType.Location = new System.Drawing.Point(586, 44);
            this.cbUploadType.Name = "cbUploadType";
            this.cbUploadType.Size = new System.Drawing.Size(176, 24);
            this.cbUploadType.TabIndex = 300;
            this.cbUploadType.Text = "Select Data...";
            this.cbUploadType.SelectedIndexChanged += new System.EventHandler(this.cbUploadType_SelectedIndexChanged);
            // 
            // cbBuType
            // 
            this.cbBuType.Enabled = false;
            this.cbBuType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbBuType.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBuType.FormattingEnabled = true;
            this.cbBuType.Items.AddRange(new object[] {
            "Select Data...",
            "All",
            "AI",
            "B",
            "HDD"});
            this.cbBuType.Location = new System.Drawing.Point(586, 12);
            this.cbBuType.Name = "cbBuType";
            this.cbBuType.Size = new System.Drawing.Size(176, 24);
            this.cbBuType.TabIndex = 301;
            this.cbBuType.Text = "Select Data...";
            this.cbBuType.SelectedIndexChanged += new System.EventHandler(this.cbBuType_SelectedIndexChanged);
            // 
            // cbModel
            // 
            this.cbModel.Enabled = false;
            this.cbModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbModel.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbModel.FormattingEnabled = true;
            this.cbModel.Items.AddRange(new object[] {
            "Select Data...",
            "All",
            "AI",
            "B",
            "HDD"});
            this.cbModel.Location = new System.Drawing.Point(586, 74);
            this.cbModel.Name = "cbModel";
            this.cbModel.Size = new System.Drawing.Size(176, 24);
            this.cbModel.TabIndex = 302;
            this.cbModel.Text = "Select Data...";
            this.cbModel.SelectedIndexChanged += new System.EventHandler(this.cbModel_SelectedIndexChanged);
            // 
            // txtTestNo
            // 
            this.txtTestNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTestNo.Location = new System.Drawing.Point(586, 104);
            this.txtTestNo.Name = "txtTestNo";
            this.txtTestNo.Size = new System.Drawing.Size(176, 21);
            this.txtTestNo.TabIndex = 304;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(481, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 16);
            this.label4.TabIndex = 305;
            this.label4.Text = "Machine Name :";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(586, 131);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(85, 23);
            this.btnUpdate.TabIndex = 306;
            this.btnUpdate.Text = "Search";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDisAdd
            // 
            this.btnDisAdd.Location = new System.Drawing.Point(677, 131);
            this.btnDisAdd.Name = "btnDisAdd";
            this.btnDisAdd.Size = new System.Drawing.Size(85, 23);
            this.btnDisAdd.TabIndex = 307;
            this.btnDisAdd.Text = "Clear";
            this.btnDisAdd.UseVisualStyleBackColor = true;
            // 
            // dgv01
            // 
            this.dgv01.AllowUserToAddRows = false;
            this.dgv01.AllowUserToDeleteRows = false;
            this.dgv01.AllowUserToResizeColumns = false;
            this.dgv01.Location = new System.Drawing.Point(12, 160);
            this.dgv01.Name = "dgv01";
            this.dgv01.Size = new System.Drawing.Size(1240, 446);
            this.dgv01.TabIndex = 308;
            // 
            // Frm_Monitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 618);
            this.Controls.Add(this.dgv01);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDisAdd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTestNo);
            this.Controls.Add(this.cbModel);
            this.Controls.Add(this.cbBuType);
            this.Controls.Add(this.cbUploadType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Frm_Monitor";
            this.Text = "Frm_Monitor";
            this.Load += new System.EventHandler(this.Frm_Monitor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv01)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbUploadType;
        private System.Windows.Forms.ComboBox cbBuType;
        private System.Windows.Forms.ComboBox cbModel;
        private System.Windows.Forms.TextBox txtTestNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDisAdd;
        private System.Windows.Forms.DataGridView dgv01;
    }
}