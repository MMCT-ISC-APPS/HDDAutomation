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
    class SystemParamDAO
    {

        private DBFactorySQL dbFactory = new DBFactorySQL();

        public Dictionary<String, SystemParamM> GetAllSystemParam(SqlConnection objConn, SqlTransaction objTrnx)
        {
            Dictionary<String, SystemParamM> result = new Dictionary<String, SystemParamM>(); // Hashtable<String, Hashtable<String, SysLookUpDataM>>

            DataSet ds = new DataSet();
            DataTable dataTbl = null;
            try
            {

                String sql = "dbo.sp00_UTIL_GET_SYS_PARAMS_ALL";

                SqlParameter[] sqlParamsIn = null;
                SqlParameter[] sqlParamsOut = null;

                //sqlParamsOut[0] = dbFactory.CreateOracleParameterOutput("o_DATA_CUR", OracleType.Cursor, 0);

                ds = dbFactory.ExecuteQueryStoredProc(objConn, objTrnx, sql, sqlParamsIn, sqlParamsOut);
                dataTbl = ds.Tables[0]; //// Retrieve frist data set

                for (int i = 0; i < dataTbl.Rows.Count; i++)
                {
                    DataRow dataRow = dataTbl.Rows[i];

                    SystemParamM paramM = new SystemParamM();
                    paramM.ParamID = dbFactory.ToInt(dataRow["PARAM_ID"].ToString());
                    paramM.ParamName = dataRow["PARAM_NAME"].ToString();
                    paramM.ParamValue = dataRow["PARAM_VALUE"].ToString();
                    paramM.ParamDesc = dataRow["DESCRIPTION"].ToString();
                    paramM.Enditable = dataRow["EDITABLE"].ToString();

                    result.Add(paramM.ParamName, paramM);

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
