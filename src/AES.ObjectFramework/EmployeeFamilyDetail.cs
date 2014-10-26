using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
    public class EmployeeFamilyDetail : BaseClassObject
    {

        #region Fields Name ...
        private int? _employeeFamilyId;
        private EmployeeDetail _employeeId;
        private string _firstName;
        private string _middleName;
        private string _lastName;
        private MetadataMaster _genderId;
        private MetadataMaster _relationId;
        private DateTime? _dateOfBirth;
        private string _birthPlace;
        private MetadataMaster _nationalityId;
        private bool? _isDependent;
        #endregion

        #region Object Properties ...
        [DataMapping("Employee_Family_Id", PrimaryKey = true)]
        public int? EmployeeFamilyId
        {
            get
            {
                return _employeeFamilyId;
            }
            set
            {
                if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
                {
                    _employeeFamilyId = value;
                }
                else
                {
                    throw new Exception("Invalid EmployeeFamilyId");
                }
            }
        }
        [DataMapping("Employee_Id", ForeignKey = true)]
        public EmployeeDetail EmployeeObject
        {
            get
            {
                return _employeeId;
            }
            set
            {
                _employeeId = value;
            }
        }
        [DataMapping("First_Name")]
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (value.Length <= 100)
                {
                    _firstName = value;
                }
                else
                {
                    throw new Exception("Invalid FirstName");
                }
            }
        }
        [DataMapping("Middle_Name")]
        public string MiddleName
        {
            get
            {
                return _middleName;
            }
            set
            {
                if (value.Length <= 100)
                {
                    _middleName = value;
                }
                else
                {
                    throw new Exception("Invalid MiddleName");
                }
            }
        }
        [DataMapping("Last_Name")]
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (value.Length <= 100)
                {
                    _lastName = value;
                }
                else
                {
                    throw new Exception("Invalid LastName");
                }
            }
        }
        [DataMapping("Gender_Id", ForeignKey = true)]
        public MetadataMaster GenderObject
        {
            get
            {
                return _genderId;
            }
            set
            {
                _genderId = value;
            }
        }
        [DataMapping("Relation_Id", ForeignKey = true)]
        public MetadataMaster RelationObject
        {
            get
            {
                return _relationId;
            }
            set
            {
                _relationId = value;
            }
        }
        [DataMapping("Date_Of_Birth")]
        public DateTime? DateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }
            set
            {
                if (GeneralUtility.IsDateTime(value) || GeneralUtility.IsNull(value))
                {
                    _dateOfBirth = value;
                }
                else
                {
                    throw new Exception("Invalid DateOfBirth");
                }
            }
        }
        [DataMapping("Birth_Place")]
        public string BirthPlace
        {
            get
            {
                return _birthPlace;
            }
            set
            {
                if (value.Length <= 100)
                {
                    _birthPlace = value;
                }
                else
                {
                    throw new Exception("Invalid BirthPlace");
                }
            }
        }
        [DataMapping("Nationality_Id", ForeignKey = true)]
        public MetadataMaster NationalityObject
        {
            get
            {
                return _nationalityId;
            }
            set
            {
                _nationalityId = value;
            }
        }
        [DataMapping("Is_Dependent")]
        public bool? IsDependent
        {
            get
            {
                return _isDependent;
            }
            set
            {
                _isDependent = value;
            }
        }
        #endregion
    }
}
