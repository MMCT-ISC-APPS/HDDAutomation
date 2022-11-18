using MachineDLL.Controller;
using MachineDLL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineDLL.DAO
{
    class SystemMessageDAO
    {

        private DBFactorySQL dbFactory = new DBFactorySQL();

        public Dictionary<String, SystemMessageM> GetAllSysMessage(SqlConnection objConn, SqlTransaction objTrnx)
        {
            Dictionary<String, SystemMessageM> result = new Dictionary<String, SystemMessageM>(); // Hashtable<String, Hashtable<String, SysLookUpDataM>>

            DataSet ds = new DataSet();
            DataTable dataTbl = null;
            try
            {

                String sql = "dbo.sp00_UTIL_GET_SYS_MESSAGE_ALL";

                SqlParameter[] sqlParamsIn = null;
                SqlParameter[] sqlParamsOut = null;

                //sqlParamsOut[0] = dbFactory.CreateOracleParameterOutput("o_DATA_CUR", OracleType.Cursor, 0);

                ds = dbFactory.ExecuteQueryStoredProc(objConn, objTrnx, sql, sqlParamsIn, sqlParamsOut);
                dataTbl = ds.Tables[0]; //// Retrieve frist data set

                for (int i = 0; i < dataTbl.Rows.Count; i++)
                {
                    DataRow dataRow = dataTbl.Rows[i];

                    SystemMessageM msgM = new SystemMessageM();

                    msgM.MsgID = dbFactory.ToInt(dataRow["MSG_ID"].ToString());
                    msgM.MsgCode = dataRow["MSG_CODE"].ToString();
                    msgM.MsgModule = dataRow["MSG_MODULE"].ToString();
                    msgM.MsgSubModule = dataRow["MSG_SUB_MODULE"].ToString();
                    msgM.MsgTitle = dataRow["MSG_TITLE"].ToString();
                    msgM.MsgTH = dataRow["MSG_TH"].ToString();
                    msgM.MsgEN = dataRow["MSG_EN"].ToString();

                    result.Add(msgM.MsgCode, msgM);

                } // for(int i = 0; i < dataTbl.Rows.Count; i++)

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbFactory.CloseConnection(ds, dataTbl);
            }
            return result;
        }


    }
}
