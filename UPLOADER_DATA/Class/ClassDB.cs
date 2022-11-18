using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.OracleClient;
using System.Collections.Generic;
using System.Web;
using System.Net.NetworkInformation;

public class ClassDB
{

    public string ErrorMsg { get; set; }

    public string TSql { get; set; }

    public string param_Approval { get; set; }

    public string param_status { get; set; }

    public string param_reason { get; set; }

    public string param_Status { get; set; }

    public string param_SEGMENT1 { get; set; }

    public DataTable GetDataSql(String Str)
    {
        DataTable Dt = new DataTable();
        try
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = Str;

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = TSql;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        da.Fill(Dt);
                    }
                    conn.Close();
                    conn.Dispose();
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

        return Dt;

    }

    public int UpdateDataSql(String Str)
    {
        int _return = 0;
        using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection())
        {
            conn.ConnectionString = Str;
            try
            {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                {
                    cmd.CommandText = TSql;
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    _return = 1;
                }
            }
            catch (SqlException ex)
            {
                ErrorMsg = ex.Message.ToString();
                _return = 0;
            }
        }
        return _return;
    }

    public Boolean StatusServer(String Str)
    {

        using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection())
        {
            conn.ConnectionString = Str;
            try
            {
                conn.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //return true;
    }

    public DataTable GetDataOra()
    {
        DataTable Dt = new DataTable();

        using (OracleConnection conn = new OracleConnection())
        {
            conn.ConnectionString = "User Id=apps;Password=apps;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.234.40)(PORT=1530))(CONNECT_DATA=(SID=prod)));";
            using (OracleCommand cmd = new OracleCommand())
            {
                cmd.CommandText = TSql;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                conn.Open();
                using (OracleDataAdapter da = new OracleDataAdapter())
                {
                    da.SelectCommand = cmd;
                    da.Fill(Dt);
                }
                conn.Close();
                conn.Dispose();
            }
        }
        return Dt;
    }
}