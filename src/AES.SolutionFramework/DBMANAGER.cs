using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml;
using System.Reflection;

namespace AES.SolutionFramework
{
    public enum ConnectionName
    {
        DefaultConnection, CustomConnection
    }

    public class DBMANAGER
    {

        #region Creating Database Objects

        internal static string GetConnectionString(ConnectionName objConnectionName)
        {
            if (objConnectionName == ConnectionName.DefaultConnection)
            {
                return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            }
            else
            {
                return ConfigurationManager.ConnectionStrings["CustomConnection"].ConnectionString;
            }

        }

        private static SqlConnection GetConnection(ConnectionName objConnectionName)
        {
            SqlConnection objConnection = new SqlConnection();
            objConnection.ConnectionString = GetConnectionString(objConnectionName);
            return objConnection;
        }

        private static SqlCommand GetCommand(SqlConnection objConnection, string strQuery, CommandType objType)
        {
            SqlCommand objCommand = new SqlCommand();
            objCommand.Connection = objConnection;
            objCommand.CommandText = strQuery;
            objCommand.CommandType = objType;
            return objCommand;
        }

        private static SqlCommand GetCommand(SqlConnection objConnection, string strQuery)
        {
            return GetCommand(objConnection, strQuery, CommandType.Text);
        }

        private static SqlDataAdapter GetDataAdapter(SqlCommand objCommand)
        {
            SqlDataAdapter objDataAdapter = new SqlDataAdapter(objCommand);
            return objDataAdapter;
        }

        #endregion

        #region Return DataReader Against a Select Query

        public static SqlDataReader GetDataReader(string strQuery)
        {
            List<SqlParameter> objParameterList = new List<SqlParameter>();
            return GetDataReader(objParameterList, strQuery, CommandType.Text, ConnectionName.DefaultConnection);
        }

        public static SqlDataReader GetDataReader(string strQuery, CommandType objType)
        {
            List<SqlParameter> objParameterList = new List<SqlParameter>();
            return GetDataReader(objParameterList, strQuery, objType, ConnectionName.DefaultConnection);
        }

        public static SqlDataReader GetDataReader(List<SqlParameter> objParameterList, string strQuery)
        {
            return GetDataReader(objParameterList, strQuery, CommandType.Text, ConnectionName.DefaultConnection);
        }

        public static SqlDataReader GetDataReader(List<SqlParameter> objParameterList, string strQuery, CommandType objType)
        {
            return GetDataReader(objParameterList, strQuery, objType, ConnectionName.DefaultConnection);
        }

        public static SqlDataReader GetDataReader(string strQuery, ConnectionName objConnectionName)
        {
            List<SqlParameter> objParameterList = new List<SqlParameter>();
            return GetDataReader(objParameterList, strQuery, CommandType.Text, objConnectionName);
        }

        public static SqlDataReader GetDataReader(string strQuery, CommandType objType, ConnectionName objConnectionName)
        {
            List<SqlParameter> objParameterList = new List<SqlParameter>();
            return GetDataReader(objParameterList, strQuery, objType, objConnectionName);
        }

        public static SqlDataReader GetDataReader(List<SqlParameter> objParameterList, string strQuery, ConnectionName objConnectionName)
        {
            return GetDataReader(objParameterList, strQuery, CommandType.Text, objConnectionName);
        }

        public static SqlDataReader GetDataReader(List<SqlParameter> objParameterList, string strQuery, CommandType objType, ConnectionName objConnectionName)
        {
            SqlConnection objConnection = null;
            SqlCommand objCommand = null;
            SqlDataReader objDataReader;

            objConnection = GetConnection(objConnectionName);
            objConnection.Open();
            using (objCommand = GetCommand(objConnection, strQuery, objType))
            {
                foreach (SqlParameter objParameter in objParameterList)
                {
                    if (objParameter.Value == null)
                        objParameter.Value = DBNull.Value;
                    objCommand.Parameters.Add(objParameter);
                }
                objDataReader = objCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            return objDataReader;
        }

        #endregion

        #region Return Dataset Against a select query

        public static DataSet GetDataSet(string strQuery)
        {
            List<SqlParameter> objParameterList = new List<SqlParameter>();
            return GetDataSet(objParameterList, strQuery, CommandType.Text, string.Empty, ConnectionName.DefaultConnection);
        }

        public static DataSet GetDataSet(string strQuery, string tableName)
        {
            List<SqlParameter> objParameterList = new List<SqlParameter>();
            return GetDataSet(objParameterList, strQuery, CommandType.Text, tableName, ConnectionName.DefaultConnection);
        }

        public static DataSet GetDataSet(string strQuery, CommandType objType)
        {
            List<SqlParameter> objParameterList = new List<SqlParameter>();
            return GetDataSet(objParameterList, strQuery, objType, string.Empty, ConnectionName.DefaultConnection);
        }

        public static DataSet GetDataSet(string strQuery, CommandType objType, string tableName)
        {
            List<SqlParameter> objParameterList = new List<SqlParameter>();
            return GetDataSet(objParameterList, strQuery, objType, tableName, ConnectionName.DefaultConnection);
        }

        public static DataSet GetDataSet(List<SqlParameter> objParameterList, string strQuery)
        {
            return GetDataSet(objParameterList, strQuery, CommandType.Text, string.Empty, ConnectionName.DefaultConnection);
        }

        public static DataSet GetDataSet(List<SqlParameter> objParameterList, string strQuery, string tableName)
        {
            return GetDataSet(objParameterList, strQuery, CommandType.Text, tableName, ConnectionName.DefaultConnection);
        }

        public static DataSet GetDataSet(List<SqlParameter> objParameterList, string strQuery, CommandType objType)
        {
            return GetDataSet(objParameterList, strQuery, objType, string.Empty, ConnectionName.DefaultConnection);
        }

        public static DataSet GetDataSet(List<SqlParameter> objParameterList, string strQuery, CommandType objType, string tableName)
        {
            return GetDataSet(objParameterList, strQuery, objType, tableName, ConnectionName.DefaultConnection);
        }

        public static DataSet GetDataSet(string strQuery, ConnectionName objConnectionName)
        {
            List<SqlParameter> objParameterList = new List<SqlParameter>();
            return GetDataSet(objParameterList, strQuery, CommandType.Text, string.Empty, objConnectionName);
        }

        public static DataSet GetDataSet(string strQuery, string tableName, ConnectionName objConnectionName)
        {
            List<SqlParameter> objParameterList = new List<SqlParameter>();
            return GetDataSet(objParameterList, strQuery, CommandType.Text, tableName, objConnectionName);
        }

        public static DataSet GetDataSet(string strQuery, CommandType objType, ConnectionName objConnectionName)
        {
            List<SqlParameter> objParameterList = new List<SqlParameter>();
            return GetDataSet(objParameterList, strQuery, objType, string.Empty, objConnectionName);
        }

        public static DataSet GetDataSet(string strQuery, CommandType objType, string tableName, ConnectionName objConnectionName)
        {
            List<SqlParameter> objParameterList = new List<SqlParameter>();
            return GetDataSet(objParameterList, strQuery, objType, tableName, objConnectionName);
        }

        public static DataSet GetDataSet(List<SqlParameter> objParameterList, string strQuery, ConnectionName objConnectionName)
        {
            return GetDataSet(objParameterList, strQuery, CommandType.Text, string.Empty, objConnectionName);
        }

        public static DataSet GetDataSet(List<SqlParameter> objParameterList, string strQuery, string tableName, ConnectionName objConnectionName)
        {
            return GetDataSet(objParameterList, strQuery, CommandType.Text, tableName, objConnectionName);
        }

        public static DataSet GetDataSet(List<SqlParameter> objParameterList, string strQuery, CommandType objType, ConnectionName objConnectionName)
        {
            return GetDataSet(objParameterList, strQuery, objType, string.Empty, objConnectionName);
        }

        public static DataSet GetDataSet(List<SqlParameter> objParameterList, string strQuery, CommandType objType, string tableName, ConnectionName objConnectionName)
        {
            SqlCommand objCommand = null;
            DataSet objDataSet = null;
            SqlDataAdapter objDataAdapter = null;

            using (objCommand = GetCommand(GetConnection(objConnectionName), strQuery, objType))
            {
                foreach (SqlParameter objParameter in objParameterList)
                {
                    if (objParameter.Value == null)
                        objParameter.Value = DBNull.Value;
                    objCommand.Parameters.Add(objParameter);
                }

                objDataAdapter = GetDataAdapter(objCommand);
                objDataSet = new DataSet();
                if (tableName.Equals(string.Empty))
                {
                    objDataAdapter.Fill(objDataSet);
                }
                else
                {
                    objDataAdapter.Fill(objDataSet, tableName);
                }
            }
            return objDataSet;
        }

        #endregion

        #region Return Scaler value against a query

        public static object GetScalerValue(string strQuery)
        {
            List<SqlParameter> objParameterList = new List<SqlParameter>();
            return GetScalerValue(objParameterList, strQuery, CommandType.Text, ConnectionName.DefaultConnection);
        }

        public static object GetScalerValue(string strQuery, CommandType objType)
        {
            List<SqlParameter> objParameterList = new List<SqlParameter>();
            return GetScalerValue(objParameterList, strQuery, objType, ConnectionName.DefaultConnection);
        }

        public static object GetScalerValue(List<SqlParameter> objParameterList, string strQuery)
        {
            return GetScalerValue(objParameterList, strQuery, CommandType.Text, ConnectionName.DefaultConnection);
        }

        public static object GetScalerValue(List<SqlParameter> objParameterList, string strQuery, CommandType objType)
        {
            return GetScalerValue(objParameterList, strQuery, objType, ConnectionName.DefaultConnection);
        }

        public static object GetScalerValue(string strQuery, ConnectionName objConnectionName)
        {
            List<SqlParameter> objParameterList = new List<SqlParameter>();
            return GetScalerValue(objParameterList, strQuery, CommandType.Text, objConnectionName);
        }

        public static object GetScalerValue(string strQuery, CommandType objType, ConnectionName objConnectionName)
        {
            List<SqlParameter> objParameterList = new List<SqlParameter>();
            return GetScalerValue(objParameterList, strQuery, objType, objConnectionName);
        }

        public static object GetScalerValue(List<SqlParameter> objParameterList, string strQuery, ConnectionName objConnectionName)
        {
            return GetScalerValue(objParameterList, strQuery, CommandType.Text, objConnectionName);
        }

        public static object GetScalerValue(List<SqlParameter> objParameterList, string strQuery, CommandType objType, ConnectionName objConnectionName)
        {
            SqlConnection objConnection = null;
            SqlCommand objCommand = null;
            object objValue = null;

            using (objConnection = GetConnection(objConnectionName))
            {
                objConnection.Open();
                using (objCommand = GetCommand(objConnection, strQuery, objType))
                {
                    foreach (SqlParameter objParameter in objParameterList)
                    {
                        if (objParameter.Value == null)
                            objParameter.Value = DBNull.Value;
                        objCommand.Parameters.Add(objParameter);
                    }

                    objValue = objCommand.ExecuteScalar();
                }
                return objValue;
            }
        }

        #endregion

        #region Execute a query against a database

        public static int ExecuteQuery(string strQuery)
        {
            List<SqlParameter> objParameterList = new List<SqlParameter>();
            return ExecuteQuery(objParameterList, strQuery, CommandType.Text, ConnectionName.DefaultConnection);
        }

        public static int ExecuteQuery(string strQuery, CommandType objType)
        {
            List<SqlParameter> objParameterList = new List<SqlParameter>();
            return ExecuteQuery(objParameterList, strQuery, objType, ConnectionName.DefaultConnection);
        }

        public static int ExecuteQuery(List<SqlParameter> objParameterList, string strQuery)
        {
            return ExecuteQuery(objParameterList, strQuery, CommandType.Text, ConnectionName.DefaultConnection);
        }

        public static int ExecuteQuery(List<SqlParameter> objParameterList, string strQuery, CommandType objType)
        {
            return ExecuteQuery(objParameterList, strQuery, objType, ConnectionName.DefaultConnection);
        }

        public static int ExecuteQuery(string strQuery, ConnectionName objConnectionName)
        {
            List<SqlParameter> objParameterList = new List<SqlParameter>();
            return ExecuteQuery(objParameterList, strQuery, CommandType.Text, objConnectionName);
        }

        public static int ExecuteQuery(string strQuery, CommandType objType, ConnectionName objConnectionName)
        {
            List<SqlParameter> objParameterList = new List<SqlParameter>();
            return ExecuteQuery(objParameterList, strQuery, objType, objConnectionName);
        }

        public static int ExecuteQuery(List<SqlParameter> objParameterList, string strQuery, ConnectionName objConnectionName)
        {
            return ExecuteQuery(objParameterList, strQuery, CommandType.Text, objConnectionName);
        }

        public static int ExecuteQuery(List<SqlParameter> objParameterList, string strQuery, CommandType objType, ConnectionName objConnectionName)
        {
            SqlConnection objConnection = null;
            SqlCommand objCommand = null;
            int rowAffected = 0;

            using (objConnection = GetConnection(objConnectionName))
            {
                objConnection.Open();
                using (objCommand = GetCommand(objConnection, strQuery, objType))
                {
                    foreach (SqlParameter objParameter in objParameterList)
                    {
                        if (objParameter.Value == null)
                            objParameter.Value = DBNull.Value;
                        objCommand.Parameters.Add(objParameter);
                    }
                    rowAffected = objCommand.ExecuteNonQuery();
                }
                return rowAffected;
            }
        }

        public static int ExecuteDataSet(DataSet objDataSet, string strSelectQuery, CommandType objType)
        {
            return ExecuteDataSet(new  List<SqlParameter>(), objDataSet, strSelectQuery, objType, ConnectionName.DefaultConnection);
        }

        public static int ExecuteDataSet(List<SqlParameter> objParameterList, DataSet objDataSet, string strSelectQuery, CommandType objType)
        {
            return ExecuteDataSet(objParameterList, objDataSet, strSelectQuery, objType, ConnectionName.DefaultConnection);
        }

        public static int ExecuteDataSet(List<SqlParameter> objParameterList, DataSet objDataSet, string strSelectQuery, CommandType objType, ConnectionName objConnectionName)
        {
            SqlConnection objConnection = null;
            SqlCommand objCommand = null;
            SqlDataAdapter objDataAdapter = null;
            SqlCommandBuilder objCommandBuilder = null;
            int rowAffected = 0;

            using (objConnection = GetConnection(objConnectionName))
            {
                objConnection.Open();
                using (objCommand = GetCommand(objConnection, strSelectQuery, objType))
                {
                    foreach (SqlParameter objParameter in objParameterList)
                    {
                        if (objParameter.Value == null)
                            objParameter.Value = DBNull.Value;
                        objCommand.Parameters.Add(objParameter);
                    }

                    objDataAdapter = GetDataAdapter(objCommand);
                    objCommandBuilder = new SqlCommandBuilder(objDataAdapter);

                    rowAffected = objDataAdapter.Update(objDataSet);
                }
                return rowAffected;
            }
        }


        #endregion

        #region Load a List of Object

        public static List<T> LoadObjectList<T>(string strQuery) where T : new()
        {
            List<SqlParameter> objParameterList = new List<SqlParameter>();

            return LoadObjectList<T>(objParameterList, strQuery, CommandType.Text, ConnectionName.DefaultConnection);
        }

        public static List<T> LoadObjectList<T>(string strQuery, CommandType objType) where T : new()
        {
            List<SqlParameter> objParameterList = new List<SqlParameter>();
            return LoadObjectList<T>(objParameterList, strQuery, objType, ConnectionName.DefaultConnection);
        }

        public static List<T> LoadObjectList<T>(List<SqlParameter> objParameterList, string strQuery) where T : new()
        {
            return LoadObjectList<T>(objParameterList, strQuery, CommandType.Text, ConnectionName.DefaultConnection);
        }

        public static List<T> LoadObjectList<T>(List<SqlParameter> objParameterList, string strQuery, CommandType objType) where T : new()
        {
            return LoadObjectList<T>(objParameterList, strQuery, objType, ConnectionName.DefaultConnection);
        }

        public static List<T> LoadObjectList<T>(string strQuery, ConnectionName objConnectionName) where T : new()
        {
            List<SqlParameter> objParameterList = new List<SqlParameter>();
            return LoadObjectList<T>(objParameterList, strQuery, CommandType.Text, objConnectionName);
        }

        public static List<T> LoadObjectList<T>(string strQuery, CommandType objType, ConnectionName objConnectionName) where T : new()
        {
            List<SqlParameter> objParameterList = new List<SqlParameter>();
            return LoadObjectList<T>(objParameterList, strQuery, objType, objConnectionName);
        }

        public static List<T> LoadObjectList<T>(List<SqlParameter> objParameterList, string strQuery, ConnectionName objConnectionName) where T : new()
        {
            return LoadObjectList<T>(objParameterList, strQuery, CommandType.Text, objConnectionName);
        }

        public static List<T> LoadObjectList<T>(List<SqlParameter> objParameterList, string strQuery, CommandType objType, ConnectionName objConnectionName) where T : new()
        {
            List<T> objList = new List<T>();
            SqlDataReader objDataReader = null;
            T obj, addObject;
            try
            {
                using (objDataReader = GetDataReader(objParameterList, strQuery, objType, objConnectionName))
                {
                    while (objDataReader.Read())
                    {
                        addObject = new T();
                        foreach (PropertyInfo objProInfo in addObject.GetType().GetProperties())
                        {
                            foreach (Attribute objAttribute in objProInfo.GetCustomAttributes(false))
                            {
                                if (objDataReader[((DataMappingAttribute)objAttribute).DataFieldName].ToString().Equals(""))
                                {
                                    objProInfo.SetValue(addObject, null, null);
                                }
                                else
                                {
                                    objProInfo.SetValue(addObject, objDataReader[((DataMappingAttribute)objAttribute).DataFieldName], null);
                                }
                            }
                        }

                        objList.Add(addObject);
                    }

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return objList;
        }

        #endregion

    }
}
