using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class FeeSetup : BaseClassObject
	{

		#region Fields Name ...
		private int? _feeSetupId;
		private FeeStructureDetail _feeStructureDetailId;
		private FeeMaster _feeId;
		private decimal? _feeAmount;
		private DateTime? _startMonth;
		private DateTime? _endMonth;
		private int? _frequencyId;
        private int? _frequencyTypeId;
       
		private DateTime? _effectiveDate;
        private bool? _isApplicable;       
		#endregion 

		#region Object Properties ...
		[DataMapping("Fee_Setup_Id",PrimaryKey=true)]
		public int? FeeSetupId
		{
			get
			{
				return _feeSetupId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_feeSetupId = value; 
				}
				else
				{
				throw new Exception("Invalid FeeSetupId");
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
		[DataMapping("Fee_Id",ForeignKey=true)]
		public FeeMaster FeeObject
		{
			get
			{
				return _feeId; 
			}
			set 
			{
				_feeId = value;
			}
		}
		[DataMapping("Fee_Amount")]
		public decimal? FeeAmount
		{
			get
			{
				return _feeAmount; 
			}
			set 
			{
				if (GeneralUtility.IsDecimal(value) || GeneralUtility.IsNull(value))
				{
					_feeAmount = value; 
				}
				else
				{
				throw new Exception("Invalid FeeAmount");
				}
			}
		}
		[DataMapping("Start_Month")]
		public DateTime? StartMonth
		{
			get
			{
				return _startMonth; 
			}
			set 
			{
				if (GeneralUtility.IsDateTime(value) || GeneralUtility.IsNull(value))
				{
					_startMonth = value; 
				}
				else
				{
				throw new Exception("Invalid StartMonth");
				}
			}
		}
		[DataMapping("End_Month")]
		public DateTime? EndMonth
		{
			get
			{
				return _endMonth; 
			}
			set 
			{
				if (GeneralUtility.IsDateTime(value) || GeneralUtility.IsNull(value))
				{
					_endMonth = value; 
				}
				else
				{
				throw new Exception("Invalid EndMonth");
				}
			}
		}
		[DataMapping("Frequency_Id")]
		public int? FrequencyId
		{
			get
			{
				return _frequencyId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_frequencyId = value; 
				}
				else
				{
				throw new Exception("Invalid Frequency Id");
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
        [DataMapping("IS_APPLICABLE")]
        public bool? IsApplicable
        {
            get { return _isApplicable; }
            set { _isApplicable = value; }
        }
        public int? FrequencyTypeId
        {
            get { return _frequencyTypeId; }
            set { _frequencyTypeId = value; }
        }
		#endregion 
	}
}
