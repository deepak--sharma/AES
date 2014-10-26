using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class ActivityMaster : BaseClassObject
	{

		#region Fields Name ...
		private int? _activityId;
		private string _activityName;
		private string _description;
		#endregion 

		#region Object Properties ...
		[DataMapping("Activity_Id",PrimaryKey=true)]
		public int? ActivityId
		{
			get
			{
				return _activityId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_activityId = value; 
				}
				else
				{
				throw new Exception("Invalid ActivityId");
				}
			}
		}
		[DataMapping("Activity_Name")]
		public string ActivityName
		{
			get
			{
				return _activityName; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_activityName = value; 
				}
				else
				{
				throw new Exception("Invalid ActivityName");
				}
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
				if (value.Length<= 500)
				{
					_description = value; 
				}
				else
				{
				throw new Exception("Invalid Description");
				}
			}
		}
		#endregion 
	}
}
