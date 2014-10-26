using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class ReportingDetail : BaseClassObject
	{

		#region Fields Name ...
		private int? _reportingId;
		private EmployeeDetail _employeeId;
		private EmployeeDetail _supervisorId;
		private string _otherDetail;
		private bool? _isPrimary;
		#endregion 

		#region Object Properties ...
		[DataMapping("Reporting_ID",PrimaryKey=true)]
		public int? ReportingId
		{
			get
			{
				return _reportingId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_reportingId = value; 
				}
				else
				{
				throw new Exception("Invalid ReportingId");
				}
			}
		}
		[DataMapping("Employee_ID",ForeignKey=true)]
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
		[DataMapping("Supervisor_ID",ForeignKey=true)]
		public EmployeeDetail SupervisorObject
		{
			get
			{
				return _supervisorId; 
			}
			set 
			{
				_supervisorId = value;
			}
		}
		[DataMapping("Other_Detail")]
		public string OtherDetail
		{
			get
			{
				return _otherDetail; 
			}
			set 
			{
				if (value.Length<= 200)
				{
					_otherDetail = value; 
				}
				else
				{
				throw new Exception("Invalid OtherDetail");
				}
			}
		}
		[DataMapping("Is_Primary")]
		public bool? IsPrimary
		{
			get
			{
				return _isPrimary; 
			}
			set 
			{
				if (GeneralUtility.IsBoolean(value) || GeneralUtility.IsNull(value))
				{
					_isPrimary = value; 
				}
				else
				{
				throw new Exception("Invalid IsPrimary");
				}
			}
		}
		#endregion 
	}
}
