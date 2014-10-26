using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
    public class SiblingDetail : BaseClassObject
    {

        #region Fields Name ...
        private int? _siblingId;
        private string _fullName;
        private DateTime? _dateOfBirth;
        private CandidateDetail _candidateId;
        private MetadataMaster _genderId;
        private SchoolMaster _schoolId;
        private string _schoolName;
        private string _schoolAddress;
        private string _schoolContacts;
        private ClassMaster _classId;
        private string _registrationNumber;
        private bool? _isCandidate;
        private bool? _isRequired;        
        #endregion

        #region Object Properties ...
        [DataMapping("Sibling_Id", PrimaryKey = true)]
        public int? SiblingId
        {
            get
            {
                return _siblingId;
            }
            set
            {
                if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
                {
                    _siblingId = value;
                }
                else
                {
                    throw new Exception("Invalid SiblingId");
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
                if (value.Length <= 100)
                {
                    _fullName = value;
                }
                else
                {
                    throw new Exception("Invalid FirstName");
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
        [DataMapping("Candidate_Id", ForeignKey = true)]
        public CandidateDetail CandidateObject
        {
            get
            {
                return _candidateId;
            }
            set
            {
                _candidateId = value;
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
        [DataMapping("School_Id", ForeignKey = true)]
        public SchoolMaster SchoolObject
        {
            get
            {
                return _schoolId;
            }
            set
            {
                _schoolId = value;
            }
        }
        [DataMapping("School_Name")]
        public string SchoolName
        {
            get
            {
                return _schoolName;
            }
            set
            {
                if (value.Length <= 100)
                {
                    _schoolName = value;
                }
                else
                {
                    throw new Exception("Invalid SchoolName");
                }
            }
        }
        [DataMapping("School_Address")]
        public string SchoolAddress
        {
            get
            {
                return _schoolAddress;
            }
            set
            {
                if (value.Length <= 500)
                {
                    _schoolAddress = value;
                }
                else
                {
                    throw new Exception("Invalid SchoolAddress");
                }
            }
        }
        [DataMapping("School_Contacts")]
        public string SchoolContacts
        {
            get
            {
                return _schoolContacts;
            }
            set
            {
                if (value.Length <= 100)
                {
                    _schoolContacts = value;
                }
                else
                {
                    throw new Exception("Invalid SchoolContacts");
                }
            }
        }
        [DataMapping("Class_Id", ForeignKey = true)]
        public ClassMaster ClassObject
        {
            get
            {
                return _classId;
            }
            set
            {
                _classId = value;
            }
        }
        [DataMapping("Registration_Number")]
        public string RegistrationNumber
        {
            get
            {
                return _registrationNumber;
            }
            set
            {
                if (value.Length <= 100)
                {
                    _registrationNumber = value;
                }
                else
                {
                    throw new Exception("Invalid RegistrationNumber");
                }
            }
        }
        [DataMapping("Is_Candidate")]
        public bool? IsCandidate
        {
            get
            {
                return _isCandidate;
            }
            set
            {
                if (GeneralUtility.IsBoolean(value) || GeneralUtility.IsNull(value))
                {
                    _isCandidate = value;
                }
                else
                {
                    throw new Exception("Invalid IsCandidate");
                }
            }
        }
        [DataMapping("Is_Required")]
        public bool? IsRequired
        {
            get 
            { 
                return _isRequired; 
            }
            set
            {
                if (GeneralUtility.IsBoolean(value) || GeneralUtility.IsNull(value))
                {
                    _isRequired = value;
                }
                else
                {
                    throw new Exception("Invalid IsRequired");
                }
            }
        }
        #endregion
    }
}
