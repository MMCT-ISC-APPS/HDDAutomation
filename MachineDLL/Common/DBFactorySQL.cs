using MachineDLL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace MachineDLL.Controller
{
    public class DBFactorySQL
    {
        public const String CONST_DB_RES_CODE_SUCCESS = "000";
        public const String CONST_DB_RES_CODE_SYS_ERROR = "SYS-100";
        //public const String dbCulture = "en-EN";
        //public const String dbDateFormat = "dd/MM/yyyy HH:mm:ss";

        //private static String strConnString = ConfigurationManager.AppSettings["DB_ConStr"];
        //private static String strConnString = "Data Source=prdsvr.mektec.co.th;Initial Catalog=DCS;User ID=sa;Password=P@ssw0rd;";
        private static String strConnString = "Data Source=mmctsg2d2;Initial Catalog=mprint2;User ID=hsm;Password=hsm;";
        private static String dbInstanceName = "";

        private SqlConnection dbConn;

        public void SetDBConnString(String dbConStr)
        {
            if (dbConStr != null && dbConStr != "")
            {
                DBFactorySQL.strConnString = dbConStr;
            }
        }

        public SqlConnection GetDBConnection()
        {
            if (DBFactorySQL.strConnString == null)
            {
                if (dbConn == null || dbConn.State == ConnectionState.Closed || dbConn.State == ConnectionState.Broken)
                {
                    String conString = strConnString;
                    //String conString = ConfigurationManager.AppSettings["QSS_ConStr"];
                    dbConn = new SqlConnection(conString);
                    dbConn.Open();
                }

            }
            else
            {
                if (dbConn == null || dbConn.State == ConnectionState.Closed || dbConn.State == ConnectionState.Broken)
                {
                    //String conString = ConfigurationManager.ConnectionStrings["DB_ConStr"].ConnectionString;
                    //String conString = ConfigurationManager.AppSettings["QSS_ConStr"];
                    dbConn = new SqlConnection(strConnString);
                    dbConn.Open();
                }

            }
            return dbConn;
        }

        public SqlTransaction BeginTransaction(SqlConnection objConn)
        {
            SqlTransaction trx = objConn.BeginTransaction(IsolationLevel.Unspecified);

            return trx;
        }

        public void CommitTransaction(SqlTransaction objTrnx)
        {
            try
            {
                objTrnx.Commit();
            }
            catch (Exception ex) { }
        }

        public void RollbackTransaction(SqlTransaction objTrnx)
        {
            try
            {
                objTrnx.Rollback();
            }
            catch (Exception ex) { }
        }

        public SqlParameter CreateParameterInput(String paramName, SqlDbType dataType, Object paramValue)
        {
            SqlParameter dbParam = new SqlParameter(paramName, dataType);
            dbParam.Direction = ParameterDirection.Input;
            dbParam.Value = paramValue;

            return dbParam;
        }

        public SqlParameter CreateParameterOutput(String paramName, SqlDbType dataType, int paramSize)
        {
            SqlParameter dbParam = new SqlParameter(paramName, dataType);

            //if (oraType != OracleType.Cursor)
            //{
            dbParam.Size = paramSize;
            //}
            dbParam.Direction = ParameterDirection.Output;

            return dbParam;
        }

        public SqlParameter[] CreateParameterStandardOutput()
        {
            SqlParameter[] sqlParamsOut = new SqlParameter[3];

            sqlParamsOut[0] = CreateParameterOutput("@o_RES_CODE", SqlDbType.VarChar, 50);
            sqlParamsOut[1] = CreateParameterOutput("@o_RES_MSG", SqlDbType.VarChar, 4000);
            sqlParamsOut[2] = CreateParameterOutput("@o_RES_DATA", SqlDbType.VarChar, 4000);

            return sqlParamsOut;
        }

        public void ExecuteNonQuerySQL(SqlConnection objConn, SqlTransaction objTrnx, String sqlStr, SqlParameter[] sqlParams)
        {
            SqlCommand objCmd = null;

            objCmd = objConn.CreateCommand();
            objCmd.CommandText = sqlStr;
            objCmd.CommandType = CommandType.Text;

            if (objTrnx != null)
            {
                objCmd.Transaction = objTrnx;
            }

            if (sqlParams != null && sqlParams.Length > 0)
            {
                for (int i = 0; i < sqlParams.Length; i++)
                {
                    objCmd.Parameters.Add(sqlParams[i]);
                }
            }

            objCmd.ExecuteNonQuery();
            CloseCommand(objCmd);

        }

        public DataSet ExecuteQuerySQL(SqlConnection objConn, String sqlStr, SqlParameter[] sqlParams)
        {
            SqlCommand objCmd = null;
            SqlDataAdapter objAdap = null;
            DataSet ds = new DataSet();

            objCmd = objConn.CreateCommand();
            objCmd.CommandText = sqlStr;
            objCmd.CommandType = CommandType.Text;

            if (sqlParams != null && sqlParams.Length > 0)
            {
                for (int i = 0; i < sqlParams.Length; i++)
                {
                    objCmd.Parameters.Add(sqlParams[i]);
                }
            }

            objAdap = new SqlDataAdapter(objCmd);
            objAdap.Fill(ds); //// populate data to the dataset

            CloseDataAdapter(objAdap);
            CloseCommand(objCmd);

            return ds;

        }

        public DataSet ExecuteQueryStoredProc(SqlConnection objConn, SqlTransaction objTrnx, String sqlStr, SqlParameter[] sqlParamsIn, SqlParameter[] sqlParamsOut)
        {
            SqlDataAdapter objAdap = null;
            DataSet ds = new DataSet();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandText = sqlStr;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.Clear();

            if (objTrnx != null)
            {
                objCmd.Transaction = objTrnx;
            }

            if (sqlParamsIn != null && sqlParamsIn.Length > 0)
            {
                for (int i = 0; i < sqlParamsIn.Length; i++)
                {
                    objCmd.Parameters.Add(sqlParamsIn[i]);
                }
            }

            if (sqlParamsOut != null && sqlParamsOut.Length > 0)
            {
                for (int i = 0; i < sqlParamsOut.Length; i++)
                {
                    objCmd.Parameters.Add(sqlParamsOut[i]);
                }
            }

            objAdap = new SqlDataAdapter(objCmd);
            objAdap.Fill(ds); //// populate data to the dataset

            CloseDataAdapter(objAdap);
            CloseCommand(objCmd);

            return ds;

        }

        public DataSet ExecuteQueryStoredProc(SqlConnection objConn, SqlTransaction objTrnx, String sqlStr, SqlParameter[] sqlParamsIn, SqlParameter[] sqlParamsOut, int CommandTimeOut)
        {
            SqlDataAdapter objAdap = null;
            DataSet ds = new DataSet();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandTimeout = CommandTimeOut;
            objCmd.CommandText = sqlStr;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.Clear();

            if (objTrnx != null)
            {
                objCmd.Transaction = objTrnx;
            }

            if (sqlParamsIn != null && sqlParamsIn.Length > 0)
            {
                for (int i = 0; i < sqlParamsIn.Length; i++)
                {
                    objCmd.Parameters.Add(sqlParamsIn[i]);
                }
            }

            if (sqlParamsOut != null && sqlParamsOut.Length > 0)
            {
                for (int i = 0; i < sqlParamsOut.Length; i++)
                {
                    objCmd.Parameters.Add(sqlParamsOut[i]);
                }
            }

            objAdap = new SqlDataAdapter(objCmd);
            objAdap.Fill(ds); //// populate data to the dataset

            CloseDataAdapter(objAdap);
            CloseCommand(objCmd);

            return ds;

        }
        public SqlParameter[] ExecuteNotQueryStoredProc(SqlConnection objConn, SqlTransaction objTrnx, String sqlStr, SqlParameter[] sqlParamsIn, SqlParameter[] sqlParamsOut)
        {

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandText = sqlStr;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.Clear();

            if (objTrnx != null)
            {
                objCmd.Transaction = objTrnx;
            }

            if (sqlParamsIn != null && sqlParamsIn.Length > 0)
            {
                for (int i = 0; i < sqlParamsIn.Length; i++)
                {
                    objCmd.Parameters.Add(sqlParamsIn[i]);
                }
            }

            if (sqlParamsOut != null && sqlParamsOut.Length > 0)
            {
                for (int i = 0; i < sqlParamsOut.Length; i++)
                {
                    objCmd.Parameters.Add(sqlParamsOut[i]);
                }
            }

            objCmd.ExecuteNonQuery();

            return sqlParamsOut;

        }

        public SqlParameter[] ExecuteNotQueryStoredProc(SqlConnection objConn, String sqlStr, SqlParameter[] sqlParamsIn, SqlParameter[] sqlParamsOut)
        {

            SqlCommand objCmd = objConn.CreateCommand();
            SqlTransaction objTrnx = null;
            SqlParameter[] result = ExecuteNotQueryStoredProc(objConn, objTrnx, sqlStr, sqlParamsIn, sqlParamsOut);
            CloseCommand(objCmd);

            return result;

        }

        public ActionResultM ExecuteNotQueryStoredProcStandard(SqlConnection objConn, SqlTransaction objTrnx, String sql, SqlParameter[] sqlParamsIn)
        {
            ActionResultM resultM = new ActionResultM();

            try
            {
                SqlParameter[] sqlParamsOut = this.CreateParameterStandardOutput();
                SqlParameter[] outParams = this.ExecuteNotQueryStoredProc(objConn, objTrnx, sql, sqlParamsIn, sqlParamsOut);

                resultM.Code = sqlParamsOut[0].Value.ToString();
                resultM.Message = sqlParamsOut[1].Value.ToString();
                resultM.ReturnObj = sqlParamsOut[2].Value.ToString();

                //if (sqlParamsOut[0].Value.ToString() == DBFactory.CONST_DB_RES_CODE_SUCCESS)
                //{
                //    result.Status = ActionResultDataM.CONST_STATUS_SUCCESS;
                //    result.Message = sqlParamsOut[1].Value.ToString();
                //    result.ReturnObject = sqlParamsOut[2].Value.ToString();
                //}
                //else
                //{
                //    result.Status = ActionResultDataM.CONST_STATUS_FAIL;
                //    result.Message = sqlParamsOut[1].Value.ToString();
                //    result.ReturnObject = sqlParamsOut[2].Value.ToString();
                //}

            }
            catch (Exception ex)
            {
                //result.Status = ActionResultDataM.CONST_STATUS_FAIL;
                //result.Message = ex.Message;
                resultM.Code = "Error";
                resultM.Message =   ex.Message;
                throw ex;
            }
            finally
            {

            }
            return resultM;
        }

        private void CloseDataReader(DbDataReader dtReader)
        {
            try
            {
                dtReader.Close();
                dtReader = null;
            }
            catch (Exception ex) { }
        }

        public void CloseCommand(SqlCommand objCmd)
        {
            try
            {
                objCmd.Dispose();
                objCmd = null;
            }
            catch (Exception ex) { }
        }

        public void CloseDataAdapter(SqlDataAdapter objAdap)
        {
            try
            {
                objAdap.Dispose();
                objAdap = null;
            }
            catch (Exception ex) { }
        }

        public void CloseDataTable(DataTable dataTbl)
        {
            try
            {
                dataTbl.Dispose();
                dataTbl = null;
            }
            catch (Exception ex) { }
        }

        public void CloseDataSet(DataSet dataSet)
        {
            try
            {
                dataSet.Dispose();
                dataSet = null;
            }
            catch (Exception ex) { }
        }

        public void CloseTransaction(SqlTransaction txn)
        {
            try
            {
                txn.Dispose();
                txn = null;
            }
            catch (Exception ex) { }
        }

        public void CloseConnection(SqlConnection objConn)
        {
            try
            {
                objConn.Close();
                objConn.Dispose();
                objConn = null;
            }
            catch (Exception ex) { }
        }

        public void CloseConnection(SqlConnection objConn, SqlTransaction txn)
        {
            CloseTransaction(txn);
            CloseConnection(objConn);
        }

        public void CloseConnection(DataSet dataSet, DataTable dataTbl)
        {
            try
            {
                CloseDataTable(dataTbl);
                CloseDataSet(dataSet);
            }
            catch (Exception ex) { }
        }

        public void CloseConnection(SqlConnection objConn, DataSet dataSet, DataTable dataTbl)
        {
            try
            {
                CloseDataTable(dataTbl);
                CloseDataSet(dataSet);
                CloseConnection(objConn);
            }
            catch (Exception ex) { }
        }

        public void CloseConnection(SqlConnection objConn, SqlTransaction txn, DataSet dataSet, DataTable dataTbl)
        {
            try
            {
                CloseDataTable(dataTbl);
                CloseDataSet(dataSet);
                CloseTransaction(txn);
                CloseConnection(objConn);
            }
            catch (Exception ex) { }
        }

        public DateTime ToDateTime(String value)
        {
            DateTime result = DateTime.MinValue;

            if (value != null && value != "")
            {
                //String dbDateFormat = SystemParamUtil.GetSystemParamValue(SystemParamUtil.PARAM_NAME.SYSTEM_DB_DATA_FORMAT_DATE);
                //result = DateTime.ParseExact(value, dbDateFormat, System.Globalization.CultureInfo.InvariantCulture);
                //result = DateTime.ParseExact(value, dbDateFormat, null);
            }
            return result;
        }

        public int ToInt(String value)
        {
            int result = 0;
            if (value != null && value != "")
            {
                result = int.Parse(value);
            }
            return result;
        }

        public Int16 ToInt16(String value)
        {
            Int16 result = 0;
            if (value != null && value != "")
            {
                result = Int16.Parse(value.Replace(",", ""));
            }
            return result;
        }

        public Int64 ToInt64(String value)
        {
            Int64 result = 0;
            if (value != null && value != "")
            {
                result = Int64.Parse(value.Replace(",", ""));
            }
            return result;
        }

        public Decimal ToDecimal(String value)
        {
            Decimal result = 0;
            if (value != null && value != "")
            {
                result = Decimal.Parse(value.Replace(",", ""));
            }
            return result;
        }

        public DateTime GetDBDateTime(DataRow dbDataRow, String fieldName)
        {
            return this.ToDateTime(dbDataRow[fieldName].ToString());
        }

        public Int64 GetDBInt64(DataRow dbDataRow, String fieldName)
        {
            return this.ToInt64(dbDataRow[fieldName].ToString());
        }

        public Decimal GetDBDecimal(DataRow dbDataRow, String fieldName)
        {
            return this.ToDecimal(dbDataRow[fieldName].ToString());
        }

        public Double GetDBDouble(DataRow dbDataRow, String fieldName)
        {
            return (Double)this.ToDecimal(dbDataRow[fieldName].ToString());
        }

        public String SaveString(String value)
        {
            String result = "";
            if (value != null && value != "")
            {
                result = value;
            }
            return result;
        }
     
    }
}
