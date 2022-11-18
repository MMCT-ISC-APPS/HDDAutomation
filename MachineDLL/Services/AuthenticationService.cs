using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MachineDLL.Entities;
using System.Web;
using MachineDLL.Controller;
using System.Data.SqlClient;
using MachineDLL.DAO;

namespace MachineDLL.Services
{
    public class AuthenticationService
    {
        //private static readonly ILog logger = LogManager.GetLogger(typeof(AuthenticationService));
        private static String sessionParam = "JigsawULgIx";

        public static UserInfoM GetCurrentUserLogIn()
        {
            UserInfoM usrM = null;

            if (HttpContext.Current.Session[sessionParam] != null)
            {
                usrM = (UserInfoM)HttpContext.Current.Session[sessionParam];
            }

            return usrM;
        }

        public static void SetCurrentUserLogIn(UserInfoM usrM)
        {
            DBFactorySQL dbFactory = new DBFactorySQL();
            SqlConnection objConn = dbFactory.GetDBConnection();

            try
            {                
                AuthenticationDAO dao = new AuthenticationDAO();

                if (usrM != null)
                {
                    usrM = dao.GetUserDetail(usrM);
                    HttpContext.Current.Session[sessionParam] = usrM;
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {

                dbFactory.CloseConnection(objConn);
            }
        }

        public static void SetCurrentUserLogIn(UserInfoM usrM, String sAction)
        {
            try
            {
                if (sAction == "Training")
                {
                    usrM.fullName = "Training Center";
                    usrM.userNo = "-99";
                    usrM.userID = "-99";
                    usrM.userRole= "training";
                }

                HttpContext.Current.Session[sessionParam] = usrM;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //public ActionResultM DoLogIn(String usrName, String usrPwd)
        //{
        //    logger.Info("...DoLogIn(String usrName<" + usrName + ">, String usrPwd)");

        //    ActionResultM resultActM = new ActionResultM();
        //    UserM usrM = null;
        //    AuthenticationService.SetCurrentUserLogIn(null);

        //    AuthenticationDAO dao = new AuthenticationDAO();
        //    DBFactorySQL dbFactory = new DBFactorySQL();
        //    SqlConnection objConn = null;
        //    SqlTransaction objTrnx = null;

        //    try
        //    {
        //        objConn = dbFactory.GetDBConnection();
        //        objTrnx = objConn.BeginTransaction();

        //        resultActM = dao.DoLogIn(dbFactory, objConn, objTrnx, usrName, usrPwd);

        //        if (resultActM.Status)
        //        {
        //            dbFactory.CommitTransaction(objTrnx);

        //            usrM = dao.GetUserDetail(dbFactory, objConn, objTrnx, (String)resultActM.ReturnObj);
        //        }
        //        else
        //        {
        //            dbFactory.RollbackTransaction(objTrnx);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        dbFactory.RollbackTransaction(objTrnx);

        //        resultActM.Code = SystemMessageUtil.MSG_CODE.SYS_ERROR;
        //        resultActM.Message = SystemMessageUtil.GetMessage(resultActM.Code);
        //        resultActM.Message = resultActM.Message + "\r\n Caused by :: " + ex.Message;

        //    }
        //    finally
        //    {
        //        dbFactory.CloseConnection(objConn, objTrnx);
        //    }

        //    AuthenticationService.SetCurrentUserLogIn(usrM);
        //    return resultActM;

        //}

        public ActionResultM DoLogin(String UserID, UserInfoM usrM)
        {
            //logger.Info("...DoLogIn(String usrName<" + UserID + ">, String usrPwd)");

            ActionResultM resultActM = new ActionResultM();
            //UserM usrM = null;
            AuthenticationService.SetCurrentUserLogIn(null);

            AuthenticationDAO dao = new AuthenticationDAO();
            DBFactorySQL dbFactory = new DBFactorySQL();
            SqlConnection objConn = null;
            SqlTransaction objTrnx = null;

            try
            {
                objConn = dbFactory.GetDBConnection();
                //objTrnx = objConn.BeginTransaction();

                //resultActM = dao.DoLogIn(dbFactory, objConn, objTrnx, usrName, usrPwd);

                //if (resultActM.Status)
                //{
                //  dbFactory.CommitTransaction(objTrnx);

                usrM = dao.GetUserDetail(usrM);

                //}
                //else
                //{
                //  dbFactory.RollbackTransaction(objTrnx);
                //}
            }
            catch (Exception ex)
            {                
                resultActM.Code = "Error";                
                resultActM.Message = resultActM.Message + "\r\n Caused by :: " + ex.Message;
            }
            finally
            {
                dbFactory.CloseConnection(objConn, objTrnx);
            }

            AuthenticationService.SetCurrentUserLogIn(usrM);
            return resultActM;

        }
    }
}
