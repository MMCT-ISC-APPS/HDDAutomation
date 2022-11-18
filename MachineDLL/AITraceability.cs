using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MachineDLL.DAO;
using MachineDLL.Common;
using MachineDLL.Entities;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Data;

namespace MachineDLL
{
    public class AITraceability : UtilityDll 
    {

        private JobinfoM objJobInfo = null;

        public AITraceability()
        {
            objJobInfo = new JobinfoM();
        }

        public String IsValid2D(List<PrintinfoM> lstPrintinfo)
        {
            String sTmp = "";
            PrintinfoDAO objPrint = new PrintinfoDAO();

            try
            {
                sTmp = objPrint.IsValid2D(lstPrintinfo);

                return sTmp;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            
        }

        public DataTable GetMachineData()
        {
            SystemUtility objSystem = new SystemUtility();
            MachineDAO objMachine = new MachineDAO();

            try
            {
                objJobInfo.MachineName = objSystem.GetComputerName();

                return objMachine.GetInkDataMachine(objJobInfo);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }finally
            {
                objSystem = null;
                objMachine = null;
            }
                        
        }

        public string[] GetJobInfo(String sJobName)
        {
            JobInfoDAO objJob = new JobInfoDAO(false);
            JobinfoM objJobInfo;
            try
            {
                String[] str = new string[9];

                objJobInfo = objJob.getJobinfo(sJobName);

                str[0] = objJobInfo.CPN;
                str[1] = objJobInfo.JobName;
                str[2] = objJobInfo.JobQty.ToString();
                str[3] = objJobInfo.Master2D;
                str[4] = objJobInfo.ModelName;
                str[5] = objJobInfo.PanelNo;
                str[6] = objJobInfo.PanelSize.ToString();
                str[7] = objJobInfo.Remain.ToString();
                str[8] = objJobInfo.Status;

                return str;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally {
                objJob = null;
            }
            
        }                
        public DataTable GenerateSerialNo(String sJobName , Int64 iJobQty)
        {
             PanelInfoDAO  objPanel = new  PanelInfoDAO ();

            try
            {
                objJobInfo.JobName = sJobName;
                objJobInfo.JobQty = iJobQty;

                return objPanel.GeneratedSerial(objJobInfo);

            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }


    }
}
