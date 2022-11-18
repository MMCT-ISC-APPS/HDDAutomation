namespace AIPackingPP
{

    // AIPackingPP
    partial class frmConfirmQty
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
            this.txtPanelNo = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.txtNG = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPanelNo
            // 
            this.txtPanelNo.AcceptsReturn = true;
            this.txtPanelNo.BackColor = System.Drawing.SystemColors.Window;
            this.txtPanelNo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPanelNo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtPanelNo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPanelNo.Location = new System.Drawing.Point(135, 16);
            this.txtPanelNo.MaxLength = 10;
            this.txtPanelNo.Name = "txtPanelNo";
            this.txtPanelNo.ReadOnly = true;
            this.txtPanelNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPanelNo.Size = new System.Drawing.Size(208, 22);
            this.txtPanelNo.TabIndex = 66;
            this.txtPanelNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPanelNo.TextChanged += new System.EventHandler(this.txtPanelNo_TextChanged);

            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Label8.ForeColor = System.Drawing.Color.Blue;
            this.Label8.Location = new System.Drawing.Point(20, 16);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(75, 18);
            this.Label8.TabIndex = 67;
            this.Label8.Text = "Panel No";
            // 
            // txtNG
            // 
            this.txtNG.AcceptsReturn = true;
            this.txtNG.BackColor = System.Drawing.SystemColors.Window;
            this.txtNG.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNG.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtNG.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNG.Location = new System.Drawing.Point(135, 54);
            this.txtNG.MaxLength = 10;
            this.txtNG.Name = "txtNG";
            this.txtNG.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtNG.Size = new System.Drawing.Size(208, 22);
            this.txtNG.TabIndex = 68;
            this.txtNG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNG.TextChanged += new System.EventHandler(this.txtNG_TextChanged);
            this.txtNG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNG_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(20, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 18);
            this.label1.TabIndex = 69;
            this.label1.Text = "NG Q\'ty(Pcs.)";
            // 
            // frmConfirmQty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 93);
            this.Controls.Add(this.txtNG);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPanelNo);
            this.Controls.Add(this.Label8);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConfirmQty";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Confirmation Q\'ty of NG";
            this.Load += new System.EventHandler(this.frmConfirmQty_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtPanelNo;
        private System.Windows.Forms.Label Label8;
        public System.Windows.Forms.TextBox txtNG;
        private System.Windows.Forms.Label label1;
    }
}