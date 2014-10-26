using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class FeeCollectionDetail : BaseClassObject
	{

		#region Fields Name ...
		private int? _feeCollectionId;
		private StudentDetail _studentId;
		private decimal? _baseFee;
		private decimal? _discountFee;
		private decimal? _lateFee;
		private decimal? _fine;
		private decimal? _totalFee;
		private decimal? _previousBalance;
		private decimal? _feeDeposite;
		private decimal? _currentBalance;
		private DateTime? _submitionDate;
		#endregion 

		#region Object Properties ...
		[DataMapping("Fee_Collection_Id",PrimaryKey=true)]
		public int? FeeCollectionId
		{
			get
			{
				return _feeCollectionId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_feeCollectionId = value; 
				}
				else
				{
				throw new Exception("Invalid FeeCollectionId");
				}
			}
		}
		[DataMapping("Student_Id",ForeignKey=true)]
		public StudentDetail StudentObject
		{
			get
			{
				return _studentId; 
			}
			set 
			{
				_studentId = value;
			}
		}
		[DataMapping("Base_Fee")]
		public decimal? BaseFee
		{
			get
			{
				return _baseFee; 
			}
			set 
			{
				if (GeneralUtility.IsDecimal(value) || GeneralUtility.IsNull(value))
				{
					_baseFee = value; 
				}
				else
				{
				throw new Exception("Invalid BaseFee");
				}
			}
		}
		[DataMapping("Discount_Fee")]
		public decimal? DiscountFee
		{
			get
			{
				return _discountFee; 
			}
			set 
			{
				if (GeneralUtility.IsDecimal(value) || GeneralUtility.IsNull(value))
				{
					_discountFee = value; 
				}
				else
				{
				throw new Exception("Invalid DiscountFee");
				}
			}
		}
		[DataMapping("Late_Fee")]
		public decimal? LateFee
		{
			get
			{
				return _lateFee; 
			}
			set 
			{
				if (GeneralUtility.IsDecimal(value) || GeneralUtility.IsNull(value))
				{
					_lateFee = value; 
				}
				else
				{
				throw new Exception("Invalid LateFee");
				}
			}
		}
		[DataMapping("Fine")]
		public decimal? Fine
		{
			get
			{
				return _fine; 
			}
			set 
			{
				if (GeneralUtility.IsDecimal(value) || GeneralUtility.IsNull(value))
				{
					_fine = value; 
				}
				else
				{
				throw new Exception("Invalid Fine");
				}
			}
		}
		[DataMapping("Total_Fee")]
		public decimal? TotalFee
		{
			get
			{
				return _totalFee; 
			}
			set 
			{
				if (GeneralUtility.IsDecimal(value) || GeneralUtility.IsNull(value))
				{
					_totalFee = value; 
				}
				else
				{
				throw new Exception("Invalid TotalFee");
				}
			}
		}
		[DataMapping("Previous_Balance")]
		public decimal? PreviousBalance
		{
			get
			{
				return _previousBalance; 
			}
			set 
			{
				if (GeneralUtility.IsDecimal(value) || GeneralUtility.IsNull(value))
				{
					_previousBalance = value; 
				}
				else
				{
				throw new Exception("Invalid PreviousBalance");
				}
			}
		}
		[DataMapping("Fee_Deposite")]
		public decimal? FeeDeposite
		{
			get
			{
				return _feeDeposite; 
			}
			set 
			{
				if (GeneralUtility.IsDecimal(value) || GeneralUtility.IsNull(value))
				{
					_feeDeposite = value; 
				}
				else
				{
				throw new Exception("Invalid FeeDeposite");
				}
			}
		}
		[DataMapping("Current_Balance")]
		public decimal? CurrentBalance
		{
			get
			{
				return _currentBalance; 
			}
			set 
			{
				if (GeneralUtility.IsDecimal(value) || GeneralUtility.IsNull(value))
				{
					_currentBalance = value; 
				}
				else
				{
				throw new Exception("Invalid CurrentBalance");
				}
			}
		}
		[DataMapping("Submition_Date")]
		public DateTime? SubmitionDate
		{
			get
			{
				return _submitionDate; 
			}
			set 
			{
				if (GeneralUtility.IsDateTime(value) || GeneralUtility.IsNull(value))
				{
					_submitionDate = value; 
				}
				else
				{
				throw new Exception("Invalid SubmitionDate");
				}
			}
		}
		#endregion 
	}
}
