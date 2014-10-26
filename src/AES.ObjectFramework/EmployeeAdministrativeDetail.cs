using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class EmployeeAdministrativeDetail : BaseClassObject
	{

		#region Fields Name ...
		private int? _employeeAdministrativeDetailId;
		private BranchMaster _branchId;
		private DepartmentMaster _departmentId;
		private DivisionMaster _divisionId;		
		private DesignationMaster _designationId;
		private DateTime? _dateOfJoining;
		private string _userName;
		private GradeMaster _gradeId;
		private DateTime? _probationUpto;
		private DateTime? _confirmationDate;
		private bool? _isSalaryStopped;
		private DateTime? _terminationDate;
		private DateTime? _resignationDate;
		private DateTime? _discontinueDate;
		private decimal? _totalExperience;
		private decimal? _relevantExperience;
		private MetadataMaster _employeeTypeId;
		private string _lwfNo;
		#endregion 

		#region Object Properties ...
		[DataMapping("Employee_Administrative_Detail_Id",PrimaryKey=true)]
		public int? EmployeeAdministrativeDetailId
		{
			get
			{
				return _employeeAdministrativeDetailId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_employeeAdministrativeDetailId = value; 
				}
				else
				{
				throw new Exception("Invalid EmployeeAdministrativeDetailId");
				}
			}
		}
		[DataMapping("Branch_Id",ForeignKey=true)]
		public BranchMaster BranchObject
		{
			get
			{
				return _branchId; 
			}
			set 
			{
				_branchId = value;
			}
		}
		[DataMapping("Department_Id",ForeignKey=true)]
		public DepartmentMaster DepartmentObject
		{
			get
			{
				return _departmentId; 
			}
			set 
			{
				_departmentId = value;
			}
		}
		[DataMapping("Division_Id",ForeignKey=true)]
		public DivisionMaster DivisionObject
		{
			get
			{
				return _divisionId; 
			}
			set 
			{
				_divisionId = value;
			}
		}	
		[DataMapping("Designation_Id",ForeignKey=true)]
		public DesignationMaster DesignationObject
		{
			get
			{
				return _designationId; 
			}
			set 
			{
				_designationId = value;
			}
		}
		[DataMapping("Date_Of_Joining")]
		public DateTime? DateOfJoining
		{
			get
			{
				return _dateOfJoining; 
			}
			set 
			{
				if (GeneralUtility.IsDateTime(value) || GeneralUtility.IsNull(value))
				{
					_dateOfJoining = value; 
				}
				else
				{
				throw new Exception("Invalid DateOfJoining");
				}
			}
		}
		[DataMapping("User_Name")]
		public string UserName
		{
			get
			{
				return _userName; 
			}
			set 
			{
				if (value.Length<= 50)
				{
					_userName = value; 
				}
				else
				{
				throw new Exception("Invalid UserName");
				}
			}
		}
		[DataMapping("Grade_Id",ForeignKey=true)]
		public GradeMaster GradeObject
		{
			get
			{
				return _gradeId; 
			}
			set 
			{
				_gradeId = value;
			}
		}
		[DataMapping("Probation_Upto")]
		public DateTime? ProbationUpto
		{
			get
			{
				return _probationUpto; 
			}
			set 
			{
				if (GeneralUtility.IsDateTime(value) || GeneralUtility.IsNull(value))
				{
					_probationUpto = value; 
				}
				else
				{
				throw new Exception("Invalid ProbationUpto");
				}
			}
		}
		[DataMapping("Confirmation_Date")]
		public DateTime? ConfirmationDate
		{
			get
			{
				return _confirmationDate; 
			}
			set 
			{
				if (GeneralUtility.IsDateTime(value) || GeneralUtility.IsNull(value))
				{
					_confirmationDate = value; 
				}
				else
				{
				throw new Exception("Invalid ConfirmationDate");
				}
			}
		}
		[DataMapping("Is_Salary_Stopped")]
		public bool? IsSalaryStopped
		{
			get
			{
				return _isSalaryStopped; 
			}
			set 
			{
				if (GeneralUtility.IsBoolean(value) || GeneralUtility.IsNull(value))
				{
					_isSalaryStopped = value; 
				}
				else
				{
				throw new Exception("Invalid IsSalaryStopped");
				}
			}
		}
		[DataMapping("Termination_Date")]
		public DateTime? TerminationDate
		{
			get
			{
				return _terminationDate; 
			}
			set 
			{
				if (GeneralUtility.IsDateTime(value) || GeneralUtility.IsNull(value))
				{
					_terminationDate = value; 
				}
				else
				{
				throw new Exception("Invalid TerminationDate");
				}
			}
		}
		[DataMapping("Resignation_Date")]
		public DateTime? ResignationDate
		{
			get
			{
				return _resignationDate; 
			}
			set 
			{
				if (GeneralUtility.IsDateTime(value) || GeneralUtility.IsNull(value))
				{
					_resignationDate = value; 
				}
				else
				{
				throw new Exception("Invalid ResignationDate");
				}
			}
		}
		[DataMapping("Discontinue_Date")]
		public DateTime? DiscontinueDate
		{
			get
			{
				return _discontinueDate; 
			}
			set 
			{
				if (GeneralUtility.IsDateTime(value) || GeneralUtility.IsNull(value))
				{
					_discontinueDate = value; 
				}
				else
				{
				throw new Exception("Invalid DiscontinueDate");
				}
			}
		}
		[DataMapping("Total_Experience")]
		public decimal? TotalExperience
		{
			get
			{
				return _totalExperience; 
			}
			set 
			{
				if (GeneralUtility.IsDecimal(value) || GeneralUtility.IsNull(value))
				{
					_totalExperience = value; 
				}
				else
				{
				throw new Exception("Invalid TotalExperience");
				}
			}
		}
		[DataMapping("Relevant_Experience")]
		public decimal? RelevantExperience
		{
			get
			{
				return _relevantExperience; 
			}
			set 
			{
				if (GeneralUtility.IsDecimal(value) || GeneralUtility.IsNull(value))
				{
					_relevantExperience = value; 
				}
				else
				{
				throw new Exception("Invalid RelevantExperience");
				}
			}
		}
		[DataMapping("Employee_Type_Id",ForeignKey=true)]
		public MetadataMaster EmployeeTypeObject
		{
			get
			{
				return _employeeTypeId; 
			}
			set 
			{
				_employeeTypeId = value;
			}
		}
		[DataMapping("LWF_No")]
		public string LwfNo
		{
			get
			{
				return _lwfNo; 
			}
			set 
			{
				if (value.Length<= 50)
				{
					_lwfNo = value; 
				}
				else
				{
				throw new Exception("Invalid LwfNo");
				}
			}
		}
		#endregion 
	}
}
