using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class LateFeeSetupDetail : BaseClassObject
	{

		#region Fields Name ...
		private int? _lateFeeSetupDetailId;
		private LateFeeSetup _lateFeeSetupId;
		private int? _startRange;
		private int? _endRange;
		private decimal? _amount;
		private MetadataMaster _frequencyId;
		#endregion 

		#region Object Properties ...
		[DataMapping("Late_Fee_Setup_Detail_Id",PrimaryKey=true)]
		public int? LateFeeSetupDetailId
		{
			get
			{
				return _lateFeeSetupDetailId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_lateFeeSetupDetailId = value; 
				}
				else
				{
				throw new Exception("Invalid LateFeeSetupDetailId");
				}
			}
		}
		[DataMapping("Late_Fee_Setup_Id",ForeignKey=true)]
		public LateFeeSetup LateFeeSetupObject
		{
			get
			{
				return _lateFeeSetupId; 
			}
			set 
			{
				_lateFeeSetupId = value;
			}
		}
		[DataMapping("Start_Range")]
		public int? StartRange
		{
			get
			{
				return _startRange; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_startRange = value; 
				}
				else
				{
				throw new Exception("Invalid StartRange");
				}
			}
		}
		[DataMapping("End_Range")]
		public int? EndRange
		{
			get
			{
				return _endRange; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_endRange = value; 
				}
				else
				{
				throw new Exception("Invalid EndRange");
				}
			}
		}
		[DataMapping("Amount")]
		public decimal? Amount
		{
			get
			{
				return _amount; 
			}
			set 
			{
				if (GeneralUtility.IsDecimal(value) || GeneralUtility.IsNull(value))
				{
					_amount = value; 
				}
				else
				{
				throw new Exception("Invalid Amount");
				}
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
		#endregion 
	}
}
