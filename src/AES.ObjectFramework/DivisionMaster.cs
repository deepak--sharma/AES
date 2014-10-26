using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class DivisionMaster : BaseClassObject
	{

		#region Fields Name ...
		private int? _divisionId;
		private DepartmentMaster _departmentId;
		private string _divisionCode;
		private string _divisionName;
		private string _description;
		#endregion 

		#region Object Properties ...
		[DataMapping("Division_Id",PrimaryKey=true)]
		public int? DivisionId
		{
			get
			{
				return _divisionId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_divisionId = value; 
				}
				else
				{
				throw new Exception("Invalid DivisionId");
				}
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
		[DataMapping("Division_Code")]
		public string DivisionCode
		{
			get
			{
				return _divisionCode; 
			}
			set 
			{
				if (value.Length<= 50)
				{
					_divisionCode = value; 
				}
				else
				{
				throw new Exception("Invalid DivisionCode");
				}
			}
		}
		[DataMapping("Division_Name")]
		public string DivisionName
		{
			get
			{
				return _divisionName; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_divisionName = value; 
				}
				else
				{
				throw new Exception("Invalid DivisionName");
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
