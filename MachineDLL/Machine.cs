using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MachineDLL.DAO;
using MachineDLL.Entities;
using MachineDLL.Entities.AutoDictate;
using MachineDLL.Common;

using System.Data;

namespace MachineDLL
{
    public class Machine : UtilityDll
    {

        private bool bOnline;
        public Machine(bool Online) : base(Online)
        {
            bOnline = Online;
        }

        public Machine() : base()
        {
            bOnline = true;
        }

        static void Main()
        {

        }


        public String GetServer()
        {
            return SystemController.HTTP_PATH;
        }

        public String UploadFile(String sFileName , String CustName)
        {
            MachineDAO objMachine = new MachineDAO();

            try
            {
                return objMachine.UploadFile(sFileName , CustName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public String isValidateEN(String pEnNo)
        {
            MachineDAO objMachine = new MachineDAO();

            try
            {
                return objMachine.isValidateEN(pEnNo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public String getBendingMachineName(String pComputerName)
        {
            MachineDAO objMachine = new MachineDAO();

            try
            {
                return objMachine.getBendingMachineName(pComputerName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public String SaveBendingLogin(String ComputerName, String Machine1, String Machine2, String EnNo)
        {
            MachineDAO objMachine = new MachineDAO();

            try
            {
                return objMachine.SaveBendingLogin(ComputerName,   Machine1,   Machine2,   EnNo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public String UploadFileFromServer(String sFileName, String CustName , String ComputerName)
        {
            MachineDAO objMachine = new MachineDAO();
            try
            {
                return objMachine.UploadFileFromServer (sFileName, CustName , ComputerName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable  GetMachineConfig(String MachineName)
        {
            MachineDAO objMachine = new MachineDAO();
            MachineInfoM objMachineM = new MachineInfoM();
            
            try
            {
                objMachineM.MachineName = MachineName;
                return objMachine.GetMachineConfig (objMachineM);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public MachineInfoM SaveMachineInfo(MachineInfoM objMachineM)
        {
            MachineDAO objMachine = new MachineDAO();            

            try
            {                
                return objMachine.SaveMachineInfo (objMachineM);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public MachineInfoM InsertAOIInfo(MachineInfoM objMachineM)
        {
            MachineDAO objMachine = new MachineDAO();

            try
            {
                return objMachine.InsertAOIInfo (objMachineM);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public String UploadAOIFromServer(MachineInfoM objMachineM)
        {
            MachineDAO objMachine = new MachineDAO();

            try
            {
                return objMachine.UploadAOIFromServer(objMachineM);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable GetMachineFileUpload(MachineInfoM objMachineM)
        {
            MachineDAO objMachine = new MachineDAO();

            try
            {
                return objMachine.GetMachineFileUpload (objMachineM);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public String UploadErrorFile(String sFileName, String CustName)
        {
            MachineDAO objMachine = new MachineDAO();

            try
            {
                return objMachine.UploadErrorFile (sFileName, CustName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void WriteMachineErrorLogs(String sError)
        {
            ProgramLogs objLogs = new ProgramLogs();

            try
            {

                objLogs.WrirteLogMessage(sError);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public FixtureResult  UpdateAOIforTri(FixtureResult objFixture)
        {
            MachineDAO objMachine = new MachineDAO();

            try
            {
                return objMachine.UpdateAOIforTri(objFixture);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                objMachine = null;
            }
        }

        public  AutoDictConfigurationM GetModelConfiguration(String Model , String Prodline)
        {
            MachineDAO objMachine = new MachineDAO();
            AutoDictConfigurationM objConfigM = new AutoDictConfigurationM();

            try
            {
                objConfigM.ModelName  = Model;
                objConfigM.ProdLineName = Prodline;

                return objMachine.GetModelConfiguration(objConfigM);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                objConfigM = null;                 
                objMachine = null;
            }
        }

        
        public List<String> GetBendingMaster(String MachineName)
        {
            MachineDAO objMachine = new MachineDAO();

            try
            {
                return objMachine.GetBendingMaster(MachineName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                objMachine = null;
            }
        }

        public DataTable  SaveBendingInfo(PrintinfoM objPrintM)
        {
            MachineDAO objMachine = new MachineDAO();

            try
            {
                return objMachine.SaveBendingInfo(objPrintM);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                objMachine = null;
            }
        }

        public DataTable  Generate2DBarcode(ref JobinfoM objJobM)
        {
            MachineDAO objMachine = new MachineDAO();

            try
            {
                return objMachine.Generate2DBarcode(ref objJobM);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                objMachine = null;
            }
        }

        public JobinfoM GetTotalPrinted(JobinfoM objJobM)
        {
            MachineDAO objMachine = new MachineDAO();

            try
            {
                return objMachine.GetTotalPrinted(objJobM);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                objMachine = null;
            }
        }


        public String DoTestResult(String sMachineType , String PanelNo , Int64 Location, String sMachineNo, String sTestResult , String PicturePathNG, String PathFileData)
        {
            bool bOk = false;
            String sMessage = "";
            if (bOnline == true)
            {
                return "OK";
            }
            else
            {
                if (sMachineType == "XRAY")
                {
                    bOk = true;
                }

                if (sTestResult == "PASS")
                {

                }
                else {
                    if (sTestResult == "FAILED")
                    {
                        bOk = true;
                    }
                    else
                    {
                        bOk = false;
                        sMessage =  "Test Result isn't correct(PASS/FAILED). Could you please correct test result;";
                    }
                }

                if (bOk == true)
                {
                    return "OK";
                }
                else {
                    return sMessage;
                }
                
            }
            // sMachineType 
            //SPI , XRAY , AOI  
            
        }

    }
}
