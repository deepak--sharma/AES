using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class EmployeeJoiningDetail : BaseClassObject
	{

		#region Fields Name ...
		private int? _employeeJoiningId;
		private EmployeeDetail _employeeId;
		private JoiningMaster _joiningId;
		private string _description;
		#endregion 

		#region Object Properties ...
		[DataMapping("Employee_Joining_Id",PrimaryKey=true)]
		public int? EmployeeJoiningId
		{
			get
			{
				return _employeeJoiningId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_employeeJoiningId = value; 
				}
				else
				{
				throw new Exception("Invalid EmployeeJoiningId");
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
		[DataMapping("Joining_Id",ForeignKey=true)]
		public JoiningMaster JoiningObject
		{
			get
			{
				return _joiningId; 
			}
			set 
			{
				_joiningId = value;
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
