using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using System.Threading;

namespace InkPrint
{
    class Model_Common_Data
    {
        Common common = new Common();

        public DataTable GetDateUser(string UserName)
        {
            DataTable dt = new DataTable();
            common.OpenConnect();

            StringBuilder sql = new StringBuilder();
            sql.Append("	SELECT [userlogin].username as UserLogin	");
            sql.Append("	      ,[userlogin].password as Password	");
            sql.Append("	      ,[userlogin].[line_code]	");
            sql.Append("	      ,line.line_Desc	");
            sql.Append("	      ,[userlogin].[process_code]	");
            sql.Append("	      ,process.Process_Desc	");
            sql.Append("	  FROM [cofdb].[dbo].[userlogin] 	");
            sql.Append("	  INNER JOIN [cofdb].[dbo].tb_LineMaster line ON [userlogin].[line_code] = line.line_code	");
            sql.Append("	  INNER JOIN [cofdb].[dbo].tb_ProcessMaster process ON [userlogin].[process_code] = process.Process_code	");
            sql.Append("	  WHERE 	");
            sql.Append("	line.line_Status = 'Active'	");
            sql.Append("	AND process.Process_Status = 'Active'	");
            sql.Append("	AND [userlogin].[username] = '" + UserName + "'	");

            SqlCommand sqlCmd = new SqlCommand(sql.ToString());
            dt = common.ExecuteReader(sqlCmd);
            common.closeConnect();

            return dt;

        }

        public DataTable GetDataTran(string process, string line)
        {
            DataTable dt = new DataTable();
            common.OpenConnect();

            StringBuilder sql = new StringBuilder();
            sql.Append("	SELECT td.[Tran_ID]	");
            sql.Append("	      ,td.[Mac_Code]	");
            sql.Append("	      ,td.[Die_Code]	");
            sql.Append("	      ,td.[Sort]	");
            sql.Append("	  FROM [cofdb].[dbo].[tb_TranLineDet] td	");
            sql.Append("	  INNER JOIN [cofdb].[dbo].[tb_TranLine] tl ON td.[Tran_ID] = tl.[Tran_ID]	");
            sql.Append("	  WHERE tl.[Tran_Status] = 'Active'	");
            sql.Append("	    AND td.[Process_code] = '" + process + "'	");
            sql.Append("	    AND td.[line_code] = '" + line + "'	");
            sql.Append("	    ORDER BY td.[Sort]	");

            SqlCommand sqlCmd = new SqlCommand(sql.ToString());
            dt = common.ExecuteReader(sqlCmd);
            common.closeConnect();

            return dt;

        }

        public DataTable GetDataProcess()
        {
            DataTable dt = new DataTable();
            common.OpenConnect();

            StringBuilder sql = new StringBuilder();
            sql.Append("    SELECT [Process_code] ");
            sql.Append("           ,[Process_Desc] ");
            sql.Append("           ,[Sort] ");
            sql.Append("      FROM [cofdb].[dbo].[tb_ProcessMaster]  ");
            sql.Append("    WHERE ");
            sql.Append("        [Process_Status] = 'Active' ");
            sql.Append(" UNION ");
            sql.Append("    SELECT ");
            sql.Append("   '' AS Process_code,  ");
            sql.Append("   'Select Item' AS Process_Desc,  ");
            sql.Append("   '0' AS Sort  ");
            sql.Append("   ORDER BY Sort  ");
            SqlCommand sqlCmd = new SqlCommand(sql.ToString());
            dt = common.ExecuteReader(sqlCmd);
            common.closeConnect();

            return dt;

        }

        public DataTable GetDataLine(string process)
        {
            DataTable dt = new DataTable();
            common.OpenConnect();

            StringBuilder sql = new StringBuilder();
            sql.Append("    SELECT [line_code] ,  [line_Desc]");
            sql.Append("      FROM [cofdb].[dbo].[tb_LineMaster]  ");
            sql.Append("    WHERE ");
            sql.Append("        [line_Status] = 'Active' ");
            if (process != "")
            {
                sql.Append("      AND  [Process_code] = '" + process + "' ");
            }

            sql.Append(" UNION ");
            sql.Append("    SELECT ");
            sql.Append("   '' AS line_code,  ");
            sql.Append("   'Select Item' AS line_Desc  ");
            SqlCommand sqlCmd = new SqlCommand(sql.ToString());
            dt = common.ExecuteReader(sqlCmd);
            common.closeConnect();

            return dt;

        }

        public DataTable GetDefaultConfig()
        {

            DataTable dt = new DataTable();
            common.OpenConnect();

            StringBuilder sql = new StringBuilder();
            sql.Append("	SELECT [Config_Code]	");
            sql.Append("	      ,[Max_Value]	");
            sql.Append("	      ,[Min_Value]	");
            sql.Append("	      ,[Process_code]	");
            sql.Append("	      ,[line_code]	");
            sql.Append("	      ,[Config_Type]	");
            sql.Append("	      ,[Config_Status]	");
            sql.Append("	  FROM [cofdb].[dbo].[tb_ConfigCOF]	");
            sql.Append("	  WHERE [Config_Status] = 'Active'	");

            SqlCommand sqlCmd = new SqlCommand(sql.ToString());
            dt = common.ExecuteReader(sqlCmd);
            common.closeConnect();

            return dt;

        }

        public string chkValidate_Digit(DataTable dtDefaultConfig, string Config_Code, string str_check)
        {
            string result = "NO";
            int Max_Value;
            int Min_Value;
            DataTable dt = dtDefaultConfig;

            if (dt.Rows.Count > 0)
            {
                DataRow[] result1 = dt.Select(" Config_Code = '" + Config_Code.ToString() + "'");

                if (result1.Length > 0)
                {
                    Max_Value = int.Parse(result1[0]["Max_Value"].ToString());
                    Min_Value = int.Parse(result1[0]["Min_Value"].ToString());

                    if (str_check.Length >= Min_Value & str_check.Length <= Max_Value)
                    {
                        result = "OK";
                    }
                }
            }

            return result;

        }
    }
}
