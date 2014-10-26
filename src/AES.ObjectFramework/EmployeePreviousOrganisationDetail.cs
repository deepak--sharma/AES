using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class EmployeePreviousOrganisationDetail : BaseClassObject
	{

		#region Fields Name ...
		private int? _employeePreviousOrgDetailId;
		private EmployeeDetail _employeeId;
		private string _organisationName;
		private DateTime? _periodFrom;
		private DateTime? _periodTo;
		private decimal? _ctc;
		private MetadataMaster _currencyId;
		private string _entryDesignation;
		private string _exitDesignation;
		private string _supervisorName;
		private string _supervisorContact;
		private string _supervisorDesignation;
		private string _department;
		private string _natureOfWork;
		private string _organisationAddress;
		private string _webAddress;
		private string _reasonForLeaving;
		private int? _recentOrder;
		#endregion 

		#region Object Properties ...
		[DataMapping("Employee_Previous_Org_Detail_Id",PrimaryKey=true)]
		public int? EmployeePreviousOrgDetailId
		{
			get
			{
				return _employeePreviousOrgDetailId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_employeePreviousOrgDetailId = value; 
				}
				else
				{
				throw new Exception("Invalid EmployeePreviousOrgDetailId");
				}
			}
		}
		[DataMapping("Employee_Id",ForeignKey=true)]
		public EmployeeDetail EmployeeObject
		{
			get
			{
				return _employeeId; 
			}
			set 
			{
				_employeeId = value;
			}
		}
		[DataMapping("Organisation_Name")]
		public string OrganisationName
		{
			get
			{
				return _organisationName; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_organisationName = value; 
				}
				else
				{
				throw new Exception("Invalid OrganisationName");
				}
			}
		}
		[DataMapping("Period_From")]
		public DateTime? PeriodFrom
		{
			get
			{
				return _periodFrom; 
			}
			set 
			{
				if (GeneralUtility.IsDateTime(value) || GeneralUtility.IsNull(value))
				{
					_periodFrom = value; 
				}
				else
				{
				throw new Exception("Invalid PeriodFrom");
				}
			}
		}
		[DataMapping("Period_To")]
		public DateTime? PeriodTo
		{
			get
			{
				return _periodTo; 
			}
			set 
			{
				if (GeneralUtility.IsDateTime(value) || GeneralUtility.IsNull(value))
				{
					_periodTo = value; 
				}
				else
				{
				throw new Exception("Invalid PeriodTo");
				}
			}
		}
		[DataMapping("CTC")]
		public decimal? Ctc
		{
			get
			{
				return _ctc; 
			}
			set 
			{
				if (GeneralUtility.IsDecimal(value) || GeneralUtility.IsNull(value))
				{
					_ctc = value; 
				}
				else
				{
				throw new Exception("Invalid Ctc");
				}
			}
		}
		[DataMapping("Currency_Id",ForeignKey=true)]
		public MetadataMaster CurrencyObject
		{
			get
			{
				return _currencyId; 
			}
			set 
			{
				_currencyId = value;
			}
		}
		[DataMapping("Entry_Designation")]
		public string EntryDesignation
		{
			get
			{
				return _entryDesignation; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_entryDesignation = value; 
				}
				else
				{
				throw new Exception("Invalid EntryDesignation");
				}
			}
		}
		[DataMapping("Exit_Designation")]
		public string ExitDesignation
		{
			get
			{
				return _exitDesignation; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_exitDesignation = value; 
				}
				else
				{
				throw new Exception("Invalid ExitDesignation");
				}
			}
		}
		[DataMapping("Supervisor_Name")]
		public string SupervisorName
		{
			get
			{
				return _supervisorName; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_supervisorName = value; 
				}
				else
				{
				throw new Exception("Invalid SupervisorName");
				}
			}
		}
		[DataMapping("Supervisor_Contact")]
		public string SupervisorContact
		{
			get
			{
				return _supervisorContact; 
			}
			set 
			{
				if (value.Length<= 50)
				{
					_supervisorContact = value; 
				}
				else
				{
				throw new Exception("Invalid SupervisorContact");
				}
			}
		}
		[DataMapping("Supervisor_Designation")]
		public string SupervisorDesignation
		{
			get
			{
				return _supervisorDesignation; 
			}
			set 
			{
				if (value.Length<= 50)
				{
					_supervisorDesignation = value; 
				}
				else
				{
				throw new Exception("Invalid SupervisorDesignation");
				}
			}
		}
		[DataMapping("Department")]
		public string Department
		{
			get
			{
				return _department; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_department = value; 
				}
				else
				{
				throw new Exception("Invalid Department");
				}
			}
		}
		[DataMapping("Nature_Of_Work")]
		public string NatureOfWork
		{
			get
			{
				return _natureOfWork; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_natureOfWork = value; 
				}
				else
				{
				throw new Exception("Invalid NatureOfWork");
				}
			}
		}
		[DataMapping("Organisation_Address")]
		public string OrganisationAddress
		{
			get
			{
				return _organisationAddress; 
			}
			set 
			{
				if (value.Length<= 500)
				{
					_organisationAddress = value; 
				}
				else
				{
				throw new Exception("Invalid Organisation Address");
				}
			}
		}
		[DataMapping("Web_Address")]
		public string WebAddress
		{
			get
			{
				return _webAddress; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_webAddress = value; 
				}
				else
				{
				throw new Exception("Invalid WebAddress");
				}
			}
		}
		[DataMapping("Reason_For_Leaving")]
		public string ReasonForLeaving
		{
			get
			{
				return _reasonForLeaving; 
			}
			set 
			{
				if (value.Length<= 500)
				{
					_reasonForLeaving = value; 
				}
				else
				{
				throw new Exception("Invalid ReasonForLeaving");
				}
			}
		}
		[DataMapping("Recent_Order")]
		public int? RecentOrder
		{
			get
			{
				return _recentOrder; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_recentOrder = value; 
				}
				else
				{
				throw new Exception("Invalid RecentOrder");
				}
			}
		}
		#endregion 
	}
}
