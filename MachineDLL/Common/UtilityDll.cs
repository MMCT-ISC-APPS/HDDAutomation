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
    public abstract  class  UtilityDll 
    {

        private bool bOnline = true;
       
        public UtilityDll(bool Online)
        {
            bOnline = Online;
        }


        public UtilityDll()
        {
            bOnline = true;
        }

        public bool Online
        {
            get
            {
                return bOnline;
            }

            set
            {
                bOnline = value;
            }
        }

        
        public String ConnectDatabase()
        {
            try
            {
                if (bOnline == true)
                {
                    Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    var result = socket.BeginConnect(SystemController.WSSERVER, 80, null, null);
                    bool success = result.AsyncWaitHandle.WaitOne(3000, false); // test the connection for 3 seconds
                    var resturnVal = socket.Connected;
                    if (socket.Connected)
                        socket.Disconnect(true);
                    
                    if (resturnVal == true)
                    {
                        UtilityDAO objUtility = new UtilityDAO();
                        return objUtility.ConnectDatabase(false);
                    }
                    else
                    {
                        return "Disconnect(Webservice)";
                    }

                }
                else
                {
                    return "Connected(Offline)";
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public String GetComputerName()
        {
            SystemUtility objSystem = new SystemUtility();           
            return objSystem.GetComputerName();
        }

        public String GetVersion()
        {
            SystemUtility objSystem = new SystemUtility();

            try
            {
                if (bOnline == true)
                {
                    return objSystem.getVersion();
                }
                else
                {
                    return "Offline v1.0.0.1";
                }
                    
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public String GetWebServiceVersion()
        {
            UtilityDAO objUtility = new UtilityDAO();

            try
            {
                if (bOnline == true)
                {
                    return objUtility.GetWebServiceVersion();
                }
                else {
                    return "WS (Offline) v1.0.0.1";
                }
                    
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                objUtility = null;
            }
        }

        public JobinfoM IsValidJob(String sProgramName  , String sJobName)
        {
            JobInfoDAO objJobDAO = new JobInfoDAO();
            JobinfoM objJobM = new JobinfoM();

            try
            {
                objJobM.ProgramName = sProgramName;
                objJobM.JobName = sJobName;

                return objJobDAO.IsValidJob(objJobM);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally {
                objJobM = null;
                objJobDAO = null;
            }
        }

        
    }
}
