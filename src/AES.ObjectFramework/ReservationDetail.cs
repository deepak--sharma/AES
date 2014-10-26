using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class ReservationDetail : BaseClassObject
	{

		#region Fields Name ...
		private int? _reservationId;
		private RegistrationMaster _registrationId;
		private MetadataMaster _reservationTypeId;
        private MetadataMaster _reservationCriteriaId;
        private MetadataMaster _reservationSubCriteriaId;
		private int? _value;
		private bool? _isPercent;
		#endregion 

		#region Object Properties ...
		[DataMapping("Reservation_Id",PrimaryKey=true)]
		public int? ReservationId
		{
			get
			{
				return _reservationId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_reservationId = value; 
				}
				else
				{
				throw new Exception("Invalid ReservationId");
				}
			}
		}
		
        [DataMapping("Registration_Id",ForeignKey=true)]
		public RegistrationMaster RegistrationObject
		{
			get
			{
				return _registrationId; 
			}
			set 
			{
				_registrationId = value;
			}
		}

        [DataMapping("Reservation_Type_Id", ForeignKey = true)]
        public MetadataMaster ReservationTypeObject
        {
            get
            {
                return _reservationTypeId;
            }
            set
            {
                _reservationTypeId = value;
            }
        }

        [DataMapping("Reservation_Criteria_Id", ForeignKey = true)]
        public MetadataMaster ReservationCriteriaObject
		{
			get
			{
                return _reservationCriteriaId; 
			}
			set 
			{
				_reservationCriteriaId = value;
			}
		}

        [DataMapping("Reservation_Sub_Criteria_Id", ForeignKey = true)]
        public MetadataMaster ReservationSubCriteriaObject
        {
            get
            {
                return _reservationSubCriteriaId;
            }
            set
            {
                _reservationSubCriteriaId = value;
            }
        }
       		
        [DataMapping("Value")]
        public int? Value
		{
			get
			{
                return _value; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
                    _value = value; 
				}
				else
				{
				throw new Exception("Invalid ActualSeat");
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
				throw new Exception("Invalid IsSeatPercent");
				}
			}
		}

        //Ids for select result grouping
        public int FreeSeatId { get; set; }
        public int ManagementSeatId { get; set; }
		
		#endregion 
	}
}
