using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class ActivityScheduleDetail : BaseClassObject
	{

		#region Fields Name ...
		private int? _activityScheduleId;
		private ActivityDetail _activityDetailId;
		private string _startTime;
		private string _endTime;
		private DateTime? _startDate;
		private DateTime? _endDate;
		private BranchMaster _branchId;
		private string _venue;
		private string _actualStartTime;
		private string _actualEndTime;
		private DateTime? _actualStartDate;
		private DateTime? _actualEndDate;
		private MetadataMaster _activityStatusId;
		#endregion 

		#region Object Properties ...
		[DataMapping("Activity_Schedule_Id",PrimaryKey=true)]
		public int? ActivityScheduleId
		{
			get
			{
				return _activityScheduleId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_activityScheduleId = value; 
				}
				else
				{
				throw new Exception("Invalid ActivityScheduleId");
				}
			}
		}
		[DataMapping("Activity_Detail_Id",ForeignKey=true)]
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
		[DataMapping("Start_Time")]
		public string StartTime
		{
			get
			{
				return _startTime; 
			}
			set 
			{
				if (value.Length<= 20)
				{
					_startTime = value; 
				}
				else
				{
				throw new Exception("Invalid StartTime");
				}
			}
		}
		[DataMapping("End_Time")]
		public string EndTime
		{
			get
			{
				return _endTime; 
			}
			set 
			{
				if (value.Length<= 20)
				{
					_endTime = value; 
				}
				else
				{
				throw new Exception("Invalid EndTime");
				}
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
		[DataMapping("Venue")]
		public string Venue
		{
			get
			{
				return _venue; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_venue = value; 
				}
				else
				{
				throw new Exception("Invalid Venue");
				}
			}
		}
		[DataMapping("Actual_Start_Time")]
		public string ActualStartTime
		{
			get
			{
				return _actualStartTime; 
			}
			set 
			{
				if (value.Length<= 20)
				{
					_actualStartTime = value; 
				}
				else
				{
				throw new Exception("Invalid ActualStartTime");
				}
			}
		}
		[DataMapping("Actual_End_Time")]
		public string ActualEndTime
		{
			get
			{
				return _actualEndTime; 
			}
			set 
			{
				if (value.Length<= 20)
				{
					_actualEndTime = value; 
				}
				else
				{
				throw new Exception("Invalid ActualEndTime");
				}
			}
		}
		[DataMapping("Actual_Start_Date")]
		public DateTime? ActualStartDate
		{
			get
			{
				return _actualStartDate; 
			}
			set 
			{
				if (GeneralUtility.IsDateTime(value) || GeneralUtility.IsNull(value))
				{
					_actualStartDate = value; 
				}
				else
				{
				throw new Exception("Invalid ActualStartDate");
				}
			}
		}
		[DataMapping("Actual_End_Date")]
		public DateTime? ActualEndDate
		{
			get
			{
				return _actualEndDate; 
			}
			set 
			{
				if (GeneralUtility.IsDateTime(value) || GeneralUtility.IsNull(value))
				{
					_actualEndDate = value; 
				}
				else
				{
				throw new Exception("Invalid ActualEndDate");
				}
			}
		}
		[DataMapping("Activity_Status_Id",ForeignKey=true)]
		public MetadataMaster ActivityStatusObject
		{
			get
			{
				return _activityStatusId; 
			}
			set 
			{
				_activityStatusId = value;
			}
		}
		#endregion 
	}
}
