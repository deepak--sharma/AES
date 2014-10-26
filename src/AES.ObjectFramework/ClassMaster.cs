using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class ClassMaster : BaseClassObject
	{

		#region Fields Name ...
		private int? _classId;
		private string _classCode;
		private string _className;
		private string _description;
		private bool? _isStudent;
		#endregion 

		#region Object Properties ...
		[DataMapping("Class_Id",PrimaryKey=true)]
		public int? ClassId
		{
			get
			{
				return _classId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_classId = value; 
				}
				else
				{
				throw new Exception("Invalid ClassId");
				}
			}
		}
		[DataMapping("Class_Code")]
		public string ClassCode
		{
			get
			{
				return _classCode; 
			}
			set 
			{
				if (value.Length<= 50)
				{
					_classCode = value; 
				}
				else
				{
				throw new Exception("Invalid ClassCode");
				}
			}
		}
		[DataMapping("Class_Name")]
		public string ClassName
		{
			get
			{
				return _className; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_className = value; 
				}
				else
				{
				throw new Exception("Invalid ClassName");
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
		[DataMapping("Is_Student")]
		public bool? IsStudent
		{
			get
			{
				return _isStudent; 
			}
			set 
			{
				if (GeneralUtility.IsBoolean(value) || GeneralUtility.IsNull(value))
				{
					_isStudent = value; 
				}
				else
				{
				throw new Exception("Invalid IsStudent");
				}
			}
		}
		#endregion 
	}
}
