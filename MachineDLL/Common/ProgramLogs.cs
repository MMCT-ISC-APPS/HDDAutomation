using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualBasic;

namespace MachineDLL.Common
{
    class ProgramLogs
    {
        private string sFileName;
        private System.IO.TextWriter objWriteFile;
        private string sPathEnvironment = "";
        private string sProgramVersion = "";
        private string sProgramMachine = "";

        public ProgramLogs()
        {
            SystemUtility objSystem = new SystemUtility();            
            sPathEnvironment = objSystem.getApplicationPath()  + @"\systemlogs";
            sProgramVersion = objSystem.getVersion();
            sProgramMachine = objSystem.GetComputerName();
            objSystem = null;
        }
        public string FileName
        {
            get
            {
                return sFileName;
            }
        }

        public void WrirteLogMessage(Dictionary<string, string> lst2D, string sFixtureNo, string sJobName)
        {
            try
            {
                //string sDirectory = System.Environment.CurrentDirectory + @"\" + DateTime.Now.Year + @"\" + DateTime.Now.Month + @"\" + DateTime.Now.Date.ToString ("ddMMyy") + @"\" + sJobName + ".txt";
                //string sDirectoryPath = System.Environment.CurrentDirectory + @"\" + DateTime.Now.Year + @"\" + DateTime.Now.Month + @"\" + DateTime.Now.Date.ToString ("ddMMyy") + @"\";
                string sDirectory = sPathEnvironment + @"\" + DateTime.Now.Year + @"\" + DateTime.Now.Month + @"\" + DateTime.Now.Date.ToString("ddMMyy") + @"\" + sJobName + ".txt";
                string sDirectoryPath = sPathEnvironment  + @"\" + DateTime.Now.Year + @"\" + DateTime.Now.Month + @"\" + DateTime.Now.Date.ToString("ddMMyy") + @"\";

                if (Directory.Exists(sDirectoryPath) == false)
                {
                    Directory.CreateDirectory(sDirectoryPath);
                    objWriteFile = new StreamWriter(sDirectory);
                }
                else
                    objWriteFile = File.AppendText(sDirectory);

                if (objWriteFile == null)
                    throw new Exception("can't initial text writer.");

                objWriteFile.WriteLine("Date:" + DateTime.Now + " :Fixture:" + sFixtureNo);

                foreach (KeyValuePair<string, string> pair in lst2D)
                    objWriteFile.WriteLine(pair.Key);

                objWriteFile.WriteLine("******************" + "Fixture:" + sFixtureNo + "*******************");

                objWriteFile.Flush();

                CloseFile();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void WrirteLogMessage(string sText, string sFixtureNo)
        {
            try
            {
                string sDirectory = sPathEnvironment + @"\" + DateTime.Now.Year + @"\" + DateTime.Now.Month + @"\" + DateTime.Now.Date.ToString("ddMMyyyy") + ".txt";
                string sDirectoryPath = sPathEnvironment + @"\" + DateTime.Now.Year + @"\" + DateTime.Now.Month + @"\";

                if (Directory.Exists(sDirectoryPath) == false)
                {
                    Directory.CreateDirectory(sDirectoryPath);
                    objWriteFile = new StreamWriter(sDirectory);
                }
                else
                    objWriteFile = File.AppendText(sDirectory);

                if (objWriteFile == null)
                    throw new Exception("can't initial text writer.");

                objWriteFile.WriteLine(DateTime.Now + ":" + sText + ":" + sFixtureNo);

                objWriteFile.Flush();

                CloseFile();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void WrirteLogMessage(string sText)
        {
            try
            {
                string sDirectory = sPathEnvironment + @"\" + DateTime.Now.Year + @"\" + DateTime.Now.Month + @"\" + DateTime.Now.Date.ToString("ddMMyyyy") + ".txt";
                string sDirectoryPath = sPathEnvironment + @"\" + DateTime.Now.Year + @"\" + DateTime.Now.Month + @"\";

                if (Directory.Exists(sDirectoryPath) == false)
                {
                    Directory.CreateDirectory(sDirectoryPath);
                    objWriteFile = new StreamWriter(sDirectory);
                }
                else
                    objWriteFile = File.AppendText(sDirectory);

                if (objWriteFile == null)
                    throw new Exception("can't initial text writer.");

                objWriteFile.WriteLine(DateTime.Now + ":" + sText);

                objWriteFile.Flush();

                CloseFile();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void WrirteLogDatabase(string sText)
        {
            try
            {
                string sDirectory = sPathEnvironment + @"\" + DateTime.Now.Year + @"\" + DateTime.Now.Month + @"\sys_" + DateTime.Now.Date.ToString("ddMMyyyy") + ".txt";
                string sDirectoryPath = sPathEnvironment + @"\" + DateTime.Now.Year + @"\" + DateTime.Now.Month + @"\";

                if (Directory.Exists(sDirectoryPath) == false)
                {
                    Directory.CreateDirectory(sDirectoryPath);
                    objWriteFile = new StreamWriter(sDirectory);
                }
                else
                    objWriteFile = File.AppendText(sDirectory);

                if (objWriteFile == null)
                    throw new Exception("can't initial text writer.");

                objWriteFile.WriteLine(DateTime.Now + ":" + sText);

                objWriteFile.Flush();

                CloseFile();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void CloseFile()
        {
            try
            {
                if (objWriteFile != null)
                {
                    objWriteFile.Close();
                }

                objWriteFile = null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void WriteLog(string sFilename, string sMessage)
        {
            System.IO.TextWriter objWrite = null;

            try
            {
                objWrite = new StreamWriter(sFilename);
                objWrite.WriteLine(sMessage);
                objWrite.Flush();
                objWrite.Close();
                objWrite.Dispose();

                objWrite = null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
