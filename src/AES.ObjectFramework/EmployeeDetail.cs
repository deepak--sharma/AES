using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class EmployeeDetail : BaseClassObject
	{

		#region Fields Name ...
		private int? _employeeId;
		private string _employeeCode;
		private string _firstName;
		private string _middleName;
		private string _lastName;
        private string _fatherName;        
		private MetadataMaster _genderId;
		private DateTime? _dateOfBirth;
		private MetadataMaster _maritialStatusId;
		private DateTime? _marriageDate;
		private string _photo;
		private EmployeeAdministrativeDetail _employeeAdministrativeDetailId;
		private EmployeeFinancialDetail _employeeFinancialDetailId;
		private MetadataMaster _religionId;
		private MetadataMaster _castecategoryId;
		private MetadataMaster _nationalityId;
		private AddressDetail _currentAddressId;
		private AddressDetail _permanentAddressId;
		private EmergencyDetail _primaryEmergencyId;
		private EmergencyDetail _secondryEmergencyId;
		private string _personalEmailId;
		private string _officeEmailId;
		private bool? _isFresher;
		private string _compaign;
		private string _ssnNo;
        private int? _version;
		private DataSet _employeeJoiningDetailData = null;
		private DataSet _reportingDetailData = null;
		private DataSet _skillDetailData = null;
		private DataSet _knownLanguageData = null;
		private DataSet _immigrationDetailData = null;
		private DataSet _licenceDetailData = null;
		private DataSet _employeePreviousOrganisationDetailData = null;
		private DataSet _employeeFamilyDetailData = null;
		private DataSet _employeeEducationalDetailData = null;
		private DataSet _employeeMedicalDetailData = null;       
		#endregion 

		#region Object Properties ...
		[DataMapping("Employee_Id",PrimaryKey=true)]
		public int? EmployeeId
		{
			get
			{
				return _employeeId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_employeeId = value; 
				}
				else
				{
				throw new Exception("Invalid EmployeeId");
				}
			}
		}
		[DataMapping("Employee_Code")]
		public string EmployeeCode
		{
			get
			{
				return _employeeCode; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_employeeCode = value; 
				}
				else
				{
				throw new Exception("Invalid EmployeeCode");
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
        [DataMapping("Father_Name")]
        public string FatherName
        {
            get { return _fatherName; }
            set 
            {
                if (value.Length <= 200)
                {
                    _fatherName = value;
                }
                else
                {
                    throw new Exception("Invalid FatherName");
                }
            }
        }
		[DataMapping("Gender_Id",ForeignKey=true)]
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
		[DataMapping("Maritial_Status_Id",ForeignKey=true)]
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
		[DataMapping("Marriage_Date")]
		public DateTime? MarriageDate
		{
			get
			{
				return _marriageDate; 
			}
			set 
			{
				if (GeneralUtility.IsDateTime(value) || GeneralUtility.IsNull(value))
				{
					_marriageDate = value; 
				}
				else
				{
				throw new Exception("Invalid MarriageDate");
				}
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
		[DataMapping("Employee_Administrative_Detail_Id",ForeignKey=true)]
		public EmployeeAdministrativeDetail EmployeeAdministrativeDetailObject
		{
			get
			{
				return _employeeAdministrativeDetailId; 
			}
			set 
			{
				_employeeAdministrativeDetailId = value;
			}
		}
		[DataMapping("Employee_Financial_Detail_ID",ForeignKey=true)]
		public EmployeeFinancialDetail EmployeeFinancialDetailObject
		{
			get
			{
				return _employeeFinancialDetailId; 
			}
			set 
			{
				_employeeFinancialDetailId = value;
			}
		}
		[DataMapping("Religion_Id",ForeignKey=true)]
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
		[DataMapping("CasteCategory_Id",ForeignKey=true)]
		public MetadataMaster CastecategoryObject
		{
			get
			{
				return _castecategoryId; 
			}
			set 
			{
				_castecategoryId = value;
			}
		}
		[DataMapping("Nationality_Id",ForeignKey=true)]
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
		[DataMapping("Current_Address_Id",ForeignKey=true)]
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
		[DataMapping("Permanent_Address_Id",ForeignKey=true)]
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
		[DataMapping("Primary_Emergency_Id",ForeignKey=true)]
		public EmergencyDetail PrimaryEmergencyObject
		{
			get
			{
				return _primaryEmergencyId; 
			}
			set 
			{
				_primaryEmergencyId = value;
			}
		}
		[DataMapping("Secondry_Emergency_Id",ForeignKey=true)]
		public EmergencyDetail SecondryEmergencyObject
		{
			get
			{
				return _secondryEmergencyId; 
			}
			set 
			{
				_secondryEmergencyId = value;
			}
		}
		[DataMapping("Personal_Email_Id")]
		public string PersonalEmailId
		{
			get
			{
				return _personalEmailId; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_personalEmailId = value; 
				}
				else
				{
				throw new Exception("Invalid PersonalEmailId");
				}
			}
		}
		[DataMapping("Office_Email_Id")]
		public string OfficeEmailId
		{
			get
			{
				return _officeEmailId; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_officeEmailId = value; 
				}
				else
				{
				throw new Exception("Invalid OfficeEmailId");
				}
			}
		}
		[DataMapping("Is_Fresher")]
		public bool? IsFresher
		{
			get
			{
				return _isFresher; 
			}
			set 
			{
				if (GeneralUtility.IsBoolean(value) || GeneralUtility.IsNull(value))
				{
					_isFresher = value; 
				}
				else
				{
				throw new Exception("Invalid IsFresher");
				}
			}
		}
		[DataMapping("Compaign")]
		public string Compaign
		{
			get
			{
				return _compaign; 
			}
			set 
			{
				if (value.Length<= 50)
				{
					_compaign = value; 
				}
				else
				{
				throw new Exception("Invalid Compaign");
				}
			}
		}
		[DataMapping("SSN_No")]
		public string SsnNo
		{
			get
			{
				return _ssnNo; 
			}
			set 
			{
				if (value.Length<= 50)
				{
					_ssnNo = value; 
				}
				else
				{
				throw new Exception("Invalid SsnNo");
				}
			}
		}
        [DataMapping("Version")]
        public new int? Version
        {
            get
            {
                return _version;
            }
            set
            {
                _version = value;
            }
        }
		public DataSet EmployeeJoiningDetailData
		{
			get
			{
				return _employeeJoiningDetailData; 
			}
			set 
			{
				_employeeJoiningDetailData = value;
			}
		}
		public DataSet ReportingDetailData
		{
			get
			{
				return _reportingDetailData; 
			}
			set 
			{
				_reportingDetailData = value;
			}
		}
		public DataSet SkillDetailData
		{
			get
			{
				return _skillDetailData; 
			}
			set 
			{
				_skillDetailData = value;
			}
		}
		public DataSet KnownLanguageData
		{
			get
			{
				return _knownLanguageData; 
			}
			set 
			{
				_knownLanguageData = value;
			}
		}
		public DataSet ImmigrationDetailData
		{
			get
			{
				return _immigrationDetailData; 
			}
			set 
			{
				_immigrationDetailData = value;
			}
		}
		public DataSet LicenceDetailData
		{
			get
			{
				return _licenceDetailData; 
			}
			set 
			{
				_licenceDetailData = value;
			}
		}
		public DataSet EmployeePreviousOrganisationDetailData
		{
			get
			{
				return _employeePreviousOrganisationDetailData; 
			}
			set 
			{
				_employeePreviousOrganisationDetailData = value;
			}
		}
		public DataSet EmployeeFamilyDetailData
		{
			get
			{
				return _employeeFamilyDetailData; 
			}
			set 
			{
				_employeeFamilyDetailData = value;
			}
		}
		public DataSet EmployeeEducationalDetailData
		{
			get
			{
				return _employeeEducationalDetailData; 
			}
			set 
			{
				_employeeEducationalDetailData = value;
			}
		}
		public DataSet EmployeeMedicalDetailData
		{
			get
			{
				return _employeeMedicalDetailData; 
			}
			set 
			{
				_employeeMedicalDetailData = value;
			}
		}
		#endregion 
	}
}
