using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
    public class PreviousSchoolEducationDetail : BaseClassObject
    {

        #region Fields Name ...
        private int? _previousSchoolEducationId;
        private CandidateDetail _candidateId;
        private SchoolMaster _schoolId;
        private string _schoolName;
        private string _schoolAddress;
        private string _schoolContacts;
        private ClassMaster _classId;
        private string _registrationNumber;
        private AcademicSessionMaster _academicSessionId;
        private string _resultStatus;
        private decimal? _marksPercent;
        private string _supportedDocuments;
        private bool? _isRequired;      
        private DataSet _previousSchoolEducationMarksDetailData = null;
        private String _previousSchoolEducationMarksDetailString = null;       
        #endregion

        #region Object Properties ...
        [DataMapping("Previous_School_Education_Id", PrimaryKey = true)]
        public int? PreviousSchoolEducationId
        {
            get
            {
                return _previousSchoolEducationId;
            }
            set
            {
                if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
                {
                    _previousSchoolEducationId = value;
                }
                else
                {
                    throw new Exception("Invalid PreviousSchoolEducationId");
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
        [DataMapping("Academic_Session_Id", ForeignKey = true)]
        public AcademicSessionMaster AcademicSessionObject
        {
            get
            {
                return _academicSessionId;
            }
            set
            {
                _academicSessionId = value;
            }
        }
        [DataMapping("Result_Status")]
        public string ResultStatus
        {
            get
            {
                return _resultStatus;
            }
            set
            {
                if (value.Length <= 100)
                {
                    _resultStatus = value;
                }
                else
                {
                    throw new Exception("Invalid ResultStatus");
                }
            }
        }
        [DataMapping("Marks_Percent")]
        public decimal? MarksPercent
        {
            get
            {
                return _marksPercent;
            }
            set
            {
                if (GeneralUtility.IsDecimal(value) || GeneralUtility.IsNull(value))
                {
                    _marksPercent = value;
                }
                else
                {
                    throw new Exception("Invalid MarksPercent");
                }
            }
        }
        [DataMapping("Supported_Documents")]
        public string SupportedDocuments
        {
            get
            {
                return _supportedDocuments;
            }
            set
            {
                if (value.Length <= 50)
                {
                    _supportedDocuments = value;
                }
                else
                {
                    throw new Exception("Invalid SupportedDocuments");
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
        public DataSet PreviousSchoolEducationMarksDetailData
        {
            get
            {
                return _previousSchoolEducationMarksDetailData;
            }
            set
            {
                _previousSchoolEducationMarksDetailData = value;
            }
        }
        
        // Custom Added
        public String PreviousSchoolEducationMarksDetailString
        {
            get { return _previousSchoolEducationMarksDetailString; }
            set { _previousSchoolEducationMarksDetailString = value; }
        }
        #endregion
    }
}
