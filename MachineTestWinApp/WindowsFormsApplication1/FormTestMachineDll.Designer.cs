namespace WindowsFormsApplication1
{
    partial class FormTestMachineDll
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
            this.chkOffline = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.textModel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textQty = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textPanelSize = new System.Windows.Forms.TextBox();
            this.txtConvert2D = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkOffline
            // 
            this.chkOffline.AutoSize = true;
            this.chkOffline.Location = new System.Drawing.Point(103, 17);
            this.chkOffline.Name = "chkOffline";
            this.chkOffline.Size = new System.Drawing.Size(56, 17);
            this.chkOffline.TabIndex = 12;
            this.chkOffline.Text = "Offline";
            this.chkOffline.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(245, 11);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMsg.Size = new System.Drawing.Size(302, 246);
            this.txtMsg.TabIndex = 13;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(9, 40);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Connect";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(27, 83);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 15;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(27, 152);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(98, 23);
            this.button3.TabIndex = 16;
            this.button3.Text = "1. Get Job";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(26, 224);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(179, 23);
            this.button4.TabIndex = 17;
            this.button4.Text = "2. StartJob (Gen Vericode)";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(28, 295);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 18;
            this.button5.Text = "3. Read Serial";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(165, 13);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 19;
            this.button6.Text = "Connect";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(137, 83);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 20;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(165, 54);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 21;
            this.button7.Text = "button7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // textModel
            // 
            this.textModel.Location = new System.Drawing.Point(27, 124);
            this.textModel.Name = "textModel";
            this.textModel.Size = new System.Drawing.Size(100, 20);
            this.textModel.TabIndex = 22;
            this.textModel.Text = "NZDXV6-P10P";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Job Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Model";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Qty";
            // 
            // textQty
            // 
            this.textQty.Location = new System.Drawing.Point(26, 200);
            this.textQty.Name = "textQty";
            this.textQty.Size = new System.Drawing.Size(100, 20);
            this.textQty.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "PanelSize";
            // 
            // textPanelSize
            // 
            this.textPanelSize.Location = new System.Drawing.Point(28, 271);
            this.textPanelSize.Name = "textPanelSize";
            this.textPanelSize.Size = new System.Drawing.Size(100, 20);
            this.textPanelSize.TabIndex = 27;
            this.textPanelSize.Text = "4";
            // 
            // txtConvert2D
            // 
            this.txtConvert2D.Location = new System.Drawing.Point(139, 168);
            this.txtConvert2D.Name = "txtConvert2D";
            this.txtConvert2D.Size = new System.Drawing.Size(92, 23);
            this.txtConvert2D.TabIndex = 29;
            this.txtConvert2D.Text = "txtConvert 32";
            this.txtConvert2D.UseVisualStyleBackColor = true;
            this.txtConvert2D.Click += new System.EventHandler(this.txtConvert2D_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(139, 196);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(92, 23);
            this.button8.TabIndex = 30;
            this.button8.Text = "txtConvert";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(139, 295);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 31;
            this.button9.Text = "X. Read Serial";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // FormTestMachineDll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 353);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.txtConvert2D);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textPanelSize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textQty);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textModel);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.chkOffline);
            this.Controls.Add(this.button1);
            this.Name = "FormTestMachineDll";
            this.Text = "FormTestMachineDll";
            this.Load += new System.EventHandler(this.FormTestMachineDll_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkOffline;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox textModel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textQty;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textPanelSize;
        private System.Windows.Forms.Button txtConvert2D;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
    }
}