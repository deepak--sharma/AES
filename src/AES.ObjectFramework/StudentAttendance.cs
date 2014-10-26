using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
    public class StudentAttendance : BaseClassObject
    {

        #region Fields Name ...
        private int? _attendanceId;
        private StudentDetail _studentId;
        private ActivityDetail _activityDetailId;
        private MetadataMaster _attendanceStatusId;
        private DateTime? _attendanceDate;
        private string _inTime;
        private string _outTime;
        private EmployeeDetail _markedBy;
        private string _comments;
        #endregion

        #region Object Properties ...
        [DataMapping("Attendance_Id", PrimaryKey = true)]
        public int? AttendanceId
        {
            get
            {
                return _attendanceId;
            }
            set
            {
                if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
                {
                    _attendanceId = value;
                }
                else
                {
                    throw new Exception("Invalid AttendanceId");
                }
            }
        }
        [DataMapping("Student_Id", ForeignKey = true)]
        public StudentDetail StudentObject
        {
            get
            {
                return _studentId;
            }
            set
            {
                _studentId = value;
            }
        }
        [DataMapping("Activity_Detail_Id", ForeignKey = true)]
        public ActivityDetail ActivityDetailObject
        {
            get
            {
                return _activityDetailId;
            }
            set
            {
                _activityDetailId = value;
            }
        }
        [DataMapping("Attendance_status_Id", ForeignKey = true)]
        public MetadataMaster AttendanceStatusObject
        {
            get
            {
                return _attendanceStatusId;
            }
            set
            {
                _attendanceStatusId = value;
            }
        }
        [DataMapping("Attendance_Date")]
        public DateTime? AttendanceDate
        {
            get
            {
                return _attendanceDate;
            }
            set
            {
                if (GeneralUtility.IsDateTime(value) || GeneralUtility.IsNull(value))
                {
                    _attendanceDate = value;
                }
                else
                {
                    throw new Exception("Invalid AttendanceDate");
                }
            }
        }
        [DataMapping("In_Time")]
        public string InTime
        {
            get
            {
                return _inTime;
            }
            set
            {
                if (value.Length <= 20)
                {
                    _inTime = value;
                }
                else
                {
                    throw new Exception("Invalid InTime");
                }
            }
        }
        [DataMapping("Out_Time")]
        public string OutTime
        {
            get
            {
                return _outTime;
            }
            set
            {
                if (value.Length <= 20)
                {
                    _outTime = value;
                }
                else
                {
                    throw new Exception("Invalid OutTime");
                }
            }
        }
        [DataMapping("Marked_By", ForeignKey = true)]
        public EmployeeDetail MarkedBy
        {
            get
            {
                return _markedBy;
            }
            set
            {
                _markedBy = value;
            }
        }
        [DataMapping("Comments")]
        public string Comments
        {
            get
            {
                return _comments;
            }
            set
            {
                if (value.Length <= 200)
                {
                    _comments = value;
                }
                else
                {
                    throw new Exception("Invalid Comments");
                }
            }
        }
        #endregion
    }
}
