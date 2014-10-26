using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
    public class CandidateDetail : BaseClassObject
    {
        #region Fields Name ...
        private int? _candidateId;
        private string _firstName;
        private string _middleName;
        private string _lastName;
        private DateTime? _dateOfBirth;
        private GuardianDetail _fatherId;
        private GuardianDetail _motherId;
        private GuardianDetail _guardianId;
        private MetadataMaster _genderId;
        private MetadataMaster _categoryId;
        private MetadataMaster _religionId;
        private MetadataMaster _maritialStatusId;
        private bool? _isStaffChild;
        private AddressDetail _currentAddressId;
        private AddressDetail _permanentAddressId;
        private string _photo;
        private DataSet _previousSchoolEducationDetailData = null;
        private DataSet _siblingDetailData = null;
        private PreviousSchoolEducationDetail _previousSchoolEducationDetailId = null;
        private SiblingDetail _siblingDetailId1 = null;
        private SiblingDetail _siblingDetailId2 = null;
        #endregion

        #region Object Properties ...
        [DataMapping("Candidate_Id", PrimaryKey=true)]
        public int? CandidateId
        {
            get
            {
                return _candidateId;
            }
            set
            {
                if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
                {
                    _candidateId = value;
                }
                else
                {
                    throw new Exception("Invalid CandidateId");
                }
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
                if (value.Length<= 100)
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
                if (value.Length<= 100)
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
                if (value.Length<= 100)
                {
                    _lastName = value;
                }
                else
                {
                    throw new Exception("Invalid LastName");
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
        [DataMapping("Father_Id", ForeignKey=true)]
        public GuardianDetail FatherObject
        {
            get
            {
                return _fatherId;
            }
            set
            {
                _fatherId = value;
            }
        }
        [DataMapping("Mother_Id", ForeignKey=true)]
        public GuardianDetail MotherObject
        {
            get
            {
                return _motherId;
            }
            set
            {
                _motherId = value;
            }
        }
        [DataMapping("Guardian_Id", ForeignKey=true)]
        public GuardianDetail GuardianObject
        {
            get
            {
                return _guardianId;
            }
            set
            {
                _guardianId = value;
            }
        }
        [DataMapping("Gender_Id", ForeignKey=true)]
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
        [DataMapping("Category_Id", ForeignKey=true)]
        public MetadataMaster CategoryObject
        {
            get
            {
                return _categoryId;
            }
            set
            {
                _categoryId = value;
            }
        }
        [DataMapping("Religion_Id", ForeignKey=true)]
        public MetadataMaster ReligionObject
        {
            get
            {
                return _religionId;
            }
            set
            {
                _religionId = value;
            }
        }
        [DataMapping("Maritial_Status_Id", ForeignKey=true)]
        public MetadataMaster MaritialStatusObject
        {
            get
            {
                return _maritialStatusId;
            }
            set
            {
                _maritialStatusId = value;
            }
        }
        [DataMapping("Is_Staff_Child")]
        public bool? IsStaffChild
        {
            get
            {
                return _isStaffChild;
            }
            set
            {
                if (GeneralUtility.IsBoolean(value) || GeneralUtility.IsNull(value))
                {
                    _isStaffChild = value;
                }
                else
                {
                    throw new Exception("Invalid IsStaffChild");
                }
            }
        }
        [DataMapping("Current_Address_Id", ForeignKey=true)]
        public AddressDetail CurrentAddressObject
        {
            get
            {
                return _currentAddressId;
            }
            set
            {
                _currentAddressId = value;
            }
        }
        [DataMapping("Permanent_Address_Id", ForeignKey=true)]
        public AddressDetail PermanentAddressObject
        {
            get
            {
                return _permanentAddressId;
            }
            set
            {
                _permanentAddressId = value;
            }
        }
        [DataMapping("Photo")]
        public string Photo
        {
            get
            {
                return _photo;
            }
            set
            {
                if (value.Length<= 50)
                {
                    _photo = value;
                }
                else
                {
                    throw new Exception("Invalid Photo");
                }
            }
        }
        public DataSet PreviousSchoolEducationDetailData
        {
            get
            {
                return _previousSchoolEducationDetailData;
            }
            set
            {
                _previousSchoolEducationDetailData = value;
            }
        }
        public DataSet SiblingDetailData
        {
            get
            {
                return _siblingDetailData;
            }
            set
            {
                _siblingDetailData = value;
            }
        }

        // Custom Added                
        public string FullName
        {
            get
            {
                return string.Format("{0} {1} {2}", FirstName, MiddleName, LastName);
            }
        }
        public PreviousSchoolEducationDetail PreviousSchoolEducationDetailObject
        {
            get
            {
                return _previousSchoolEducationDetailId;
            }
            set
            {
                _previousSchoolEducationDetailId = value;
            }
        }
        public SiblingDetail SiblingDetailObject1
        {
            get
            {
                return _siblingDetailId1;
            }
            set
            {
                _siblingDetailId1 = value;
            }
        }
        public SiblingDetail SiblingDetailObject2
        {
            get
            {
                return _siblingDetailId2;
            }
            set
            {
                _siblingDetailId2 = value;
            }
        }
        #endregion
    }
}
