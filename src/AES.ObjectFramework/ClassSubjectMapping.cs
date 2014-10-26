using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class ClassSubjectMapping : BaseClassObject
	{

		#region Fields Name ...
		private int? _classSubjectMappingId;
		private string _classSubjectMappingName;
		private ClassMaster _classId;
		private SubjectMaster _subjectId;
		private string _description;
		#endregion 

		#region Object Properties ...
		[DataMapping("Class_Subject_Mapping_Id",PrimaryKey=true)]
		public int? ClassSubjectMappingId
		{
			get
			{
				return _classSubjectMappingId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_classSubjectMappingId = value; 
				}
				else
				{
				throw new Exception("Invalid ClassSubjectMappingId");
				}
			}
		}
		[DataMapping("Class_Subject_Mapping_Name")]
		public string ClassSubjectMappingName
		{
			get
			{
				return _classSubjectMappingName; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_classSubjectMappingName = value; 
				}
				else
				{
				throw new Exception("Invalid ClassSubjectMappingName");
				}
			}
		}
		[DataMapping("Class_Id",ForeignKey=true)]
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
		[DataMapping("Subject_Id",ForeignKey=true)]
		public SubjectMaster SubjectObject
		{
			get
			{
				return _subjectId; 
			}
			set 
			{
				_subjectId = value;
			}
		}
		[DataMapping("Description")]
		public string Description
		{
			get
			{
				return _description; 
			}
			set 
			{
				if (value.Length<= 500)
				{
					_description = value; 
				}
				else
				{
				throw new Exception("Invalid Description");
				}
			}
		}
		#endregion 
	}
}
