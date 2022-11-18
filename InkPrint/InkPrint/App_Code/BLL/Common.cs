using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Data.OleDb;
using System.Data.Odbc;
/// <summary>
/// Summary description for Common
/// </summary>

namespace InkPrint
{
   public class Common
{
    private SqlTransaction trans;
        //private SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["COFConnectionString"].ToString());
        private SqlConnection conn = new SqlConnection("Data Source = prdsvr.mektec.co.th; Initial Catalog = AUTODB; Persist Security Info = True; User ID = sa; Password = P@ssw0rd");
        public Common()
	    {
		    //
		    // TODO: Add constructor logic here
		    //
	    }

    #region DB Transaction
    public string ExecuteData(SqlCommand sqlCmd)
    {
        sqlCmd.Connection = conn;
        string s = sqlCmd.CommandText;
        sqlCmd.Transaction = trans;
        try
        {
            int rowEffect = sqlCmd.ExecuteNonQuery();
            return "";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }

    }

    //public string ExecuteDataCIM(SqlCommand sqlCmd)
    //{
    //    sqlCmd.Connection = conn2DDataBase;
    //    string s = sqlCmd.CommandText;
    //    sqlCmd.Transaction = trans;
    //    try
    //    {
    //        int rowEffect = sqlCmd.ExecuteNonQuery();
    //        return "";
    //    }
    //    catch (Exception ex)
    //    {
    //        return ex.Message;
    //    }

    //}

    public string ExecuteDataxx(SqlCommand sqlCmd, SqlConnection connect, SqlTransaction tensec)
    {
        sqlCmd.Connection = connect;
        string s = sqlCmd.CommandText;
        sqlCmd.Transaction = tensec;
        try
        {
            int rowEffect = sqlCmd.ExecuteNonQuery();
            return "";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }

    }

    public void OpenConnect()
    {
        if (conn.State == ConnectionState.Open) conn.Close();
        conn.Open();
    }

   

    //public void OpenConnectMFG()
    //{
    //    if (connMFG.State == ConnectionState.Open) connMFG.Close();
    //    connMFG.Open();
    //}

    public void BeginTrans()
    {
        OpenConnect();
        trans = conn.BeginTransaction();
    }

   

    public void CommitTrans()
    {
        trans.Commit();
        trans = null;
        conn.Close();
    }

    //public void OpenConnectCIM()
    //{
    //    if (conn2DDataBase.State == ConnectionState.Open) conn2DDataBase.Close();
    //    conn2DDataBase.Open();
    //}
    //public void BeginTransCim()
    //{
    //    OpenConnectCIM();
    //    trans = conn2DDataBase.BeginTransaction();
    //}
    //public void CommitTransCIM()
    //{
    //    trans.Commit();
    //    trans = null;
    //    conn2DDataBase.Close();
    //}
    //public void RollBackTransCIM()
    //{
    //    if (trans != null)
    //    {
    //        trans.Rollback();
    //        trans = null;
    //        conn2DDataBase.Close();
    //    }
    //}
    //public void closeConnectCIM()
    //{
    //    conn2DDataBase.Close();
    //}

    public void RollBackTrans()
    {
        if (trans != null)
        {
            trans.Rollback();
            trans = null;
            conn.Close();
        }
    }
    
    public void closeConnect()
    {
        conn.Close();
    }

    //public void closeConnectMFG()
    //{
    //    connMFG.Close();
    //}

    public DataTable ExecuteReader(SqlCommand sqlCmd)
    {
        DataTable dt = new DataTable();
        sqlCmd.Connection = conn;
        string s = sqlCmd.CommandText;

        SqlDataReader reader = sqlCmd.ExecuteReader();
        dt.Load(reader);
        return dt;
    }

    public DataTable ExecuteReaderxx(SqlCommand sqlCmd, SqlConnection connect)
    {
        DataTable dt = new DataTable();
        sqlCmd.Connection = connect;
        string s = sqlCmd.CommandText;

        SqlDataReader reader = sqlCmd.ExecuteReader();
        dt.Load(reader);
        return dt;
    }

    //public DataTable ExecuteReaderMFG(OdbcCommand sqlCmdMfg)
    //{
    //    DataTable dt = new DataTable();
    //    sqlCmdMfg.Connection = connMFG;
    //    string s = sqlCmdMfg.CommandText;

    //    OdbcDataReader reader = sqlCmdMfg.ExecuteReader();
    //    dt.Load(reader);
    //    return dt;
    //}

     #endregion
}
}




