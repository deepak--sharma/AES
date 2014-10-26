using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class LedgerMaster : BaseClassObject
	{

		#region Fields Name ...
		private int? _ledgerId;
		private string _ledgerName;
		private GroupMaster _groupId;
		private decimal? _openingBalance;
		private DateTime? _openingDate;
		private string _drCr;
		private DateTime? _onDate;
		private string _description;
		#endregion 

		#region Object Properties ...
		[DataMapping("Ledger_Id",PrimaryKey=true)]
		public int? LedgerId
		{
			get
			{
				return _ledgerId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_ledgerId = value; 
				}
				else
				{
				throw new Exception("Invalid LedgerId");
				}
			}
		}
		[DataMapping("Ledger_Name")]
		public string LedgerName
		{
			get
			{
				return _ledgerName; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_ledgerName = value; 
				}
				else
				{
				throw new Exception("Invalid LedgerName");
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
		[DataMapping("Opening_Balance")]
		public decimal? OpeningBalance
		{
			get
			{
				return _openingBalance; 
			}
			set 
			{
				if (GeneralUtility.IsDecimal(value) || GeneralUtility.IsNull(value))
				{
					_openingBalance = value; 
				}
				else
				{
				throw new Exception("Invalid OpeningBalance");
				}
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
