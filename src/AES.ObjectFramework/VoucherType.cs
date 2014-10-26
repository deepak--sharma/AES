using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class VoucherType : BaseClassObject
	{

		#region Fields Name ...
		private int? _voucherTypeId;
		private string _voucherTypeName;
		private string _serialNumberMode;
		private string _serialNumberPrefix;
		private int? _numericalWidth;
		private bool? _isZeroPrefix;
		private string _startingNumber;
		#endregion 

		#region Object Properties ...
		[DataMapping("Voucher_Type_Id",PrimaryKey=true)]
		public int? VoucherTypeId
		{
			get
			{
				return _voucherTypeId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_voucherTypeId = value; 
				}
				else
				{
				throw new Exception("Invalid VoucherTypeId");
				}
			}
		}
		[DataMapping("Voucher_Type_Name")]
		public string VoucherTypeName
		{
			get
			{
				return _voucherTypeName; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_voucherTypeName = value; 
				}
				else
				{
				throw new Exception("Invalid VoucherTypeName");
				}
			}
		}
		[DataMapping("Serial_Number_Mode")]
		public string SerialNumberMode
		{
			get
			{
				return _serialNumberMode; 
			}
			set 
			{
				if (value.Length<= 50)
				{
					_serialNumberMode = value; 
				}
				else
				{
				throw new Exception("Invalid SerialNumberMode");
				}
			}
		}
		[DataMapping("Serial_Number_Prefix")]
		public string SerialNumberPrefix
		{
			get
			{
				return _serialNumberPrefix; 
			}
			set 
			{
				if (value.Length<= 50)
				{
					_serialNumberPrefix = value; 
				}
				else
				{
				throw new Exception("Invalid SerialNumberPrefix");
				}
			}
		}
		[DataMapping("Numerical_Width")]
		public int? NumericalWidth
		{
			get
			{
				return _numericalWidth; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_numericalWidth = value; 
				}
				else
				{
				throw new Exception("Invalid NumericalWidth");
				}
			}
		}
		[DataMapping("Is_Zero_Prefix")]
		public bool? IsZeroPrefix
		{
			get
			{
				return _isZeroPrefix; 
			}
			set 
			{
				if (GeneralUtility.IsBoolean(value) || GeneralUtility.IsNull(value))
				{
					_isZeroPrefix = value; 
				}
				else
				{
				throw new Exception("Invalid IsZeroPrefix");
				}
			}
		}
		[DataMapping("Starting_Number")]
		public string StartingNumber
		{
			get
			{
				return _startingNumber; 
			}
			set 
			{
				if (value.Length<= 50)
				{
					_startingNumber = value; 
				}
				else
				{
				throw new Exception("Invalid StartingNumber");
				}
			}
		}
		#endregion 
	}
}
