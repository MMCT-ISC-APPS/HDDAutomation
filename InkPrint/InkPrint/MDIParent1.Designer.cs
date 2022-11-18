namespace InkPrint
{
    partial class MDIParent1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIParent1));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.generat2DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InkPrintConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.generate2D = new System.Windows.Forms.ToolStripMenuItem();
            this.generate2DNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportSerialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportInkPrintTrackingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generat2DToolStripMenuItem,
            this.reportSerialToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1231, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "MenuStrip";
            this.menuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip_ItemClicked);
            // 
            // generat2DToolStripMenuItem
            // 
            this.generat2DToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InkPrintConfig,
            this.generate2D,
            this.generate2DNewToolStripMenuItem});
            this.generat2DToolStripMenuItem.Name = "generat2DToolStripMenuItem";
            this.generat2DToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.generat2DToolStripMenuItem.Text = "Ink Print";
            // 
            // InkPrintConfig
            // 
            this.InkPrintConfig.Name = "InkPrintConfig";
            this.InkPrintConfig.Size = new System.Drawing.Size(157, 22);
            this.InkPrintConfig.Text = "Ink Print Config";
            this.InkPrintConfig.Click += new System.EventHandler(this.generate2DToolStripMenuItem_Click);
            // 
            // generate2D
            // 
            this.generate2D.Name = "generate2D";
            this.generate2D.Size = new System.Drawing.Size(157, 22);
            this.generate2D.Text = "Generate 2D";
            this.generate2D.Visible = false;
            this.generate2D.Click += new System.EventHandler(this.generate2DToolStripMenuItem1_Click);
            // 
            // generate2DNewToolStripMenuItem
            // 
            this.generate2DNewToolStripMenuItem.Name = "generate2DNewToolStripMenuItem";
            this.generate2DNewToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.generate2DNewToolStripMenuItem.Text = "Generate Serials";
            this.generate2DNewToolStripMenuItem.Click += new System.EventHandler(this.generate2DNewToolStripMenuItem_Click);
            // 
            // reportSerialToolStripMenuItem
            // 
            this.reportSerialToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportInkPrintTrackingToolStripMenuItem});
            this.reportSerialToolStripMenuItem.Name = "reportSerialToolStripMenuItem";
            this.reportSerialToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.reportSerialToolStripMenuItem.Text = "Report";
            // 
            // reportInkPrintTrackingToolStripMenuItem
            // 
            this.reportInkPrintTrackingToolStripMenuItem.Name = "reportInkPrintTrackingToolStripMenuItem";
            this.reportInkPrintTrackingToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.reportInkPrintTrackingToolStripMenuItem.Text = "Report InkPrint Tracking";
            this.reportInkPrintTrackingToolStripMenuItem.Click += new System.EventHandler(this.reportInkPrintTrackingToolStripMenuItem_Click);
            // 
            // MDIParent1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 544);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MDIParent1";
            this.Text = "Ink Print";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MDIParent1_FormClosed);
            this.Load += new System.EventHandler(this.MDIParent1_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem reportSerialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generat2DToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem InkPrintConfig;
        private System.Windows.Forms.ToolStripMenuItem generate2D;
        private System.Windows.Forms.ToolStripMenuItem reportInkPrintTrackingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generate2DNewToolStripMenuItem;

    }
}



