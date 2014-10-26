using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class SubjectMaster : BaseClassObject
	{

		#region Fields Name ...
		private int? _subjectId;
		private string _subjectCode;
		private string _subjectName;
		private string _description;
		#endregion 

		#region Object Properties ...
		[DataMapping("Subject_Id",PrimaryKey=true)]
		public int? SubjectId
		{
			get
			{
				return _subjectId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_subjectId = value; 
				}
				else
				{
				throw new Exception("Invalid SubjectId");
				}
			}
		}
		[DataMapping("Subject_Code")]
		public string SubjectCode
		{
			get
			{
				return _subjectCode; 
			}
			set 
			{
				if (value.Length<= 50)
				{
					_subjectCode = value; 
				}
				else
				{
				throw new Exception("Invalid SubjectCode");
				}
			}
		}
		[DataMapping("Subject_Name")]
		public string SubjectName
		{
			get
			{
				return _subjectName; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_subjectName = value; 
				}
				else
				{
				throw new Exception("Invalid SubjectName");
				}
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
