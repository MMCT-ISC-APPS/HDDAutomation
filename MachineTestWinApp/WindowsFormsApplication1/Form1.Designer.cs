namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.txtRuncard = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblModel = new System.Windows.Forms.Label();
            this.lblCpn = new System.Windows.Forms.Label();
            this.lblJobsize = new System.Windows.Forms.Label();
            this.lblMaster2D = new System.Windows.Forms.Label();
            this.lblPanelSize = new System.Windows.Forms.Label();
            this.chkOffline = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtRemain = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 32);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(456, 34);
            this.txtMsg.Margin = new System.Windows.Forms.Padding(4);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(401, 264);
            this.txtMsg.TabIndex = 1;
            // 
            // txtRuncard
            // 
            this.txtRuncard.Location = new System.Drawing.Point(127, 81);
            this.txtRuncard.Margin = new System.Windows.Forms.Padding(4);
            this.txtRuncard.Name = "txtRuncard";
            this.txtRuncard.Size = new System.Drawing.Size(204, 22);
            this.txtRuncard.TabIndex = 2;
            this.txtRuncard.TextChanged += new System.EventHandler(this.txtRuncard_TextChanged);
            this.txtRuncard.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRuncard_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 84);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Run Card";
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Location = new System.Drawing.Point(35, 121);
            this.lblModel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(46, 17);
            this.lblModel.TabIndex = 4;
            this.lblModel.Text = "label2";
            // 
            // lblCpn
            // 
            this.lblCpn.AutoSize = true;
            this.lblCpn.Location = new System.Drawing.Point(35, 154);
            this.lblCpn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCpn.Name = "lblCpn";
            this.lblCpn.Size = new System.Drawing.Size(46, 17);
            this.lblCpn.TabIndex = 5;
            this.lblCpn.Text = "label2";
            // 
            // lblJobsize
            // 
            this.lblJobsize.AutoSize = true;
            this.lblJobsize.Location = new System.Drawing.Point(35, 186);
            this.lblJobsize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblJobsize.Name = "lblJobsize";
            this.lblJobsize.Size = new System.Drawing.Size(46, 17);
            this.lblJobsize.TabIndex = 6;
            this.lblJobsize.Text = "label2";
            // 
            // lblMaster2D
            // 
            this.lblMaster2D.AutoSize = true;
            this.lblMaster2D.Location = new System.Drawing.Point(35, 249);
            this.lblMaster2D.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaster2D.Name = "lblMaster2D";
            this.lblMaster2D.Size = new System.Drawing.Size(46, 17);
            this.lblMaster2D.TabIndex = 8;
            this.lblMaster2D.Text = "label2";
            // 
            // lblPanelSize
            // 
            this.lblPanelSize.AutoSize = true;
            this.lblPanelSize.Location = new System.Drawing.Point(35, 283);
            this.lblPanelSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPanelSize.Name = "lblPanelSize";
            this.lblPanelSize.Size = new System.Drawing.Size(46, 17);
            this.lblPanelSize.TabIndex = 9;
            this.lblPanelSize.Text = "label2";
            // 
            // chkOffline
            // 
            this.chkOffline.AutoSize = true;
            this.chkOffline.Location = new System.Drawing.Point(115, 10);
            this.chkOffline.Margin = new System.Windows.Forms.Padding(4);
            this.chkOffline.Name = "chkOffline";
            this.chkOffline.Size = new System.Drawing.Size(71, 21);
            this.chkOffline.TabIndex = 10;
            this.chkOffline.Text = "Offline";
            this.chkOffline.UseVisualStyleBackColor = true;
            this.chkOffline.CheckedChanged += new System.EventHandler(this.chkOffline_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(340, 84);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 11;
            this.button2.Text = "Read2d";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtRemain
            // 
            this.txtRemain.Location = new System.Drawing.Point(39, 218);
            this.txtRemain.Margin = new System.Windows.Forms.Padding(4);
            this.txtRemain.Name = "txtRemain";
            this.txtRemain.Size = new System.Drawing.Size(204, 22);
            this.txtRemain.TabIndex = 12;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(340, 134);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 28);
            this.button3.TabIndex = 13;
            this.button3.Text = "PrintTime";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(339, 180);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 28);
            this.button4.TabIndex = 14;
            this.button4.Text = "Verify";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(339, 236);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(100, 28);
            this.button5.TabIndex = 15;
            this.button5.Text = "getRemain";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(296, 283);
            this.button6.Margin = new System.Windows.Forms.Padding(4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(100, 28);
            this.button6.TabIndex = 16;
            this.button6.Text = "NG Remove";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(185, 271);
            this.button7.Margin = new System.Windows.Forms.Padding(4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(100, 28);
            this.button7.TabIndex = 17;
            this.button7.Text = "button7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(293, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 18;
            this.label2.Text = "Remain";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(415, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 19;
            this.label3.Text = "Remain";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(197, 6);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(42, 21);
            this.checkBox1.TabIndex = 20;
            this.checkBox1.Text = "SI";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(127, 121);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(204, 22);
            this.textBox1.TabIndex = 21;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(127, 154);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(204, 22);
            this.textBox2.TabIndex = 22;
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(127, 186);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(204, 22);
            this.textBox3.TabIndex = 23;
            this.textBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(340, 48);
            this.button8.Margin = new System.Windows.Forms.Padding(4);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(100, 28);
            this.button8.TabIndex = 24;
            this.button8.Text = "Read2d";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(418, 306);
            this.button9.Margin = new System.Windows.Forms.Padding(4);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(100, 28);
            this.button9.TabIndex = 25;
            this.button9.Text = "NG Remove";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 343);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.txtRemain);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.chkOffline);
            this.Controls.Add(this.lblPanelSize);
            this.Controls.Add(this.lblMaster2D);
            this.Controls.Add(this.lblJobsize);
            this.Controls.Add(this.lblCpn);
            this.Controls.Add(this.lblModel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRuncard);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.TextBox txtRuncard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.Label lblCpn;
        private System.Windows.Forms.Label lblJobsize;
        private System.Windows.Forms.Label lblMaster2D;
        private System.Windows.Forms.Label lblPanelSize;
        private System.Windows.Forms.CheckBox chkOffline;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtRemain;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
    }
}

