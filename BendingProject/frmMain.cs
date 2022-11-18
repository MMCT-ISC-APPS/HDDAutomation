using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using MachineDLL;
using MachineDLL.Entities;

using System.IO;

namespace BendingProject
{
    public partial class frmBending : Form
    {
        private Machine objMachine;
        private HSGTraceability objHsg;
        private List<String> objModel;
        private DataTable dsData;
        private const Byte STX = 0x02;
        private const Byte ETX = 0x03;
        private const Byte CR = 0x0d;

        private int SERIAL_PORT_COUNT = 1;    // Number of COM ports used
        private const int RECV_DATA_MAX = 10240;
        private const bool binaryDataMode = false;  // Whether using binary data mode
        private SerialPort[] serialPortInstance;
        private bool TypeUse;

        private const int COM_BAND_RATE = 115200;
        private const int COM_DATA_BIT = 8;
        private const Parity  COM_PARITY = Parity.Even ;
        private const StopBits COM_STOPBITS = StopBits.One;        
      

        private string SN = "";

        delegate void SetTextCallback(string text);

        public frmBending()
        {
            InitializeComponent();                    
        }

        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.        

            try
            {
                if (this.txt2DBarcode1.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetText);
                    this.Invoke(d, new object[] { text });
                }
                else
                   // sBarcode = barcode
                   if (!(text.Contains("ERROR") | SN.Contains("ER,lon")))
                {
                    if (text.ToUpper().Trim() != txt2DBarcode1.Text.ToString().ToUpper().Trim())
                    {
                        Application.DoEvents();
                        // ClearData()
                        txt2DBarcode1.Text = text.Trim();
                        SaveData();                        
                        txt2DBarcode1.SelectAll();
                    }
                }
            }
            catch (Exception ex)
            {
                txtStatus1.BackColor = Color.Red;
                txtStatus1.Text = ex.Message;
                //throw new Exception(ex.Message);
            }
        }

        public string getVersion()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            return version;
        }

        private void frmBending_Load(object sender, EventArgs e)
        {
            objMachine = new Machine();
            objHsg = new HSGTraceability(false);
            txtComputerName.Text = objMachine.GetComputerName();

            this.Text = "Bending Project SW" + getVersion() + " DLL:" + objMachine.GetVersion() + " API:" + objMachine.GetWebServiceVersion() + " status:" + objMachine.ConnectDatabase();
            //string[] ports =  new string[] { "COM1", "COM2", "COM3", "COM4" }; ;//SerialPort.GetPortNames();
            /*
                        string[] ports = SerialPort.GetPortNames();

                        Console.WriteLine("The following serial ports were found:");

                        objMachine = new Machine();
                        objHsg = new HSGTraceability(false);

                        cboUSBPort.Items.Clear();

                        txtComputerName.Text = objMachine.GetComputerName();

                        this.Text = "Bending Project SW" + getVersion() + " DLL:" + objMachine.GetVersion() + " API:" + objMachine.GetWebServiceVersion () + " status:" + objMachine.ConnectDatabase();

                        // Display each port name to the console.
                        foreach (string port in ports)
                        {
                            cboUSBPort.Items.Add(port);
                            //Console.WriteLine(port);
                        }

                        this.serialPort1.BaudRate = 115200;         // 9600, 19200, 38400, 57600 or 115200
                        this.serialPort1.DataBits = 8;              // 7 or 8
                        this.serialPort1.Parity = Parity.Even;    // Even or Odd
                        this.serialPort1.StopBits = StopBits.One;   // One or Two
                      
            //this.serialPort1.PortName = "COM3";
            //this.serialPort1.PortName = "COM4";

            //this.serialPort2.BaudRate = 115200;         // 9600, 19200, 38400, 57600 or 115200
            //this.serialPort2.DataBits = 8;              // 7 or 8
            //this.serialPort2.Parity = Parity.Even;    // Even or Odd
            //this.serialPort2.StopBits = StopBits.One;   // One or Two
            //this.serialPort2.PortName = "COM5";

            //serialPortInstance = new SerialPort[1] { this.serialPort1 };

            //if (cboUSBPort.Items.Count == 1)
            //{
            //    serialPortInstance = new SerialPort[1] { this.serialPort1 };
            //}
            //else
            //{
            //    if (cboUSBPort.Items.Count == 2)
            //    {
            //        serialPortInstance = new SerialPort[2] { this.serialPort1, this.serialPort2 };
            //    }
            //}

            //
            // Store COM ports instances in the array.
            ////
            //if (cboUSBPort.Items.Count == 1)
            //{
            //    //serialPortInstance = new SerialPort[1] { this.serialPort1 };
            //    serialPortInstance = new SerialPort[1] { this.serialPort1 };
            //}            
            //else
            //{
            //    //if (cboUSBPort.Items.Count == 2)
            //    //{
            //    //    serialPortInstance = new SerialPort[2] { this.serialPort1, this.serialPort2 };
            //    //}
            //}
           
            cboConsole.SelectedIndex = 0; */
            //cboUSBPort.SelectedIndex = 0;

            gConsole1.Enabled = false;
            btnLogin.Enabled = false;

            //Connection();
            ClearBuffer();
            txtEN.Focus();


        }

        private void Connection()
        {
            for (int i = 0; i < serialPortInstance.Length; i++)
            {
                try
                {
                    //
                    // Close the COM port if opened.
                    //
                    if (serialPortInstance[i].IsOpen)
                    {
                        this.serialPortInstance[i].Close();
                    }

                    //
                    // Open the COM port.
                    //
                    this.serialPortInstance[i].Open();

                    //
                    // Set 100 milliseconds to receive timeout.
                    //
                    this.serialPortInstance[i].ReadTimeout = 100;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(serialPortInstance[i].PortName + "\r\n" + ex.Message);  // non-existent or disappeared
                }
            }
        }

        private void ClearBuffer()
        {
            dsData = null;                      

            dsData = new DataTable();
            dsData.Columns.Add("machinename1");
            dsData.Columns.Add("machinename2");
            dsData.Columns.Add("serialno");
            dsData.Columns.Add("jobname");
            dsData.Columns.Add("creationdate");
            

        }
        private void getDefaultMachine()
        {
            if (txtBendingMachine.Text == txtBendingMachine_2.Text)
            {
                txtMC_2.Text = "Error";
                MessageBox.Show("Error: เครื่อง Bending : " + txtBendingMachine_2.Text + " นี้ ซ้ำ !!! ");
                txtMC_2.BackColor = Color.Red;
                txtBendingMachine_2.Text = "";
                txtBendingMachine_2.Focus();
                txtBendingMachine_2.Select();
            }
            else
            {
                try
                {
                    objModel = objMachine.GetBendingMaster(txtBendingMachine.Text);
                    if (objModel.Count == 0)
                    {
                        txtBendingMachine.Text = "";
                        txtBendingMachine.Focus();
                        txtBendingMachine.Select();

                        txtMC_1.Text = "Error";
                        MessageBox.Show("Error: เครื่อง Bending : " + txtBendingMachine.Text + " นี้ ไม่พบ Model Config.");
                        txtMC_1.BackColor = Color.Red;

                    }
                    else
                    {
                        //txtBendingMachine1.Text = txtBendingMachine.Text; 
                        txtMC_1.Text = "OK";
                        txtMC_1.BackColor = Color.Green;
                        txtBendingMachine_2.Focus();

                    }
                } 
                catch (Exception ex)
                {
                    CheckAllReady();
                    txtMC_1.Text = "Error";
                    txtMC_1.BackColor = Color.Red;
                    MessageBox.Show("Error:" + ex.Message);
                    txtBendingMachine.Text = "";
                    txtBendingMachine.Focus();
                    txtBendingMachine.Select();

                }
                try {
                    objModel = objMachine.GetBendingMaster(txtBendingMachine_2.Text);
                    if (objModel.Count == 0)
                    {
                        txtMC_2.Text = "Error";
                        MessageBox.Show("Error: เครื่อง Bending : " + txtBendingMachine_2.Text + " นี้ ไม่พบ Model Config.");
                        txtMC_2.BackColor = Color.Red;
                        txtBendingMachine_2.Text = "";
                        txtBendingMachine_2.Focus();
                        txtBendingMachine_2.Select();
                    }
                    else
                    {
                        //txtBendingMachine2.Text = txtBendingMachine_2.Text;
                        txtMC_2.Text = "OK";
                        txtMC_2.BackColor = Color.Green;
                        if (txtEnStatus.Text == "OK" && txtMC_1.Text == "OK" && txtMC_2.Text == "OK")
                        {
                            txtEN.Enabled = false;
                            txtBendingMachine.Enabled = false;
                            txtBendingMachine_2.Enabled = false;
                            textReady.Text = "Ready to operate";
                            textReady.BackColor = Color.Green;
                        }

                    }
                } 
                catch (Exception ex)
                {
                    CheckAllReady();
                    txtMC_2.Text = "Error";
                    txtMC_2.BackColor = Color.Red;
                    MessageBox.Show("Error:" + ex.Message);
                    txtBendingMachine_2.Text = "";
                    txtBendingMachine_2.Focus();
                    txtBendingMachine_2.Select();
                }


            }

            CheckAllReady();

        }
        private void CheckAllReady()
        {
            btnLogin.Enabled = false;
            if (txtEnStatus.Text == "OK" && txtMC_1.Text == "OK" && txtMC_2.Text == "OK")
            {
                btnLogin.Enabled = true;
            }
            else
            {
                btnLogin.Enabled = false;
            }
            txtBendingMachine.Enabled = false;
            txtBendingMachine_2.Enabled = false;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txt2DBarcode1.Focus();
            }

        }

        private void txt2DBarcode_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt2DBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {                
                try
                {
                    SaveData();
                }
                catch (Exception ex)
                {
                    //throw new Exception(ex.Message);

                    txtStatus1.BackColor = Color.Red;
                    //txtStatus1.Text = ex.Message;
                    txtStatus1.Text = "Vericode : " + txt2DBarcode1.Text + " นี้ "+ ex.Message;
                    txt2DBarcode1.Text = "";
                    txt2DBarcode1.Focus();
                }
            }
        }

        private void SaveData()
        {
            PrintinfoM objPrintinfo = new PrintinfoM();
            DataTable dt;
            DataRow dr;

            bool bModel = false;


            objPrintinfo.Customer = "HHG";
            objPrintinfo.Serialno = txt2DBarcode1.Text;
            objPrintinfo = objHsg.GetPrintInfo(objPrintinfo);

            if (objModel.Count == 0)
            {
                txtStatus1.BackColor = Color.Red;
                txtStatus1.Text = "เครื่อง Bending : "+ txtBendingMachine1.Text+" นี้ ไม่พบ Model Config.";
                txt2DBarcode1.Text = "";
                txt2DBarcode1.Focus();
            }
            else {
                if (objPrintinfo.ModelName == "")
                {
                    txtStatus1.BackColor = Color.Red;
                    txtStatus1.Text = "Vericode : " + txt2DBarcode1.Text + " นี้ ไม่พบ Model.";
                    txt2DBarcode1.Text = "";
                    txt2DBarcode1.Focus();
                }
                else {
                    // Check Model with bending Control
                    /*
                     DataRow[] rsSP = INPUT_LISTS.Select(" model = 'BY-PASS' ");
                            if (rsSP.Length > 0)
                            {
                            } 
                            model
                     */
                    //string[] objModelTemp = objModel.Select(x => x.Contains("BY-PASS") ? x.Replace("BY-PASS", "") : x).ToArray();
                    string[] objModelTemp = objModel.Select(x => x.Contains("BY-PASS") ? x.Replace("BY-PASS", "SKIP") : x).ToArray();
                    if(objModelTemp.Length > 0)
                    {
                        bModel = true;
                    }
                    else
                    {
                        for (int i = 0; i <= objModel.Count - 1; i++)
                        {

                            if (objModel[i] == objPrintinfo.ModelName)
                            {
                                bModel = true;
                                break;
                            }
                        }
                    }

                    if (bModel == false)
                    {
                        txtStatus1.BackColor = Color.Red;
                        txtStatus1.Text = "เครื่อง Bending นี้ไม่สามารถใช้กับ Model:" + objPrintinfo.ModelName + " นี้ได้";
                        txt2DBarcode1.Text = "";
                        txt2DBarcode1.Focus();
                    }
                    else
                    {
                        txtStatus1.BackColor = Color.Green;
                        txtStatus1.Text = "PASS";
                    }

                    if (bModel == true)
                    {
                        objPrintinfo.ComputerName = txtComputerName.Text;
                        objPrintinfo.MachineName = txtBendingMachine1.Text;

                        //objPrintinfo.ComputerName = txtComputerName.Text;
                        

                        dt = SaveBendingInfo(objPrintinfo);

                        for (int i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            if (dt.Rows[i]["SCAN_MESSAGE"].ToString() == "PASS")
                            {
                                dr = dsData.NewRow(); 
                                dr["machinename1"] = dt.Rows[i]["machinename"].ToString();
                                dr["machinename2"] = dt.Rows[i]["machinename_2"].ToString();
                                dr["serialno"] = dt.Rows[i]["serialno"].ToString();
                                dr["jobname"] = dt.Rows[i]["jobname"].ToString();
                                dr["creationdate"] = dt.Rows[i]["creationdate"].ToString();                                
                                dsData.Rows.Add(dr);
                            }
                            else
                            {
                                txtStatus1.BackColor = Color.Red;
                                txtStatus1.Text = dt.Rows[i]["SCAN_MESSAGE"].ToString();
                            }


                            dr = null;

                        }
                         
                        grdView1.DataSource = dsData;
                        grdView1.Refresh();
                        txt2DBarcode1.Text = "";
                        txt2DBarcode1.Focus();
                        txtTotal.Text = Convert.ToString(grdView1.RowCount-1);

                    }
                }
            }
        }

        private DataTable  SaveBendingInfo(PrintinfoM objPrintM)
        {                        
            try
            {
               return  objMachine.SaveBendingInfo(objPrintM);
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (btnConnect.Text == "Connect")
            {
                Connected();
                btnConnect.Text = "Connected";
            }
            else
            {
                if (btnConnect.Text == "Connected")
                {
                    Disconnected();
                    btnConnect.Text = "Connect";
                }
            }
        }

        private void Disconnected()
        {
            //
            // Send "LOFF" command.
            // Set STX to command header and ETX to the terminator to distinguish between command respons
            // and read data when receives data from readers.
            // 
            string loff = "\x02LOFF\x03";   // <STX>LOFF<ETX>
            Byte[] sendBytes = ASCIIEncoding.ASCII.GetBytes(loff);

            for (int i = 0; i < serialPortInstance.Length; i++)
            {
                if (this.serialPortInstance[i].IsOpen)
                {
                    try
                    {
                        this.serialPortInstance[i].Write(sendBytes, 0, sendBytes.Length);
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show(serialPortInstance[i].PortName + "\r\n" + ex.Message);    // disappeared
                    }
                }
                else
                {
                    MessageBox.Show(serialPortInstance[i].PortName + " is disconnected.");
                }
            }
        }
        private void Connected()
        {
            //
            // Send "LON" command.
            // Set STX to command header and ETX to the terminator to distinguish between command respons
            // and read data when receives data from readers.
            // 
            TypeUse = true;
            string lon = "\x02LON\x03";   // <STX>LON<ETX>
            Byte[] sendBytes = ASCIIEncoding.ASCII.GetBytes(lon);

            for (int i = 0; i < serialPortInstance.Length; i++)
            {
                if (this.serialPortInstance[i].IsOpen)
                {
                    try
                    {
                        this.serialPortInstance[i].Write(sendBytes, 0, sendBytes.Length);
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show(serialPortInstance[i].PortName + "\r\n" + ex.Message);    // disappeared
                    }
                }
                else
                {
                    MessageBox.Show(serialPortInstance[i].PortName + " is disconnected.");
                }
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (TypeUse)
            {
                string lon = "\x02LON\x03";
                // <STX>LON<ETX>
                Byte[] sendBytes = ASCIIEncoding.ASCII.GetBytes(lon);

                for (int i = 0; i <= serialPortInstance.Length - 1; i++)
                {
                    if (this.serialPort1.IsOpen)
                    {
                        try
                        {
                            this.serialPort1.Write(sendBytes, 0, sendBytes.Length);
                            ReceiveData();
                            //Button3_Click_1(sender, e);
                        }
                        catch (IOException ex)
                        {
                            // disappeared
                            MessageBox.Show(serialPort1.PortName  + ex.Message);
                        }
                    }
                    else
                        MessageBox.Show(serialPort1.PortName + " is disconnected.");
                }
            }
            else
            {
                string loff = "\x02LOFF\x03";
                // <STX>LOFF<ETX>
                Byte[] sendBytes = ASCIIEncoding.ASCII.GetBytes(loff);

                for (int i = 0; i <= serialPortInstance.Length - 1; i++)
                {
                    if (this.serialPort1.IsOpen)
                    {
                        try
                        {
                            this.serialPort1.Write(sendBytes, 0, sendBytes.Length);
                        }
                        catch (IOException ex)
                        {
                            // disappeared
                            MessageBox.Show(serialPort1.PortName + ex.Message);
                        }
                    }
                    else
                        MessageBox.Show(serialPort1.PortName + " is disconnected.");
                }
            }
        }

        private void ReceiveData()
        {
            Byte[] recvBytes = new Byte[RECV_DATA_MAX - 1 + 1];
            int recvSize;

            // for (int i = 0; i < this.serialPortInstance.Length; i++)
            // {
            if (this.serialPort1.IsOpen == false)
                // continue;
                MessageBox.Show(serialPort1.PortName + " is disconnected.");

            while (true)
            {
                try
                {
                    recvSize = readDataSub(recvBytes, this.serialPort1);
                }
                catch (IOException ex)
                {
                    // MessageBox.Show(serialPort1.PortName + "\r\n" + ex.Message);    // disappeared
                    break;
                }
                if (recvSize == 0)
                    // MessageBox.Show(serialPort1.PortName + " has no data.");
                    break;
                if (recvBytes[0] == STX)
                    // 
                    // Skip if command response.
                    // 
                    continue;
                else
                {
                    // 
                    // Show the receive data after converting the receive data to Shift-JIS.
                    // Terminating null to handle as string.
                    // 
                    recvBytes[recvSize] = 0;
                    // MessageBox.Show(serialPort1.PortName + "\r\n" + Encoding.GetEncoding("Shift_JIS").GetString(recvBytes));
                    //SN = Encoding.GetEncoding("Shift_JIS").GetString(recvBytes);
                    SN = Encoding.GetEncoding("Shift_JIS").GetString(recvBytes).ToString().Replace("\r", "").Replace ("\0", "");

                    if (!(SN.Contains("ERROR") | SN.Contains("ER,lon")))
                        SetText(SN.ToString());

                    break;
                }
            }
        }

        private int readDataSub(Byte[] recvBytes, SerialPort serialPortInstance)
        {
            int recvSize = 0;
            bool isCommandRes = false;
            byte d;
            // 
            // Distinguish between command response and read data.
            // 
            try
            {
                d = Convert.ToByte(serialPortInstance.ReadByte()); // DirectCast(serialPortInstance.ReadByte(), [Byte])
                recvBytes[System.Math.Max(System.Threading.Interlocked.Increment(ref recvSize), recvSize - 1)] = d;
                if (d == STX)
                    // Distinguish between command response and read data.
                    isCommandRes = true;
            }
            catch (TimeoutException generatedExceptionName)
            {
                // No data received.
                return 0;
            }

            // 
            // Receive data until the terminator character.
            // 
            while (true)
            {
                try
                {
                    // d = DirectCast(serialPortInstance.ReadByte(), [Byte])
                    d = Convert.ToByte(serialPortInstance.ReadByte());
                    recvBytes[System.Math.Max(System.Threading.Interlocked.Increment(ref recvSize), recvSize - 1)] = d;

                    if (isCommandRes && (d == ETX))
                        // Command response is received completely.
                        break;
                    else if (d == CR)
                    {
                        if (checkDataSize(recvBytes, recvSize))
                            // Read data is received completely.
                            break;
                    }
                }
                catch (TimeoutException ex)
                {
                    // 
                    // No terminator is received.
                    // 
                    MessageBox.Show(ex.Message);
                    return 0;
                }
            }

            return recvSize;
        }

        private bool checkDataSize(Byte[] recvBytes, int recvSize)
        {
            const int dataSizeLen = 4;

            if (binaryDataMode == false)
            {
                return true;
            }

            if (recvSize < dataSizeLen)
            {
                return false;
            }

            int dataSize = 0;
            int mul = 1;
            for (int i = 0; i < dataSizeLen; i++)
            {
                dataSize += (recvBytes[dataSizeLen - 1 - i] - '0') * mul;
                mul *= 10;
            }

            return (dataSize + 1 == recvSize);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                if (cboConsole.Text == "Console1")
                {
                    //gConsole1.Enabled = true;

                    //this.serialPort1.BaudRate = 115200;         // 9600, 19200, 38400, 57600 or 115200
                    //this.serialPort1.DataBits = 8;              // 7 or 8
                    //this.serialPort1.Parity = Parity.Even;    // Even or Odd
                    //this.serialPort1.StopBits = StopBits.One;   // One or Two
                    //this.serialPort1.PortName = cboUSBPort.SelectedText;

                    objModel = objMachine.GetBendingMaster(txtBendingMachine.Text);
                    if(objModel.Count == 0)
                    {
                        MessageBox.Show("Error: เครื่อง Bending : "+ txtBendingMachine.Text+" นี้ ไม่พบ Model Config.");
                    }else
                    {
                        txtUsbPort1.Text = cboUSBPort.Text;
                        txtBendingMachine1.Text = txtBendingMachine.Text;
                        this.serialPort1.PortName = txtUsbPort1.Text;
                        serialPortInstance = new SerialPort[1] { this.serialPort1 }; 

                        Connection();

                        gConsole1.Enabled = true;
                    }
         
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }

        }

        private void txt2DBarcode1_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void btnLogout_Click(object sender, EventArgs e)
        {
            txtEN.Enabled = true;
            txtBendingMachine.Enabled = true;
            txtBendingMachine_2.Enabled = true;
            txtEN.Text = "";
            txtBendingMachine.Text = "";
            txtBendingMachine_2.Text = "";
            txtBendingMachine1.Text = "";
            txtBendingMachine2.Text = "";
            txtEnStatus.Text = "Waiting";
            txtEnStatus.BackColor = Color.Orange;
            txtMC_1.Text = "Waiting";
            txtMC_1.BackColor = Color.Orange;
            txtMC_2.Text = "Waiting";
            txtMC_2.BackColor = Color.Orange;
            textReady.Text = "Operation is not ready";
            textReady.BackColor = Color.OrangeRed;

            txtStatus1.BackColor = Color.Silver; 

            txtStatus1.Text = "";
            grdView1.DataSource = "";
            grdView1.Refresh();
            gConsole1.Enabled = false;
            txtEN.Focus();


        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBendingMachine.Text == "" || txtBendingMachine_2.Text == "" || txtEN.Text =="")
                {
                    textReady.Text = "Operation is not ready";
                    textReady.BackColor = Color.Red;
                    gConsole1.Enabled = false;
                    MessageBox.Show("Error: กรุณา Scan ข้อมูลให้ครบ !!! "); 
                } else
                {
                
                    if (txtBendingMachine.Text == txtBendingMachine_2.Text)
                    {
                        txtMC_2.Text = "Error";
                        MessageBox.Show("Error: เครื่อง Bending : " + txtBendingMachine_2.Text + " นี้ ซ้ำ !!! ");
                        txtMC_2.BackColor = Color.Red;
                        txtBendingMachine_2.Text = "";
                        txtBendingMachine_2.Focus();
                        txtBendingMachine_2.Select();
                    }
                    else
                    {
                
                        if (txtEnStatus.Text == "OK" && txtMC_1.Text == "OK" && txtMC_2.Text == "OK")
                        {
                            string errEn = objMachine.SaveBendingLogin(txtComputerName.Text, txtBendingMachine.Text, txtBendingMachine_2.Text,txtEN.Text);
                            if (errEn == "OK")
                            {
                                txtEN.Enabled = false;
                                txtBendingMachine.Enabled = false;
                                txtBendingMachine_2.Enabled = false;
                                textReady.Text = "Ready to operate";
                                textReady.BackColor = Color.Green;



                                txtBendingMachine1.Text = txtBendingMachine.Text;
                                txtBendingMachine2.Text = txtBendingMachine_2.Text;

                                gConsole1.Enabled = true;
                                txt2DBarcode1.Focus();
                            }else
                            {
                                txtEN.Enabled = true;
                                txtBendingMachine.Enabled = true;
                                txtBendingMachine_2.Enabled = true;
                                txtBendingMachine1.Text = "";
                                txtBendingMachine2.Text = "";
                                textReady.Text = "Operation is not ready";
                                textReady.BackColor = Color.Red;
                                gConsole1.Enabled = false;
                                MessageBox.Show("Error: Login Fail . ");
                            }
                        }
                        else
                        {
                            txtEN.Enabled = true;
                            txtBendingMachine.Enabled = true;
                            txtBendingMachine_2.Enabled = true;
                            txtBendingMachine1.Text = "";
                            txtBendingMachine2.Text = "";
                            textReady.Text = "Operation is not ready";
                            textReady.BackColor = Color.Red;
                            gConsole1.Enabled = false;
                            MessageBox.Show("Error: Operation is not ready.");
                        }
                    }
                }
                //gConsole1.Enabled = true;

                //this.serialPort1.BaudRate = 115200;         // 9600, 19200, 38400, 57600 or 115200
                //this.serialPort1.DataBits = 8;              // 7 or 8
                //this.serialPort1.Parity = Parity.Even;    // Even or Odd
                //this.serialPort1.StopBits = StopBits.One;   // One or Two
                //this.serialPort1.PortName = cboUSBPort.SelectedText;
                /*
                objModel = objMachine.GetBendingMaster(txtBendingMachine.Text);
                if (objModel.Count == 0)
                {
                    MessageBox.Show("Error: เครื่อง Bending : " + txtBendingMachine.Text + " นี้ ไม่พบ Model Config.");
                }
                else
                {
                    //txtUsbPort1.Text = cboUSBPort.Text;
                    txtBendingMachine1.Text = txtBendingMachine.Text;
                    txtBendingMachine2.Text = txtBendingMachine_2.Text;
                   // this.serialPort1.PortName = txtUsbPort1.Text;
                    //serialPortInstance = new SerialPort[1] { this.serialPort1 };

                    Connection();

                    gConsole1.Enabled = true;
                }*/


            }
            catch (Exception ex)
            {
                textReady.Text = "Operation is not ready";
                textReady.BackColor = Color.Red;
                MessageBox.Show("Error:" + ex.Message);
            }
        }

        private void txtBendingMachine_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                if (e.KeyChar == 13)
                {
                    objModel = objMachine.GetBendingMaster(txtBendingMachine.Text);
                    if (objModel.Count == 0)
                    {
                        txtBendingMachine.Text = "";
                        txtBendingMachine.Focus();
                        txtBendingMachine.Select();

                        txtMC_1.Text = "Error";
                        MessageBox.Show("Error: เครื่อง Bending : " + txtBendingMachine.Text + " นี้ ไม่พบ Model Config.");
                        txtMC_1.BackColor = Color.Red;
                        
                    }
                    else
                    {
                        //txtBendingMachine1.Text = txtBendingMachine.Text; 
                        txtMC_1.Text = "OK";
                        txtMC_1.BackColor = Color.Green;
                        txtBendingMachine_2.Focus();

                    }
                    CheckAllReady();
                }
                    




            }
            catch (Exception ex)
            {
                CheckAllReady();
                txtMC_1.Text = "Error";
                txtMC_1.BackColor = Color.Red;
                MessageBox.Show("Error:" + ex.Message);
                txtBendingMachine.Text = "";
                txtBendingMachine.Focus();
                txtBendingMachine.Select();

            }
        }

        private void txtBendingMachine_2_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                if (e.KeyChar == 13)
                {
                    if(txtBendingMachine.Text == txtBendingMachine_2.Text)
                    {
                        txtMC_2.Text = "Error";
                        MessageBox.Show("Error: เครื่อง Bending : " + txtBendingMachine_2.Text + " นี้ ซ้ำ !!! ");
                        txtMC_2.BackColor = Color.Red;
                        txtBendingMachine_2.Text = "";
                        txtBendingMachine_2.Focus();
                        txtBendingMachine_2.Select();
                    }
                    else
                    {
                        objModel = objMachine.GetBendingMaster(txtBendingMachine_2.Text);
                        if (objModel.Count == 0)
                        {
                            txtMC_2.Text = "Error";
                            MessageBox.Show("Error: เครื่อง Bending : " + txtBendingMachine_2.Text + " นี้ ไม่พบ Model Config.");
                            txtMC_2.BackColor = Color.Red;
                            txtBendingMachine_2.Text = "";
                            txtBendingMachine_2.Focus();
                            txtBendingMachine_2.Select();
                        }
                        else
                        {
                            //txtBendingMachine2.Text = txtBendingMachine_2.Text;
                            txtMC_2.Text = "OK";
                            txtMC_2.BackColor = Color.Green;
                                if (txtEnStatus.Text == "OK" && txtMC_1.Text == "OK" && txtMC_2.Text == "OK")
                                {
                                    txtEN.Enabled = false;
                                    txtBendingMachine.Enabled = false;
                                    txtBendingMachine_2.Enabled = false;
                                    textReady.Text = "Ready to operate";
                                    textReady.BackColor = Color.Green;
                                }

                            }
                    }

                    CheckAllReady();
    
                }

            }
            catch (Exception ex)
            {
                CheckAllReady();
                txtMC_2.Text = "Error";
                txtMC_2.BackColor = Color.Red;
                MessageBox.Show("Error:" + ex.Message);
                txtBendingMachine_2.Text = "";
                txtBendingMachine_2.Focus();
                txtBendingMachine_2.Select();
            }
        }

        private void txtEN_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                if (e.KeyChar == 13)
                {
                     
                    string errEn = objMachine.isValidateEN(txtEN.Text);
                    if (errEn == "OK")
                    {


                        //txtBendingMachine.Focus();
                        txtEnStatus.Text = "OK";
                        txtEnStatus.BackColor = Color.Green;
                        string rsMachine = objMachine.getBendingMachineName(txtComputerName.Text);
                        String[] sResultX = rsMachine.Split(',');
                        if (sResultX[0].ToString() != "OK")
                        {
                            txtEnStatus.Text = "Error";
                            txtEnStatus.BackColor = Color.Red;
                            txtEN.Text = "";
                            txtEN.Focus();
                            MessageBox.Show("Error: Computer Name :"+ txtComputerName.Text+" ยังไม่ได้ Setup Machine Name .");
                        }
                        else
                        {
                            txtBendingMachine.Text = sResultX[1];
                            txtBendingMachine_2.Text = sResultX[2];

                            getDefaultMachine();
                        }


                    }
                    else
                    {
                        txtEnStatus.Text = "Error";                        
                        txtEnStatus.BackColor = Color.Red;
                        txtEN.Text = "";
                        txtEN.Focus();
                        MessageBox.Show("Error: ไม่พบ EN : " + txtEN.Text + " นี้ ในระบบ HRMS.");

                    }
                    CheckAllReady();
                }





            }
            catch (Exception ex)
            {
                CheckAllReady();
                txtEN.Text = "";
                txtEN.Select();
                txtEnStatus.Text = "Error";
                txtEnStatus.BackColor = Color.Red;
                MessageBox.Show("Error:" + ex.Message);
                

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
