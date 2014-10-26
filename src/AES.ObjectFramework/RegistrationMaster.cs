using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class RegistrationMaster : BaseClassObject
	{

		#region Fields Name ...
		private int? _registrationId;
		private string _registrationName;
        private ClassMaster _classId;
        private StreamMaster _streamId;
		private BranchMaster _branchId;
		private DateTime? _startDate;
		private DateTime? _endDate;
		private AcademicSessionMaster _academicSessionId;
		private int? _totalSeat;
		private int? _freeSeat;
		private int? _managementSeat;
		private decimal? _registrationFee;
		private bool? _isPartialFeeAllowed;
		private bool? _isReservationAllowed;
		private string _eligibility;
		private string _instruction;
		private string _disclaimer;
		private DataSet _reservationDetailData = null;
		private DataSet _registrationEligibilityData = null;
        private MetadataMaster _registrationStatusId;
		#endregion 

		#region Object Properties ...
		[DataMapping("Registration_Id",PrimaryKey=true)]
		public int? RegistrationId
		{
			get
			{
				return _registrationId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_registrationId = value; 
				}
				else
				{
				throw new Exception("Invalid RegistrationId");
				}
			}
		}
		[DataMapping("Registration_Name")]
		public string RegistrationName
		{
			get
			{
				return _registrationName; 
			}
			set 
			{
				if (value.Length<= 200)
				{
					_registrationName = value; 
				}
				else
				{
				throw new Exception("Invalid RegistrationName");
				}
			}
		}
		[DataMapping("Class_Id",ForeignKey=true)]
        public ClassMaster ClassObject
		{
			get
			{
				return _classId; 
			}
			set 
			{
				_classId = value;
			}
		}
        [DataMapping("Stream_Id", ForeignKey = true)]
        public StreamMaster StreamObject
        {
            get
            {
                return _streamId;
            }
            set
            {
                _streamId = value;
            }
        }
		[DataMapping("Branch_Id",ForeignKey=true)]
		public BranchMaster BranchObject
		{
			get
			{
				return _branchId; 
			}
			set 
			{
				_branchId = value;
			}
		}
		[DataMapping("Start_Date")]
		public DateTime? StartDate
		{
			get
			{
				return _startDate; 
			}
			set 
			{
				if (GeneralUtility.IsDateTime(value) || GeneralUtility.IsNull(value))
				{
					_startDate = value; 
				}
				else
				{
				throw new Exception("Invalid StartDate");
				}
			}
		}
		[DataMapping("End_Date")]
		public DateTime? EndDate
		{
			get
			{
				return _endDate; 
			}
			set 
			{
				if (GeneralUtility.IsDateTime(value) || GeneralUtility.IsNull(value))
				{
					_endDate = value; 
				}
				else
				{
				throw new Exception("Invalid EndDate");
				}
			}
		}
		[DataMapping("Academic_Session_Id",ForeignKey=true)]
		public AcademicSessionMaster AcademicSessionObject
		{
			get
			{
				return _academicSessionId; 
			}
			set 
			{
				_academicSessionId = value;
			}
		}
		[DataMapping("Total_Seat")]
		public int? TotalSeat
		{
			get
			{
				return _totalSeat; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_totalSeat = value; 
				}
				else
				{
				throw new Exception("Invalid TotalSeat");
				}
			}
		}
		[DataMapping("Free_Seat")]
		public int? FreeSeat
		{
			get
			{
				return _freeSeat; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_freeSeat = value; 
				}
				else
				{
				throw new Exception("Invalid FreeSeat");
				}
			}
		}
		[DataMapping("Management_Seat")]
		public int? ManagementSeat
		{
			get
			{
				return _managementSeat; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_managementSeat = value; 
				}
				else
				{
				throw new Exception("Invalid ManagementSeat");
				}
			}
		}
		[DataMapping("Registration_Fee")]
		public decimal? RegistrationFee
		{
			get
			{
				return _registrationFee; 
			}
			set 
			{
				if (GeneralUtility.IsDecimal(value) || GeneralUtility.IsNull(value))
				{
					_registrationFee = value; 
				}
				else
				{
				throw new Exception("Invalid RegistrationFee");
				}
			}
		}
		[DataMapping("Is_Partial_Fee_Allowed")]
		public bool? IsPartialFeeAllowed
		{
			get
			{
				return _isPartialFeeAllowed; 
			}
			set 
			{
				if (GeneralUtility.IsBoolean(value) || GeneralUtility.IsNull(value))
				{
					_isPartialFeeAllowed = value; 
				}
				else
				{
				throw new Exception("Invalid IsPartialFeeAllowed");
				}
			}
		}
		[DataMapping("Is_Reservation_Allowed")]
		public bool? IsReservationAllowed
		{
			get
			{
				return _isReservationAllowed; 
			}
			set 
			{
				if (GeneralUtility.IsBoolean(value) || GeneralUtility.IsNull(value))
				{
					_isReservationAllowed = value; 
				}
				else
				{
				throw new Exception("Invalid IsReservationAllowed");
				}
			}
		}
		[DataMapping("Eligibility")]
		public string Eligibility
		{
			get
			{
				return _eligibility; 
			}
			set 
			{
				if (value.Length<= 4000)
				{
					_eligibility = value; 
				}
				else
				{
				throw new Exception("Invalid Eligibility");
				}
			}
		}
		[DataMapping("Instruction")]
		public string Instruction
		{
			get
			{
				return _instruction; 
			}
			set 
			{
				if (value.Length<= 4000)
				{
					_instruction = value; 
				}
				else
				{
				throw new Exception("Invalid Instruction");
				}
			}
		}
		[DataMapping("Disclaimer")]
		public string Disclaimer
		{
			get
			{
				return _disclaimer; 
			}
			set 
			{
				if (value.Length<= 4000)
				{
					_disclaimer = value; 
				}
				else
				{
				throw new Exception("Invalid Disclaimer");
				}
			}
		}
		public DataSet ReservationDetailData
		{
			get
			{
				return _reservationDetailData; 
			}
			set 
			{
				_reservationDetailData = value;
			}
		}
		public DataSet RegistrationEligibilityData
		{
			get
			{
				return _registrationEligibilityData; 
			}
			set 
			{
				_registrationEligibilityData = value;
			}
		}
        public MetadataMaster RegistrationStatusObject
        {
            get { return _registrationStatusId; }
            set { _registrationStatusId = value; }
        }
		#endregion 
	}
}
