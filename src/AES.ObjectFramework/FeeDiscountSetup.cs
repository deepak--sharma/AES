using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class FeeDiscountSetup : BaseClassObject
	{

		#region Fields Name ...
		private int? _feeDiscountId;
		private FeeStructureDetail _feeStructureDetailId;
		private FeeMaster _discountTypeId;
		private DateTime? _discountTypeValue;
		private decimal? _discountAmount;
		private bool? _isPercent;
		private DateTime? _effectiveDate;
		#endregion 

		#region Object Properties ...
		[DataMapping("Fee_Discount_Id",PrimaryKey=true)]
		public int? FeeDiscountId
		{
			get
			{
				return _feeDiscountId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_feeDiscountId = value; 
				}
				else
				{
				throw new Exception("Invalid FeeDiscountId");
				}
			}
		}
		[DataMapping("Fee_Structure_Detail_Id",ForeignKey=true)]
		public FeeStructureDetail FeeStructureDetailObject
		{
			get
			{
				return _feeStructureDetailId; 
			}
			set 
			{
				_feeStructureDetailId = value;
			}
		}
		[DataMapping("Discount_Type_Id",ForeignKey=true)]
		public FeeMaster DiscountTypeObject
		{
			get
			{
				return _discountTypeId; 
			}
			set 
			{
				_discountTypeId = value;
			}
		}
		[DataMapping("Discount_Type_Value")]
		public DateTime? DiscountTypeValue
		{
			get
			{
				return _discountTypeValue; 
			}
			set 
			{
				if (GeneralUtility.IsDateTime(value) || GeneralUtility.IsNull(value))
				{
					_discountTypeValue = value; 
				}
				else
				{
				throw new Exception("Invalid DiscountTypeValue");
				}
			}
		}
		[DataMapping("Discount_Amount")]
		public decimal? DiscountAmount
		{
			get
			{
				return _discountAmount; 
			}
			set 
			{
				if (GeneralUtility.IsDecimal(value) || GeneralUtility.IsNull(value))
				{
					_discountAmount = value; 
				}
				else
				{
				throw new Exception("Invalid DiscountAmount");
				}
			}
		}
		[DataMapping("Is_Percent")]
		public bool? IsPercent
		{
			get
			{
				return _isPercent; 
			}
			set 
			{
				if (GeneralUtility.IsBoolean(value) || GeneralUtility.IsNull(value))
				{
					_isPercent = value; 
				}
				else
				{
				throw new Exception("Invalid IsPercent");
				}
			}
		}
		[DataMapping("Effective_Date")]
		public DateTime? EffectiveDate
		{
			get
			{
				return _effectiveDate; 
			}
			set 
			{
				if (GeneralUtility.IsDateTime(value) || GeneralUtility.IsNull(value))
				{
					_effectiveDate = value; 
				}
				else
				{
				throw new Exception("Invalid EffectiveDate");
				}
			}
		}
		#endregion 
	}
}
