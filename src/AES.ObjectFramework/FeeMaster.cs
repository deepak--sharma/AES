using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class FeeMaster : BaseClassObject
	{

		#region Fields Name ...
		private int? _feeId;
		private string _feeCode;
		private string _feeName;
		private MetadataMaster _feeGroupId;
		private MetadataMaster _frequencyId;
		private bool? _isMandatory;
		private bool? _isRefundable;
		private MetadataMaster _applicableTo;
		private string _description;
		#endregion 

		#region Object Properties ...
		[DataMapping("Fee_Id",PrimaryKey=true)]
		public int? FeeId
		{
			get
			{
				return _feeId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_feeId = value; 
				}
				else
				{
				throw new Exception("Invalid FeeId");
				}
			}
		}
		[DataMapping("Fee_Code")]
		public string FeeCode
		{
			get
			{
				return _feeCode; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_feeCode = value; 
				}
				else
				{
				throw new Exception("Invalid FeeCode");
				}
			}
		}
		[DataMapping("Fee_Name")]
		public string FeeName
		{
			get
			{
				return _feeName; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_feeName = value; 
				}
				else
				{
				throw new Exception("Invalid FeeName");
				}
			}
		}
		[DataMapping("Fee_Group_Id",ForeignKey=true)]
		public MetadataMaster FeeGroupObject
		{
			get
			{
				return _feeGroupId; 
			}
			set 
			{
				_feeGroupId = value;
			}
		}
		[DataMapping("Frequency_Id",ForeignKey=true)]
		public MetadataMaster FrequencyObject
		{
			get
			{
				return _frequencyId; 
			}
			set 
			{
				_frequencyId = value;
			}
		}
		[DataMapping("Is_Mandatory")]
		public bool? IsMandatory
		{
			get
			{
				return _isMandatory; 
			}
			set 
			{
				if (GeneralUtility.IsBoolean(value) || GeneralUtility.IsNull(value))
				{
					_isMandatory = value; 
				}
				else
				{
				throw new Exception("Invalid IsMandatory");
				}
			}
		}
		[DataMapping("Is_Refundable")]
		public bool? IsRefundable
		{
			get
			{
				return _isRefundable; 
			}
			set 
			{
				if (GeneralUtility.IsBoolean(value) || GeneralUtility.IsNull(value))
				{
					_isRefundable = value; 
				}
				else
				{
				throw new Exception("Invalid IsRefundable");
				}
			}
		}
		[DataMapping("Applicable_To",ForeignKey=true)]
		public MetadataMaster ApplicableTo
		{
			get
			{
				return _applicableTo; 
			}
			set 
			{
				_applicableTo = value;
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
