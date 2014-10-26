using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class EmployeeMedicalDetail : BaseClassObject
	{

		#region Fields Name ...
		private int? _employeeMedicalId;
		private EmployeeDetail _employeeId;
		private MedicalMaster _medicalId;
		private string _description;
		#endregion 

		#region Object Properties ...
		[DataMapping("Employee_Medical_Id",PrimaryKey=true)]
		public int? EmployeeMedicalId
		{
			get
			{
				return _employeeMedicalId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_employeeMedicalId = value; 
				}
				else
				{
				throw new Exception("Invalid EmployeeMedicalId");
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
		[DataMapping("Medical_Id",ForeignKey=true)]
		public MedicalMaster MedicalObject
		{
			get
			{
				return _medicalId; 
			}
			set 
			{
				_medicalId = value;
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
