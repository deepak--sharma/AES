using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class EmployeeEducationalDetail : BaseClassObject
	{

		#region Fields Name ...
		private int? _employeeEducationalDetailId;
		private EmployeeDetail _employeeId;
		private ClassMaster _classId;
		private StreamMaster _streamId;
		private DateTime? _periodFrom;
		private DateTime? _periodTo;
		private decimal? _marksPercentage;
		private string _schoolCollegeInstituteName;
		private string _address;
		private string _boardUniversityName;
		private string _remarks;
		#endregion 

		#region Object Properties ...
		[DataMapping("Employee_Educational_Detail_Id",PrimaryKey=true)]
		public int? EmployeeEducationalDetailId
		{
			get
			{
				return _employeeEducationalDetailId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_employeeEducationalDetailId = value; 
				}
				else
				{
				throw new Exception("Invalid EmployeeEducationalDetailId");
				}
			}
		}
		[DataMapping("Employee_Id",ForeignKey=true)]
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
		[DataMapping("Class_Course_Mapping_Id",ForeignKey=true)]
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
		[DataMapping("Stream_Id",ForeignKey=true)]
		public StreamMaster StreamObject
		{
			get
			{
				return _streamId; 
			}
			set 
			{
				_streamId = value;
			}
		}
		[DataMapping("Period_From")]
		public DateTime? PeriodFrom
		{
			get
			{
				return _periodFrom; 
			}
			set 
			{
				if (GeneralUtility.IsDateTime(value) || GeneralUtility.IsNull(value))
				{
					_periodFrom = value; 
				}
				else
				{
				throw new Exception("Invalid PeriodFrom");
				}
			}
		}
		[DataMapping("Period_To")]
		public DateTime? PeriodTo
		{
			get
			{
				return _periodTo; 
			}
			set 
			{
				if (GeneralUtility.IsDateTime(value) || GeneralUtility.IsNull(value))
				{
					_periodTo = value; 
				}
				else
				{
				throw new Exception("Invalid PeriodTo");
				}
			}
		}
		[DataMapping("Marks_Percentage")]
		public decimal? MarksPercentage
		{
			get
			{
				return _marksPercentage; 
			}
			set 
			{
				if (GeneralUtility.IsDecimal(value) || GeneralUtility.IsNull(value))
				{
					_marksPercentage = value; 
				}
				else
				{
				throw new Exception("Invalid MarksPercentage");
				}
			}
		}
		[DataMapping("School_College_Institute_Name")]
		public string SchoolCollegeInstituteName
		{
			get
			{
				return _schoolCollegeInstituteName; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_schoolCollegeInstituteName = value; 
				}
				else
				{
				throw new Exception("Invalid SchoolCollegeInstituteName");
				}
			}
		}
		[DataMapping("Address")]
		public string Address
		{
			get
			{
				return _address; 
			}
			set 
			{
				if (value.Length<= 500)
				{
					_address = value; 
				}
				else
				{
				throw new Exception("Invalid Address");
				}
			}
		}
		[DataMapping("Board_University_Name")]
		public string BoardUniversityName
		{
			get
			{
				return _boardUniversityName; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_boardUniversityName = value; 
				}
				else
				{
				throw new Exception("Invalid BoardUniversityName");
				}
			}
		}
		[DataMapping("Remarks")]
		public string Remarks
		{
			get
			{
				return _remarks; 
			}
			set 
			{
				if (value.Length<= 500)
				{
					_remarks = value; 
				}
				else
				{
				throw new Exception("Invalid Remarks");
				}
			}
		}
		#endregion 
	}
}
