using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class ActivityOwnership : BaseClassObject
	{

		#region Fields Name ...
		private int? _ownershipId;
		private ActivityScheduleDetail _activityScheduleId;
		private int? _memberId;
		private MetadataMaster _ownershipStatusId;
		private string _comment;
		#endregion 

		#region Object Properties ...
		[DataMapping("Ownership_Id",PrimaryKey=true)]
		public int? OwnershipId
		{
			get
			{
				return _ownershipId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_ownershipId = value; 
				}
				else
				{
				throw new Exception("Invalid OwnershipId");
				}
			}
		}
		[DataMapping("Activity_Schedule_Id",ForeignKey=true)]
		public ActivityScheduleDetail ActivityScheduleObject
		{
			get
			{
				return _activityScheduleId; 
			}
			set 
			{
				_activityScheduleId = value;
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
		[DataMapping("Ownership_Status_id",ForeignKey=true)]
		public MetadataMaster OwnershipStatusObject
		{
			get
			{
				return _ownershipStatusId; 
			}
			set 
			{
				_ownershipStatusId = value;
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
				if (value.Length<= 50)
				{
					_comment = value; 
				}
				else
				{
				throw new Exception("Invalid Comment");
				}
			}
		}
		#endregion 
	}
}
