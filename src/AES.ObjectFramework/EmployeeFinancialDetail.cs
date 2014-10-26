using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class EmployeeFinancialDetail : BaseClassObject
	{

		#region Fields Name ...
		private int? _employeeFinancialDetailId;
		private string _panCardNo;
		private string _pfNo;
		private string _esiNo;
		private bool? _isPanApproved;
		private string _accountNo;
		private MetadataMaster _accountTypeId;
		private decimal? _vpfPercent;
		private decimal? _vpfAmount;
		private bool? _isConsentForEcs;
		private bool? _isVpfEligible;
		private bool? _isPfDeducted;
		private int? _ledgerId;
		private bool? _isSalaryHold;
        private MetadataMaster _paymentModeId;
		private BankMaster _bankId;
		#endregion 

		#region Object Properties ...
		[DataMapping("Employee_Financial_Detail_ID",PrimaryKey=true)]
		public int? EmployeeFinancialDetailId
		{
			get
			{
				return _employeeFinancialDetailId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_employeeFinancialDetailId = value; 
				}
				else
				{
				throw new Exception("Invalid EmployeeFinancialDetailId");
				}
			}
		}
		[DataMapping("Pan_Card_No")]
		public string PanCardNo
		{
			get
			{
				return _panCardNo; 
			}
			set 
			{
				if (value.Length<= 50)
				{
					_panCardNo = value; 
				}
				else
				{
				throw new Exception("Invalid PanCardNo");
				}
			}
		}
		[DataMapping("PF_No")]
		public string PfNo
		{
			get
			{
				return _pfNo; 
			}
			set 
			{
				if (value.Length<= 50)
				{
					_pfNo = value; 
				}
				else
				{
				throw new Exception("Invalid PfNo");
				}
			}
		}
		[DataMapping("ESI_No")]
		public string EsiNo
		{
			get
			{
				return _esiNo; 
			}
			set 
			{
				if (value.Length<= 50)
				{
					_esiNo = value; 
				}
				else
				{
				throw new Exception("Invalid EsiNo");
				}
			}
		}
		[DataMapping("Is_Pan_Approved")]
		public bool? IsPanApproved
		{
			get
			{
				return _isPanApproved; 
			}
			set 
			{
				if (GeneralUtility.IsBoolean(value) || GeneralUtility.IsNull(value))
				{
					_isPanApproved = value; 
				}
				else
				{
				throw new Exception("Invalid IsPanApproved");
				}
			}
		}
		[DataMapping("Account_No")]
		public string AccountNo
		{
			get
			{
				return _accountNo; 
			}
			set 
			{
				if (value.Length<= 50)
				{
					_accountNo = value; 
				}
				else
				{
				throw new Exception("Invalid AccountNo");
				}
			}
		}
		[DataMapping("Account_Type_Id",ForeignKey=true)]
		public MetadataMaster AccountTypeObject
		{
			get
			{
				return _accountTypeId; 
			}
			set 
			{
				_accountTypeId = value;
			}
		}
		[DataMapping("VPF_Percent")]
		public decimal? VpfPercent
		{
			get
			{
				return _vpfPercent; 
			}
			set 
			{
				if (GeneralUtility.IsDecimal(value) || GeneralUtility.IsNull(value))
				{
					_vpfPercent = value; 
				}
				else
				{
				throw new Exception("Invalid VpfPercent");
				}
			}
		}
		[DataMapping("VPF_Amount")]
		public decimal? VpfAmount
		{
			get
			{
				return _vpfAmount; 
			}
			set 
			{
				if (GeneralUtility.IsDecimal(value) || GeneralUtility.IsNull(value))
				{
					_vpfAmount = value; 
				}
				else
				{
				throw new Exception("Invalid VpfAmount");
				}
			}
		}
		[DataMapping("Is_Consent_For_ECS")]
		public bool? IsConsentForEcs
		{
			get
			{
				return _isConsentForEcs; 
			}
			set 
			{
				if (GeneralUtility.IsBoolean(value) || GeneralUtility.IsNull(value))
				{
					_isConsentForEcs = value; 
				}
				else
				{
				throw new Exception("Invalid IsConsentForEcs");
				}
			}
		}
		[DataMapping("Is_VPF_Eligible")]
		public bool? IsVpfEligible
		{
			get
			{
				return _isVpfEligible; 
			}
			set 
			{
				if (GeneralUtility.IsBoolean(value) || GeneralUtility.IsNull(value))
				{
					_isVpfEligible = value; 
				}
				else
				{
				throw new Exception("Invalid IsVpfEligible");
				}
			}
		}
		[DataMapping("Is_PF_Deducted")]
		public bool? IsPfDeducted
		{
			get
			{
				return _isPfDeducted; 
			}
			set 
			{
				if (GeneralUtility.IsBoolean(value) || GeneralUtility.IsNull(value))
				{
					_isPfDeducted = value; 
				}
				else
				{
				throw new Exception("Invalid IsPfDeducted");
				}
			}
		}
		[DataMapping("Ledger_Id")]
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
		[DataMapping("Is_Salary_Hold")]
		public bool? IsSalaryHold
		{
			get
			{
				return _isSalaryHold; 
			}
			set 
			{
				if (GeneralUtility.IsBoolean(value) || GeneralUtility.IsNull(value))
				{
					_isSalaryHold = value; 
				}
				else
				{
				throw new Exception("Invalid IsSalaryHold");
				}
			}
		}
        [DataMapping("Payment_Mode_Id", ForeignKey = true)]
        public MetadataMaster PaymentModeObject
        {
            get
            {
                return _paymentModeId;
            }
            set
            {
                _paymentModeId = value;
            }
        }
		[DataMapping("Bank_Id",ForeignKey=true)]
		public BankMaster BankObject
		{
			get
			{
				return _bankId; 
			}
			set 
			{
				_bankId = value;
			}
		}
		#endregion 
	}
}
