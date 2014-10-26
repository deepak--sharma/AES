using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using AES.SolutionFramework;

namespace AES.DataFramework
{
    public class DataUtility
    {
        public static string ActivateDeactivateObject(string tableName, int? recordId, int? version, int? recordStatus, string modifiedBy)
        {
            string strActivateDeactivateObject = "SP_ACTIVATE_DEACTIVATE_OBJECT";
            List<SqlParameter> objParameterList = new List<SqlParameter>();
            objParameterList.Add(new SqlParameter("@TABLE_NAME", tableName));
            objParameterList.Add(new SqlParameter("@RECORD_ID", recordId));
            objParameterList.Add(new SqlParameter("@VERSION", version));
            objParameterList.Add(new SqlParameter("@RECORD_STATUS", recordStatus));
            objParameterList.Add(new SqlParameter("@MODIFIED_BY", modifiedBy));

            string returnValue = DBMANAGER.GetScalerValue(objParameterList, strActivateDeactivateObject, CommandType.StoredProcedure).ToString();
            return returnValue;
        }

        public static DataSet SelectRecordById(string tableName, int? recordId, int? version, string selectProc)
        {
            string strSelectRecordById = "SP_GET_RECORD_BY_ID";
            List<SqlParameter> objParameterList = new List<SqlParameter>();
            objParameterList.Add(new SqlParameter("@TABLE_NAME", tableName));
            objParameterList.Add(new SqlParameter("@RECORD_ID", recordId));
            objParameterList.Add(new SqlParameter("@VERSION", version));
            objParameterList.Add(new SqlParameter("@SELECT_PROC", selectProc));

            DataSet returnDs = DBMANAGER.GetDataSet(objParameterList, strSelectRecordById, CommandType.StoredProcedure);
            return returnDs;
        }

        public static DataTable UpdateDataColumnWithPrimaryKey(DataTable objTable, string columnName, int? value)
        {
            if (value != null)
            {
                foreach (DataRow objRow in objTable.Rows)
                {
                    if (objRow.RowState != DataRowState.Deleted)
                    {
                        objRow[columnName] = value;
                    }
                }
            }
            return objTable;
        }

        public static string GetQueryParameters(List<SqlParameter> objParameterList)
        {
            StringBuilder strParams = new StringBuilder("");

            foreach (SqlParameter objParams in objParameterList)
            {
                strParams.Append("\nParameterName: " + objParams.ParameterName + ", ParameterValue: " + objParams.Value);
            }

            return strParams.ToString();
        }

    }
}
