using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace AES.SolutionFramework
{
    public class DBUtility
    {
        #region Getting Next Id from Datbase table on a integer column

        public static int GetNextId(string queryString)
        {
            int maxId = 0;
            object maxValue = GetIdValue(queryString);

            if (maxValue == DBNull.Value)
            {
                maxId = 1;
                return maxId;
            }

            if (GeneralUtility.IsInteger(maxValue.ToString()))
            {

                maxId = int.Parse(maxValue.ToString());
                maxId++;
                return maxId;
            }
            else
            {
                throw (new Exception("The Column Type is not valObject. Required Integer"));
            }
        }

        public static int GetNextId(string ColumnName, string TableName)
        {
            int maxId = 0;
            string queryString = "SELECT MAX(" + ColumnName + ") FROM " + TableName;
            object maxValue = GetIdValue(queryString);

            if (maxValue == DBNull.Value)
            {
                maxId = 1;
                return maxId;
            }

            if (GeneralUtility.IsInteger(maxValue.ToString()))
            {

                maxId = int.Parse(maxValue.ToString());
                maxId++;
                return maxId;
            }
            else
            {
                throw (new Exception("The Column Type is not valObject. Required Integer"));
            }
        }

        public static int GetNextId(string queryString, ConnectionName objConnectioName)
        {
            int maxId = 0;
            object maxValue = GetIdValue(queryString, objConnectioName);

            if (maxValue == DBNull.Value)
            {
                maxId = 1;
                return maxId;
            }

            if (GeneralUtility.IsInteger(maxValue.ToString()))
            {

                maxId = int.Parse(maxValue.ToString());
                maxId++;
                return maxId;
            }
            else
            {
                throw (new Exception("The Column Type is not valObject. Required Integer"));
            }
        }

        public static int GetNextId(string ColumnName, string TableName, ConnectionName objConnectioName)
        {
            int maxId = 0;
            string queryString = "SELECT MAX(" + ColumnName + ") FROM " + TableName;
            object maxValue = GetIdValue(queryString, objConnectioName);

            if (maxValue == DBNull.Value)
            {
                maxId = 1;
                return maxId;
            }

            if (GeneralUtility.IsInteger(maxValue.ToString()))
            {

                maxId = int.Parse(maxValue.ToString());
                maxId++;
                return maxId;
            }
            else
            {
                throw (new Exception("The Column Type is not valObject. Required Integer"));
            }

        }

        private static object GetIdValue(string strQuery)
        {
            object objValue = DBMANAGER.GetScalerValue(strQuery);
            return objValue;
        }

        private static object GetIdValue(string strQuery, ConnectionName objConnectioName)
        {
            object objValue = DBMANAGER.GetScalerValue(strQuery);
            return objValue;
        }

        #endregion

        #region Bulck Copy [Insert records from DataTable to Database Table ]

        public static void BulckCopy(string destinationTableName, DataTable objTable)
        {
            using (SqlBulkCopy copyToDelta = new SqlBulkCopy(DBMANAGER.GetConnectionString(ConnectionName.DefaultConnection)))
            {
                copyToDelta.DestinationTableName = destinationTableName;

                copyToDelta.WriteToServer(objTable);
            }

        }

        public static void BulckCopy(string destinationTableName, DataTable objTable, ConnectionName objConnectionName)
        {
            using (SqlBulkCopy copyToDelta = new SqlBulkCopy(DBMANAGER.GetConnectionString(objConnectionName)))
            {
                copyToDelta.DestinationTableName = destinationTableName;

                copyToDelta.WriteToServer(objTable);
            }

        }

        #endregion
    }
}
