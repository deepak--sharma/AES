using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class CashRegisterMaster : BaseClassObject
	{

		#region Fields Name ...
		private int? _cashRegisterId;
		private string _cashRegisterName;
		private GroupMaster _groupId;
		private DateTime? _openingDate;
		private string _drCr;
		private DateTime? _onDate;
		private string _description;
		#endregion 

		#region Object Properties ...
		[DataMapping("Cash_Register_Id",PrimaryKey=true)]
		public int? CashRegisterId
		{
			get
			{
				return _cashRegisterId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_cashRegisterId = value; 
				}
				else
				{
				throw new Exception("Invalid CashRegisterId");
				}
			}
		}
		[DataMapping("Cash_Register_Name")]
		public string CashRegisterName
		{
			get
			{
				return _cashRegisterName; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_cashRegisterName = value; 
				}
				else
				{
				throw new Exception("Invalid CashRegisterName");
				}
			}
		}
		[DataMapping("Group_Id",ForeignKey=true)]
		public GroupMaster GroupObject
		{
			get
			{
				return _groupId; 
			}
			set 
			{
				_groupId = value;
			}
		}
		[DataMapping("Opening_Date")]
		public DateTime? OpeningDate
		{
			get
			{
				return _openingDate; 
			}
			set 
			{
				if (GeneralUtility.IsDateTime(value) || GeneralUtility.IsNull(value))
				{
					_openingDate = value; 
				}
				else
				{
				throw new Exception("Invalid OpeningDate");
				}
			}
		}
		[DataMapping("DR_CR")]
		public string DrCr
		{
			get
			{
				return _drCr; 
			}
			set 
			{
				if (value.Length<= 50)
				{
					_drCr = value; 
				}
				else
				{
				throw new Exception("Invalid DrCr");
				}
			}
		}
		[DataMapping("On_Date")]
		public DateTime? OnDate
		{
			get
			{
				return _onDate; 
			}
			set 
			{
				if (GeneralUtility.IsDateTime(value) || GeneralUtility.IsNull(value))
				{
					_onDate = value; 
				}
				else
				{
				throw new Exception("Invalid OnDate");
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
