namespace CommonPacking
{
    partial class frmMessagePopUp
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.textSubject = new System.Windows.Forms.TextBox();
            this.TxtErrMsg = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.TxtErrMsg);
            this.panel1.Controls.Add(this.textSubject);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.ForeColor = System.Drawing.Color.Red;
            this.panel1.Location = new System.Drawing.Point(15, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1276, 570);
            this.panel1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(32, 496);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(254, 71);
            this.btnClose.TabIndex = 76;
            this.btnClose.Text = "ปิดหน้าจอ";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // textSubject
            // 
            this.textSubject.AcceptsReturn = true;
            this.textSubject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.textSubject.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textSubject.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textSubject.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textSubject.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textSubject.HideSelection = false;
            this.textSubject.Location = new System.Drawing.Point(32, 47);
            this.textSubject.MaxLength = 4000;
            this.textSubject.Name = "textSubject";
            this.textSubject.ReadOnly = true;
            this.textSubject.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textSubject.Size = new System.Drawing.Size(1209, 36);
            this.textSubject.TabIndex = 77;
            this.textSubject.Tag = "";
            this.textSubject.Text = "ERROR  SUBJECT";
            // 
            // TxtErrMsg
            // 
            this.TxtErrMsg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.TxtErrMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtErrMsg.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold);
            this.TxtErrMsg.Location = new System.Drawing.Point(32, 143);
            this.TxtErrMsg.Multiline = true;
            this.TxtErrMsg.Name = "TxtErrMsg";
            this.TxtErrMsg.ReadOnly = true;
            this.TxtErrMsg.Size = new System.Drawing.Size(1209, 336);
            this.TxtErrMsg.TabIndex = 78;
            this.TxtErrMsg.Text = "ERROR MESSAGE";
            // 
            // frmMessagePopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1316, 609);
            this.Controls.Add(this.panel1);
            this.Name = "frmMessagePopUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wanning Message !!!";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Click += new System.EventHandler(this.frmMessagePopUp_Click);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.TextBox textSubject;
        public System.Windows.Forms.TextBox TxtErrMsg;
    }
}