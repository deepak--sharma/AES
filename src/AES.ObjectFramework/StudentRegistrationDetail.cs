using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
    public class StudentRegistrationDetail : BaseClassObject
    {

        #region Fields Name ...
        private int? _studentRegistrationId;
        private string _registrationNumber;
        private CandidateDetail _candidateId;
        private RegistrationMaster _registrationId;
        private decimal? _feeSubmited;
        private MetadataMaster _boardingTypeId;
        private bool? _isTransportRequired;
        private DateTime? _registrationDate;
        private MetadataMaster _registrationStatusId;
        private int? _distance;
        private int? _version;
        private string _comment;

        #endregion

        #region Object Properties ...
        [DataMapping("Student_Registration_Id", PrimaryKey=true)]
        public int? StudentRegistrationId
        {
            get
            {
                return _studentRegistrationId;
            }
            set
            {
                if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
                {
                    _studentRegistrationId = value;
                }
                else
                {
                    throw new Exception("Invalid StudentRegistrationId");
                }
            }
        }
        [DataMapping("Registration_Number")]
        public string RegistrationNumber
        {
            get
            {
                return _registrationNumber;
            }
            set
            {
                if (value.Length<= 100)
                {
                    _registrationNumber = value;
                }
                else
                {
                    throw new Exception("Invalid RegistrationNumber");
                }
            }
        }
        [DataMapping("Candidate_Id", ForeignKey=true)]
        public CandidateDetail CandidateObject
        {
            get
            {
                return _candidateId;
            }
            set
            {
                _candidateId = value;
            }
        }
        [DataMapping("Registration_Id", ForeignKey=true)]
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
        [DataMapping("Fee_Submited")]
        public decimal? FeeSubmited
        {
            get
            {
                return _feeSubmited;
            }
            set
            {
                if (GeneralUtility.IsDecimal(value) || GeneralUtility.IsNull(value))
                {
                    _feeSubmited = value;
                }
                else
                {
                    throw new Exception("Invalid FeeSubmited");
                }
            }
        }
        [DataMapping("Boarding_Type_Id", ForeignKey=true)]
        public MetadataMaster BoardingTypeObject
        {
            get
            {
                return _boardingTypeId;
            }
            set
            {
                _boardingTypeId = value;
            }
        }
        [DataMapping("Is_Transport_Required")]
        public bool? IsTransportRequired
        {
            get
            {
                return _isTransportRequired;
            }
            set
            {
                if (GeneralUtility.IsBoolean(value) || GeneralUtility.IsNull(value))
                {
                    _isTransportRequired = value;
                }
                else
                {
                    throw new Exception("Invalid IsTransportRequired");
                }
            }
        }
        [DataMapping("Registration_Date")]
        public DateTime? RegistrationDate
        {
            get
            {
                return _registrationDate;
            }
            set
            {
                if (GeneralUtility.IsDateTime(value) || GeneralUtility.IsNull(value))
                {
                    _registrationDate = value;
                }
                else
                {
                    throw new Exception("Invalid RegistrationDate");
                }
            }
        }
        [DataMapping("Registration_Status_Id", ForeignKey=true)]
        public MetadataMaster RegistrationStatusObject
        {
            get
            {
                return _registrationStatusId;
            }
            set
            {
                _registrationStatusId = value;
            }
        }
        [DataMapping("Distance")]
        public int? Distance
        {
            get
            {
                return _distance;
            }
            set
            {
                if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
                {
                    _distance = value;
                }
                else
                {
                    throw new Exception("Invalid Distance");
                }
            }
        }
        [DataMapping("Version")]
        public new int? Version
        {
            get
            {
                return _version;
            }
            set
            {
                _version = value;
            }
        }
        [DataMapping("Comment")]
        public string Comment
        {
            get
            {
                return _comment;
            }
            set
            {
                _comment = value;
            }
        }
        #endregion

        #region Additional Search Parameters...
        private DateTime? _startDate;
        private DateTime? _endDate;

        public DateTime? StartDate
        {
            get
            {
                return _startDate;
            }
            set
            {
                _startDate = value;
            }
        }
        public DateTime? EndDate
        {
            get
            {
                return _endDate;
            }
            set
            {
                _endDate = value;
            }
        }

        #endregion
    }
}
