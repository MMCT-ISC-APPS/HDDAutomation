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
    class ListOfValueDAO
    {

        private DBFactorySQL dbFactory = new DBFactorySQL();

        public Dictionary<String, Dictionary<String, ListOfValueDataM>> GetAllLookUpData(SqlConnection objConn, SqlTransaction objTrnx)
        {
            Dictionary<String, Dictionary<String, ListOfValueDataM>> result = new Dictionary<String, Dictionary<String, ListOfValueDataM>>(); // Hashtable<String, Hashtable<String, SysLookUpDataM>>

            DataSet ds = new DataSet();
            DataTable dataTbl = null;
            String oFieldName = "";

            try
            {

                String sql = "dbo.sp00_UTIL_GET_FIELD_LIST_BOX_ALL";

                SqlParameter[] sqlParamsIn = null;
                SqlParameter[] sqlParamsOut = null;

                //sqlParamsOut[0] = dbFactory.CreateOracleParameterOutput("o_DATA_CUR", OracleType.Cursor, 0);

                ds = dbFactory.ExecuteQueryStoredProc(objConn, objTrnx, sql, sqlParamsIn, sqlParamsOut);
                dataTbl = ds.Tables[0]; //// Retrieve frist data set

                Dictionary<String, ListOfValueDataM> fieldHashSet = new Dictionary<String, ListOfValueDataM>();
                String lastFieldName = "";
                for (int i = 0; i < dataTbl.Rows.Count; i++)
                {
                    DataRow dataRow = dataTbl.Rows[i];

                    String nFieldName = dataRow["LB_FIELD_NO"].ToString();
                    if (nFieldName != oFieldName)
                    {
                        if (oFieldName != "")
                        {
                            result.Add(lastFieldName, fieldHashSet);
                            fieldHashSet = new Dictionary<String, ListOfValueDataM>();
                        }
                        oFieldName = nFieldName;
                    }

                    ListOfValueDataM lookupDataM = new ListOfValueDataM();
                    lookupDataM.FieldName = dataRow["LB_FIELD_NO"].ToString();
                    lookupDataM.DataValue = dataRow["LIST_BOX_VALUE"].ToString();
                    lookupDataM.DataDisplayTH = dataRow["LIST_BOX_DISPLAY_VALUE_TH"].ToString();
                    lookupDataM.DataDisplayEN = dataRow["LIST_BOX_DISPLAY_VALUE_EN"].ToString();
                    lookupDataM.Default = dataRow["IS_DEFAULT"].ToString();
                    lookupDataM.Display = dataRow["IS_DISPLAY"].ToString();
                    lookupDataM.Index = dbFactory.ToInt(dataRow["LIST_BOX_SEQ"].ToString());

                    fieldHashSet.Add(lookupDataM.DataValue, lookupDataM);
                    lastFieldName = lookupDataM.FieldName;

                } // for(int i = 0; i < dataTbl.Rows.Count; i++)

                result.Add(lastFieldName, fieldHashSet);
                fieldHashSet = new Dictionary<String, ListOfValueDataM>();

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
