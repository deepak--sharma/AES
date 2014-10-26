using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
    public class ActivityDetail : BaseClassObject
    {

        #region Fields Name ...
        private int? _activityDetailId;
        private ActivityMaster _activityId;
        private AcademicSessionMaster _sessionId;
        private BranchMaster _branchId;
        private ClassMaster _classId;
        private SubjectMaster _subjectId;
        private SectionMaster _sectionId;
        private StreamMaster _streamId;
        private DateTime? _startDate;
        private DateTime? _endDate;
        private EmployeeDetail _activityOwnerId;
        private string _description;
        private DataSet _studentAttendanceData = null;
        #endregion

        #region Object Properties ...
        [DataMapping("Activity_Detail_Id", PrimaryKey = true)]
        public int? ActivityDetailId
        {
            get
            {
                return _activityDetailId;
            }
            set
            {
                if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
                {
                    _activityDetailId = value;
                }
                else
                {
                    throw new Exception("Invalid ActivityDetailId");
                }
            }
        }
        [DataMapping("Activity_Id", ForeignKey = true)]
        public ActivityMaster ActivityObject
        {
            get
            {
                return _activityId;
            }
            set
            {
                _activityId = value;
            }
        }
        [DataMapping("Session_Id", ForeignKey = true)]
        public AcademicSessionMaster SessionObject
        {
            get
            {
                return _sessionId;
            }
            set
            {
                _sessionId = value;
            }
        }
        [DataMapping("Branch_Id", ForeignKey = true)]
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
        [DataMapping("Class_Id", ForeignKey = true)]
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
        [DataMapping("Subject_Id", ForeignKey = true)]
        public SubjectMaster SubjectObject
        {
            get
            {
                return _subjectId;
            }
            set
            {
                _subjectId = value;
            }
        }
        [DataMapping("Section_Id", ForeignKey = true)]
        public SectionMaster SectionObject
        {
            get
            {
                return _sectionId;
            }
            set
            {
                _sectionId = value;
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
        [DataMapping("Activity_Owner_Id", ForeignKey = true)]
        public EmployeeDetail ActivityOwnerObject
        {
            get
            {
                return _activityOwnerId;
            }
            set
            {
                _activityOwnerId = value;
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
                if (value.Length <= 500)
                {
                    _description = value;
                }
                else
                {
                    throw new Exception("Invalid Description");
                }
            }
        }
        public DataSet StudentAttendanceData
        {
            get
            {
                return _studentAttendanceData;
            }
            set
            {
                _studentAttendanceData = value;
            }
        }
        #endregion
    }
}
