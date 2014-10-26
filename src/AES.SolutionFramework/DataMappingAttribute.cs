using System;
using System.Collections.Generic;
using System.Text;

namespace AES.SolutionFramework
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class DataMappingAttribute : System.Attribute
    {
        #region Variables and Properties

        private string _dataFieldName;
        private bool _primaryKey;
        private bool _foreignKey;

        public string DataFieldName
        {
            get { return _dataFieldName; }
        }
        public bool PrimaryKey
        {
            get { return _primaryKey; }
            set { _primaryKey = value; }
        }
        public bool ForeignKey
        {
            get { return _foreignKey; }
            set { _foreignKey = value; }
        }

        #endregion

        public DataMappingAttribute(string dataFieldName)
            : base()
        {
            _dataFieldName = dataFieldName;
        }

    }
}
