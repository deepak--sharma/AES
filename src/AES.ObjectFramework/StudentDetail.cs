using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class StudentDetail : BaseClassObject
	{

		#region Fields Name ...
		private int? _studentId;
		private StudentRegistrationDetail _studentRegistrationId;
		private SectionMaster _sectionId;
		private StreamMaster _streamId;
		private string _rollNo;
		private FeeStructure _feeStructureId;
		private DateTime? _admissionDate;
		#endregion 

		#region Object Properties ...
		[DataMapping("Student_Id",PrimaryKey=true)]
		public int? StudentId
		{
			get
			{
				return _studentId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_studentId = value; 
				}
				else
				{
				throw new Exception("Invalid StudentId");
				}
			}
		}
		[DataMapping("Student_Registration_Id",ForeignKey=true)]
		public StudentRegistrationDetail StudentRegistrationObject
		{
			get
			{
				return _studentRegistrationId; 
			}
			set 
			{
				_studentRegistrationId = value;
			}
		}
		[DataMapping("Section_Id",ForeignKey=true)]
		public SectionMaster SectionObject
		{
			get
			{
				return _sectionId; 
			}
			set 
			{
				_sectionId = value;
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
		[DataMapping("Roll_No")]
		public string RollNo
		{
			get
			{
				return _rollNo; 
			}
			set 
			{
				if (value.Length<= 50)
				{
					_rollNo = value; 
				}
				else
				{
				throw new Exception("Invalid RollNo");
				}
			}
		}
		[DataMapping("Fee_Structure_Id",ForeignKey=true)]
		public FeeStructure FeeStructureObject
		{
			get
			{
				return _feeStructureId; 
			}
			set 
			{
				_feeStructureId = value;
			}
		}
		[DataMapping("Admission_Date")]
		public DateTime? AdmissionDate
		{
			get
			{
				return _admissionDate; 
			}
			set 
			{
				if (GeneralUtility.IsDateTime(value) || GeneralUtility.IsNull(value))
				{
					_admissionDate = value; 
				}
				else
				{
				throw new Exception("Invalid AdmissionDate");
				}
			}
		}
		#endregion 
	}
}
