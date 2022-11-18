using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UPLOAD_FILE
{
    public partial class Frm_Setup : Form
    {
        ClassDB db = new ClassDB();
        DataTable Dt = null;

        String ConDB = "";
        String ConB = "Data Source=prdsvr;Initial Catalog=dflex;User ID=sa;Password=P@ssw0rd";
        String ConHDD = "Data Source=prdsvrb\\hdd;Initial Catalog=HGSTVericode;User ID=sa;Password=P@ssw0rd";

        String ProductType = "";
        String UploadType = "";
        String ModelType = "";

        public Frm_Setup()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductType = comboBox1.SelectedItem.ToString();
            if (ProductType == "B")
            {
                ConDB = ConB;
            }
            else if (ProductType == "HDD")
            {
                ConDB = ConHDD;
            }


            if (UploadType == "ICT")
            {
                db.TSql = "SELECT * FROM [ICT_SETUP] WHERE [MODEL_TYPE] = '" + ModelType + "' ";
            }
            else if (UploadType == "FCT")
            {
                db.TSql = "SELECT * FROM [FCT_SETUP] WHERE [MODEL_TYPE] = '" + ModelType + "' ";
            }

            Dt = db.GetDataSql(ConDB);
            if (Dt.Rows.Count > 0)
            {
              
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
