using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MachineDLL;

namespace HDDTraceability
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {        
        private Machine objMachine;

        public frmLogin()
        {
            InitializeComponent();
            this.ActiveControl = txtUsername;
            objMachine = new Machine();
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //FormMain fm = new FormMain();
            this.Hide();
            //fm.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
         
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            try
            {
                loginAction();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "Login", MessageBoxButtons.OK);
            }
            
        }

        private void loginAction()
        {
            try
            {
                if (txtUsername.Text != "" && txtPassword.Text != "")
                {

                    /*AuthenticateController objAuthen = new AuthenticateController();                    

                    objUserM.UserName = txtUsername.Text.Trim();
                    objUserM.Password = txtPassword.Text.Trim();

                    objUserM = objAuthen.GetUserSearch(objUserM);

                    ControlParameter.loginName = objUserM.Name;
                    ControlParameter.loginLastName = objUserM.Lastname;
                    ControlParameter.UserInfoM = objUserM;

                    FormMain fm = new FormMain();
                    fm = new FormMain();
                    fm.Show();
                    this.Hide();*/

                }
                else
                {
                    throw new Exception ("Please check username or password is correctly? ");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

     
        private void panel2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            //objUserM = new UserM();
            
            lblVersion.Text = "HDD Traceability SW V." + getVersion() + " Dll v." + objMachine.GetVersion() + "API v." + objMachine.GetWebServiceVersion();
            //try
            //{
            //    //conn = new ConnectionString().Connect();
            //}
            //catch (SqlException ex) { MessageBox.Show("Connection to Server is Failed!!! " + ex.Message.ToString()); }
            //textBox1.AutoSize = false;
            //textBox2.AutoSize = false;
            //textEdit1.AutoSize = false;

        }

        public string getVersion()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            return version;
        }


        private void timerIdle_Tick(object sender, EventArgs e)
        {
            //Here perform your action by first validating that idle task is not already running.
            // If you want to redirect user to login page, then first check weather login page is already displayed or not
            // if not then show loign page. Same logic for other task or Implement your own. 
            // Remember after every five minutes or period you defined above this timerIdle_Tick will be called 
            ////so first check weather idle task is already running or not. If not then perform 
            //if(!)
            //{
               
            //  //  PerformNecessoryActions();
            //  //  ShowLoginForm();
            //}

            this.ShowDialog();
            
       
        
            //FormMain fm = new FormMain();
            //fm.Enabled = false;
           // fm.Show();
        }
      
        private void textEdit2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    loginAction();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.Message, "Login", MessageBoxButtons.OK );
                }
                
            }
            
        }
    }
}