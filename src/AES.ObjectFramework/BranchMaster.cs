using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class BranchMaster : BaseClassObject
	{

		#region Fields Name ...
		private int? _branchId;
		private string _branchCode;
		private string _branchName;
		private EmployeeDetail _branchHeadId;
		private DateTime? _establishedOn;
		private AddressDetail _branchAddressId;
		private string _description;
		#endregion 

		#region Object Properties ...
		[DataMapping("Branch_Id",PrimaryKey=true)]
		public int? BranchId
		{
			get
			{
				return _branchId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_branchId = value; 
				}
				else
				{
				throw new Exception("Invalid BranchId");
				}
			}
		}
		[DataMapping("Branch_Code")]
		public string BranchCode
		{
			get
			{
				return _branchCode; 
			}
			set 
			{
				if (value.Length<= 50)
				{
					_branchCode = value; 
				}
				else
				{
				throw new Exception("Invalid BranchCode");
				}
			}
		}
		[DataMapping("Branch_Name")]
		public string BranchName
		{
			get
			{
				return _branchName; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_branchName = value; 
				}
				else
				{
				throw new Exception("Invalid BranchName");
				}
			}
		}
		[DataMapping("Branch_Head_Id",ForeignKey=true)]
		public EmployeeDetail BranchHeadObject
		{
			get
			{
				return _branchHeadId; 
			}
			set 
			{
				_branchHeadId = value;
			}
		}
		[DataMapping("Established_On")]
		public DateTime? EstablishedOn
		{
			get
			{
				return _establishedOn; 
			}
			set 
			{
				if (GeneralUtility.IsDateTime(value) || GeneralUtility.IsNull(value))
				{
					_establishedOn = value; 
				}
				else
				{
				throw new Exception("Invalid EstablishedOn");
				}
			}
		}
		[DataMapping("Branch_Address_Id",ForeignKey=true)]
		public AddressDetail BranchAddressObject
		{
			get
			{
				return _branchAddressId; 
			}
			set 
			{
				_branchAddressId = value;
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
