using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Reflection;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
    public class BaseClassObject
    {
        #region Variable Declaration
        private string objectNamespace = "AES.ObjectFramework";
        private int rowId;
        private int tableId;
        #endregion

        #region Costructor Definition....
        public BaseClassObject()
        {
            //Costructor Definition....
        }
        #endregion

        #region Fields Name ...
        private int? _version;
        private string _createdBy;
        private DateTime? _createdOn;
        private string _modifiedBy;
        private DateTime? _modifiedOn;
        private int? _recordStatus;
        private bool? _isRecordChanged;
        private int? _dbOperationStatus;
        private string _dbErrorMessage;
        private DataSet _objectDataSet;
        private string _whereCondition;
        private int? _parentId;
        private int? _parentVersion;        
        #endregion

        #region Object Properties ...       
        public int? Version
        {
            get { return _version; }
            set { _version = value; }
        }
        public string CreatedBy
        {
            get { return _createdBy; }
            set { _createdBy = value; }
        }
        public DateTime? CreatedOn
        {
            get { return _createdOn; }
            set { _createdOn = value; }
        }
        public string ModifiedBy
        {
            get { return _modifiedBy; }
            set { _modifiedBy = value; }
        }
        public DateTime? ModifiedOn
        {
            get { return _modifiedOn; }
            set { _modifiedOn = value; }
        }
        public int? RecordStatus
        {
            get { return _recordStatus; }
            set { _recordStatus = value; }
        }
        public bool? IsRecordChanged
        {
            get { return _isRecordChanged; }
            set { _isRecordChanged = value; }
        }
        public int? DbOperationStatus
        {
            get { return _dbOperationStatus; }
            set { _dbOperationStatus = value; }
        }
        public string DbErrorMessage
        {
            get { return _dbErrorMessage; }
            set { _dbErrorMessage = value; }
        }
        public DataSet ObjectDataSet
        {
            get { return _objectDataSet; }
            set { _objectDataSet = value; }
        }
        public string WhereCondition
        {
            get { return _whereCondition; }
            set { _whereCondition = value; }
        }
        public int? ParentId
        {
            get { return _parentId; }
            set { _parentId = value; }
        }
        public int? ParentVersion
        {
            get { return _parentVersion; }
            set { _parentVersion = value; }
        }
        public string DataHolder
        {
            get;set;            
        }
        #endregion

        #region To convert a dataset(Single Row) to an object
        public virtual void ConvertToObjectFromDataset(int tableIndex)
        {
            if (this.ObjectDataSet.Tables[tableIndex].Rows.Count == 1)
            {
                tableId = tableIndex;
                rowId = 0;
                foreach (PropertyInfo objProInfo in this.GetType().GetProperties())
                {
                    AssignValueToProperty(this, objProInfo);
                }
            }
            else
            {
                throw new Exception("Too many rows or no row exist in DataTable. Opeartion failed while coverting Dataset to object");
            }
        }

        private void AssignValueToProperty(object objAssignValue, PropertyInfo objProInfo)
        {
            if (objProInfo.PropertyType.FullName.Contains(objectNamespace))
            {
                object innerPropertyObject = objProInfo.PropertyType.GetConstructor(new Type[] { }).Invoke(new object[] { });

                foreach (PropertyInfo objInnerProInfo in objProInfo.PropertyType.GetProperties())
                {
                    foreach (Attribute objAttribute in objInnerProInfo.GetCustomAttributes(false))
                    {
                        if (((DataMappingAttribute)objAttribute).PrimaryKey)
                        {
                            if (objProInfo.GetCustomAttributes(false).Length > 0 &&
                                this.ObjectDataSet.Tables[tableId].Rows[rowId][((DataMappingAttribute)objProInfo.GetCustomAttributes(false)[0]).DataFieldName] != DBNull.Value)
                            {
                                objInnerProInfo.SetValue(innerPropertyObject, this.ObjectDataSet.Tables[tableId].Rows[rowId]
                                    [((DataMappingAttribute)objProInfo.GetCustomAttributes(false)[0]).DataFieldName], null);
                            }
                        }
                    }
                }

                objProInfo.SetValue(objAssignValue, innerPropertyObject, null);
            }
            else
            {
                foreach (Attribute objAttribute in objProInfo.GetCustomAttributes(false))
                {
                    if (this.ObjectDataSet.Tables[tableId].Columns.Contains(((DataMappingAttribute)objAttribute).DataFieldName))
                    {
                        if (this.ObjectDataSet.Tables[tableId].Rows[rowId][((DataMappingAttribute)objAttribute).DataFieldName] != DBNull.Value)
                        {
                            objProInfo.SetValue(objAssignValue, this.ObjectDataSet.Tables[tableId].Rows[rowId][((DataMappingAttribute)objAttribute).DataFieldName], null);
                        }
                    }
                }
            }
        }

        #endregion

        #region Add a single object instance to DataTable
        public virtual DataTable AddObjectToTable(DataTable objTable)
        {
            DataRow objRow = objTable.NewRow();

            foreach (PropertyInfo objProInfo in this.GetType().GetProperties())
            {
                if (objProInfo.PropertyType.FullName.Contains(objectNamespace))
                {
                    object innerPropertyObject = objProInfo.GetValue(this, null);

                    if (innerPropertyObject == null)
                    { continue; }

                    foreach (PropertyInfo objInnerProInfo in innerPropertyObject.GetType().GetProperties())
                    {
                        foreach (Attribute objAttribute in objInnerProInfo.GetCustomAttributes(false))
                        {
                            if (objTable.Columns.Contains(((DataMappingAttribute)objProInfo.GetCustomAttributes(false)[0]).DataFieldName))
                            {
                                if (objInnerProInfo.GetValue(innerPropertyObject, null) != null
                                    && !objInnerProInfo.PropertyType.FullName.Contains(objectNamespace))
                                {
                                    objRow[(((DataMappingAttribute)objProInfo.GetCustomAttributes(false)[0]).DataFieldName)]
                                        = objInnerProInfo.GetValue(innerPropertyObject, null);
                                }
                            }
                        }
                    }
                }
                else
                {
                    foreach (Attribute objAttribute in objProInfo.GetCustomAttributes(false))
                    {
                        if (objTable.Columns.Contains(((DataMappingAttribute)objAttribute).DataFieldName))
                        {

                            if (objProInfo.GetValue(this, null) != null)
                            {
                                objRow[(((DataMappingAttribute)objAttribute).DataFieldName)] = objProInfo.GetValue(this, null);
                            }
                        }
                    }
                }
            }
            objTable.Rows.Add(objRow);
            return objTable;
        }
        #endregion

        #region Update a single row of DataTable from Object
        public virtual DataTable UpdateTableFromObject(DataTable objTable, int dataRowIndex)
        {
            DataRow objRow = objTable.Rows[dataRowIndex];

            foreach (PropertyInfo objProInfo in this.GetType().GetProperties())
            {
                if (objProInfo.PropertyType.FullName.Contains(objectNamespace))
                {
                    object innerPropertyObject = objProInfo.GetValue(this, null);
                    if (innerPropertyObject == null)
                    { continue; }
                    foreach (PropertyInfo objInnerProInfo in innerPropertyObject.GetType().GetProperties())
                    {
                        foreach (Attribute objAttribute in objInnerProInfo.GetCustomAttributes(false))
                        {
                            if (objTable.Columns.Contains(((DataMappingAttribute)objProInfo.GetCustomAttributes(false)[0]).DataFieldName))
                            {
                                if (objInnerProInfo.GetValue(innerPropertyObject, null) != null
                                    && !objInnerProInfo.PropertyType.FullName.Contains(objectNamespace))
                                {
                                    objRow[(((DataMappingAttribute)objProInfo.GetCustomAttributes(false)[0]).DataFieldName)]
                                        = objInnerProInfo.GetValue(innerPropertyObject, null);
                                }
                            }
                        }
                    }
                }
                else
                {
                    foreach (Attribute objAttribute in objProInfo.GetCustomAttributes(false))
                    {
                        if (objTable.Columns.Contains(((DataMappingAttribute)objAttribute).DataFieldName))
                        {

                            if (objProInfo.GetValue(this, null) != null)
                            {
                                objRow[(((DataMappingAttribute)objAttribute).DataFieldName)] = objProInfo.GetValue(this, null);
                            }
                        }
                    }
                }
            }
            return objTable;
        }
        #endregion

        #region To convert a Data Row to an object
        public virtual void ConvertToObjectFromDataRow(DataTable objTable, int dataRowIndex)
        {
            DataRow objRow = objTable.Rows[dataRowIndex];

            foreach (PropertyInfo objProInfo in this.GetType().GetProperties())
            {
                if (objProInfo.PropertyType.FullName.Contains(objectNamespace))
                {
                    object innerPropertyObject = objProInfo.PropertyType.GetConstructor(new Type[] { }).Invoke(new object[] { });

                    foreach (PropertyInfo objInnerProInfo in objProInfo.PropertyType.GetProperties())
                    {
                        foreach (Attribute objAttribute in objInnerProInfo.GetCustomAttributes(false))
                        {
                            if (((DataMappingAttribute)objAttribute).PrimaryKey &&
                               objTable.Rows[dataRowIndex][((DataMappingAttribute)objProInfo.GetCustomAttributes(false)[0]).DataFieldName] != DBNull.Value)
                            {
                                objInnerProInfo.SetValue(innerPropertyObject,
                                    objTable.Rows[dataRowIndex][((DataMappingAttribute)objProInfo.GetCustomAttributes(false)[0]).DataFieldName], null);
                            }
                        }
                    }

                    objProInfo.SetValue(this, innerPropertyObject, null);
                }
                else
                {
                    foreach (Attribute objAttribute in objProInfo.GetCustomAttributes(false))
                    {
                        if (objTable.Columns.Contains(((DataMappingAttribute)objAttribute).DataFieldName))
                        {
                            if (objTable.Rows[dataRowIndex][((DataMappingAttribute)objAttribute).DataFieldName] != DBNull.Value)
                            {
                                objProInfo.SetValue(this, objTable.Rows[dataRowIndex][((DataMappingAttribute)objAttribute).DataFieldName], null);
                            }
                        }
                    }
                }
            }
        }
        #endregion
    }
}
