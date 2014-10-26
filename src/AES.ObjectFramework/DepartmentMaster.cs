using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class DepartmentMaster : BaseClassObject
	{

		#region Fields Name ...
		private int? _departmentId;
		private string _departmentCode;
		private string _departmentName;
		private string _description;
		private EmployeeDetail _hod;
		#endregion 

		#region Object Properties ...
		[DataMapping("Department_Id",PrimaryKey=true)]
		public int? DepartmentId
		{
			get
			{
				return _departmentId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_departmentId = value; 
				}
				else
				{
				throw new Exception("Invalid DepartmentId");
				}
			}
		}
		[DataMapping("Department_Code")]
		public string DepartmentCode
		{
			get
			{
				return _departmentCode; 
			}
			set 
			{
				if (value.Length<= 50)
				{
					_departmentCode = value; 
				}
				else
				{
				throw new Exception("Invalid DepartmentCode");
				}
			}
		}
		[DataMapping("Department_Name")]
		public string DepartmentName
		{
			get
			{
				return _departmentName; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_departmentName = value; 
				}
				else
				{
				throw new Exception("Invalid DepartmentName");
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
		[DataMapping("HOD",ForeignKey=true)]
		public EmployeeDetail Hod
		{
			get
			{
				return _hod; 
			}
			set 
			{
				_hod = value;
			}
		}
		#endregion 
	}
}
