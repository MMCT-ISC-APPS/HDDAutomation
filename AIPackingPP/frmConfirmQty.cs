using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIPackingPP
{
    public partial class frmConfirmQty : Form
    {
        public string PanelNo { get; set; }

        public int  NGQty { get; set; }

        public Boolean Ok { get; set; }

        public frmConfirmQty()
        {
            InitializeComponent();
        }

        private void frmConfirmQty_Load(object sender, EventArgs e)
        {
            txtPanelNo.Text = PanelNo;

            if (NGQty != 0)
            {
                txtNG.Text = NGQty.ToString ();
            }
            else {
                txtNG.Text = "0";
            }
                        
            txtNG.Focus();

        }

        private void txtNG_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                NGQty = Convert.ToInt16 (txtNG.Text);
                if (NGQty > 8)
                {
                    Ok = false;
                    MessageBox.Show("NG เกิน 8 ตัว Sheet นี้ไม่สามารถใช้ได้");
                }
                else
                {
                    Ok = true;
                    this.Close();
                }
            }
        }

        private void txtNG_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPanelNo_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
