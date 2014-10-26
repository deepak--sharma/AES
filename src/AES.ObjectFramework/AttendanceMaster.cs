using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class AttendanceMaster : BaseClassObject
	{

		#region Fields Name ...
		private int? _attendanceId;
		private int? _memberId;
		private MetadataMaster _memberTypeId;
		private int? _activityDetailId;
		private MetadataMaster _attendanceStatusId;
		private DateTime? _attendanceDate;
		private string _inTime;
		private string _outTime;
		private EmployeeDetail _markedBy;
		#endregion 

		#region Object Properties ...
		[DataMapping("Attendance_Id",PrimaryKey=true)]
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
		[DataMapping("Member_Id")]
		public int? MemberId
		{
			get
			{
				return _memberId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_memberId = value; 
				}
				else
				{
				throw new Exception("Invalid MemberId");
				}
			}
		}
		[DataMapping("Member_Type_Id",ForeignKey=true)]
		public MetadataMaster MemberTypeObject
		{
			get
			{
				return _memberTypeId; 
			}
			set 
			{
				_memberTypeId = value;
			}
		}
		[DataMapping("Activity_Detail_Id")]
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
		[DataMapping("Attendance_status_Id",ForeignKey=true)]
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
				if (value.Length<= 20)
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
				if (value.Length<= 20)
				{
					_outTime = value; 
				}
				else
				{
				throw new Exception("Invalid OutTime");
				}
			}
		}
		[DataMapping("Marked_By",ForeignKey=true)]
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
		#endregion 
	}
}
