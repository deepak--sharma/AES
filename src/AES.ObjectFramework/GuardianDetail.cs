using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
    public class GuardianDetail : BaseClassObject
    {
        #region Fields Name ...
        private int? _guardianId;
        private string _fullName;
        private DateTime? _dateOfBirth;
        private string _contactNo;
        private string _designation;
        private string _qualification;
        private MetadataMaster _nationalityId;
        private string _relation;
        private bool? _isGuardian;
        private bool? _isStaff;
        private bool? _wasStudent;
        private string _officeDetail;
        #endregion

        #region Object Properties ...
        [DataMapping("Guardian_Id", PrimaryKey = true)]
        public int? GuardianId
        {
            get
            {
                return _guardianId;
            }
            set
            {
                if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
                {
                    _guardianId = value;
                }
                else
                {
                    throw new Exception("Invalid GuardianId");
                }
            }
        }
        [DataMapping("Full_Name")]
        public string FullName
        {
            get
            {
                return _fullName;
            }
            set
            {
                if (value.Length <= 300)
                {
                    _fullName = value;
                }
                else
                {
                    throw new Exception("Invalid FullName");
                }
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
        [DataMapping("Contact_No")]
        public string ContactNo
        {
            get
            {
                return _contactNo;
            }
            set
            {
                if (value.Length <= 50)
                {
                    _contactNo = value;
                }
                else
                {
                    throw new Exception("Invalid ContactNo");
                }
            }
        }
        [DataMapping("Designation")]
        public string Designation
        {
            get
            {
                return _designation;
            }
            set
            {
                if (value.Length <= 100)
                {
                    _designation = value;
                }
                else
                {
                    throw new Exception("Invalid Designation");
                }
            }
        }
        [DataMapping("Qualification")]
        public string Qualification
        {
            get
            {
                return _qualification;
            }
            set
            {
                if (value.Length <= 100)
                {
                    _qualification = value;
                }
                else
                {
                    throw new Exception("Invalid Qualification");
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
        [DataMapping("Relation")]
        public string Relation
        {
            get
            {
                return _relation;
            }
            set
            {
                if (value.Length <= 50)
                {
                    _relation = value;
                }
                else
                {
                    throw new Exception("Invalid Relation");
                }
            }
        }
        [DataMapping("Is_Guardian")]
        public bool? IsGuardian
        {
            get
            {
                return _isGuardian;
            }
            set
            {
                if (GeneralUtility.IsBoolean(value) || GeneralUtility.IsNull(value))
                {
                    _isGuardian = value;
                }
                else
                {
                    throw new Exception("Invalid IsGuardian");
                }
            }
        }
        [DataMapping("Is_Staff")]
        public bool? IsStaff
        {
            get
            {
                return _isStaff;
            }
            set
            {
                if (GeneralUtility.IsBoolean(value) || GeneralUtility.IsNull(value))
                {
                    _isStaff = value;
                }
                else
                {
                    throw new Exception("Invalid IsStaff");
                }
            }
        }
        [DataMapping("Was_Student")]
        public bool? WasStudent
        {
            get
            {
                return _wasStudent;
            }
            set
            {
                if (GeneralUtility.IsBoolean(value) || GeneralUtility.IsNull(value))
                {
                    _wasStudent = value;
                }
                else
                {
                    throw new Exception("Invalid WasStudent");
                }
            }
        }
        [DataMapping("Office_Detail")]
        public string OfficeDetail
        {
            get
            {
                return _officeDetail;
            }
            set
            {
                if (value.Length <= 500)
                {
                    _officeDetail = value;
                }
                else
                {
                    throw new Exception("Invalid Office Detail");
                }
            }
        }
        #endregion
    }
}
