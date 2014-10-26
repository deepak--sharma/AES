using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class BankMaster : BaseClassObject
	{

		#region Fields Name ...
		private int? _bankId;
		private string _bankCode;
		private string _bankName;
		private int? _bankAddressId;
		private string _description;
		#endregion 

		#region Object Properties ...
		[DataMapping("Bank_Id",PrimaryKey=true)]
		public int? BankId
		{
			get
			{
				return _bankId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_bankId = value; 
				}
				else
				{
				throw new Exception("Invalid BankId");
				}
			}
		}
		[DataMapping("Bank_Code")]
		public string BankCode
		{
			get
			{
				return _bankCode; 
			}
			set 
			{
				if (value.Length<= 50)
				{
					_bankCode = value; 
				}
				else
				{
				throw new Exception("Invalid BankCode");
				}
			}
		}
		[DataMapping("Bank_Name")]
		public string BankName
		{
			get
			{
				return _bankName; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_bankName = value; 
				}
				else
				{
				throw new Exception("Invalid BankName");
				}
			}
		}
		[DataMapping("Bank_Address_Id")]
		public int? BankAddressId
		{
			get
			{
				return _bankAddressId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_bankAddressId = value; 
				}
				else
				{
				throw new Exception("Invalid BankAddressId");
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
