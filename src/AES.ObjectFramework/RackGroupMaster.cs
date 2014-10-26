using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using AES.SolutionFramework;


namespace AES.ObjectFramework
{
	public class RackGroupMaster : BaseClassObject
	{

		#region Fields Name ...
		private int? _rackGroupId;
		private string _rackGroupName;
		private string _description;
		#endregion 

		#region Object Properties ...
		[DataMapping("Rack_Group_ID",PrimaryKey=true)]
		public int? RackGroupId
		{
			get
			{
				return _rackGroupId; 
			}
			set 
			{
				if (GeneralUtility.IsInteger(value) || GeneralUtility.IsNull(value))
				{
					_rackGroupId = value; 
				}
				else
				{
				throw new Exception("Invalid RackGroupId");
				}
			}
		}
		[DataMapping("Rack_Group_Name")]
		public string RackGroupName
		{
			get
			{
				return _rackGroupName; 
			}
			set 
			{
				if (value.Length<= 100)
				{
					_rackGroupName = value; 
				}
				else
				{
				throw new Exception("Invalid RackGroupName");
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
