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
            //string[] ports =  new string[] { "COM1", "COM2", "COM3", "COM4" }; ;//SerialPort.GetPortNames();
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

            cboConsole.SelectedIndex = 0;
            //cboUSBPort.SelectedIndex = 0;

            gConsole1.Enabled = false;

            //Connection();
            ClearBuffer();

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

            dsData.Columns.Add("machinename");
            dsData.Columns.Add("serialno");
            dsData.Columns.Add("jobname");

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
                SaveData();
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
            }
            else {
                if (objPrintinfo.ModelName == "")
                {
                    txtStatus1.BackColor = Color.Red;
                    txtStatus1.Text = "Vericode : " + txt2DBarcode1.Text + " นี้ ไม่พบ Model.";
                }
                else { 
                    // Check Model with bending Control
                    for (int i = 0; i <= objModel.Count - 1; i++)
                    {
                        if (objModel[i] == objPrintinfo.ModelName)
                        {
                            bModel = true;
                            break;
                        }
                    }
                    if (bModel == false)
                    {
                        txtStatus1.BackColor = Color.Red;
                        txtStatus1.Text = "เครื่อง Bending นี้ไม่สามารถใช้กับ Model:" + objPrintinfo.ModelName + " นี้ได้";
                    }
                    else
                    {
                        txtStatus1.BackColor = Color.Green;
                        txtStatus1.Text = "PASS";
                    }

                    if (bModel == true)
                    {
                        objPrintinfo.MachineName = txtBendingMachine1.Text;
                        objPrintinfo.ComputerName = txtComputerName.Text;

                        dt = SaveBendingInfo(objPrintinfo);

                        for (int i = 0; i <= dt.Rows.Count - 1; i++)
                        {
                            if (dt.Rows[i]["SCAN_MESSAGE"].ToString() == "PASS")
                            {
                                dr = dsData.NewRow();
                                dr["machinename"] = dt.Rows[i]["machinename"].ToString();
                                dr["serialno"] = dt.Rows[i]["serialno"].ToString();
                                dr["jobname"] = dt.Rows[i]["jobname"].ToString();

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
    }
}
